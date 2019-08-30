using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CD_Sync_Portable.Properties;

namespace CD_Sync_Portable
{
    internal partial class WndApplicationOptions : Form
    {
        public WndApplicationOptions()
        {
            InitializeComponent();
        }

        private void WndApplicationOptions_Load(object sender, EventArgs e)
        {
            txtImagesDirectory.Text = AppSettingsManager.ImagesDirectory;

            if (Path.IsPathRooted(AppSettingsManager.DefaultBackupPath))
                txtDefaultBackupPath.Text = AppSettingsManager.DefaultBackupPath;
            else
                txtDefaultBackupPath.Text = Application.StartupPath + "\\" + AppSettingsManager.DefaultBackupPath;

            if (Path.IsPathRooted(AppSettingsManager.DefaultRestorePath))
                txtDefaultRestorePath.Text = AppSettingsManager.DefaultRestorePath;
            else
                txtDefaultRestorePath.Text = Application.StartupPath + "\\" + AppSettingsManager.DefaultRestorePath;

            chkNotifyOfImagesInDeletedCategories.Checked = AppSettingsManager.NotifyOfImagesInDeletedCategories;
            
            chkHideArchive.Checked = AppSettingsManager.HideArchive;
            chkHideReadOnly.Checked = AppSettingsManager.HideReadOnly;
            chkHideHidden.Checked = AppSettingsManager.HideHidden;
            chkHideSystem.Checked = AppSettingsManager.HideSystem;
            chkHideCompressed.Checked = AppSettingsManager.HideCompressed;
            chkHideEncrypted.Checked = AppSettingsManager.HideEncrypted;

            chkNotifyOfInvisibleObjects.Checked = AppSettingsManager.NotifyOfInvisibleObjects;
            chkShowFileExtensions.Checked = AppSettingsManager.ShowExtensions;
            chkShowHiddenWithDistinctRepresentation.Checked = AppSettingsManager.ShowHiddenWithDistinctRepresentation;
            chkShowObjectDetailsOnBottomPanel.Checked = AppSettingsManager.ShowObjectDetailsOnBottomPanel;
            chkShowExtendedPropertiesPanel.Checked = AppSettingsManager.ShowExtendedPropertiesPanel;
            chkAutoPlayVideos.Checked = AppSettingsManager.AutoPlayVideos;
            chkAutoplayAudios.Checked = AppSettingsManager.AutoPlayAudios;
            if (!chkShowExtendedPropertiesPanel.Checked)
            {
                chkAutoPlayVideos.Enabled = false;
                chkAutoplayAudios.Enabled = false;
            }

            panelSampleColor.BackColor = AppSettingsManager.SpecialIconTextColor;
            colorChooserDialog.Color = AppSettingsManager.SpecialIconTextColor;

            chkShowAccessedDate.Checked = AppSettingsManager.ShowAccessedDateColumn;
            chkShowAlbum.Checked = AppSettingsManager.ShowAlbumColumn;
            chkShowAlbumYear.Checked = AppSettingsManager.ShowAlbumYearColumn;
            chkShowArtist.Checked = AppSettingsManager.ShowArtistColumn;
            chkShowAttributes.Checked = AppSettingsManager.ShowAttributesColumn;
            chkShowAuthor.Checked = AppSettingsManager.ShowAuthorColumn;
            chkShowBitrate.Checked = AppSettingsManager.ShowBitrateColumn;
            chkShowCategory.Checked = AppSettingsManager.ShowCategoryColumn;
            chkShowComments.Checked = AppSettingsManager.ShowCommentsColumn;
            chkShowCompany.Checked = AppSettingsManager.ShowCompanyColumn;
            chkShowCopyright.Checked = AppSettingsManager.ShowCopyrightColumn;
            chkShowCreatedDate.Checked = AppSettingsManager.ShowCreatedDateColumn;
            chkShowDescription.Checked = AppSettingsManager.ShowDescriptionColumn;
            chkShowDimensions.Checked = AppSettingsManager.ShowDimensionsColumn;
            chkShowDuration.Checked = AppSettingsManager.ShowDurationColumn;
            //chkShowFrameRate.Checked = AppSettingsManager.ShowFrameRateColumn;
            chkShowGenre.Checked = AppSettingsManager.ShowGenreColumn;
            chkShowModifiedDate.Checked = AppSettingsManager.ShowModifiedDateColumn;
            //chkShowOwner.Checked = AppSettingsManager.ShowOwnerColumn;
            chkShowPages.Checked = AppSettingsManager.ShowPagesColumn;
            chkShowProductName.Checked = AppSettingsManager.ShowProductNameColumn;
            chkShowProductVersion.Checked = AppSettingsManager.ShowPVersionColumn;
            chkShowSampleRate.Checked = AppSettingsManager.ShowSampleRateColumn;
            chkShowSize.Checked = AppSettingsManager.ShowSizeColumn;
            chkShowSubject.Checked = AppSettingsManager.ShowSubjectColumn;
            chkShowTitle.Checked = AppSettingsManager.ShowTitleColumn;
            chkShowTrackNumber.Checked = AppSettingsManager.ShowTrackNoColumn;
            chkShowVersion.Checked = AppSettingsManager.ShowVersionColumn;
            chkShowItemType.Checked = AppSettingsManager.ShowItemTypeColumn;
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            if (colorChooserDialog.ShowDialog() == DialogResult.OK)
                panelSampleColor.BackColor = colorChooserDialog.Color;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtImagesDirectory.Text))
            {
                MessageBox.Show(Resources.msgImagesDirectoryInvalid, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // AppSettingsManager.ImagesDirectory = txtImagesDirectory.Text;
            AppSettingsManager.DefaultBackupPath = txtDefaultBackupPath.Text;
            AppSettingsManager.DefaultRestorePath = txtDefaultRestorePath.Text;

            AppSettingsManager.NotifyOfImagesInDeletedCategories = chkNotifyOfImagesInDeletedCategories.Checked;

            AppSettingsManager.HideArchive = chkHideArchive.Checked;
            AppSettingsManager.HideReadOnly = chkHideReadOnly.Checked;
            AppSettingsManager.HideHidden = chkHideHidden.Checked;
            AppSettingsManager.HideSystem = chkHideSystem.Checked;
            AppSettingsManager.HideCompressed = chkHideCompressed.Checked;
            AppSettingsManager.HideEncrypted = chkHideEncrypted.Checked;

            AppSettingsManager.NotifyOfInvisibleObjects = chkNotifyOfInvisibleObjects.Checked;
            AppSettingsManager.ShowExtensions = chkShowFileExtensions.Checked;
            AppSettingsManager.ShowHiddenWithDistinctRepresentation = chkShowHiddenWithDistinctRepresentation.Checked;
            AppSettingsManager.ShowObjectDetailsOnBottomPanel = chkShowObjectDetailsOnBottomPanel.Checked;
            AppSettingsManager.ShowExtendedPropertiesPanel = chkShowExtendedPropertiesPanel.Checked;
            AppSettingsManager.AutoPlayVideos = chkAutoPlayVideos.Checked;
            AppSettingsManager.AutoPlayAudios = chkAutoplayAudios.Checked;

            AppSettingsManager.SpecialIconTextColor = panelSampleColor.BackColor;

            AppSettingsManager.ShowAccessedDateColumn = chkShowAccessedDate.Checked;
            AppSettingsManager.ShowAlbumColumn = chkShowAlbum.Checked;
            AppSettingsManager.ShowAlbumYearColumn = chkShowAlbumYear.Checked;
            AppSettingsManager.ShowArtistColumn = chkShowArtist.Checked;
            AppSettingsManager.ShowAttributesColumn = chkShowAttributes.Checked;
            AppSettingsManager.ShowAuthorColumn = chkShowAuthor.Checked;
            AppSettingsManager.ShowBitrateColumn = chkShowBitrate.Checked;
            AppSettingsManager.ShowCategoryColumn = chkShowCategory.Checked;
            AppSettingsManager.ShowCommentsColumn = chkShowComments.Checked;
            AppSettingsManager.ShowCompanyColumn = chkShowCompany.Checked;
            AppSettingsManager.ShowCopyrightColumn = chkShowCopyright.Checked;
            AppSettingsManager.ShowCreatedDateColumn = chkShowCreatedDate.Checked;
            AppSettingsManager.ShowDescriptionColumn = chkShowDescription.Checked;
            AppSettingsManager.ShowDimensionsColumn = chkShowDimensions.Checked;
            AppSettingsManager.ShowDurationColumn = chkShowDuration.Checked;
            //AppSettingsManager.ShowFrameRateColumn = chkShowFrameRate.Checked;
            AppSettingsManager.ShowGenreColumn = chkShowGenre.Checked;
            AppSettingsManager.ShowModifiedDateColumn = chkShowModifiedDate.Checked;
            //AppSettingsManager.ShowOwnerColumn = chkShowOwner.Checked;
            AppSettingsManager.ShowPagesColumn = chkShowPages.Checked;
            AppSettingsManager.ShowProductNameColumn = chkShowProductName.Checked;
            AppSettingsManager.ShowPVersionColumn = chkShowProductVersion.Checked;
            AppSettingsManager.ShowSampleRateColumn = chkShowSampleRate.Checked;
            AppSettingsManager.ShowSizeColumn = chkShowSize.Checked;
            AppSettingsManager.ShowSubjectColumn = chkShowSubject.Checked;
            AppSettingsManager.ShowTitleColumn = chkShowTitle.Checked;
            AppSettingsManager.ShowTrackNoColumn = chkShowTrackNumber.Checked;
            AppSettingsManager.ShowVersionColumn = chkShowVersion.Checked;
            AppSettingsManager.ShowItemTypeColumn = chkShowItemType.Checked;

            AppSettingsManager.UpdateSettings();

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void chkShowExtendedPropertiesPanel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowExtendedPropertiesPanel.Checked)
            {
                chkAutoPlayVideos.Enabled = true;
                chkAutoplayAudios.Enabled = true;
            }
            else
            {
                chkAutoPlayVideos.Enabled = false;
                chkAutoplayAudios.Enabled = false;
            }
        }

