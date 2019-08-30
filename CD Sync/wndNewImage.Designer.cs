namespace CD_Sync_Portable
{
    partial class WndNewImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndNewImage));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPageFolderFiltering = new System.Windows.Forms.TabPage();
            this.upDownSearchDepth = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.lstExcludedDirectories = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnClearExcludedFoldersList = new System.Windows.Forms.Button();
            this.btnRemoveFolderFromExclusions = new System.Windows.Forms.Button();
            this.btnAddFolderToExclusions = new System.Windows.Forms.Button();
            this.tabPageFileFiltering = new System.Windows.Forms.TabPage();
            this.btnClearExcludedFiles = new System.Windows.Forms.Button();
            this.btnRemoveFileFromExclusions = new System.Windows.Forms.Button();
            this.btnAddFileToExclusions = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.lstExcludedFiles = new System.Windows.Forms.ListBox();
            this.grpFileTypeFilter = new System.Windows.Forms.GroupBox();
            this.radioIncludeTypes = new System.Windows.Forms.RadioButton();
            this.radioExcludeTypes = new System.Windows.Forms.RadioButton();
            this.txtFileTypes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpDateFilterSettings = new System.Windows.Forms.GroupBox();
            this.chkAccessedDate = new System.Windows.Forms.CheckBox();
            this.dateAccessedE = new System.Windows.Forms.DateTimePicker();
            this.chkModifiedDate = new System.Windows.Forms.CheckBox();
            this.dateModifiedE = new System.Windows.Forms.DateTimePicker();
            this.dateAccessedB = new System.Windows.Forms.DateTimePicker();
            this.chkCreatedDate = new System.Windows.Forms.CheckBox();
            this.dateModifiedB = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateCreatedE = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateCreatedB = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkDateFilter = new System.Windows.Forms.CheckBox();
            this.grpAttributesFilterSettings = new System.Windows.Forms.GroupBox();
            this.chkExcludeEncrypted = new System.Windows.Forms.CheckBox();
            this.chkExcludeCompressed = new System.Windows.Forms.CheckBox();
            this.chkExcludeROnly = new System.Windows.Forms.CheckBox();
            this.chkExcludeArchive = new System.Windows.Forms.CheckBox();
            this.chkExcludeSystem = new System.Windows.Forms.CheckBox();
            this.chkExcludeHidden = new System.Windows.Forms.CheckBox();
            this.chkAttributesFilter = new System.Windows.Forms.CheckBox();
            this.grpSizeFilterSettings = new System.Windows.Forms.GroupBox();
            this.txtFileSizeUBound = new System.Windows.Forms.TextBox();
            this.txtFileSizeLBound = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSizeFilter = new System.Windows.Forms.CheckBox();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.grpExtendedFileInfo = new System.Windows.Forms.GroupBox();
            this.chkCopyDocInfo = new System.Windows.Forms.CheckBox();
            this.chkCopyFileAVInfo = new System.Windows.Forms.CheckBox();
            this.chkCopyFileVersionInfo = new System.Windows.Forms.CheckBox();
            this.chkCopyIcons = new System.Windows.Forms.CheckBox();
            this.chkCopyExtendedFileInfo = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCategories = new System.Windows.Forms.ComboBox();
            this.txtImagePic = new System.Windows.Forms.TextBox();
            this.txtCdDescription = new System.Windows.Forms.TextBox();
            this.txtCdName = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnNewCategory = new System.Windows.Forms.Button();
            this.tabNewImageSettings = new System.Windows.Forms.TabControl();
            this.tabPageFolderFiltering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSearchDepth)).BeginInit();
            this.tabPageFileFiltering.SuspendLayout();
            this.grpFileTypeFilter.SuspendLayout();
            this.grpDateFilterSettings.SuspendLayout();
            this.grpAttributesFilterSettings.SuspendLayout();
            this.grpSizeFilterSettings.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.grpExtendedFileInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabNewImageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(456, 445);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 28);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(583, 445);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // fileBrowser
            // 
            this.fileBrowser.DefaultExt = "jpg";
            this.fileBrowser.RestoreDirectory = true;
            // 
            // folderBrowser
            // 
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // tabPageFolderFiltering
            // 
            this.tabPageFolderFiltering.Controls.Add(this.upDownSearchDepth);
            this.tabPageFolderFiltering.Controls.Add(this.label18);
            this.tabPageFolderFiltering.Controls.Add(this.lstExcludedDirectories);
            this.tabPageFolderFiltering.Controls.Add(this.label17);
            this.tabPageFolderFiltering.Controls.Add(this.btnClearExcludedFoldersList);
            this.tabPageFolderFiltering.Controls.Add(this.btnRemoveFolderFromExclusions);
            this.tabPageFolderFiltering.Controls.Add(this.btnAddFolderToExclusions);
            this.tabPageFolderFiltering.Location = new System.Drawing.Point(4, 22);
            this.tabPageFolderFiltering.Name = "tabPageFolderFiltering";
            this.tabPageFolderFiltering.Size = new System.Drawing.Size(660, 409);
            this.tabPageFolderFiltering.TabIndex = 2;
            this.tabPageFolderFiltering.Tag = "335, 520";
            this.tabPageFolderFiltering.Text = "Folder Filtering";
            this.tabPageFolderFiltering.UseVisualStyleBackColor = true;
            // 
            // upDownSearchDepth
            // 
            this.upDownSearchDepth.Location = new System.Drawing.Point(255, 352);
            this.upDownSearchDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.upDownSearchDepth.Name = "upDownSearchDepth";
            this.upDownSearchDepth.Size = new System.Drawing.Size(53, 20);
            this.upDownSearchDepth.TabIndex = 6;
            this.upDownSearchDepth.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 354);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(236, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Search depth (specify -1 to search all subfolders)";
            // 
            // lstExcludedDirectories
            // 
            this.lstExcludedDirectories.FormattingEnabled = true;
            this.lstExcludedDirectories.Location = new System.Drawing.Point(11, 25);
            this.lstExcludedDirectories.Name = "lstExcludedDirectories";
            this.lstExcludedDirectories.Size = new System.Drawing.Size(297, 277);
            this.lstExcludedDirectories.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(219, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Exclude these folder as well as their contents";
            // 
            // btnClearExcludedFoldersList
            // 
            this.btnClearExcludedFoldersList.Location = new System.Drawing.Point(218, 308);
            this.btnClearExcludedFoldersList.Name = "btnClearExcludedFoldersList";
            this.btnClearExcludedFoldersList.Size = new System.Drawing.Size(90, 28);
            this.btnClearExcludedFoldersList.TabIndex = 4;
            this.btnClearExcludedFoldersList.Text = "R&emove All";
            this.btnClearExcludedFoldersList.UseVisualStyleBackColor = true;
            this.btnClearExcludedFoldersList.Click += new System.EventHandler(this.btnClearExcludedFoldersList_Click);
            // 
            // btnRemoveFolderFromExclusions
            // 
            this.btnRemoveFolderFromExclusions.Location = new System.Drawing.Point(115, 308);
            this.btnRemoveFolderFromExclusions.Name = "btnRemoveFolderFromExclusions";
            this.btnRemoveFolderFromExclusions.Size = new System.Drawing.Size(90, 28);
            this.btnRemoveFolderFromExclusions.TabIndex = 3;
            this.btnRemoveFolderFromExclusions.Text = "&Remove";
            this.btnRemoveFolderFromExclusions.UseVisualStyleBackColor = true;
            this.btnRemoveFolderFromExclusions.Click += new System.EventHandler(this.btnRemoveFolderFromExclusions_Click);
            // 
            // btnAddFolderToExclusions
            // 
            this.btnAddFolderToExclusions.Location = new System.Drawing.Point(11, 308);
            this.btnAddFolderToExclusions.Name = "btnAddFolderToExclusions";
            this.btnAddFolderToExclusions.Size = new System.Drawing.Size(90, 28);
            this.btnAddFolderToExclusions.TabIndex = 2;
            this.btnAddFolderToExclusions.Text = "&Add";
            this.btnAddFolderToExclusions.UseVisualStyleBackColor = true;
            this.btnAddFolderToExclusions.Click += new System.EventHandler(this.btnAddFolderToExclusions_Click);
            // 
            // tabPageFileFiltering
            // 
            this.tabPageFileFiltering.Controls.Add(this.btnClearExcludedFiles);
            this.tabPageFileFiltering.Controls.Add(this.btnRemoveFileFromExclusions);
            this.tabPageFileFiltering.Controls.Add(this.btnAddFileToExclusions);
            this.tabPageFileFiltering.Controls.Add(this.label16);
            this.tabPageFileFiltering.Controls.Add(this.lstExcludedFiles);
            this.tabPageFileFiltering.Controls.Add(this.grpFileTypeFilter);
            this.tabPageFileFiltering.Controls.Add(this.grpDateFilterSettings);
            this.tabPageFileFiltering.Controls.Add(this.chkDateFilter);
            this.tabPageFileFiltering.Controls.Add(this.grpAttributesFilterSettings);
            this.tabPageFileFiltering.Controls.Add(this.chkAttributesFilter);
            this.tabPageFileFiltering.Controls.Add(this.grpSizeFilterSettings);
            this.tabPageFileFiltering.Controls.Add(this.chkSizeFilter);
            this.tabPageFileFiltering.Location = new System.Drawing.Point(4, 22);
            this.tabPageFileFiltering.Name = "tabPageFileFiltering";
            this.tabPageFileFiltering.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFileFiltering.Size = new System.Drawing.Size(660, 409);
            this.tabPageFileFiltering.TabIndex = 1;
            this.tabPageFileFiltering.Tag = "675, 520";
            this.tabPageFileFiltering.Text = "File Filtering";
            this.tabPageFileFiltering.UseVisualStyleBackColor = true;
            // 
            // btnClearExcludedFiles
            // 
            this.btnClearExcludedFiles.Location = new System.Drawing.Point(563, 374);
            this.btnClearExcludedFiles.Name = "btnClearExcludedFiles";
            this.btnClearExcludedFiles.Size = new System.Drawing.Size(90, 28);
            this.btnClearExcludedFiles.TabIndex = 11;
            this.btnClearExcludedFiles.Text = "Remove A&ll";
            this.btnClearExcludedFiles.UseVisualStyleBackColor = true;
            this.btnClearExcludedFiles.Click += new System.EventHandler(this.btnClearExcludedFiles_Click);
            // 
            // btnRemoveFileFromExclusions
            // 
            this.btnRemoveFileFromExclusions.Location = new System.Drawing.Point(462, 374);
            this.btnRemoveFileFromExclusions.Name = "btnRemoveFileFromExclusions";
            this.btnRemoveFileFromExclusions.Size = new System.Drawing.Size(90, 28);
            this.btnRemoveFileFromExclusions.TabIndex = 10;
            this.btnRemoveFileFromExclusions.Text = "&Remove";
            this.btnRemoveFileFromExclusions.UseVisualStyleBackColor = true;
            this.btnRemoveFileFromExclusions.Click += new System.EventHandler(this.btnRemoveFileFromExclusions_Click);
            // 
            // btnAddFileToExclusions
            // 
            this.btnAddFileToExclusions.Location = new System.Drawing.Point(361, 374);
            this.btnAddFileToExclusions.Name = "btnAddFileToExclusions";
            this.btnAddFileToExclusions.Size = new System.Drawing.Size(90, 28);
            this.btnAddFileToExclusions.TabIndex = 9;
            this.btnAddFileToExclusions.Text = "&Add";
            this.btnAddFileToExclusions.UseVisualStyleBackColor = true;
            this.btnAddFileToExclusions.Click += new System.EventHandler(this.btnAddFileToExclusions_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(358, 198);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Exclude these files";
            // 
            // lstExcludedFiles
            // 
            this.lstExcludedFiles.FormattingEnabled = true;
            this.lstExcludedFiles.HorizontalScrollbar = true;
            this.lstExcludedFiles.Location = new System.Drawing.Point(361, 214);
            this.lstExcludedFiles.Name = "lstExcludedFiles";
            this.lstExcludedFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstExcludedFiles.Size = new System.Drawing.Size(292, 147);
            this.lstExcludedFiles.TabIndex = 8;
            // 
            // grpFileTypeFilter
            // 
            this.grpFileTypeFilter.Controls.Add(this.radioIncludeTypes);
            this.grpFileTypeFilter.Controls.Add(this.radioExcludeTypes);
            this.grpFileTypeFilter.Controls.Add(this.txtFileTypes);
            this.grpFileTypeFilter.Controls.Add(this.label9);
            this.grpFileTypeFilter.Location = new System.Drawing.Point(6, 284);
            this.grpFileTypeFilter.Name = "grpFileTypeFilter";
            this.grpFileTypeFilter.Size = new System.Drawing.Size(350, 118);
            this.grpFileTypeFilter.TabIndex = 2;
            this.grpFileTypeFilter.TabStop = false;
            this.grpFileTypeFilter.Text = "File type filtering";
            // 
            // radioIncludeTypes
            // 
            this.radioIncludeTypes.AutoSize = true;
            this.radioIncludeTypes.Location = new System.Drawing.Point(11, 42);
            this.radioIncludeTypes.Name = "radioIncludeTypes";
            this.radioIncludeTypes.Size = new System.Drawing.Size(207, 17);
            this.radioIncludeTypes.TabIndex = 1;
            this.radioIncludeTypes.Text = "&Include files with only these extensions";
            this.radioIncludeTypes.UseVisualStyleBackColor = true;
            // 
            // radioExcludeTypes
            // 
            this.radioExcludeTypes.AutoSize = true;
            this.radioExcludeTypes.Checked = true;
            this.radioExcludeTypes.Location = new System.Drawing.Point(11, 19);
            this.radioExcludeTypes.Name = "radioExcludeTypes";
            this.radioExcludeTypes.Size = new System.Drawing.Size(188, 17);
            this.radioExcludeTypes.TabIndex = 0;
            this.radioExcludeTypes.TabStop = true;
            this.radioExcludeTypes.Text = "E&xclude files with these extensions";
            this.radioExcludeTypes.UseVisualStyleBackColor = true;
            // 
            // txtFileTypes
            // 
            this.txtFileTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtFileTypes.Location = new System.Drawing.Point(11, 65);
            this.txtFileTypes.Name = "txtFileTypes";
            this.txtFileTypes.Size = new System.Drawing.Size(332, 20);
            this.txtFileTypes.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(318, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "(use semicolon to separate multiple entries. For ex: .jpg;.bmp;.mp3)";
            // 
            // grpDateFilterSettings
            // 
            this.grpDateFilterSettings.Controls.Add(this.chkAccessedDate);
            this.grpDateFilterSettings.Controls.Add(this.dateAccessedE);
            this.grpDateFilterSettings.Controls.Add(this.chkModifiedDate);
            this.grpDateFilterSettings.Controls.Add(this.dateModifiedE);
            this.grpDateFilterSettings.Controls.Add(this.dateAccessedB);
            this.grpDateFilterSettings.Controls.Add(this.chkCreatedDate);
            this.grpDateFilterSettings.Controls.Add(this.dateModifiedB);
            this.grpDateFilterSettings.Controls.Add(this.label10);
            this.grpDateFilterSettings.Controls.Add(this.dateCreatedE);
            this.grpDateFilterSettings.Controls.Add(this.label8);
            this.grpDateFilterSettings.Controls.Add(this.dateCreatedB);
            this.grpDateFilterSettings.Controls.Add(this.label15);
            this.grpDateFilterSettings.Controls.Add(this.label12);
            this.grpDateFilterSettings.Enabled = false;
            this.grpDateFilterSettings.Location = new System.Drawing.Point(6, 23);
            this.grpDateFilterSettings.Name = "grpDateFilterSettings";
            this.grpDateFilterSettings.Size = new System.Drawing.Size(350, 252);
            this.grpDateFilterSettings.TabIndex = 1;
            this.grpDateFilterSettings.TabStop = false;
            this.grpDateFilterSettings.Text = "Configure date filtering";
            // 
            // chkAccessedDate
            // 
            this.chkAccessedDate.AutoSize = true;
            this.chkAccessedDate.Location = new System.Drawing.Point(11, 181);
            this.chkAccessedDate.Name = "chkAccessedDate";
            this.chkAccessedDate.Size = new System.Drawing.Size(141, 17);
            this.chkAccessedDate.TabIndex = 9;
            this.chkAccessedDate.Text = "Accessed date bet&ween";
            this.chkAccessedDate.UseVisualStyleBackColor = true;
            this.chkAccessedDate.CheckedChanged += new System.EventHandler(this.chkAccessedDate_CheckedChanged);
            // 
            // dateAccessedE
            // 
            this.dateAccessedE.CustomFormat = "DD/MM/YYYY";
            this.dateAccessedE.Enabled = false;
            this.dateAccessedE.Location = new System.Drawing.Point(156, 220);
            this.dateAccessedE.Name = "dateAccessedE";
            this.dateAccessedE.Size = new System.Drawing.Size(187, 20);
            this.dateAccessedE.TabIndex = 12;
            // 
            // chkModifiedDate
            // 
            this.chkModifiedDate.AutoSize = true;
            this.chkModifiedDate.Location = new System.Drawing.Point(11, 108);
            this.chkModifiedDate.Name = "chkModifiedDate";
            this.chkModifiedDate.Size = new System.Drawing.Size(134, 17);
            this.chkModifiedDate.TabIndex = 5;
            this.chkModifiedDate.Text = "Modi&fied date between";
            this.chkModifiedDate.UseVisualStyleBackColor = true;
            this.chkModifiedDate.CheckedChanged += new System.EventHandler(this.chkModifiedDate_CheckedChanged);
            // 
            // dateModifiedE
            // 
            this.dateModifiedE.CustomFormat = "DD/MM/YYYY";
            this.dateModifiedE.Enabled = false;
            this.dateModifiedE.Location = new System.Drawing.Point(156, 147);
            this.dateModifiedE.Name = "dateModifiedE";
            this.dateModifiedE.Size = new System.Drawing.Size(187, 20);
            this.dateModifiedE.TabIndex = 8;
            // 
            // dateAccessedB
            // 
            this.dateAccessedB.CustomFormat = "DD/MM/YYYY";
            this.dateAccessedB.Enabled = false;
            this.dateAccessedB.Location = new System.Drawing.Point(156, 181);
            this.dateAccessedB.Name = "dateAccessedB";
            this.dateAccessedB.Size = new System.Drawing.Size(187, 20);
            this.dateAccessedB.TabIndex = 10;
            // 
            // chkCreatedDate
            // 
            this.chkCreatedDate.AutoSize = true;
            this.chkCreatedDate.Location = new System.Drawing.Point(11, 35);
            this.chkCreatedDate.Name = "chkCreatedDate";
            this.chkCreatedDate.Size = new System.Drawing.Size(131, 17);
            this.chkCreatedDate.TabIndex = 1;
            this.chkCreatedDate.Text = "Cr&eated date between";
            this.chkCreatedDate.UseVisualStyleBackColor = true;
            this.chkCreatedDate.CheckedChanged += new System.EventHandler(this.chkCreatedDate_CheckedChanged);
            // 
            // dateModifiedB
            // 
            this.dateModifiedB.CustomFormat = "DD/MM/YYYY";
            this.dateModifiedB.Enabled = false;
            this.dateModifiedB.Location = new System.Drawing.Point(156, 108);
            this.dateModifiedB.Name = "dateModifiedB";
            this.dateModifiedB.Size = new System.Drawing.Size(187, 20);
            this.dateModifiedB.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(235, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "and";
            // 
            // dateCreatedE
            // 
            this.dateCreatedE.CustomFormat = "DD/MM/YYYY";
            this.dateCreatedE.Enabled = false;
            this.dateCreatedE.Location = new System.Drawing.Point(156, 74);
            this.dateCreatedE.Name = "dateCreatedE";
            this.dateCreatedE.Size = new System.Drawing.Size(187, 20);
            this.dateCreatedE.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(235, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "and";
            // 
            // dateCreatedB
            // 
            this.dateCreatedB.CustomFormat = "DD/MM/YYYY";
            this.dateCreatedB.Enabled = false;
            this.dateCreatedB.Location = new System.Drawing.Point(156, 35);
            this.dateCreatedB.Name = "dateCreatedB";
            this.dateCreatedB.Size = new System.Drawing.Size(187, 20);
            this.dateCreatedB.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Location = new System.Drawing.Point(235, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "and";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Only include files that have";
            // 
            // chkDateFilter
            // 
            this.chkDateFilter.AutoSize = true;
            this.chkDateFilter.Location = new System.Drawing.Point(6, 3);
            this.chkDateFilter.Name = "chkDateFilter";
            this.chkDateFilter.Size = new System.Drawing.Size(71, 17);
            this.chkDateFilter.TabIndex = 0;
            this.chkDateFilter.Text = "Da&te filter";
            this.chkDateFilter.UseVisualStyleBackColor = true;
            this.chkDateFilter.CheckedChanged += new System.EventHandler(this.chkDateFilter_CheckedChanged);
            // 
            // grpAttributesFilterSettings
            // 
            this.grpAttributesFilterSettings.Controls.Add(this.chkExcludeEncrypted);
            this.grpAttributesFilterSettings.Controls.Add(this.chkExcludeCompressed);
            this.grpAttributesFilterSettings.Controls.Add(this.chkExcludeROnly);
            this.grpAttributesFilterSettings.Controls.Add(this.chkExcludeArchive);
            this.grpAttributesFilterSettings.Controls.Add(this.chkExcludeSystem);
            this.grpAttributesFilterSettings.Controls.Add(this.chkExcludeHidden);
            this.grpAttributesFilterSettings.Enabled = false;
            this.grpAttributesFilterSettings.Location = new System.Drawing.Point(361, 120);
            this.grpAttributesFilterSettings.Name = "grpAttributesFilterSettings";
            this.grpAttributesFilterSettings.Size = new System.Drawing.Size(292, 70);
            this.grpAttributesFilterSettings.TabIndex = 6;
            this.grpAttributesFilterSettings.TabStop = false;
            this.grpAttributesFilterSettings.Text = "Exclude files with any of the following attributes";
            // 
            // chkExcludeEncrypted
            // 
            this.chkExcludeEncrypted.AutoSize = true;
            this.chkExcludeEncrypted.Location = new System.Drawing.Point(204, 44);
            this.chkExcludeEncrypted.Name = "chkExcludeEncrypted";
            this.chkExcludeEncrypted.Size = new System.Drawing.Size(74, 17);
            this.chkExcludeEncrypted.TabIndex = 5;
            this.chkExcludeEncrypted.Text = "Encrypted";
            this.chkExcludeEncrypted.UseVisualStyleBackColor = true;
            // 
            // chkExcludeCompressed
            // 
            this.chkExcludeCompressed.AutoSize = true;
            this.chkExcludeCompressed.Location = new System.Drawing.Point(101, 42);
            this.chkExcludeCompressed.Name = "chkExcludeCompressed";
            this.chkExcludeCompressed.Size = new System.Drawing.Size(84, 17);
            this.chkExcludeCompressed.TabIndex = 4;
            this.chkExcludeCompressed.Text = "Compressed";
            this.chkExcludeCompressed.UseVisualStyleBackColor = true;
            // 
            // chkExcludeROnly
            // 
            this.chkExcludeROnly.AutoSize = true;
            this.chkExcludeROnly.Location = new System.Drawing.Point(101, 19);
            this.chkExcludeROnly.Name = "chkExcludeROnly";
            this.chkExcludeROnly.Size = new System.Drawing.Size(76, 17);
            this.chkExcludeROnly.TabIndex = 1;
            this.chkExcludeROnly.Text = "Read &Only";
            this.chkExcludeROnly.UseVisualStyleBackColor = true;
            // 
            // chkExcludeArchive
            // 
            this.chkExcludeArchive.AutoSize = true;
            this.chkExcludeArchive.Location = new System.Drawing.Point(11, 19);
            this.chkExcludeArchive.Name = "chkExcludeArchive";
            this.chkExcludeArchive.Size = new System.Drawing.Size(62, 17);
            this.chkExcludeArchive.TabIndex = 0;
            this.chkExcludeArchive.Text = "Archi&ve";
            this.chkExcludeArchive.UseVisualStyleBackColor = true;
            // 
            // chkExcludeSystem
            // 
            this.chkExcludeSystem.AutoSize = true;
            this.chkExcludeSystem.Location = new System.Drawing.Point(11, 42);
            this.chkExcludeSystem.Name = "chkExcludeSystem";
            this.chkExcludeSystem.Size = new System.Drawing.Size(60, 17);
            this.chkExcludeSystem.TabIndex = 3;
            this.chkExcludeSystem.Text = "S&ystem";
            this.chkExcludeSystem.UseVisualStyleBackColor = true;
            // 
            // chkExcludeHidden
            // 
            this.chkExcludeHidden.AutoSize = true;
            this.chkExcludeHidden.Location = new System.Drawing.Point(204, 19);
            this.chkExcludeHidden.Name = "chkExcludeHidden";
            this.chkExcludeHidden.Size = new System.Drawing.Size(60, 17);
            this.chkExcludeHidden.TabIndex = 2;
            this.chkExcludeHidden.Text = "&Hidden";
            this.chkExcludeHidden.UseVisualStyleBackColor = true;
            // 
            // chkAttributesFilter
            // 
            this.chkAttributesFilter.AutoSize = true;
            this.chkAttributesFilter.Location = new System.Drawing.Point(361, 100);
            this.chkAttributesFilter.Name = "chkAttributesFilter";
            this.chkAttributesFilter.Size = new System.Drawing.Size(92, 17);
            this.chkAttributesFilter.TabIndex = 5;
            this.chkAttributesFilter.Text = "&Attributes filter";
            this.chkAttributesFilter.UseVisualStyleBackColor = true;
            this.chkAttributesFilter.CheckedChanged += new System.EventHandler(this.chkAttributesFilter_CheckedChanged);
            // 
            // grpSizeFilterSettings
            // 
            this.grpSizeFilterSettings.Controls.Add(this.txtFileSizeUBound);
            this.grpSizeFilterSettings.Controls.Add(this.txtFileSizeLBound);
            this.grpSizeFilterSettings.Controls.Add(this.label7);
            this.grpSizeFilterSettings.Controls.Add(this.label5);
            this.grpSizeFilterSettings.Controls.Add(this.label2);
            this.grpSizeFilterSettings.Enabled = false;
            this.grpSizeFilterSettings.Location = new System.Drawing.Point(361, 23);
            this.grpSizeFilterSettings.Name = "grpSizeFilterSettings";
            this.grpSizeFilterSettings.Size = new System.Drawing.Size(292, 71);
            this.grpSizeFilterSettings.TabIndex = 4;
            this.grpSizeFilterSettings.TabStop = false;
            this.grpSizeFilterSettings.Text = "Configure size filtering";
            // 
            // txtFileSizeUBound
            // 
            this.txtFileSizeUBound.Location = new System.Drawing.Point(150, 36);
            this.txtFileSizeUBound.MaxLength = 14;
            this.txtFileSizeUBound.Name = "txtFileSizeUBound";
            this.txtFileSizeUBound.Size = new System.Drawing.Size(104, 20);
            this.txtFileSizeUBound.TabIndex = 3;
            this.txtFileSizeUBound.Text = "0";
            this.txtFileSizeUBound.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // txtFileSizeLBound
            // 
            this.txtFileSizeLBound.Location = new System.Drawing.Point(11, 36);
            this.txtFileSizeLBound.MaxLength = 14;
            this.txtFileSizeLBound.Name = "txtFileSizeLBound";
            this.txtFileSizeLBound.Size = new System.Drawing.Size(102, 20);
            this.txtFileSizeLBound.TabIndex = 1;
            this.txtFileSizeLBound.Text = "0";
            this.txtFileSizeLBound.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "KBs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "and";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Only include files with size between:";
            // 
            // chkSizeFilter
            // 
            this.chkSizeFilter.AutoSize = true;
            this.chkSizeFilter.Location = new System.Drawing.Point(361, 3);
            this.chkSizeFilter.Name = "chkSizeFilter";
            this.chkSizeFilter.Size = new System.Drawing.Size(68, 17);
            this.chkSizeFilter.TabIndex = 3;
            this.chkSizeFilter.Text = "Si&ze filter";
            this.chkSizeFilter.UseVisualStyleBackColor = true;
            this.chkSizeFilter.CheckedChanged += new System.EventHandler(this.chkSizeFilter_CheckedChanged);
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.grpExtendedFileInfo);
            this.tabPageGeneral.Controls.Add(this.chkCopyExtendedFileInfo);
            this.tabPageGeneral.Controls.Add(this.label11);
            this.tabPageGeneral.Controls.Add(this.label4);
            this.tabPageGeneral.Controls.Add(this.label14);
            this.tabPageGeneral.Controls.Add(this.label13);
            this.tabPageGeneral.Controls.Add(this.label1);
            this.tabPageGeneral.Controls.Add(this.comboCategories);
            this.tabPageGeneral.Controls.Add(this.txtImagePic);
            this.tabPageGeneral.Controls.Add(this.txtCdDescription);
            this.tabPageGeneral.Controls.Add(this.txtCdName);
            this.tabPageGeneral.Controls.Add(this.txtSource);
            this.tabPageGeneral.Controls.Add(this.groupBox1);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(660, 409);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Tag = "395x520";
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // grpExtendedFileInfo
            // 
            this.grpExtendedFileInfo.Controls.Add(this.chkCopyDocInfo);
            this.grpExtendedFileInfo.Controls.Add(this.chkCopyFileAVInfo);
            this.grpExtendedFileInfo.Controls.Add(this.chkCopyFileVersionInfo);
            this.grpExtendedFileInfo.Controls.Add(this.chkCopyIcons);
            this.grpExtendedFileInfo.Enabled = false;
            this.grpExtendedFileInfo.Location = new System.Drawing.Point(362, 30);
            this.grpExtendedFileInfo.Name = "grpExtendedFileInfo";
            this.grpExtendedFileInfo.Size = new System.Drawing.Size(293, 110);
            this.grpExtendedFileInfo.TabIndex = 17;
            this.grpExtendedFileInfo.TabStop = false;
            this.grpExtendedFileInfo.Text = "Select the extended information";
            // 
            // chkCopyDocInfo
            // 
            this.chkCopyDocInfo.AutoSize = true;
            this.chkCopyDocInfo.Location = new System.Drawing.Point(6, 65);
            this.chkCopyDocInfo.Name = "chkCopyDocInfo";
            this.chkCopyDocInfo.Size = new System.Drawing.Size(157, 17);
            this.chkCopyDocInfo.TabIndex = 20;
            this.chkCopyDocInfo.Text = "Copy document information.";
            this.chkCopyDocInfo.UseVisualStyleBackColor = true;
            // 
            // chkCopyFileAVInfo
            // 
            this.chkCopyFileAVInfo.AutoSize = true;
            this.chkCopyFileAVInfo.Location = new System.Drawing.Point(6, 42);
            this.chkCopyFileAVInfo.Name = "chkCopyFileAVInfo";
            this.chkCopyFileAVInfo.Size = new System.Drawing.Size(197, 17);
            this.chkCopyFileAVInfo.TabIndex = 19;
            this.chkCopyFileAVInfo.Text = "Copy file\'s audio && video information.";
            this.chkCopyFileAVInfo.UseVisualStyleBackColor = true;
            // 
            // chkCopyFileVersionInfo
            // 
            this.chkCopyFileVersionInfo.AutoSize = true;
            this.chkCopyFileVersionInfo.Location = new System.Drawing.Point(6, 19);
            this.chkCopyFileVersionInfo.Name = "chkCopyFileVersionInfo";
            this.chkCopyFileVersionInfo.Size = new System.Drawing.Size(167, 17);
            this.chkCopyFileVersionInfo.TabIndex = 18;
            this.chkCopyFileVersionInfo.Text = "Copy file\'s version information.";
            this.chkCopyFileVersionInfo.UseVisualStyleBackColor = true;
            // 
            // chkCopyIcons
            // 
            this.chkCopyIcons.AutoSize = true;
            this.chkCopyIcons.Location = new System.Drawing.Point(6, 88);
            this.chkCopyIcons.Name = "chkCopyIcons";
            this.chkCopyIcons.Size = new System.Drawing.Size(100, 17);
            this.chkCopyIcons.TabIndex = 21;
            this.chkCopyIcons.Text = "Copy file icons..";
            this.chkCopyIcons.UseVisualStyleBackColor = true;
            // 
            // chkCopyExtendedFileInfo
            // 
            this.chkCopyExtendedFileInfo.AutoSize = true;
            this.chkCopyExtendedFileInfo.Location = new System.Drawing.Point(362, 7);
            this.chkCopyExtendedFileInfo.Name = "chkCopyExtendedFileInfo";
            this.chkCopyExtendedFileInfo.Size = new System.Drawing.Size(170, 17);
            this.chkCopyExtendedFileInfo.TabIndex = 16;
            this.chkCopyExtendedFileInfo.Text = "C&opy extended file information.";
            this.chkCopyExtendedFileInfo.UseVisualStyleBackColor = true;
            this.chkCopyExtendedFileInfo.CheckedChanged += new System.EventHandler(this.chkCopyAdvancedFileInfo_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "S&elect a category.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Select a picture for this image.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 275);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(162, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Type a &description for this image.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 232);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(170, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Type a &name to identify this image.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select source path.";
            // 
            // comboCategories
            // 
            this.comboCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategories.FormattingEnabled = true;
            this.comboCategories.Location = new System.Drawing.Point(11, 176);
            this.comboCategories.MaxDropDownItems = 100;
            this.comboCategories.Name = "comboCategories";
            this.comboCategories.Size = new System.Drawing.Size(339, 21);
            this.comboCategories.TabIndex = 9;
            // 
            // txtImagePic
            // 
            this.txtImagePic.Location = new System.Drawing.Point(11, 107);
            this.txtImagePic.Name = "txtImagePic";
            this.txtImagePic.Size = new System.Drawing.Size(339, 20);
            this.txtImagePic.TabIndex = 6;
            // 
            // txtCdDescription
            // 
            this.txtCdDescription.Location = new System.Drawing.Point(11, 291);
            this.txtCdDescription.Multiline = true;
            this.txtCdDescription.Name = "txtCdDescription";
            this.txtCdDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCdDescription.Size = new System.Drawing.Size(339, 108);
            this.txtCdDescription.TabIndex = 15;
            // 
            // txtCdName
            // 
            this.txtCdName.Location = new System.Drawing.Point(11, 248);
            this.txtCdName.Name = "txtCdName";
            this.txtCdName.Size = new System.Drawing.Size(339, 20);
            this.txtCdName.TabIndex = 12;
            this.txtCdName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCdName_KeyPress);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(11, 38);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(339, 20);
            this.txtSource.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.btnBrowseImage);
            this.groupBox1.Controls.Add(this.btnNewCategory);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 399);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New image settings";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(254, 58);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 28);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(254, 128);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(90, 28);
            this.btnBrowseImage.TabIndex = 7;
            this.btnBrowseImage.Text = "B&rowse";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // btnNewCategory
            // 
            this.btnNewCategory.Location = new System.Drawing.Point(254, 198);
            this.btnNewCategory.Name = "btnNewCategory";
            this.btnNewCategory.Size = new System.Drawing.Size(90, 28);
            this.btnNewCategory.TabIndex = 10;
            this.btnNewCategory.Text = "&Create New";
            this.btnNewCategory.UseVisualStyleBackColor = true;
            this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
            // 
            // tabNewImageSettings
            // 
            this.tabNewImageSettings.Controls.Add(this.tabPageGeneral);
            this.tabNewImageSettings.Controls.Add(this.tabPageFileFiltering);
            this.tabNewImageSettings.Controls.Add(this.tabPageFolderFiltering);
            this.tabNewImageSettings.Location = new System.Drawing.Point(5, 3);
            this.tabNewImageSettings.Name = "tabNewImageSettings";
            this.tabNewImageSettings.SelectedIndex = 0;
            this.tabNewImageSettings.Size = new System.Drawing.Size(668, 435);
            this.tabNewImageSettings.TabIndex = 0;
            // 
            // WndNewImage
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(676, 477);
            this.Controls.Add(this.tabNewImageSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WndNewImage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Image";
            this.tabPageFolderFiltering.ResumeLayout(false);
            this.tabPageFolderFiltering.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSearchDepth)).EndInit();
            this.tabPageFileFiltering.ResumeLayout(false);
            this.tabPageFileFiltering.PerformLayout();
            this.grpFileTypeFilter.ResumeLayout(false);
            this.grpFileTypeFilter.PerformLayout();
            this.grpDateFilterSettings.ResumeLayout(false);
            this.grpDateFilterSettings.PerformLayout();
            this.grpAttributesFilterSettings.ResumeLayout(false);
            this.grpAttributesFilterSettings.PerformLayout();
            this.grpSizeFilterSettings.ResumeLayout(false);
            this.grpSizeFilterSettings.PerformLayout();
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.grpExtendedFileInfo.ResumeLayout(false);
            this.grpExtendedFileInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabNewImageSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.TabPage tabPageFolderFiltering;
        private System.Windows.Forms.NumericUpDown upDownSearchDepth;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox lstExcludedDirectories;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnRemoveFolderFromExclusions;
        private System.Windows.Forms.Button btnAddFolderToExclusions;
        private System.Windows.Forms.TabPage tabPageFileFiltering;
        private System.Windows.Forms.Button btnRemoveFileFromExclusions;
        private System.Windows.Forms.Button btnAddFileToExclusions;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox lstExcludedFiles;
        private System.Windows.Forms.GroupBox grpFileTypeFilter;
        private System.Windows.Forms.RadioButton radioIncludeTypes;
        private System.Windows.Forms.RadioButton radioExcludeTypes;
        private System.Windows.Forms.TextBox txtFileTypes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpDateFilterSettings;
        private System.Windows.Forms.CheckBox chkAccessedDate;
        private System.Windows.Forms.DateTimePicker dateAccessedE;
        private System.Windows.Forms.CheckBox chkModifiedDate;
        private System.Windows.Forms.DateTimePicker dateModifiedE;
        private System.Windows.Forms.DateTimePicker dateAccessedB;
        private System.Windows.Forms.CheckBox chkCreatedDate;
        private System.Windows.Forms.DateTimePicker dateModifiedB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateCreatedE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateCreatedB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkDateFilter;
        private System.Windows.Forms.GroupBox grpAttributesFilterSettings;
        private System.Windows.Forms.CheckBox chkExcludeROnly;
        private System.Windows.Forms.CheckBox chkExcludeArchive;
        private System.Windows.Forms.CheckBox chkExcludeSystem;
        private System.Windows.Forms.CheckBox chkExcludeHidden;
        private System.Windows.Forms.CheckBox chkAttributesFilter;
        private System.Windows.Forms.GroupBox grpSizeFilterSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSizeFilter;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.GroupBox grpExtendedFileInfo;
        private System.Windows.Forms.CheckBox chkCopyDocInfo;
        private System.Windows.Forms.CheckBox chkCopyFileAVInfo;
        private System.Windows.Forms.CheckBox chkCopyFileVersionInfo;
        private System.Windows.Forms.CheckBox chkCopyIcons;
        private System.Windows.Forms.CheckBox chkCopyExtendedFileInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboCategories;
        private System.Windows.Forms.TextBox txtImagePic;
        private System.Windows.Forms.TextBox txtCdDescription;
        private System.Windows.Forms.TextBox txtCdName;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnNewCategory;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabNewImageSettings;
        private System.Windows.Forms.Button btnClearExcludedFiles;
        private System.Windows.Forms.CheckBox chkExcludeEncrypted;
        private System.Windows.Forms.CheckBox chkExcludeCompressed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileSizeLBound;
        private System.Windows.Forms.TextBox txtFileSizeUBound;
        private System.Windows.Forms.Button btnClearExcludedFoldersList;
        private System.Windows.Forms.Button btnBrowse;
    }
}