using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPBMTTC_FinalC_M_vs2017.Model
{
    public class UserModel
    {
        private int uId;
        private String uName;
        private String uPasswd;
        private String uEmail;



        public int UId { get => uId; set => uId = value; }
        public string UName { get => uName; set => uName = value; }
        public string UPasswd { get => uPasswd; set => uPasswd = value; }
        public string UEmail { get => uEmail; set => uEmail = value; }

        public void SetProperty(string key, object value)
        {
            switch (key)
            {
                case "UId":
                    this.UId = Int32.Parse(value as string);
                    break;
                case "UName":
                    this.UName = value as string;
                    break;
                case "UPasswd":
                    this.UPasswd = value as string;
                    break;
                case "UEmail":
                    this.UEmail = value as string;
                    break;
                default:
                    break;
            }
        }

        public List<PersonalData> PersonalDatas;
    }
}