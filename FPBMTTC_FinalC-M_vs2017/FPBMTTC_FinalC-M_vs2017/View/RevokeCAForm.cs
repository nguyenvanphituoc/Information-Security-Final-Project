using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPBMTTC_FinalC_M_vs2017.Model;
using System.Net;

namespace FPBMTTC_FinalC_M_vs2017.View
{
    public partial class RevokeCAForm : Form
    {
        MenuForm menu;
        X509CertificateModel model;
        public RevokeCAForm(MenuForm menu, X509CertificateModel model)
        {
            this.menu = menu;
            this.model = model;
            InitializeComponent();
        }
        public RevokeCAForm()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRevoke_Click(object sender, EventArgs e)
        {
            if (txtUsr.Text.Equals(menu.user.UPasswd))
            {
                //FinalC-M/Values/RevokeDigitalCert?usrId={usrId}&serialNumber={serialNumber}
                string url = Packet.prefixUsage+"RevokeDigitalCert?usrId=" + this.menu.user.UId + "&serialNumber=" + model.SeriralNumber;
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
            else
                MessageBox.Show("Please choose CA to revoke");
            ButtonCancel_Click(sender, e);
        }
    }
}
