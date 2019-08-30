using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Virtual_File_System_Library;

namespace CD_Sync_Portable
{
    internal partial class WndVFSFileProperties : Form
    {
        private VFSEntry vfsEntry;
        private FileTypeInfo fileTypeInfo;
        private string fullPath;
        private Icon tempIcon;

        public WndVFSFileProperties(VFSEntry vfsEntry, FileTypeInfo fileTypeInfo, string fullPath)
        {
            InitializeComponent();

            this.vfsEntry = vfsEntry;
            this.fileTypeInfo = fileTypeInfo;
            this.fullPath = fullPath;
        }

        private void wndVFSFileProperties_Load(object sender, EventArgs e)
        {
            this.Text = vfsEntry.name + " - Properties";

            if (fileTypeInfo.largeIcon != null)
                pBoxItemIcon.Image = fileTypeInfo.largeIcon.ToBitmap();
            if (fileTypeInfo.smallIcon != null)
                this.Icon = fileTypeInfo.smallIcon;
            txtFileName.Text = vfsEntry.name;

            lblFileType.Text = fileTypeInfo.typeName;
            tempIcon = IconFunctions.ExtractSingleIcon(fileTypeInfo.opensWithPath);
            if (tempIcon != null)
                pBoxOpensWithIcon.Image = tempIcon.ToBitmap();
            else
                txtOpensWithName.Location = new Point(txtFileLocation.Location.X, txtOpensWithName.Location.Y);
            if (fileTypeInfo.opensWithName == null || fileTypeInfo.opensWithName == String.Empty)
            {
                if (fileTypeInfo.opensWithPath == null || fileTypeInfo.opensWithPath == String.Empty)
                    txtOpensWithName.Text = "Unknown Application";
                else
                    txtOpensWithName.Text = fileTypeInfo.opensWithPath;
            }
            else
                txtOpensWithName.Text = fileTypeInfo.opensWithName;

            txtFileLocation.Text = fullPath;
            lblFileSize.Text = GeneralMethods.GetFormattedSize(vfsEntry.size);

            if (vfsEntry.created.Year < 1800)
                lblFileAccessed.Text = "N/A";
            else
                lblFileCreated.Text = vfsEntry.created.ToLongDateString() + " " + vfsEntry.created.ToShortTimeString();
            if (vfsEntry.modified.Year < 1800)
                lblFileModified.Text = "N/A";
            else
                lblFileModified.Text = vfsEntry.modified.ToLongDateString() + " " + vfsEntry.modified.ToShortTimeString();
            if (vfsEntry.accessed.Year < 1800)
                lblFileAccessed.Text = "N/A";
            else
                lblFileAccessed.Text = vfsEntry.accessed.ToLongDateString() + " " + vfsEntry.accessed.ToShortTimeString();

            chkItemAttrROnly.Checked = vfsEntry.isROnly;
            chkItemAttrHidden.Checked = vfsEntry.isHidden;
            chkItemAttrArchive.Checked = vfsEntry.isArch;
            chkItemAttrSystem.Checked = vfsEntry.isSystem;
            chkItemAttrCompressed.Checked = vfsEntry.isCompressed;
            chkItemAttrEncrypted.Checked = vfsEntry.isEncrypted;

            // Fill in advanced properties tab.
            lViewExtendedProperties.BeginUpdate();
            GeneralMethods.GetGeneralFileProperties(vfsEntry, lViewExtendedProperties, 0);
            if (GeneralMethods.IsFileTypeAudio(vfsEntry.name))
            {
                // Music Properties
                GeneralMethods.GetMusicProperties(vfsEntry, lViewExtendedProperties, 1);

                // Audio Properties
                GeneralMethods.GetAudioProperties(vfsEntry, lViewExtendedProperties, 2);
            }
            else if (GeneralMethods.IsFileTypeVideo(vfsEntry.name))
            {
                GeneralMethods.GetVideoProperties(vfsEntry, lViewExtendedProperties, 3);
            }
            else if (GeneralMethods.IsFileTypeImage(vfsEntry.name))
            {
                GeneralMethods.GetImageProperties(vfsEntry, lViewExtendedProperties, 4);
            }
            else if (GeneralMethods.IsFileTypeDocument(vfsEntry.name))
            {
                GeneralMethods.GetDocumentProperties(vfsEntry, lViewExtendedProperties, 5);
            }
            lViewExtendedProperties.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lViewExtendedProperties.EndUpdate();

            if (lViewExtendedProperties.Items.Count == 0)
            {
                lViewExtendedProperties.View = View.List;
                lViewExtendedProperties.Items.Add("No extended properties are available for this file.");
            }
        }
    }

    internal enum VFSItemSelectionType
    {
        SingleFile = 1, SingleFolder, MultipleItems = 4
    };
}