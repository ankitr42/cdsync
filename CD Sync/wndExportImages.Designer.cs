namespace CD_Sync_Portable
{
    partial class WndExportImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndExportImages));
            this.treeImageBrowser = new System.Windows.Forms.TreeView();
            this.txtExportDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.grpImageProperties = new System.Windows.Forms.GroupBox();
            this.panelImageProperties = new System.Windows.Forms.Panel();
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
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
            // txtExportDirectory
            // 
            this.txtExportDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtExportDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtExportDirectory.BackColor = System.Drawing.SystemColors.Window;
            this.txtExportDirectory.Location = new System.Drawing.Point(12, 25);
            this.txtExportDirectory.Name = "txtExportDirectory";
            this.txtExportDirectory.ReadOnly = true;
            this.txtExportDirectory.Size = new System.Drawing.Size(292, 20);
            this.txtExportDirectory.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select destination directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select images to export";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(214, 473);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 28);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(310, 473);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select a directory to export your images to.";
            // 
            // grpImageProperties
            // 
            this.grpImageProperties.Controls.Add(this.panelImageProperties);
            this.grpImageProperties.Location = new System.Drawing.Point(12, 333);
            this.grpImageProperties.Name = "grpImageProperties";
            this.grpImageProperties.Size = new System.Drawing.Size(388, 128);
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
            this.panelImageProperties.Size = new System.Drawing.Size(382, 109);
            this.panelImageProperties.TabIndex = 0;
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.AutoSize = true;
            this.lblImageInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImageInfo.Location = new System.Drawing.Point(0, 0);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(185, 13);
            this.lblImageInfo.TabIndex = 0;
            this.lblImageInfo.Text = "Select an image to view its properties.";
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // WndExportImages
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(412, 513);
            this.Controls.Add(this.grpImageProperties);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtExportDirectory);
            this.Controls.Add(this.treeImageBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndExportImages";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Images";
            this.grpImageProperties.ResumeLayout(false);
            this.panelImageProperties.ResumeLayout(false);
            this.panelImageProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeImageBrowser;
        private System.Windows.Forms.TextBox txtExportDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox grpImageProperties;
        private System.Windows.Forms.Label lblImageInfo;
        private System.Windows.Forms.Panel panelImageProperties;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}