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
    public partial class RegisterCAForm : Form
    {
        MenuForm menu;
        public RegisterCAForm(MenuForm menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

        public RegisterCAForm()
        {
            InitializeComponent();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            string url = Packet.prefixUsage+"GenerateCA?subjectName="+GetSubjectname()+"&userId="+menu.user.UId;
            var json = new WebClient().DownloadString(url);
            if (json.Equals("true"))
            {
                MessageBox.Show("Success create CA");
            }
            else
            {
                MessageBox.Show("Failed create CA");
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txtPreview.Text = "CN:" + txtCN.Text + ";\r\n" +
                                "OU:" + txtOU.Text + ";\r\n" +
                                "O:" + txtO.Text + ";\r\n" +
                                "L:" + txtL.Text + ";\r\n" +
                                "S:" + txtPN.Text + ";\r\n" +
                                "C:" + cbCountry.Text;
        }

        private String GetSubjectname()
        {
            return "CN=" + txtCN.Text + ",OU=" + txtOU.Text + ",O=" + txtO.Text + ",L=" + txtL.Text + ",ST=" + txtPN.Text + ",C=" + cbCountry.Text;
        }
    }
}
