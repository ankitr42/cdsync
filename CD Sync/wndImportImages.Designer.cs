namespace CD_Sync_Portable
{
    partial class WndImportImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndImportImages));
            this.treeImageBrowser = new System.Windows.Forms.TreeView();
            this.txtImportDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.grpImageProperties = new System.Windows.Forms.GroupBox();
            this.panelImageProperties = new System.Windows.Forms.Panel();
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.bgImportListReader = new System.ComponentModel.BackgroundWorker();
            this.bgImageImporter = new System.ComponentModel.BackgroundWorker();
            this.grpImageProperties.SuspendLayout();
            this.panelImageProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeImageBrowser
            // 
            this.treeImageBrowser.CheckBoxes = true;
            this.treeImageBrowser.Location = new System.Drawing.Point(12, 69);
            this.treeImageBrowser.Name = "treeImageBrowser";
            this.treeImageBrowser.Size = new System.Drawing.Size(388, 258);
            this.treeImageBrowser.TabIndex = 4;
            this.treeImageBrowser.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeImageBrowser_AfterCheck);
            this.treeImageBrowser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeImageBrowser_AfterSelect);
            // 
            // txtImportDirectory
            // 
            this.txtImportDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtImportDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtImportDirectory.BackColor = System.Drawing.SystemColors.Window;
            this.txtImportDirectory.Location = new System.Drawing.Point(12, 25);
            this.txtImportDirectory.Name = "txtImportDirectory";
            this.txtImportDirectory.ReadOnly = true;
            this.txtImportDirectory.Size = new System.Drawing.Size(292, 20);
            this.txtImportDirectory.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(310, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 28);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select source directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select images to import";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(214, 484);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(90, 28);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "&Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(310, 484);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select the directory that contains the images to import.";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // grpImageProperties
            // 
            this.grpImageProperties.Controls.Add(this.panelImageProperties);
            this.grpImageProperties.Location = new System.Drawing.Point(12, 333);
            this.grpImageProperties.Name = "grpImageProperties";
            this.grpImageProperties.Size = new System.Drawing.Size(388, 145);
            this.grpImageProperties.TabIndex = 5;
            this.grpImageProperties.TabStop = false;
            this.grpImageProperties.Text = "Image Properties";
            // 
            // panelImageProperties
            // 
            this.panelImageProperties.AutoScroll = true;
            this.panelImageProperties.Controls.Add(this.lblImageInfo);
            this.panelImageProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImageProperties.Location = new System.Drawing.Point(3, 16);
            this.panelImageProperties.Name = "panelImageProperties";
            this.panelImageProperties.Size = new System.Drawing.Size(382, 126);
            this.panelImageProperties.TabIndex = 1;
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.AutoSize = true;
            this.lblImageInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImageInfo.Location = new System.Drawing.Point(0, 0);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(319, 13);
            this.lblImageInfo.TabIndex = 0;
            this.lblImageInfo.Text = "Click the Browse button to select a directory to import images from.";
            // 
            // bgImportListReader
            // 
            this.bgImportListReader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgImportListReader_DoWork);
            this.bgImportListReader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgImportListReader_RunWorkerCompleted);
            // 
            // bgImageImporter
            // 
            this.bgImageImporter.WorkerReportsProgress = true;
            this.bgImageImporter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgImageImporter_DoWork);
            this.bgImageImporter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgImageImporter_RunWorkerCompleted);
            this.bgImageImporter.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgImageImporter_ProgressChanged);
            // 
            // WndImportImages
            // 
            this.AcceptButton = this.btnImport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(412, 524);
            this.Controls.Add(this.grpImageProperties);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtImportDirectory);
            this.Controls.Add(this.treeImageBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndImportImages";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Images";
            this.Load += new System.EventHandler(this.WndImportImages_Load);
            this.grpImageProperties.ResumeLayout(false);
            this.panelImageProperties.ResumeLayout(false);
            this.panelImageProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeImageBrowser;
        private System.Windows.Forms.TextBox txtImportDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox grpImageProperties;
        private System.Windows.Forms.Panel panelImageProperties;
        private System.Windows.Forms.Label lblImageInfo;
        private System.ComponentModel.BackgroundWorker bgImportListReader;
        private System.ComponentModel.BackgroundWorker bgImageImporter;
    }
}