using FPBMTTC_FinalC_M_vs2017_ServiceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FPBMTTC_FinalC_M_vs2017_ServiceAPI.DAL;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.Models
{
    public class PersonalDataModel
    {
        private int uId;
        private int caId;
        private String serialNumber;
        private String publicKey;
        private String privateKey;
        private bool enable;

        public int UId
        {
            get { return uId; }
            set { uId = value; }
        }
        public int CaId
        {
            get { return caId; }
            set { caId = value; }
        } 

        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public string PublicKey
        {
            get { return publicKey; }
            set { publicKey = value; }
        }

        public string PrivateKey
        {
            get { return privateKey; }
            set { privateKey = value; }
        }

        public bool Enable { get { return enable; } set { enable = value; } }

        public PersonalDataModel() { }

        public PersonalDataModel(PersonalData data)
        {
            this.CaId = data.ca_id;
            this.PrivateKey = data.caPriKey;
            this.PublicKey = data.caPubkey;
            this.UId = data.uId;
            this.Enable = data.caEnable;
            this.SerialNumber = data.ca_serial_number;
        }

        public static bool InsertPersonalData (PersonalDataModel model, ref string err)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    db.spInsertPersonalData(model.PublicKey, model.PrivateKey, model.SerialNumber, model.UId, model.CaId);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public static PersonalDataModel GetPersonalData(int usrId, string serialNumber)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    var keyDatas = (from data in db.PersonalDatas
                                  where data.uId == usrId
                                  select data);

                    Packet p = ValuesController.P;

                    foreach (var keyData in keyDatas)
                    {
                        keyData.ca_serial_number = Clibs_14110434.ConvertBytetoString(p.DecryptData(Clibs_14110434.ConvertStringtoByte(keyData.ca_serial_number)));
                        if (keyData.ca_serial_number.Equals(serialNumber))
                            return new PersonalDataModel(keyData);
                    }

                    return new PersonalDataModel();
                }
            }
            catch (Exception ex)
            {
                return new PersonalDataModel();
            }
        }

        public static PersonalDataModel GetPersonalData(string serialNumber)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    Packet p = ValuesController.P;

                    foreach (var keyData in db.PersonalDatas)
                    {
                        keyData.ca_serial_number = Clibs_14110434.ConvertBytetoString(p.DecryptData(Clibs_14110434.ConvertStringtoByte(keyData.ca_serial_number)));
                        if (keyData.ca_serial_number.Equals(serialNumber))
                            return new PersonalDataModel(keyData);
                    }
                    return new PersonalDataModel();
                }
            }
            catch (Exception ex)
            {
                return new PersonalDataModel();
            }
        }

        public static bool Revoke(int usrId, string serialNumber)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    var keyDatas = from data in db.PersonalDatas
                                   where data.uId == usrId
                                   select data;

                    Packet p = ValuesController.P;

                    foreach(var keyData in keyDatas)
                    {
                        keyData.ca_serial_number = Clibs_14110434.ConvertBytetoString(p.DecryptData(Clibs_14110434.ConvertStringtoByte(keyData.ca_serial_number)));
                        if(keyData.ca_serial_number.Equals(serialNumber))
                            keyData.caEnable = false;
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserModel User;
        public X509CertificateModel X509;
    }
}