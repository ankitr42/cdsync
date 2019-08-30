using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Virtual_File_System_Library;
using System.IO;
using CD_Sync_Portable.Properties;

namespace CD_Sync_Portable
{
    internal partial class WndAdvancedSearch : Form
    {
        List<ImageCategory> categories;
        List<ExtendedTreeNode> imageNodes;

        List<ListEntry> imagesToSearch;
        List<VFSSearchTerm> searchTerms;
        VFSSearchOptions searchOptions;

        public WndAdvancedSearch()
        {
            InitializeComponent();
            
            imageNodes = new List<ExtendedTreeNode>();
            searchTerms = new List<VFSSearchTerm>();
            searchOptions = new VFSSearchOptions();

            // Initialize combo boxes
            this.cBoxFileSizeMatchType.SelectedIndex = 2;
            this.cBoxFileSizeMatchType.SelectedIndexChanged += new System.EventHandler(this.cBoxFileSizeMatchType_SelectedIndexChanged);
            this.cBoxFileSizeLBoundUnit.SelectedIndex = 0;
            this.cBoxFileSizeUBoundUnit.SelectedIndex = 0;
            this.cBoxCreatedDateMatchType.SelectedIndex = 2;
            this.cBoxCreatedDateMatchType.SelectedIndexChanged += new System.EventHandler(this.cBoxCreatedDateMatchType_SelectedIndexChanged);
            this.cBoxAccessedDateMatchType.SelectedIndex = 2;
            this.cBoxAccessedDateMatchType.SelectedIndexChanged += new System.EventHandler(this.cBoxAccessedDateMatchType_SelectedIndexChanged);
            this.cBoxModifiedDateMatchType.SelectedIndex = 2;
            this.cBoxModifiedDateMatchType.SelectedIndexChanged += new System.EventHandler(this.cBoxModifiedDateMatchType_SelectedIndexChanged);
            this.cBoxSampleRateMatchType.SelectedIndex = 2;
            this.cBoxSampleRateMatchType.SelectedIndexChanged += new System.EventHandler(this.cBoxSampleRateMatchType_SelectedIndexChanged);
            this.cBoxBitrateMatchType.SelectedIndex = 2;
            this.cBoxBitrateMatchType.SelectedIndexChanged += new System.EventHandler(this.cBoxBitrateMatchType_SelectedIndexChanged);
            // -----------------------------------------------
        }

        internal List<VFSSearchTerm> SearchTerms
        {
            get { return searchTerms; }
        }

        internal List<ListEntry> ImagesToSearch
        {
            set { imagesToSearch = value; }
        }

        internal VFSSearchOptions SearchOptions
        {
            get { return searchOptions; }
            set { searchOptions = value; }
        }

        #region Event handlers

        #region Checkboxes
        private void chkFileSize_CheckedChanged(object sender, EventArgs e)
        {
            cBoxFileSizeMatchType.Enabled = true;
            if (chkFileSize.Checked)
                cBoxFileSizeMatchType_SelectedIndexChanged(sender, e);
            else
            {
                cBoxFileSizeMatchType.Enabled = false;
                txtFileSizeLBound.Enabled = false;
                cBoxFileSizeLBoundUnit.Enabled = false;
                lblFileSize.Enabled = false;
                txtFileSizeUBound.Enabled = false;
                cBoxFileSizeUBoundUnit.Enabled = false;
            }
        }

        private void chkCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            cBoxCreatedDateMatchType.Enabled = true;
            if (chkCreatedDate.Checked)
                cBoxCreatedDateMatchType_SelectedIndexChanged(sender, e);
            else
            {
                cBoxCreatedDateMatchType.Enabled = false;
                dTimeLBoundCreatedDate.Enabled = false;
                lblCreatedDate.Enabled = false;
                dTimeUBoundCreatedDate.Enabled = false;
            }
        }

