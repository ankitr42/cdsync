using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Virtual_File_System_Library;
using CD_Sync_Portable.Properties;

namespace CD_Sync_Portable
{
    public partial class WndSearchResults : Form
    {
        private WndBasicSearch wndBasicSearch;
        private WndAdvancedSearch wndAdvancedSearch;
        private FileTypeManager fTypeManager;
        private List<ListEntry> allImages;
        
        private UInt64 selectionSize;
        
        private bool multiSelectionIconSet;

        // Variables used by the background db searcher component.
        private List<VFSSearchTerm> termsToSearch;
        private List<ListEntry> imagesToSearch;
        private VFSSearchOptions searchOptions;

        public WndSearchResults(uint currentImageID)
        {
            InitializeComponent();

            lViewSResultsBrowser.LargeImageList = new ImageList();
            lViewSResultsBrowser.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
            lViewSResultsBrowser.LargeImageList.ImageSize = new Size(32, 32);

            lViewSResultsBrowser.SmallImageList = new ImageList();
            lViewSResultsBrowser.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
            lViewSResultsBrowser.SmallImageList.ImageSize = new Size(16, 16);
            lViewSResultsBrowser.AutoArrange = true;

            allImages = new List<ListEntry>();
            imagesToSearch = new List<ListEntry>();
            ImageListManipulator.ReadAllEntries(ImageListProcessor);
            
            wndBasicSearch = new WndBasicSearch();
            wndBasicSearch.ImagesToSearch = imagesToSearch;
            wndAdvancedSearch = new WndAdvancedSearch();
            wndAdvancedSearch.ImagesToSearch = imagesToSearch;

            ClearExtendedPropertiesPanel();

            AddDetailColumns();
        }

        #region Custom events
        public event EventHandler<ExploreEntryEventArgs> ExploreEntry;
        #endregion

