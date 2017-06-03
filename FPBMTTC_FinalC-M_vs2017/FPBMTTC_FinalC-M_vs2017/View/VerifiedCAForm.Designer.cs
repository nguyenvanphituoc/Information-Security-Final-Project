namespace FPBMTTC_FinalC_M_vs2017.View
{
    partial class VerifiedCAForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCert = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnVerified = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbCert
            // 
            this.cbCert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCert.FormattingEnabled = true;
            this.cbCert.Location = new System.Drawing.Point(109, 61);
            this.cbCert.Name = "cbCert";
            this.cbCert.Size = new System.Drawing.Size(248, 24);
            this.cbCert.TabIndex = 31;
            this.cbCert.SelectedIndexChanged += new System.EventHandler(this.CbCert_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(109, 13);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(460, 26);
            this.txtSearch.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(19, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "View Cert";
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetrieve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetrieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetrieve.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRetrieve.Location = new System.Drawing.Point(577, 8);
            this.btnRetrieve.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(94, 37);
            this.btnRetrieve.TabIndex = 28;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.BtnRetrieve_Click);
            // 
            // btnVerified
            // 
            this.btnVerified.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerified.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerified.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerified.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVerified.Location = new System.Drawing.Point(577, 53);
            this.btnVerified.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerified.Name = "btnVerified";
            this.btnVerified.Size = new System.Drawing.Size(94, 37);
            this.btnVerified.TabIndex = 32;
            this.btnVerified.Text = "Verify";
            this.btnVerified.UseVisualStyleBackColor = true;
            this.btnVerified.Click += new System.EventHandler(this.BtnVerified_Click);
            // 
            // VerifiedCAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(689, 108);
            this.Controls.Add(this.btnVerified);
            this.Controls.Add(this.cbCert);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRetrieve);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VerifiedCAForm";
            this.Text = "VerifiedCA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCert;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Button btnVerified;
    }
}