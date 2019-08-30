namespace CD_Sync_Portable
{
    partial class WndAboutMe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndAboutMe));
            this.txtBoxCredits = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.pBoxAppIcon = new System.Windows.Forms.PictureBox();
            this.lnkLabelEmail = new System.Windows.Forms.LinkLabel();
            this.lnkLabelWebsite = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxCredits
            // 
            this.txtBoxCredits.Location = new System.Drawing.Point(12, 139);
            this.txtBoxCredits.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.txtBoxCredits.MaxLength = 65535;
            this.txtBoxCredits.Multiline = true;
            this.txtBoxCredits.Name = "txtBoxCredits";
            this.txtBoxCredits.ReadOnly = true;
            this.txtBoxCredits.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxCredits.Size = new System.Drawing.Size(498, 209);
            this.txtBoxCredits.TabIndex = 4;
            this.txtBoxCredits.TabStop = false;
            this.txtBoxCredits.Text = resources.GetString("txtBoxCredits.Text");
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(85, 12);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(75, 13);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(85, 29);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(85, 63);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(51, 13);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copyright";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(85, 46);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(74, 13);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "Developed By";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(436, 358);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 21);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "&OK";
            // 
            // pBoxAppIcon
            // 
            this.pBoxAppIcon.Image = global::CD_Sync_Portable.Properties.Resources.appIcon_48x48x32;
            this.pBoxAppIcon.Location = new System.Drawing.Point(12, 12);
            this.pBoxAppIcon.Name = "pBoxAppIcon";
            this.pBoxAppIcon.Size = new System.Drawing.Size(64, 64);
            this.pBoxAppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxAppIcon.TabIndex = 6;
            this.pBoxAppIcon.TabStop = false;
            this.pBoxAppIcon.Click += new System.EventHandler(this.pBoxAppIcon_Click);
            // 
            // lnkLabelEmail
            // 
            this.lnkLabelEmail.AutoSize = true;
            this.lnkLabelEmail.LinkArea = new System.Windows.Forms.LinkArea(37, 19);
            this.lnkLabelEmail.Location = new System.Drawing.Point(10, 101);
            this.lnkLabelEmail.Name = "lnkLabelEmail";
            this.lnkLabelEmail.Size = new System.Drawing.Size(302, 17);
            this.lnkLabelEmail.TabIndex = 7;
            this.lnkLabelEmail.TabStop = true;
            this.lnkLabelEmail.Text = "Send bug reports and suggestions to: ankitr.42@gmail.com";
            this.lnkLabelEmail.UseCompatibleTextRendering = true;
            this.lnkLabelEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lnkLabelWebsite
            // 
            this.lnkLabelWebsite.AutoSize = true;
            this.lnkLabelWebsite.LinkArea = new System.Windows.Forms.LinkArea(9, 25);
            this.lnkLabelWebsite.Location = new System.Drawing.Point(10, 118);
            this.lnkLabelWebsite.Name = "lnkLabelWebsite";
            this.lnkLabelWebsite.Size = new System.Drawing.Size(168, 17);
            this.lnkLabelWebsite.TabIndex = 7;
            this.lnkLabelWebsite.TabStop = true;
            this.lnkLabelWebsite.Text = "Website: http://ankitr.fileave.com";
            this.lnkLabelWebsite.UseCompatibleTextRendering = true;
            this.lnkLabelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLabelWebsite_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(56, 0);
            this.linkLabel1.Location = new System.Drawing.Point(10, 84);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(288, 17);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.Text = "Requires Microsoft® .Net Framework v2.0 or later to run.";
            this.linkLabel1.UseCompatibleTextRendering = true;
            // 
            // WndAboutMe
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(523, 387);
            this.Controls.Add(this.lnkLabelWebsite);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lnkLabelEmail);
            this.Controls.Add(this.pBoxAppIcon);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtBoxCredits);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.lblCompanyName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndAboutMe";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "wndAboutMe";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAppIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtBoxCredits;
        private System.Windows.Forms.PictureBox pBoxAppIcon;
        private System.Windows.Forms.LinkLabel lnkLabelEmail;
        private System.Windows.Forms.LinkLabel lnkLabelWebsite;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
