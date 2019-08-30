using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CD_Sync_Portable.Properties;
using Registry_Manager;

namespace CD_Sync_Portable
{
    internal partial class WndNewImage : Form
    {
        private bool refresh;

        public WndNewImage(string path)
        {
            InitializeComponent();

            try
            {
                if (path != null)
                {
                    DriveInfo drvInfo = new DriveInfo(path);
                    if (drvInfo.IsReady)
                    {
                        txtSource.Text = path;
                        if (path.EndsWith("\\"))
                            txtCdName.Text = drvInfo.VolumeLabel;
                        else
                            txtCdName.Text = path.Substring(path.LastIndexOf("\\") + 1);
                    }
                    else
                    {
                        MessageBox.Show(Resources.msgImageSourceNotReady, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            {
            }
        }

        public DialogResult ShowDialog(List<ImageCategory> categories)
        {
            foreach(ImageCategory category in categories)
                comboCategories.Items.Add(category.categoryName);
            
            comboCategories.Items.Add("");

            comboCategories.SelectedIndex = 0;
            base.ShowDialog();
            if (refresh)
                return DialogResult.OK;
            else
                return this.DialogResult;
        }

        private void chkSizeFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSizeFilter.Checked)
                grpSizeFilterSettings.Enabled = true;
            else
                grpSizeFilterSettings.Enabled = false;
        }

        private void chkAttributesFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAttributesFilter.Checked)
                grpAttributesFilterSettings.Enabled = true;
            else
                grpAttributesFilterSettings.Enabled = false;
        }

