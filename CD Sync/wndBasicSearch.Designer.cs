namespace CD_Sync_Portable
{
    partial class WndBasicSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndBasicSearch));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeImageSelector = new System.Windows.Forms.TreeView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lnkLblAdvancedSearch = new System.Windows.Forms.LinkLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Look for (wildcards allowed, use pipe \'|\' to separate multiple entries):";
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(4, 20);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(403, 20);
            this.txtSearchText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Look in:";
            // 
            // treeImageSelector
            // 
            this.treeImageSelector.CheckBoxes = true;
            this.treeImageSelector.Location = new System.Drawing.Point(4, 63);
            this.treeImageSelector.Name = "treeImageSelector";
            this.treeImageSelector.Size = new System.Drawing.Size(403, 238);
            this.treeImageSelector.TabIndex = 3;
            this.treeImageSelector.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeImageSelector_AfterCheck);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(221, 317);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lnkLblAdvancedSearch
            // 
            this.lnkLblAdvancedSearch.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkLblAdvancedSearch.AutoSize = true;
            this.lnkLblAdvancedSearch.Location = new System.Drawing.Point(1, 332);
            this.lnkLblAdvancedSearch.Name = "lnkLblAdvancedSearch";
            this.lnkLblAdvancedSearch.Size = new System.Drawing.Size(93, 13);
            this.lnkLblAdvancedSearch.TabIndex = 4;
            this.lnkLblAdvancedSearch.TabStop = true;
            this.lnkLblAdvancedSearch.Text = "Advanced Search";
            this.lnkLblAdvancedSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblAdvancedSearch_LinkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(317, 317);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // WndBasicSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(411, 350);
            this.Controls.Add(this.lnkLblAdvancedSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.treeImageSelector);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndBasicSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Basic Search";
            this.Load += new System.EventHandler(this.WndBasicSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeImageSelector;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.LinkLabel lnkLblAdvancedSearch;
        private System.Windows.Forms.Button btnCancel;
    }
}