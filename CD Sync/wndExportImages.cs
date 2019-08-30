using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Threading;
using CD_Sync_Portable.Properties;

namespace CD_Sync_Portable
{
    internal partial class WndExportImages : Form
    {
        List<ImageCategory> categories;
        List<ExtendedTreeNode> imageNodes;
        List<UInt32> preselectedImages;

        public WndExportImages()
        {
            InitializeComponent();
            folderBrowserDialog.SelectedPath = AppSettingsManager.DefaultBackupPath;
            imageNodes = new List<ExtendedTreeNode>();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                txtExportDirectory.Text = folderBrowserDialog.SelectedPath;
        }

        public void ShowDialog(List<UInt32> preselectedImages)
        {
            imageNodes.Clear();
            treeImageBrowser.Nodes.Clear();
            treeImageBrowser.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Categorized Images", 0, 0));
            treeImageBrowser.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Uncategorized Images", 0, 0));
            treeImageBrowser.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Deleted Categories", 0, 0));

            this.preselectedImages = preselectedImages;
            categories = CategoryManager.GetAllCategories();
            foreach (ImageCategory category in categories)
            {
                ExtendedTreeNode node = new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeCategory, category.categoryName);
                treeImageBrowser.Nodes[0].Nodes.Add(node);
            }

            ImageListManipulator.ReadAllEntries(ImageListEntryProcessor);
            treeImageBrowser.ExpandAll();
            base.ShowDialog();
        }

        private void ImageListEntryProcessor(ListEntry entry)
        {
            ExtendedTreeNode tempTreeNode = new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeImage, entry.imageName, (object)entry);

            tempTreeNode.ToolTipText = "Image Source: " + entry.imageSourcePath;
            tempTreeNode.ToolTipText += Environment.NewLine + "Volume Label: " + entry.imageSourceVolLabel;
            tempTreeNode.ToolTipText += Environment.NewLine + "File System: " + entry.imageSourceFileSystem;
            tempTreeNode.ToolTipText += Environment.NewLine + "Source Type: " + ((DriveType)entry.imageSourceDriveType).ToString();
            if (entry.imageDescription.Length > 0)
                tempTreeNode.ToolTipText += Environment.NewLine + "Image Description: " + entry.imageDescription;

            if (preselectedImages.Contains(entry.imageID))
                tempTreeNode.Checked = true;
            imageNodes.Add(tempTreeNode);
            if (entry.imageCategory == "")
            {
                treeImageBrowser.Nodes[1].Nodes.Add(tempTreeNode);
                return;
            }

            foreach (ExtendedTreeNode node in treeImageBrowser.Nodes[0].Nodes)
            {
                if (node.NodeType == ExtendedTreeNodeType.NodeTypeCategory)
                {
                    if (String.Compare(entry.imageCategory, node.Text, true) == 0)
                    {
                        node.Nodes.Add(tempTreeNode);
                        return;
                    }
                }
            }

