namespace CD_Sync_Portable
{
    partial class WndVFSFolderProperties
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
            this.components = new System.ComponentModel.Container();
            this.tabVFSItemProperties = new System.Windows.Forms.TabControl();
            this.tabPageVFSItemGenProperties = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.separator3 = new System.Windows.Forms.Panel();
            this.separator2 = new System.Windows.Forms.Panel();
            this.separator1 = new System.Windows.Forms.Panel();
            this.lblFolderContents = new System.Windows.Forms.Label();
            this.lblFolderSize = new System.Windows.Forms.Label();
            this.lblItemType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkItemAttrEncrypted = new System.Windows.Forms.CheckBox();
            this.chkItemAttrCompressed = new System.Windows.Forms.CheckBox();
            this.chkItemAttrSystem = new System.Windows.Forms.CheckBox();
            this.chkItemAttrArchive = new System.Windows.Forms.CheckBox();
            this.chkItemAttrHidden = new System.Windows.Forms.CheckBox();
            this.chkItemAttrROnly = new System.Windows.Forms.CheckBox();
            this.lblFolderAccessed = new System.Windows.Forms.Label();
            this.lblFolderModified = new System.Windows.Forms.Label();
            this.lblFolderCreated = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pBoxItemIcon = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tmrFormUpdate = new System.Windows.Forms.Timer(this.components);
            this.tabVFSItemProperties.SuspendLayout();
            this.tabPageVFSItemGenProperties.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxItemIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabVFSItemProperties
            // 
            this.tabVFSItemProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabVFSItemProperties.Controls.Add(this.tabPageVFSItemGenProperties);
            this.tabVFSItemProperties.Location = new System.Drawing.Point(5, 5);
            this.tabVFSItemProperties.Name = "tabVFSItemProperties";
            this.tabVFSItemProperties.SelectedIndex = 0;
            this.tabVFSItemProperties.Size = new System.Drawing.Size(375, 409);
            this.tabVFSItemProperties.TabIndex = 0;
            // 
            // tabPageVFSItemGenProperties
            // 
            this.tabPageVFSItemGenProperties.Controls.Add(this.groupBox1);
            this.tabPageVFSItemGenProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageVFSItemGenProperties.Name = "tabPageVFSItemGenProperties";
            this.tabPageVFSItemGenProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVFSItemGenProperties.Size = new System.Drawing.Size(367, 383);
            this.tabPageVFSItemGenProperties.TabIndex = 0;
            this.tabPageVFSItemGenProperties.Text = "General Properties";
            this.tabPageVFSItemGenProperties.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLocation);
            this.groupBox1.Controls.Add(this.txtFolderName);
            this.groupBox1.Controls.Add(this.separator3);
            this.groupBox1.Controls.Add(this.separator2);
            this.groupBox1.Controls.Add(this.separator1);
            this.groupBox1.Controls.Add(this.lblFolderContents);
            this.groupBox1.Controls.Add(this.lblFolderSize);
            this.groupBox1.Controls.Add(this.lblItemType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkItemAttrEncrypted);
            this.groupBox1.Controls.Add(this.chkItemAttrCompressed);
            this.groupBox1.Controls.Add(this.chkItemAttrSystem);
            this.groupBox1.Controls.Add(this.chkItemAttrArchive);
            this.groupBox1.Controls.Add(this.chkItemAttrHidden);
            this.groupBox1.Controls.Add(this.chkItemAttrROnly);
            this.groupBox1.Controls.Add(this.lblFolderAccessed);
            this.groupBox1.Controls.Add(this.lblFolderModified);
            this.groupBox1.Controls.Add(this.lblFolderCreated);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pBoxItemIcon);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 377);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Properties";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.SystemColors.Control;
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLocation.Location = new System.Drawing.Point(90, 109);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(260, 13);
            this.txtLocation.TabIndex = 25;
            this.txtLocation.Text = "----";
            // 
            // txtFolderName
            // 
            this.txtFolderName.BackColor = System.Drawing.SystemColors.Control;
            this.txtFolderName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFolderName.Location = new System.Drawing.Point(90, 28);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.ReadOnly = true;
            this.txtFolderName.Size = new System.Drawing.Size(260, 13);
            this.txtFolderName.TabIndex = 1;
            this.txtFolderName.Text = "----";
            // 
            // separator3
            // 
            this.separator3.BackColor = System.Drawing.Color.Gray;
            this.separator3.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.separator3.Location = new System.Drawing.Point(17, 294);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(333, 10);
            this.separator3.TabIndex = 18;
            // 
            // separator2
            // 
            this.separator2.BackColor = System.Drawing.Color.Gray;
            this.separator2.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.separator2.Location = new System.Drawing.Point(17, 195);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(333, 10);
            this.separator2.TabIndex = 11;
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.Gray;
            this.separator1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.separator1.Location = new System.Drawing.Point(17, 70);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(333, 10);
            this.separator1.TabIndex = 1;
            // 
            // lblFolderContents
            // 
            this.lblFolderContents.AutoSize = true;
            this.lblFolderContents.Location = new System.Drawing.Point(87, 161);
            this.lblFolderContents.Name = "lblFolderContents";
            this.lblFolderContents.Size = new System.Drawing.Size(19, 13);
            this.lblFolderContents.TabIndex = 10;
            this.lblFolderContents.Text = "----";
            // 
            // lblFolderSize
            // 
            this.lblFolderSize.AutoSize = true;
            this.lblFolderSize.Location = new System.Drawing.Point(87, 135);
            this.lblFolderSize.Name = "lblFolderSize";
            this.lblFolderSize.Size = new System.Drawing.Size(19, 13);
            this.lblFolderSize.TabIndex = 7;
            this.lblFolderSize.Text = "----";
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(87, 83);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(19, 13);
            this.lblItemType.TabIndex = 3;
            this.lblItemType.Text = "----";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Contains:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type:";
            // 
            // chkItemAttrEncrypted
            // 
            this.chkItemAttrEncrypted.AutoSize = true;
            this.chkItemAttrEncrypted.Enabled = false;
            this.chkItemAttrEncrypted.Location = new System.Drawing.Point(276, 342);
            this.chkItemAttrEncrypted.Name = "chkItemAttrEncrypted";
            this.chkItemAttrEncrypted.Size = new System.Drawing.Size(74, 17);
            this.chkItemAttrEncrypted.TabIndex = 0;
            this.chkItemAttrEncrypted.Text = "Encrypted";
            this.chkItemAttrEncrypted.UseVisualStyleBackColor = true;
            // 
            // chkItemAttrCompressed
            // 
            this.chkItemAttrCompressed.AutoSize = true;
            this.chkItemAttrCompressed.Enabled = false;
            this.chkItemAttrCompressed.Location = new System.Drawing.Point(177, 342);
            this.chkItemAttrCompressed.Name = "chkItemAttrCompressed";
            this.chkItemAttrCompressed.Size = new System.Drawing.Size(84, 17);
            this.chkItemAttrCompressed.TabIndex = 24;
            this.chkItemAttrCompressed.Text = "Compressed";
            this.chkItemAttrCompressed.UseVisualStyleBackColor = true;
            // 
            // chkItemAttrSystem
            // 
            this.chkItemAttrSystem.AutoSize = true;
            this.chkItemAttrSystem.Enabled = false;
            this.chkItemAttrSystem.Location = new System.Drawing.Point(90, 342);
            this.chkItemAttrSystem.Name = "chkItemAttrSystem";
            this.chkItemAttrSystem.Size = new System.Drawing.Size(60, 17);
            this.chkItemAttrSystem.TabIndex = 23;
            this.chkItemAttrSystem.Text = "System";
            this.chkItemAttrSystem.UseVisualStyleBackColor = true;
            // 
            // chkItemAttrArchive
            // 
            this.chkItemAttrArchive.AutoSize = true;
            this.chkItemAttrArchive.Enabled = false;
            this.chkItemAttrArchive.Location = new System.Drawing.Point(276, 306);
            this.chkItemAttrArchive.Name = "chkItemAttrArchive";
            this.chkItemAttrArchive.Size = new System.Drawing.Size(62, 17);
            this.chkItemAttrArchive.TabIndex = 22;
            this.chkItemAttrArchive.Text = "Archive";
            this.chkItemAttrArchive.UseVisualStyleBackColor = true;
            // 
            // chkItemAttrHidden
            // 
            this.chkItemAttrHidden.AutoSize = true;
            this.chkItemAttrHidden.Enabled = false;
            this.chkItemAttrHidden.Location = new System.Drawing.Point(177, 307);
            this.chkItemAttrHidden.Name = "chkItemAttrHidden";
            this.chkItemAttrHidden.Size = new System.Drawing.Size(60, 17);
            this.chkItemAttrHidden.TabIndex = 21;
            this.chkItemAttrHidden.Text = "Hidden";
            this.chkItemAttrHidden.UseVisualStyleBackColor = true;
            // 
            // chkItemAttrROnly
            // 
            this.chkItemAttrROnly.AutoSize = true;
            this.chkItemAttrROnly.Enabled = false;
            this.chkItemAttrROnly.Location = new System.Drawing.Point(90, 306);
            this.chkItemAttrROnly.Name = "chkItemAttrROnly";
            this.chkItemAttrROnly.Size = new System.Drawing.Size(74, 17);
            this.chkItemAttrROnly.TabIndex = 20;
            this.chkItemAttrROnly.Text = "Read-only";
            this.chkItemAttrROnly.UseVisualStyleBackColor = true;
            // 
            // lblFolderAccessed
            // 
            this.lblFolderAccessed.AutoSize = true;
            this.lblFolderAccessed.Location = new System.Drawing.Point(87, 260);
            this.lblFolderAccessed.Name = "lblFolderAccessed";
            this.lblFolderAccessed.Size = new System.Drawing.Size(19, 13);
            this.lblFolderAccessed.TabIndex = 17;
            this.lblFolderAccessed.Text = "----";
            // 
            // lblFolderModified
            // 
            this.lblFolderModified.AutoSize = true;
            this.lblFolderModified.Location = new System.Drawing.Point(87, 234);
            this.lblFolderModified.Name = "lblFolderModified";
            this.lblFolderModified.Size = new System.Drawing.Size(19, 13);
            this.lblFolderModified.TabIndex = 15;
            this.lblFolderModified.Text = "----";
            // 
            // lblFolderCreated
            // 
            this.lblFolderCreated.AutoSize = true;
            this.lblFolderCreated.Location = new System.Drawing.Point(87, 208);
            this.lblFolderCreated.Name = "lblFolderCreated";
            this.lblFolderCreated.Size = new System.Drawing.Size(19, 13);
            this.lblFolderCreated.TabIndex = 13;
            this.lblFolderCreated.Text = "----";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 307);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Attributes:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 260);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Accessed:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Modified:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Created:";
            // 
            // pBoxItemIcon
            // 
            this.pBoxItemIcon.Location = new System.Drawing.Point(17, 28);
            this.pBoxItemIcon.Name = "pBoxItemIcon";
            this.pBoxItemIcon.Size = new System.Drawing.Size(32, 32);
            this.pBoxItemIcon.TabIndex = 0;
            this.pBoxItemIcon.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(289, 420);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tmrFormUpdate
            // 
            this.tmrFormUpdate.Interval = 1000;
            this.tmrFormUpdate.Tick += new System.EventHandler(this.tmrFormUpdate_Tick);
            // 
            // WndVFSFolderProperties
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(384, 453);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabVFSItemProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndVFSFolderProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wndVFSFolderProperties_FormClosing);
            this.Load += new System.EventHandler(this.wndVFSFolderProperties_Load);
            this.tabVFSItemProperties.ResumeLayout(false);
            this.tabPageVFSItemGenProperties.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxItemIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabVFSItemProperties;
        private System.Windows.Forms.TabPage tabPageVFSItemGenProperties;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pBoxItemIcon;
        private System.Windows.Forms.Label lblFolderAccessed;
        private System.Windows.Forms.Label lblFolderModified;
        private System.Windows.Forms.Label lblFolderCreated;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkItemAttrArchive;
        private System.Windows.Forms.CheckBox chkItemAttrHidden;
        private System.Windows.Forms.CheckBox chkItemAttrROnly;
        private System.Windows.Forms.CheckBox chkItemAttrEncrypted;
        private System.Windows.Forms.CheckBox chkItemAttrCompressed;
        private System.Windows.Forms.CheckBox chkItemAttrSystem;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblFolderSize;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrFormUpdate;
        private System.Windows.Forms.Label lblFolderContents;
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.Panel separator3;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.TextBox txtLocation;
    }
}