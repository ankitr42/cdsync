using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CD_Sync_Portable.Properties;
using Virtual_File_System_Library;

namespace CD_Sync_Portable
{
    internal partial class WndBasicSearch : Form
    {
        List<ImageCategory> categories;
        List<ExtendedTreeNode> imageNodes;
        
        List<ListEntry> imagesToSearch;
        List<VFSSearchTerm> searchTerms;

        internal List<VFSSearchTerm> SearchTerms
        {
            get { return searchTerms; }
        }

        internal List<ListEntry> ImagesToSearch
        {
            set { imagesToSearch = value; }
        }

        public WndBasicSearch()
        {
            InitializeComponent();
            imageNodes = new List<ExtendedTreeNode>();
            searchTerms = new List<VFSSearchTerm>();
        }

        private void WndBasicSearch_Load(object sender, EventArgs e)
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
                temp.Contains("\"") || temp.Contains("<") || temp.Contains(">"))
            {
                MessageBox.Show(Resources.msgInvalidFileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                searchTerms.Add(term);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void lnkLblAdvancedSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
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