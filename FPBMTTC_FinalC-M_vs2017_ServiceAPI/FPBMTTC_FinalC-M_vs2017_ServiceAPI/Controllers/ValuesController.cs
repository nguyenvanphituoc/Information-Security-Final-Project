using DAL;
using FPBMTTC_FinalC_M_vs2017_ServiceAPI.Models;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.DAL
{
    public class ValuesController : ApiController
    {
        DBConnect Datase = null;
        static private Packet p = null;
        public ValuesController()
        {
            try
            {
                Datase = new DBConnect(new HelperModel().BuildConnectionString());
                p = new Packet();
            }
            catch(Exception ex)
            {

            }
        }
        // GET 
        internal static Packet P { get { return p; } }

        [HttpGet]
        public bool GenerateCA(string subjectName, int userId)//"CN=abcd; OU=abcd; O=abcd; C=abc"
        {
            try
            {
                RsaPrivateCrtKeyParameters CaPrivateKey = 1234 as Object as RsaPrivateCrtKeyParameters;
                X509Certificate2 x509 = CAController.GenerateCACertificate(subjectName, ref CaPrivateKey);
                X509CertificateModel model = new X509CertificateModel(x509);
                RSACryptoServiceProvider rsa = CAController.ToDotNetKey(CaPrivateKey) as RSACryptoServiceProvider;
                model.Signature = CAController.CertSign(model, rsa.ExportParameters(true));//8
                return CAController.CreateDigitalCertificate(model, rsa, userId);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        public List<X509CertificateModel> SearchCert(string subjectName)
        {
            try
            {
                return CAController.SearchDigitalCertificates(subjectName);
            }
            catch
            {
                return new List<X509CertificateModel>();
            }
        }

        [HttpGet]
        public bool RevokeDigitalCert(int usrId, string serialNumber)
        {
            try
            {
                return CAController.RevokeDigitalCertificate(serialNumber, usrId);
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        public bool VerifiedDigitalCert(string serialNumber, int usrId)
        {
            try
            {
                return CAController.VerifyDigitalCertificate(serialNumber, usrId);
            }
            catch
            {
                return false;
            }
        }

        // POST 
        [HttpPost]
        public bool RegisterUser([FromBody]UserModel model)
        {
            try
            {
                string err = "";
                return UserController.CreateNewUser(model);
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        public UserModel LoginUser([FromBody]UserModel model)
        {
            try
            {
                return UserController.GetUser(model);
            }
            catch
            {
                return new UserModel();
            }
        }

        // PUT api/values/5
        public bool UpdateCert(string serialNumber, [FromBody]string subjectName)
        {
            try
            {
                return CAController.UpdateDigitalCertificate(serialNumber, subjectName);
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