        #region Toolbar events handling code.
        private void toolBtnBasicSearch_Click(object sender, EventArgs e)
        {
            if (bgDatabaseSearcher.IsBusy)
            {
                MessageBox.Show(Resources.msgSearchActive_NewSearch, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //List<uint> list = new List<uint>();
            DialogResult dlgResult;

            //if (imagesToSearch != null)
            //    foreach (ListEntry entry in imagesToSearch)
            //        list.Add(entry.imageID);
            //else
            //    list.Add(currentImageID);

            dlgResult = wndBasicSearch.ShowDialog(null);
            if (dlgResult == DialogResult.OK)
            {
                // Update UI to reflect that a search is active.
                toolBtnStopSearch.Visible = true;

                lViewSResultsBrowser.BeginUpdate();
                lViewSResultsBrowser.Groups.Clear();
                lViewSResultsBrowser.Items.Clear();
                if (toolBtnExtendedProperties.Checked)
                    ClearExtendedPropertiesPanel();
                UpdateStatusBar(null);
                //lViewSResultsBrowser_ItemSelectionChanged(sender, null);
                // -------------------------------------------------------
                
                termsToSearch = wndBasicSearch.SearchTerms;
                //imagesToSearch = wndBasicSearch.ImagesToSearch;
                searchOptions = new VFSSearchOptions();
                bgDatabaseSearcher.RunWorkerAsync();
            }
            else if (dlgResult == DialogResult.Retry)
            {
                toolBtnAdvancedSearch_Click(sender, e);
            }
        }

        private void toolBtnAdvancedSearch_Click(object sender, EventArgs e)
        {
            if (bgDatabaseSearcher.IsBusy)
            {
                MessageBox.Show(Resources.msgSearchActive_NewSearch, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (imagesToSearch != null)
            //    foreach (ListEntry entry in imagesToSearch)
            //        list.Add(entry.imageID);
            //else
            //    list.Add(currentImageID);

            if (wndAdvancedSearch.ShowDialog() == DialogResult.OK)
            {
                // Update UI to reflect that a search is active.
                toolBtnStopSearch.Visible = true;

                lViewSResultsBrowser.BeginUpdate();
                lViewSResultsBrowser.Groups.Clear();
                lViewSResultsBrowser.Items.Clear();
                if (toolBtnExtendedProperties.Checked)
                    ClearExtendedPropertiesPanel();
                UpdateStatusBar(null);
                //lViewSResultsBrowser_ItemSelectionChanged(sender, null);
                // -------------------------------------------------------

                termsToSearch = wndAdvancedSearch.SearchTerms;
                //imagesToSearch = wndAdvancedSearch.ImagesToSearch;
                searchOptions = wndAdvancedSearch.SearchOptions;
                bgDatabaseSearcher.RunWorkerAsync();
            }
        }

        private void toolBtnStopSearch_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.msgAreYouSure, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bgDatabaseSearcher.CancelAsync();
            }
        }

        private void toolBtnOpen_Click(object sender, EventArgs e)
        {
            lViewSResultsBrowser_ItemActivate(sender, e);
        }

        private void toolBtnExplore_Click(object sender, EventArgs e)
        {
            if (ExploreEntry != null)
            {
                ExploreEntry(this, new ExploreEntryEventArgs(((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ParentImageID,
                                                             ((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ItemVFSEntry));
            }
        }

        private void toolBtnSItemProperties_Click(object sender, EventArgs e)
        {
            VFSEntry tempVFSEntry;
            FileTypeInfo tempFileTypeInfo;
            VFS virtualFS = new VFS();

            tempVFSEntry = ((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ItemVFSEntry;
            virtualFS.OpenConnection(Path.Combine(AppSettingsManager.ImagesDirectory, FindListEntryWithID(((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ParentImageID).imageDbPath));
            if (tempVFSEntry.isDir)
            {
                WndVFSFolderProperties wndVFSFolderProp = new WndVFSFolderProperties(fTypeManager.GetFileTypeInfo("*dir"), virtualFS, tempVFSEntry);

                wndVFSFolderProp.ShowDialog();
                wndVFSFolderProp.Dispose();
                virtualFS.CloseConnection(true);
            }
            else
            {
                tempFileTypeInfo = fTypeManager.GetFileTypeInfo(Path.GetExtension(tempVFSEntry.name));
                if (tempFileTypeInfo == null)
                    tempFileTypeInfo = fTypeManager.GetFileTypeInfo("*file");
                if (tempVFSEntry.fileIcon != null)
                    tempFileTypeInfo.largeIcon = IconFunctions.IconFromBytes(tempVFSEntry.fileIcon);
                else if (tempFileTypeInfo.largeIcon == null)
                    tempFileTypeInfo.largeIcon = fTypeManager.GetIconForType("*file", IconSize.IconLarge);

                WndVFSFileProperties wndVFSFileProp = new WndVFSFileProperties(tempVFSEntry, tempFileTypeInfo, txtAddress.Text);

                wndVFSFileProp.ShowDialog();
                wndVFSFileProp.Dispose();
            }
        }

        private void toolBtnExtendedProperties_Click(object sender, EventArgs e)
        {
            if (toolBtnExtendedProperties.Checked)
            {
                toolBtnAutoPlay.Enabled = true;
                viewSplitter1.Panel2Collapsed = false;
                if (lViewSResultsBrowser.SelectedItems.Count > 0)
                    UpdateExtendedPropertiesPanel();
            }
            else
            {
                toolBtnAutoPlay.Enabled = false;
                viewSplitter1.Panel2Collapsed = true;
                ClearExtendedPropertiesPanel();
            }
        }

        private void iconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lViewSResultsBrowser.View = View.LargeIcon;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lViewSResultsBrowser.View = View.List;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lViewSResultsBrowser.View = View.Details;
            lViewSResultsBrowser.BeginUpdate();
            lViewSResultsBrowser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lViewSResultsBrowser.EndUpdate();
        }
        #endregion

        #region BackgroundWorker events handling code
        private void bgDatabaseSearcher_DoWork(object sender, DoWorkEventArgs e)
        {
            VFS virtualFS = new VFS();

            foreach (ListEntry entry in imagesToSearch)
            {
                lViewSResultsBrowser.Groups.Add(entry.imageID.ToString(), entry.imageName);
                
                try
                {
                    virtualFS.OpenConnection(Path.Combine(AppSettingsManager.ImagesDirectory, entry.imageDbPath));
                    foreach (VFSSearchTerm searchTerm in termsToSearch)
                    {
                        virtualFS.SearchVFS(searchTerm, searchOptions, SearchResultProcessor, entry.imageID);
                        if (bgDatabaseSearcher.CancellationPending)
                        {
                            virtualFS.CloseConnection(true);
                            return;
                        }
                    }
                }
                finally
                {
                    virtualFS.CloseConnection(true);
                }
            }
        }

        private void bgDatabaseSearcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.Visible)
            {
                if (lViewSResultsBrowser.View == View.Details)
                    lViewSResultsBrowser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lViewSResultsBrowser.EndUpdate();
                
                toolBtnStopSearch.Visible = false;
                toolBtnOpen.Enabled = false;
                toolBtnExplore.Enabled = false;
                toolBtnSItemProperties.Enabled = false;
                txtAddress.Text = "";
                
                UpdateStatusBar(null);
                if (toolBtnExtendedProperties.Checked)
                    UpdateExtendedPropertiesPanel();
                if (lViewSResultsBrowser.Items.Count == 0)
                    MessageBox.Show(Resources.msgNoSearchResults, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region SearchResultProcessor method
        private bool SearchResultProcessor(VFSSearchResult result)
        {
            string imageKey, tempString;
            Icon iconL, iconS;
            VFSEntry entry = result.entry;
            ExtendedListViewItem tempExtendedListViewItem = new ExtendedListViewItem(ExtendedListViewItemType.ListViewItemTypeSearchResult, entry);

            //if ((AppSettingsManager.HideArchive && entry.isArch) ||
            //    (AppSettingsManager.HideReadOnly && entry.isROnly) ||
            //    (AppSettingsManager.HideHidden && entry.isHidden) ||
            //    (AppSettingsManager.HideSystem && entry.isSystem) ||
            //    (AppSettingsManager.HideCompressed && entry.isCompressed) ||
            //    (AppSettingsManager.HideEncrypted && entry.isEncrypted))
            //{
            //    totalInvisibleObjects++;
            //    return;
            //}

            tempExtendedListViewItem.ParentImageID = (uint)result.userData;
            tempExtendedListViewItem.Group = lViewSResultsBrowser.Groups[((uint)result.userData).ToString()];
            if (entry.isEncrypted || entry.isCompressed)
                tempExtendedListViewItem.ForeColor = AppSettingsManager.SpecialIconTextColor;

            imageKey = Path.GetExtension(entry.name);
            if (entry.isDir)
                imageKey = "*dir";
            else if (entry.fileIcon == null)
                imageKey = (imageKey == null || imageKey == String.Empty) ? "*file" : imageKey;
            else
                imageKey = "*" + entry.entryNo.ToString();

            tempString = imageKey;
            if (entry.fileIcon == null)
            {
                iconL = fTypeManager.GetIconForType(imageKey, IconSize.IconLarge);
                iconS = fTypeManager.GetIconForType(imageKey, IconSize.IconSmall);
            }
            else
            {
                iconL = IconFunctions.IconFromBytes(entry.fileIcon);
                iconS = IconFunctions.IconFromBytes(entry.fileIcon);
            }

            if (iconL == null || iconS == null)
            {
                iconL = fTypeManager.GetIconForType("*file", IconSize.IconLarge);
                iconS = fTypeManager.GetIconForType("*file", IconSize.IconSmall);
            }

            if (AppSettingsManager.ShowHiddenWithDistinctRepresentation && (entry.isHidden || entry.isSystem))
            {
                imageKey = "*" + imageKey + "h";
                if (!lViewSResultsBrowser.LargeImageList.Images.ContainsKey(imageKey))
                {
                    lViewSResultsBrowser.LargeImageList.Images.Add(imageKey, GeneralMethods.SetImageOpacity(iconL.ToBitmap(), (float)0.5));
                    lViewSResultsBrowser.SmallImageList.Images.Add(imageKey, GeneralMethods.SetImageOpacity(iconS.ToBitmap(), (float)0.5));
                }
            }
            else if (!lViewSResultsBrowser.LargeImageList.Images.ContainsKey(imageKey))
            {
                lViewSResultsBrowser.LargeImageList.Images.Add(imageKey, iconL.ToBitmap());
                lViewSResultsBrowser.SmallImageList.Images.Add(imageKey, iconS.ToBitmap());
            }

            if (entry.isDir)
                tempExtendedListViewItem.Text = entry.name;
            else
            {
                if (AppSettingsManager.ShowExtensions)
                    tempExtendedListViewItem.Text = entry.name;
                else
                    tempExtendedListViewItem.Text = Path.GetFileNameWithoutExtension(entry.name);
            }

            tempExtendedListViewItem.ImageKey = imageKey;
            tempExtendedListViewItem.UseItemStyleForSubItems = true;
            tempExtendedListViewItem.FullPath = result.fullPath;
            //tempExtendedListViewItem.ToolTipText += "Type: " + ((entry.isDir) ? "File Folder" : fTypeManager.GetFileTypeInfo(Path.GetExtension(entry.name)).typeName);
            //if (entry.size > 0)
            //    tempExtendedListViewItem.ToolTipText += Environment.NewLine + "Size: " + GeneralMethods.GetFormattedSize(entry.size);

            foreach (ColumnHeader column in lViewSResultsBrowser.Columns)
            {
                if (column.Text == "File Size" && !entry.isDir)
                    tempExtendedListViewItem.SubItems.Add(GeneralMethods.GetFormattedSizeForColumn(entry.size));
                else if (column.Text == "Type")
                {
                    FileTypeInfo typeInfo = entry.isDir ? fTypeManager.GetFileTypeInfo("*dir") :
                                            fTypeManager.GetFileTypeInfo(Path.GetExtension(entry.name));

                    tempExtendedListViewItem.SubItems.Add((typeInfo == null) ? "Unknown" : typeInfo.typeName);
                }
                else if (column.Text == "Date Modified")
                    tempExtendedListViewItem.SubItems.Add(entry.modified.ToString());
                else if (column.Text == "Date Created")
                    tempExtendedListViewItem.SubItems.Add(entry.created.ToString());
                else if (column.Text == "Date Accessed")
                    tempExtendedListViewItem.SubItems.Add(entry.accessed.ToString());
                else if (column.Text == "Attrubutes")
                {
                    string temp = "";
                    temp += (entry.isArch) ? "A" : "";
                    temp += (entry.isROnly) ? "R" : "";
                    temp += (entry.isSystem) ? "S" : "";
                    temp += (entry.isHidden) ? "H" : "";
                    temp += (entry.isCompressed) ? "C" : "";
                    temp += (entry.isEncrypted) ? "E" : "";

                    tempExtendedListViewItem.SubItems.Add(temp);
                }
                //else if (column.Text == "Owner")
                //    tempExtendedListViewItem.SubItems.Add(entry.owner);
                else if (column.Text == "Author")
                    tempExtendedListViewItem.SubItems.Add(entry.author);
                else if (column.Text == "Title")
                    tempExtendedListViewItem.SubItems.Add(entry.title);
                else if (column.Text == "Subject")
                    tempExtendedListViewItem.SubItems.Add(entry.subject);
                else if (column.Text == "Category")
                    tempExtendedListViewItem.SubItems.Add(entry.category);
                else if (column.Text == "Pages" && entry.pages > 0 && !entry.isDir)
                    tempExtendedListViewItem.SubItems.Add(entry.pages.ToString());
                else if (column.Text == "Comments")
                    tempExtendedListViewItem.SubItems.Add(entry.comments);
                else if (column.Text == "Artist")
                    tempExtendedListViewItem.SubItems.Add(entry.artist);
                else if (column.Text == "Album")
                    tempExtendedListViewItem.SubItems.Add(entry.album);
                else if (column.Text == "Album Year" && entry.albumYear > 1500)
                    tempExtendedListViewItem.SubItems.Add(entry.albumYear.ToString());
                else if (column.Text == "Track Number" && entry.trackNo > 0)
                    tempExtendedListViewItem.SubItems.Add(entry.trackNo.ToString());
                else if (column.Text == "Duration" && entry.trackDurtion > 0)
                    tempExtendedListViewItem.SubItems.Add((new TimeSpan(0, 0, (int)entry.trackDurtion)).ToString());
                else if (column.Text == "Genre")
                    tempExtendedListViewItem.SubItems.Add(entry.genre);
                else if (column.Text == "Bitrate" && entry.bitRate > 0)
                    tempExtendedListViewItem.SubItems.Add(GeneralMethods.GetFormattedBitrate(entry.bitRate));
                else if (column.Text == "Sample Rate" && entry.sampleRate > 0)
                    tempExtendedListViewItem.SubItems.Add(entry.sampleRate.ToString() + "Hz");
                //else if (column.Text == "Frame Rate" && entry.frameRate > 0)
                //    tempExtendedListViewItem.SubItems.Add(entry.frameRate.ToString() + " FPS");
                else if (column.Text == "Dimensions" && (entry.width > 0 || entry.height > 0))
                    tempExtendedListViewItem.SubItems.Add(entry.width.ToString() + "x" + entry.height.ToString());
                else if (column.Text == "Company")
                    tempExtendedListViewItem.SubItems.Add(entry.company);
                else if (column.Text == "Description")
                    tempExtendedListViewItem.SubItems.Add(entry.description);
                else if (column.Text == "File Version" && (entry.majorV + entry.minorV + entry.revision) > 0)
                    tempExtendedListViewItem.SubItems.Add(entry.majorV.ToString() + "." +
                        entry.minorV.ToString() + "." + entry.revision.ToString());
                else if (column.Text == "Product Name")
                    tempExtendedListViewItem.SubItems.Add(entry.productName);
                else if (column.Text == "Product Version" && (entry.majorPV + entry.minorPV + entry.pRevision) > 0)
                    tempExtendedListViewItem.SubItems.Add(entry.majorPV.ToString() + "." +
                        entry.minorPV.ToString() + "." + entry.pRevision.ToString());
                else if (column.Text == "Copyright")
                    tempExtendedListViewItem.SubItems.Add(entry.copyright);
                else if (column.Text != "Name")
                    tempExtendedListViewItem.SubItems.Add("");
            }
            lViewSResultsBrowser.Items.Add(tempExtendedListViewItem);

            return !bgDatabaseSearcher.CancellationPending;
        }
        #endregion

        #region Form events handling code
        private void WndSearchResults_Load(object sender, EventArgs e)
        {
            if (fTypeManager == null)
                fTypeManager = new FileTypeManager();
        }

        private void WndSearchResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgDatabaseSearcher.IsBusy)
            {
                if (MessageBox.Show(Resources.msgSearchActive_WindowClosing, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    bgDatabaseSearcher.CancelAsync();
                    ///////////////////////////////////////////
                    while (bgDatabaseSearcher.IsBusy)
                        Application.DoEvents();
                }
            }
            if (toolBtnExtendedProperties.Checked)
                ClearExtendedPropertiesPanel();
        }
        #endregion

        #region ListView events handling code
        private void lViewSResultsBrowser_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lViewSResultsBrowser.SelectedItems.Count == 0)
            {
                toolBtnOpen.Enabled = false;
                toolBtnExplore.Enabled = false;
                toolBtnSItemProperties.Enabled = false;
                txtAddress.Text = "";
            }
            else
            {
                toolBtnOpen.Enabled = true;
                toolBtnExplore.Enabled = true;
                if (lViewSResultsBrowser.SelectedItems.Count == 1)
                {
                    toolBtnSItemProperties.Enabled = true;
                    txtAddress.Text = ((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).FullPath;
                }
                else
                {
                    toolBtnSItemProperties.Enabled = false;
                    txtAddress.Text = "";
                }
            }
            UpdateStatusBar(e);
            if (toolBtnExtendedProperties.Checked)
                UpdateExtendedPropertiesPanel();
        }

        private void lViewSResultsBrowser_ItemActivate(object sender, EventArgs e)
        {
            VFSEntry tempVFSEntry;
            string fullPath = "";

            tempVFSEntry = ((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ItemVFSEntry;
            fullPath = FindListEntryWithID(((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ParentImageID).imageSourcePath;
            fullPath = Path.Combine(fullPath, txtAddress.Text.Substring(txtAddress.Text.IndexOf("\\") + 1));
            fullPath = Path.Combine(fullPath, tempVFSEntry.name);

            try
            {
                if (tempVFSEntry.isDir)
                {
                    if (!Directory.Exists(fullPath))
                    {
                        MessageBox.Show("The directory " + fullPath + " was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ProcessStartInfo a = new ProcessStartInfo(fullPath);
                    a.UseShellExecute = true;
                    a.WorkingDirectory = Path.GetDirectoryName(fullPath);
                    Process.Start(a);
                }
                else
                {
                    if (!File.Exists(fullPath))
                    {
                        MessageBox.Show("The file " + fullPath + " was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ProcessStartInfo a = new ProcessStartInfo(fullPath);
                    a.UseShellExecute = true;
                    a.WorkingDirectory = Path.GetDirectoryName(fullPath);
                    Process.Start(a);
                }
            }
            catch (Win32Exception ex)
            { 
                MessageBox.Show("There was an error starting " + fullPath + ". The error message follows:\r\n" + 
                                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Properties
        internal FileTypeManager FileTypeManager
        {
            set { fTypeManager = value; }
        }
        #endregion

        #region Miscellenous methods
        private void AddDetailColumns()
        {
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("name", "Name", "String"));

            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("size", "File Size", "FileSize"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("iType", "Type", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("modified", "Date Modified", "DateTime"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("created", "Date Created", "DateTime"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("accessed", "Date Accessed", "DateTime"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("attributes", "Attrubutes", "String"));

            // lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("owner", "Owner", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("author", "Author", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("title", "Title", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("subject", "Subject", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("category", "Category", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("pages", "Pages", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("comments", "Comments", "String"));

            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("artist", "Artist", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("album", "Album", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("albumYear", "Album Year", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("trackNo", "Track Number", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("trackDuration", "Duration", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("genre", "Genre", "String"));

            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("bitRate", "Bitrate", "Bitrate"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("sampleRate", "Sample Rate", "String"));
            // lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("frameRate", "Frame Rate", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("dimenstions", "Dimensions", "String"));

            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("company", "Company", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("description", "Description", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("version", "File Version", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("pName", "Product Name", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("pVersion", "Product Version", "String"));
            lViewSResultsBrowser.Columns.Add(new ExtendedColumnHeader("copyright", "Copyright", "String"));
        }
        
        private void ImageListProcessor(ListEntry entry)
        {
            allImages.Add(entry);
        }
        
        private ListEntry FindListEntryWithID(uint imageID)
        {
            ListEntry listEntry = new ListEntry();
            foreach (ListEntry entry in allImages)
            {
                if (entry.imageID == imageID)
                {
                    listEntry = entry;
                    break;
                }
            }
            return listEntry;
        }
        #endregion

        #region UI Updaters
        private void UpdateStatusBar(ListViewItemSelectionChangedEventArgs e)
        {
            FileTypeInfo typeInfo;
            VFSEntry vfsEntry;
            ListEntry listEntry = new ListEntry();
            string temp = "";
            uint imageID = 0;

            if (lViewSResultsBrowser.SelectedItems.Count == 0)
            {
                statusStripLblImageIcon.Image = null;
                statusStripLblImageInfo.Text = "";

                statusStripLblSearchItemIcon.Image = Resources.search_48x48x32;
                statusStripLblSearchItemInfo.Text = "Search Results" + Environment.NewLine;
                statusStripLblSearchItemInfo.Text += lViewSResultsBrowser.Items.Count.ToString() + " items shown.";

                selectionSize = 0;
                multiSelectionIconSet = false;
            }
            else if (lViewSResultsBrowser.SelectedItems.Count == 1)
            {
                vfsEntry = ((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ItemVFSEntry;
                selectionSize = vfsEntry.size;

                imageID = ((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ParentImageID;
                listEntry = FindListEntryWithID(imageID);

                statusStripLblImageInfo.Text = listEntry.imageName;
                statusStripLblImageInfo.Text += Environment.NewLine + "Source: ";
                if (listEntry.imageSourcePath.Length > 50)
                    statusStripLblImageInfo.Text += GeneralMethods.TruncatePathString(listEntry.imageSourcePath, 50);
                else
                    statusStripLblImageInfo.Text += listEntry.imageSourcePath;
                //if (object.ReferenceEquals(treeImageBrowser.SelectedNode.Parent, treeImageBrowser.Nodes[2]))
                statusStripLblImageInfo.Text += Environment.NewLine + "Category: " + listEntry.imageCategory; // + " (Non-existent)";
                //else if (listEntry.imageSourceVolLabel.Length > 0)
                //    statusStripLblImageInfo.Text += Environment.NewLine + "Volume Label: " + listEntry.imageSourceVolLabel;
                if (listEntry.imageDescription.Length > 0 && listEntry.imageDescription.Length < 50)
                    statusStripLblImageInfo.Text += Environment.NewLine + "Description: " + listEntry.imageDescription;
                else if (listEntry.imageDescription.Length >= 50)
                    statusStripLblImageInfo.Text += Environment.NewLine + "Description: " + listEntry.imageDescription.Substring(0, 47) + "...";

                if (!vfsEntry.isDir)
                {
                    typeInfo = fTypeManager.GetFileTypeInfo(Path.GetExtension(vfsEntry.name));
                    if (typeInfo == null)
                        typeInfo = fTypeManager.GetFileTypeInfo("*file");
                }
                else
                    typeInfo = fTypeManager.GetFileTypeInfo("*dir");

                statusStripLblSearchItemIcon.Image = lViewSResultsBrowser.LargeImageList.Images[lViewSResultsBrowser.SelectedItems[0].ImageKey];
                statusStripLblSearchItemInfo.Text = vfsEntry.name;
                statusStripLblSearchItemInfo.Text += Environment.NewLine + "Type: " + typeInfo.typeName;
                if (vfsEntry.size > 0)
                    statusStripLblSearchItemInfo.Text += Environment.NewLine + "Size: " + GeneralMethods.GetFormattedSize(vfsEntry.size);
                if (vfsEntry.isROnly)
                    temp = Environment.NewLine + "Attributes: Read Only";
                if (vfsEntry.isHidden)
                    temp += ((temp.Length > 0) ? ", Hidden" : Environment.NewLine + "Attributes: Hidden");
                if (vfsEntry.isArch)
                    temp += ((temp.Length > 0) ? ", Archive" : Environment.NewLine + "Attributes: Archive");
                if (vfsEntry.isSystem)
                    temp += ((temp.Length > 0) ? ", System" : Environment.NewLine + "Attributes: System");
                if (vfsEntry.isCompressed)
                    temp += ((temp.Length > 0) ? ", Compressed" : Environment.NewLine + "Attributes: Compressed");
                if (vfsEntry.isEncrypted)
                    temp += ((temp.Length > 0) ? ", Encrypted" : Environment.NewLine + "Attributes: Encrypted");
                statusStripLblSearchItemInfo.Text += temp;

                multiSelectionIconSet = false;
            }
            else
            {
                vfsEntry = ((ExtendedListViewItem)e.Item).ItemVFSEntry;

                statusStripLblImageInfo.Text = "";

                if (!multiSelectionIconSet)
                {
                    statusStripLblSearchItemIcon.Image = IconFunctions.ExtractStandardIcon(StandardIcons.IconMultipleTypes).ToBitmap();
                    multiSelectionIconSet = true;
                }
                statusStripLblSearchItemInfo.Text = lViewSResultsBrowser.SelectedItems.Count.ToString() + " items selected.";
                if (e.IsSelected)
                    selectionSize += vfsEntry.size;
                else
                    selectionSize -= vfsEntry.size;
                if (selectionSize > 0)
                {
                    statusStripLblSearchItemInfo.Text += Environment.NewLine;
                    statusStripLblSearchItemInfo.Text += "Size: " + GeneralMethods.GetFormattedSize(selectionSize);
                }
            }
        }

        private void UpdateExtendedPropertiesPanel()
        {
            VFSEntry entry;

            if (lViewSResultsBrowser.SelectedItems.Count != 1)
            {
                ClearExtendedPropertiesPanel();
                return;
            }

            lViewExtendedProperties.Items.Clear();
            lViewExtendedProperties.View = View.Details;
            lViewExtendedProperties.BeginUpdate();
            //entry = ((ExtendedListViewItem)e.Item).ItemVFSEntry;
            entry = ((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ItemVFSEntry;

            GeneralMethods.GetGeneralFileProperties(entry, lViewExtendedProperties, 0);

            if (GeneralMethods.IsFileTypeAudio(entry.name))
            {
                // Music Properties
                GeneralMethods.GetMusicProperties(entry, lViewExtendedProperties, 1);

                // Audio Properties
                GeneralMethods.GetAudioProperties(entry, lViewExtendedProperties, 2);
            }
            else if (GeneralMethods.IsFileTypeVideo(entry.name))
            {
                GeneralMethods.GetVideoProperties(entry, lViewExtendedProperties, 3);
            }
            else if (GeneralMethods.IsFileTypeImage(entry.name))
            {
                GeneralMethods.GetImageProperties(entry, lViewExtendedProperties, 4);
            }
            else if (GeneralMethods.IsFileTypeDocument(entry.name))
            {
                GeneralMethods.GetDocumentProperties(entry, lViewExtendedProperties, 5);
            }

            lViewExtendedProperties.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lViewExtendedProperties.EndUpdate();

            if (lViewExtendedProperties.Items.Count == 0)
            {
                lViewExtendedProperties.View = View.List;
                lViewExtendedProperties.Items.Add("No extended properties are available for this object.");
            }

            if (!entry.isDir)
            {
                string fullPath = FindListEntryWithID(((ExtendedListViewItem)lViewSResultsBrowser.SelectedItems[0]).ParentImageID).imageSourcePath;

                fullPath = Path.Combine(fullPath, txtAddress.Text.Substring(txtAddress.Text.IndexOf("\\") + 1));
                fullPath = Path.Combine(fullPath, entry.name);

                multiPreviewer.Preview(fullPath, false, toolBtnAutoPlay.Checked, toolBtnAutoPlay.Checked);
            }
        }

        private void ClearExtendedPropertiesPanel()
        {
            lViewExtendedProperties.BeginUpdate();
            lViewExtendedProperties.Items.Clear();
            if (lViewSResultsBrowser.Items.Count > 0)
            {
                lViewExtendedProperties.Items.Add("Select an object to view its properties.");
                multiPreviewer.Preview("Select a file to preview.", true, false, false);
            }
            else
            {
                lViewExtendedProperties.Items.Add("No results shown.");
                multiPreviewer.Preview("No results shown.", true, false, false);
            }
            lViewExtendedProperties.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            lViewExtendedProperties.View = View.List;
            lViewExtendedProperties.EndUpdate();
        }
        #endregion

        private void cMenuSResultItem_Opening(object sender, CancelEventArgs e)
        {
            if (lViewSResultsBrowser.SelectedItems.Count > 1)
                cMenuSResultItemProperties.Enabled = false;
            else
                cMenuSResultItemProperties.Enabled = true;
        }

        private void cMenuSResultItemOpen_Click(object sender, EventArgs e)
        {
            toolBtnOpen_Click(sender, e);
        }

        private void cMenuSResultItemExplore_Click(object sender, EventArgs e)
        {
            toolBtnExplore_Click(sender, e);
        }

        private void cMenuSResultItemProperties_Click(object sender, EventArgs e)
        {
            toolBtnSItemProperties_Click(sender, e);
        }

        private void cMenuSResultItem_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            lViewSResultsBrowser.ContextMenuStrip = cMenuSResultsBrowser;
        }

        private void lViewSResultsBrowser_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lViewSResultsBrowser.SelectedItems.Count > 0)
                lViewSResultsBrowser.ContextMenuStrip = cMenuSResultItem;
        }

        private void lViewSResultsBrowser_SystemColorsChanged(object sender, EventArgs e)
        {
            if (!AppSettingsManager.ShowHiddenWithDistinctRepresentation)
                return;

            VFSEntry entry;
            Icon iconL, iconS;
            string imageKey;

            lViewSResultsBrowser.SuspendLayout();
            foreach (ExtendedListViewItem item in lViewSResultsBrowser.Items)
            {
                entry = item.ItemVFSEntry;
                if (entry.isHidden || entry.isSystem)
                {
                    imageKey = Path.GetExtension(entry.name);
                    if (entry.isDir)
                        imageKey = "*dir";
                    else if (entry.fileIcon == null)
                        imageKey = (imageKey == null || imageKey == String.Empty) ? "*file" : imageKey;
                    else
                        imageKey = "*" + entry.entryNo.ToString();

                    if (entry.fileIcon == null)
                    {
                        iconL = fTypeManager.GetIconForType(imageKey, IconSize.IconLarge);
                        iconS = fTypeManager.GetIconForType(imageKey, IconSize.IconSmall);
                    }
                    else
                    {
                        iconL = IconFunctions.IconFromBytes(entry.fileIcon);
                        iconS = IconFunctions.IconFromBytes(entry.fileIcon);
                    }

                    if (iconL == null || iconS == null)
                    {
                        iconL = fTypeManager.GetIconForType("*file", IconSize.IconLarge);
                        iconS = fTypeManager.GetIconForType("*file", IconSize.IconSmall);
                    }
                    lViewSResultsBrowser.LargeImageList.Images.RemoveByKey(item.ImageKey);
                    lViewSResultsBrowser.SmallImageList.Images.RemoveByKey(item.ImageKey);
                    lViewSResultsBrowser.LargeImageList.Images.Add(item.ImageKey, GeneralMethods.SetImageOpacity(iconL.ToBitmap(), 0.5f));
                    lViewSResultsBrowser.SmallImageList.Images.Add(item.ImageKey, GeneralMethods.SetImageOpacity(iconS.ToBitmap(), 0.5f));
                }
            }
            lViewSResultsBrowser.ResumeLayout();
        }

        private void cMenuVFSBrowserItemIcons_Click(object sender, EventArgs e)
        {
            iconsToolStripMenuItem_Click(sender, e);
        }

        private void cMenuVFSBrowserItemList_Click(object sender, EventArgs e)
        {
            listToolStripMenuItem_Click(sender, e);
        }

        private void cMenuVFSBrowserItemDetails_Click(object sender, EventArgs e)
        {
            detailsToolStripMenuItem_Click(sender, e);
        }
    }

    public class ExploreEntryEventArgs : EventArgs
    {
        private uint parentImageID;
        private VFSEntry entryToExplore;

        public uint ParentImageID
        {
            get { return parentImageID; }
        }
        public VFSEntry EntryToExplore
        {
            get { return entryToExplore; }
        }

        public ExploreEntryEventArgs(uint parentImageID, VFSEntry entryToExplore)
        {
            this.parentImageID = parentImageID;
            this.entryToExplore = entryToExplore;
        }
    }
}