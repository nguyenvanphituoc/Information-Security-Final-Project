using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FPBMTTC_FinalC_M_vs2017.Model
{
    public enum PacketType
    {
        PersonalData,
        User,
        X509CertificateModel
    }
    class Packet
    {
        static private string prefixOnWeb = "http://finalc-m.gear.host/FinalC-M/Values/";
        static private string prefixOnLocal = "https://localhost/Restful/FinalC-M/Values/";
        static public string prefixUsage = prefixOnLocal;
        RSAParameters rsaPubParams;
        RSAParameters rsaPrivateParams;
        public PacketType packetType;

        public Packet(PacketType type, string senderId)
        {
            this.packetType = type;
        }

        public Packet(byte[] packetBytes)
        {
            Packet p = (Packet)Packet.Deserialize(packetBytes);
            packetType = p.packetType;
        }
        public static string getIp4Address()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress i in ips)
            {
                if (i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return i.ToString();
                }
            }
            return "127.0.0.1";
        }
        //data streamer 
        public static byte[] Serialize(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }
        public static object Deserialize(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }
        //Encrypts using only the public key data.
        public byte[] EncryptData(RSAParameters rsaParams, byte[] toEncrypt)
        {
            using (RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider())
            {
                rsaCSP.ImportParameters(rsaParams);
                return rsaCSP.Encrypt(toEncrypt, false);
            }
        }
        //Decrypt using the private key data.
        public byte[] DecryptData(byte[] encrypted)
        {
            byte[] fromEncrypt;
            string roundTrip;
            ASCIIEncoding myAscii = new ASCIIEncoding();
            using (RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider())
            {
                rsaCSP.ImportParameters(rsaPrivateParams);
                fromEncrypt = rsaCSP.Decrypt(encrypted, false);
                roundTrip = Clibs_14110434.ConvertBytetoString(fromEncrypt);

                Console.WriteLine("RoundTrip: {0}", roundTrip);
                return fromEncrypt;
            }
        }
        //Manually performs hash and then signs hashed value.
        public byte[] HashAndSign(byte[] encrypted)
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();
            SHA1Managed hash = new SHA1Managed();
            byte[] hashedData;

            rsaCSP.ImportParameters(rsaPrivateParams);

            hashedData = hash.ComputeHash(encrypted);
            return rsaCSP.SignHash(hashedData, CryptoConfig.MapNameToOID("SHA1"));
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
    }
}
