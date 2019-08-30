using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Registry_Manager;
using Virtual_File_System_Library;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using CD_Sync_Portable.Properties;
using Utils.MessageBoxExLib;
using Customized_Controls;

namespace CD_Sync_Portable
{
    internal partial class WndMain : Form
    {
        private List<ImageCategory> categories;
        private VFS virtualFS;
        private Stack<UInt32> backChain, forwardChain;
        private ListEntry globalImageListEntry;
        private UInt32 currentLocationID, totalInvisibleObjects;
        private UInt64 selectionSize;
        private FileTypeManager fTypeManager;
        private Thread threadImageSourceDriveTypeQuerier;
        private SortOrder curSortOrder;
        private int lastSortColumn, tempInteger;
        private bool asked, imageSourceOnline, multiSelectionIconSet;
        private string argument;

        public WndMain(string[] args)
        {
            InitializeComponent();

            if (args.Length > 0)
                argument = args[0];

            categories = CategoryManager.GetAllCategories();

            treeImageBrowser.ImageList = new ImageList();
            treeImageBrowser.ImageList.Images.Add(Properties.Resources.blankcd);
            treeImageBrowser.ImageList.Images.Add(Properties.Resources.FillDownHS);
            treeImageBrowser.ImageList.Images.Add(Properties.Resources.FillRightHS);
            treeImageBrowser.HideSelection = false;
            treeImageBrowser.PathSeparator = "\\";

            lViewVFSBrowser.View = AppSettingsManager.BrowserViewSetting;
            lViewVFSBrowser.LargeImageList = new ImageList();
            lViewVFSBrowser.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
            lViewVFSBrowser.LargeImageList.ImageSize = new Size(32, 32);

            lViewVFSBrowser.SmallImageList = new ImageList();
            lViewVFSBrowser.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
            lViewVFSBrowser.SmallImageList.ImageSize = new Size(16, 16);
            lViewVFSBrowser.AutoArrange = true;
            AddDetailColumns();

            MessageBoxEx msgBox;

            msgBox = MessageBoxExManager.CreateMessageBox("CategoryAddition");
            msgBox.Caption = "Question";
            msgBox.Font = new Font("Tahoma", 8);
            msgBox.Icon = MessageBoxExIcon.Question;
            msgBox.AddButtons(MessageBoxButtons.YesNo);
            msgBox.PlayAlertSound = true;
            msgBox.SaveResponseText = "Remember my choice.";
            msgBox.AllowSaveResponse = true;
            msgBox.UseSavedResponse = true;

            msgBox = MessageBoxExManager.CreateMessageBox("FSBrowserException");
            msgBox.Caption = "Error";
            msgBox.Font = new Font("Tahoma", 8);
            msgBox.Icon = MessageBoxExIcon.Error;
            msgBox.AddButtons(MessageBoxButtons.OK);
            msgBox.PlayAlertSound = true;
            msgBox.SaveResponseText = "Don't show me this message again.";
            msgBox.AllowSaveResponse = true;
            msgBox.UseSavedResponse = true;

            fTypeManager = new FileTypeManager();

            backChain = new Stack<UInt32>(10);
            forwardChain = new Stack<UInt32>(10);
            virtualFS = new VFS();

            lastSortColumn = -1;
            curSortOrder = SortOrder.None;
            multiSelectionIconSet = false;
            asked = false;
        }

        private void mainWnd_Load(object sender, EventArgs e)
        {
            // The following statement have been moved to wndMain.Designer.cs file and have been left here
            // to server as a reminder for the same.

            // this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(AppSettingsManager.StartPositionX, AppSettingsManager.StartPositionY);
            this.WindowState = AppSettingsManager.MainWindowState;
            this.Size = new Size(AppSettingsManager.MainWindowWidth, AppSettingsManager.MainWindowHeight);

            this.SizeChanged += new System.EventHandler(this.WndMain_SizeChanged);
            this.Move += new System.EventHandler(this.WndMain_Move);
            
            viewSplitter.SplitterDistance = AppSettingsManager.ImageBrowserWidth;
            viewSplitter2.SplitterDistance = AppSettingsManager.ImageBrowserHeight;
            viewSplitter3.SplitterDistance = AppSettingsManager.VFSBrowserHeight;
            viewSplitter4.SplitterDistance = AppSettingsManager.ExtendedPropertiesPanelSplitterDistance;

            viewSplitter.SplitterMoved += new SplitterEventHandler(viewSplitter_SplitterMoved);
            viewSplitter2.SplitterMoved += new SplitterEventHandler(viewSplitter2_SplitterMoved);
            viewSplitter3.SplitterMoved += new SplitterEventHandler(viewSplitter3_SplitterMoved);
            viewSplitter4.SplitterMoved += new SplitterEventHandler(viewSplitter4_SplitterMoved);
            RefreshImageBrowser();
            if (AppSettingsManager.ShowExtendedPropertiesPanel)
            {
                viewSplitter3.Panel2Collapsed = false;
                ClearExtendedPropertiesPanel();
            }
            else
                viewSplitter3.Panel2Collapsed = true;

            if (argument != null && Directory.Exists(argument))
                if ((new WndNewImage(argument)).ShowDialog(categories) == DialogResult.OK)
                {
                    categories = CategoryManager.GetAllCategories();
                    RefreshImageBrowser();
                }
        }

        #region treeImageBrowser handling code

        private void RefreshImageBrowser()
        {
            ExtendedTreeNode tempExtendedTreeNode = new ExtendedTreeNode();
            ListEntry tempListEntry;
            bool addEventHandler = false;

            if (treeImageBrowser.SelectedNode != null && ((ExtendedTreeNode)treeImageBrowser.SelectedNode).NodeType == ExtendedTreeNodeType.NodeTypeImage)
            {
                treeImageBrowser.AfterSelect -= treeImageBrowser_AfterSelect;
                addEventHandler = true;
            }

            treeImageBrowser.Nodes.Clear();
            treeImageBrowser.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Categorized Images", 0, 0));
            treeImageBrowser.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Uncategorized Images", 0, 0));
            treeImageBrowser.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Deleted Categories", 0, 0));

            tempExtendedTreeNode.NodeType = ExtendedTreeNodeType.NodeTypeCategory;
            tempExtendedTreeNode.ImageIndex = 2;
            tempExtendedTreeNode.SelectedImageIndex = 1;
            tempExtendedTreeNode.ContextMenuStrip = cMenuImageCategoryNode;
            tempExtendedTreeNode.Tag = null;
            foreach(ImageCategory category in categories)
            {
                tempExtendedTreeNode.Text = category.categoryName;
                tempExtendedTreeNode.NodeData = category;
                tempExtendedTreeNode.ToolTipText = category.categoryDesc;

                treeImageBrowser.Nodes[0].Nodes.Add((ExtendedTreeNode)tempExtendedTreeNode.Clone());
            }

            ImageListManipulator.ReadAllEntries(ImageListEntryProcessor);
            treeImageBrowser.ExpandAll();

            tempInteger = 0;
            foreach (ExtendedTreeNode node in treeImageBrowser.Nodes[0].Nodes)
            {
                treeImageBrowser.Nodes[0].Nodes[node.Index].Text = node.Text + " (" + node.Nodes.Count.ToString() + ")";
                tempInteger += node.Nodes.Count;
            }

            treeImageBrowser.Nodes[0].Text = "Categorized Images" + " (" + tempInteger.ToString() + ")";
            treeImageBrowser.Nodes[1].Text = "Uncategorized Images" + " (" + treeImageBrowser.Nodes[1].Nodes.Count.ToString() + ")";
            treeImageBrowser.Nodes[2].Text = "Deleted Categories" + " (" + treeImageBrowser.Nodes[2].Nodes.Count.ToString() + ")";

            if (treeImageBrowser.Nodes[2].Nodes.Count > 0 && !asked && AppSettingsManager.NotifyOfImagesInDeletedCategories)
            {
                if (MessageBox.Show(Properties.Resources.promptImagesInDeletedCategory, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ExtendedTreeNode node in treeImageBrowser.Nodes[2].Nodes)
                    {
                        tempListEntry = new ListEntry();
                        tempListEntry = (ListEntry)node.NodeData;
                        tempListEntry.imageCategory = "";
                        ImageListManipulator.UpdateEntry(tempListEntry.imageID, tempListEntry);
                    }
                    RefreshImageBrowser();
                }
                asked = true;
            }

            if (addEventHandler)
            {
                TreeNode[] nodes = treeImageBrowser.Nodes.Find(globalImageListEntry.imageID.ToString(), true);
                if (nodes.Length > 0)
                    treeImageBrowser.SelectedNode = nodes[0];
                treeImageBrowser.AfterSelect += treeImageBrowser_AfterSelect;
            }
        }
        private void treeImageBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (virtualFS.GetDbState() != System.Data.ConnectionState.Closed)
            {
                virtualFS.CloseConnection(true);
                globalImageListEntry = new ListEntry();

                ClosePictureBox();

                imageSourceOnline = false;
                txtAddress.Text = "";

                TreeNonImageNodeActive();
            }

