namespace CD_Sync_Portable
{
    partial class WndImageOrganizer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeImageBrowser = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpCommonTasks = new System.Windows.Forms.GroupBox();
            this.lblLasrSynchronization = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDeleteCurrent = new System.Windows.Forms.Button();
            this.btnDeleteAllSelected = new System.Windows.Forms.Button();
            this.btnSynchronize = new System.Windows.Forms.Button();
            this.btnExportDirectoryTree = new System.Windows.Forms.Button();
            this.btnExportFilelist = new System.Windows.Forms.Button();
            this.btnExportCurrent = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSeparator3 = new System.Windows.Forms.Label();
            this.lblSeparator2 = new System.Windows.Forms.Label();
            this.lblSeparator1 = new System.Windows.Forms.Label();
            this.grpImageProperties = new System.Windows.Forms.GroupBox();
            this.btnEditProperties = new System.Windows.Forms.Button();
            this.lblIntro = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpCommonTasks.SuspendLayout();
            this.grpImageProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.55132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.44868F));
            this.tableLayoutPanel1.Controls.Add(this.treeImageBrowser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(663, 447);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // treeImageBrowser
            // 
            this.treeImageBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeImageBrowser.Location = new System.Drawing.Point(3, 3);
            this.treeImageBrowser.Name = "treeImageBrowser";
            this.treeImageBrowser.Size = new System.Drawing.Size(209, 441);
            this.treeImageBrowser.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.grpCommonTasks);
            this.panel1.Controls.Add(this.grpImageProperties);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(218, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 441);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(352, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // grpCommonTasks
            // 
            this.grpCommonTasks.Controls.Add(this.lblLasrSynchronization);
            this.grpCommonTasks.Controls.Add(this.btnImport);
            this.grpCommonTasks.Controls.Add(this.btnDeleteCurrent);
            this.grpCommonTasks.Controls.Add(this.btnDeleteAllSelected);
            this.grpCommonTasks.Controls.Add(this.btnSynchronize);
            this.grpCommonTasks.Controls.Add(this.btnExportDirectoryTree);
            this.grpCommonTasks.Controls.Add(this.btnExportFilelist);
            this.grpCommonTasks.Controls.Add(this.btnExportCurrent);
            this.grpCommonTasks.Controls.Add(this.btnExportAll);
            this.grpCommonTasks.Controls.Add(this.label1);
            this.grpCommonTasks.Controls.Add(this.lblSeparator3);
            this.grpCommonTasks.Controls.Add(this.lblSeparator2);
            this.grpCommonTasks.Controls.Add(this.lblSeparator1);
            this.grpCommonTasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCommonTasks.Location = new System.Drawing.Point(0, 132);
            this.grpCommonTasks.Name = "grpCommonTasks";
            this.grpCommonTasks.Size = new System.Drawing.Size(442, 272);
            this.grpCommonTasks.TabIndex = 2;
            this.grpCommonTasks.TabStop = false;
            this.grpCommonTasks.Text = "Common Tasks";
            // 
            // lblLasrSynchronization
            // 
            this.lblLasrSynchronization.Location = new System.Drawing.Point(3, 157);
            this.lblLasrSynchronization.Name = "lblLasrSynchronization";
            this.lblLasrSynchronization.Size = new System.Drawing.Size(311, 28);
            this.lblLasrSynchronization.TabIndex = 8;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(319, 37);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(116, 28);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import Images";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCurrent
            // 
            this.btnDeleteCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCurrent.Enabled = false;
            this.btnDeleteCurrent.Location = new System.Drawing.Point(320, 218);
            this.btnDeleteCurrent.Name = "btnDeleteCurrent";
            this.btnDeleteCurrent.Size = new System.Drawing.Size(116, 28);
            this.btnDeleteCurrent.TabIndex = 12;
            this.btnDeleteCurrent.Text = "Delete Current Image";
            this.btnDeleteCurrent.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAllSelected
            // 
            this.btnDeleteAllSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAllSelected.Enabled = false;
            this.btnDeleteAllSelected.Location = new System.Drawing.Point(198, 218);
            this.btnDeleteAllSelected.Name = "btnDeleteAllSelected";
            this.btnDeleteAllSelected.Size = new System.Drawing.Size(116, 28);
            this.btnDeleteAllSelected.TabIndex = 11;
            this.btnDeleteAllSelected.Text = "Delete All Selected";
            this.btnDeleteAllSelected.UseVisualStyleBackColor = true;
            // 
            // btnSynchronize
            // 
            this.btnSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSynchronize.Enabled = false;
            this.btnSynchronize.Location = new System.Drawing.Point(320, 157);
            this.btnSynchronize.Name = "btnSynchronize";
            this.btnSynchronize.Size = new System.Drawing.Size(116, 28);
            this.btnSynchronize.TabIndex = 9;
            this.btnSynchronize.Text = "Synchronize Image";
            this.btnSynchronize.UseVisualStyleBackColor = true;
            // 
            // btnExportDirectoryTree
            // 
            this.btnExportDirectoryTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportDirectoryTree.Enabled = false;
            this.btnExportDirectoryTree.Location = new System.Drawing.Point(320, 97);
            this.btnExportDirectoryTree.Name = "btnExportDirectoryTree";
            this.btnExportDirectoryTree.Size = new System.Drawing.Size(116, 28);
            this.btnExportDirectoryTree.TabIndex = 6;
            this.btnExportDirectoryTree.Text = "Export Directory Tree";
            this.btnExportDirectoryTree.UseVisualStyleBackColor = true;
            // 
            // btnExportFilelist
            // 
            this.btnExportFilelist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportFilelist.Enabled = false;
            this.btnExportFilelist.Location = new System.Drawing.Point(198, 97);
            this.btnExportFilelist.Name = "btnExportFilelist";
            this.btnExportFilelist.Size = new System.Drawing.Size(116, 28);
            this.btnExportFilelist.TabIndex = 5;
            this.btnExportFilelist.Text = "Export Filelist";
            this.btnExportFilelist.UseVisualStyleBackColor = true;
            // 
            // btnExportCurrent
            // 
            this.btnExportCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCurrent.Enabled = false;
            this.btnExportCurrent.Location = new System.Drawing.Point(198, 37);
            this.btnExportCurrent.Name = "btnExportCurrent";
            this.btnExportCurrent.Size = new System.Drawing.Size(116, 28);
            this.btnExportCurrent.TabIndex = 2;
            this.btnExportCurrent.Text = "Export This Image";
            this.btnExportCurrent.UseVisualStyleBackColor = true;
            // 
            // btnExportAll
            // 
            this.btnExportAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportAll.Enabled = false;
            this.btnExportAll.Location = new System.Drawing.Point(76, 37);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(116, 28);
            this.btnExportAll.TabIndex = 1;
            this.btnExportAll.Text = "Export All Selected";
            this.btnExportAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Delete Images";
            // 
            // lblSeparator3
            // 
            this.lblSeparator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeparator3.AutoEllipsis = true;
            this.lblSeparator3.BackColor = System.Drawing.Color.Gray;
            this.lblSeparator3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator3.ForeColor = System.Drawing.Color.White;
            this.lblSeparator3.Location = new System.Drawing.Point(4, 76);
            this.lblSeparator3.Name = "lblSeparator3";
            this.lblSeparator3.Size = new System.Drawing.Size(432, 15);
            this.lblSeparator3.TabIndex = 4;
            this.lblSeparator3.Text = "Export Filelist or Directory Tree";
            // 
            // lblSeparator2
            // 
            this.lblSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeparator2.AutoEllipsis = true;
            this.lblSeparator2.BackColor = System.Drawing.Color.Gray;
            this.lblSeparator2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator2.ForeColor = System.Drawing.Color.White;
            this.lblSeparator2.Location = new System.Drawing.Point(4, 136);
            this.lblSeparator2.Name = "lblSeparator2";
            this.lblSeparator2.Size = new System.Drawing.Size(432, 15);
            this.lblSeparator2.TabIndex = 7;
            this.lblSeparator2.Text = "Synchronize Image";
            // 
            // lblSeparator1
            // 
            this.lblSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeparator1.AutoEllipsis = true;
            this.lblSeparator1.BackColor = System.Drawing.Color.Gray;
            this.lblSeparator1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator1.ForeColor = System.Drawing.Color.White;
            this.lblSeparator1.Location = new System.Drawing.Point(3, 16);
            this.lblSeparator1.Name = "lblSeparator1";
            this.lblSeparator1.Size = new System.Drawing.Size(432, 15);
            this.lblSeparator1.TabIndex = 0;
            this.lblSeparator1.Text = "Import and Export Images";
            // 
            // grpImageProperties
            // 
            this.grpImageProperties.Controls.Add(this.btnEditProperties);
            this.grpImageProperties.Controls.Add(this.lblIntro);
            this.grpImageProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpImageProperties.Location = new System.Drawing.Point(0, 0);
            this.grpImageProperties.Name = "grpImageProperties";
            this.grpImageProperties.Size = new System.Drawing.Size(442, 132);
            this.grpImageProperties.TabIndex = 0;
            this.grpImageProperties.TabStop = false;
            this.grpImageProperties.Text = "Image Properties";
            // 
            // btnEditProperties
            // 
            this.btnEditProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditProperties.Location = new System.Drawing.Point(346, 98);
            this.btnEditProperties.Name = "btnEditProperties";
            this.btnEditProperties.Size = new System.Drawing.Size(90, 28);
            this.btnEditProperties.TabIndex = 1;
            this.btnEditProperties.Text = "&Edit Properties";
            this.btnEditProperties.UseVisualStyleBackColor = true;
            this.btnEditProperties.Visible = false;
            // 
            // lblIntro
            // 
            this.lblIntro.AutoEllipsis = true;
            this.lblIntro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIntro.Location = new System.Drawing.Point(3, 16);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(436, 113);
            this.lblIntro.TabIndex = 0;
            // 
            // WndImageOrganizer
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(663, 447);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndImageOrganizer";
            this.ShowInTaskbar = false;
            this.Text = "Image Organizer";
            this.Load += new System.EventHandler(this.wndImageOrganizer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grpCommonTasks.ResumeLayout(false);
            this.grpImageProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeImageBrowser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpImageProperties;
        private System.Windows.Forms.GroupBox grpCommonTasks;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Button btnEditProperties;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSeparator1;
        private System.Windows.Forms.Label lblSeparator2;
        private System.Windows.Forms.Label lblSeparator3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.Button btnExportCurrent;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExportDirectoryTree;
        private System.Windows.Forms.Button btnExportFilelist;
        private System.Windows.Forms.Button btnSynchronize;
        private System.Windows.Forms.Button btnDeleteAllSelected;
        private System.Windows.Forms.Button btnDeleteCurrent;
        private System.Windows.Forms.Label lblLasrSynchronization;

    }
}