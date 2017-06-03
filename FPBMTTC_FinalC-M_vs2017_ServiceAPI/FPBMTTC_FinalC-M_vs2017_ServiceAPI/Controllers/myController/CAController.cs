using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Operators;
using System.IO;
using FPBMTTC_FinalC_M_vs2017_ServiceAPI.Models;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.DAL
{
    class CAController
    {
        public static byte[] CertSign(X509CertificateModel cert, RSAParameters rsaPrivateParams)
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();
            SHA1Managed hash = new SHA1Managed();
            byte[] bytesData = cert.ToByte();
            byte[] hashedData = hashedData = hash.ComputeHash(bytesData);
            rsaCSP.ImportParameters(rsaPrivateParams);
            return rsaCSP.SignHash(hashedData, CryptoConfig.MapNameToOID("SHA1"));
        }

        public static bool VerifyCertSign(RSACryptoServiceProvider csp, X509CertificateModel x509)
        {
            /*// Load the certificate we’ll use to verify the signature from a file
            X509Certificate2 cert = new X509Certificate2(certPath);
            // Note:
            // If we want to use the client cert in an ASP.NET app, we may use something like this instead:
            // X509Certificate2 cert = new X509Certificate2(Request.ClientCertificate.Certificate);
            // Get its associated CSP and public key
            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PublicKey.Key;*/
            // Hash the data
            SHA1Managed sha1 = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = x509.ToByte();
            byte[] hash = sha1.ComputeHash(data);
            // Verify the signature with the hash
            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), x509.Signature);
        }

        public static AsymmetricAlgorithm ToDotNetKey(RsaPrivateCrtKeyParameters privateKey)
        {
            var cspParams = new CspParameters
            {
                KeyContainerName = Guid.NewGuid().ToString(),
                KeyNumber = (int)KeyNumber.Exchange,
                Flags = CspProviderFlags.UseMachineKeyStore
            };

            var rsaProvider = new RSACryptoServiceProvider(cspParams);
            var parameters = new RSAParameters
            {
                Modulus = privateKey.Modulus.ToByteArrayUnsigned(),
                P = privateKey.P.ToByteArrayUnsigned(),
                Q = privateKey.Q.ToByteArrayUnsigned(),
                DP = privateKey.DP.ToByteArrayUnsigned(),
                DQ = privateKey.DQ.ToByteArrayUnsigned(),
                InverseQ = privateKey.QInv.ToByteArrayUnsigned(),
                D = privateKey.Exponent.ToByteArrayUnsigned(),
                Exponent = privateKey.PublicExponent.ToByteArrayUnsigned()
            };

            rsaProvider.ImportParameters(parameters);
            return rsaProvider;
        }

        public static X509Certificate2 GenerateCACertificate(String subjectName, ref RsaPrivateCrtKeyParameters CaPrivateKey)
        {
            const int keyStrength = 2048;

            // Generating Random Numbers
            CryptoApiRandomGenerator randomGenerator = new CryptoApiRandomGenerator();
            SecureRandom random = new SecureRandom(randomGenerator);

            // The Certificate Generator
            X509V3CertificateGenerator certificateGenerator = new X509V3CertificateGenerator();

            // Serial Number
            BigInteger serialNumber = BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), random);
            certificateGenerator.SetSerialNumber(serialNumber);

            // Signature Algorithm
            const string signatureAlgorithm = "SHA1WithRSA";

            // Issuer and Subject Name
            X509Name subjectDN = new X509Name(true, subjectName);
            X509Name issuerDN = subjectDN;
            certificateGenerator.SetIssuerDN(issuerDN);
            certificateGenerator.SetSubjectDN(subjectDN);

            // Valid For
            DateTime notBefore = DateTime.UtcNow.Date;
            DateTime notAfter = notBefore.AddYears(2);

            certificateGenerator.SetNotBefore(notBefore);
            certificateGenerator.SetNotAfter(notAfter);

            // Subject Public Key
            AsymmetricCipherKeyPair subjectKeyPair;
            KeyGenerationParameters keyGenerationParameters = new KeyGenerationParameters(random, keyStrength);
            RsaKeyPairGenerator keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            subjectKeyPair = keyPairGenerator.GenerateKeyPair();

            certificateGenerator.SetPublicKey(subjectKeyPair.Public);

            // Generating the Certificate
            AsymmetricCipherKeyPair issuerKeyPair = subjectKeyPair;

            // selfsign certificate
            ISignatureFactory signatureFactory = new Asn1SignatureFactory(signatureAlgorithm, issuerKeyPair.Private, random);
            Org.BouncyCastle.X509.X509Certificate certificate = certificateGenerator.Generate(signatureFactory);
            X509Certificate2 x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(certificate.GetEncoded());

            CaPrivateKey = issuerKeyPair.Private as RsaPrivateCrtKeyParameters;
            return x509;
            //return issuerKeyPair.Private;

        }

        public static string ToXmlString(RsaPrivateCrtKeyParameters privKey)
        {
            return ToDotNetKey(privKey).ToXmlString(true);
        }

        private static byte[] ConvertRSAParametersField(BigInteger n, int size)
        {
            byte[] bs = n.ToByteArrayUnsigned();
            if (bs.Length == size)
                return bs;
            if (bs.Length > size)
                throw new ArgumentException("Specified size too small", "size");
            byte[] padded = new byte[size];
            Array.Copy(bs, 0, padded, size - bs.Length, bs.Length);
            return padded;
        }

        // database
        public static bool CreateDigitalCertificate(X509CertificateModel cert, RSACryptoServiceProvider rsa, int usrId)
        {
            bool bRet = false;

            try
            {
                string err = "";

                Packet p = ValuesController.P;
                cert.SeriralNumber = Clibs_14110434.ConvertBytetoString(p.EncryptData(p.rsaPubParams, Clibs_14110434.ConvertStringtoByte(cert.SeriralNumber)));

                if (X509CertificateModel.InsertX509Cert(cert, ref err))
                {
                    using (MagicECertCAEntities context = new MagicECertCAEntities())
                    {
                        var publicKey = rsa.ToXmlString(false);
                        var privatekey = rsa.ToXmlString(true);

                        var ca = context.X509Certificate.OrderByDescending(myCert => myCert.id).Take(1).FirstOrDefault();

                        var data = new PersonalDataModel()
                        {
                            UId = usrId,
                            CaId = ca.id,
                            PrivateKey = privatekey,
                            PublicKey = publicKey,
                            SerialNumber = ca.serial_number
                        };
                        return PersonalDataModel.InsertPersonalData(data, ref err);
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }

            return bRet;
        }
      
        public static bool RevokeDigitalCertificate(string serialNumber, int usrId)
        {
            return PersonalDataModel.Revoke(usrId, serialNumber);
        }

        public static bool UpdateDigitalCertificate(string serialNumber, string subjectName)
        {
            var x509 = X509CertificateModel.GetRecord(serialNumber);
            var keyData = PersonalDataModel.GetPersonalData(serialNumber);
            x509.SubjectName = subjectName;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(keyData.PrivateKey);

            x509.Signature = CertSign(x509, rsa.ExportParameters(true));
            return X509CertificateModel.UpdateRecord(serialNumber, x509);
        }

        public static List<X509CertificateModel> SearchDigitalCertificates(string subjectName)
        {
            return X509CertificateModel.GetListRecord(subjectName);
        }

        public static bool VerifyDigitalCertificate(string serialNumber, int usrId)
        {
            var cert = X509CertificateModel.GetRecord(serialNumber);
            var keyData = PersonalDataModel.GetPersonalData(usrId, serialNumber);

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(keyData.PublicKey);

            return VerifyCertSign(rsa, cert);
        }
    }
}
