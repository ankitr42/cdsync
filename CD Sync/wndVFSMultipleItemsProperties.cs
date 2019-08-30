using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Virtual_File_System_Library;

namespace CD_Sync_Portable
{
    internal partial class WndVFSMultipleItemsProperties : Form
    {
        private UInt32 totalFiles, totalDirs;
        private UInt64 totalSize;
        private VFS virtualFS;
        private VFSEntry vfsEntry;
        private ListView.SelectedListViewItemCollection selectedItems;
        private Queue<UInt32> parentEntries;
        private Thread formUpdaterThread;
        private FileTypeManager fTypeManager;
        private bool changed;

        public WndVFSMultipleItemsProperties(VFS virtualFS, ListView.SelectedListViewItemCollection selectedItems, string fullPath, FileTypeManager fTypeManager)
        {
            InitializeComponent();

            totalFiles = totalDirs = 0;
            totalSize = 0;
            this.virtualFS = virtualFS;
            this.selectedItems = selectedItems;
            lblLocation.Text = fullPath;
            this.fTypeManager = fTypeManager;
            parentEntries = new Queue<uint>();
            pBoxItemIcon.Image = IconFunctions.ExtractStandardIcon(StandardIcons.IconMultipleTypes).ToBitmap();
        }

        private void wndVFSMultipleItemsProperties_Load(object sender, EventArgs e)
        {
            bool multipleTypes = false, multiplePrograms = false;
            string typeString = "", openWithString = "";
            FileTypeInfo fTypeInfo;

            formUpdaterThread = new Thread(new ThreadStart(_ThreadFormUpdater));

            foreach (ExtendedListViewItem item in selectedItems)
            {
                vfsEntry = item.ItemVFSEntry;
                if (!(multipleTypes && multiplePrograms))
                {
                    fTypeInfo = (vfsEntry.isDir) ? fTypeManager.GetFileTypeInfo("*dir") : fTypeManager.GetFileTypeInfo(Path.GetExtension(vfsEntry.name));
                    try
                    {
                        if (!multipleTypes && typeString.Length > 0 && String.Compare(typeString, fTypeInfo.typeName, true) != 0)
                        {
                            typeString = "Multiple types.";
                            multipleTypes = true;
                        }
                        else if (!multipleTypes)
                            typeString = fTypeInfo.typeName;

                        if (!multiplePrograms && openWithString.Length > 0 && String.Compare(openWithString, fTypeInfo.opensWithName, true) != 0)
                        {
                            openWithString = "Multiple programs.";
                            multiplePrograms = true;
                        }
                        else if (!multiplePrograms)
                            openWithString = fTypeInfo.opensWithName;
                    }
                    catch
                    {
                    }
                }
                if (vfsEntry.isDir)
                {
                    parentEntries.Enqueue(vfsEntry.entryNo);
                    totalDirs++;
                }
                else
                {
                    totalFiles++;
                    totalSize += vfsEntry.size;
                }
            }

            
            lblTotalItems.Text = totalFiles.ToString() + " Files";
            lblTotalItems.Text += "and, " + totalDirs.ToString() + " Folders selected";

            lblItemType.Text = (multipleTypes) ? typeString : "All of type " + typeString;
            txtOpensWithName.Text = openWithString;

            lblSize.Text = GeneralMethods.GetFormattedSize(totalSize);
            changed = true;
            tmrUpdateForm.Start();
            formUpdaterThread.Start();
        }

        private void _ThreadFormUpdater()
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
                totalDirs++;
                parentEntries.Enqueue(entry.entryNo);
            }
            else
            {
                totalFiles++;
                totalSize += entry.size;
            }
        }

        private void tmrUpdateForm_Tick(object sender, EventArgs e)
        {
            if (changed)
            {
                lblTotalItems.Text = totalFiles.ToString() + " Files, " + totalDirs.ToString() + " Folders";
                lblSize.Text = GeneralMethods.GetFormattedSize(totalSize);
                changed = false;
            }
        }

        private void wndVFSMultipleItemsProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formUpdaterThread.IsAlive)
                formUpdaterThread.Abort();

            tmrUpdateForm.Stop();
        }
    }
}