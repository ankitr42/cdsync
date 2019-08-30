using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CD_Sync_Portable.Properties;
using Registry_Manager;

namespace CD_Sync_Portable
{
    internal partial class WndImageCategoryManager : Form
    {
        List<ImageCategory> categories;
        bool refresh;

        /// <summary>
        /// Returns true if the categories were modified and false otherwise.
        /// </summary>
        public bool Reload
        {
            get
            {
                return refresh;
            }
        }
        
        public WndImageCategoryManager()
        {
            InitializeComponent();
            categories = new List<ImageCategory>();
            refresh = false;
        }

        private void wndImageCategoryManager_Load(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void lViewCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lViewCategories.SelectedItems.Count > 0)
            {
                btnModifyCategory.Enabled = true;
                btnDeleteCategory.Enabled = true;
            }
            else
            {
                btnModifyCategory.Enabled = false;
                btnDeleteCategory.Enabled = false;
            }
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            ImageCategory tempImageCategory;
            WndEditImageCategory wndNewCategory = new WndEditImageCategory("Create new image category", new ImageCategory());

            tempImageCategory = wndNewCategory.ShowDialog();

            if (wndNewCategory.DialogResult == DialogResult.OK)
            {
                CategoryManager.AddCategory(tempImageCategory);
                RefreshView();
                refresh = true;
            }
            wndNewCategory.Dispose();
        }

        private void btnModifyCategory_Click(object sender, EventArgs e)
        {
            ImageCategory tempImageCategory;
            WndEditImageCategory wndEditCategory = new WndEditImageCategory("Modify Image Category", (ImageCategory)lViewCategories.SelectedItems[0].Tag);
            
            tempImageCategory = wndEditCategory.ShowDialog();

            if (wndEditCategory.DialogResult == DialogResult.OK)
            {
                CategoryManager.RemoveCategory((ImageCategory)lViewCategories.SelectedItems[0].Tag);
                CategoryManager.AddCategory(tempImageCategory);
                RefreshView();
                refresh = true;
            }
            wndEditCategory.Dispose();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.promptImageCategoryDelete, "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CategoryManager.RemoveCategory((ImageCategory)lViewCategories.SelectedItems[0].Tag);
                RefreshView();
                refresh = true;
            }
        }

        private void RefreshView()
        {
            ListViewItem temp = new ListViewItem();
            categories.Clear();
            lViewCategories.Items.Clear();

            categories.AddRange(CategoryManager.GetAllCategories());

            btnDeleteCategory.Enabled = false;
            btnModifyCategory.Enabled = false;

            lViewCategories.BeginUpdate();
            foreach (ImageCategory category in categories)
            {
                temp.SubItems.Clear();
                temp.Text = category.categoryName;
                temp.SubItems.Add(category.categoryDesc);
                temp.Tag = category;

                lViewCategories.Items.Add((ListViewItem)temp.Clone());
            }
            lViewCategories.EndUpdate();
        }
    }
}