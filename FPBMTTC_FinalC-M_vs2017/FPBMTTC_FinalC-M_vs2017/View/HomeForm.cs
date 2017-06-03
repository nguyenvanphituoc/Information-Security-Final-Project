using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPBMTTC_FinalC_M_vs2017.View
{
    public partial class HomeForm : Form
    {
        MenuForm menu;
        public HomeForm(MenuForm menu)
        {
            this.menu = menu;
            InitializeComponent();
            if (menu.user != null)
                btnLogout.Text = "Logout";
            else
                btnLogout.Text = "Login";
        }
        public HomeForm()
        {
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.menu.user = null;
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
        }
    }
}
