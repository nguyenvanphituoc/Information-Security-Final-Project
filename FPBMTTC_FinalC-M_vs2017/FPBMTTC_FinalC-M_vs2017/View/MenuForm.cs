using FPBMTTC_FinalC_M_vs2017.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FPBMTTC_FinalC_M_vs2017.View
{
    enum ChooseForm
    {
        HomeForm,
        RegisterCAForm,
        PersonalCAForm,
        VerifiedCAForm,
        SearchCAForm,
        AccountForm,
        MangermentCAForm,
    }
    public partial class MenuForm : Form
    {
        private int btnComponentsCount;
        private Button[] btnComponents;
        ChooseForm choosenForm = ChooseForm.AccountForm;
        public UserModel user;
        public MenuForm()
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();
            pnMain.AutoScroll = true;
            InitialBtnList();
            Btn_Control_Tab_Click(btnComponents[btnComponents.Length - 5 - 1], new EventArgs());
            this.Cursor = Cursors.Default;
        }

        public void InitialBtnList()
        {
            btnComponentsCount = this.panel1.Controls.Count;// lấy số lượng button có trong pannel này
            btnComponents = new Button[btnComponentsCount];
            int index = 0;
            foreach (var i in this.panel1.Controls)
            {
                btnComponents[index] = (Button)i;
                // tất cả button điều phải được mở
                btnComponents[index].Enabled = true;
                index++;
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size; // Form sẽ hiện thị kích thức như màn hình lap   
            this.WindowState = FormWindowState.Maximized;
            Menu_Resize(sender, e);
        }

        private void Menu_Resize(object sender, EventArgs e)
        {
            foreach (var btn in btnComponents)
            {
                btn.Width = GetNewButtonWidth(2);
            }
        }

        private int GetNewButtonWidth(int offset)
        {
            int index = btnComponents.Length;
            return this.Width / index - offset;
        }

        private void Btn_Control_Tab_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //button nào được nhấp vào thì đóng, không cho mở tiếp nữa
            int index = this.panel1.Controls.GetChildIndex((Control)sender);
            // close all tab
            foreach (var btn in btnComponents)
            {
                if (!btn.Enabled)
                    btn.Enabled = true;
            }

            foreach (var control in pnMain.Controls)
            {
                (control as Control).Dispose();
            }
            choosenForm = (ChooseForm)(btnComponents.Length - index - 1);
            btnComponents[index].Enabled = false;
            btnComponents[index].Select();
            this.Cursor = Cursors.Default;
        }

        private void Button_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                if (((Control)sender).Enabled == false)
                {
                    Form form = null;
                    switch (choosenForm)
                    {
                        case ChooseForm.AccountForm:
                            if (user == null)
                            {
                                form = new LoginForm(this);
                                (form as LoginForm).DeletegateLogin += HasLogin;
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case ChooseForm.HomeForm:
                            if (user != null)
                                form = new HomeForm();
                            else
                            {
                                MessageBox.Show("You should to login page");
                                return;
                            }
                            break;
                        case ChooseForm.MangermentCAForm:
                            if (user != null)
                                form = new Form();
                            else
                            {
                                MessageBox.Show("You should to login page");
                                return;
                            }
                            break;
                        case ChooseForm.VerifiedCAForm:
                            if (user != null)
                                form = new VerifiedCAForm(this);
                            else
                            {
                                MessageBox.Show("You should to login page");
                                return;
                            }
                            break;
                        case ChooseForm.PersonalCAForm:
                            if (user != null)
                                form = new CertDetailForm(this);
                            else
                            {
                                MessageBox.Show("You should to login page");
                                return;
                            }
                            break;
                        case ChooseForm.RegisterCAForm:
                            if (user != null)
                                form = new RegisterCAForm(this);
                            else
                            {
                                MessageBox.Show("You should to login page");
                                return;
                            }
                            break;
                        case ChooseForm.SearchCAForm:
                            if (user != null)
                                form = new SearchCAForm(this);
                            else
                            {
                                MessageBox.Show("You should to login page");
                                return;
                            }
                            break;
                        default:
                            form = new Form();
                            break;
                    }
                    int height = this.panel1.Height;
                    form.TopLevel = false;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Show();
                    this.pnMain.Controls.Add(form);
                    PnMainResize(pnMain);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public void PnMainResize(Panel pnMain)
        {
            foreach (var i in pnMain.Controls)
            {
                var form = i as Form;
                int offsetWidth = (pnMain.Width - form.Width) / 2 >= 0 ? (pnMain.Width - form.Width) / 2 : 0;
                int offsetHeight = (pnMain.Height - form.Height) / 2 >= 0 ? (pnMain.Height - form.Height) / 2 : 0;
                form.Location = new Point(0 + offsetWidth, 0 + offsetHeight);
            }
        }

        private void MenuForm_ResizeEnd(object sender, EventArgs e)
        {
            Menu_Resize(sender, e);
            PnMainResize(pnMain);
        }

        private void HasLogin(bool hasLogin)
        {
            if (hasLogin)
            {
                MessageBox.Show("Login successed");
                return;
            }
            else
            {
                MessageBox.Show("Login failed");
                return;
            }
        }
    }
}