            if (((ExtendedTreeNode)e.Node).NodeType == ExtendedTreeNodeType.NodeTypeImage)
            {
                globalImageListEntry = ((ListEntry)((ExtendedTreeNode)e.Node).NodeData).Clone();
                try
                {
                    virtualFS.OpenConnection(Path.Combine(AppSettingsManager.ImagesDirectory, globalImageListEntry.imageDbPath));
                }
                catch
                {
                    globalImageListEntry = new ListEntry();
                    MessageBox.Show(Resources.msgCannotConnectToVFS, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (virtualFS.ReadEntry(0).name != globalImageListEntry.imageName)
                {
                    MessageBox.Show(Resources.msgInvalidVFS, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    virtualFS.CloseConnection(true);
                    globalImageListEntry = new ListEntry();
                    return;
                }
                ShowPictureBox(Path.Combine(AppSettingsManager.ImagesDirectory, globalImageListEntry.imagePicture));

                ShowRootContents();
                TreeImageNodeActive();

                UpdateBottomPanelImageInfo();
            }
        }
        private void treeImageBrowser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeImageBrowser.SelectedNode = e.Node;
        }
        private void treeImageBrowser_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            VFSEntry tempVFSEntry;
            treeImageBrowser.LabelEdit = false;

            if (e.Label == null)
            {
                e.CancelEdit = true;
                return;
            }
            if (e.Label.Length == 0)
            {
                MessageBox.Show(Properties.Resources.msgImageNameEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
                return;
            }
            if (e.Label == e.Node.Text)
            {
                e.CancelEdit = true;
                return;
            }

            e.Node.Text = e.Label;
            globalImageListEntry.imageName = e.Label;
            ((ExtendedTreeNode)e.Node).NodeData = globalImageListEntry.Clone();
            ImageListManipulator.UpdateEntry(globalImageListEntry.imageID, globalImageListEntry);

            tempVFSEntry = virtualFS.ReadEntry(0);
            tempVFSEntry.name = e.Label;
            virtualFS.UpdateEntry(0, tempVFSEntry);

            subMenuItemRefreshlViewVFSBrowser_Click(new object(), EventArgs.Empty);
        }
        private void treeImageBrowser_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ((ExtendedTreeNode)e.Item).NodeType == ExtendedTreeNodeType.NodeTypeImage)
                DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void treeImageBrowser_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ExtendedTreeNode)))
                e.Effect = e.AllowedEffect;
        }
        private void treeImageBrowser_DragDrop(object sender, DragEventArgs e)
        {
            ExtendedTreeNode draggedNode, destNode;
            ListEntry entry;

            draggedNode = (ExtendedTreeNode)e.Data.GetData(typeof(ExtendedTreeNode));
            entry = (ListEntry)draggedNode.NodeData;
            destNode = (ExtendedTreeNode)treeImageBrowser.GetNodeAt(treeImageBrowser.PointToClient(new Point(e.X, e.Y)));

            if (destNode.NodeType == ExtendedTreeNodeType.NodeTypeImage)
                destNode = (ExtendedTreeNode)destNode.Parent;

            if (Object.ReferenceEquals(destNode, treeImageBrowser.Nodes[0]) || Object.ReferenceEquals(destNode, treeImageBrowser.Nodes[2]))
                return;

            if (Object.ReferenceEquals(destNode, treeImageBrowser.Nodes[1]))
                entry.imageCategory = "";
            else
                entry.imageCategory = ((ImageCategory)destNode.NodeData).categoryName;
            ImageListManipulator.UpdateEntry(entry.imageID, entry);

            treeImageBrowser.SelectedNode = draggedNode;
            RefreshImageBrowser();
        }
        private void TreeImageNodeActive()
        {
            menuItemExportFileList.Enabled = true;
            menuItemShowProp.Enabled = true;
            menuItemDelImage.Enabled = true;
            toolBtnDeleteImage.Enabled = true;

            if (AppSettingsManager.ShowExtendedPropertiesPanel)
                ClearExtendedPropertiesPanel();

            subMenuItemRefreshlViewVFSBrowser.Enabled = true;
            toolBtnlViewBrowserRefresh.Enabled = true;

            subMenuViewlViewVFSBrowser.Enabled = true;
            toolMenulViewVFSBrowserView.Enabled = true;
        }
        private void TreeNonImageNodeActive()
        {
            menuItemExportFileList.Enabled = false;
            menuItemShowProp.Enabled = false;
            menuItemDelImage.Enabled = false;
            toolBtnDeleteImage.Enabled = false;

            if (AppSettingsManager.ShowExtendedPropertiesPanel)
                ClearExtendedPropertiesPanel();
            
            lViewVFSBrowser.LargeImageList.Images.Clear();
            lViewVFSBrowser.SmallImageList.Images.Clear();
            statusStripLblImageIcon.Image = null;
            statusStripLblImageInfo.Text = "";
            statusStripLblVFSItemIcon.Image = null;
            statusStripLblVFSItemInfo.Text = "";
            imageSourceOnline = false;

            ClearContents();
            backChain.Clear();
            forwardChain.Clear();

            subMenuItemRefreshlViewVFSBrowser.Enabled = false;
            toolBtnlViewBrowserRefresh.Enabled = false;

            menuItemVFSItemProperties.Enabled = false;
            toolBtnVFSItemProperties.Enabled = false;

            subMenuViewlViewVFSBrowser.Enabled = false;
            toolMenulViewVFSBrowserView.Enabled = false;

            subMenuItemlViewVFSBrowserGoBack.Enabled = false;
            toolBtnlViewVFSBrowserGoBack.Enabled = false;

            subMenuItemlViewVFSBrowserGoForward.Enabled = false;
            toolBtnlViewVFSBrowserGoForward.Enabled = false;

            subMenuItemlViewVFSBrowserGoUp.Enabled = false;
            toolBtnlViewVFSBrowserGoUp.Enabled = false;

            subMenuItemlViewVFSBrowserGoToRoot.Enabled = false;
            toolBtnlViewVFSBrowserGoToRoot.Enabled = false;
        }

        #endregion

        #region lViewVFSBrowser handling code

        private void ShowRootContents()
        {
            lViewVFSBrowser.BeginUpdate();
            
            ClearContents();
            totalInvisibleObjects = 0;
            virtualFS.ReadSubEntries(0, VFSEntryProcessor);
            currentLocationID = 0;

            if (lViewVFSBrowser.View == View.Details)
                lViewVFSBrowser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lViewVFSBrowser.EndUpdate();

            subMenuItemlViewVFSBrowserGoUp.Enabled = false;
            toolBtnlViewVFSBrowserGoUp.Enabled = false;

            subMenuItemlViewVFSBrowserGoToRoot.Enabled = false;
            toolBtnlViewVFSBrowserGoToRoot.Enabled = false;


            menuItemVFSItemOpen.Enabled = false;
            menuItemVFSItemExplore.Enabled = false;
            menuItemVFSItemDelete.Enabled = false;
            menuItemVFSItemProperties.Enabled = false;
            toolBtnVFSItemProperties.Enabled = false;

            txtAddress.Text = globalImageListEntry.imageName + "\\";

            UpdateBottomPanelVFSBrowserInfo(null);
            if (AppSettingsManager.ShowExtendedPropertiesPanel)
                ClearExtendedPropertiesPanel();
        }
        private void ShowContents(UInt32 entryNumber)
        {
            if (entryNumber == 0)
            {
                ShowRootContents();
                return;
            }

            lViewVFSBrowser.BeginUpdate();

            ClearContents();
            totalInvisibleObjects = 0;
            virtualFS.ReadSubEntries(entryNumber, VFSEntryProcessor);
            currentLocationID = entryNumber;

            if (lViewVFSBrowser.View == View.Details)
                lViewVFSBrowser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lViewVFSBrowser.EndUpdate();

            subMenuItemlViewVFSBrowserGoUp.Enabled = true;
            toolBtnlViewVFSBrowserGoUp.Enabled = true;

            subMenuItemlViewVFSBrowserGoToRoot.Enabled = true;
            toolBtnlViewVFSBrowserGoToRoot.Enabled = true;

            menuItemVFSItemOpen.Enabled = false;
            menuItemVFSItemExplore.Enabled = false;
            menuItemVFSItemDelete.Enabled = false;
            menuItemVFSItemProperties.Enabled = false;
            toolBtnVFSItemProperties.Enabled = false;

            txtAddress.Text = virtualFS.GetPathFromList(virtualFS.TracePathToEntry(currentLocationID));

            UpdateBottomPanelVFSBrowserInfo(null);
            if (AppSettingsManager.ShowExtendedPropertiesPanel)
                ClearExtendedPropertiesPanel();
        }
        private void UpdateBottomPanelVFSBrowserInfo(ListViewItemSelectionChangedEventArgs e)
        {
            FileTypeInfo typeInfo;
            VFSEntry vfsEntry;
            string temp = "";

            if (lViewVFSBrowser.SelectedItems.Count == 0)
            {
                selectionSize = 0;
                vfsEntry = virtualFS.ReadEntry(currentLocationID);
                statusStripLblVFSItemIcon.Image = fTypeManager.GetIconForType("*dir", IconSize.IconLarge).ToBitmap();
                multiSelectionIconSet = false;

                if (vfsEntry.name.Length > 50)
                    statusStripLblVFSItemInfo.Text = vfsEntry.name.Substring(0, 47) + "...";
                else
                    statusStripLblVFSItemInfo.Text = vfsEntry.name;
                if (currentLocationID == 0)
                {
                    statusStripLblVFSItemInfo.Text += Environment.NewLine + "Type: Image Root Folder";
                    statusStripLblVFSItemInfo.Text += Environment.NewLine + "Image VFS File: " + globalImageListEntry.imageDbPath;
                }
                else
                {
                    statusStripLblVFSItemInfo.Text += Environment.NewLine + "Type: File Folder";
                    if (vfsEntry.isROnly)
                        temp = Environment.NewLine + "Attributes: Read Only";
                    if (vfsEntry.isHidden)
                        temp += (temp.Length > 0) ? ", Hidden" : Environment.NewLine + "Attributes: Hidden";
                    if (vfsEntry.isArch)
                        temp += (temp.Length > 0) ? ", Archive" : Environment.NewLine + "Attributes: Archive";
                    if (vfsEntry.isSystem)
                        temp += (temp.Length > 0) ? ", System" : Environment.NewLine + "Attributes: System";
                    if (vfsEntry.isCompressed)
                        temp += (temp.Length > 0) ? ", Compressed" : Environment.NewLine + "Attributes: Compressed";
                    if (vfsEntry.isEncrypted)
                        temp += (temp.Length > 0) ? ", Encrypted" : Environment.NewLine + "Attributes: Encrypted";
                    statusStripLblVFSItemInfo.Text += temp;
                }
                statusStripLblVFSItemInfo.Text += Environment.NewLine;
                statusStripLblVFSItemInfo.Text += lViewVFSBrowser.Items.Count.ToString() + " objects";
                if (AppSettingsManager.NotifyOfInvisibleObjects)
                    statusStripLblVFSItemInfo.Text += " shown, " + totalInvisibleObjects.ToString() + " invisible";
            }
            else if (lViewVFSBrowser.SelectedItems.Count == 1)
            {
                vfsEntry = ((ExtendedListViewItem)lViewVFSBrowser.SelectedItems[0]).ItemVFSEntry;
                selectionSize = vfsEntry.size;
                if (!vfsEntry.isDir)
                {
                    typeInfo = fTypeManager.GetFileTypeInfo(Path.GetExtension(vfsEntry.name));
                    if (typeInfo == null)
                        typeInfo = fTypeManager.GetFileTypeInfo("*file");
                }
                else
                    typeInfo = fTypeManager.GetFileTypeInfo("*dir");

                statusStripLblVFSItemIcon.Image = lViewVFSBrowser.LargeImageList.Images[lViewVFSBrowser.SelectedItems[0].ImageKey];
                statusStripLblVFSItemInfo.Text = vfsEntry.name;
                statusStripLblVFSItemInfo.Text += Environment.NewLine + "Type: " + typeInfo.typeName;
                multiSelectionIconSet = false;
                if (vfsEntry.size > 0)
                    statusStripLblVFSItemInfo.Text += Environment.NewLine + "Size: " + GeneralMethods.GetFormattedSize(vfsEntry.size);
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
                statusStripLblVFSItemInfo.Text += temp;
            }
            else
            {
                vfsEntry = ((ExtendedListViewItem)e.Item).ItemVFSEntry;
                if (!multiSelectionIconSet)
                {
                    statusStripLblVFSItemIcon.Image = IconFunctions.ExtractStandardIcon(StandardIcons.IconMultipleTypes).ToBitmap();
                    multiSelectionIconSet = true;
                }
                statusStripLblVFSItemInfo.Text = lViewVFSBrowser.SelectedItems.Count.ToString() + " items selected.";
                if (e.IsSelected)
                    selectionSize += vfsEntry.size;
                else
                    selectionSize -= vfsEntry.size;
                if (selectionSize > 0)
                {
                    statusStripLblVFSItemInfo.Text += Environment.NewLine;
                    statusStripLblVFSItemInfo.Text += "Size: " + GeneralMethods.GetFormattedSize(selectionSize);
                }
            }
        }
        private void UpdateExtendedPropertiesPanel(ListViewItemSelectionChangedEventArgs e)
        {
            VFSEntry entry;

            if (!e.IsSelected || lViewVFSBrowser.SelectedItems.Count > 1)
            {
                ClearExtendedPropertiesPanel();
                return;
            }

            lViewExtendedProperties.Items.Clear();
            lViewExtendedProperties.View = View.Details;
            lViewExtendedProperties.BeginUpdate();
            entry = ((ExtendedListViewItem)e.Item).ItemVFSEntry;

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

            if (imageSourceOnline && !entry.isDir)
            {
                string fullPath = globalImageListEntry.imageSourcePath;

                fullPath = Path.Combine(fullPath, txtAddress.Text.Substring(txtAddress.Text.IndexOf("\\")+1));
                fullPath = Path.Combine(fullPath, entry.name);
                
                multiPreviewer.Preview(fullPath, false, AppSettingsManager.AutoPlayVideos, AppSettingsManager.AutoPlayAudios);
            }
        }
        private void ClearExtendedPropertiesPanel()
        {
            lViewExtendedProperties.BeginUpdate();
            lViewExtendedProperties.Items.Clear();
            if (txtAddress.Text.Length > 0)
            {
                lViewExtendedProperties.Items.Add("Select an object to view its properties.");
                if (imageSourceOnline)
                    multiPreviewer.Preview("Select a file to preview.", true, false, false);
                else
                    multiPreviewer.Preview("Image source offline. Preview unavailable.", true, false, false);
            }
            else
            {
                lViewExtendedProperties.Items.Add("No image selected.");
                multiPreviewer.Preview("No image selected.", true, false, false);
            }
            lViewExtendedProperties.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            lViewExtendedProperties.View = View.List;
            lViewExtendedProperties.EndUpdate();
        }
        private void ClearContents()
        {
            lViewVFSBrowser.Items.Clear();
        }
        private void lViewVFSBrowser_ItemActivate(object sender, EventArgs e)
        {
            VFSEntry tempVFSEntry;
            string fullPath="";

            tempVFSEntry = ((ExtendedListViewItem)lViewVFSBrowser.SelectedItems[0]).ItemVFSEntry;

            if (tempVFSEntry.isDir)
            {
                backChain.Push(currentLocationID);
                forwardChain.Clear();
                ShowContents(tempVFSEntry.entryNo);

                subMenuItemlViewVFSBrowserGoBack.Enabled = true;
                toolBtnlViewVFSBrowserGoBack.Enabled = true;

                subMenuItemlViewVFSBrowserGoForward.Enabled = false;
                toolBtnlViewVFSBrowserGoForward.Enabled = false;
            }
            else
            {
                if (imageSourceOnline)
                {
                    fullPath = globalImageListEntry.imageSourcePath;
                    fullPath = Path.Combine(fullPath, txtAddress.Text.Substring(txtAddress.Text.IndexOf("\\") + 1));
                    fullPath = Path.Combine(fullPath, tempVFSEntry.name);
                    try
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
                    catch(Win32Exception ex)
                    {
                        MessageBox.Show("There was an error starting " + fullPath + ". The error message follows:\r\n"
                            + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.msgImageSourceOffline, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void lViewVFSBrowser_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lViewVFSBrowser.SelectedItems.Count < 1)
            {
                menuItemVFSItemOpen.Enabled = false;
                menuItemVFSItemExplore.Enabled = false;
                menuItemRenameVFSItem.Enabled = false;
                menuItemEditVFSItemDescription.Enabled = false;
                menuItemVFSItemDelete.Enabled = false;
                menuItemVFSItemProperties.Enabled = false;
                toolBtnVFSItemProperties.Enabled = false;
            }
            else
            {
                if (lViewVFSBrowser.SelectedItems.Count == 1)
                {
                    menuItemVFSItemOpen.Enabled = true;
                    if (((ExtendedListViewItem)lViewVFSBrowser.SelectedItems[0]).ItemVFSEntry.isDir)
                        menuItemVFSItemExplore.Enabled = true;
                    menuItemRenameVFSItem.Enabled = true;
                    menuItemEditVFSItemDescription.Enabled = true;
                }
                else
                {
                    menuItemVFSItemOpen.Enabled = false;
                    menuItemVFSItemExplore.Enabled = false;
                    menuItemRenameVFSItem.Enabled = false;
                    menuItemEditVFSItemDescription.Enabled = false;
                }
                menuItemVFSItemDelete.Enabled = true;
                menuItemVFSItemProperties.Enabled = true;
                toolBtnVFSItemProperties.Enabled = true;
            }
            if (AppSettingsManager.ShowObjectDetailsOnBottomPanel)
                UpdateBottomPanelVFSBrowserInfo(e);
            if (AppSettingsManager.ShowExtendedPropertiesPanel)
                UpdateExtendedPropertiesPanel(e);
        }
        private void lViewVFSBrowser_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && txtAddress.Text.Length > 0)
            {
                if (lViewVFSBrowser.SelectedItems.Count > 0)
                    lViewVFSBrowser.ContextMenuStrip = cMenuVFSItem;
            }
        }
        private void lViewVFSBrowser_SystemColorsChanged(object sender, EventArgs e)
        {
            if (!AppSettingsManager.ShowHiddenWithDistinctRepresentation)
                return;

            VFSEntry entry;
            Icon iconL, iconS;
            string imageKey;

            lViewVFSBrowser.SuspendLayout();
            foreach (ExtendedListViewItem item in lViewVFSBrowser.Items)
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
                    lViewVFSBrowser.LargeImageList.Images.RemoveByKey(item.ImageKey);
                    lViewVFSBrowser.SmallImageList.Images.RemoveByKey(item.ImageKey);
                    lViewVFSBrowser.LargeImageList.Images.Add(item.ImageKey, GeneralMethods.SetImageOpacity(iconL.ToBitmap(), 0.5f));
                    lViewVFSBrowser.SmallImageList.Images.Add(item.ImageKey, GeneralMethods.SetImageOpacity(iconS.ToBitmap(), 0.5f));
                }
            }
            lViewVFSBrowser.ResumeLayout();
        }
        private void lViewVFSBrowser_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lastSortColumn == e.Column)
            {
                if (curSortOrder != SortOrder.Descending)
                {
                    lViewVFSBrowser.ListViewItemSorter = new ListViewItemComparer(e.Column, (string)lViewVFSBrowser.Columns[e.Column].Tag, true);
                    curSortOrder = SortOrder.Descending;
                }
                else
                {
                    lViewVFSBrowser.ListViewItemSorter = new ListViewItemComparer(e.Column, (string)lViewVFSBrowser.Columns[e.Column].Tag, false);
                    curSortOrder = SortOrder.Ascending;
                }
            }
            else
            {
                lViewVFSBrowser.ListViewItemSorter = new ListViewItemComparer(e.Column, (string)lViewVFSBrowser.Columns[e.Column].Tag, false);
                curSortOrder = SortOrder.Ascending;
            }
            lastSortColumn = e.Column;
        }
        private void lViewVFSBrowser_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ExtendedListViewItem item;
            VFSEntry entry;

            if (e.Label == null)
                return;

            if (e.Label.Length == 0)
            {
                MessageBox.Show(Resources.msgFileNameCannotBeEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
                return;
            }
            
            if (e.Label.Contains("/") || e.Label.Contains("\\") || e.Label.Contains(":") || e.Label.Contains("*") ||
                e.Label.Contains("?") || e.Label.Contains("\"") || e.Label.Contains("<") || e.Label.Contains(">") ||
                e.Label.Contains("|"))
            {
                MessageBox.Show(Resources.msgInvalidFileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
                return;
            }

            item = (ExtendedListViewItem)lViewVFSBrowser.Items[e.Item];
            entry = item.ItemVFSEntry;
            entry.name = e.Label;
            item.ItemVFSEntry = entry;
            virtualFS.UpdateEntry(entry.entryNo, entry);

            if (!entry.isDir && String.Compare(Path.GetExtension(e.Label), Path.GetExtension(item.Text), true) != 0)
                subMenuItemRefreshlViewVFSBrowser_Click(sender, e);
            else
            {
                ListViewItemSelectionChangedEventArgs eventArgs = new ListViewItemSelectionChangedEventArgs(lViewVFSBrowser.Items[e.Item], e.Item, true);
                UpdateExtendedPropertiesPanel(eventArgs);
                UpdateBottomPanelVFSBrowserInfo(eventArgs);
            }
        }
        private void AddDetailColumns()
        {
            lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("name", "Name", "String"));

            if (AppSettingsManager.ShowSizeColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("size", "File Size", "FileSize"));
            if (AppSettingsManager.ShowItemTypeColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("iType", "Type", "String"));
            if (AppSettingsManager.ShowModifiedDateColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("modified", "Date Modified", "DateTime"));
            if (AppSettingsManager.ShowCreatedDateColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("created", "Date Created", "DateTime"));
            if (AppSettingsManager.ShowAccessedDateColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("accessed", "Date Accessed", "DateTime"));
            if (AppSettingsManager.ShowAttributesColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("attributes", "Attrubutes", "String"));

            //if (AppSettingsManager.ShowOwnerColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("owner", "Owner", "String"));
            if (AppSettingsManager.ShowAuthorColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("author", "Author", "String"));
            if (AppSettingsManager.ShowTitleColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("title", "Title", "String"));
            if (AppSettingsManager.ShowSubjectColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("subject", "Subject", "String"));
            if (AppSettingsManager.ShowCategoryColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("category", "Category", "String"));
            if (AppSettingsManager.ShowPagesColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("pages", "Pages", "String"));
            if (AppSettingsManager.ShowCommentsColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("comments", "Comments", "String"));

            if (AppSettingsManager.ShowArtistColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("artist", "Artist", "String"));
            if (AppSettingsManager.ShowAlbumColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("album", "Album", "String"));
            if (AppSettingsManager.ShowAlbumYearColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("albumYear", "Album Year", "String"));
            if (AppSettingsManager.ShowTrackNoColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("trackNo", "Track Number", "String"));
            if (AppSettingsManager.ShowDurationColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("trackDuration", "Duration", "String"));
            if (AppSettingsManager.ShowGenreColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("genre", "Genre", "String"));

            if (AppSettingsManager.ShowBitrateColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("bitRate", "Bitrate", "Bitrate"));
            if (AppSettingsManager.ShowSampleRateColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("sampleRate", "Sample Rate", "String"));
            //if (AppSettingsManager.ShowFrameRateColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("frameRate", "Frame Rate", "String"));
            if (AppSettingsManager.ShowDimensionsColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("dimenstions", "Dimensions", "String"));

            if (AppSettingsManager.ShowCompanyColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("company", "Company", "String"));
            if (AppSettingsManager.ShowDescriptionColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("description", "Description", "String"));
            if (AppSettingsManager.ShowVersionColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("version", "File Version", "String"));
            if (AppSettingsManager.ShowProductNameColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("pName", "Product Name", "String"));
            if (AppSettingsManager.ShowPVersionColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("pVersion", "Product Version", "String"));
            if (AppSettingsManager.ShowCopyrightColumn) lViewVFSBrowser.Columns.Add(new ExtendedColumnHeader("copyright", "Copyright", "String"));
        }
        #endregion

        #region Menus and toolbar handling code

        #region Event Handlers for Menu Items

        private void menuItemNewImage_Click(object sender, EventArgs e)
        {
            WndNewImage newImageWindow = new WndNewImage(null);

            if (newImageWindow.ShowDialog(categories) == DialogResult.OK)
            {
                categories = CategoryManager.GetAllCategories();
                RefreshImageBrowser();
            }
            newImageWindow.Dispose();
        }
        private void menuItemDelImage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.promptImageDelete, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (virtualFS.GetDbState() == System.Data.ConnectionState.Open)
            {
                ClearContents();
                ClosePictureBox();
                virtualFS.CloseConnection(true);
            }

            try
            {
                if (File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, globalImageListEntry.imageDbPath)))
                    File.Delete(Path.Combine(AppSettingsManager.ImagesDirectory, globalImageListEntry.imageDbPath));

                if (File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, globalImageListEntry.imagePicture)))
                    File.Delete(Path.Combine(AppSettingsManager.ImagesDirectory, globalImageListEntry.imagePicture));
            }
            catch
            {
            }

            ImageListManipulator.DeleteEntry(globalImageListEntry.imageID);
            
            txtAddress.Text = "";
            RefreshImageBrowser();
            TreeNonImageNodeActive();
        }
        private void menuItemShowImageProp_Click(object sender, EventArgs e)
        {
            VFSEntry tempVFSEntry = new VFSEntry();
            ImageProperties ip = new ImageProperties();
            ListEntry tempListEntry;

            if (txtAddress.Text.Length == 0)
                return;

            ip.imageEntry = globalImageListEntry.Clone();
            ip.imageCategories = categories;
            ip.totalDirs = (UInt32)(virtualFS.GetTotalEntries("IsDirectory=True") - 1);
            ip.totalFiles = (UInt32)virtualFS.GetTotalEntries("IsDirectory=False");
            WndImageProperties imgPropWindow = new WndImageProperties(ip);

            tempListEntry = imgPropWindow.ShowDialog();

            if (imgPropWindow.DialogResult == DialogResult.OK)
            {
                if (!ip.imageEntry.Equals(globalImageListEntry))
                {
                    try
                    {
                        if (ip.imageEntry.imagePicture != globalImageListEntry.imagePicture)
                        {
                            if (globalImageListEntry.imagePicture != null && globalImageListEntry.imagePicture != "")
                            {
                                ClosePictureBox();
                                File.SetAttributes(Path.Combine(AppSettingsManager.ImagesDirectory, globalImageListEntry.imagePicture), FileAttributes.Archive);
                                File.Delete(Path.Combine(AppSettingsManager.ImagesDirectory, globalImageListEntry.imagePicture));
                            }
                            if (ip.imageEntry.imagePicture != null && ip.imageEntry.imagePicture != "")
                            {
                                string temp = ip.imageEntry.imageDbPath + Path.GetExtension(ip.imageEntry.imagePicture);
                                File.Copy(ip.imageEntry.imagePicture, Path.Combine(AppSettingsManager.ImagesDirectory, temp));
                                ShowPictureBox(Path.Combine(AppSettingsManager.ImagesDirectory, temp));
                                ip.imageEntry.imagePicture = temp;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show(Resources.msgPictureUpdateError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ImageListManipulator.UpdateEntry(ip.imageEntry.imageID, ip.imageEntry);
                    if (ip.imageEntry.imageName != globalImageListEntry.imageName)
                    {
                        tempVFSEntry = virtualFS.ReadEntry(0);
                        tempVFSEntry.name = ip.imageEntry.imageName;
                        virtualFS.UpdateEntry(0, tempVFSEntry);
                    }

                    globalImageListEntry = ip.imageEntry.Clone();
                    RefreshImageBrowser();
                    subMenuItemRefreshlViewVFSBrowser_Click(new object(), EventArgs.Empty);
                    UpdateBottomPanelImageInfo();
                }
            }
        }
        private void menuItemVFSItemProperties_Click(object sender, EventArgs e)
        {
            VFSEntry tempVFSEntry;
            FileTypeInfo tempFileTypeInfo;

            if (lViewVFSBrowser.SelectedItems.Count > 1)
            {
                WndVFSMultipleItemsProperties wndVFSMultipleItemsProp = new WndVFSMultipleItemsProperties(virtualFS, lViewVFSBrowser.SelectedItems, txtAddress.Text, fTypeManager);

                wndVFSMultipleItemsProp.ShowDialog();
                wndVFSMultipleItemsProp.Dispose();
            }
            else
            {
                tempVFSEntry = ((ExtendedListViewItem)lViewVFSBrowser.SelectedItems[0]).ItemVFSEntry;
                if (tempVFSEntry.isDir)
                {
                    WndVFSFolderProperties wndVFSFolderProp = new WndVFSFolderProperties(fTypeManager.GetFileTypeInfo("*dir"), virtualFS, tempVFSEntry);

                    wndVFSFolderProp.ShowDialog();
                    wndVFSFolderProp.Dispose();
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
        }
        private void menuItemAboutCDSync_Click(object sender, EventArgs e)
        {
            (new WndAboutMe()).ShowDialog();
        }
        private void menuItemCategories_Click(object sender, EventArgs e)
        {
            WndImageCategoryManager wndCategoryManager = new WndImageCategoryManager();

            wndCategoryManager.ShowDialog();

            if (wndCategoryManager.Reload)
            {
                categories = CategoryManager.GetAllCategories();
                RefreshImageBrowser();
            }
            wndCategoryManager.Dispose();
        }
        private void menuItemOptions_Click(object sender, EventArgs e)
        {
            DialogResult result;
            WndApplicationOptions wndOptions = new WndApplicationOptions();

            if (txtAddress.Text.Length > 0)
                virtualFS.CloseConnection(true);
            result = wndOptions.ShowDialog();

            if (txtAddress.Text.Length > 0)
                virtualFS.OpenConnection(Path.Combine(AppSettingsManager.ImagesDirectory, globalImageListEntry.imageDbPath));
            
            if (result == DialogResult.OK)
            {
                lViewVFSBrowser.BeginUpdate();
                lViewVFSBrowser.Columns.Clear();
                AddDetailColumns();
                lViewVFSBrowser.EndUpdate();
                if (txtAddress.Text.Length > 0)
                    subMenuItemRefreshlViewVFSBrowser_Click(sender, e);

                if (!AppSettingsManager.ShowExtendedPropertiesPanel)
                {
                    ClearExtendedPropertiesPanel();
                    viewSplitter3.Panel2Collapsed = true;
                }
                else
                    viewSplitter3.Panel2Collapsed = false;
            }
        }
        private void menuItemExportImages_Click(object sender, EventArgs e)
        {
            WndExportImages wndExportImages = new WndExportImages();
            wndExportImages.ShowDialog(new List<uint>());
        }
        private void menuItemImportImages_Click(object sender, EventArgs e)
        {
            WndImportImages wndImport = new WndImportImages();

            // Reflect the changes, if any, in the main window.
            if (wndImport.ShowDialog() == DialogResult.OK)
            {
                categories = CategoryManager.GetAllCategories();
                RefreshImageBrowser();
            }
        }
        private void menuItemExportFileList_Click(object sender, EventArgs e)
        {
            WndExportFileList wnd = new WndExportFileList(globalImageListEntry.imageName, virtualFS);

            wnd.ShowDialog();
        }
        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            lViewVFSBrowser_ItemActivate(sender, e);
        }
        private void menuItemExplore_Click(object sender, EventArgs e)
        {
            string fullPath;

            if (!imageSourceOnline)
            {
                MessageBox.Show(Resources.msgImageSourceOffline, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fullPath = globalImageListEntry.imageSourcePath;
            fullPath = Path.Combine(fullPath, txtAddress.Text.Substring(txtAddress.Text.IndexOf("\\") + 1));
            fullPath = Path.Combine(fullPath, ((ExtendedListViewItem)lViewVFSBrowser.SelectedItems[0]).ItemVFSEntry.name);

            try
            {
                if (!Directory.Exists(fullPath))
                {
                    MessageBox.Show(Resources.msgDirectoryNotFound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Process.Start(fullPath);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show("There was an error starting " + fullPath + ". The error message follows:\r\n"
                            + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            WndWaitBanner wnd = new WndWaitBanner("Deleting. Please wait...");
            if (MessageBox.Show(Resources.promptAreYouSure, "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                wnd.ShowDialogAsync();

                foreach (ExtendedListViewItem listViewItem in lViewVFSBrowser.SelectedItems)
                    virtualFS.DeleteEntry(listViewItem.ItemVFSEntry.entryNo, listViewItem.ItemVFSEntry.isDir);

                wnd.EndShowDialogAsync();

                subMenuItemRefreshlViewVFSBrowser_Click(sender, e);
            }
        }
        private void menuItemVFSItemSearch_Click(object sender, EventArgs e)
        {
            WndSearchResults wnd = new WndSearchResults((txtAddress.Text.Length == 0) ? 0 : globalImageListEntry.imageID);

            wnd.ExploreEntry += new EventHandler<ExploreEntryEventArgs>(wnd_ExploreEntry);
            wnd.FileTypeManager = fTypeManager;
            wnd.Show(this);
        }
        private void menuItemExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void menuItemEditVFSItemDescription_Click(object sender, EventArgs e)
        {
            ExtendedListViewItem item = (ExtendedListViewItem)lViewVFSBrowser.SelectedItems[0];
            VFSEntry entry = item.ItemVFSEntry;
            WndEditVFSItemDescription wnd = new WndEditVFSItemDescription(entry.description);

            if (wnd.ShowDialog() == DialogResult.OK)
            {
                entry.description = wnd.ItemDescription;
                virtualFS.UpdateEntry(entry.entryNo, entry);
                item.ItemVFSEntry = entry;

                item.ToolTipText = entry.description;
                UpdateExtendedPropertiesPanel(new ListViewItemSelectionChangedEventArgs(item, item.Index, true));
            }
        }
        private void menuItemRenameVFSItem_Click(object sender, EventArgs e)
        {
            lViewVFSBrowser.SelectedItems[0].BeginEdit();
        }
        private void subMenuItemRefreshlViewVFSBrowser_Click(object sender, EventArgs e)
        {
            ClearContents();
            ShowContents(currentLocationID);
            UpdateBottomPanelImageInfo();

            menuItemVFSItemProperties.Enabled = false;
            toolBtnVFSItemProperties.Enabled = false;
        }
        private void subMenuItemViewIcons_Click(object sender, EventArgs e)
        {
            if (lViewVFSBrowser.View != View.LargeIcon)
            {
                lViewVFSBrowser.View = View.LargeIcon;
                AppSettingsManager.BrowserViewSetting = View.LargeIcon;
            }
        }
        private void subMenuItemViewList_Click(object sender, EventArgs e)
        {
            if (lViewVFSBrowser.View != View.List)
            {
                lViewVFSBrowser.BeginUpdate();
                lViewVFSBrowser.View = View.List;
                AppSettingsManager.BrowserViewSetting = View.List;
                lViewVFSBrowser.EndUpdate();
                lViewVFSBrowser.Columns[0].Width = -1;
            }
        }
        private void subMenuItemViewDetails_Click(object sender, EventArgs e)
        {
            if (lViewVFSBrowser.View != View.Details)
            {
                lViewVFSBrowser.BeginUpdate();
                lViewVFSBrowser.View = View.Details;
                AppSettingsManager.BrowserViewSetting = View.Details;
                if (txtAddress.Text.Length > 0)
                    subMenuItemRefreshlViewVFSBrowser_Click(sender, e);
                lViewVFSBrowser.EndUpdate();
            }
        }
        private void subMenuItemlViewVFSBrowserGoUp_Click(object sender, EventArgs e)
        {
            backChain.Push(currentLocationID);
            forwardChain.Clear();

            ShowContents((uint)virtualFS.ReadEntry(currentLocationID).parentDir);

            subMenuItemlViewVFSBrowserGoForward.Enabled = false;
            toolBtnlViewVFSBrowserGoForward.Enabled = false;
        }
        private void subMenuItemlViewVFSBrowserGoToRoot_Click(object sender, EventArgs e)
        {
            backChain.Push(currentLocationID);
            forwardChain.Clear();
            ShowRootContents();

            subMenuItemlViewVFSBrowserGoForward.Enabled = false;
            toolBtnlViewVFSBrowserGoForward.Enabled = false;
        }
        private void subMenuItemlViewVFSBrowserGoBack_Click(object sender, EventArgs e)
        {
            forwardChain.Push(currentLocationID);
            ShowContents(backChain.Pop());

            subMenuItemlViewVFSBrowserGoForward.Enabled = true;
            toolBtnlViewVFSBrowserGoForward.Enabled = true;

            if (backChain.Count < 1)
            {
                subMenuItemlViewVFSBrowserGoBack.Enabled = false;
                toolBtnlViewVFSBrowserGoBack.Enabled = false;
            }
        }
        private void subMenuItemlViewVFSBrowserGoForward_Click(object sender, EventArgs e)
        {
            backChain.Push(currentLocationID);
            ShowContents(forwardChain.Pop());

            subMenuItemlViewVFSBrowserGoBack.Enabled = true;
            toolBtnlViewVFSBrowserGoBack.Enabled = true;

            if (forwardChain.Count < 1)
            {
                subMenuItemlViewVFSBrowserGoForward.Enabled = false;
                toolBtnlViewVFSBrowserGoForward.Enabled = false;
            }
        }
        private void menuItemHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.Combine(AppSettingsManager.AppInstallationDirectory, "CD Sync Help.chm"));
            }
            catch
            {
                MessageBox.Show(Resources.msgErrorOpeningHelp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menuItemEmailAuthor_Click(object sender, EventArgs e)
        {
            try { Process.Start("mailto:ankitr.42@gmail.com?subject=CD Sync Portable 1.0"); }
            catch { }
        }
        private void menuItemVisitWebsite_Click(object sender, EventArgs e)
        {
            try { Process.Start("http://ankitr.fileave.com"); }
            catch { }
        }

        #endregion

        #region Toolbar handler code
        
        private void toolBarMenuItemViewIcons_Click(object sender, EventArgs e)
        {
            subMenuItemViewIcons_Click(sender, e);
        }
        private void toolBarMenuItemViewList_Click(object sender, EventArgs e)
        {
            subMenuItemViewList_Click(sender, e);
        }
        private void toolBarMenuItemViewDetails_Click(object sender, EventArgs e)
        {
            subMenuItemViewDetails_Click(sender, e);
        }
        private void toolBtnlViewVFSBrowserGoBack_Click(object sender, EventArgs e)
        {
            subMenuItemlViewVFSBrowserGoBack_Click(sender, e);
        }
        private void toolBtnlViewVFSBrowserGoForward_Click(object sender, EventArgs e)
        {
            subMenuItemlViewVFSBrowserGoForward_Click(sender, e);
        }
        private void toolBtnlViewVFSBrowserGoUp_Click(object sender, EventArgs e)
        {
            subMenuItemlViewVFSBrowserGoUp_Click(sender, e);
        }
        private void toolBtnlViewVFSBrowserGoToRoot_Click(object sender, EventArgs e)
        {
            subMenuItemlViewVFSBrowserGoToRoot_Click(sender, e);
        }
        private void toolBtnVFSItemProperties_Click(object sender, EventArgs e)
        {
            menuItemVFSItemProperties_Click(sender, e);
        }
        private void toolBtnlViewBrowserRefresh_Click(object sender, EventArgs e)
        {
            subMenuItemRefreshlViewVFSBrowser_Click(sender, e);
        }
        private void toolBtnOptions_Click(object sender, EventArgs e)
        {
            menuItemOptions_Click(sender, e);
        }
        private void toolBtnVFSItemSearch_Click(object sender, EventArgs e)
        {
            menuItemVFSItemSearch_Click(sender, e);
        }
        private void toolBtnNewImage_Click(object sender, EventArgs e)
        {
            menuItemNewImage_Click(sender, e);
        }
        private void toolBtnDeleteImage_Click(object sender, EventArgs e)
        {
            menuItemDelImage_Click(sender, e);
        }

        #endregion
                
        #region Context menu handlers
        
        private void cMenuVFSItemProperties_Click(object sender, EventArgs e)
        {
            menuItemVFSItemProperties_Click(sender, e);
        }
        private void cMenuItemRenImage_Click(object sender, EventArgs e)
        {
            treeImageBrowser.LabelEdit = true;
            treeImageBrowser.SelectedNode.BeginEdit();
        }
        private void cMenuImageCNodeItemEditCategory_Click(object sender, EventArgs e)
        {
            ImageCategory tempImageCategory1, tempImageCategory2;
            WndEditImageCategory wndEditImageCategory;
            ListEntry tempListEntry;

            tempImageCategory1 = (ImageCategory)((ExtendedTreeNode)treeImageBrowser.SelectedNode).NodeData;
            wndEditImageCategory = new WndEditImageCategory("Modify Image Category", tempImageCategory1);

            tempImageCategory2 = wndEditImageCategory.ShowDialog();

            if (wndEditImageCategory.DialogResult == DialogResult.OK)
            {
                CategoryManager.RemoveCategory(tempImageCategory1);
                CategoryManager.AddCategory(tempImageCategory2);
                categories = CategoryManager.GetAllCategories();

                if (tempImageCategory1.categoryName != tempImageCategory2.categoryName)
                {
                    foreach (ExtendedTreeNode node in treeImageBrowser.SelectedNode.Nodes)
                    {
                        tempListEntry = (ListEntry)node.NodeData;
                        tempListEntry.imageCategory = tempImageCategory2.categoryName;

                        ImageListManipulator.UpdateEntry(tempListEntry.imageID, tempListEntry);
                    }
                }

                RefreshImageBrowser();
            }
            wndEditImageCategory.Dispose();
        }
        private void cMenuImageCNodeItemRemoveCategory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.promptImageCategoryDelete, "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CategoryManager.RemoveCategory((ImageCategory)((ExtendedTreeNode)treeImageBrowser.SelectedNode).NodeData);
                categories = CategoryManager.GetAllCategories();
                RefreshImageBrowser();
            }
        }
        private void cMenuImageCNodeItemRemoveImages_Click(object sender, EventArgs e)
        {
            ListEntry tempListEntry;
            if (MessageBox.Show(Resources.promptMemberImagesDelete, "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (ExtendedTreeNode node in treeImageBrowser.SelectedNode.Nodes)
                {
                    tempListEntry = (ListEntry)node.NodeData;

                    if (File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, tempListEntry.imageDbPath)))
                        File.Delete(Path.Combine(AppSettingsManager.ImagesDirectory, tempListEntry.imageDbPath));

                    if (File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, tempListEntry.imagePicture)))
                        File.Delete(Path.Combine(AppSettingsManager.ImagesDirectory, tempListEntry.imagePicture));

                    ImageListManipulator.DeleteEntry(tempListEntry.imageID);
                }
                RefreshImageBrowser();
            }
        }
        private void cMenuImageNodeItemExportImage_Click(object sender, EventArgs e)
        {
            List<UInt32> imageID = new List<uint>();
            
            imageID.Add(((ListEntry)((ExtendedTreeNode)treeImageBrowser.SelectedNode).NodeData).imageID);

            WndExportImages wnd = new WndExportImages();
            wnd.ShowDialog(imageID);
        }
        private void cMenuVFSBrowserItemIcons_Click(object sender, EventArgs e)
        {
            subMenuItemViewIcons_Click(sender, e);
        }
        private void cMenuVFSBrowserItemList_Click(object sender, EventArgs e)
        {
            subMenuItemViewList_Click(sender, e);
        }
        private void cMenuVFSBrowserItemDetails_Click(object sender, EventArgs e)
        {
            subMenuItemViewDetails_Click(sender, e);
        }
        private void cMenuImageCNodeItemExportImages_Click(object sender, EventArgs e)
        {
            List<UInt32> memberImages = new List<uint>();
            foreach (ExtendedTreeNode node in treeImageBrowser.SelectedNode.Nodes)
                memberImages.Add(((ListEntry)node.NodeData).imageID);

            if (memberImages.Count > 0)
            {
                WndExportImages wndExportImages = new WndExportImages();
                wndExportImages.ShowDialog(memberImages);
            }
        }
        private void cMenuVFSBrowserItemRefresh_Click(object sender, EventArgs e)
        {
            subMenuItemRefreshlViewVFSBrowser_Click(sender, e);
        }
        private void cMenuVFSBrowserItemProperties_Click(object sender, EventArgs e)
        {
            if (currentLocationID == 0)
                menuItemShowImageProp_Click(sender, e);
            else
            {
                WndVFSFolderProperties wnd = new WndVFSFolderProperties(fTypeManager.GetFileTypeInfo("*dir"),
                                                    virtualFS, virtualFS.ReadEntry(currentLocationID));
                wnd.ShowDialog();
            }
        }
        private void cMenuVFSItem_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            lViewVFSBrowser.ContextMenuStrip = cMenuVFSBrowser;
        }
        private void cMenuVFSBrowser_Opening(object sender, CancelEventArgs e)
        {
            if (txtAddress.Text.Length > 0)
            {
                cMenuVFSBrowserItemProperties.Enabled = true;
                cMenuVFSBrowserItemRefresh.Enabled = true;
            }
            else
            {
                cMenuVFSBrowserItemProperties.Enabled = false;
                cMenuVFSBrowserItemRefresh.Enabled = false;
            }
        }
        private void cMenuVFSItemExplore_Click(object sender, EventArgs e)
        {
            menuItemExplore_Click(sender, e);
        }
        private void cMenuVFSItem_Opening(object sender, CancelEventArgs e)
        {
            if (lViewVFSBrowser.SelectedItems.Count == 1)
            {
                cMenuItemVFSItemOpen.Enabled = true;
                if (!((ExtendedListViewItem)lViewVFSBrowser.SelectedItems[0]).ItemVFSEntry.isDir)
                    cMenuItemVFSItemExplore.Enabled = false;
                else
                    cMenuItemVFSItemExplore.Enabled = true;
                cMenuItemRenameVFSItem.Enabled = true;
                cMenuItemEditVFSItemDescription.Enabled = true;
            }
            else
            {
                cMenuItemVFSItemOpen.Enabled = false;
                cMenuItemVFSItemExplore.Enabled = false;
                cMenuItemRenameVFSItem.Enabled = false;
                cMenuItemEditVFSItemDescription.Enabled = false;
            }


        }
        private void cMenuImageNodeItemDelete_Click(object sender, EventArgs e)
        {
            menuItemDelImage_Click(sender, e);
        }
        private void cMenuImageNodeItemProperties_Click(object sender, EventArgs e)
        {
            menuItemShowImageProp_Click(sender, e);
        }
        private void cMenuImageNodeItemExportList_Click(object sender, EventArgs e)
        {
            menuItemExportFileList_Click(sender, e);
        }
        private void cMenuVFSItemDelete_Click(object sender, EventArgs e)
        {
            menuItemDelete_Click(sender, e);
        }
        private void cMenuVFSItemOpen_Click(object sender, EventArgs e)
        {
            menuItemOpen_Click(sender, e);
        }
        private void cMenuItemEditVFSItemDescription_Click(object sender, EventArgs e)
        {
            menuItemEditVFSItemDescription_Click(sender, e);
        }
        private void cMenuItemRenameVFSItem_Click(object sender, EventArgs e)
        {
            menuItemRenameVFSItem_Click(sender, e);
        }
        
        #endregion

        #endregion

        #region Miscellaneous Code

        private void VFSEntryProcessor(VFSEntry entry)
        {
            string imageKey, tempString;
            Icon iconL, iconS;
            ExtendedListViewItem tempExtendedListViewItem = new ExtendedListViewItem(ExtendedListViewItemType.ListViewItemTypeVFSItem);

            if ((AppSettingsManager.HideArchive && entry.isArch) ||
                (AppSettingsManager.HideReadOnly && entry.isROnly) ||
                (AppSettingsManager.HideHidden && entry.isHidden) ||
                (AppSettingsManager.HideSystem && entry.isSystem) ||
                (AppSettingsManager.HideCompressed && entry.isCompressed) ||
                (AppSettingsManager.HideEncrypted && entry.isEncrypted))
            {
                totalInvisibleObjects++;
                return;
            }

            tempExtendedListViewItem.ItemVFSEntry = entry;
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
                if (!lViewVFSBrowser.LargeImageList.Images.ContainsKey(imageKey))
                {
                    lViewVFSBrowser.LargeImageList.Images.Add(imageKey, GeneralMethods.SetImageOpacity(iconL.ToBitmap(), (float)0.5));
                    lViewVFSBrowser.SmallImageList.Images.Add(imageKey, GeneralMethods.SetImageOpacity(iconS.ToBitmap(), (float)0.5));
                }
            }
            else if (!lViewVFSBrowser.LargeImageList.Images.ContainsKey(imageKey))
            {
                lViewVFSBrowser.LargeImageList.Images.Add(imageKey, iconL.ToBitmap());
                lViewVFSBrowser.SmallImageList.Images.Add(imageKey, iconS.ToBitmap());
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
            tempExtendedListViewItem.ToolTipText = entry.description;
            if (lViewVFSBrowser.View == View.Details)
            {
                foreach (ColumnHeader column in lViewVFSBrowser.Columns)
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
            }
            lViewVFSBrowser.Items.Add(tempExtendedListViewItem);
        }
        private void ImageListEntryProcessor(ListEntry entry)
        {
            ExtendedTreeNode tempTreeNode = new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeImage, entry.imageName, (object)entry);
            tempTreeNode.Name = entry.imageID.ToString();
            tempTreeNode.ImageIndex = 2;
            tempTreeNode.SelectedImageIndex = 1;
            
            tempTreeNode.ToolTipText = "Image Source: " + entry.imageSourcePath;
            tempTreeNode.ToolTipText += Environment.NewLine + "Volume Label: " + entry.imageSourceVolLabel;
            tempTreeNode.ToolTipText += Environment.NewLine + "File System: " + entry.imageSourceFileSystem;
            tempTreeNode.ToolTipText += Environment.NewLine + "Source Type: " + ((DriveType)entry.imageSourceDriveType).ToString();
            if (entry.imageDescription.Length > 0)
                tempTreeNode.ToolTipText += Environment.NewLine + "Image Description: " + entry.imageDescription;
            tempTreeNode.ContextMenuStrip = cMenuImageNode;

            if (entry.imageCategory == "")
            {
                treeImageBrowser.Nodes[1].Nodes.Add(tempTreeNode);
                return;
            }

            foreach (ExtendedTreeNode node in treeImageBrowser.Nodes[0].Nodes)
            {
                if (node.NodeType == ExtendedTreeNodeType.NodeTypeCategory)
                {
                    if (String.Compare(((ImageCategory)node.NodeData).categoryName, entry.imageCategory, true) == 0)
                    {
                        node.Nodes.Add(tempTreeNode);
                        return;
                    }
                }
            }

            treeImageBrowser.Nodes[2].Nodes.Add(tempTreeNode);
        }
        private void ShowPictureBox(string picturePath)
        {
            try
            {
                if (File.Exists(picturePath))
                {
                    FileStream stream = File.Open(picturePath, FileMode.Open);
                    pBoxImagePicture.Image = Image.FromStream(stream);
                    viewSplitter2.Panel2Collapsed = false;
                    stream.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ClosePictureBox()
        {
            if (pBoxImagePicture.Image != null)
                pBoxImagePicture.Image.Dispose();
            viewSplitter2.Panel2Collapsed = true;
        }
        private void UpdateBottomPanelImageInfo()
        {
            if (threadImageSourceDriveTypeQuerier != null)
                if (threadImageSourceDriveTypeQuerier.IsAlive)
                    threadImageSourceDriveTypeQuerier.Abort();

            threadImageSourceDriveTypeQuerier = new Thread(new ParameterizedThreadStart(ImageSourceDriveTypeQuerier));
            threadImageSourceDriveTypeQuerier.Start(globalImageListEntry);

            statusStripLblImageInfo.Text = globalImageListEntry.imageName;
            statusStripLblImageInfo.Text += Environment.NewLine + "Source: ";
            if (globalImageListEntry.imageSourcePath.Length > 50)
                statusStripLblImageInfo.Text += GeneralMethods.TruncatePathString(globalImageListEntry.imageSourcePath, 50);
            else
                statusStripLblImageInfo.Text += globalImageListEntry.imageSourcePath;
            if (object.ReferenceEquals(treeImageBrowser.SelectedNode.Parent, treeImageBrowser.Nodes[2]))
                statusStripLblImageInfo.Text += Environment.NewLine + "Category: " + globalImageListEntry.imageCategory + " (Non-existent)";
            else if (globalImageListEntry.imageSourceVolLabel.Length > 0)
                statusStripLblImageInfo.Text += Environment.NewLine + "Volume Label: " + globalImageListEntry.imageSourceVolLabel;
            if (globalImageListEntry.imageDescription.Length > 0 && globalImageListEntry.imageDescription.Length < 50)
                statusStripLblImageInfo.Text += Environment.NewLine + "Description: " + globalImageListEntry.imageDescription;
            else if (globalImageListEntry.imageDescription.Length >= 50)
                statusStripLblImageInfo.Text += Environment.NewLine + "Description: " + globalImageListEntry.imageDescription.Substring(0, 47) + "...";
        }
        private void ImageSourceDriveTypeQuerier(object tempEntry)
        {
            ListEntry listEntry = (ListEntry)tempEntry;
            DriveInfo drvInfo = new DriveInfo(listEntry.imageSourcePath);
            Image imgOnline = Resources.unKnownOnline_64x64x32, imgOffline = Resources.unKnownOffline_64x64x32;

            switch ((DriveType)listEntry.imageSourceDriveType)
            {
                case DriveType.CDRom:
                    imgOnline = Resources.opticalDiskOnline_64x64x32;
                    imgOffline = Resources.opticalDiskOffline_64x64x32;
                    break;
                case DriveType.Fixed:
                    imgOnline = Resources.hardDiskOnline_64x64x32;
                    imgOffline = Resources.hardDiskOffline_64x64x32;
                    break;
                case DriveType.Network:
                    imgOnline = Resources.netDriveOnline_64x64x32;
                    imgOffline = Resources.netDriveOffline_64x64x32;
                    break;
                case DriveType.Removable:
                    imgOnline = Resources.removableDriveOnline_64x64x32;
                    imgOffline = Resources.removableDriveOffline_64x64x32;
                    break;
            }

            if (drvInfo.IsReady)
            {
                if (listEntry.imageSourceVolLabel == drvInfo.VolumeLabel)
                {
                    if (Directory.Exists(listEntry.imageSourcePath))
                    {
                        statusStripLblImageIcon.Image = (Image)imgOnline.Clone();
                        imageSourceOnline = true;
                    }
                    else
                    {
                        statusStripLblImageIcon.Image = (Image)imgOffline.Clone();
                        imageSourceOnline = false;
                    }
                }
                else
                {
                    statusStripLblImageIcon.Image = (Image)imgOffline.Clone();
                    imageSourceOnline = false;
                }
            }
            else
            {
                statusStripLblImageIcon.Image = (Image)imgOffline.Clone();
                imageSourceOnline = false;
            }
            if (AppSettingsManager.ShowExtendedPropertiesPanel && imageSourceOnline)
                multiPreviewer.Preview("Select a file to preview.", true, false, false);
        }

        #endregion

        private void viewSplitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            AppSettingsManager.ImageBrowserWidth = viewSplitter.SplitterDistance;
        }
        private void viewSplitter2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            AppSettingsManager.ImageBrowserHeight = viewSplitter2.SplitterDistance;
        }
        private void viewSplitter3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            AppSettingsManager.VFSBrowserHeight = viewSplitter3.SplitterDistance;
        }
        private void viewSplitter4_SplitterMoved(object sender, SplitterEventArgs e)
        {
            AppSettingsManager.ExtendedPropertiesPanelSplitterDistance = viewSplitter4.SplitterDistance;
        }
        private void WndMain_SizeChanged(object sender, EventArgs e)
        {
            AppSettingsManager.MainWindowState = this.WindowState;
            AppSettingsManager.MainWindowWidth = this.Size.Width;
            AppSettingsManager.MainWindowHeight = this.Size.Height;
        }
        private void WndMain_Move(object sender, EventArgs e)
        {
            AppSettingsManager.StartPositionX = this.Location.X;
            AppSettingsManager.StartPositionY = this.Location.Y;
        }
        private void wnd_ExploreEntry(object sender, ExploreEntryEventArgs e)
        {
            TreeNode[] nodes = treeImageBrowser.Nodes.Find(e.ParentImageID.ToString(), true);

            if (nodes.Length == 0)
            {
                MessageBox.Show("The image that contains " + e.EntryToExplore.name + " was not found.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            treeImageBrowser.SelectedNode = nodes[0];
            ShowContents((uint)e.EntryToExplore.parentDir);
            BringToFront();
            lViewVFSBrowser.FindItemWithText(AppSettingsManager.ShowExtensions ? e.EntryToExplore.name :
                                             Path.GetFileNameWithoutExtension(e.EntryToExplore.name));
        }
    }

    internal class ExtendedTreeNode : TreeNode
    {
        private ExtendedTreeNodeType nodeType;
        private object nodeData;

        /// <summary>
        /// Gets or sets the type of this node. When setting to a new value, the value of NodeData property will be
        /// set to null and must be reinitialized according to the new type.
        /// </summary>
        public ExtendedTreeNodeType NodeType
        {
            get
            {
                return nodeType;
            }
            set
            {
                if (nodeType != value)
                    nodeData = null;
                nodeType = value;
            }
        }

        /// <summary>
        /// Gets or sets the data associated with this node.
        /// Throws an exception if the type of this node is set to NodeTypeUnknown.
        /// </summary>
        public Object NodeData
        {
            get { return nodeData; }
            set
            {
                if (nodeType == ExtendedTreeNodeType.NodeTypeUnknown)
                    throw new InvalidOperationException("NodeData cannot be assigned to when the NodeType property is set to NodeTypeUnknown");
                nodeData = value;
            }
        }

        public ExtendedTreeNode()
            : base()
        {
            nodeType = ExtendedTreeNodeType.NodeTypeUnknown;
            nodeData = null;
        }

        public ExtendedTreeNode(ExtendedTreeNodeType nodeType)
            : base()
        {
            this.nodeType = nodeType;
            this.nodeData = null;
        }

        public ExtendedTreeNode(ExtendedTreeNodeType nodeType, string text)
            : base(text)
        {
            this.nodeType = nodeType;
            this.nodeData = null;
        }

        public ExtendedTreeNode(ExtendedTreeNodeType nodeType, Object nodeData)
            : base()
        {
            this.nodeType = nodeType;
            this.nodeData = nodeData;
        }

        public ExtendedTreeNode(ExtendedTreeNodeType nodeType, string text, Object nodeData)
            : base(text)
        {
            this.nodeType = nodeType;
            this.nodeData = nodeData;
        }

        public ExtendedTreeNode(ExtendedTreeNodeType nodeType, TreeNode node, Object nodeData)
        {
            this.BackColor = node.BackColor;
            this.Checked = node.Checked;
            this.ContextMenu = node.ContextMenu;
            this.ContextMenuStrip = node.ContextMenuStrip;
            this.ForeColor = node.ForeColor;
            this.ImageIndex = node.ImageIndex;
            this.ImageKey = node.ImageKey;
            this.Name = node.Name;
            this.nodeData = nodeData;
            this.NodeFont = node.NodeFont;
            this.nodeType = nodeType;
            this.SelectedImageIndex = node.SelectedImageIndex;
            this.SelectedImageKey = node.SelectedImageKey;
            this.StateImageIndex = node.StateImageIndex;
            this.StateImageKey = node.StateImageKey;
            this.Tag = node.Tag;
            this.Text = node.Text;
            this.ToolTipText = node.ToolTipText;
        }
       
        public ExtendedTreeNode(ExtendedTreeNodeType nodeType, string text, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex)
        {
            this.nodeType = nodeType;
            this.nodeData = null;
        }

        public ExtendedTreeNode(ExtendedTreeNodeType nodeType, string text, int imageIndex, int selectedImageIndex, Object nodeData)
            : base(text, imageIndex, selectedImageIndex)
        {
            this.nodeType = nodeType;
            this.nodeData = nodeData;
        }

        public override object Clone()
        {
            ExtendedTreeNode newNode = new ExtendedTreeNode(this.nodeType, this.nodeData);

            newNode.BackColor = this.BackColor;
            newNode.Checked = this.Checked;
            newNode.ContextMenu = this.ContextMenu;
            newNode.ContextMenuStrip = this.ContextMenuStrip;
            newNode.ForeColor = this.ForeColor;
            if (this.ImageIndex > -1)
                newNode.ImageIndex = this.ImageIndex;
            else
                newNode.ImageKey = this.ImageKey;
            newNode.Name = this.Name;
            newNode.NodeFont = this.NodeFont;
            if (this.SelectedImageIndex > -1)
                newNode.SelectedImageIndex = this.SelectedImageIndex;
            else
                newNode.SelectedImageKey = this.SelectedImageKey;
            if (this.StateImageIndex > -1)
                newNode.StateImageIndex = this.StateImageIndex;
            else
                newNode.StateImageKey = this.StateImageKey;
            newNode.Tag = this.Tag;
            newNode.Text = this.Text;
            newNode.ToolTipText = this.ToolTipText;

            return newNode;
        }

        public override string ToString()
        {
            return "ExtendedTreeNode";
        }
    }

    internal enum ExtendedTreeNodeType
    {
        NodeTypeUnknown=0, NodeTypeImage, NodeTypeCategory, NodeTypeSuperCategory
    };

    internal class ExtendedListViewItem : ListViewItem
    {
        private VFSEntry itemVFSEntry;
        private ExtendedListViewItemType itemType;
        private UInt32 parentImageID;
        private string fullPath;

        public VFSEntry ItemVFSEntry
        {
            get
            {
                return itemVFSEntry;
            }
            set
            {
                itemVFSEntry = value;
            }
        }

        public ExtendedListViewItemType ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                if (itemType != value)
                    parentImageID = 0;
                itemType = value;
            }
        }

        public UInt32 ParentImageID
        {
            get
            {
                return parentImageID;
            }
            set
            {
                parentImageID = value;
            }
        }

        public String FullPath
        {
            get { return fullPath; }
            set { fullPath = value; }
        }

        public ExtendedListViewItem(ExtendedListViewItemType itemType)
            : base()
        {
            this.itemType = itemType;
        }

        public ExtendedListViewItem(ExtendedListViewItemType itemType, string text)
            : base(text)
        {
            this.itemType = itemType;
        }

        public ExtendedListViewItem(ExtendedListViewItemType itemType, string text, int imageIndex)
            : base(text, imageIndex)
        {
            this.itemType = itemType;
        }

        public ExtendedListViewItem(ExtendedListViewItemType itemType, string text, string imageKey)
            : base(text, imageKey)
        {
            this.itemType = itemType;
        }

        public ExtendedListViewItem(ExtendedListViewItemType itemType, VFSEntry entry)
            : base()
        {
            this.itemType = itemType;
            itemVFSEntry = entry;
        }

        public ExtendedListViewItem(ExtendedListViewItemType itemType, string text, VFSEntry entry)
            : base(text)
        {
            this.itemType = itemType;
            itemVFSEntry = entry;
        }

        public ExtendedListViewItem(ExtendedListViewItemType itemType, UInt32 parentImageID, string text, VFSEntry entry)
            : base(text)
        {
            this.itemType = itemType;
            this.parentImageID = parentImageID;
            itemVFSEntry = entry;
        }

        public ExtendedListViewItem(ExtendedListViewItemType itemType, string text, int imageIndex, VFSEntry entry)
            : base(text, imageIndex)
        {
            this.itemType = itemType;
            itemVFSEntry = entry;
        }

        public ExtendedListViewItem(ExtendedListViewItemType itemType, string text, string imageKey, VFSEntry entry)
            : base(text, imageKey)
        {
            this.itemType = itemType;
            itemVFSEntry = entry;
        }
    }

    internal enum ExtendedListViewItemType
    {
        ListViewItemTypeSearchResult=0, ListViewItemTypeVFSItem
    };

    internal class ExtendedColumnHeader : ColumnHeader
    {
        public ExtendedColumnHeader(string name, string text, object tag)
        {
            Name = name;
            Text = text;
            Tag = tag;
        }
    }

    internal class ListViewItemComparer : System.Collections.IComparer
    {
        int colToSort;
        bool descending;
        string colType;

        public ListViewItemComparer(int col, string type, bool descending)
        {
            colToSort = col;
            this.descending = descending;
            colType = type;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            int retVal = 0;
            if (((ExtendedListViewItem)x).SubItems[colToSort].Text.Length == 0 || 
                ((ExtendedListViewItem)x).SubItems[colToSort].Text.Length == 0)
                return retVal;

            if (colType == "String")
            {
                retVal = String.Compare(((ExtendedListViewItem)x).SubItems[colToSort].Text,
                                        ((ExtendedListViewItem)y).SubItems[colToSort].Text, true);
            }
            else if (colType == "DateTime")
            {
                try
                {
                    DateTime first = DateTime.Parse(((ExtendedListViewItem)x).SubItems[colToSort].Text);
                    DateTime second = DateTime.Parse(((ExtendedListViewItem)y).SubItems[colToSort].Text);

                    retVal = DateTime.Compare(first, second);
                }
                catch
                {
                }
            }
            else if (colType == "FileSize")
            {
                string unit1 = ((ExtendedListViewItem)x).SubItems[colToSort].Text;
                string size1 = unit1;

                if (unit1.Length > 0)
                {
                    if (unit1.EndsWith("Bytes"))
                    {
                        unit1 = "Bytes";
                        size1 = size1.Substring(0, size1.Length - 6);
                    }
                    else
                    {
                        unit1 = unit1.Substring(unit1.Length - 2);
                        size1 = size1.Substring(0, size1.Length - 3);
                    }
                }
                
                string unit2 = ((ExtendedListViewItem)y).SubItems[colToSort].Text;
                string size2 = unit2;

                if (unit2.Length > 0)
                {
                    if (unit2.EndsWith("Bytes"))
                    {
                        unit2 = "Bytes";
                        size2 = size2.Substring(0, size2.Length - 6);
                    }
                    else
                    {
                        unit2 = unit2.Substring(unit2.Length - 2);
                        size2 = size2.Substring(0, size2.Length - 3);
                    }
                }

                if (unit1 == unit2)
                    retVal = String.Compare(size1, size2);
                else if (WeighFileSize(unit1) > WeighFileSize(unit2))
                    retVal = 1;
                else
                    retVal = -1;
            }
            else if (colType == "Bitrate")
            {
                string unit1 = ((ExtendedListViewItem)x).SubItems[colToSort].Text;
                string rate1 = unit1;
                if (unit1.Length > 0)
                    unit1 = unit1.Substring(unit1.Length - 4);
                string unit2 = ((ExtendedListViewItem)y).SubItems[colToSort].Text;
                string rate2 = unit2;
                if (unit2.Length > 0)
                    unit2 = unit2.Substring(unit2.Length - 4);

                if (unit1 == unit2)
                    retVal = String.Compare(rate1, rate2);
                else if (WeighBitrate(unit1) > WeighBitrate(unit2))
                    retVal = 1;
                else
                    retVal = -1;
            }
            if (descending)
                retVal *= -1;

            return retVal;
        }

        #endregion

        private int WeighFileSize(string unit)
        {
            string[] conventions = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

            for (int i=0; i < 6; i++)
            {
                if (unit == conventions[i])
                    return i;
            }
            
            return -1;
        }
        private int WeighBitrate(string unit)
        {
            string[] conventions = { "Kbps", "Mbps", "Gbps", "Tbps", "Pbps" };

            for (int i = 0; i < 5; i++)
            {
                if (unit == conventions[i])
                    return i;
            }
            return -1;
        }
    }
}