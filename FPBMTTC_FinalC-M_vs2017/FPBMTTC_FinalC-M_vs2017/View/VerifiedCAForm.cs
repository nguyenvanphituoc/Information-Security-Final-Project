using FPBMTTC_FinalC_M_vs2017.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPBMTTC_FinalC_M_vs2017.View
{
    public partial class VerifiedCAForm : Form
    {
        MenuForm menu;
        List<X509CertificateModel> listData;
        int index;
        public VerifiedCAForm(MenuForm menu)
        {
            InitializeComponent();
            listData = new List<X509CertificateModel>();
            this.menu = menu;
            index = -1;
        }
        public VerifiedCAForm()
        {
            InitializeComponent();
            listData = new List<X509CertificateModel>();
            index = -1;

        }

        private void BtnRetrieve_Click(object sender, EventArgs e)
        {
            string url = "https://localhost/Restful/FinalC-M/Values/SearchCert?subjectName=" + txtSearch.Text;
            var json = new WebClient().DownloadString(url);

            JArray a = JArray.Parse(json);
            foreach (JObject o in a.Children<JObject>())
            {
                X509CertificateModel model = new X509CertificateModel();
                foreach (JProperty p in o.Properties())
                {
                    if (!p.Name.Contains("Person"))
                        model.SetProperty(p.Name, p.Value.ToString());
                }
                listData.Add(model);
            }
            LoadCombobox(listData);
        }

        private void LoadCombobox(List<X509CertificateModel> datas)
        {
            cbCert.DataSource = null;

            cbCert.DataSource = datas;
            cbCert.DisplayMember = "SeriralNumber";
            cbCert.ValueMember = "SeriralNumber";
        }

        private void BtnVerified_Click(object sender, EventArgs e)
        {
            if (cbCert.Text != null && !cbCert.Text.Equals("") && index >= 0)
            {
                //FinalC-M/Values/RevokeDigitalCert?usrId={usrId}&serialNumber={serialNumber}
                string url = Packet.prefixUsage+"VerifiedDigitalCert?serialNumber=" + this.listData[index].SeriralNumber + "&usrId=" + this.menu.user.UId;
                var json = new WebClient().DownloadString(url);

                if (json.Equals("true"))
                {
                    MessageBox.Show("Success verify CA");
                }
                else
                {
                    MessageBox.Show("Failed verify CA");
                }
            }
            else
                MessageBox.Show("Please choose CA to verify");
        }

        private void CbCert_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = cbCert.SelectedIndex;
        }
    }
}
