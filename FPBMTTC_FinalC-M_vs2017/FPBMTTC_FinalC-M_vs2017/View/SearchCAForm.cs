﻿using System;
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
    public partial class SearchCAForm : Form
    {

        MenuForm menu;
        public SearchCAForm(MenuForm menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

        public SearchCAForm()
        {
            InitializeComponent();
        }
    }
}
