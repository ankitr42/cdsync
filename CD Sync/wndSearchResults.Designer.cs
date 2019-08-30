namespace CD_Sync_Portable
{
    partial class WndSearchResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndSearchResults));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripDummyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripLblImageIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripLblImageInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripLblSearchItemIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripLblSearchItemInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.viewSplitter1 = new System.Windows.Forms.SplitContainer();
            this.lViewSResultsBrowser = new System.Windows.Forms.ListView();
            this.cMenuSResultsBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuVFSBrowserItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuVFSBrowserItemIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuVFSBrowserItemList = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuVFSBrowserItemDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSplitter2 = new System.Windows.Forms.SplitContainer();
            this.lViewExtendedProperties = new System.Windows.Forms.ListView();
            this.lViewColumnProperty = new System.Windows.Forms.ColumnHeader();
            this.lViewColumnValue = new System.Windows.Forms.ColumnHeader();
            this.multiPreviewer = new Customized_Controls.CustomPreviewControl();
            this.lblPreview = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBtnBasicSearch = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAdvancedSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolBtnExplore = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSItemProperties = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnExtendedProperties = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAutoPlay = new System.Windows.Forms.ToolStripButton();
            this.toolMenuSResultBrowser = new System.Windows.Forms.ToolStripDropDownButton();
            this.iconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBtnStopSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripAddressBar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtAddress = new System.Windows.Forms.ToolStripTextBox();
            this.bgDatabaseSearcher = new System.ComponentModel.BackgroundWorker();
            this.cMenuSResultItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuSResultItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuSResultItemExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cMenuSResultItemProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.viewSplitter1.Panel1.SuspendLayout();
            this.viewSplitter1.Panel2.SuspendLayout();
            this.viewSplitter1.SuspendLayout();
            this.cMenuSResultsBrowser.SuspendLayout();
            this.viewSplitter2.Panel1.SuspendLayout();
            this.viewSplitter2.Panel2.SuspendLayout();
            this.viewSplitter2.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.toolStripAddressBar.SuspendLayout();
            this.cMenuSResultItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.viewSplitter1);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(785, 335);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(785, 465);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripAddressBar);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripDummyLabel,
            this.statusStripLblImageIcon,
            this.statusStripLblImageInfo,
            this.statusStripLblSearchItemIcon,
            this.statusStripLblSearchItemInfo});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.MinimumSize = new System.Drawing.Size(0, 66);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(785, 66);
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
            // statusStripLblSearchItemIcon
            // 
            this.statusStripLblSearchItemIcon.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusStripLblSearchItemIcon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusStripLblSearchItemIcon.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.statusStripLblSearchItemIcon.Name = "statusStripLblSearchItemIcon";
            this.statusStripLblSearchItemIcon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStripLblSearchItemIcon.Size = new System.Drawing.Size(13, 64);
            this.statusStripLblSearchItemIcon.Text = "  ";
            // 
            // statusStripLblSearchItemInfo
            // 
            this.statusStripLblSearchItemInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusStripLblSearchItemInfo.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.statusStripLblSearchItemInfo.Name = "statusStripLblSearchItemInfo";
            this.statusStripLblSearchItemInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStripLblSearchItemInfo.Size = new System.Drawing.Size(19, 64);
            this.statusStripLblSearchItemInfo.Text = "    ";
            this.statusStripLblSearchItemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viewSplitter1
            // 
            this.viewSplitter1.BackColor = System.Drawing.Color.Transparent;
            this.viewSplitter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSplitter1.Location = new System.Drawing.Point(0, 0);
            this.viewSplitter1.Name = "viewSplitter1";
            this.viewSplitter1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // viewSplitter1.Panel1
            // 
            this.viewSplitter1.Panel1.Controls.Add(this.lViewSResultsBrowser);
            // 
            // viewSplitter1.Panel2
            // 
            this.viewSplitter1.Panel2.Controls.Add(this.viewSplitter2);
            this.viewSplitter1.Size = new System.Drawing.Size(785, 335);
            this.viewSplitter1.SplitterDistance = 208;
            this.viewSplitter1.TabIndex = 1;
            // 
            // lViewSResultsBrowser
            // 
            this.lViewSResultsBrowser.AllowColumnReorder = true;
            this.lViewSResultsBrowser.BackColor = System.Drawing.SystemColors.Window;
            this.lViewSResultsBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lViewSResultsBrowser.ContextMenuStrip = this.cMenuSResultsBrowser;
            this.lViewSResultsBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lViewSResultsBrowser.FullRowSelect = true;
            this.lViewSResultsBrowser.HideSelection = false;
            this.lViewSResultsBrowser.Location = new System.Drawing.Point(0, 0);
            this.lViewSResultsBrowser.Name = "lViewSResultsBrowser";
            this.lViewSResultsBrowser.ShowItemToolTips = true;
            this.lViewSResultsBrowser.Size = new System.Drawing.Size(785, 208);
            this.lViewSResultsBrowser.TabIndex = 6;
            this.lViewSResultsBrowser.UseCompatibleStateImageBehavior = false;
            this.lViewSResultsBrowser.ItemActivate += new System.EventHandler(this.lViewSResultsBrowser_ItemActivate);
            this.lViewSResultsBrowser.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lViewSResultsBrowser_MouseClick);
            this.lViewSResultsBrowser.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lViewSResultsBrowser_ItemSelectionChanged);
            this.lViewSResultsBrowser.SystemColorsChanged += new System.EventHandler(this.lViewSResultsBrowser_SystemColorsChanged);
            // 
            // cMenuSResultsBrowser
            // 
            this.cMenuSResultsBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuVFSBrowserItemView});
            this.cMenuSResultsBrowser.Name = "cMenuVFSBrowser";
            this.cMenuSResultsBrowser.Size = new System.Drawing.Size(108, 26);
            // 
            // cMenuVFSBrowserItemView
            // 
            this.cMenuVFSBrowserItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuVFSBrowserItemIcons,
            this.cMenuVFSBrowserItemList,
            this.cMenuVFSBrowserItemDetails});
            this.cMenuVFSBrowserItemView.Name = "cMenuVFSBrowserItemView";
            this.cMenuVFSBrowserItemView.Size = new System.Drawing.Size(107, 22);
            this.cMenuVFSBrowserItemView.Text = "&View";
            // 
            // cMenuVFSBrowserItemIcons
            // 
            this.cMenuVFSBrowserItemIcons.Name = "cMenuVFSBrowserItemIcons";
            this.cMenuVFSBrowserItemIcons.Size = new System.Drawing.Size(117, 22);
            this.cMenuVFSBrowserItemIcons.Text = "&Icons";
            this.cMenuVFSBrowserItemIcons.Click += new System.EventHandler(this.cMenuVFSBrowserItemIcons_Click);
            // 
            // cMenuVFSBrowserItemList
            // 
            this.cMenuVFSBrowserItemList.Name = "cMenuVFSBrowserItemList";
            this.cMenuVFSBrowserItemList.Size = new System.Drawing.Size(117, 22);
            this.cMenuVFSBrowserItemList.Text = "&List";
            this.cMenuVFSBrowserItemList.Click += new System.EventHandler(this.cMenuVFSBrowserItemList_Click);
            // 
            // cMenuVFSBrowserItemDetails
            // 
            this.cMenuVFSBrowserItemDetails.Name = "cMenuVFSBrowserItemDetails";
            this.cMenuVFSBrowserItemDetails.Size = new System.Drawing.Size(117, 22);
            this.cMenuVFSBrowserItemDetails.Text = "&Details";
            this.cMenuVFSBrowserItemDetails.Click += new System.EventHandler(this.cMenuVFSBrowserItemDetails_Click);
            // 
            // viewSplitter2
            // 
            this.viewSplitter2.BackColor = System.Drawing.SystemColors.Control;
            this.viewSplitter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewSplitter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSplitter2.Location = new System.Drawing.Point(0, 0);
            this.viewSplitter2.Name = "viewSplitter2";
            // 
            // viewSplitter2.Panel1
            // 
            this.viewSplitter2.Panel1.Controls.Add(this.lViewExtendedProperties);
            // 
            // viewSplitter2.Panel2
            // 
            this.viewSplitter2.Panel2.Controls.Add(this.multiPreviewer);
            this.viewSplitter2.Panel2.Controls.Add(this.lblPreview);
            this.viewSplitter2.Size = new System.Drawing.Size(785, 123);
            this.viewSplitter2.SplitterDistance = 476;
            this.viewSplitter2.TabIndex = 0;
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
            this.lViewExtendedProperties.Size = new System.Drawing.Size(474, 121);
            this.lViewExtendedProperties.TabIndex = 0;
            this.lViewExtendedProperties.UseCompatibleStateImageBehavior = false;
            this.lViewExtendedProperties.View = System.Windows.Forms.View.Details;
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
            this.multiPreviewer.Size = new System.Drawing.Size(303, 121);
            this.multiPreviewer.TabIndex = 1;
            // 
            // lblPreview
            // 
            this.lblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreview.Location = new System.Drawing.Point(0, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(303, 121);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnBasicSearch,
            this.toolBtnAdvancedSearch,
            this.toolStripSeparator1,
            this.toolBtnOpen,
            this.toolBtnExplore,
            this.toolBtnSItemProperties,
            this.toolStripSeparator2,
            this.toolBtnExtendedProperties,
            this.toolBtnAutoPlay,
            this.toolMenuSResultBrowser,
            this.toolBtnStopSearch});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(785, 39);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 0;
            // 
            // toolBtnBasicSearch
            // 
            this.toolBtnBasicSearch.Image = global::CD_Sync_Portable.Properties.Resources.search_32x32x32;
            this.toolBtnBasicSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnBasicSearch.Name = "toolBtnBasicSearch";
            this.toolBtnBasicSearch.Size = new System.Drawing.Size(67, 36);
            this.toolBtnBasicSearch.Text = "&Basic";
            this.toolBtnBasicSearch.ToolTipText = "Basic Search";
            this.toolBtnBasicSearch.Click += new System.EventHandler(this.toolBtnBasicSearch_Click);
            // 
            // toolBtnAdvancedSearch
            // 
            this.toolBtnAdvancedSearch.Image = global::CD_Sync_Portable.Properties.Resources.search1_32x32x32;
            this.toolBtnAdvancedSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAdvancedSearch.Name = "toolBtnAdvancedSearch";
            this.toolBtnAdvancedSearch.Size = new System.Drawing.Size(91, 36);
            this.toolBtnAdvancedSearch.Text = "&Advanced";
            this.toolBtnAdvancedSearch.ToolTipText = "Advanced Search";
            this.toolBtnAdvancedSearch.Click += new System.EventHandler(this.toolBtnAdvancedSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnOpen
            // 
            this.toolBtnOpen.Enabled = false;
            this.toolBtnOpen.Image = global::CD_Sync_Portable.Properties.Resources.explore_32x32x32;
            this.toolBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnOpen.Name = "toolBtnOpen";
            this.toolBtnOpen.Size = new System.Drawing.Size(69, 36);
            this.toolBtnOpen.Text = "&Open";
            this.toolBtnOpen.Click += new System.EventHandler(this.toolBtnOpen_Click);
            // 
            // toolBtnExplore
            // 
            this.toolBtnExplore.Enabled = false;
            this.toolBtnExplore.Image = global::CD_Sync_Portable.Properties.Resources.explore_in_main_window_32x32x32;
            this.toolBtnExplore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnExplore.Name = "toolBtnExplore";
            this.toolBtnExplore.Size = new System.Drawing.Size(79, 36);
            this.toolBtnExplore.Text = "&Explore";
            this.toolBtnExplore.ToolTipText = "Explore in main window";
            this.toolBtnExplore.Click += new System.EventHandler(this.toolBtnExplore_Click);
            // 
            // toolBtnSItemProperties
            // 
            this.toolBtnSItemProperties.Enabled = false;
            this.toolBtnSItemProperties.Image = global::CD_Sync_Portable.Properties.Resources.properties_32x32x32;
            this.toolBtnSItemProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSItemProperties.Name = "toolBtnSItemProperties";
            this.toolBtnSItemProperties.Size = new System.Drawing.Size(92, 36);
            this.toolBtnSItemProperties.Text = "&Properties";
            this.toolBtnSItemProperties.Click += new System.EventHandler(this.toolBtnSItemProperties_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnExtendedProperties
            // 
            this.toolBtnExtendedProperties.Checked = true;
            this.toolBtnExtendedProperties.CheckOnClick = true;
            this.toolBtnExtendedProperties.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBtnExtendedProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnExtendedProperties.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnExtendedProperties.Image")));
            this.toolBtnExtendedProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnExtendedProperties.Name = "toolBtnExtendedProperties";
            this.toolBtnExtendedProperties.Size = new System.Drawing.Size(109, 36);
            this.toolBtnExtendedProperties.Text = "E&xtended Properties";
            this.toolBtnExtendedProperties.ToolTipText = "Show extended properties Panel";
            this.toolBtnExtendedProperties.Click += new System.EventHandler(this.toolBtnExtendedProperties_Click);
            // 
            // toolBtnAutoPlay
            // 
            this.toolBtnAutoPlay.CheckOnClick = true;
            this.toolBtnAutoPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnAutoPlay.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnAutoPlay.Image")));
            this.toolBtnAutoPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAutoPlay.Name = "toolBtnAutoPlay";
            this.toolBtnAutoPlay.Size = new System.Drawing.Size(54, 36);
            this.toolBtnAutoPlay.Text = "A&utoplay";
            this.toolBtnAutoPlay.ToolTipText = "Autoplay audio and video files";
            // 
            // toolMenuSResultBrowser
            // 
            this.toolMenuSResultBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolMenuSResultBrowser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.toolMenuSResultBrowser.Image = ((System.Drawing.Image)(resources.GetObject("toolMenuSResultBrowser.Image")));
            this.toolMenuSResultBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMenuSResultBrowser.Name = "toolMenuSResultBrowser";
            this.toolMenuSResultBrowser.Size = new System.Drawing.Size(42, 36);
            this.toolMenuSResultBrowser.Text = "View";
            // 
            // iconsToolStripMenuItem
            // 
            this.iconsToolStripMenuItem.Name = "iconsToolStripMenuItem";
            this.iconsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.iconsToolStripMenuItem.Text = "&Icons";
            this.iconsToolStripMenuItem.Click += new System.EventHandler(this.iconsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.listToolStripMenuItem.Text = "&List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.detailsToolStripMenuItem.Text = "&Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // toolBtnStopSearch
            // 
            this.toolBtnStopSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnStopSearch.Image = global::CD_Sync_Portable.Properties.Resources.cross1_32x32x32;
            this.toolBtnStopSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnStopSearch.Name = "toolBtnStopSearch";
            this.toolBtnStopSearch.Size = new System.Drawing.Size(101, 36);
            this.toolBtnStopSearch.Text = "Stop Search";
            this.toolBtnStopSearch.ToolTipText = "Stop Search";
            this.toolBtnStopSearch.Visible = false;
            this.toolBtnStopSearch.Click += new System.EventHandler(this.toolBtnStopSearch_Click);
            // 
            // toolStripAddressBar
            // 
            this.toolStripAddressBar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripAddressBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripAddressBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtAddress});
            this.toolStripAddressBar.Location = new System.Drawing.Point(0, 39);
            this.toolStripAddressBar.Name = "toolStripAddressBar";
            this.toolStripAddressBar.Size = new System.Drawing.Size(785, 25);
            this.toolStripAddressBar.Stretch = true;
            this.toolStripAddressBar.TabIndex = 1;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel1.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(700, 25);
            // 
            // bgDatabaseSearcher
            // 
            this.bgDatabaseSearcher.WorkerSupportsCancellation = true;
            this.bgDatabaseSearcher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgDatabaseSearcher_DoWork);
            this.bgDatabaseSearcher.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgDatabaseSearcher_RunWorkerCompleted);
            // 
            // cMenuSResultItem
            // 
            this.cMenuSResultItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuSResultItemOpen,
            this.cMenuSResultItemExplore,
            this.toolStripSeparator8,
            this.cMenuSResultItemProperties});
            this.cMenuSResultItem.Name = "cMenulViewVFSBrowser";
            this.cMenuSResultItem.Size = new System.Drawing.Size(135, 76);
            this.cMenuSResultItem.Opening += new System.ComponentModel.CancelEventHandler(this.cMenuSResultItem_Opening);
            this.cMenuSResultItem.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.cMenuSResultItem_Closing);
            // 
            // cMenuSResultItemOpen
            // 
            this.cMenuSResultItemOpen.Name = "cMenuSResultItemOpen";
            this.cMenuSResultItemOpen.Size = new System.Drawing.Size(134, 22);
            this.cMenuSResultItemOpen.Text = "&Open";
            this.cMenuSResultItemOpen.Click += new System.EventHandler(this.cMenuSResultItemOpen_Click);
            // 
            // cMenuSResultItemExplore
            // 
            this.cMenuSResultItemExplore.Name = "cMenuSResultItemExplore";
            this.cMenuSResultItemExplore.Size = new System.Drawing.Size(134, 22);
            this.cMenuSResultItemExplore.Text = "&Explore";
            this.cMenuSResultItemExplore.Click += new System.EventHandler(this.cMenuSResultItemExplore_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(131, 6);
            // 
            // cMenuSResultItemProperties
            // 
            this.cMenuSResultItemProperties.Name = "cMenuSResultItemProperties";
            this.cMenuSResultItemProperties.Size = new System.Drawing.Size(134, 22);
            this.cMenuSResultItemProperties.Text = "&Properties";
            this.cMenuSResultItemProperties.Click += new System.EventHandler(this.cMenuSResultItemProperties_Click);
            // 
            // WndSearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(785, 465);
            this.Controls.Add(this.toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndSearchResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Results";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WndSearchResults_FormClosing);
            this.Load += new System.EventHandler(this.WndSearchResults_Load);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.viewSplitter1.Panel1.ResumeLayout(false);
            this.viewSplitter1.Panel2.ResumeLayout(false);
            this.viewSplitter1.ResumeLayout(false);
            this.cMenuSResultsBrowser.ResumeLayout(false);
            this.viewSplitter2.Panel1.ResumeLayout(false);
            this.viewSplitter2.Panel2.ResumeLayout(false);
            this.viewSplitter2.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStripAddressBar.ResumeLayout(false);
            this.toolStripAddressBar.PerformLayout();
            this.cMenuSResultItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer viewSplitter1;
        private System.Windows.Forms.ListView lViewSResultsBrowser;
        private System.Windows.Forms.SplitContainer viewSplitter2;
        private System.Windows.Forms.ListView lViewExtendedProperties;
        private Customized_Controls.CustomPreviewControl multiPreviewer;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.ToolStripButton toolBtnBasicSearch;
        private System.Windows.Forms.ToolStripButton toolBtnAdvancedSearch;
        private System.ComponentModel.BackgroundWorker bgDatabaseSearcher;
        private System.Windows.Forms.ToolStripDropDownButton toolMenuSResultBrowser;
        private System.Windows.Forms.ToolStripMenuItem iconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripDummyLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLblImageIcon;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLblImageInfo;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLblSearchItemIcon;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLblSearchItemInfo;
        private System.Windows.Forms.ToolStripButton toolBtnOpen;
        private System.Windows.Forms.ToolStripButton toolBtnExplore;
        private System.Windows.Forms.ToolStripButton toolBtnExtendedProperties;
        private System.Windows.Forms.ToolStripButton toolBtnAutoPlay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolBtnSItemProperties;
        private System.Windows.Forms.ToolStrip toolStripAddressBar;
        private System.Windows.Forms.ToolStripTextBox txtAddress;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolBtnStopSearch;
        private System.Windows.Forms.ColumnHeader lViewColumnProperty;
        private System.Windows.Forms.ColumnHeader lViewColumnValue;
        private System.Windows.Forms.ContextMenuStrip cMenuSResultItem;
        private System.Windows.Forms.ToolStripMenuItem cMenuSResultItemOpen;
        private System.Windows.Forms.ToolStripMenuItem cMenuSResultItemExplore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem cMenuSResultItemProperties;
        private System.Windows.Forms.ContextMenuStrip cMenuSResultsBrowser;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemView;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemIcons;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemList;
        private System.Windows.Forms.ToolStripMenuItem cMenuVFSBrowserItemDetails;
    }
}