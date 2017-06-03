using FPBMTTC_FinalC_M_vs2017_ServiceAPI;
using FPBMTTC_FinalC_M_vs2017_ServiceAPI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.Models
{
    public class UserModel
    {
        private int uId;
        private String uName;
        private String uPasswd;
        private String uEmail;

        public int UId
        {
            get { return uId; }
            set { uId = value; }
        }
        public string UName
        {
            get { return uName; }
            set { uName = value; }
        }
        public string UPasswd
        {
            get { return uPasswd; }
            set { uPasswd = value; }
        }
        public string UEmail
        {
            get { return uEmail; }
            set { uEmail = value; }
        }

        public UserModel()
        {

        }

        public UserModel(FPBMTTC_FinalC_M_vs2017_ServiceAPI.User usr)
        {
            this.UName = usr.uName;//1
            this.UPasswd = usr.uPasswd;//2
            this.UEmail = usr.uEmail;//3
            this.UId = usr.uId;//4
        }

        public static bool InsertUser(UserModel model, ref string err)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    db.spInsertUser(model.UName, model.UPasswd, model.UEmail);
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

        public static UserModel FindUser(UserModel model, ref string err)
        {
            try
            {
                using (MagicECertCAEntities db = new MagicECertCAEntities())
                {
                    var findedUser = (from user in db.Users
                            where user.uName == model.uName
                            select user).Take(1).SingleOrDefault();
                    
                    Packet p = ValuesController.P;
                    findedUser.uEmail = Clibs_14110434.ConvertBytetoString(p.DecryptData(Clibs_14110434.ConvertStringtoByte(findedUser.uEmail)));
                    findedUser.uPasswd = Clibs_14110434.ConvertBytetoString(p.DecryptData(Clibs_14110434.ConvertStringtoByte(findedUser.uPasswd)));

                    if (findedUser.uPasswd.Equals(model.UPasswd))
                        return new UserModel(findedUser);
                    else
                        return new UserModel();
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return new UserModel(); 
            }
        }

        public List<PersonalDataModel> PersonalDatas;
    }
}