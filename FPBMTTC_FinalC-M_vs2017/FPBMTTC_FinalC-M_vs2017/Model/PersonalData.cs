using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPBMTTC_FinalC_M_vs2017.Model
{
    public class PersonalData
    {
        private int uId;
        private int caId;
        private String serialNumber;
        private String publicKey;
        private String privateKey;

        public int UId { get => uId; set => uId = value; }
        public int CaId { get => caId; set => caId = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string PublicKey { get => publicKey; set => publicKey = value; }
        public string PrivateKey { get => privateKey; set => privateKey = value; }

        public UserModel User;
        public X509CertificateModel X509;
    }
}