using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPBMTTC_FinalC_M_vs2017.Model
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
        private String publicKey;
        private String extensions;
        private String signature;

        public int Id { get => id; set => id = value; }
        public double Version { get => version; set => version = value; }
        public string SeriralNumber { get => seriralNumber; set => seriralNumber = value; }
        public string SignatureAlgorithm { get => signatureAlgorithm; set => signatureAlgorithm = value; }
        public string IssuerName { get => issuerName; set => issuerName = value; }
        public string ValidityPeriod { get => validityPeriod; set => validityPeriod = value; }
        public string SubjectName { get => subjectName; set => subjectName = value; }
        public string PublicKey { get => publicKey; set => publicKey = value; }
        public string Extensions { get => extensions; set => extensions = value; }
        public string Signature { get => signature; set => signature = value; }

        public void SetProperty(string key, object value)
        {
            switch (key)
            {
                case "Id":
                    this.id = Int32.Parse(value as string);
                    break;
                case "SeriralNumber":
                    this.seriralNumber = value as string;
                    break;
                case "SignatureAlgorithm":
                    this.signatureAlgorithm = value as string;
                    break;
                case "Version":
                    this.version = Double.Parse(value as string);
                    break;
                case "IssuerName":
                    this.issuerName = value as string;
                    break;
                case "ValidityPeriod":
                    this.ValidityPeriod = value as string;
                    break;
                case "SubjectName":
                    this.subjectName = value as string;
                    break;
                case "PublicKey":
                    this.publicKey = value as string;
                    break;
                case "Extensions":
                    this.extensions = value as string;
                    break;
                case "Signature":
                    this.signature = value as string;
                    break;
                default:
                    break;
            }
        }

        public List<PersonalData> PersonalDatas;
    }
}