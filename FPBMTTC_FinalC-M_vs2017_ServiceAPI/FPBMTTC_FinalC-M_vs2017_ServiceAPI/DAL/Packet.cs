using FPBMTTC_FinalC_M_vs2017_ServiceAPI.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Xml;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.DAL
{
    class Packet
    {
        public RSAParameters rsaPubParams;
        RSAParameters rsaPrivateParams;
        const string priKey = "privateKey.xml";
        const string pubKey = "publicKey.xml";

        public Packet()
        {
            BuildKeyPairs();
        }
        /*       public Packet(PacketType type, string senderId)
               {
                   BuildKeyPairs();
                   this.packetType = type;
               }

               public Packet(byte[] packetBytes)
               {
                   BuildKeyPairs();
                   Packet p = (Packet)Packet.Deserialize(packetBytes);
                   packetType = p.packetType;
               }
               public static string GetIp4Address()
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
               }*/

        public void BuildKeyPairs()
        {
            string physicalPath = HostingEnvironment.MapPath(@"/" + priKey);
            String xml = Clibs_14110434.ReadTextFile_14110434(physicalPath);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xml);

            rsaPubParams = rsa.ExportParameters(false);
            rsaPrivateParams = rsa.ExportParameters(true);

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