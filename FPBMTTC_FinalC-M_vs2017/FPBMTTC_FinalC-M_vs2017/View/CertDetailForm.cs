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
using FPBMTTC_FinalC_M_vs2017.Model;

namespace FPBMTTC_FinalC_M_vs2017.View
{
    public partial class CertDetailForm : Form
    {
        MenuForm menu;
        List<X509CertificateModel> listData;
        int index = -1;
        public CertDetailForm(MenuForm menu)
        {
            InitializeComponent();
            this.menu = menu;
            listData = new List<X509CertificateModel>();
            index = -1;
        }
        public CertDetailForm()
        {
            InitializeComponent();
            listData = new List<X509CertificateModel>();
            index = -1;
        }

        private void ButtonRevoke_Click(object sender, EventArgs e)
        {
            if (index >= 0) {
                RevokeCAForm form = new RevokeCAForm(this.menu, listData[index]);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No handler Cert to revoke");
            }
        }

        private void BtnRetrieve_Click(object sender, EventArgs e)
        {
            string url = Packet.prefixUsage+"SearchCert?subjectName=" + txtSearch.Text;
            var json = new WebClient().DownloadString(url);

            JArray a = JArray.Parse(json);
            listData.Clear();
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

            txtExpires.DataBindings.Clear();
            txtExtension.DataBindings.Clear();
            txtFormat.DataBindings.Clear();
            txtIssuer.DataBindings.Clear();
            txtSerial.DataBindings.Clear();
            txtSignature.DataBindings.Clear();
            txtSignatureAlgo.DataBindings.Clear();
            txtSubject.DataBindings.Clear();
            txtValidFrom.DataBindings.Clear();
            txtVersion.DataBindings.Clear();

            txtVersion.DataBindings.Add("Text", cbCert.DataSource, "Version");
            txtSignature.DataBindings.Add("Text", cbCert.DataSource, "Signature");
            txtExtension.DataBindings.Add("Text", cbCert.DataSource, "Extensions");
            txtSerial.DataBindings.Add("Text", cbCert.DataSource, "SeriralNumber");
            txtSignatureAlgo.DataBindings.Add("Text", cbCert.DataSource, "SignatureAlgorithm");
            txtSubject.DataBindings.Add("Text", cbCert.DataSource, "SubjectName");
            txtIssuer.DataBindings.Add("Text", cbCert.DataSource, "IssuerName");
        }

        private void CbCert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCert.Text != null && !cbCert.Text.Equals(""))
            {
                int index = cbCert.SelectedIndex;
                if (index >= 0)
                {
                    this.index = index;
                    X509CertificateModel model = listData[index];
                    string[] date = model.ValidityPeriod.Split(';');
                    txtValidFrom.Text = date[0];
                    txtExpires.Text = date[1];
                }
            }
            else
                MessageBox.Show("Please choose CA to detail");
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
    }
}
