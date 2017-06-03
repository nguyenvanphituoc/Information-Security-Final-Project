using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FPBMTTC_FinalC_M_vs2017.Model
{
    class ReceiverModel
    {
        RSAParameters rsaPubParams;
        RSAParameters rsaPrivateParams;

        public ReceiverModel()
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();

            //Generate public and private key data.
            rsaPrivateParams = rsaCSP.ExportParameters(true);
            rsaPubParams = rsaCSP.ExportParameters(false);
        }

        public RSAParameters PublicParameters
        {
            get
            {
                return rsaPubParams;
            }
        }

        //Manually performs hash and then verifies hashed value.
        public bool VerifyHash(RSAParameters rsaParams, byte[] signedData, byte[] signature)
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();
            SHA1Managed hash = new SHA1Managed();
            byte[] hashedData;

            rsaCSP.ImportParameters(rsaParams);
            bool dataOK = rsaCSP.VerifyData(signedData, CryptoConfig.MapNameToOID("SHA1"), signature);
            hashedData = hash.ComputeHash(signedData);
            return rsaCSP.VerifyHash(hashedData, CryptoConfig.MapNameToOID("SHA1"), signature);
        }

        //Decrypt using the private key data.
        public void DecryptData(byte[] encrypted)
        {
            byte[] fromEncrypt;
            string roundTrip;
            ASCIIEncoding myAscii = new ASCIIEncoding();
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();

            rsaCSP.ImportParameters(rsaPrivateParams);
            fromEncrypt = rsaCSP.Decrypt(encrypted, false);
            roundTrip = myAscii.GetString(fromEncrypt);

            Console.WriteLine("RoundTrip: {0}", roundTrip);
        }
    }
}
