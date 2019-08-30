namespace CD_Sync_Portable
{
    partial class WndImageCategoryManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndImageCategoryManager));
            this.label1 = new System.Windows.Forms.Label();
            this.lViewCategories = new System.Windows.Forms.ListView();
            this.clmnName = new System.Windows.Forms.ColumnHeader();
            this.clmnDesc = new System.Windows.Forms.ColumnHeader();
            this.btnAddNewCategory = new System.Windows.Forms.Button();
            this.btnModifyCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A&vailable categories";
            // 
            // lViewCategories
            // 
            this.lViewCategories.BackColor = System.Drawing.SystemColors.Window;
            this.lViewCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnName,
            this.clmnDesc});
            this.lViewCategories.FullRowSelect = true;
            this.lViewCategories.GridLines = true;
            this.lViewCategories.HideSelection = false;
            this.lViewCategories.Location = new System.Drawing.Point(6, 25);
            this.lViewCategories.MultiSelect = false;
            this.lViewCategories.Name = "lViewCategories";
            this.lViewCategories.Size = new System.Drawing.Size(332, 160);
            this.lViewCategories.TabIndex = 1;
            this.lViewCategories.UseCompatibleStateImageBehavior = false;
            this.lViewCategories.View = System.Windows.Forms.View.Details;
            this.lViewCategories.SelectedIndexChanged += new System.EventHandler(this.lViewCategories_SelectedIndexChanged);
            // 
            // clmnName
            // 
            this.clmnName.Text = "Name";
            this.clmnName.Width = 79;
            // 
            // clmnDesc
            // 
            this.clmnDesc.Text = "Description";
            this.clmnDesc.Width = 249;
            // 
            // btnAddNewCategory
            // 
            this.btnAddNewCategory.Location = new System.Drawing.Point(6, 195);
            this.btnAddNewCategory.Name = "btnAddNewCategory";
            this.btnAddNewCategory.Size = new System.Drawing.Size(90, 28);
            this.btnAddNewCategory.TabIndex = 2;
            this.btnAddNewCategory.Text = "&Add New";
            this.btnAddNewCategory.UseVisualStyleBackColor = true;
            this.btnAddNewCategory.Click += new System.EventHandler(this.btnAddNewCategory_Click);
            // 
            // btnModifyCategory
            // 
            this.btnModifyCategory.Enabled = false;
            this.btnModifyCategory.Location = new System.Drawing.Point(248, 195);
            this.btnModifyCategory.Name = "btnModifyCategory";
            this.btnModifyCategory.Size = new System.Drawing.Size(90, 28);
            this.btnModifyCategory.TabIndex = 3;
            this.btnModifyCategory.Text = "&Modify";
            this.btnModifyCategory.UseVisualStyleBackColor = true;
            this.btnModifyCategory.Click += new System.EventHandler(this.btnModifyCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Enabled = false;
            this.btnDeleteCategory.Location = new System.Drawing.Point(6, 233);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(90, 28);
            this.btnDeleteCategory.TabIndex = 4;
            this.btnDeleteCategory.Text = "&Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(248, 233);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // WndImageCategoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(345, 270);
            this.Controls.Add(this.btnModifyCategory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnAddNewCategory);
            this.Controls.Add(this.lViewCategories);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndImageCategoryManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Categories";
            this.Load += new System.EventHandler(this.wndImageCategoryManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lViewCategories;
        private System.Windows.Forms.ColumnHeader clmnName;
        private System.Windows.Forms.ColumnHeader clmnDesc;
        private System.Windows.Forms.Button btnAddNewCategory;
        private System.Windows.Forms.Button btnModifyCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnClose;
    }
}