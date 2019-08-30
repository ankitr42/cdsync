using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Registry_Manager;
using Virtual_File_System_Library;

namespace CD_Sync_Portable
{
    internal partial class WndImageProperties : Form
    {
        private ImageProperties imageProperties;

        public WndImageProperties(ImageProperties ip)
        {
            InitializeComponent();

            imageProperties = ip;
        }

        public new ListEntry ShowDialog()
        {
            FileInfo tempFileInfo = new FileInfo(Path.Combine(AppSettingsManager.ImagesDirectory, imageProperties.imageEntry.imageDbPath));

            foreach (ImageCategory category in imageProperties.imageCategories)
                comboImageCategory.Items.Add(category.categoryName);

            comboImageCategory.Items.Add("");

            this.Text = imageProperties.imageEntry.imageName + " - Image Properties";

            txtImageName.Text = imageProperties.imageEntry.imageName;
            txtImageDescription.Text = imageProperties.imageEntry.imageDescription;
            comboImageCategory.SelectedItem = imageProperties.imageEntry.imageCategory;

            try
            {
                // Add code to display proper error messages if the picture doesn't exist or there's some error accessing it.
                if (imageProperties.imageEntry.imagePicture != "" && imageProperties.imageEntry.imagePicture != null)
                {
                    FileStream stream = File.Open(Path.Combine(AppSettingsManager.ImagesDirectory, imageProperties.imageEntry.imagePicture), FileMode.Open);
                    pBoxImagePicture.Image = Image.FromStream(stream);
                    btnRemovePicture.Enabled = true;
                    stream.Close();
                }
            }
            catch
            {
                MessageBox.Show("The picture file " + imageProperties.imageEntry.imagePicture + " could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtImageSource.Text = imageProperties.imageEntry.imageSourcePath;

            lblSourceDriveType.Text = ((DriveType)imageProperties.imageEntry.imageSourceDriveType).ToString();
            lblSourceFileSystem.Text = imageProperties.imageEntry.imageSourceFileSystem;
            lblSourceVolumeLabel.Text = imageProperties.imageEntry.imageSourceVolLabel;
            lblImageDbFileName.Text = imageProperties.imageEntry.imageDbPath;

            lblTotalDirectories.Text = imageProperties.totalDirs.ToString();
            lblTotalFiles.Text = imageProperties.totalFiles.ToString();

            lblImageDbSize.Text = GeneralMethods.GetFormattedSize((UInt64)tempFileInfo.Length);

            lblImageCreated.Text = tempFileInfo.CreationTime.ToLongDateString() + " " + tempFileInfo.CreationTime.ToShortTimeString();
            lblImageAccessed.Text = tempFileInfo.LastAccessTime.ToLongDateString() + " " + tempFileInfo.LastAccessTime.ToShortTimeString();
            lblImageModified.Text = tempFileInfo.LastWriteTime.ToLongDateString() + " " + tempFileInfo.LastWriteTime.ToShortTimeString();

            base.ShowDialog();
            return imageProperties.imageEntry.Clone();
        }

        #region Event handlers
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtImageName.Text.Length == 0)
            {
                MessageBox.Show(Properties.Resources.msgImageNameEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            imageProperties.imageEntry.imageName = txtImageName.Text;
            imageProperties.imageEntry.imageDescription = txtImageDescription.Text;
            if ((string)comboImageCategory.SelectedItem != null)
                imageProperties.imageEntry.imageCategory = (string)comboImageCategory.SelectedItem;
            imageProperties.imageEntry.imageSourcePath = txtImageSource.Text;
            imageProperties.imageEntry.imageSourceFileSystem = lblSourceFileSystem.Text;
            imageProperties.imageEntry.imageSourceVolLabel = lblSourceVolumeLabel.Text;

            this.DialogResult = DialogResult.OK;
        }
        private void btnNewPicture_Click(object sender, EventArgs e)
        {
            dlgFileBrowser.Title = "Select Picture";
            dlgFileBrowser.Filter = "All Images (*.jpeg, *.jpg, *.bmp, *.gif, *.png)|*.jpeg;*.jpg;*.bmp;*.gif;*.png|JPEG Images (*.jpeg)|*.jpeg|JPG Images (*.jpg)|*.jpg|Bitmap Images (*.bmp)|*.bmp|GIF Images (*.gif)|*.gif|PNG Images (*.png)|*.png";
            if (dlgFileBrowser.ShowDialog() == DialogResult.OK)
            {
                imageProperties.imageEntry.imagePicture = dlgFileBrowser.FileName;
                if (pBoxImagePicture.Image != null)
                    pBoxImagePicture.Image.Dispose();
                pBoxImagePicture.Image = Image.FromFile(imageProperties.imageEntry.imagePicture);
                btnRemovePicture.Enabled = true;
            }
        }
        private void btnChangeImageSource_Click(object sender, EventArgs e)
        {
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                DriveInfo drvInfo = new DriveInfo(dlgFolderBrowser.SelectedPath);

                if (!drvInfo.IsReady)
                {
                    MessageBox.Show(Properties.Resources.msgImageSourceNotReady, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtImageSource.Text = dlgFolderBrowser.SelectedPath;
                lblSourceDriveType.Text = drvInfo.DriveType.ToString();
                lblSourceFileSystem.Text = drvInfo.DriveFormat;
                lblSourceVolumeLabel.Text = drvInfo.VolumeLabel;
                imageProperties.imageEntry.imageSourceDriveType = (Byte)drvInfo.DriveType;
            }
        }
        private void btnRemovePicture_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.promptAreYouSure, "Question.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                imageProperties.imageEntry.imagePicture = "";
                pBoxImagePicture.Image = null;
                btnRemovePicture.Enabled = false;
            }
        }
        
        #endregion

        #region Miscellaneous code

        private bool GetThumbnailAbort()
        {
            return false;
        }
        private string GetFormattedSize(string filePath)
        {
            string[] conventions = { " Bytes", " KBytes", " MBytes", " GBytes", " TBytes", " PBytes" };
            int index=0;
            UInt64 sizeInBytes;

            sizeInBytes = (UInt64)new FileInfo(filePath).Length;
            while(sizeInBytes >= 1024)
            {
                sizeInBytes /= 1024;
                index++;
            }

            return (Math.Round((double)sizeInBytes, 4).ToString() + conventions[index]);
        }

        #endregion
    }

    internal class ImageProperties
    {
        public List<ImageCategory> imageCategories;
        public ListEntry imageEntry;
        public UInt32 totalDirs;
        public UInt32 totalFiles;
    }
}