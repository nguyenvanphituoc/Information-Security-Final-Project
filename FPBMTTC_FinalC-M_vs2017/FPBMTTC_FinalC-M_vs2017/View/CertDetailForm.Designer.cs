namespace FPBMTTC_FinalC_M_vs2017.View
{
    partial class CertDetailForm
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
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.cbCert = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.txtSignature = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIssuer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExpires = new System.Windows.Forms.TextBox();
            this.txtValidFrom = new System.Windows.Forms.TextBox();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSignatureAlgo = new System.Windows.Forms.TextBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbUsr = new System.Windows.Forms.Label();
            this.btnVerified = new System.Windows.Forms.Button();
            this.grpAction.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnVerified);
            this.grpAction.Controls.Add(this.cbCert);
            this.grpAction.Controls.Add(this.txtSearch);
            this.grpAction.Controls.Add(this.label5);
            this.grpAction.Controls.Add(this.button1);
            this.grpAction.Controls.Add(this.btnRetrieve);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAction.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.grpAction.Location = new System.Drawing.Point(0, 0);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(891, 104);
            this.grpAction.TabIndex = 0;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Action";
            // 
            // cbCert
            // 
            this.cbCert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCert.FormattingEnabled = true;
            this.cbCert.Location = new System.Drawing.Point(103, 61);
            this.cbCert.Name = "cbCert";
            this.cbCert.Size = new System.Drawing.Size(205, 24);
            this.cbCert.TabIndex = 27;
            this.cbCert.SelectedIndexChanged += new System.EventHandler(this.CbCert_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(103, 27);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(460, 26);
            this.txtSearch.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(13, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "View Cert";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(673, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "Revoke";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonRevoke_Click);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetrieve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetrieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetrieve.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRetrieve.Location = new System.Drawing.Point(571, 22);
            this.btnRetrieve.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(94, 37);
            this.btnRetrieve.TabIndex = 8;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.BtnRetrieve_Click);
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.txtSignature);
            this.pnMain.Controls.Add(this.label9);
            this.pnMain.Controls.Add(this.txtExtension);
            this.pnMain.Controls.Add(this.label8);
            this.pnMain.Controls.Add(this.txtSubject);
            this.pnMain.Controls.Add(this.label7);
            this.pnMain.Controls.Add(this.txtIssuer);
            this.pnMain.Controls.Add(this.label6);
            this.pnMain.Controls.Add(this.txtExpires);
            this.pnMain.Controls.Add(this.txtValidFrom);
            this.pnMain.Controls.Add(this.txtFormat);
            this.pnMain.Controls.Add(this.label1);
            this.pnMain.Controls.Add(this.label4);
            this.pnMain.Controls.Add(this.txtSignatureAlgo);
            this.pnMain.Controls.Add(this.txtSerial);
            this.pnMain.Controls.Add(this.txtVersion);
            this.pnMain.Controls.Add(this.label3);
            this.pnMain.Controls.Add(this.label2);
            this.pnMain.Controls.Add(this.label10);
            this.pnMain.Controls.Add(this.lbUsr);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 104);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(891, 609);
            this.pnMain.TabIndex = 1;
            // 
            // txtSignature
            // 
            this.txtSignature.BackColor = System.Drawing.SystemColors.Info;
            this.txtSignature.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSignature.Location = new System.Drawing.Point(14, 462);
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.ReadOnly = true;
            this.txtSignature.Size = new System.Drawing.Size(863, 128);
            this.txtSignature.TabIndex = 40;
            this.txtSignature.Text = "";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(14, 439);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(863, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "Signature";
            // 
            // txtExtension
            // 
            this.txtExtension.BackColor = System.Drawing.SystemColors.Info;
            this.txtExtension.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtExtension.Location = new System.Drawing.Point(14, 287);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.ReadOnly = true;
            this.txtExtension.Size = new System.Drawing.Size(863, 128);
            this.txtExtension.TabIndex = 38;
            this.txtExtension.Text = "";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(14, 264);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(863, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Extensions";
            // 
            // txtSubject
            // 
            this.txtSubject.BackColor = System.Drawing.SystemColors.Info;
            this.txtSubject.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(14, 221);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ReadOnly = true;
            this.txtSubject.Size = new System.Drawing.Size(863, 26);
            this.txtSubject.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(14, 197);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(863, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "Subject";
            // 
            // txtIssuer
            // 
            this.txtIssuer.BackColor = System.Drawing.SystemColors.Info;
            this.txtIssuer.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtIssuer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssuer.Location = new System.Drawing.Point(14, 153);
            this.txtIssuer.Margin = new System.Windows.Forms.Padding(4);
            this.txtIssuer.Name = "txtIssuer";
            this.txtIssuer.ReadOnly = true;
            this.txtIssuer.Size = new System.Drawing.Size(863, 26);
            this.txtIssuer.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(14, 129);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(863, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Issuer";
            // 
            // txtExpires
            // 
            this.txtExpires.BackColor = System.Drawing.SystemColors.Info;
            this.txtExpires.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpires.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtExpires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpires.Location = new System.Drawing.Point(637, 84);
            this.txtExpires.Margin = new System.Windows.Forms.Padding(4);
            this.txtExpires.Name = "txtExpires";
            this.txtExpires.ReadOnly = true;
            this.txtExpires.Size = new System.Drawing.Size(240, 26);
            this.txtExpires.TabIndex = 32;
            // 
            // txtValidFrom
            // 
            this.txtValidFrom.BackColor = System.Drawing.SystemColors.Info;
            this.txtValidFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidFrom.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtValidFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValidFrom.Location = new System.Drawing.Point(637, 50);
            this.txtValidFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txtValidFrom.Name = "txtValidFrom";
            this.txtValidFrom.ReadOnly = true;
            this.txtValidFrom.Size = new System.Drawing.Size(240, 26);
            this.txtValidFrom.TabIndex = 31;
            // 
            // txtFormat
            // 
            this.txtFormat.BackColor = System.Drawing.SystemColors.Info;
            this.txtFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFormat.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormat.Location = new System.Drawing.Point(637, 17);
            this.txtFormat.Margin = new System.Windows.Forms.Padding(4);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.ReadOnly = true;
            this.txtFormat.Size = new System.Drawing.Size(130, 26);
            this.txtFormat.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(538, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Expires";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(538, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Valid From";
            // 
            // txtSignatureAlgo
            // 
            this.txtSignatureAlgo.BackColor = System.Drawing.SystemColors.Info;
            this.txtSignatureAlgo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSignatureAlgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSignatureAlgo.Location = new System.Drawing.Point(178, 86);
            this.txtSignatureAlgo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSignatureAlgo.Name = "txtSignatureAlgo";
            this.txtSignatureAlgo.ReadOnly = true;
            this.txtSignatureAlgo.Size = new System.Drawing.Size(352, 26);
            this.txtSignatureAlgo.TabIndex = 27;
            // 
            // txtSerial
            // 
            this.txtSerial.BackColor = System.Drawing.SystemColors.Info;
            this.txtSerial.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(178, 52);
            this.txtSerial.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.ReadOnly = true;
            this.txtSerial.Size = new System.Drawing.Size(352, 26);
            this.txtSerial.TabIndex = 26;
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.SystemColors.Info;
            this.txtVersion.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersion.Location = new System.Drawing.Point(178, 19);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(130, 26);
            this.txtVersion.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(538, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Format";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(14, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Signature Algorithm";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(14, 54);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Serial Number";
            // 
            // lbUsr
            // 
            this.lbUsr.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbUsr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbUsr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbUsr.Location = new System.Drawing.Point(14, 21);
            this.lbUsr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUsr.Name = "lbUsr";
            this.lbUsr.Size = new System.Drawing.Size(156, 20);
            this.lbUsr.TabIndex = 21;
            this.lbUsr.Text = "Version";
            // 
            // btnVerified
            // 
            this.btnVerified.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerified.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerified.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerified.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVerified.Location = new System.Drawing.Point(775, 22);
            this.btnVerified.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerified.Name = "btnVerified";
            this.btnVerified.Size = new System.Drawing.Size(94, 37);
            this.btnVerified.TabIndex = 33;
            this.btnVerified.Text = "Verify";
            this.btnVerified.UseVisualStyleBackColor = true;
            this.btnVerified.Click += new System.EventHandler(this.BtnVerified_Click);
            // 
            // CertDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(891, 713);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.grpAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CertDetailForm";
            this.Text = "Personal CA Form";
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtSignature;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtExtension;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIssuer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExpires;
        private System.Windows.Forms.TextBox txtValidFrom;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSignatureAlgo;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbUsr;
        private System.Windows.Forms.ComboBox cbCert;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnVerified;
    }
}