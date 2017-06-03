using FPBMTTC_FinalC_M_vs2017.Model;
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

namespace FPBMTTC_FinalC_M_vs2017.View
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            var webAddr = Packet.prefixUsage+"RegisterUser";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{" +
                                "\"uId\": null," +
                                "\"uName\": \"" + txtUsr.Text + "\"," +
                                "\"uPasswd\":\"" + txtPasswd.Text + "\"," +
                                "\"uEmail\":\"" + txtEmail.Text + "\"" +
                                "}";

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (result.Equals("false"))
                {
                    MessageBox.Show("Register failed, pls try again");
                }
                else
                {
                    MessageBox.Show("Register successed, now you can login");
                }
            }
        }
    }
}