        private void chkDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateFilter.Checked)
                grpDateFilterSettings.Enabled = true;
            else
                grpDateFilterSettings.Enabled = false;
        }

        private void chkCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreatedDate.Checked)
            {
                dateCreatedB.Enabled = true;
                dateCreatedE.Enabled = true;
                label15.Enabled = true;
            }
            else
            {
                dateCreatedB.Enabled = false;
                dateCreatedE.Enabled = false;
                label15.Enabled = false;
            }
        }

        private void chkModifiedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModifiedDate.Checked)
            {
                dateModifiedB.Enabled = true;
                dateModifiedE.Enabled = true;
                label8.Enabled = true;
            }
            else
            {
                dateModifiedB.Enabled = false;
                dateModifiedE.Enabled = false;
                label8.Enabled = false;
            }
        }

        private void chkAccessedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAccessedDate.Checked)
            {
                dateAccessedB.Enabled = true;
                dateAccessedE.Enabled = true;
                label10.Enabled = true;
            }
            else
            {
                dateAccessedB.Enabled = false;
                dateAccessedE.Enabled = false;
                label10.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FSToVFSHandler fsToVFSHandler;

            if (txtSource.Text.Length == 0)
            {
                MessageBox.Show(Resources.msgImageSourceNotSpecified, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(txtSource.Text))
            {
                MessageBox.Show(Resources.msgImageSourceNotFound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCdName.Text.Length == 0)
            {
                MessageBox.Show(Resources.msgImageNameEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtImagePic.Text.Length == 0)
                if (MessageBox.Show(Resources.promptImagePicEmpty, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            if (txtCdDescription.Text.Length == 0)
                if (MessageBox.Show(Resources.promptImageDescEmpty, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            FilterSettings filterSettings;

            filterSettings.sizeFilter = chkSizeFilter.Checked;
            filterSettings.minSize = (txtFileSizeLBound.Text.Length == 0) ? 0 : Convert.ToUInt64(txtFileSizeLBound.Text) * 1024;
            filterSettings.maxSize = (txtFileSizeUBound.Text.Length == 0) ? 0 : Convert.ToUInt64(txtFileSizeUBound.Text) * 1024;

            filterSettings.attrFilter = chkAttributesFilter.Checked;
            filterSettings.exArchive = chkExcludeArchive.Checked;
            filterSettings.exROnly = chkExcludeROnly.Checked;
            filterSettings.exHidden = chkExcludeHidden.Checked;
            filterSettings.exSystem = chkExcludeSystem.Checked;
            filterSettings.exCompressed = chkExcludeCompressed.Checked;
            filterSettings.exEncrypted = chkExcludeEncrypted.Checked;

            filterSettings.dateFilter = chkDateFilter.Checked;
            filterSettings.cDate = chkCreatedDate.Checked;
            filterSettings.cDateBegin = dateCreatedB.Value;
            filterSettings.cDateEnd = dateCreatedE.Value;
            filterSettings.mDate = chkModifiedDate.Checked;
            filterSettings.mDateBegin = dateModifiedB.Value;
            filterSettings.mDateEnd = dateModifiedE.Value;
            filterSettings.aDate = chkAccessedDate.Checked;
            filterSettings.aDateBegin = dateAccessedB.Value;
            filterSettings.aDateEnd = dateAccessedE.Value;

            if (radioExcludeTypes.Checked)
                filterSettings.fTypeFilter = true;
            else
                filterSettings.fTypeFilter = false;
            filterSettings.fTypes = txtFileTypes.Text;
            filterSettings.excludedFiles = new List<string>();
            filterSettings.excludedDirectories = new List<string>();
            foreach (object item in lstExcludedFiles.Items)
                filterSettings.excludedFiles.Add((string)item);
            foreach (object item in lstExcludedDirectories.Items)
                filterSettings.excludedDirectories.Add((string)item);

            FilterExtendedInfo filterExInfo;
            filterExInfo.copyExtendedInfo = chkCopyExtendedFileInfo.Checked;
            filterExInfo.copyFileVersionInfo = chkCopyFileVersionInfo.Checked;
            filterExInfo.copyAVInfo = chkCopyFileAVInfo.Checked;
            filterExInfo.copyDocumentInfo = chkCopyDocInfo.Checked;
            filterExInfo.copyFileIcon = chkCopyIcons.Checked;

            this.Enabled = false;

            fsToVFSHandler = new FSToVFSHandler(txtSource.Text, txtImagePic.Text, (string)comboCategories.SelectedItem,
                                        txtCdName.Text, txtCdDescription.Text, filterExInfo, filterSettings, (int)upDownSearchDepth.Value);

            if (fsToVFSHandler.Start())
                this.DialogResult = DialogResult.OK;
            else
            {
                this.Enabled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DriveInfo drvInfo;
            folderBrowser.Description = "Select a source for this image.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                drvInfo = new DriveInfo(folderBrowser.SelectedPath);
                if (drvInfo.IsReady)
                {
                    txtSource.Text = folderBrowser.SelectedPath;
                    if (folderBrowser.SelectedPath.EndsWith("\\"))
                        txtCdName.Text = drvInfo.VolumeLabel;
                    else
                        txtCdName.Text = folderBrowser.SelectedPath.Substring(folderBrowser.SelectedPath.LastIndexOf("\\")+1);
                }
                else
                {
                    MessageBox.Show(Resources.msgImageSourceNotReady, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            fileBrowser.Title = "Select image";
            fileBrowser.Filter = "Jpeg Images (*.jpg)|*.jpg|Bitmap Images (*.bmp)|*.bmp|Gif Images (*.gif)|*.gif";
            if (fileBrowser.ShowDialog() == DialogResult.OK)
                txtImagePic.Text = fileBrowser.FileName;
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            ImageCategory tempImageCategory;
            WndEditImageCategory wndNewCategory = new WndEditImageCategory("Create new image category", new ImageCategory());

            tempImageCategory = wndNewCategory.ShowDialog();

            if (wndNewCategory.DialogResult == DialogResult.OK)
            {
                CategoryManager.AddCategory(tempImageCategory);
                comboCategories.Items.Add(tempImageCategory.categoryName);
                comboCategories.SelectedIndex = comboCategories.Items.Count - 1;
                wndNewCategory.Dispose();
                refresh = true;
            }
        }

        private void chkCopyAdvancedFileInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCopyExtendedFileInfo.Checked)
                grpExtendedFileInfo.Enabled = true;
            else
                grpExtendedFileInfo.Enabled = false;
        }

        private void txtCdName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\\' || e.KeyChar == '"')
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private void btnAddFileToExclusions_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();

            fileBrowser.AddExtension = false;
            fileBrowser.CheckFileExists = true;
            fileBrowser.CheckPathExists = true;
            fileBrowser.Filter = "All files (*.*)|*.*";
            fileBrowser.FilterIndex = 0;
            fileBrowser.InitialDirectory = txtSource.Text;
            fileBrowser.Multiselect = true;
            fileBrowser.RestoreDirectory = true;
            fileBrowser.SupportMultiDottedExtensions = true;
            fileBrowser.Title = "Select files to exclude";
            fileBrowser.ValidateNames = true;

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                lstExcludedFiles.Items.AddRange(fileBrowser.FileNames);
            }
        }

        private void btnRemoveFileFromExclusions_Click(object sender, EventArgs e)
        {
            foreach (int index in lstExcludedFiles.SelectedIndices)
                lstExcludedFiles.Items.RemoveAt(index);
        }

        private void btnClearExcludedFiles_Click(object sender, EventArgs e)
        {
            lstExcludedFiles.Items.Clear();
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar)))
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private void btnAddFolderToExclusions_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.Description = "Select the folders that you would like to be excluded from the image.";
            dlg.ShowNewFolderButton = false;

            if (dlg.ShowDialog() == DialogResult.OK)
                lstExcludedDirectories.Items.Add(dlg.SelectedPath);
        }

        private void btnRemoveFolderFromExclusions_Click(object sender, EventArgs e)
        {
            foreach (int selectedIndex in lstExcludedDirectories.SelectedIndices)
                lstExcludedDirectories.Items.RemoveAt(selectedIndex);
        }

        private void btnClearExcludedFoldersList_Click(object sender, EventArgs e)
        {
            lstExcludedDirectories.Items.Clear();
        }
    }
}