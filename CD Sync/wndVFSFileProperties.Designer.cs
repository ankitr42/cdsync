namespace CD_Sync_Portable
{
    partial class WndVFSFileProperties
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("File Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Music Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Audio Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Video Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Image Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Document Properties", System.Windows.Forms.HorizontalAlignment.Left);
            this.tabVFSItemProperties = new System.Windows.Forms.TabControl();
            this.tabPageVFSItemGenProperties = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.separator3 = new System.Windows.Forms.Panel();
            this.separator2 = new System.Windows.Forms.Panel();
            this.separator1 = new System.Windows.Forms.Panel();
            this.txtOpensWithName = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblFileType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pBoxOpensWithIcon = new System.Windows.Forms.PictureBox();
            this.chkItemAttrEncrypted = new System.Windows.Forms.CheckBox();
            this.chkItemAttrCompressed = new System.Windows.Forms.CheckBox();
            this.chkItemAttrSystem = new System.Windows.Forms.CheckBox();
            this.chkItemAttrArchive = new System.Windows.Forms.CheckBox();
            this.chkItemAttrHidden = new System.Windows.Forms.CheckBox();
            this.chkItemAttrROnly = new System.Windows.Forms.CheckBox();
            this.lblFileAccessed = new System.Windows.Forms.Label();
            this.lblFileModified = new System.Windows.Forms.Label();
            this.lblFileCreated = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pBoxItemIcon = new System.Windows.Forms.PictureBox();
            this.tabPageVFSItemAdvProperties = new System.Windows.Forms.TabPage();
            this.lViewExtendedProperties = new System.Windows.Forms.ListView();
            this.lViewColumnProperty = new System.Windows.Forms.ColumnHeader();
            this.lViewColumnValue = new System.Windows.Forms.ColumnHeader();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabVFSItemProperties.SuspendLayout();
            this.tabPageVFSItemGenProperties.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOpensWithIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxItemIcon)).BeginInit();
            this.tabPageVFSItemAdvProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabVFSItemProperties
            // 
            this.tabVFSItemProperties.Controls.Add(this.tabPageVFSItemGenProperties);
            this.tabVFSItemProperties.Controls.Add(this.tabPageVFSItemAdvProperties);
            this.tabVFSItemProperties.Location = new System.Drawing.Point(5, 5);
            this.tabVFSItemProperties.Name = "tabVFSItemProperties";
            this.tabVFSItemProperties.SelectedIndex = 0;
            this.tabVFSItemProperties.Size = new System.Drawing.Size(376, 409);
            this.tabVFSItemProperties.TabIndex = 0;
            // 
            // tabPageVFSItemGenProperties
            // 
            this.tabPageVFSItemGenProperties.Controls.Add(this.groupBox1);
            this.tabPageVFSItemGenProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageVFSItemGenProperties.Name = "tabPageVFSItemGenProperties";
            this.tabPageVFSItemGenProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVFSItemGenProperties.Size = new System.Drawing.Size(368, 383);
            this.tabPageVFSItemGenProperties.TabIndex = 0;
            this.tabPageVFSItemGenProperties.Text = "General Properties";
            this.tabPageVFSItemGenProperties.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.separator3);
            this.groupBox1.Controls.Add(this.separator2);
            this.groupBox1.Controls.Add(this.separator1);
            this.groupBox1.Controls.Add(this.txtOpensWithName);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.txtFileLocation);
            this.groupBox1.Controls.Add(this.lblFileSize);
            this.groupBox1.Controls.Add(this.lblFileType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pBoxOpensWithIcon);
            this.groupBox1.Controls.Add(this.chkItemAttrEncrypted);
            this.groupBox1.Controls.Add(this.chkItemAttrCompressed);
            this.groupBox1.Controls.Add(this.chkItemAttrSystem);
            this.groupBox1.Controls.Add(this.chkItemAttrArchive);
            this.groupBox1.Controls.Add(this.chkItemAttrHidden);
            this.groupBox1.Controls.Add(this.chkItemAttrROnly);
            this.groupBox1.Controls.Add(this.lblFileAccessed);
            this.groupBox1.Controls.Add(this.lblFileModified);
            this.groupBox1.Controls.Add(this.lblFileCreated);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pBoxItemIcon);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 377);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Properties";
            // 
            // separator3
            // 
            this.separator3.BackColor = System.Drawing.Color.Gray;
            this.separator3.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.separator3.Location = new System.Drawing.Point(17, 290);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(333, 10);
            this.separator3.TabIndex = 17;
            // 
            // separator2
            // 
            this.separator2.BackColor = System.Drawing.Color.Gray;
            this.separator2.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.separator2.Location = new System.Drawing.Point(17, 203);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(333, 10);
            this.separator2.TabIndex = 10;
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
            // txtOpensWithName
            // 
            this.txtOpensWithName.BackColor = System.Drawing.SystemColors.Control;
            this.txtOpensWithName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOpensWithName.Location = new System.Drawing.Point(128, 114);
            this.txtOpensWithName.Name = "txtOpensWithName";
            this.txtOpensWithName.ReadOnly = true;
            this.txtOpensWithName.Size = new System.Drawing.Size(222, 13);
            this.txtOpensWithName.TabIndex = 5;
            this.txtOpensWithName.Text = "----";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.SystemColors.Control;
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileName.Location = new System.Drawing.Point(90, 28);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(260, 13);
            this.txtFileName.TabIndex = 0;
            this.txtFileName.Text = "----";
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.BackColor = System.Drawing.SystemColors.Control;
            this.txtFileLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileLocation.Location = new System.Drawing.Point(90, 152);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.ReadOnly = true;
            this.txtFileLocation.Size = new System.Drawing.Size(260, 13);
            this.txtFileLocation.TabIndex = 7;
            this.txtFileLocation.Text = "----";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(87, 174);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(19, 13);
            this.lblFileSize.TabIndex = 9;
            this.lblFileSize.Text = "----";
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(87, 83);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(19, 13);
            this.lblFileType.TabIndex = 3;
            this.lblFileType.Text = "----";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Opens with:";
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
            // pBoxOpensWithIcon
            // 
            this.pBoxOpensWithIcon.Location = new System.Drawing.Point(90, 103);
            this.pBoxOpensWithIcon.Name = "pBoxOpensWithIcon";
            this.pBoxOpensWithIcon.Size = new System.Drawing.Size(32, 32);
            this.pBoxOpensWithIcon.TabIndex = 7;
            this.pBoxOpensWithIcon.TabStop = false;
            // 
            // chkItemAttrEncrypted
            // 
            this.chkItemAttrEncrypted.AutoSize = true;
            this.chkItemAttrEncrypted.Enabled = false;
            this.chkItemAttrEncrypted.Location = new System.Drawing.Point(276, 342);
            this.chkItemAttrEncrypted.Name = "chkItemAttrEncrypted";
            this.chkItemAttrEncrypted.Size = new System.Drawing.Size(74, 17);
            this.chkItemAttrEncrypted.TabIndex = 24;
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
            this.chkItemAttrCompressed.TabIndex = 23;
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
            this.chkItemAttrSystem.TabIndex = 22;
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
            this.chkItemAttrArchive.TabIndex = 21;
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
            this.chkItemAttrHidden.TabIndex = 20;
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
            this.chkItemAttrROnly.TabIndex = 19;
            this.chkItemAttrROnly.Text = "Read-only";
            this.chkItemAttrROnly.UseVisualStyleBackColor = true;
            // 
            // lblFileAccessed
            // 
            this.lblFileAccessed.AutoSize = true;
            this.lblFileAccessed.Location = new System.Drawing.Point(87, 256);
            this.lblFileAccessed.Name = "lblFileAccessed";
            this.lblFileAccessed.Size = new System.Drawing.Size(19, 13);
            this.lblFileAccessed.TabIndex = 16;
            this.lblFileAccessed.Text = "----";
            // 
            // lblFileModified
            // 
            this.lblFileModified.AutoSize = true;
            this.lblFileModified.Location = new System.Drawing.Point(87, 236);
            this.lblFileModified.Name = "lblFileModified";
            this.lblFileModified.Size = new System.Drawing.Size(19, 13);
            this.lblFileModified.TabIndex = 14;
            this.lblFileModified.Text = "----";
            // 
            // lblFileCreated
            // 
            this.lblFileCreated.AutoSize = true;
            this.lblFileCreated.Location = new System.Drawing.Point(87, 216);
            this.lblFileCreated.Name = "lblFileCreated";
            this.lblFileCreated.Size = new System.Drawing.Size(19, 13);
            this.lblFileCreated.TabIndex = 12;
            this.lblFileCreated.Text = "----";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 307);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Attributes:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Accessed:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Modified:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 11;
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
            // tabPageVFSItemAdvProperties
            // 
            this.tabPageVFSItemAdvProperties.Controls.Add(this.lViewExtendedProperties);
            this.tabPageVFSItemAdvProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageVFSItemAdvProperties.Name = "tabPageVFSItemAdvProperties";
            this.tabPageVFSItemAdvProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVFSItemAdvProperties.Size = new System.Drawing.Size(368, 383);
            this.tabPageVFSItemAdvProperties.TabIndex = 1;
            this.tabPageVFSItemAdvProperties.Text = "Advanced Properties";
            this.tabPageVFSItemAdvProperties.UseVisualStyleBackColor = true;
            // 
            // lViewExtendedProperties
            // 
            this.lViewExtendedProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lViewColumnProperty,
            this.lViewColumnValue});
            this.lViewExtendedProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "File Properties";
            listViewGroup1.Name = "lViewGroupFileProperties";
            listViewGroup2.Header = "Music Properties";
            listViewGroup2.Name = "lViewGroupMusicProperties";
            listViewGroup3.Header = "Audio Properties";
            listViewGroup3.Name = "lViewGroupAudioProperties";
            listViewGroup4.Header = "Video Properties";
            listViewGroup4.Name = "lViewGroupVideoProperties";
            listViewGroup5.Header = "Image Properties";
            listViewGroup5.Name = "lViewGroupImageProperties";
            listViewGroup6.Header = "Document Properties";
            listViewGroup6.Name = "lViewGroupDocProperties";
            this.lViewExtendedProperties.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            this.lViewExtendedProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lViewExtendedProperties.Location = new System.Drawing.Point(3, 3);
            this.lViewExtendedProperties.MultiSelect = false;
            this.lViewExtendedProperties.Name = "lViewExtendedProperties";
            this.lViewExtendedProperties.Size = new System.Drawing.Size(362, 377);
            this.lViewExtendedProperties.TabIndex = 0;
            this.lViewExtendedProperties.UseCompatibleStateImageBehavior = false;
            this.lViewExtendedProperties.View = System.Windows.Forms.View.Details;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(290, 420);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // WndVFSFileProperties
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(385, 453);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabVFSItemProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndVFSFileProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.wndVFSFileProperties_Load);
            this.tabVFSItemProperties.ResumeLayout(false);
            this.tabPageVFSItemGenProperties.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOpensWithIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxItemIcon)).EndInit();
            this.tabPageVFSItemAdvProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabVFSItemProperties;
        private System.Windows.Forms.TabPage tabPageVFSItemGenProperties;
        private System.Windows.Forms.TabPage tabPageVFSItemAdvProperties;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pBoxItemIcon;
        private System.Windows.Forms.Label lblFileAccessed;
        private System.Windows.Forms.Label lblFileModified;
        private System.Windows.Forms.Label lblFileCreated;
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
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pBoxOpensWithIcon;
        private System.Windows.Forms.TextBox txtOpensWithName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.Panel separator3;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.ListView lViewExtendedProperties;
        private System.Windows.Forms.ColumnHeader lViewColumnProperty;
        private System.Windows.Forms.ColumnHeader lViewColumnValue;
    }
}