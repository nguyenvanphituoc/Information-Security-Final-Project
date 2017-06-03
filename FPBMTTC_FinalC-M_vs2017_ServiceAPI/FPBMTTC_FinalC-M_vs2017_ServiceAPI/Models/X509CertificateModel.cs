using DAL;
using FPBMTTC_FinalC_M_vs2017_ServiceAPI.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using FPBMTTC_FinalC_M_vs2017_ServiceAPI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.Models
{
    public class X509CertificateModel
    {
        private int id;
        private double version;
        private String seriralNumber;
        private String signatureAlgorithm;
        private String issuerName;
        private String validityPeriod;
        private String subjectName;
        private String extensions;
        private byte[] publicKey;
        private byte[] signature;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Version
        {
            get { return version; }
            set { version = value; }
        }
        public string SeriralNumber
        {
            get { return seriralNumber; }
            set { seriralNumber = value; }
        }
        public string SignatureAlgorithm
        {
            get { return signatureAlgorithm; }
            set { signatureAlgorithm = value; }
        }
        public string IssuerName
        {
            get { return issuerName; }
            set { issuerName = value; }
        }
        public string ValidityPeriod
        {
            get { return validityPeriod; }
            set { validityPeriod = value; }
        }
        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }
        public byte[] PublicKey
        {
            get { return publicKey; }
            set { publicKey = value; }
        }
        public string Extensions
        {
            get { return extensions; }
            set { extensions = value; }
        }
        public byte[] Signature
        {
            get { return signature; }
            set { signature = value; }
        }

        public X509CertificateModel() { }

        public X509CertificateModel(X509Certificate2 x509)
        {
            this.SeriralNumber = x509.SerialNumber;//1
            this.SubjectName = x509.Subject;//2
            this.IssuerName = x509.Issuer;//3
            this.SignatureAlgorithm = x509.SignatureAlgorithm.FriendlyName;//4
            this.ValidityPeriod = x509.NotBefore.ToString() + ";" + x509.NotAfter.ToString();//5
            this.Version = x509.Version;//6
            this.PublicKey = x509.GetPublicKey();//7
            this.Signature = null;//8
            this.Extensions = null; //9
        }

        public X509CertificateModel(FPBMTTC_FinalC_M_vs2017_ServiceAPI.X509Certificate x509)
        {
            this.Id = x509.id;
            this.SeriralNumber = x509.serial_number;//1
            this.SubjectName = x509.subject_name;//2
            this.IssuerName = x509.issuer_name;//3
            this.SignatureAlgorithm = x509.signature_algorithm;//4
            this.ValidityPeriod = x509.validity_period;//5
            this.Version = x509.version;//6
            this.PublicKey = Clibs_14110434.ConvertStringtoByte(x509.public_key);//7
            this.Signature = Clibs_14110434.ConvertStringtoByte(x509.signature);//8
            this.Extensions = x509.extensions; //9
        }

        public byte[] ToByte()
        {
            string sbytes = this.SeriralNumber + "--" + this.SubjectName + "--" + this.IssuerName + "--" + this.SignatureAlgorithm + "--" +
                     this.ValidityPeriod + "--" + this.Version + "--" + this.Extensions + "--" + this.PublicKey;
            return Packet.Serialize(sbytes);
        }

        public void SetProperty(string key, object value)
        {
            switch (key)
            {
                case "id":
                    this.Id = Int32.Parse(value as string);
                    break;
                case "version":
                    this.Version = Double.Parse(value as string);
                    break;
                case "serial_number":
                    this.SeriralNumber = value as string;
                    break;
                case "signature_algorithm":
                    this.SignatureAlgorithm = value as string;
                    break;
                case "issuer_name":
                    this.IssuerName = value as string;
                    break;
                case "validity_period":
                    this.ValidityPeriod = value as string;
                    break;
                case "subject_name":
                    this.SubjectName = value as string;
                    break;
                case "public_key":
                    this.PublicKey = value as byte[];
                    break;
                case "extensions":
                    this.Extensions = value as string;
                    break;
                case "signature":
                    this.Signature = value as byte[];
                    break;
                default:
                    break;
            }
        }

        public static bool InsertX509Cert(X509CertificateModel x509, ref string err)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                        bool result =  db.spInsertX509Cert(x509.Version, x509.SeriralNumber,
                        x509.SignatureAlgorithm, x509.IssuerName,
                        x509.ValidityPeriod, x509.SubjectName,
                        Clibs_14110434.ConvertBytetoString(x509.PublicKey), x509.Extensions,
                        Clibs_14110434.ConvertBytetoString(x509.Signature)) >= 1? true : false;
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public static X509CertificateModel GetRecord(int usrId)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    var x509 = db.X509Certificate.OrderByDescending(cert => cert.id).Take(1).FirstOrDefault();
                    Packet p = ValuesController.P;
                    x509.serial_number = Clibs_14110434.ConvertBytetoString(p.DecryptData(Clibs_14110434.ConvertStringtoByte(x509.serial_number)));
                    return new X509CertificateModel(x509);
                }
            }
            catch (Exception ex)
            {
            }
            return new X509CertificateModel();
        }

        public static X509CertificateModel GetRecord(string serialNumber)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    //var x509 = db.X509Certificate.Where(cert => cert.serial_number == serialNumber).Take(1).FirstOrDefault();

                    Packet p = ValuesController.P;

                    foreach(var x509 in db.X509Certificate)
                    {
                        x509.serial_number = Clibs_14110434.ConvertBytetoString(p.DecryptData(Clibs_14110434.ConvertStringtoByte(x509.serial_number)));
                        if(x509.serial_number.Equals(serialNumber))
                          return  new X509CertificateModel(x509);
                    }
                    return new X509CertificateModel();
                }
            }
            catch (Exception ex)
            {
            }
            return new X509CertificateModel();
        }

        public static bool UpdateRecord(string serialNumber, X509CertificateModel model)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    var x509 = db.X509Certificate.Find(model.id);
                    x509.subject_name = model.SubjectName;
                    x509.public_key = Clibs_14110434.ConvertBytetoString(model.PublicKey);
                    x509.signature = Clibs_14110434.ConvertBytetoString(model.Signature);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public static List<X509CertificateModel> GetListRecord(string subjectName)
        {
            List<X509CertificateModel> list = new List<X509CertificateModel>();
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    var x509 = from cert in db.X509Certificate
                                join data in db.PersonalDatas on cert.serial_number equals data.ca_serial_number
                               where (cert.subject_name.Contains(subjectName.ToUpper()) ||
                                        cert.subject_name.Contains(subjectName.ToLower()) ||
                                        cert.subject_name.Contains(subjectName)) && data.caEnable == true
                               select cert;
                    foreach(var cert in x509)
                    {
                        Packet p = ValuesController.P;
                        cert.serial_number = Clibs_14110434.ConvertBytetoString(p.DecryptData(Clibs_14110434.ConvertStringtoByte(cert.serial_number)));
                        list.Add(new X509CertificateModel(cert));
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public List<PersonalDataModel> PersonalDatas;
    }
}