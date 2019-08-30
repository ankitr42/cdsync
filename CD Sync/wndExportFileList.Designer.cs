namespace CD_Sync_Portable
{
    partial class WndExportFileList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndExportFileList));
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.grpBoxMain = new System.Windows.Forms.GroupBox();
            this.grpColumnsToExport = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkShowCreatedDate = new System.Windows.Forms.CheckBox();
            this.chkShowGenre = new System.Windows.Forms.CheckBox();
            this.chkSelectAllDocProps = new System.Windows.Forms.CheckBox();
            this.chkSelectAllAVProps = new System.Windows.Forms.CheckBox();
            this.chkSelectAllFileProps = new System.Windows.Forms.CheckBox();
            this.chkShowSize = new System.Windows.Forms.CheckBox();
            this.chkShowProductVersion = new System.Windows.Forms.CheckBox();
            this.chkShowDuration = new System.Windows.Forms.CheckBox();
            this.chkShowDescription = new System.Windows.Forms.CheckBox();
            this.chkShowComments = new System.Windows.Forms.CheckBox();
            this.chkShowModifiedDate = new System.Windows.Forms.CheckBox();
            this.chkShowCompany = new System.Windows.Forms.CheckBox();
            this.chkShowAuthor = new System.Windows.Forms.CheckBox();
            this.chkShowSubject = new System.Windows.Forms.CheckBox();
            this.chkShowDimensions = new System.Windows.Forms.CheckBox();
            this.chkShowPages = new System.Windows.Forms.CheckBox();
            this.chkShowBitrate = new System.Windows.Forms.CheckBox();
            this.chkShowCategory = new System.Windows.Forms.CheckBox();
            this.chkShowSampleRate = new System.Windows.Forms.CheckBox();
            this.chkShowCopyright = new System.Windows.Forms.CheckBox();
            this.chkShowArtist = new System.Windows.Forms.CheckBox();
            this.chkShowProductName = new System.Windows.Forms.CheckBox();
            this.chkShowVersion = new System.Windows.Forms.CheckBox();
            this.chkShowTrackNumber = new System.Windows.Forms.CheckBox();
            this.chkShowTitle = new System.Windows.Forms.CheckBox();
            this.chkShowAttributes = new System.Windows.Forms.CheckBox();
            this.chkShowAlbumYear = new System.Windows.Forms.CheckBox();
            this.chkShowAccessedDate = new System.Windows.Forms.CheckBox();
            this.chkShowAlbum = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.grpBoxMain.SuspendLayout();
            this.grpColumnsToExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(268, 332);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 28);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(364, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFileName.Location = new System.Drawing.Point(7, 32);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(351, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(364, 27);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 28);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // grpBoxMain
            // 
            this.grpBoxMain.Controls.Add(this.grpColumnsToExport);
            this.grpBoxMain.Controls.Add(this.label1);
            this.grpBoxMain.Controls.Add(this.txtFileName);
            this.grpBoxMain.Controls.Add(this.btnCancel);
            this.grpBoxMain.Controls.Add(this.btnExport);
            this.grpBoxMain.Controls.Add(this.btnBrowse);
            this.grpBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxMain.Location = new System.Drawing.Point(0, 0);
            this.grpBoxMain.Name = "grpBoxMain";
            this.grpBoxMain.Size = new System.Drawing.Size(462, 368);
            this.grpBoxMain.TabIndex = 0;
            this.grpBoxMain.TabStop = false;
            this.grpBoxMain.Text = "Select export settings";
            // 
            // grpColumnsToExport
            // 
            this.grpColumnsToExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpColumnsToExport.Controls.Add(this.label2);
            this.grpColumnsToExport.Controls.Add(this.label3);
            this.grpColumnsToExport.Controls.Add(this.label6);
            this.grpColumnsToExport.Controls.Add(this.chkShowCreatedDate);
            this.grpColumnsToExport.Controls.Add(this.chkShowGenre);
            this.grpColumnsToExport.Controls.Add(this.chkSelectAllDocProps);
            this.grpColumnsToExport.Controls.Add(this.chkSelectAllAVProps);
            this.grpColumnsToExport.Controls.Add(this.chkSelectAllFileProps);
            this.grpColumnsToExport.Controls.Add(this.chkShowSize);
            this.grpColumnsToExport.Controls.Add(this.chkShowProductVersion);
            this.grpColumnsToExport.Controls.Add(this.chkShowDuration);
            this.grpColumnsToExport.Controls.Add(this.chkShowDescription);
            this.grpColumnsToExport.Controls.Add(this.chkShowComments);
            this.grpColumnsToExport.Controls.Add(this.chkShowModifiedDate);
            this.grpColumnsToExport.Controls.Add(this.chkShowCompany);
            this.grpColumnsToExport.Controls.Add(this.chkShowAuthor);
            this.grpColumnsToExport.Controls.Add(this.chkShowSubject);
            this.grpColumnsToExport.Controls.Add(this.chkShowDimensions);
            this.grpColumnsToExport.Controls.Add(this.chkShowPages);
            this.grpColumnsToExport.Controls.Add(this.chkShowBitrate);
            this.grpColumnsToExport.Controls.Add(this.chkShowCategory);
            this.grpColumnsToExport.Controls.Add(this.chkShowSampleRate);
            this.grpColumnsToExport.Controls.Add(this.chkShowCopyright);
            this.grpColumnsToExport.Controls.Add(this.chkShowArtist);
            this.grpColumnsToExport.Controls.Add(this.chkShowProductName);
            this.grpColumnsToExport.Controls.Add(this.chkShowVersion);
            this.grpColumnsToExport.Controls.Add(this.chkShowTrackNumber);
            this.grpColumnsToExport.Controls.Add(this.chkShowTitle);
            this.grpColumnsToExport.Controls.Add(this.chkShowAttributes);
            this.grpColumnsToExport.Controls.Add(this.chkShowAlbumYear);
            this.grpColumnsToExport.Controls.Add(this.chkShowAccessedDate);
            this.grpColumnsToExport.Controls.Add(this.chkShowAlbum);
            this.grpColumnsToExport.Location = new System.Drawing.Point(7, 61);
            this.grpColumnsToExport.Name = "grpColumnsToExport";
            this.grpColumnsToExport.Size = new System.Drawing.Size(447, 264);
            this.grpColumnsToExport.TabIndex = 3;
            this.grpColumnsToExport.TabStop = false;
            this.grpColumnsToExport.Text = "Select file details to be exported";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "File Properties";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(311, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Document Properties";
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(160, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "A/V Properties";
            // 
            // chkShowCreatedDate
            // 
            this.chkShowCreatedDate.AutoSize = true;
            this.chkShowCreatedDate.Location = new System.Drawing.Point(6, 103);
            this.chkShowCreatedDate.Name = "chkShowCreatedDate";
            this.chkShowCreatedDate.Size = new System.Drawing.Size(89, 17);
            this.chkShowCreatedDate.TabIndex = 4;
            this.chkShowCreatedDate.Text = "Created Date";
            this.chkShowCreatedDate.UseVisualStyleBackColor = true;
            // 
            // chkShowGenre
            // 
            this.chkShowGenre.AutoSize = true;
            this.chkShowGenre.Location = new System.Drawing.Point(160, 172);
            this.chkShowGenre.Name = "chkShowGenre";
            this.chkShowGenre.Size = new System.Drawing.Size(55, 17);
            this.chkShowGenre.TabIndex = 18;
            this.chkShowGenre.Text = "Genre";
            this.chkShowGenre.UseVisualStyleBackColor = true;
            // 
            // chkSelectAllDocProps
            // 
            this.chkSelectAllDocProps.AutoSize = true;
            this.chkSelectAllDocProps.Location = new System.Drawing.Point(311, 34);
            this.chkSelectAllDocProps.Name = "chkSelectAllDocProps";
            this.chkSelectAllDocProps.Size = new System.Drawing.Size(70, 17);
            this.chkSelectAllDocProps.TabIndex = 23;
            this.chkSelectAllDocProps.Text = "Select All";
            this.chkSelectAllDocProps.UseVisualStyleBackColor = true;
            this.chkSelectAllDocProps.CheckedChanged += new System.EventHandler(this.chkSelectAllDocProps_CheckedChanged);
            // 
            // chkSelectAllAVProps
            // 
            this.chkSelectAllAVProps.AutoSize = true;
            this.chkSelectAllAVProps.Location = new System.Drawing.Point(160, 34);
            this.chkSelectAllAVProps.Name = "chkSelectAllAVProps";
            this.chkSelectAllAVProps.Size = new System.Drawing.Size(70, 17);
            this.chkSelectAllAVProps.TabIndex = 12;
            this.chkSelectAllAVProps.Text = "Select All";
            this.chkSelectAllAVProps.UseVisualStyleBackColor = true;
            this.chkSelectAllAVProps.CheckedChanged += new System.EventHandler(this.chkSelectAllAVProps_CheckedChanged);
            // 
            // chkSelectAllFileProps
            // 
            this.chkSelectAllFileProps.AutoSize = true;
            this.chkSelectAllFileProps.Location = new System.Drawing.Point(6, 34);
            this.chkSelectAllFileProps.Name = "chkSelectAllFileProps";
            this.chkSelectAllFileProps.Size = new System.Drawing.Size(70, 17);
            this.chkSelectAllFileProps.TabIndex = 1;
            this.chkSelectAllFileProps.Text = "Select All";
            this.chkSelectAllFileProps.UseVisualStyleBackColor = true;
            this.chkSelectAllFileProps.CheckedChanged += new System.EventHandler(this.chkSelectAllFileProps_CheckedChanged);
            // 
            // chkShowSize
            // 
            this.chkShowSize.AutoSize = true;
            this.chkShowSize.Location = new System.Drawing.Point(6, 57);
            this.chkShowSize.Name = "chkShowSize";
            this.chkShowSize.Size = new System.Drawing.Size(65, 17);
            this.chkShowSize.TabIndex = 2;
            this.chkShowSize.Text = "File Size";
            this.chkShowSize.UseVisualStyleBackColor = true;
            // 
            // chkShowProductVersion
            // 
            this.chkShowProductVersion.AutoSize = true;
            this.chkShowProductVersion.Location = new System.Drawing.Point(6, 241);
            this.chkShowProductVersion.Name = "chkShowProductVersion";
            this.chkShowProductVersion.Size = new System.Drawing.Size(101, 17);
            this.chkShowProductVersion.TabIndex = 10;
            this.chkShowProductVersion.Text = "Product Version";
            this.chkShowProductVersion.UseVisualStyleBackColor = true;
            // 
            // chkShowDuration
            // 
            this.chkShowDuration.AutoSize = true;
            this.chkShowDuration.Location = new System.Drawing.Point(160, 149);
            this.chkShowDuration.Name = "chkShowDuration";
            this.chkShowDuration.Size = new System.Drawing.Size(66, 17);
            this.chkShowDuration.TabIndex = 17;
            this.chkShowDuration.Text = "Duration";
            this.chkShowDuration.UseVisualStyleBackColor = true;
            // 
            // chkShowDescription
            // 
            this.chkShowDescription.AutoSize = true;
            this.chkShowDescription.Location = new System.Drawing.Point(6, 172);
            this.chkShowDescription.Name = "chkShowDescription";
            this.chkShowDescription.Size = new System.Drawing.Size(79, 17);
            this.chkShowDescription.TabIndex = 7;
            this.chkShowDescription.Text = "Description";
            this.chkShowDescription.UseVisualStyleBackColor = true;
            // 
            // chkShowComments
            // 
            this.chkShowComments.AutoSize = true;
            this.chkShowComments.Location = new System.Drawing.Point(311, 172);
            this.chkShowComments.Name = "chkShowComments";
            this.chkShowComments.Size = new System.Drawing.Size(75, 17);
            this.chkShowComments.TabIndex = 29;
            this.chkShowComments.Text = "Comments";
            this.chkShowComments.UseVisualStyleBackColor = true;
            // 
            // chkShowModifiedDate
            // 
            this.chkShowModifiedDate.AutoSize = true;
            this.chkShowModifiedDate.Location = new System.Drawing.Point(6, 149);
            this.chkShowModifiedDate.Name = "chkShowModifiedDate";
            this.chkShowModifiedDate.Size = new System.Drawing.Size(92, 17);
            this.chkShowModifiedDate.TabIndex = 6;
            this.chkShowModifiedDate.Text = "Modified Date";
            this.chkShowModifiedDate.UseVisualStyleBackColor = true;
            // 
            // chkShowCompany
            // 
            this.chkShowCompany.AutoSize = true;
            this.chkShowCompany.Location = new System.Drawing.Point(311, 218);
            this.chkShowCompany.Name = "chkShowCompany";
            this.chkShowCompany.Size = new System.Drawing.Size(70, 17);
            this.chkShowCompany.TabIndex = 31;
            this.chkShowCompany.Text = "Company";
            this.chkShowCompany.UseVisualStyleBackColor = true;
            // 
            // chkShowAuthor
            // 
            this.chkShowAuthor.AutoSize = true;
            this.chkShowAuthor.Location = new System.Drawing.Point(311, 57);
            this.chkShowAuthor.Name = "chkShowAuthor";
            this.chkShowAuthor.Size = new System.Drawing.Size(57, 17);
            this.chkShowAuthor.TabIndex = 24;
            this.chkShowAuthor.Text = "Author";
            this.chkShowAuthor.UseVisualStyleBackColor = true;
            // 
            // chkShowSubject
            // 
            this.chkShowSubject.AutoSize = true;
            this.chkShowSubject.Location = new System.Drawing.Point(311, 103);
            this.chkShowSubject.Name = "chkShowSubject";
            this.chkShowSubject.Size = new System.Drawing.Size(62, 17);
            this.chkShowSubject.TabIndex = 26;
            this.chkShowSubject.Text = "Subject";
            this.chkShowSubject.UseVisualStyleBackColor = true;
            // 
            // chkShowDimensions
            // 
            this.chkShowDimensions.AutoSize = true;
            this.chkShowDimensions.Location = new System.Drawing.Point(160, 241);
            this.chkShowDimensions.Name = "chkShowDimensions";
            this.chkShowDimensions.Size = new System.Drawing.Size(80, 17);
            this.chkShowDimensions.TabIndex = 21;
            this.chkShowDimensions.Text = "Dimensions";
            this.chkShowDimensions.UseVisualStyleBackColor = true;
            // 
            // chkShowPages
            // 
            this.chkShowPages.AutoSize = true;
            this.chkShowPages.Location = new System.Drawing.Point(311, 149);
            this.chkShowPages.Name = "chkShowPages";
            this.chkShowPages.Size = new System.Drawing.Size(56, 17);
            this.chkShowPages.TabIndex = 28;
            this.chkShowPages.Text = "Pages";
            this.chkShowPages.UseVisualStyleBackColor = true;
            // 
            // chkShowBitrate
            // 
            this.chkShowBitrate.AutoSize = true;
            this.chkShowBitrate.Location = new System.Drawing.Point(160, 195);
            this.chkShowBitrate.Name = "chkShowBitrate";
            this.chkShowBitrate.Size = new System.Drawing.Size(56, 17);
            this.chkShowBitrate.TabIndex = 19;
            this.chkShowBitrate.Text = "Bitrate";
            this.chkShowBitrate.UseVisualStyleBackColor = true;
            // 
            // chkShowCategory
            // 
            this.chkShowCategory.AutoSize = true;
            this.chkShowCategory.Location = new System.Drawing.Point(311, 126);
            this.chkShowCategory.Name = "chkShowCategory";
            this.chkShowCategory.Size = new System.Drawing.Size(68, 17);
            this.chkShowCategory.TabIndex = 27;
            this.chkShowCategory.Text = "Category";
            this.chkShowCategory.UseVisualStyleBackColor = true;
            // 
            // chkShowSampleRate
            // 
            this.chkShowSampleRate.AutoSize = true;
            this.chkShowSampleRate.Location = new System.Drawing.Point(160, 218);
            this.chkShowSampleRate.Name = "chkShowSampleRate";
            this.chkShowSampleRate.Size = new System.Drawing.Size(87, 17);
            this.chkShowSampleRate.TabIndex = 20;
            this.chkShowSampleRate.Text = "Sample Rate";
            this.chkShowSampleRate.UseVisualStyleBackColor = true;
            // 
            // chkShowCopyright
            // 
            this.chkShowCopyright.AutoSize = true;
            this.chkShowCopyright.Location = new System.Drawing.Point(311, 195);
            this.chkShowCopyright.Name = "chkShowCopyright";
            this.chkShowCopyright.Size = new System.Drawing.Size(70, 17);
            this.chkShowCopyright.TabIndex = 30;
            this.chkShowCopyright.Text = "Copyright";
            this.chkShowCopyright.UseVisualStyleBackColor = true;
            // 
            // chkShowArtist
            // 
            this.chkShowArtist.AutoSize = true;
            this.chkShowArtist.Location = new System.Drawing.Point(160, 57);
            this.chkShowArtist.Name = "chkShowArtist";
            this.chkShowArtist.Size = new System.Drawing.Size(49, 17);
            this.chkShowArtist.TabIndex = 13;
            this.chkShowArtist.Text = "Artist";
            this.chkShowArtist.UseVisualStyleBackColor = true;
            // 
            // chkShowProductName
            // 
            this.chkShowProductName.AutoSize = true;
            this.chkShowProductName.Location = new System.Drawing.Point(6, 218);
            this.chkShowProductName.Name = "chkShowProductName";
            this.chkShowProductName.Size = new System.Drawing.Size(94, 17);
            this.chkShowProductName.TabIndex = 9;
            this.chkShowProductName.Text = "Product Name";
            this.chkShowProductName.UseVisualStyleBackColor = true;
            // 
            // chkShowVersion
            // 
            this.chkShowVersion.AutoSize = true;
            this.chkShowVersion.Location = new System.Drawing.Point(6, 195);
            this.chkShowVersion.Name = "chkShowVersion";
            this.chkShowVersion.Size = new System.Drawing.Size(80, 17);
            this.chkShowVersion.TabIndex = 8;
            this.chkShowVersion.Text = "File Version";
            this.chkShowVersion.UseVisualStyleBackColor = true;
            // 
            // chkShowTrackNumber
            // 
            this.chkShowTrackNumber.AutoSize = true;
            this.chkShowTrackNumber.Location = new System.Drawing.Point(160, 126);
            this.chkShowTrackNumber.Name = "chkShowTrackNumber";
            this.chkShowTrackNumber.Size = new System.Drawing.Size(94, 17);
            this.chkShowTrackNumber.TabIndex = 16;
            this.chkShowTrackNumber.Text = "Track Number";
            this.chkShowTrackNumber.UseVisualStyleBackColor = true;
            // 
            // chkShowTitle
            // 
            this.chkShowTitle.AutoSize = true;
            this.chkShowTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkShowTitle.Location = new System.Drawing.Point(311, 80);
            this.chkShowTitle.Name = "chkShowTitle";
            this.chkShowTitle.Size = new System.Drawing.Size(46, 17);
            this.chkShowTitle.TabIndex = 25;
            this.chkShowTitle.Text = "Title";
            this.chkShowTitle.UseVisualStyleBackColor = true;
            // 
            // chkShowAttributes
            // 
            this.chkShowAttributes.AutoSize = true;
            this.chkShowAttributes.Location = new System.Drawing.Point(6, 80);
            this.chkShowAttributes.Name = "chkShowAttributes";
            this.chkShowAttributes.Size = new System.Drawing.Size(70, 17);
            this.chkShowAttributes.TabIndex = 3;
            this.chkShowAttributes.Text = "Attributes";
            this.chkShowAttributes.UseVisualStyleBackColor = true;
            // 
            // chkShowAlbumYear
            // 
            this.chkShowAlbumYear.AutoSize = true;
            this.chkShowAlbumYear.Location = new System.Drawing.Point(160, 103);
            this.chkShowAlbumYear.Name = "chkShowAlbumYear";
            this.chkShowAlbumYear.Size = new System.Drawing.Size(80, 17);
            this.chkShowAlbumYear.TabIndex = 15;
            this.chkShowAlbumYear.Text = "Album Year";
            this.chkShowAlbumYear.UseVisualStyleBackColor = true;
            // 
            // chkShowAccessedDate
            // 
            this.chkShowAccessedDate.AutoSize = true;
            this.chkShowAccessedDate.Location = new System.Drawing.Point(6, 126);
            this.chkShowAccessedDate.Name = "chkShowAccessedDate";
            this.chkShowAccessedDate.Size = new System.Drawing.Size(99, 17);
            this.chkShowAccessedDate.TabIndex = 5;
            this.chkShowAccessedDate.Text = "Accessed Date";
            this.chkShowAccessedDate.UseVisualStyleBackColor = true;
            // 
            // chkShowAlbum
            // 
            this.chkShowAlbum.AutoSize = true;
            this.chkShowAlbum.Location = new System.Drawing.Point(160, 80);
            this.chkShowAlbum.Name = "chkShowAlbum";
            this.chkShowAlbum.Size = new System.Drawing.Size(55, 17);
            this.chkShowAlbum.TabIndex = 14;
            this.chkShowAlbum.Text = "Album";
            this.chkShowAlbum.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a file to export the filelist to:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "XML File|*.xml";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            this.saveFileDialog.Title = "Save filelist to...";
            // 
            // WndExportFileList
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(462, 368);
            this.Controls.Add(this.grpBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndExportFileList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Filelist";
            this.grpBoxMain.ResumeLayout(false);
            this.grpBoxMain.PerformLayout();
            this.grpColumnsToExport.ResumeLayout(false);
            this.grpColumnsToExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox grpBoxMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox grpColumnsToExport;
        private System.Windows.Forms.CheckBox chkShowCreatedDate;
        private System.Windows.Forms.CheckBox chkShowGenre;
        private System.Windows.Forms.CheckBox chkShowSize;
        private System.Windows.Forms.CheckBox chkShowProductVersion;
        private System.Windows.Forms.CheckBox chkShowDuration;
        private System.Windows.Forms.CheckBox chkShowDescription;
        private System.Windows.Forms.CheckBox chkShowComments;
        private System.Windows.Forms.CheckBox chkShowModifiedDate;
        private System.Windows.Forms.CheckBox chkShowCompany;
        private System.Windows.Forms.CheckBox chkShowAuthor;
        private System.Windows.Forms.CheckBox chkShowSubject;
        private System.Windows.Forms.CheckBox chkShowDimensions;
        private System.Windows.Forms.CheckBox chkShowPages;
        private System.Windows.Forms.CheckBox chkShowBitrate;
        private System.Windows.Forms.CheckBox chkShowCategory;
        private System.Windows.Forms.CheckBox chkShowSampleRate;
        private System.Windows.Forms.CheckBox chkShowCopyright;
        private System.Windows.Forms.CheckBox chkShowArtist;
        private System.Windows.Forms.CheckBox chkShowProductName;
        private System.Windows.Forms.CheckBox chkShowVersion;
        private System.Windows.Forms.CheckBox chkShowTrackNumber;
        private System.Windows.Forms.CheckBox chkShowTitle;
        private System.Windows.Forms.CheckBox chkShowAttributes;
        private System.Windows.Forms.CheckBox chkShowAlbumYear;
        private System.Windows.Forms.CheckBox chkShowAccessedDate;
        private System.Windows.Forms.CheckBox chkShowAlbum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSelectAllFileProps;
        private System.Windows.Forms.CheckBox chkSelectAllAVProps;
        private System.Windows.Forms.CheckBox chkSelectAllDocProps;

    }
}