        private void chkSelectAllFileProps_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAllFileProps.Checked)
            {
                chkShowItemType.Checked = true;
                chkShowSize.Checked = true;
                chkShowAttributes.Checked = true;
                chkShowCreatedDate.Checked = true;
                chkShowAccessedDate.Checked = true;
                chkShowModifiedDate.Checked = true;
                chkShowDescription.Checked = true;
                chkShowVersion.Checked = true;
                chkShowProductName.Checked = true;
                chkShowProductVersion.Checked = true;
            }
            else
            {
                chkShowItemType.Checked = false;
                chkShowSize.Checked = false;
                chkShowAttributes.Checked = false;
                chkShowCreatedDate.Checked = false;
                chkShowAccessedDate.Checked = false;
                chkShowModifiedDate.Checked = false;
                chkShowDescription.Checked = false;
                chkShowVersion.Checked = false;
                chkShowProductName.Checked = false;
                chkShowProductVersion.Checked = false;
            }
        }

        private void chkSelectAllAVProps_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAllAVProps.Checked)
            {
                chkShowArtist.Checked = true;
                chkShowAlbum.Checked = true;
                chkShowAlbumYear.Checked = true;
                chkShowTrackNumber.Checked = true;
                chkShowDuration.Checked = true;
                chkShowGenre.Checked = true;
                chkShowBitrate.Checked = true;
                chkShowSampleRate.Checked = true;
                chkShowDimensions.Checked = true;
            }
            else
            {
                chkShowArtist.Checked = false;
                chkShowAlbum.Checked = false;
                chkShowAlbumYear.Checked = false;
                chkShowTrackNumber.Checked = false;
                chkShowDuration.Checked = false;
                chkShowGenre.Checked = false;
                chkShowBitrate.Checked = false;
                chkShowSampleRate.Checked = false;
                chkShowDimensions.Checked = false;
            }
        }

        private void chkSelectAllDocProps_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAllDocProps.Checked)
            {
                chkShowAuthor.Checked = true;
                chkShowTitle.Checked = true;
                chkShowSubject.Checked = true;
                chkShowCategory.Checked = true;
                chkShowPages.Checked = true;
                chkShowComments.Checked = true;
                chkShowCopyright.Checked = true;
                chkShowCompany.Checked = true;
            }
            else
            {
                chkShowAuthor.Checked = false;
                chkShowTitle.Checked = false;
                chkShowSubject.Checked = false;
                chkShowCategory.Checked = false;
                chkShowPages.Checked = false;
                chkShowComments.Checked = false;
                chkShowCopyright.Checked = false;
                chkShowCompany.Checked = false;
            }
        }

        private void btnBrowseDirForBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select default backup path.";
            dlg.ShowNewFolderButton = true;
            if (dlg.ShowDialog() == DialogResult.OK)
                txtDefaultBackupPath.Text = dlg.SelectedPath;
        }

        private void btnBrowseDirForRestore_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select default restore path.";
            dlg.ShowNewFolderButton = true;
            if (dlg.ShowDialog() == DialogResult.OK)
                txtDefaultRestorePath.Text = dlg.SelectedPath;
        }
    }
}