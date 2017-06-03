using FPBMTTC_FinalC_M_vs2017.Model;
using FPBMTTC_FinalC_M_vs2017.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPBMTTC_FinalC_M_vs2017
{
    public partial class LoginForm : Form
    {
        MenuForm menu;
        public delegate void Login(bool hasLogin);
        public event Login DeletegateLogin;
        private bool hasLogin;
        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(MenuForm menu)
        {
            this.menu = menu;
            InitializeComponent();
        }
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.ShowDialog();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var webAddr = Packet.prefixUsage+"LoginUser";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{" +
                                "\"UId\": null," +
                                "\"UName\": \""+txtUsr.Text+"\"," +
                                "\"UPasswd\":\""+txtPasswd.Text+"\"," +
                                "\"UEmail\": null " +
                                "}";

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var myObject = JObject.Parse(result); // parse as obj
                menu.user = new FPBMTTC_FinalC_M_vs2017.Model.UserModel();
                foreach (JProperty app in myObject.Properties())
                {
                    if (!app.Name.Contains("Person"))
                        this.menu.user.SetProperty(app.Name, app.Value.ToString());
                }
                if (menu.user.UId != 0)
                    hasLogin = true;
                else
                    hasLogin = false;
                DeletegateLogin?.Invoke(hasLogin);
            }
        }
    }
}
