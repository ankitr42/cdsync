namespace CD_Sync_Portable
{
    partial class WndMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                virtualFS.CloseConnection(true);
                fTypeManager.Close();
                AppSettingsManager.SaveWindowMetrics();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("File Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Music Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Audio Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Video Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Image Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Document Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndMain));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripDummyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripLblImageIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripLblImageInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripLblVFSItemIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripLblVFSItemInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.viewSplitter = new System.Windows.Forms.SplitContainer();
            this.viewSplitter2 = new System.Windows.Forms.SplitContainer();
            this.treeImageBrowser = new System.Windows.Forms.TreeView();
            this.pBoxImagePicture = new System.Windows.Forms.PictureBox();
            this.viewSplitter3 = new System.Windows.Forms.SplitContainer();
            this.lViewVFSBrowser = new System.Windows.Forms.ListView();
            this.cMenuVFSBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuVFSBrowserItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuVFSBrowserItemIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuVFSBrowserItemList = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuVFSBrowserItemDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cMenuVFSBrowserItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.cMenuVFSBrowserItemProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSplitter4 = new System.Windows.Forms.SplitContainer();
            this.lViewExtendedProperties = new System.Windows.Forms.ListView();
            this.lViewColumnProperty = new System.Windows.Forms.ColumnHeader();
            this.lViewColumnValue = new System.Windows.Forms.ColumnHeader();
            this.multiPreviewer = new Customized_Controls.CustomPreviewControl();
            this.lblPreview = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVFSItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVFSItemExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRenameVFSItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditVFSItemDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemVFSItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVFSItemProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewImage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemShowProp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuGoTo = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuItemlViewVFSBrowserGoBack = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuItemlViewVFSBrowserGoForward = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuItemlViewVFSBrowserGoUp = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuItemlViewVFSBrowserGoToRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuItemRefreshlViewVFSBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuViewlViewVFSBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuItemViewIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuItemViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuItemViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVFSItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExportImages = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImportImages = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExportFileList = new System.Windows.Forms.ToolStripMenuItem();
            this.separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemEmailAuthor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVisitWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemAboutCDSync = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBtnNewImage = new System.Windows.Forms.ToolStripButton();
            this.toolBtnDeleteImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnlViewVFSBrowserGoBack = new System.Windows.Forms.ToolStripButton();
            this.toolBtnlViewVFSBrowserGoForward = new System.Windows.Forms.ToolStripButton();
            this.toolBtnlViewVFSBrowserGoUp = new System.Windows.Forms.ToolStripButton();
            this.toolBtnlViewVFSBrowserGoToRoot = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnlViewBrowserRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolBtnVFSItemProperties = new System.Windows.Forms.ToolStripButton();
            this.toolBtnVFSItemSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolMenulViewVFSBrowserView = new System.Windows.Forms.ToolStripSplitButton();
            this.toolMenuItemViewIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuItemViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarMenuItemViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBtnOptions = new System.Windows.Forms.ToolStripButton();
            this.addressBar = new System.Windows.Forms.ToolStrip();
            this.lblAddress = new System.Windows.Forms.ToolStripLabel();
            this.txtAddress = new System.Windows.Forms.ToolStripTextBox();
            this.cMenuVFSItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuItemVFSItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuItemVFSItemExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuItemRenameVFSItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuItemEditVFSItemDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cMenuItemVFSItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuItemVFSItemProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNavigatelViewVFSBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMenuImageNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuImageNodeItemExportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuImageNodeItemExportList = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuImageNodeItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuImageNodeItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.cMenuImageNodeItemProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuImageCategoryNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuImageCNodeItemEditCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuImageCNodeItemRemoveCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cMenuImageCNodeItemExportImages = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuImageCNodeItemRemoveImages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.viewSplitter.Panel1.SuspendLayout();
            this.viewSplitter.Panel2.SuspendLayout();
            this.viewSplitter.SuspendLayout();
            this.viewSplitter2.Panel1.SuspendLayout();
            this.viewSplitter2.Panel2.SuspendLayout();
            this.viewSplitter2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxImagePicture)).BeginInit();
            this.viewSplitter3.Panel1.SuspendLayout();
            this.viewSplitter3.Panel2.SuspendLayout();
            this.viewSplitter3.SuspendLayout();
            this.cMenuVFSBrowser.SuspendLayout();
            this.viewSplitter4.Panel1.SuspendLayout();
            this.viewSplitter4.Panel2.SuspendLayout();
            this.viewSplitter4.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.addressBar.SuspendLayout();
            this.cMenuVFSItem.SuspendLayout();
            this.cMenuImageNode.SuspendLayout();
            this.cMenuImageCategoryNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
            this.toolStripContainer.BottomToolStripPanel.MinimumSize = new System.Drawing.Size(0, 55);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.AutoScroll = true;
            this.toolStripContainer.ContentPanel.Controls.Add(this.viewSplitter);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(840, 317);
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.RightToolStripPanelVisible = false;
            this.toolStripContainer.Size = new System.Drawing.Size(840, 471);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.mainMenu);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.addressBar);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripDummyLabel,
            this.statusStripLblImageIcon,
            this.statusStripLblImageInfo,
            this.statusStripLblVFSItemIcon,
            this.statusStripLblVFSItemInfo});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.MinimumSize = new System.Drawing.Size(0, 66);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip.Size = new System.Drawing.Size(840, 66);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            // 
            // statusStripDummyLabel
            // 
            this.statusStripDummyLabel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.statusStripDummyLabel.Name = "statusStripDummyLabel";
            this.statusStripDummyLabel.Size = new System.Drawing.Size(13, 64);
            this.statusStripDummyLabel.Text = "  ";
            // 
            // statusStripLblImageIcon
            // 
            this.statusStripLblImageIcon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusStripLblImageIcon.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.statusStripLblImageIcon.Name = "statusStripLblImageIcon";
            this.statusStripLblImageIcon.Size = new System.Drawing.Size(13, 64);
            this.statusStripLblImageIcon.Text = "  ";
            // 
            // statusStripLblImageInfo
            // 
            this.statusStripLblImageInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusStripLblImageInfo.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.statusStripLblImageInfo.Name = "statusStripLblImageInfo";
            this.statusStripLblImageInfo.Size = new System.Drawing.Size(10, 64);
            this.statusStripLblImageInfo.Text = " ";
            this.statusStripLblImageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusStripLblImageInfo.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // statusStripLblVFSItemIcon
            // 
            this.statusStripLblVFSItemIcon.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusStripLblVFSItemIcon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusStripLblVFSItemIcon.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.statusStripLblVFSItemIcon.Name = "statusStripLblVFSItemIcon";
            this.statusStripLblVFSItemIcon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStripLblVFSItemIcon.Size = new System.Drawing.Size(13, 64);
            this.statusStripLblVFSItemIcon.Text = "  ";
            // 
            // statusStripLblVFSItemInfo
            // 
            this.statusStripLblVFSItemInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusStripLblVFSItemInfo.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.statusStripLblVFSItemInfo.Name = "statusStripLblVFSItemInfo";
            this.statusStripLblVFSItemInfo.Size = new System.Drawing.Size(19, 64);
            this.statusStripLblVFSItemInfo.Text = "    ";
            this.statusStripLblVFSItemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viewSplitter
            // 
            this.viewSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSplitter.Location = new System.Drawing.Point(0, 0);
            this.viewSplitter.Name = "viewSplitter";
            // 
            // viewSplitter.Panel1
            // 
            this.viewSplitter.Panel1.Controls.Add(this.viewSplitter2);
            // 
            // viewSplitter.Panel2
            // 
            this.viewSplitter.Panel2.Controls.Add(this.viewSplitter3);
            this.viewSplitter.Size = new System.Drawing.Size(840, 317);
            this.viewSplitter.SplitterDistance = 214;
            this.viewSplitter.TabIndex = 1;
            // 
            // viewSplitter2
            // 
            this.viewSplitter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSplitter2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.viewSplitter2.Location = new System.Drawing.Point(0, 0);
            this.viewSplitter2.Name = "viewSplitter2";
            this.viewSplitter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // viewSplitter2.Panel1
            // 
            this.viewSplitter2.Panel1.Controls.Add(this.treeImageBrowser);
            // 
            // viewSplitter2.Panel2
            // 
            this.viewSplitter2.Panel2.Controls.Add(this.pBoxImagePicture);
            this.viewSplitter2.Panel2Collapsed = true;
            this.viewSplitter2.Size = new System.Drawing.Size(214, 317);
            this.viewSplitter2.TabIndex = 1;
            // 
            // treeImageBrowser
            // 
            this.treeImageBrowser.AllowDrop = true;
            this.treeImageBrowser.BackColor = System.Drawing.SystemColors.Window;
            this.treeImageBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeImageBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeImageBrowser.Location = new System.Drawing.Point(0, 0);
            this.treeImageBrowser.Name = "treeImageBrowser";
            this.treeImageBrowser.ShowNodeToolTips = true;
            this.treeImageBrowser.Size = new System.Drawing.Size(214, 317);
            this.treeImageBrowser.TabIndex = 0;
            this.treeImageBrowser.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeImageBrowser_AfterLabelEdit);
            this.treeImageBrowser.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeImageBrowser_DragDrop);
            this.treeImageBrowser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeImageBrowser_AfterSelect);
            this.treeImageBrowser.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeImageBrowser_DragEnter);
            this.treeImageBrowser.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeImageBrowser_NodeMouseClick);
            this.treeImageBrowser.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeImageBrowser_ItemDrag);
            // 
            // pBoxImagePicture
            // 
            this.pBoxImagePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxImagePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxImagePicture.Location = new System.Drawing.Point(0, 0);
            this.pBoxImagePicture.Name = "pBoxImagePicture";
            this.pBoxImagePicture.Size = new System.Drawing.Size(150, 46);
            this.pBoxImagePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxImagePicture.TabIndex = 1;
            this.pBoxImagePicture.TabStop = false;
            // 
            // viewSplitter3
            // 
            this.viewSplitter3.BackColor = System.Drawing.Color.Transparent;
            this.viewSplitter3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSplitter3.Location = new System.Drawing.Point(0, 0);
            this.viewSplitter3.Name = "viewSplitter3";
            this.viewSplitter3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // viewSplitter3.Panel1
            // 
            this.viewSplitter3.Panel1.Controls.Add(this.lViewVFSBrowser);
            // 
            // viewSplitter3.Panel2
            // 
            this.viewSplitter3.Panel2.Controls.Add(this.viewSplitter4);
            this.viewSplitter3.Size = new System.Drawing.Size(622, 317);
            this.viewSplitter3.SplitterDistance = 158;
            this.viewSplitter3.TabIndex = 0;
            // 
            // lViewVFSBrowser
            // 
            this.lViewVFSBrowser.AllowColumnReorder = true;
            this.lViewVFSBrowser.BackColor = System.Drawing.SystemColors.Window;
            this.lViewVFSBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lViewVFSBrowser.ContextMenuStrip = this.cMenuVFSBrowser;
            this.lViewVFSBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lViewVFSBrowser.FullRowSelect = true;
            this.lViewVFSBrowser.HideSelection = false;
            this.lViewVFSBrowser.LabelEdit = true;
            this.lViewVFSBrowser.Location = new System.Drawing.Point(0, 0);
            this.lViewVFSBrowser.Name = "lViewVFSBrowser";
            this.lViewVFSBrowser.ShowItemToolTips = true;
            this.lViewVFSBrowser.Size = new System.Drawing.Size(622, 158);
            this.lViewVFSBrowser.TabIndex = 0;
            this.lViewVFSBrowser.UseCompatibleStateImageBehavior = false;
            this.lViewVFSBrowser.ItemActivate += new System.EventHandler(this.lViewVFSBrowser_ItemActivate);
            this.lViewVFSBrowser.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lViewVFSBrowser_MouseClick);
            this.lViewVFSBrowser.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lViewVFSBrowser_AfterLabelEdit);
            this.lViewVFSBrowser.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lViewVFSBrowser_ColumnClick);
            this.lViewVFSBrowser.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lViewVFSBrowser_ItemSelectionChanged);
            this.lViewVFSBrowser.SystemColorsChanged += new System.EventHandler(this.lViewVFSBrowser_SystemColorsChanged);
            // 
            // cMenuVFSBrowser
            // 
            this.cMenuVFSBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuVFSBrowserItemView,
            this.toolStripSeparator6,
            this.cMenuVFSBrowserItemRefresh,
            this.toolStripSeparator7,
            this.cMenuVFSBrowserItemProperties});
            this.cMenuVFSBrowser.Name = "cMenuVFSBrowser";
            this.cMenuVFSBrowser.Size = new System.Drawing.Size(128, 82);
            this.cMenuVFSBrowser.Opening += new System.ComponentModel.CancelEventHandler(this.cMenuVFSBrowser_Opening);
            // 
            // cMenuVFSBrowserItemView
            // 
            this.cMenuVFSBrowserItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuVFSBrowserItemIcons,
            this.cMenuVFSBrowserItemList,
            this.cMenuVFSBrowserItemDetails});
            this.cMenuVFSBrowserItemView.Name = "cMenuVFSBrowserItemView";
            this.cMenuVFSBrowserItemView.Size = new System.Drawing.Size(127, 22);
            this.cMenuVFSBrowserItemView.Text = "&View";
            // 
            // cMenuVFSBrowserItemIcons
            // 
            this.cMenuVFSBrowserItemIcons.Name = "cMenuVFSBrowserItemIcons";
            this.cMenuVFSBrowserItemIcons.Size = new System.Drawing.Size(109, 22);
            this.cMenuVFSBrowserItemIcons.Text = "&Icons";
            this.cMenuVFSBrowserItemIcons.Click += new System.EventHandler(this.cMenuVFSBrowserItemIcons_Click);
            // 
            // cMenuVFSBrowserItemList
            // 
            this.cMenuVFSBrowserItemList.Name = "cMenuVFSBrowserItemList";
            this.cMenuVFSBrowserItemList.Size = new System.Drawing.Size(109, 22);
            this.cMenuVFSBrowserItemList.Text = "&List";
            this.cMenuVFSBrowserItemList.Click += new System.EventHandler(this.cMenuVFSBrowserItemList_Click);
            // 
            // cMenuVFSBrowserItemDetails
            // 
            this.cMenuVFSBrowserItemDetails.Name = "cMenuVFSBrowserItemDetails";
            this.cMenuVFSBrowserItemDetails.Size = new System.Drawing.Size(109, 22);
            this.cMenuVFSBrowserItemDetails.Text = "&Details";
            this.cMenuVFSBrowserItemDetails.Click += new System.EventHandler(this.cMenuVFSBrowserItemDetails_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(124, 6);
            // 
            // cMenuVFSBrowserItemRefresh
            // 
            this.cMenuVFSBrowserItemRefresh.Image = global::CD_Sync_Portable.Properties.Resources.browser_refresh_16x16x32;
            this.cMenuVFSBrowserItemRefresh.Name = "cMenuVFSBrowserItemRefresh";
            this.cMenuVFSBrowserItemRefresh.Size = new System.Drawing.Size(127, 22);
            this.cMenuVFSBrowserItemRefresh.Text = "&Refresh";
            this.cMenuVFSBrowserItemRefresh.Click += new System.EventHandler(this.cMenuVFSBrowserItemRefresh_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(124, 6);
            // 
            // cMenuVFSBrowserItemProperties
            // 
            this.cMenuVFSBrowserItemProperties.Image = global::CD_Sync_Portable.Properties.Resources.properties_16x16x32;
            this.cMenuVFSBrowserItemProperties.Name = "cMenuVFSBrowserItemProperties";
            this.cMenuVFSBrowserItemProperties.Size = new System.Drawing.Size(127, 22);
            this.cMenuVFSBrowserItemProperties.Text = "&Properties";
            this.cMenuVFSBrowserItemProperties.Click += new System.EventHandler(this.cMenuVFSBrowserItemProperties_Click);
            // 
            // viewSplitter4
            // 
            this.viewSplitter4.BackColor = System.Drawing.SystemColors.Control;
            this.viewSplitter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewSplitter4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSplitter4.Location = new System.Drawing.Point(0, 0);
            this.viewSplitter4.Name = "viewSplitter4";
            // 
            // viewSplitter4.Panel1
            // 
            this.viewSplitter4.Panel1.Controls.Add(this.lViewExtendedProperties);
            // 
            // viewSplitter4.Panel2
            // 
            this.viewSplitter4.Panel2.Controls.Add(this.multiPreviewer);
            this.viewSplitter4.Panel2.Controls.Add(this.lblPreview);
            this.viewSplitter4.Size = new System.Drawing.Size(622, 155);
            this.viewSplitter4.SplitterDistance = 306;
            this.viewSplitter4.TabIndex = 0;
            // 
            // lViewExtendedProperties
            // 
            this.lViewExtendedProperties.BackColor = System.Drawing.SystemColors.Control;
            this.lViewExtendedProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lViewExtendedProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lViewColumnProperty,
            this.lViewColumnValue});
            this.lViewExtendedProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lViewExtendedProperties.FullRowSelect = true;
            listViewGroup1.Header = "File Properties";
            listViewGroup1.Name = "lViewGroupFile";
            listViewGroup2.Header = "Music Properties";
            listViewGroup2.Name = "lViewGroupMusic";
            listViewGroup3.Header = "Audio Properties";
            listViewGroup3.Name = "lViewGroupAudio";
            listViewGroup4.Header = "Video Properties";
            listViewGroup4.Name = "lViewGroupVideo";
            listViewGroup5.Header = "Image Properties";
            listViewGroup5.Name = "lViewGroupImage";
            listViewGroup6.Header = "Document Properties";
            listViewGroup6.Name = "lViewGroupDocument";
            this.lViewExtendedProperties.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            this.lViewExtendedProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lViewExtendedProperties.Location = new System.Drawing.Point(0, 0);
            this.lViewExtendedProperties.MultiSelect = false;
            this.lViewExtendedProperties.Name = "lViewExtendedProperties";
            this.lViewExtendedProperties.Size = new System.Drawing.Size(304, 153);
            this.lViewExtendedProperties.TabIndex = 0;
            this.lViewExtendedProperties.UseCompatibleStateImageBehavior = false;
            this.lViewExtendedProperties.View = System.Windows.Forms.View.Details;
            // 
            // lViewColumnProperty
            // 
            this.lViewColumnProperty.Text = "Property";
            // 
            // lViewColumnValue
            // 
            this.lViewColumnValue.Text = "Value";
            this.lViewColumnValue.Width = 71;
            // 
            // multiPreviewer
            // 
            this.multiPreviewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiPreviewer.FileNotFoundNotice = "The file was not found.";
            this.multiPreviewer.GeneratingPreviewNotice = "Generating preview...";
            this.multiPreviewer.InvalidFileTypeNotice = "Preview not available.";
            this.multiPreviewer.Location = new System.Drawing.Point(0, 0);
            this.multiPreviewer.Name = "multiPreviewer";
            this.multiPreviewer.PreviewErrorNotice = "There was an error generating the preview.";
            this.multiPreviewer.Size = new System.Drawing.Size(310, 153);
            this.multiPreviewer.TabIndex = 0;
            // 
            // lblPreview
            // 
            this.lblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreview.Location = new System.Drawing.Point(0, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(310, 153);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainMenu
            // 
            this.mainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuImage,
            this.menuView,
            this.menuTools,
            this.menuHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(840, 24);
            this.mainMenu.TabIndex = 0;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVFSItemOpen,
            this.menuItemVFSItemExplore,
            this.menuItemRenameVFSItem,
            this.menuItemEditVFSItemDescription,
            this.toolStripSeparator3,
            this.menuItemVFSItemDelete,
            this.menuItemVFSItemProperties,
            this.toolStripSeparator5,
            this.menuItemExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuItemVFSItemOpen
            // 
            this.menuItemVFSItemOpen.Enabled = false;
            this.menuItemVFSItemOpen.Name = "menuItemVFSItemOpen";
            this.menuItemVFSItemOpen.Size = new System.Drawing.Size(157, 22);
            this.menuItemVFSItemOpen.Text = "&Open";
            this.menuItemVFSItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemVFSItemExplore
            // 
            this.menuItemVFSItemExplore.Enabled = false;
            this.menuItemVFSItemExplore.Image = global::CD_Sync_Portable.Properties.Resources.explore_16x16x32;
            this.menuItemVFSItemExplore.Name = "menuItemVFSItemExplore";
            this.menuItemVFSItemExplore.Size = new System.Drawing.Size(157, 22);
            this.menuItemVFSItemExplore.Text = "&Explore";
            this.menuItemVFSItemExplore.Click += new System.EventHandler(this.menuItemExplore_Click);
            // 
            // menuItemRenameVFSItem
            // 
            this.menuItemRenameVFSItem.Enabled = false;
            this.menuItemRenameVFSItem.Name = "menuItemRenameVFSItem";
            this.menuItemRenameVFSItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuItemRenameVFSItem.ShowShortcutKeys = false;
            this.menuItemRenameVFSItem.Size = new System.Drawing.Size(157, 22);
            this.menuItemRenameVFSItem.Text = "&Rename";
            this.menuItemRenameVFSItem.Click += new System.EventHandler(this.menuItemRenameVFSItem_Click);
            // 
            // menuItemEditVFSItemDescription
            // 
            this.menuItemEditVFSItemDescription.Enabled = false;
            this.menuItemEditVFSItemDescription.Image = global::CD_Sync_Portable.Properties.Resources.edit_description_16x16x32;
            this.menuItemEditVFSItemDescription.Name = "menuItemEditVFSItemDescription";
            this.menuItemEditVFSItemDescription.Size = new System.Drawing.Size(157, 22);
            this.menuItemEditVFSItemDescription.Text = "E&dit Description";
            this.menuItemEditVFSItemDescription.Click += new System.EventHandler(this.menuItemEditVFSItemDescription_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(154, 6);
            // 
            // menuItemVFSItemDelete
            // 
            this.menuItemVFSItemDelete.Enabled = false;
            this.menuItemVFSItemDelete.Image = global::CD_Sync_Portable.Properties.Resources.del_16x16x32;
            this.menuItemVFSItemDelete.Name = "menuItemVFSItemDelete";
            this.menuItemVFSItemDelete.Size = new System.Drawing.Size(157, 22);
            this.menuItemVFSItemDelete.Text = "De&lete";
            this.menuItemVFSItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // menuItemVFSItemProperties
            // 
            this.menuItemVFSItemProperties.Enabled = false;
            this.menuItemVFSItemProperties.Image = global::CD_Sync_Portable.Properties.Resources.properties_16x16x32;
            this.menuItemVFSItemProperties.Name = "menuItemVFSItemProperties";
            this.menuItemVFSItemProperties.Size = new System.Drawing.Size(157, 22);
            this.menuItemVFSItemProperties.Text = "&Item Properties";
            this.menuItemVFSItemProperties.Click += new System.EventHandler(this.menuItemVFSItemProperties_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(154, 6);
            // 
            // menuItemExitApp
            // 
            this.menuItemExitApp.Name = "menuItemExitApp";
            this.menuItemExitApp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuItemExitApp.Size = new System.Drawing.Size(157, 22);
            this.menuItemExitApp.Text = "E&xit";
            this.menuItemExitApp.Click += new System.EventHandler(this.menuItemExitApp_Click);
            // 
            // menuImage
            // 
            this.menuImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewImage,
            this.menuItemDelImage,
            this.toolStripSeparator9,
            this.menuItemShowProp});
            this.menuImage.Name = "menuImage";
            this.menuImage.Size = new System.Drawing.Size(52, 20);
            this.menuImage.Text = "&Image";
            // 
            // menuItemNewImage
            // 
            this.menuItemNewImage.Image = global::CD_Sync_Portable.Properties.Resources.new_image_16x16x32;
            this.menuItemNewImage.Name = "menuItemNewImage";
            this.menuItemNewImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuItemNewImage.Size = new System.Drawing.Size(204, 22);
            this.menuItemNewImage.Text = "&New Image";
            this.menuItemNewImage.Click += new System.EventHandler(this.menuItemNewImage_Click);
            // 
            // menuItemDelImage
            // 
            this.menuItemDelImage.Enabled = false;
            this.menuItemDelImage.Image = global::CD_Sync_Portable.Properties.Resources.image_delete_16x16x32;
            this.menuItemDelImage.Name = "menuItemDelImage";
            this.menuItemDelImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.menuItemDelImage.Size = new System.Drawing.Size(204, 22);
            this.menuItemDelImage.Text = "&Delete Image";
            this.menuItemDelImage.Click += new System.EventHandler(this.menuItemDelImage_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(201, 6);
            // 
            // menuItemShowProp
            // 
            this.menuItemShowProp.Enabled = false;
            this.menuItemShowProp.Image = global::CD_Sync_Portable.Properties.Resources.image_properties_16x16x32;
            this.menuItemShowProp.Name = "menuItemShowProp";
            this.menuItemShowProp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuItemShowProp.Size = new System.Drawing.Size(204, 22);
            this.menuItemShowProp.Text = "&Image Properties";
            this.menuItemShowProp.Click += new System.EventHandler(this.menuItemShowImageProp_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuBrowser});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // subMenuBrowser
            // 
            this.subMenuBrowser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuGoTo,
            this.subMenuItemRefreshlViewVFSBrowser,
            this.subMenuViewlViewVFSBrowser});
            this.subMenuBrowser.Name = "subMenuBrowser";
            this.subMenuBrowser.Size = new System.Drawing.Size(116, 22);
            this.subMenuBrowser.Text = "&Browser";
            // 
            // subMenuGoTo
            // 
            this.subMenuGoTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuItemlViewVFSBrowserGoBack,
            this.subMenuItemlViewVFSBrowserGoForward,
            this.subMenuItemlViewVFSBrowserGoUp,
            this.subMenuItemlViewVFSBrowserGoToRoot});
            this.subMenuGoTo.Name = "subMenuGoTo";
            this.subMenuGoTo.Size = new System.Drawing.Size(132, 22);
            this.subMenuGoTo.Text = "&Go";
            // 
            // subMenuItemlViewVFSBrowserGoBack
            // 
            this.subMenuItemlViewVFSBrowserGoBack.Enabled = false;
            this.subMenuItemlViewVFSBrowserGoBack.Image = global::CD_Sync_Portable.Properties.Resources.back_16x16x32;
            this.subMenuItemlViewVFSBrowserGoBack.Name = "subMenuItemlViewVFSBrowserGoBack";
            this.subMenuItemlViewVFSBrowserGoBack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left)));
            this.subMenuItemlViewVFSBrowserGoBack.Size = new System.Drawing.Size(175, 22);
            this.subMenuItemlViewVFSBrowserGoBack.Text = "Back";
            this.subMenuItemlViewVFSBrowserGoBack.Click += new System.EventHandler(this.subMenuItemlViewVFSBrowserGoBack_Click);
            // 
            // subMenuItemlViewVFSBrowserGoForward
            // 
            this.subMenuItemlViewVFSBrowserGoForward.Enabled = false;
            this.subMenuItemlViewVFSBrowserGoForward.Image = global::CD_Sync_Portable.Properties.Resources.forward_16x16x32;
            this.subMenuItemlViewVFSBrowserGoForward.Name = "subMenuItemlViewVFSBrowserGoForward";
            this.subMenuItemlViewVFSBrowserGoForward.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right)));
            this.subMenuItemlViewVFSBrowserGoForward.Size = new System.Drawing.Size(175, 22);
            this.subMenuItemlViewVFSBrowserGoForward.Text = "Forward";
            this.subMenuItemlViewVFSBrowserGoForward.Click += new System.EventHandler(this.subMenuItemlViewVFSBrowserGoForward_Click);
            // 
            // subMenuItemlViewVFSBrowserGoUp
            // 
            this.subMenuItemlViewVFSBrowserGoUp.Enabled = false;
            this.subMenuItemlViewVFSBrowserGoUp.Image = global::CD_Sync_Portable.Properties.Resources.browser_up_16x16x32;
            this.subMenuItemlViewVFSBrowserGoUp.Name = "subMenuItemlViewVFSBrowserGoUp";
            this.subMenuItemlViewVFSBrowserGoUp.Size = new System.Drawing.Size(175, 22);
            this.subMenuItemlViewVFSBrowserGoUp.Text = "&Up One Level";
            this.subMenuItemlViewVFSBrowserGoUp.Click += new System.EventHandler(this.subMenuItemlViewVFSBrowserGoUp_Click);
            // 
            // subMenuItemlViewVFSBrowserGoToRoot
            // 
            this.subMenuItemlViewVFSBrowserGoToRoot.Enabled = false;
            this.subMenuItemlViewVFSBrowserGoToRoot.Image = global::CD_Sync_Portable.Properties.Resources.browser_root_16x16x32;
            this.subMenuItemlViewVFSBrowserGoToRoot.Name = "subMenuItemlViewVFSBrowserGoToRoot";
            this.subMenuItemlViewVFSBrowserGoToRoot.Size = new System.Drawing.Size(175, 22);
            this.subMenuItemlViewVFSBrowserGoToRoot.Text = "&Root";
            this.subMenuItemlViewVFSBrowserGoToRoot.Click += new System.EventHandler(this.subMenuItemlViewVFSBrowserGoToRoot_Click);
            // 
            // subMenuItemRefreshlViewVFSBrowser
            // 
            this.subMenuItemRefreshlViewVFSBrowser.Enabled = false;
            this.subMenuItemRefreshlViewVFSBrowser.Image = global::CD_Sync_Portable.Properties.Resources.browser_refresh_16x16x32;
            this.subMenuItemRefreshlViewVFSBrowser.Name = "subMenuItemRefreshlViewVFSBrowser";
            this.subMenuItemRefreshlViewVFSBrowser.ShortcutKeyDisplayString = "";
            this.subMenuItemRefreshlViewVFSBrowser.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.subMenuItemRefreshlViewVFSBrowser.Size = new System.Drawing.Size(132, 22);
            this.subMenuItemRefreshlViewVFSBrowser.Text = "&Refresh";
            this.subMenuItemRefreshlViewVFSBrowser.Click += new System.EventHandler(this.subMenuItemRefreshlViewVFSBrowser_Click);
            // 
            // subMenuViewlViewVFSBrowser
            // 
            this.subMenuViewlViewVFSBrowser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuItemViewIcons,
            this.subMenuItemViewList,
            this.subMenuItemViewDetails});
            this.subMenuViewlViewVFSBrowser.Name = "subMenuViewlViewVFSBrowser";
            this.subMenuViewlViewVFSBrowser.Size = new System.Drawing.Size(132, 22);
            this.subMenuViewlViewVFSBrowser.Text = "&View";
            // 
            // subMenuItemViewIcons
            // 
            this.subMenuItemViewIcons.Name = "subMenuItemViewIcons";
            this.subMenuItemViewIcons.Size = new System.Drawing.Size(109, 22);
            this.subMenuItemViewIcons.Text = "&Icons";
            this.subMenuItemViewIcons.Click += new System.EventHandler(this.subMenuItemViewIcons_Click);
            // 
            // subMenuItemViewList
            // 
            this.subMenuItemViewList.Name = "subMenuItemViewList";
            this.subMenuItemViewList.Size = new System.Drawing.Size(109, 22);
            this.subMenuItemViewList.Text = "&List";
            this.subMenuItemViewList.Click += new System.EventHandler(this.subMenuItemViewList_Click);
            // 
            // subMenuItemViewDetails
            // 
            this.subMenuItemViewDetails.Name = "subMenuItemViewDetails";
            this.subMenuItemViewDetails.Size = new System.Drawing.Size(109, 22);
            this.subMenuItemViewDetails.Text = "&Details";
            this.subMenuItemViewDetails.Click += new System.EventHandler(this.subMenuItemViewDetails_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVFSItemSearch,
            this.toolStripSeparator10,
            this.menuItemExportImages,
            this.menuItemImportImages,
            this.menuItemExportFileList,
            this.separator4,
            this.menuItemCategories,
            this.menuItemOptions});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(48, 20);
            this.menuTools.Text = "&Tools";
            // 
            // menuItemVFSItemSearch
            // 
            this.menuItemVFSItemSearch.Image = global::CD_Sync_Portable.Properties.Resources.search_16x16x32;
            this.menuItemVFSItemSearch.Name = "menuItemVFSItemSearch";
            this.menuItemVFSItemSearch.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuItemVFSItemSearch.Size = new System.Drawing.Size(207, 22);
            this.menuItemVFSItemSearch.Text = "&Search";
            this.menuItemVFSItemSearch.Click += new System.EventHandler(this.menuItemVFSItemSearch_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(204, 6);
            // 
            // menuItemExportImages
            // 
            this.menuItemExportImages.Image = global::CD_Sync_Portable.Properties.Resources.export_16x16x32;
            this.menuItemExportImages.Name = "menuItemExportImages";
            this.menuItemExportImages.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.menuItemExportImages.Size = new System.Drawing.Size(207, 22);
            this.menuItemExportImages.Text = "&Export Images";
            this.menuItemExportImages.Click += new System.EventHandler(this.menuItemExportImages_Click);
            // 
            // menuItemImportImages
            // 
            this.menuItemImportImages.Image = global::CD_Sync_Portable.Properties.Resources.import_16x16x32;
            this.menuItemImportImages.Name = "menuItemImportImages";
            this.menuItemImportImages.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.menuItemImportImages.Size = new System.Drawing.Size(207, 22);
            this.menuItemImportImages.Text = "&Import Images";
            this.menuItemImportImages.Click += new System.EventHandler(this.menuItemImportImages_Click);
            // 
            // menuItemExportFileList
            // 
            this.menuItemExportFileList.Enabled = false;
            this.menuItemExportFileList.Name = "menuItemExportFileList";
            this.menuItemExportFileList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuItemExportFileList.Size = new System.Drawing.Size(207, 22);
            this.menuItemExportFileList.Text = "Export &Filelist";
            this.menuItemExportFileList.Click += new System.EventHandler(this.menuItemExportFileList_Click);
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            this.separator4.Size = new System.Drawing.Size(204, 6);
            // 
            // menuItemCategories
            // 
            this.menuItemCategories.Name = "menuItemCategories";
            this.menuItemCategories.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuItemCategories.Size = new System.Drawing.Size(207, 22);
            this.menuItemCategories.Text = "&Image Categories";
            this.menuItemCategories.Click += new System.EventHandler(this.menuItemCategories_Click);
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.Image = global::CD_Sync_Portable.Properties.Resources.configure_16x16x32;
            this.menuItemOptions.Name = "menuItemOptions";
            this.menuItemOptions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemOptions.Size = new System.Drawing.Size(207, 22);
            this.menuItemOptions.Text = "&Options";
            this.menuItemOptions.Click += new System.EventHandler(this.menuItemOptions_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHelp,
            this.separator2,
            this.menuItemEmailAuthor,
            this.menuItemVisitWebsite,
            this.toolStripSeparator13,
            this.menuItemAboutCDSync});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "&Help";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Image = global::CD_Sync_Portable.Properties.Resources.help_16x16x32;
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuItemHelp.Size = new System.Drawing.Size(149, 22);
            this.menuItemHelp.Text = "&Help";
            this.menuItemHelp.Click += new System.EventHandler(this.menuItemHelp_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(146, 6);
            // 
            // menuItemEmailAuthor
            // 
            this.menuItemEmailAuthor.Name = "menuItemEmailAuthor";
            this.menuItemEmailAuthor.Size = new System.Drawing.Size(149, 22);
            this.menuItemEmailAuthor.Text = "&E-Mail Author";
            this.menuItemEmailAuthor.Click += new System.EventHandler(this.menuItemEmailAuthor_Click);
            // 
            // menuItemVisitWebsite
            // 
            this.menuItemVisitWebsite.Name = "menuItemVisitWebsite";
            this.menuItemVisitWebsite.Size = new System.Drawing.Size(149, 22);
            this.menuItemVisitWebsite.Text = "&Visit Website";
            this.menuItemVisitWebsite.Click += new System.EventHandler(this.menuItemVisitWebsite_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(146, 6);
            // 
            // menuItemAboutCDSync
            // 
            this.menuItemAboutCDSync.Name = "menuItemAboutCDSync";
            this.menuItemAboutCDSync.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuItemAboutCDSync.Size = new System.Drawing.Size(149, 22);
            this.menuItemAboutCDSync.Text = "&About";
            this.menuItemAboutCDSync.Click += new System.EventHandler(this.menuItemAboutCDSync_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AllowItemReorder = true;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnNewImage,
            this.toolBtnDeleteImage,
            this.toolStripSeparator12,
            this.toolBtnlViewVFSBrowserGoBack,
            this.toolBtnlViewVFSBrowserGoForward,
            this.toolBtnlViewVFSBrowserGoUp,
            this.toolBtnlViewVFSBrowserGoToRoot,
            this.toolStripSeparator1,
            this.toolBtnlViewBrowserRefresh,
            this.toolBtnVFSItemProperties,
            this.toolBtnVFSItemSearch,
            this.toolStripSeparator2,
            this.toolMenulViewVFSBrowserView,
            this.toolBtnOptions});
            this.toolStrip.Location = new System.Drawing.Point(3, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(837, 39);
            this.toolStrip.TabIndex = 1;
            // 
            // toolBtnNewImage
            // 
            this.toolBtnNewImage.Image = global::CD_Sync_Portable.Properties.Resources.new_image_32x32x32;
            this.toolBtnNewImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnNewImage.Name = "toolBtnNewImage";
            this.toolBtnNewImage.Size = new System.Drawing.Size(67, 36);
            this.toolBtnNewImage.Text = "New";
            this.toolBtnNewImage.Click += new System.EventHandler(this.toolBtnNewImage_Click);
            // 
            // toolBtnDeleteImage
            // 
            this.toolBtnDeleteImage.Enabled = false;
            this.toolBtnDeleteImage.Image = global::CD_Sync_Portable.Properties.Resources.image_delete_32x32x32;
            this.toolBtnDeleteImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDeleteImage.Name = "toolBtnDeleteImage";
            this.toolBtnDeleteImage.Size = new System.Drawing.Size(76, 36);
            this.toolBtnDeleteImage.Text = "Delete";
            this.toolBtnDeleteImage.Click += new System.EventHandler(this.toolBtnDeleteImage_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnlViewVFSBrowserGoBack
            // 
            this.toolBtnlViewVFSBrowserGoBack.Enabled = false;
            this.toolBtnlViewVFSBrowserGoBack.Image = global::CD_Sync_Portable.Properties.Resources.back_48x48x32;
            this.toolBtnlViewVFSBrowserGoBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnlViewVFSBrowserGoBack.Name = "toolBtnlViewVFSBrowserGoBack";
            this.toolBtnlViewVFSBrowserGoBack.Size = new System.Drawing.Size(68, 36);
            this.toolBtnlViewVFSBrowserGoBack.Text = "Back";
            this.toolBtnlViewVFSBrowserGoBack.Click += new System.EventHandler(this.toolBtnlViewVFSBrowserGoBack_Click);
            // 
            // toolBtnlViewVFSBrowserGoForward
            // 
            this.toolBtnlViewVFSBrowserGoForward.Enabled = false;
            this.toolBtnlViewVFSBrowserGoForward.Image = global::CD_Sync_Portable.Properties.Resources.forward_32x32x32;
            this.toolBtnlViewVFSBrowserGoForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnlViewVFSBrowserGoForward.Name = "toolBtnlViewVFSBrowserGoForward";
            this.toolBtnlViewVFSBrowserGoForward.Size = new System.Drawing.Size(86, 36);
            this.toolBtnlViewVFSBrowserGoForward.Text = "Forward";
            this.toolBtnlViewVFSBrowserGoForward.Click += new System.EventHandler(this.toolBtnlViewVFSBrowserGoForward_Click);
            // 
            // toolBtnlViewVFSBrowserGoUp
            // 
            this.toolBtnlViewVFSBrowserGoUp.Enabled = false;
            this.toolBtnlViewVFSBrowserGoUp.Image = global::CD_Sync_Portable.Properties.Resources.browser_up_24x24x32;
            this.toolBtnlViewVFSBrowserGoUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnlViewVFSBrowserGoUp.Name = "toolBtnlViewVFSBrowserGoUp";
            this.toolBtnlViewVFSBrowserGoUp.Size = new System.Drawing.Size(58, 36);
            this.toolBtnlViewVFSBrowserGoUp.Text = "Up";
            this.toolBtnlViewVFSBrowserGoUp.Click += new System.EventHandler(this.toolBtnlViewVFSBrowserGoUp_Click);
            // 
            // toolBtnlViewVFSBrowserGoToRoot
            // 
            this.toolBtnlViewVFSBrowserGoToRoot.Enabled = false;
            this.toolBtnlViewVFSBrowserGoToRoot.Image = global::CD_Sync_Portable.Properties.Resources.browser_root_32x32x32;
            this.toolBtnlViewVFSBrowserGoToRoot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnlViewVFSBrowserGoToRoot.Name = "toolBtnlViewVFSBrowserGoToRoot";
            this.toolBtnlViewVFSBrowserGoToRoot.Size = new System.Drawing.Size(68, 36);
            this.toolBtnlViewVFSBrowserGoToRoot.Text = "Root";
            this.toolBtnlViewVFSBrowserGoToRoot.Click += new System.EventHandler(this.toolBtnlViewVFSBrowserGoToRoot_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnlViewBrowserRefresh
            // 
            this.toolBtnlViewBrowserRefresh.Enabled = false;
            this.toolBtnlViewBrowserRefresh.Image = global::CD_Sync_Portable.Properties.Resources.browser_refresh_24x24x32;
            this.toolBtnlViewBrowserRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnlViewBrowserRefresh.Name = "toolBtnlViewBrowserRefresh";
            this.toolBtnlViewBrowserRefresh.Size = new System.Drawing.Size(82, 36);
            this.toolBtnlViewBrowserRefresh.Text = "Refresh";
            this.toolBtnlViewBrowserRefresh.Click += new System.EventHandler(this.toolBtnlViewBrowserRefresh_Click);
            // 
            // toolBtnVFSItemProperties
            // 
            this.toolBtnVFSItemProperties.Enabled = false;
            this.toolBtnVFSItemProperties.Image = global::CD_Sync_Portable.Properties.Resources.properties_32x32x32;
            this.toolBtnVFSItemProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnVFSItemProperties.Name = "toolBtnVFSItemProperties";
            this.toolBtnVFSItemProperties.Size = new System.Drawing.Size(96, 36);
            this.toolBtnVFSItemProperties.Text = "Properties";
            this.toolBtnVFSItemProperties.Click += new System.EventHandler(this.toolBtnVFSItemProperties_Click);
            // 
            // toolBtnVFSItemSearch
            // 
            this.toolBtnVFSItemSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolBtnVFSItemSearch.Image = global::CD_Sync_Portable.Properties.Resources.search_32x32x32;
            this.toolBtnVFSItemSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnVFSItemSearch.Name = "toolBtnVFSItemSearch";
            this.toolBtnVFSItemSearch.Size = new System.Drawing.Size(78, 36);
            this.toolBtnVFSItemSearch.Text = "Search";
            this.toolBtnVFSItemSearch.Click += new System.EventHandler(this.toolBtnVFSItemSearch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolMenulViewVFSBrowserView
            // 
            this.toolMenulViewVFSBrowserView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuItemViewIcons,
            this.toolMenuItemViewList,
            this.toolBarMenuItemViewDetails});
            this.toolMenulViewVFSBrowserView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMenulViewVFSBrowserView.Name = "toolMenulViewVFSBrowserView";
            this.toolMenulViewVFSBrowserView.Size = new System.Drawing.Size(48, 36);
            this.toolMenulViewVFSBrowserView.Text = "View";
            // 
            // toolMenuItemViewIcons
            // 
            this.toolMenuItemViewIcons.Name = "toolMenuItemViewIcons";
            this.toolMenuItemViewIcons.Size = new System.Drawing.Size(109, 22);
            this.toolMenuItemViewIcons.Text = "&Icons";
            this.toolMenuItemViewIcons.Click += new System.EventHandler(this.toolBarMenuItemViewIcons_Click);
            // 
            // toolMenuItemViewList
            // 
            this.toolMenuItemViewList.Name = "toolMenuItemViewList";
            this.toolMenuItemViewList.Size = new System.Drawing.Size(109, 22);
            this.toolMenuItemViewList.Text = "&List";
            this.toolMenuItemViewList.Click += new System.EventHandler(this.toolBarMenuItemViewList_Click);
            // 
            // toolBarMenuItemViewDetails
            // 
            this.toolBarMenuItemViewDetails.Name = "toolBarMenuItemViewDetails";
            this.toolBarMenuItemViewDetails.Size = new System.Drawing.Size(109, 22);
            this.toolBarMenuItemViewDetails.Text = "&Details";
            this.toolBarMenuItemViewDetails.Click += new System.EventHandler(this.toolBarMenuItemViewDetails_Click);
            // 
            // toolBtnOptions
            // 
            this.toolBtnOptions.Image = global::CD_Sync_Portable.Properties.Resources.configure_24x24x32;
            this.toolBtnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnOptions.Name = "toolBtnOptions";
            this.toolBtnOptions.Size = new System.Drawing.Size(85, 36);
            this.toolBtnOptions.Text = "Options";
            this.toolBtnOptions.ToolTipText = "Program Options";
            this.toolBtnOptions.Click += new System.EventHandler(this.toolBtnOptions_Click);
            // 
            // addressBar
            // 
            this.addressBar.Dock = System.Windows.Forms.DockStyle.None;
            this.addressBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAddress,
            this.txtAddress});
            this.addressBar.Location = new System.Drawing.Point(0, 63);
            this.addressBar.Name = "addressBar";
            this.addressBar.Size = new System.Drawing.Size(840, 25);
            this.addressBar.Stretch = true;
            this.addressBar.TabIndex = 2;
            // 
            // lblAddress
            // 
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 22);
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = false;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(760, 20);
            // 
            // cMenuVFSItem
            // 
            this.cMenuVFSItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuItemVFSItemOpen,
            this.cMenuItemVFSItemExplore,
            this.cMenuItemRenameVFSItem,
            this.cMenuItemEditVFSItemDescription,
            this.toolStripSeparator8,
            this.cMenuItemVFSItemDelete,
            this.cMenuItemVFSItemProperties});
            this.cMenuVFSItem.Name = "cMenulViewVFSBrowser";
            this.cMenuVFSItem.Size = new System.Drawing.Size(158, 142);
            this.cMenuVFSItem.Opening += new System.ComponentModel.CancelEventHandler(this.cMenuVFSItem_Opening);
            this.cMenuVFSItem.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.cMenuVFSItem_Closing);
            // 
            // cMenuItemVFSItemOpen
            // 
            this.cMenuItemVFSItemOpen.Name = "cMenuItemVFSItemOpen";
            this.cMenuItemVFSItemOpen.Size = new System.Drawing.Size(157, 22);
            this.cMenuItemVFSItemOpen.Text = "&Open";
            this.cMenuItemVFSItemOpen.Click += new System.EventHandler(this.cMenuVFSItemOpen_Click);
            // 
            // cMenuItemVFSItemExplore
            // 
            this.cMenuItemVFSItemExplore.Image = global::CD_Sync_Portable.Properties.Resources.explore_16x16x32;
            this.cMenuItemVFSItemExplore.Name = "cMenuItemVFSItemExplore";
            this.cMenuItemVFSItemExplore.Size = new System.Drawing.Size(157, 22);
            this.cMenuItemVFSItemExplore.Text = "&Explore";
            this.cMenuItemVFSItemExplore.Click += new System.EventHandler(this.cMenuVFSItemExplore_Click);
            // 
            // cMenuItemRenameVFSItem
            // 
            this.cMenuItemRenameVFSItem.Name = "cMenuItemRenameVFSItem";
            this.cMenuItemRenameVFSItem.Size = new System.Drawing.Size(157, 22);
            this.cMenuItemRenameVFSItem.Text = "&Rename";
            this.cMenuItemRenameVFSItem.Click += new System.EventHandler(this.cMenuItemRenameVFSItem_Click);
            // 
            // cMenuItemEditVFSItemDescription
            // 
            this.cMenuItemEditVFSItemDescription.Image = global::CD_Sync_Portable.Properties.Resources.edit_description_16x16x32;
            this.cMenuItemEditVFSItemDescription.Name = "cMenuItemEditVFSItemDescription";
            this.cMenuItemEditVFSItemDescription.Size = new System.Drawing.Size(157, 22);
            this.cMenuItemEditVFSItemDescription.Text = "E&dit Description";
            this.cMenuItemEditVFSItemDescription.Click += new System.EventHandler(this.cMenuItemEditVFSItemDescription_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(154, 6);
            // 
            // cMenuItemVFSItemDelete
            // 
            this.cMenuItemVFSItemDelete.Image = global::CD_Sync_Portable.Properties.Resources.del_16x16x32;
            this.cMenuItemVFSItemDelete.Name = "cMenuItemVFSItemDelete";
            this.cMenuItemVFSItemDelete.Size = new System.Drawing.Size(157, 22);
            this.cMenuItemVFSItemDelete.Text = "De&lete";
            this.cMenuItemVFSItemDelete.Click += new System.EventHandler(this.cMenuVFSItemDelete_Click);
            // 
            // cMenuItemVFSItemProperties
            // 
            this.cMenuItemVFSItemProperties.Image = global::CD_Sync_Portable.Properties.Resources.properties_16x16x32;
            this.cMenuItemVFSItemProperties.Name = "cMenuItemVFSItemProperties";
            this.cMenuItemVFSItemProperties.Size = new System.Drawing.Size(157, 22);
            this.cMenuItemVFSItemProperties.Text = "&Item Properties";
            this.cMenuItemVFSItemProperties.Click += new System.EventHandler(this.cMenuVFSItemProperties_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(152, 22);
            this.menuItemExit.Text = "&Exit";
            // 
            // menuNavigatelViewVFSBrowser
            // 
            this.menuNavigatelViewVFSBrowser.Name = "menuNavigatelViewVFSBrowser";
            this.menuNavigatelViewVFSBrowser.Size = new System.Drawing.Size(70, 20);
            this.menuNavigatelViewVFSBrowser.Text = "&Navigation";
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(6, 39);
            // 
            // cMenuImageNode
            // 
            this.cMenuImageNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuImageNodeItemExportImage,
            this.cMenuImageNodeItemExportList,
            this.cMenuImageNodeItemDelete,
            this.cMenuImageNodeItemRename,
            this.toolStripSeparator11,
            this.cMenuImageNodeItemProperties});
            this.cMenuImageNode.Name = "cMenuTreeImageBrowser";
            this.cMenuImageNode.Size = new System.Drawing.Size(164, 120);
            // 
            // cMenuImageNodeItemExportImage
            // 
            this.cMenuImageNodeItemExportImage.Image = global::CD_Sync_Portable.Properties.Resources.export_16x16x32;
            this.cMenuImageNodeItemExportImage.Name = "cMenuImageNodeItemExportImage";
            this.cMenuImageNodeItemExportImage.Size = new System.Drawing.Size(163, 22);
            this.cMenuImageNodeItemExportImage.Text = "Export &Image";
            this.cMenuImageNodeItemExportImage.Click += new System.EventHandler(this.cMenuImageNodeItemExportImage_Click);
            // 
            // cMenuImageNodeItemExportList
            // 
            this.cMenuImageNodeItemExportList.Name = "cMenuImageNodeItemExportList";
            this.cMenuImageNodeItemExportList.Size = new System.Drawing.Size(163, 22);
            this.cMenuImageNodeItemExportList.Text = "Export &Filelist";
            this.cMenuImageNodeItemExportList.Click += new System.EventHandler(this.cMenuImageNodeItemExportList_Click);
            // 
            // cMenuImageNodeItemDelete
            // 
            this.cMenuImageNodeItemDelete.Image = global::CD_Sync_Portable.Properties.Resources.image_delete_16x16x32;
            this.cMenuImageNodeItemDelete.Name = "cMenuImageNodeItemDelete";
            this.cMenuImageNodeItemDelete.ShortcutKeyDisplayString = "";
            this.cMenuImageNodeItemDelete.Size = new System.Drawing.Size(163, 22);
            this.cMenuImageNodeItemDelete.Text = "&Delete Image";
            this.cMenuImageNodeItemDelete.Click += new System.EventHandler(this.cMenuImageNodeItemDelete_Click);
            // 
            // cMenuImageNodeItemRename
            // 
            this.cMenuImageNodeItemRename.Name = "cMenuImageNodeItemRename";
            this.cMenuImageNodeItemRename.Size = new System.Drawing.Size(163, 22);
            this.cMenuImageNodeItemRename.Text = "&Rename Image";
            this.cMenuImageNodeItemRename.Click += new System.EventHandler(this.cMenuItemRenImage_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(160, 6);
            // 
            // cMenuImageNodeItemProperties
            // 
            this.cMenuImageNodeItemProperties.Image = global::CD_Sync_Portable.Properties.Resources.image_properties_16x16x32;
            this.cMenuImageNodeItemProperties.Name = "cMenuImageNodeItemProperties";
            this.cMenuImageNodeItemProperties.ShortcutKeyDisplayString = "";
            this.cMenuImageNodeItemProperties.Size = new System.Drawing.Size(163, 22);
            this.cMenuImageNodeItemProperties.Text = "&Image Properties";
            this.cMenuImageNodeItemProperties.Click += new System.EventHandler(this.cMenuImageNodeItemProperties_Click);
            // 
            // cMenuImageCategoryNode
            // 
            this.cMenuImageCategoryNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuImageCNodeItemEditCategory,
            this.cMenuImageCNodeItemRemoveCategory,
            this.toolStripSeparator4,
            this.cMenuImageCNodeItemExportImages,
            this.cMenuImageCNodeItemRemoveImages});
            this.cMenuImageCategoryNode.Name = "cMenuTreeImageBrowser";
            this.cMenuImageCategoryNode.Size = new System.Drawing.Size(169, 98);
            // 
            // cMenuImageCNodeItemEditCategory
            // 
            this.cMenuImageCNodeItemEditCategory.Name = "cMenuImageCNodeItemEditCategory";
            this.cMenuImageCNodeItemEditCategory.Size = new System.Drawing.Size(168, 22);
            this.cMenuImageCNodeItemEditCategory.Text = "&Edit Category";
            this.cMenuImageCNodeItemEditCategory.Click += new System.EventHandler(this.cMenuImageCNodeItemEditCategory_Click);
            // 
            // cMenuImageCNodeItemRemoveCategory
            // 
            this.cMenuImageCNodeItemRemoveCategory.Name = "cMenuImageCNodeItemRemoveCategory";
            this.cMenuImageCNodeItemRemoveCategory.Size = new System.Drawing.Size(168, 22);
            this.cMenuImageCNodeItemRemoveCategory.Text = "&Remove Category";
            this.cMenuImageCNodeItemRemoveCategory.Click += new System.EventHandler(this.cMenuImageCNodeItemRemoveCategory_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // cMenuImageCNodeItemExportImages
            // 
            this.cMenuImageCNodeItemExportImages.Image = global::CD_Sync_Portable.Properties.Resources.export_16x16x32;
            this.cMenuImageCNodeItemExportImages.Name = "cMenuImageCNodeItemExportImages";
            this.cMenuImageCNodeItemExportImages.Size = new System.Drawing.Size(168, 22);
            this.cMenuImageCNodeItemExportImages.Text = "E&xport Images";
            this.cMenuImageCNodeItemExportImages.Click += new System.EventHandler(this.cMenuImageCNodeItemExportImages_Click);
            // 
            // cMenuImageCNodeItemRemoveImages
            // 
            this.cMenuImageCNodeItemRemoveImages.Name = "cMenuImageCNodeItemRemoveImages";
            this.cMenuImageCNodeItemRemoveImages.Size = new System.Drawing.Size(168, 22);
            this.cMenuImageCNodeItemRemoveImages.Text = "Rem&ove Images";
            this.cMenuImageCNodeItemRemoveImages.Click += new System.EventHandler(this.cMenuImageCNodeItemRemoveImages_Click);
            // 
            // WndMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 471);
            this.Controls.Add(this.toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "WndMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CD Sync Portable";
            this.Load += new System.EventHandler(this.mainWnd_Load);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.viewSplitter.Panel1.ResumeLayout(false);
            this.viewSplitter.Panel2.ResumeLayout(false);
            this.viewSplitter.ResumeLayout(false);
            this.viewSplitter2.Panel1.ResumeLayout(false);
            this.viewSplitter2.Panel2.ResumeLayout(false);
            this.viewSplitter2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxImagePicture)).EndInit();
            this.viewSplitter3.Panel1.ResumeLayout(false);
            this.viewSplitter3.Panel2.ResumeLayout(false);
            this.viewSplitter3.ResumeLayout(false);
            this.cMenuVFSBrowser.ResumeLayout(false);
            this.viewSplitter4.Panel1.ResumeLayout(false);
            this.viewSplitter4.Panel2.ResumeLayout(false);
            this.viewSplitter4.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.addressBar.ResumeLayout(false);
            this.addressBar.PerformLayout();
            this.cMenuVFSItem.ResumeLayout(false);
            this.cMenuImageNode.ResumeLayout(false);
            this.cMenuImageCategoryNode.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolBtnlViewVFSBrowserGoBack;
        private System.Windows.Forms.ToolStripButton toolBtnlViewVFSBrowserGoForward;
        private System.Windows.Forms.ToolStripButton toolBtnlViewVFSBrowserGoUp;
        private System.Windows.Forms.ToolStripSeparator separator3;
        private System.Windows.Forms.ToolStripButton toolBtnVFSItemSearch;
        private System.Windows.Forms.ToolStripButton toolBtnVFSItemProperties;
        private System.Windows.Forms.ToolStripSplitButton toolMenulViewVFSBrowserView;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuImage;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewImage;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem subMenuBrowser;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripSeparator separator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemAboutCDSync;
        private System.Windows.Forms.SplitContainer viewSplitter;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuItemVFSItemSearch;
        private System.Windows.Forms.ToolStripSeparator separator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem menuItemCategories;
        private System.Windows.Forms.ToolStrip addressBar;
        private System.Windows.Forms.ToolStripLabel lblAddress;
        private System.Windows.Forms.ToolStripTextBox txtAddress;
        private System.Windows.Forms.ToolStripMenuItem toolMenuItemViewIcons;
        private System.Windows.Forms.ToolStripMenuItem toolMenuItemViewList;
        private System.Windows.Forms.ToolStripMenuItem toolBarMenuItemViewDetails;
        private System.Windows.Forms.ContextMenuStrip cMenuImageNode;
        private System.Windows.Forms.ToolStripMenuItem cMenuImageNodeItemProperties;
        private System.Windows.Forms.ToolStripMenuItem cMenuImageNodeItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowProp;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelImage;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem subMenuViewlViewVFSBrowser;
        private System.Windows.Forms.ToolStripMenuItem subMenuItemViewIcons;
        private System.Windows.Forms.ToolStripMenuItem subMenuItemViewList;
        private System.Windows.Forms.ToolStripMenuItem subMenuItemViewDetails;
        private System.Windows.Forms.SplitContainer viewSplitter2;
        private System.Windows.Forms.TreeView treeImageBrowser;
        private System.Windows.Forms.PictureBox pBoxImagePicture;
        private System.Windows.Forms.ContextMenuStrip cMenuVFSItem;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemVFSItemOpen;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemVFSItemProperties;
        private System.Windows.Forms.ToolStripMenuItem subMenuItemRefreshlViewVFSBrowser;
        private System.Windows.Forms.ToolStripButton toolBtnlViewBrowserRefresh;
        private System.Windows.Forms.ToolStripButton toolBtnlViewVFSBrowserGoToRoot;
        private System.Windows.Forms.ToolStripMenuItem menuNavigatelViewVFSBrowser;
        private System.Windows.Forms.ToolStripMenuItem subMenuGoTo;
        private System.Windows.Forms.ToolStripMenuItem subMenuItemlViewVFSBrowserGoBack;
        private System.Windows.Forms.ToolStripMenuItem subMenuItemlViewVFSBrowserGoForward;
        private System.Windows.Forms.ToolStripMenuItem subMenuItemlViewVFSBrowserGoUp;
        private System.Windows.Forms.ToolStripMenuItem subMenuItemlViewVFSBrowserGoToRoot;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLblImageIcon;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLblImageInfo;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLblVFSItemIcon;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLblVFSItemInfo;
        private System.Windows.Forms.ToolStripStatusLabel statusStripDummyLabel;
        private System.Windows.Forms.ToolStripMenuItem cMenuImageNodeItemRename;
        private System.Windows.Forms.ContextMenuStrip cMenuImageCategoryNode;
        private System.Windows.Forms.ToolStripMenuItem cMenuImageCNodeItemEditCategory;
        private System.Windows.Forms.ToolStripMenuItem cMenuImageCNodeItemRemoveCategory;
        private System.Windows.Forms.ToolStripMenuItem cMenuImageCNodeItemExportImages;
        private System.Windows.Forms.ToolStripMenuItem cMenuImageCNodeItemRemoveImages;
        private System.Windows.Forms.ToolStripMenuItem cMenuImageNodeItemExportImage;
        private System.Windows.Forms.ToolStripMenuItem cMenuImageNodeItemExportList;
        private System.Windows.Forms.ToolStripButton toolBtnOptions;
        private System.Windows.Forms.SplitContainer viewSplitter3;
        private System.Windows.Forms.ListView lViewVFSBrowser;
        private System.Windows.Forms.SplitContainer viewSplitter4;
        private System.Windows.Forms.Label lblPreview;
        private Customized_Controls.CustomPreviewControl multiPreviewer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuItemExitApp;
        private System.Windows.Forms.ToolStripMenuItem menuItemExportImages;
        private System.Windows.Forms.ToolStripMenuItem menuItemImportImages;
        private System.Windows.Forms.ContextMenuStrip cMenuVFSBrowser;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemView;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemIcons;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemList;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemProperties;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemVFSItemExplore;
        private System.Windows.Forms.ListView lViewExtendedProperties;
        private System.Windows.Forms.ColumnHeader lViewColumnProperty;
        private System.Windows.Forms.ColumnHeader lViewColumnValue;
        private System.Windows.Forms.ToolStripMenuItem menuItemVFSItemProperties;
        private System.Windows.Forms.ToolStripMenuItem menuItemVFSItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemVFSItemExplore;
        private System.Windows.Forms.ToolStripMenuItem menuItemVFSItemOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemVFSItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem menuItemExportFileList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditVFSItemDescription;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemEditVFSItemDescription;
        private System.Windows.Forms.ToolStripMenuItem menuItemRenameVFSItem;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemRenameVFSItem;
        private System.Windows.Forms.ToolStripButton toolBtnNewImage;
        private System.Windows.Forms.ToolStripButton toolBtnDeleteImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem menuItemEmailAuthor;
        private System.Windows.Forms.ToolStripMenuItem menuItemVisitWebsite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
    }
}