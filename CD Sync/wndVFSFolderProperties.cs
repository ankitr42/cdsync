using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Virtual_File_System_Library;

namespace CD_Sync_Portable
{
    internal partial class WndVFSFolderProperties : Form
    {
        private VFS virtualFS;
        private UInt32 totalFiles, totalSubDirs;
        private VFSEntry rootVFSEntry;
        private FileTypeInfo fileTypeInfo;
        private UInt64 totalSize;
        private Thread formUpdaterThread;
        private bool changed;
        private Queue<UInt32> parentEntries;

        public WndVFSFolderProperties(FileTypeInfo typeInfo, VFS virtualFS, VFSEntry rootEntry)
        {
            InitializeComponent();

            fileTypeInfo = typeInfo;
            this.virtualFS = virtualFS;
            rootVFSEntry = rootEntry;
            totalFiles = 0;
            totalSubDirs = 0;
            parentEntries = new Queue<uint>();
            changed = true;
        }

        private void wndVFSFolderProperties_Load(object sender, EventArgs e)
        {
            formUpdaterThread = new Thread(new ThreadStart(_VFSDirectoryTreeTraverser));
            this.Text = rootVFSEntry.name + " - Properties";

            if (fileTypeInfo.largeIcon != null)
            {
                this.Icon = fileTypeInfo.smallIcon;
                pBoxItemIcon.Image = fileTypeInfo.largeIcon.ToBitmap();
            }
            txtFolderName.Text = rootVFSEntry.name;

            lblItemType.Text = fileTypeInfo.typeName;
            txtLocation.Text = virtualFS.GetPathFromList(virtualFS.TracePathToEntry((uint)rootVFSEntry.parentDir));

            lblFolderSize.Text = "Estimating...";
            lblFolderContents.Text = "Searching...";
            parentEntries.Enqueue(rootVFSEntry.entryNo);
            tmrFormUpdate.Start();
            formUpdaterThread.Start();

            if (rootVFSEntry.created.Year < 1800)
                lblFolderAccessed.Text = "N/A";
            else
                lblFolderCreated.Text = rootVFSEntry.created.ToLongDateString() + " " + rootVFSEntry.created.ToShortTimeString();
            if (rootVFSEntry.modified.Year < 1800)
                lblFolderModified.Text = "N/A";
            else
                lblFolderModified.Text = rootVFSEntry.modified.ToLongDateString() + " " + rootVFSEntry.modified.ToShortTimeString();
            if (rootVFSEntry.accessed.Year < 1800)
                lblFolderAccessed.Text = "N/A";
            else
                lblFolderAccessed.Text = rootVFSEntry.accessed.ToLongDateString() + " " + rootVFSEntry.accessed.ToShortTimeString();

            chkItemAttrROnly.Checked = rootVFSEntry.isROnly;
            chkItemAttrHidden.Checked = rootVFSEntry.isHidden;
            chkItemAttrArchive.Checked = rootVFSEntry.isArch;
            chkItemAttrSystem.Checked = rootVFSEntry.isSystem;
            chkItemAttrCompressed.Checked = rootVFSEntry.isCompressed;
            chkItemAttrEncrypted.Checked = rootVFSEntry.isEncrypted;
        }

        private void _VFSDirectoryTreeTraverser()
        {
            VFSEntryProcessorDelegate tempDelegate = new VFSEntryProcessorDelegate(VFSEntryProcessor);

            while (parentEntries.Count > 0)
                virtualFS.ReadSubEntries(parentEntries.Dequeue(), tempDelegate);
        }

        private void VFSEntryProcessor(VFSEntry entry)
        {
            changed = true;
            if (entry.isDir)
            {
                totalSubDirs++;
                parentEntries.Enqueue(entry.entryNo);
            }
            else
            {
                totalFiles++;
                totalSize += entry.size;
            }
        }

        private void wndVFSFolderProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formUpdaterThread.ThreadState == ThreadState.Running)
                formUpdaterThread.Abort();
        }

        private void tmrFormUpdate_Tick(object sender, EventArgs e)
        {
            if (changed)
            {
                lblFolderSize.Text = GeneralMethods.GetFormattedSize(totalSize);
                lblFolderContents.Text = totalFiles.ToString() + " Files, " + totalSubDirs.ToString() + " Folders";
                changed = false;
            }
        }
    }
}