using FPBMTTC_FinalC_M_vs2017_ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.DAL
{
    public class UserController
    {
        // database
        public static bool CreateNewUser(UserModel model)
        {
            try
            {
                string err = "";
                Packet p = ValuesController.P;
                model.UEmail = Clibs_14110434.ConvertBytetoString(p.EncryptData(p.rsaPubParams, Clibs_14110434.ConvertStringtoByte(model.UEmail)));
                model.UPasswd = Clibs_14110434.ConvertBytetoString(p.EncryptData(p.rsaPubParams, Clibs_14110434.ConvertStringtoByte(model.UPasswd)));
                return UserModel.InsertUser(model, ref err);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // getUser
        public static UserModel GetUser(UserModel model)
        {
            try
            {
                string err = "";
                return UserModel.FindUser(model, ref err);
            }
            catch (Exception ex)
            {
                return new UserModel();
            }
        }
    }
}