            treeImageBrowser.Nodes[2].Nodes.Add(tempTreeNode);
        }

        private void treeImageBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (((ExtendedTreeNode)e.Node).NodeType == ExtendedTreeNodeType.NodeTypeImage)
            {
                ListEntry entry = (ListEntry)((ExtendedTreeNode)e.Node).NodeData;

                lblImageInfo.Text = entry.imageName;
                if (entry.imageDescription.Length > 0 && entry.imageDescription.Length < 50)
                    lblImageInfo.Text += Environment.NewLine + "Description: " + entry.imageDescription;
                else if (entry.imageDescription.Length >= 50)
                    lblImageInfo.Text += Environment.NewLine + "Description: " + entry.imageDescription.Substring(0, 47) + "...";
                if (object.ReferenceEquals(e.Node.Parent, treeImageBrowser.Nodes[2]))
                    lblImageInfo.Text += Environment.NewLine + "Category: " + entry.imageCategory;
                lblImageInfo.Text += Environment.NewLine + "Database file: " + entry.imageDbPath;
                lblImageInfo.Text += Environment.NewLine + "Source Path: ";
                if (entry.imageSourcePath.Length > 50)
                    lblImageInfo.Text += GeneralMethods.TruncatePathString(entry.imageSourcePath, 50);
                else
                    lblImageInfo.Text += entry.imageSourcePath;
                lblImageInfo.Text += Environment.NewLine + "Source Drive Type: " + ((DriveType)entry.imageSourceDriveType).ToString();
                if (entry.imageSourceFileSystem.Length > 0)
                    lblImageInfo.Text += Environment.NewLine + "Source File System: " + entry.imageSourceFileSystem;
                if (entry.imageSourceVolLabel.Length > 0)
                    lblImageInfo.Text += Environment.NewLine + "Source Volume Label: " + entry.imageSourceVolLabel;
            }
            else
            {
                lblImageInfo.Text = "Select an image to view its properties.";
            }
        }

        private void treeImageBrowser_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ExtendedTreeNode node = (ExtendedTreeNode)e.Node;

            treeImageBrowser.AfterCheck -= treeImageBrowser_AfterCheck;
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
            treeImageBrowser.AfterCheck += treeImageBrowser_AfterCheck;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult result;
            XmlElement tempElement1, tempElement2;
            XmlDocument exportDoc = new XmlDocument();
            WndAltFileNameInputBox wnd = new WndAltFileNameInputBox();
            List<ExtendedTreeNode> selectedImages = new List<ExtendedTreeNode>();
            WndImportExportProgress wndExportProgress;

            string msgExportFileExists = "The directory you've selected to export the images already contains some exported images. You can either:" + Environment.NewLine + Environment.NewLine;
                   msgExportFileExists += "1) Click 'Yes' to add your images to the list of existing images in the directory. OR" + Environment.NewLine;
                   msgExportFileExists += "2) Click 'No' to replace the list of existing images with a new one. Existing images in the directory will be lost. OR" + Environment.NewLine;
                   msgExportFileExists += "3) Click 'Cancel' to go back and select a different directory." + Environment.NewLine + Environment.NewLine;
                   msgExportFileExists += "Do you want to add your images to the list of existing images in the directory.";

            exportDoc.PreserveWhitespace = true;

            foreach (ExtendedTreeNode node in imageNodes)
                if (node.Checked)
                    selectedImages.Add(node);

            if (selectedImages.Count == 0)
            {
                MessageBox.Show(Resources.msgNoImageSelectedToExport, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtExportDirectory.Text.Length == 0)
            {
                MessageBox.Show(Resources.msgDestinationPathEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(txtExportDirectory.Text))
            {
                MessageBox.Show(Resources.msgDestinationFolderInAccessible, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (File.Exists(Path.Combine(txtExportDirectory.Text, Resources.fileExportedImagesXML)))
            {
                result = MessageBox.Show(msgExportFileExists, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    exportDoc.Load(Path.Combine(txtExportDirectory.Text, Resources.fileExportedImagesXML));

                    if (String.Compare(exportDoc.DocumentElement.LocalName, "Images", false) != 0)
                    {
                        if (MessageBox.Show(Resources.msgExistingExportFileCorrupt, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                        File.Delete(Path.Combine(txtExportDirectory.Text, Resources.fileExportedImagesXML));
                        exportDoc.RemoveAll();
                        exportDoc.AppendChild(exportDoc.CreateXmlDeclaration("1.0", "", ""));
                        exportDoc.AppendChild(exportDoc.CreateComment("Generated by CD Sync Portable"));
                        exportDoc.AppendChild(exportDoc.CreateElement("Images"));
                    }
                }
                else if (result == DialogResult.No)
                {
                    File.Delete(Path.Combine(txtExportDirectory.Text, Resources.fileExportedImagesXML));

                    exportDoc.AppendChild(exportDoc.CreateXmlDeclaration("1.0", "", ""));
                    exportDoc.AppendChild(exportDoc.CreateComment("Generated by CD Sync Portable"));
                    exportDoc.AppendChild(exportDoc.CreateElement("Images"));
                }
                else
                    return;
            }
            else
            {
                exportDoc.AppendChild(exportDoc.CreateXmlDeclaration("1.0", "", ""));
                exportDoc.AppendChild(exportDoc.CreateComment("Generated by CD Sync Portable"));
                exportDoc.AppendChild(exportDoc.CreateElement("Images"));
            }

            wndExportProgress = new WndImportExportProgress(selectedImages.Count, false);
            wndExportProgress.Show();

            foreach (ExtendedTreeNode node in selectedImages)
            {
                ListEntry tempListEntry = ((ListEntry)node.NodeData);

                wndExportProgress.BeginImportExport(tempListEntry);

                tempElement1 = exportDoc.CreateElement("Image");
                
                tempElement2 = exportDoc.CreateElement("Name");
                tempElement2.InnerText = tempListEntry.imageName;
                tempElement1.AppendChild(tempElement2);

                if (tempListEntry.imageDescription.Length > 0)
                {
                    tempElement2 = exportDoc.CreateElement("Description");
                    tempElement2.InnerText = tempListEntry.imageDescription;
                    tempElement1.AppendChild(tempElement2);
                }

                if (tempListEntry.imageCategory.Length > 0)
                {
                    tempElement2 = exportDoc.CreateElement("Category");
                    tempElement2.InnerText = tempListEntry.imageCategory;
                    tempElement1.AppendChild(tempElement2);
                }

                tempElement2 = exportDoc.CreateElement("SourcePath");
                tempElement2.InnerText = tempListEntry.imageSourcePath;
                tempElement1.AppendChild(tempElement2);

                if (tempListEntry.imageSourceVolLabel.Length > 0)
                {
                    tempElement2 = exportDoc.CreateElement("SourceVolLabel");
                    tempElement2.InnerText = tempListEntry.imageSourceVolLabel;
                    tempElement1.AppendChild(tempElement2);
                }

                if (tempListEntry.imageSourceFileSystem.Length > 0)
                {
                    tempElement2 = exportDoc.CreateElement("SourceFileSystem");
                    tempElement2.InnerText = tempListEntry.imageSourceFileSystem;
                    tempElement1.AppendChild(tempElement2);
                }

                tempElement2 = exportDoc.CreateElement("SourceDriveType");
                tempElement2.InnerText = tempListEntry.imageSourceDriveType.ToString();
                tempElement1.AppendChild(tempElement2);

                tempElement2 = exportDoc.CreateElement("VFSFile");
            L1:
                if (File.Exists(Path.Combine(txtExportDirectory.Text, tempListEntry.imageDbPath)))
                {
                    wnd.Tag = wnd.ShowDialog(tempListEntry.imageDbPath, txtExportDirectory.Text, "The export directory you selected" +
                                             " already contains the file " + tempListEntry.imageDbPath + ". Please specify a different filename.");

                    if (wnd.DialogResult == DialogResult.Ignore)
                    {
                        try { File.Delete(Path.Combine(txtExportDirectory.Text, (string)wnd.Tag)); }
                        catch
                        {
                            MessageBox.Show(Resources.msgCannotOverwrite, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto L1;
                        }
                    }

                    tempElement2.InnerText = (string)wnd.Tag;
                }
                else
                    tempElement2.InnerText = tempListEntry.imageDbPath;

                try
                {
                    File.Copy(Path.Combine(AppSettingsManager.ImagesDirectory, tempListEntry.imageDbPath), Path.Combine(txtExportDirectory.Text, tempElement2.InnerText));
                }
                catch
                {
                    MessageBox.Show("Cannot export image " + tempListEntry.imageName + ". An error occured during the file copy operation.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                tempElement1.AppendChild(tempElement2);

                tempElement2 = exportDoc.CreateElement("PictureFile");
            L2:
                if (File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, tempListEntry.imagePicture)))
                {
                    if (File.Exists(Path.Combine(txtExportDirectory.Text, tempListEntry.imagePicture)))
                    {
                        wnd.ShowDialog(tempListEntry.imagePicture, txtExportDirectory.Text, "The export directory you selected" +
                                       " already contains the file " + tempListEntry.imagePicture + ". Please specify a different filename.");

                        if (wnd.DialogResult == DialogResult.Ignore)
                        {
                            try { File.Delete(Path.Combine(txtExportDirectory.Text, (string)wnd.Tag)); }
                            catch
                            {
                                MessageBox.Show(Resources.msgCannotOverwrite, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                goto L2;
                            }
                        }
                        tempElement2.InnerText = (string)wnd.Tag;
                    }
                    else
                        tempElement2.InnerText = tempListEntry.imagePicture;

                    File.Copy(Path.Combine(AppSettingsManager.ImagesDirectory, tempListEntry.imagePicture), Path.Combine(txtExportDirectory.Text, tempElement2.InnerText));
                    tempElement1.AppendChild(tempElement2);
                }

                exportDoc.DocumentElement.AppendChild(tempElement1);
                wndExportProgress.ImportExportComplete();
            }

            wndExportProgress.Close();

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            writerSettings.NewLineChars = Environment.NewLine;
            
            XmlWriter tempWriter = XmlWriter.Create(Path.Combine(txtExportDirectory.Text, Resources.fileExportedImagesXML), writerSettings);

            exportDoc.WriteTo(tempWriter);
            tempWriter.Close();

            MessageBox.Show(Resources.msgExportSuccessful, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}