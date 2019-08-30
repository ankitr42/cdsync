namespace CD_Sync_Portable
{
    partial class WndImageProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndImageProperties));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dlgFileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tabImageProperties = new System.Windows.Forms.TabControl();
            this.tabPageGeneralProperties = new System.Windows.Forms.TabPage();
            this.groupIntroductoryProperties = new System.Windows.Forms.GroupBox();
            this.pBoxImagePicture = new System.Windows.Forms.PictureBox();
            this.comboImageCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemovePicture = new System.Windows.Forms.Button();
            this.btnNewPicture = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImageDescription = new System.Windows.Forms.TextBox();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.tabPageAdvancedProperties = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.separator3 = new System.Windows.Forms.Panel();
            this.separator2 = new System.Windows.Forms.Panel();
            this.separator1 = new System.Windows.Forms.Panel();
            this.btnChangeImageSource = new System.Windows.Forms.Button();
            this.lblImageAccessed = new System.Windows.Forms.Label();
            this.lblImageDbSize = new System.Windows.Forms.Label();
            this.lblImageModified = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblImageCreated = new System.Windows.Forms.Label();
            this.lblTotalDirectories = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSourceVolumeLabel = new System.Windows.Forms.Label();
            this.lblSourceFileSystem = new System.Windows.Forms.Label();
            this.lblSourceDriveType = new System.Windows.Forms.Label();
            this.lblImageDbFileName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImageSource = new System.Windows.Forms.TextBox();
            this.tabImageProperties.SuspendLayout();
            this.tabPageGeneralProperties.SuspendLayout();
            this.groupIntroductoryProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxImagePicture)).BeginInit();
            this.tabPageAdvancedProperties.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(320, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cance&l";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(220, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dlgFileBrowser
            // 
            this.dlgFileBrowser.RestoreDirectory = true;
            // 
            // tabImageProperties
            // 
            this.tabImageProperties.Controls.Add(this.tabPageGeneralProperties);
            this.tabImageProperties.Controls.Add(this.tabPageAdvancedProperties);
            this.tabImageProperties.Location = new System.Drawing.Point(5, 4);
            this.tabImageProperties.Name = "tabImageProperties";
            this.tabImageProperties.SelectedIndex = 0;
            this.tabImageProperties.Size = new System.Drawing.Size(405, 425);
            this.tabImageProperties.TabIndex = 0;
            // 
            // tabPageGeneralProperties
            // 
            this.tabPageGeneralProperties.Controls.Add(this.groupIntroductoryProperties);
            this.tabPageGeneralProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneralProperties.Name = "tabPageGeneralProperties";
            this.tabPageGeneralProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneralProperties.Size = new System.Drawing.Size(397, 399);
            this.tabPageGeneralProperties.TabIndex = 0;
            this.tabPageGeneralProperties.Text = "General Properties";
            this.tabPageGeneralProperties.UseVisualStyleBackColor = true;
            // 
            // groupIntroductoryProperties
            // 
            this.groupIntroductoryProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupIntroductoryProperties.Controls.Add(this.pBoxImagePicture);
            this.groupIntroductoryProperties.Controls.Add(this.comboImageCategory);
            this.groupIntroductoryProperties.Controls.Add(this.label7);
            this.groupIntroductoryProperties.Controls.Add(this.label2);
            this.groupIntroductoryProperties.Controls.Add(this.btnRemovePicture);
            this.groupIntroductoryProperties.Controls.Add(this.btnNewPicture);
            this.groupIntroductoryProperties.Controls.Add(this.label3);
            this.groupIntroductoryProperties.Controls.Add(this.label1);
            this.groupIntroductoryProperties.Controls.Add(this.txtImageDescription);
            this.groupIntroductoryProperties.Controls.Add(this.txtImageName);
            this.groupIntroductoryProperties.Location = new System.Drawing.Point(8, 6);
            this.groupIntroductoryProperties.Name = "groupIntroductoryProperties";
            this.groupIntroductoryProperties.Size = new System.Drawing.Size(384, 387);
            this.groupIntroductoryProperties.TabIndex = 0;
            this.groupIntroductoryProperties.TabStop = false;
            this.groupIntroductoryProperties.Text = "General Properties";
            // 
            // pBoxImagePicture
            // 
            this.pBoxImagePicture.BackColor = System.Drawing.Color.Transparent;
            this.pBoxImagePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBoxImagePicture.Location = new System.Drawing.Point(98, 163);
            this.pBoxImagePicture.Name = "pBoxImagePicture";
            this.pBoxImagePicture.Size = new System.Drawing.Size(200, 175);
            this.pBoxImagePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxImagePicture.TabIndex = 4;
            this.pBoxImagePicture.TabStop = false;
            // 
            // comboImageCategory
            // 
            this.comboImageCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboImageCategory.FormattingEnabled = true;
            this.comboImageCategory.Location = new System.Drawing.Point(98, 136);
            this.comboImageCategory.Name = "comboImageCategory";
            this.comboImageCategory.Size = new System.Drawing.Size(275, 21);
            this.comboImageCategory.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Picture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Image name";
            // 
            // btnRemovePicture
            // 
            this.btnRemovePicture.Enabled = false;
            this.btnRemovePicture.Location = new System.Drawing.Point(98, 344);
            this.btnRemovePicture.Name = "btnRemovePicture";
            this.btnRemovePicture.Size = new System.Drawing.Size(95, 28);
            this.btnRemovePicture.TabIndex = 7;
            this.btnRemovePicture.Text = "&Remove Picture";
            this.btnRemovePicture.UseVisualStyleBackColor = true;
            this.btnRemovePicture.Click += new System.EventHandler(this.btnRemovePicture_Click);
            // 
            // btnNewPicture
            // 
            this.btnNewPicture.Location = new System.Drawing.Point(203, 344);
            this.btnNewPicture.Name = "btnNewPicture";
            this.btnNewPicture.Size = new System.Drawing.Size(95, 28);
            this.btnNewPicture.TabIndex = 8;
            this.btnNewPicture.Text = "C&hange Picture";
            this.btnNewPicture.UseVisualStyleBackColor = true;
            this.btnNewPicture.Click += new System.EventHandler(this.btnNewPicture_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Image &category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image &description";
            // 
            // txtImageDescription
            // 
            this.txtImageDescription.Location = new System.Drawing.Point(98, 48);
            this.txtImageDescription.Multiline = true;
            this.txtImageDescription.Name = "txtImageDescription";
            this.txtImageDescription.Size = new System.Drawing.Size(275, 82);
            this.txtImageDescription.TabIndex = 3;
            // 
            // txtImageName
            // 
            this.txtImageName.Location = new System.Drawing.Point(98, 22);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(275, 20);
            this.txtImageName.TabIndex = 1;
            // 
            // tabPageAdvancedProperties
            // 
            this.tabPageAdvancedProperties.Controls.Add(this.groupBox2);
            this.tabPageAdvancedProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdvancedProperties.Name = "tabPageAdvancedProperties";
            this.tabPageAdvancedProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvancedProperties.Size = new System.Drawing.Size(397, 399);
            this.tabPageAdvancedProperties.TabIndex = 1;
            this.tabPageAdvancedProperties.Text = "Advanced Properties";
            this.tabPageAdvancedProperties.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.separator3);
            this.groupBox2.Controls.Add(this.separator2);
            this.groupBox2.Controls.Add(this.separator1);
            this.groupBox2.Controls.Add(this.btnChangeImageSource);
            this.groupBox2.Controls.Add(this.lblImageAccessed);
            this.groupBox2.Controls.Add(this.lblImageDbSize);
            this.groupBox2.Controls.Add(this.lblImageModified);
            this.groupBox2.Controls.Add(this.lblTotalFiles);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblImageCreated);
            this.groupBox2.Controls.Add(this.lblTotalDirectories);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblSourceVolumeLabel);
            this.groupBox2.Controls.Add(this.lblSourceFileSystem);
            this.groupBox2.Controls.Add(this.lblSourceDriveType);
            this.groupBox2.Controls.Add(this.lblImageDbFileName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtImageSource);
            this.groupBox2.Location = new System.Drawing.Point(8, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 386);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced Properties";
            // 
            // separator3
            // 
            this.separator3.BackColor = System.Drawing.Color.Gray;
            this.separator3.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.separator3.Location = new System.Drawing.Point(9, 291);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(360, 10);
            this.separator3.TabIndex = 19;
            // 
            // separator2
            // 
            this.separator2.BackColor = System.Drawing.Color.Gray;
            this.separator2.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.separator2.Location = new System.Drawing.Point(9, 179);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(360, 10);
            this.separator2.TabIndex = 10;
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.Gray;
            this.separator1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.separator1.Location = new System.Drawing.Point(9, 90);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(360, 10);
            this.separator1.TabIndex = 3;
            // 
            // btnChangeImageSource
            // 
            this.btnChangeImageSource.Location = new System.Drawing.Point(279, 48);
            this.btnChangeImageSource.Name = "btnChangeImageSource";
            this.btnChangeImageSource.Size = new System.Drawing.Size(90, 28);
            this.btnChangeImageSource.TabIndex = 2;
            this.btnChangeImageSource.Text = "&Change";
            this.btnChangeImageSource.UseVisualStyleBackColor = true;
            this.btnChangeImageSource.Click += new System.EventHandler(this.btnChangeImageSource_Click);
            // 
            // lblImageAccessed
            // 
            this.lblImageAccessed.AutoSize = true;
            this.lblImageAccessed.Location = new System.Drawing.Point(180, 348);
            this.lblImageAccessed.Name = "lblImageAccessed";
            this.lblImageAccessed.Size = new System.Drawing.Size(13, 13);
            this.lblImageAccessed.TabIndex = 25;
            this.lblImageAccessed.Text = "0";
            // 
            // lblImageDbSize
            // 
            this.lblImageDbSize.AutoSize = true;
            this.lblImageDbSize.Location = new System.Drawing.Point(180, 258);
            this.lblImageDbSize.Name = "lblImageDbSize";
            this.lblImageDbSize.Size = new System.Drawing.Size(13, 13);
            this.lblImageDbSize.TabIndex = 18;
            this.lblImageDbSize.Text = "0";
            // 
            // lblImageModified
            // 
            this.lblImageModified.AutoSize = true;
            this.lblImageModified.Location = new System.Drawing.Point(180, 326);
            this.lblImageModified.Name = "lblImageModified";
            this.lblImageModified.Size = new System.Drawing.Size(13, 13);
            this.lblImageModified.TabIndex = 23;
            this.lblImageModified.Text = "0";
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(180, 236);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFiles.TabIndex = 16;
            this.lblTotalFiles.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 348);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Image last accessed on";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Size of the image on disk";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 326);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Image last modified on";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Total files in the image";
            // 
            // lblImageCreated
            // 
            this.lblImageCreated.AutoSize = true;
            this.lblImageCreated.Location = new System.Drawing.Point(180, 304);
            this.lblImageCreated.Name = "lblImageCreated";
            this.lblImageCreated.Size = new System.Drawing.Size(13, 13);
            this.lblImageCreated.TabIndex = 21;
            this.lblImageCreated.Text = "0";
            // 
            // lblTotalDirectories
            // 
            this.lblTotalDirectories.AutoSize = true;
            this.lblTotalDirectories.Location = new System.Drawing.Point(180, 214);
            this.lblTotalDirectories.Name = "lblTotalDirectories";
            this.lblTotalDirectories.Size = new System.Drawing.Size(13, 13);
            this.lblTotalDirectories.TabIndex = 14;
            this.lblTotalDirectories.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Image created on";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total directories in the image";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Source drive type";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Source volume label";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Source filesystem";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Image database filename";
            // 
            // lblSourceVolumeLabel
            // 
            this.lblSourceVolumeLabel.Location = new System.Drawing.Point(181, 145);
            this.lblSourceVolumeLabel.Name = "lblSourceVolumeLabel";
            this.lblSourceVolumeLabel.Size = new System.Drawing.Size(188, 13);
            this.lblSourceVolumeLabel.TabIndex = 9;
            this.lblSourceVolumeLabel.Text = "0";
            // 
            // lblSourceFileSystem
            // 
            this.lblSourceFileSystem.Location = new System.Drawing.Point(181, 125);
            this.lblSourceFileSystem.Name = "lblSourceFileSystem";
            this.lblSourceFileSystem.Size = new System.Drawing.Size(188, 13);
            this.lblSourceFileSystem.TabIndex = 7;
            this.lblSourceFileSystem.Text = "0";
            // 
            // lblSourceDriveType
            // 
            this.lblSourceDriveType.Location = new System.Drawing.Point(181, 103);
            this.lblSourceDriveType.Name = "lblSourceDriveType";
            this.lblSourceDriveType.Size = new System.Drawing.Size(188, 13);
            this.lblSourceDriveType.TabIndex = 5;
            this.lblSourceDriveType.Text = "0";
            // 
            // lblImageDbFileName
            // 
            this.lblImageDbFileName.Location = new System.Drawing.Point(180, 192);
            this.lblImageDbFileName.Name = "lblImageDbFileName";
            this.lblImageDbFileName.Size = new System.Drawing.Size(189, 13);
            this.lblImageDbFileName.TabIndex = 12;
            this.lblImageDbFileName.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Image source";
            // 
            // txtImageSource
            // 
            this.txtImageSource.Location = new System.Drawing.Point(98, 22);
            this.txtImageSource.Name = "txtImageSource";
            this.txtImageSource.ReadOnly = true;
            this.txtImageSource.Size = new System.Drawing.Size(271, 20);
            this.txtImageSource.TabIndex = 1;
            // 
            // WndImageProperties
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(413, 468);
            this.Controls.Add(this.tabImageProperties);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndImageProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Properties";
            this.tabImageProperties.ResumeLayout(false);
            this.tabPageGeneralProperties.ResumeLayout(false);
            this.groupIntroductoryProperties.ResumeLayout(false);
            this.groupIntroductoryProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxImagePicture)).EndInit();
            this.tabPageAdvancedProperties.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.OpenFileDialog dlgFileBrowser;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.TabControl tabImageProperties;
        private System.Windows.Forms.TabPage tabPageGeneralProperties;
        private System.Windows.Forms.GroupBox groupIntroductoryProperties;
        private System.Windows.Forms.PictureBox pBoxImagePicture;
        private System.Windows.Forms.ComboBox comboImageCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemovePicture;
        private System.Windows.Forms.Button btnNewPicture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImageDescription;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.TabPage tabPageAdvancedProperties;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChangeImageSource;
        private System.Windows.Forms.Label lblImageAccessed;
        private System.Windows.Forms.Label lblImageDbSize;
        private System.Windows.Forms.Label lblImageModified;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblImageCreated;
        private System.Windows.Forms.Label lblTotalDirectories;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSourceVolumeLabel;
        private System.Windows.Forms.Label lblSourceFileSystem;
        private System.Windows.Forms.Label lblSourceDriveType;
        private System.Windows.Forms.Label lblImageDbFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImageSource;
        private System.Windows.Forms.Panel separator3;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.Panel separator1;
    }
}