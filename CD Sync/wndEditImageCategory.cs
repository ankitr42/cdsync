using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using CD_Sync_Portable.Properties;
using System.Windows.Forms;

namespace CD_Sync_Portable
{
    internal partial class WndEditImageCategory : Form
    {
        private ImageCategory category;

        public WndEditImageCategory(string windowTitle, ImageCategory category)
        {
            InitializeComponent();

            this.Text = windowTitle;
            this.category = category;
        }

        public new ImageCategory ShowDialog()
        {
            base.ShowDialog();
            return category;
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show(Resources.msgImageCategoryNameEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.Compare(txtCategoryName.Text, category.categoryName, true) == 0 || String.Compare(txtCategoryDesc.Text, category.categoryDesc, true) == 0)
                this.DialogResult = DialogResult.Cancel;

            category.categoryName = txtCategoryName.Text;
            category.categoryDesc = txtCategoryDesc.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void wndEditImageCategory_Load(object sender, EventArgs e)
        {
            this.txtCategoryName.Text = category.categoryName;
            this.txtCategoryDesc.Text = category.categoryDesc;
        }

        private void txtCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '"')
                e.Handled = true;
        }

        private void txtCategoryDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '"')
                e.Handled = true;
        }
    }
}