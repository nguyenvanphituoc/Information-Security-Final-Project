namespace FPBMTTC_FinalC_M_vs2017.View
{
    partial class RevokeCAForm
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
            this.lbUsr = new System.Windows.Forms.Label();
            this.txtUsr = new System.Windows.Forms.TextBox();
            this.btnRevoke = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUsr
            // 
            this.lbUsr.AutoSize = true;
            this.lbUsr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsr.Location = new System.Drawing.Point(13, 9);
            this.lbUsr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUsr.Name = "lbUsr";
            this.lbUsr.Size = new System.Drawing.Size(128, 20);
            this.lbUsr.TabIndex = 1;
            this.lbUsr.Text = "Enter Password";
            // 
            // txtUsr
            // 
            this.txtUsr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsr.Location = new System.Drawing.Point(149, 6);
            this.txtUsr.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsr.MaxLength = 50;
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.PasswordChar = '*';
            this.txtUsr.Size = new System.Drawing.Size(268, 26);
            this.txtUsr.TabIndex = 4;
            // 
            // btnRevoke
            // 
            this.btnRevoke.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRevoke.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevoke.Location = new System.Drawing.Point(320, 40);
            this.btnRevoke.Margin = new System.Windows.Forms.Padding(4);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(94, 42);
            this.btnRevoke.TabIndex = 7;
            this.btnRevoke.Text = "Submit";
            this.btnRevoke.UseVisualStyleBackColor = true;
            this.btnRevoke.Click += new System.EventHandler(this.BtnRevoke_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(218, 40);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // RevokeCAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 90);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRevoke);
            this.Controls.Add(this.txtUsr);
            this.Controls.Add(this.lbUsr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RevokeCAForm";
            this.Text = "Digital Certificate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsr;
        private System.Windows.Forms.TextBox txtUsr;
        private System.Windows.Forms.Button btnRevoke;
        private System.Windows.Forms.Button button1;
    }
}