        private void chkAccessedDate_CheckedChanged(object sender, EventArgs e)
        {
            cBoxAccessedDateMatchType.Enabled = true;
            if (chkAccessedDate.Checked)
                cBoxAccessedDateMatchType_SelectedIndexChanged(sender, e);
            else
            {
                cBoxAccessedDateMatchType.Enabled = false;
                dTimeLBoundAccessedDate.Enabled = false;
                lblAccessedDate.Enabled = false;
                dTimeUBoundAccessedDate.Enabled = false;
            }
        }

        private void chkModifiedDate_CheckedChanged(object sender, EventArgs e)
        {
            cBoxModifiedDateMatchType.Enabled = true;
            if (chkModifiedDate.Checked)
                cBoxModifiedDateMatchType_SelectedIndexChanged(sender, e);
            else
            {
                cBoxModifiedDateMatchType.Enabled = false;
                dTimeLBoundModifiedDate.Enabled = false;
                lblModifiedDate.Enabled = false;
                dTimeUBoundModifiedDate.Enabled = false;
            }
        }

        private void chkTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTitle.Checked)
            {
                txtTitle.Enabled = true;
                grpStringMatchType1.Enabled = true;
            }
            else
            {
                txtTitle.Enabled = false;
                grpStringMatchType1.Enabled = false;
            }
        }

        private void chkArtist_CheckedChanged(object sender, EventArgs e)
        {
            if (chkArtist.Checked)
            {
                txtArtist.Enabled = true;
                grpStringMatchType2.Enabled = true;
            }
            else
            {
                txtArtist.Enabled = false;
                grpStringMatchType2.Enabled = false;
            }

        }

        private void chkAlbum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlbum.Checked)
            {
                txtAlbum.Enabled = true;
                grpStringMatchType3.Enabled = true;
            }
            else
            {
                txtAlbum.Enabled = false;
                grpStringMatchType3.Enabled = false;
            }
        }

        private void chkGenre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGenre.Checked)
            {
                txtGenre.Enabled = true;
                grpStringMatchType4.Enabled = true;
            }
            else
            {
                txtGenre.Enabled = false;
                grpStringMatchType4.Enabled = false;
            }
        }

        private void chkBitrate_CheckedChanged(object sender, EventArgs e)
        {
            cBoxBitrateMatchType.Enabled = true;
            if (chkBitrate.Checked)
                cBoxBitrateMatchType_SelectedIndexChanged(sender, e);
            else
            {
                cBoxBitrateMatchType.Enabled = false;
                txtBitrateLBound.Enabled = false;
                lblBitrate.Enabled = false;
                txtBitrateUBound.Enabled = false;
                lblBitrate2.Enabled = false;
            }
        }

        private void chkSampleRate_CheckedChanged(object sender, EventArgs e)
        {
            cBoxSampleRateMatchType.Enabled = true;
            if (chkSampleRate.Checked)
                cBoxSampleRateMatchType_SelectedIndexChanged(sender, e);
            else
            {
                cBoxSampleRateMatchType.Enabled = false;
                txtSampleRateLBound.Enabled = false;
                lblSampleRate.Enabled = false;
                txtSampleRateUBound.Enabled = false;
                lblSampleRate2.Enabled = false;
            }
        }

        private void chkAttributes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAttributes.Checked)
            {
                chkSearchArchive.Enabled = true;
                chkSearchReadOnly.Enabled = true;
                chkSearchHidden.Enabled = true;
                chkSearchSystem.Enabled = true;
                chkSearchCompressed.Enabled = true;
                chkSearchEncrypted.Enabled = true;
            }
            else
            {
                chkSearchArchive.Enabled = false;
                chkSearchReadOnly.Enabled = false;
                chkSearchHidden.Enabled = false;
                chkSearchSystem.Enabled = false;
                chkSearchCompressed.Enabled = false;
                chkSearchEncrypted.Enabled = false;
            }
        }

        private void chkDescription_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDescription.Checked)
            {
                txtDescription.Enabled = true;
                grpStringMatchType5.Enabled = true;
            }
            else
            {
                txtDescription.Enabled = false;
                grpStringMatchType5.Enabled = false;
            }
        }

        private void chkAuthor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuthor.Checked)
            {
                txtAuthor.Enabled = true;
                grpStringMatchType6.Enabled = true;
            }
            else
            {
                txtAuthor.Enabled = false;
                grpStringMatchType6.Enabled = false;
            }
        }

        private void chkSubject_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSubject.Checked)
            {
                txtSubject.Enabled = true;
                grpStringMatchType7.Enabled = true;
            }
            else
            {
                txtSubject.Enabled = false;
                grpStringMatchType7.Enabled = false;
            }
        }

        private void chkCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategory.Checked)
            {
                txtCategory.Enabled = true;
                grpStringMatchType8.Enabled = true;
            }
            else
            {
                txtCategory.Enabled = false;
                grpStringMatchType8.Enabled = false;
            }
        }

        private void chkComments_CheckedChanged(object sender, EventArgs e)
        {
            if (chkComments.Checked)
            {
                txtComments.Enabled = true;
                grpStringMatchType9.Enabled = true;
            }
            else
            {
                txtComments.Enabled = false;
                grpStringMatchType9.Enabled = false;
            }
        }

        private void chkCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompany.Checked == true)
            {
                txtCompany.Enabled = true;
                grpStringMatchType10.Enabled = true;
            }
            else
            {
                txtCompany.Enabled = false;
                grpStringMatchType10.Enabled = false;
            }
        }
        #endregion

        #region Comboboxes
        private void cBoxFileSizeMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFileSizeLBound.Enabled = true;
            cBoxFileSizeLBoundUnit.Enabled = true;
            if (cBoxFileSizeMatchType.SelectedIndex == 2)
            {
                lblFileSize.Enabled = true;
                txtFileSizeUBound.Enabled = true;
                cBoxFileSizeUBoundUnit.Enabled = true;
            }
            else
            {
                lblFileSize.Enabled = false;
                txtFileSizeUBound.Enabled = false;
                cBoxFileSizeUBoundUnit.Enabled = false;
            }
        }

        private void cBoxCreatedDateMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dTimeLBoundCreatedDate.Enabled = true;
            if (cBoxCreatedDateMatchType.SelectedIndex == 2)
            {
                lblCreatedDate.Enabled = true;
                dTimeUBoundCreatedDate.Enabled = true;
            }
            else
            {
                lblCreatedDate.Enabled = false;
                dTimeUBoundCreatedDate.Enabled = false;
            }
        }

        private void cBoxAccessedDateMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dTimeLBoundAccessedDate.Enabled = true;
            if (cBoxAccessedDateMatchType.SelectedIndex == 2)
            {
                lblAccessedDate.Enabled = true;
                dTimeUBoundAccessedDate.Enabled = true;
            }
            else
            {
                lblAccessedDate.Enabled = false;
                dTimeUBoundAccessedDate.Enabled = false;
            }
        }

        private void cBoxModifiedDateMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dTimeLBoundModifiedDate.Enabled = true;
            if (cBoxModifiedDateMatchType.SelectedIndex == 2)
            {
                lblModifiedDate.Enabled = true;
                dTimeUBoundModifiedDate.Enabled = true;
            }
            else
            {
                lblModifiedDate.Enabled = false;
                dTimeUBoundModifiedDate.Enabled = false;
            }
        }

        private void cBoxBitrateMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBitrateLBound.Enabled = true;
            if (cBoxBitrateMatchType.SelectedIndex == 2)
            {
                lblBitrate.Text = "Kbps and";
                lblBitrate.Enabled = true;
                txtBitrateUBound.Enabled = true;
                lblBitrate2.Enabled = true;
            }
            else
            {
                lblBitrate.Text = "Kbps    ";
                txtBitrateUBound.Enabled = false;
                lblBitrate2.Enabled = false;
            }
        }

        private void cBoxSampleRateMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSampleRateLBound.Enabled = true;
            if (cBoxSampleRateMatchType.SelectedIndex == 2)
            {
                lblSampleRate.Text = "Hz and";
                lblSampleRate.Enabled = true;
                txtSampleRateUBound.Enabled = true;
                lblSampleRate2.Enabled = true;
            }
            else
            {
                lblSampleRate.Text = "Hz    ";
                txtSampleRateUBound.Enabled = false;
                lblSampleRate2.Enabled = false;
            }
        }
        #endregion

        private void WndAdvancedSearch_Load(object sender, EventArgs e)
        {
            imageNodes.Clear();
            treeImageSelector.Nodes.Clear();
            treeImageSelector.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Categorized Images", 0, 0));
            treeImageSelector.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Uncategorized Images", 0, 0));
            treeImageSelector.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Deleted Categories", 0, 0));

            categories = CategoryManager.GetAllCategories();
            foreach (ImageCategory category in categories)
            {
                ExtendedTreeNode node = new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeCategory, category.categoryName);
                treeImageSelector.Nodes[0].Nodes.Add(node);
            }

            ImageListManipulator.ReadAllEntries(ImageListEntryProcessor);
            treeImageSelector.ExpandAll();
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private void rBtnSearchFolders_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnSearchFolders.Checked)
            {
                grpMusicAndAudioProperties.Enabled = false;
                grpDocumentProperties.Enabled = false;
            }
            else
            {
                grpMusicAndAudioProperties.Enabled = true;
                grpDocumentProperties.Enabled = true;
            }
        }

        private void treeImageSelector_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ExtendedTreeNode node = (ExtendedTreeNode)e.Node;

            treeImageSelector.AfterCheck -= treeImageSelector_AfterCheck;
            if (node.NodeType == ExtendedTreeNodeType.NodeTypeCategory || node.NodeType == ExtendedTreeNodeType.NodeTypeSuperCategory)
            {
                if (node.Checked == true)
                    CheckAllChildren(node);
                else
                    UnCheckAllChildren(node);
            }
            else
            {
                if (node.Checked == true)
                    node.Parent.Checked = true;
                else
                {
                    bool check = false;
                    foreach (ExtendedTreeNode cNode in node.Parent.Nodes)
                    {
                        if (cNode.Checked == true)
                            check = true;
                    }
                    node.Parent.Checked = check;
                }
            }
            treeImageSelector.AfterCheck += treeImageSelector_AfterCheck;
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string[] searchStrings;
            string temp;

            if (txtSearchText.Text.Length == 0)
            {
                MessageBox.Show(Resources.msgNothingToSearch, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            temp = txtSearchText.Text;
            if (temp.Contains("\\") || temp.Contains("/") || temp.Contains(":") || temp.Contains("?") || 
                temp.Contains("\"") || temp.Contains("<") || temp.Contains(">") || temp.Contains("|"))
            {
                MessageBox.Show(Resources.msgInvalidFileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkFileSize.Checked)
            {
                if (txtFileSizeLBound.Text.Length == 0 || (cBoxFileSizeMatchType.SelectedIndex == 2 && txtFileSizeUBound.Text.Length == 0))
                {
                    MessageBox.Show(Resources.msgSpecifyFileSize, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkBitrate.Checked)
            {
                if (txtBitrateLBound.Text.Length == 0 || (cBoxBitrateMatchType.SelectedIndex == 2 && txtBitrateUBound.Text.Length == 0))
                {
                    MessageBox.Show(Resources.msgSpecifyBitrate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkSampleRate.Checked)
            {
                if (txtSampleRateLBound.Text.Length == 0 || (cBoxSampleRateMatchType.SelectedIndex == 2 && txtSampleRateUBound.Text.Length == 0))
                {
                    MessageBox.Show(Resources.msgSpecifySampleRate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            imagesToSearch.Clear();
            foreach (ExtendedTreeNode node in imageNodes)
            {
                if (node.Checked)
                    imagesToSearch.Add((ListEntry)node.NodeData);
            }

            if (imagesToSearch.Count == 0)
            {
                MessageBox.Show(Resources.msgNoImageSelectedToSearch, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            searchStrings = txtSearchText.Text.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            searchTerms.Clear();
            foreach (string str in searchStrings)
            {
                VFSSearchTerm term = new VFSSearchTerm();
                term.entry.name = str;

                if (chkFileSize.Checked)
                {
                    if (cBoxFileSizeLBoundUnit.SelectedIndex == 0)
                        term.minSize = Convert.ToUInt64(txtFileSizeLBound.Text);
                    else if (cBoxFileSizeLBoundUnit.SelectedIndex == 1)
                        term.minSize = Convert.ToUInt64(txtFileSizeLBound.Text) * 1024;
                    else if (cBoxFileSizeLBoundUnit.SelectedIndex == 2)
                        term.minSize = Convert.ToUInt64(txtFileSizeLBound.Text) * 1024 * 1024;
                    else if (cBoxFileSizeLBoundUnit.SelectedIndex == 3)
                        term.minSize = Convert.ToUInt64(txtFileSizeLBound.Text) * 1024 * 1024 * 1024;
                    else
                        term.minSize = Convert.ToUInt64(txtFileSizeLBound.Text) * 1024 * 1024 * 1024 * 1024;

                    if (cBoxFileSizeMatchType.SelectedIndex == 2)
                    {
                        if (cBoxFileSizeUBoundUnit.SelectedIndex == 0)
                            term.maxSize = Convert.ToUInt64(txtFileSizeUBound.Text);
                        else if (cBoxFileSizeUBoundUnit.SelectedIndex == 1)
                            term.maxSize = Convert.ToUInt64(txtFileSizeUBound.Text) * 1024;
                        else if (cBoxFileSizeUBoundUnit.SelectedIndex == 2)
                            term.maxSize = Convert.ToUInt64(txtFileSizeUBound.Text) * 1024 * 1024;
                        else if (cBoxFileSizeUBoundUnit.SelectedIndex == 3)
                            term.maxSize = Convert.ToUInt64(txtFileSizeUBound.Text) * 1024 * 1024 * 1024;
                        else
                            term.maxSize = Convert.ToUInt64(txtFileSizeUBound.Text) * 1024 * 1024 * 1024 * 1024;
                    }
                }

                term.bCreatedDate = dTimeLBoundCreatedDate.Value;
                term.eCreatedDate = dTimeUBoundCreatedDate.Value;
                term.bAccessedDate = dTimeLBoundAccessedDate.Value;
                term.eAccessedDate = dTimeUBoundAccessedDate.Value;
                term.bModifiedDate = dTimeLBoundModifiedDate.Value;
                term.eModifiedDate = dTimeUBoundModifiedDate.Value;

                term.entry.isArch = chkSearchArchive.Checked;
                term.entry.isROnly = chkSearchReadOnly.Checked;
                term.entry.isHidden = chkSearchHidden.Checked;
                term.entry.isSystem = chkSearchSystem.Checked;
                term.entry.isCompressed = chkSearchCompressed.Checked;
                term.entry.isEncrypted = chkSearchEncrypted.Checked;

                term.entry.title = txtTitle.Text;
                term.entry.artist = txtArtist.Text;
                term.entry.album = txtAlbum.Text;
                term.entry.genre = txtGenre.Text;

                if (chkBitrate.Checked)
                {
                    term.minBitRate = Convert.ToUInt32(txtBitrateLBound.Text);
                    term.maxBitRate = Convert.ToUInt32(txtBitrateUBound.Text);
                }
                if (chkSampleRate.Checked)
                {
                    term.minSampleRate = Convert.ToUInt32(txtSampleRateLBound.Text);
                    term.maxSampleRate = Convert.ToUInt32(txtSampleRateUBound.Text);
                }

                term.entry.description = txtDescription.Text;
                term.entry.author = txtAuthor.Text;
                term.entry.subject = txtSubject.Text;
                term.entry.category = txtCategory.Text;
                term.entry.comments = txtComments.Text;
                term.entry.company = txtCompany.Text;

                searchTerms.Add(term);
            }

            searchOptions = new VFSSearchOptions();

            if (rBtnSearchFiles.Checked)
                searchOptions.searchOnlyForFiles = true;
            else if (rBtnSearchFolders.Checked)
                searchOptions.searchOnlyForDirectories = true;

            if (chkFileSize.Checked)
            {
                if (cBoxFileSizeMatchType.SelectedIndex == 0)
                    searchOptions.sizeUBound = true;
                else if (cBoxFileSizeMatchType.SelectedIndex == 1)
                    searchOptions.sizeLBound = true;
                else if (cBoxFileSizeMatchType.SelectedIndex == 2)
                    searchOptions.sizeRange = true;
                else
                    searchOptions.sizeExact = true;
            }
            if (chkAccessedDate.Checked)
            {
                if (cBoxAccessedDateMatchType.SelectedIndex == 0)
                    searchOptions.aDateUBound = true;
                else if (cBoxAccessedDateMatchType.SelectedIndex == 1)
                    searchOptions.aDateLBound = true;
                else if (cBoxAccessedDateMatchType.SelectedIndex == 2)
                    searchOptions.aDateRange = true;
                else
                    searchOptions.bitRateExact = true;
            }
            if (chkCreatedDate.Checked)
            {
                if (cBoxCreatedDateMatchType.SelectedIndex == 0)
                    searchOptions.cDateUBound = true;
                else if (cBoxCreatedDateMatchType.SelectedIndex == 1)
                    searchOptions.cDateLBound = true;
                else if (cBoxCreatedDateMatchType.SelectedIndex == 2)
                    searchOptions.cDateRange = true;
                else
                    searchOptions.cDateExact = true;
            }
            if (chkModifiedDate.Checked)
            {
                if (cBoxModifiedDateMatchType.SelectedIndex == 0)
                    searchOptions.mDateUBound = true;
                else if (cBoxModifiedDateMatchType.SelectedIndex == 1)
                    searchOptions.mDateLBound = true;
                else if (cBoxModifiedDateMatchType.SelectedIndex == 2)
                    searchOptions.mDateRange = true;
                else
                    searchOptions.mDateExact = true;
            }
            searchOptions.matchAttributes = chkAttributes.Checked;
            searchOptions.matchTitle = (chkTitle.Checked && txtTitle.Text.Length > 0);
            searchOptions.matchTitleSubstring = rBtnTitleMatchSubstring.Checked;
            searchOptions.matchArtist = (chkArtist.Checked && txtArtist.Text.Length > 0);
            searchOptions.matchArtistSubstring = rBtnArtistMatchSubstring.Checked;
            searchOptions.matchAlbum = (chkAlbum.Checked && txtAlbum.Text.Length > 0);
            searchOptions.matchAlbumSubstring = rBtnAlbumMatchSubstring.Checked;
            searchOptions.matchGenre = (chkGenre.Checked && txtGenre.Text.Length > 0);
            searchOptions.matchGenreSubstring = rBtnGenreMatchSubstring.Checked;
            if (chkBitrate.Checked)
            {
                if (cBoxBitrateMatchType.SelectedIndex == 0)
                    searchOptions.bitRateUBound = true;
                else if (cBoxBitrateMatchType.SelectedIndex == 1)
                    searchOptions.bitRateLBound = true;
                else if (cBoxBitrateMatchType.SelectedIndex == 2)
                    searchOptions.bitRateRange = true;
                else
                    searchOptions.bitRateExact = true;
            }
            if (chkSampleRate.Checked)
            {
                if (cBoxSampleRateMatchType.SelectedIndex == 0)
                    searchOptions.sampleRateUBound = true;
                else if (cBoxSampleRateMatchType.SelectedIndex == 1)
                    searchOptions.sampleRateLBound = true;
                else if (cBoxSampleRateMatchType.SelectedIndex == 2)
                    searchOptions.sampleRateRange = true;
                else
                    searchOptions.sampleRateExact = true;
            }
            searchOptions.matchDescription = (chkDescription.Checked && txtDescription.Text.Length > 0);
            searchOptions.matchDescriptionSubstring = rBtnDescriptionMatchSubstring.Checked;
            searchOptions.matchAuthor = (chkAuthor.Checked && txtAuthor.Text.Length > 0);
            searchOptions.matchAuthorSubstring = rBtnAuthorMatchSubstring.Checked;
            searchOptions.matchSubject = (chkSubject.Checked && txtSubject.Text.Length > 0);
            searchOptions.matchSubjectSubstring = rBtnSubjectMatchSubstring.Checked;
            searchOptions.matchCategory = (chkCategory.Checked && txtCategory.Text.Length > 0);
            searchOptions.matchCategorySubstring = rBtnCategoryMatchSubstring.Checked;
            searchOptions.matchComments = (chkComments.Checked && txtComments.Text.Length > 0);
            searchOptions.matchCommentsSubstring = rBtnCommentsMatchSubstring.Checked;
            searchOptions.matchCompany = (chkCompany.Checked && txtCompany.Text.Length > 0);
            searchOptions.matchCompanySubstring = rBtnCompanyMatchSubstring.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void cBoxFileSizeLBoundUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxFileSizeLBoundUnit.SelectedIndex == 0)
                txtFileSizeLBound.MaxLength = 15;
            else if (cBoxFileSizeLBoundUnit.SelectedIndex == 1)
                txtFileSizeLBound.MaxLength = 10;
            else if (cBoxFileSizeLBoundUnit.SelectedIndex == 2)
                txtFileSizeLBound.MaxLength = 10;
            else if (cBoxFileSizeLBoundUnit.SelectedIndex == 3)
                txtFileSizeLBound.MaxLength = 8;
            else
                txtFileSizeLBound.MaxLength = 6;
        }

        private void cBoxFileSizeUBoundUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxFileSizeUBoundUnit.SelectedIndex == 0)
                txtFileSizeUBound.MaxLength = 15;
            else if (cBoxFileSizeUBoundUnit.SelectedIndex == 1)
                txtFileSizeUBound.MaxLength = 10;
            else if (cBoxFileSizeUBoundUnit.SelectedIndex == 2)
                txtFileSizeUBound.MaxLength = 10;
            else if (cBoxFileSizeUBoundUnit.SelectedIndex == 3)
                txtFileSizeUBound.MaxLength = 8;
            else
                txtFileSizeUBound.MaxLength = 6;
        }

        private void ImageListEntryProcessor(ListEntry imageEntry)
        {
            ExtendedTreeNode tempTreeNode = new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeImage, imageEntry.imageName, (object)imageEntry);

            tempTreeNode.ToolTipText = "Image Source: " + imageEntry.imageSourcePath;
            tempTreeNode.ToolTipText += Environment.NewLine + "Volume Label: " + imageEntry.imageSourceVolLabel;
            tempTreeNode.ToolTipText += Environment.NewLine + "File System: " + imageEntry.imageSourceFileSystem;
            tempTreeNode.ToolTipText += Environment.NewLine + "Source Type: " + ((DriveType)imageEntry.imageSourceDriveType).ToString();
            if (imageEntry.imageDescription.Length > 0)
                tempTreeNode.ToolTipText += Environment.NewLine + "Image Description: " + imageEntry.imageDescription;

            if (imagesToSearch.Contains(imageEntry))
                tempTreeNode.Checked = true;

            imageNodes.Add(tempTreeNode);
            if (imageEntry.imageCategory == "")
            {
                treeImageSelector.Nodes[1].Nodes.Add(tempTreeNode);
                return;
            }

            foreach (ExtendedTreeNode node in treeImageSelector.Nodes[0].Nodes)
            {
                if (node.NodeType == ExtendedTreeNodeType.NodeTypeCategory)
                {
                    if (String.Compare(imageEntry.imageCategory, node.Text, true) == 0)
                    {
                        node.Nodes.Add(tempTreeNode);
                        return;
                    }
                }
            }

            treeImageSelector.Nodes[2].Nodes.Add(tempTreeNode);
        }

        private void CheckAllChildren(ExtendedTreeNode parentNode)
        {
            foreach (ExtendedTreeNode node in parentNode.Nodes)
            {
                node.Checked = true;
                CheckAllChildren(node);
            }
        }

        private void UnCheckAllChildren(ExtendedTreeNode parentNode)
        {
            foreach (ExtendedTreeNode node in parentNode.Nodes)
            {
                node.Checked = false;
                UnCheckAllChildren(node);
            }
        }
    }
}