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
using Virtual_File_System_Library;
using Utils.MessageBoxExLib;

namespace CD_Sync_Portable
{
    internal partial class WndImportImages : Form
    {
        List<ImageCategory> categories;
        List<ExtendedTreeNode> imageNodes;
        WndWaitBanner wndWaitBanner;
        WndImportExportProgress wndImportProgress;

        public WndImportImages()
        {
            InitializeComponent();
            folderBrowserDialog.SelectedPath = AppSettingsManager.DefaultRestorePath;
            imageNodes = new List<ExtendedTreeNode>();
            wndWaitBanner = new WndWaitBanner("");
            wndWaitBanner.Owner = this;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            wndWaitBanner.SetMessage("Reading image list. Please wait...");

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                bgImportListReader.RunWorkerAsync(folderBrowserDialog.SelectedPath);
                treeImageBrowser.Nodes.Clear();
                wndWaitBanner.ShowDialog();
            }
        }

        private void treeImageBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (((ExtendedTreeNode)e.Node).NodeType == ExtendedTreeNodeType.NodeTypeImage)
            {
                ListEntry entry = (ListEntry)((ExtendedTreeNode)e.Node).NodeData;

                lblImageInfo.Text = entry.imageName;
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
                    lblImageInfo.Text += Environment.NewLine + "Volume Label: " + entry.imageSourceVolLabel;
                if (entry.imageDescription.Length > 0 && entry.imageDescription.Length < 50)
                    lblImageInfo.Text += Environment.NewLine + "Description: " + entry.imageDescription;
                else if (entry.imageDescription.Length >= 50)
                    lblImageInfo.Text += Environment.NewLine + "Description: " + entry.imageDescription.Substring(0, 47) + "...";
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
                {
                    node.Parent.Checked = true;
                }
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

        private void WndImportImages_Load(object sender, EventArgs e)
        {
            categories = CategoryManager.GetAllCategories();
        }

        private bool CategoryExists(string categoryName)
        {
            foreach (ImageCategory category in categories)
            {
                if (String.Compare(categoryName, category.categoryName, true) == 0)
                    return true;
            }
            return false;
        }

        private ExtendedTreeNode FindImageCategoryNode(ExtendedTreeNode parentNode, string categoryName)
        {
            if (parentNode.NodeType != ExtendedTreeNodeType.NodeTypeSuperCategory)
                return null;

            foreach (ExtendedTreeNode node in parentNode.Nodes)
            {
                if (node.NodeType != ExtendedTreeNodeType.NodeTypeCategory)
                    continue;
                if (String.Compare(categoryName, node.Text, true) == 0)
                    return node;
            }
            return null;
        }

        private void bgImportListReader_DoWork(object sender, DoWorkEventArgs e)
        {
            XmlDocument importDoc = new XmlDocument();
            XmlNodeList imageNodesXML;
            VFS virtualFS;
            VFSEntry vfsEntry;
            ExtendedTreeNode tempTreeNode, rootNode;

            //WndWaitBanner wndWaitBanner = new WndWaitBanner("Reading image list. Please wait...");
            e.Result = null;
            rootNode = new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeUnknown, null);
            rootNode.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Existing Categories"));
            rootNode.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Uncategorized Images"));
            rootNode.Nodes.Add(new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeSuperCategory, "Non-Existent Categories"));
            imageNodes.Clear();

            #region Validation Checks
            if (!File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, Resources.fileExportedImagesXML)))
            {
                MessageBox.Show(Resources.msgImportDirectoryEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                importDoc.Load(Path.Combine(folderBrowserDialog.SelectedPath, Resources.fileExportedImagesXML));
            }
            catch
            {
                MessageBox.Show(Resources.msgImportXMLInvalid, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.Compare(importDoc.DocumentElement.LocalName, "Images") != 0)
            {
                MessageBox.Show(Resources.msgImportXMLInvalid, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            imageNodesXML = importDoc.DocumentElement.GetElementsByTagName("Image");
            if (imageNodesXML.Count == 0)
            {
                MessageBox.Show(Resources.msgImportDirectoryEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Loop through all the XmlElements in the document and construct a tree of treenodes to be added to treeImageBrowser
            foreach (XmlElement element in imageNodesXML)
            {
                XmlNodeList nodeList = element.ChildNodes;
                ListEntry entry = new ListEntry();
                entry.Initialize();

                #region Verify that this XmlElement has enough information needed to import an image.
                if (!element.HasChildNodes)
                    continue;
                if (element.GetElementsByTagName("Name").Count == 0 || element.GetElementsByTagName("VFSFile").Count == 0)
                    continue;
                #endregion

                #region Code to construct ListEntry instance from XmlNode
                foreach (XmlElement imagePropElement in nodeList)
                {
                    if (String.Compare(imagePropElement.LocalName, "Name", true) == 0)
                        entry.imageName = imagePropElement.InnerText;
                    else if (String.Compare(imagePropElement.LocalName, "Description", true) == 0)
                        entry.imageDescription = imagePropElement.InnerText;
                    else if (String.Compare(imagePropElement.LocalName, "Category", true) == 0)
                        entry.imageCategory = imagePropElement.InnerText;
                    else if (String.Compare(imagePropElement.LocalName, "SourcePath", true) == 0)
                        entry.imageSourcePath = imagePropElement.InnerText;
                    else if (String.Compare(imagePropElement.LocalName, "SourceVolLabel", true) == 0)
                        entry.imageSourceVolLabel = imagePropElement.InnerText;
                    else if (String.Compare(imagePropElement.LocalName, "SourceFileSystem", true) == 0)
                        entry.imageSourceFileSystem = imagePropElement.InnerText;
                    else if (String.Compare(imagePropElement.LocalName, "SourceDriveType", true) == 0)
                    {
                        try
                        {
                            entry.imageSourceDriveType = Convert.ToByte(imagePropElement.InnerText);
                        }
                        catch
                        {
                            entry.imageSourceDriveType = (byte)DriveType.Unknown;
                        }
                    }
                    else if (String.Compare(imagePropElement.LocalName, "VFSFile", true) == 0)
                        entry.imageDbPath = imagePropElement.InnerText;
                    else if (String.Compare(imagePropElement.LocalName, "PictureFile", true) == 0)
                        entry.imagePicture = imagePropElement.InnerText;
                }
                #endregion

                #region Code to validate the database file.
                if (entry.imageName.Length == 0 || entry.imageName.Contains("\"") || entry.imageName.Contains("\\") || !File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, entry.imageDbPath)))
                    continue;
                virtualFS = new VFS();
                vfsEntry = new VFSEntry();
                try
                {
                    virtualFS.OpenConnection(Path.Combine(folderBrowserDialog.SelectedPath, entry.imageDbPath));
                    vfsEntry = virtualFS.ReadEntry(0);
                    if (String.Compare(entry.imageName, vfsEntry.name, true) != 0)
                        continue;
                }
                catch
                {
                    continue;
                }
                finally
                {
                    if (virtualFS.GetDbState() != ConnectionState.Closed)
                        virtualFS.CloseConnection(false);
                }
                #endregion

                tempTreeNode = new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeImage, entry.imageName, entry);
                imageNodes.Add(tempTreeNode);

                if (entry.imageCategory.Length == 0)
                    rootNode.Nodes[1].Nodes.Add(tempTreeNode);
                else
                {
                    ExtendedTreeNode temp;

                    if (CategoryExists(entry.imageCategory))
                    {
                        temp = FindImageCategoryNode((ExtendedTreeNode)rootNode.Nodes[0], entry.imageCategory);
                        if (temp == null)
                        {
                            temp = new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeCategory, entry.imageCategory);
                            rootNode.Nodes[0].Nodes.Add(temp);
                        }
                        temp.Nodes.Add(tempTreeNode);
                    }
                    else
                    {
                        temp = FindImageCategoryNode((ExtendedTreeNode)rootNode.Nodes[2], entry.imageCategory);
                        if (temp == null)
                        {
                            temp = new ExtendedTreeNode(ExtendedTreeNodeType.NodeTypeCategory, entry.imageCategory);
                            rootNode.Nodes[2].Nodes.Add(temp);
                        }
                        temp.Nodes.Add(tempTreeNode);
                    }
                }
            }
            #endregion

            e.Result = rootNode.Nodes;
        }

        private void bgImportListReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            wndWaitBanner.Close();
            if (e.Error != null)
            {
                MessageBox.Show(Resources.msgImportListRetrieveFailed, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.Result != null)
            {
                if (imageNodes.Count == 0)
                {
                    MessageBox.Show(Resources.msgImportDirectoryEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (ExtendedTreeNode node in ((TreeNodeCollection)e.Result))
                {
                    if (node.Nodes.Count > 0)
                        treeImageBrowser.Nodes.Add(node);
                }
                treeImageBrowser.ExpandAll();
                txtImportDirectory.Text = folderBrowserDialog.SelectedPath;
                lblImageInfo.Text = "Select an image to view its properties.";
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            List<ExtendedTreeNode> selectedNodes = new List<ExtendedTreeNode>();

            foreach (ExtendedTreeNode node in imageNodes)
            {
                if (node.Checked)
                    selectedNodes.Add(node);
            }

            if (selectedNodes.Count == 0)
            {
                MessageBox.Show(Resources.msgNoImageSelectedToImport, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            wndImportProgress = new WndImportExportProgress(selectedNodes.Count, true);
            bgImageImporter.RunWorkerAsync(selectedNodes);
            wndImportProgress.ShowDialog();
        }

        private void bgImageImporter_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ExtendedTreeNode> nodesToImport = (List<ExtendedTreeNode>)e.Argument;
            Random randGenerator = new Random();

            MessageBoxEx msgBox = MessageBoxExManager.GetMessageBox("CategoryAddition");            
            string vfsFileDestName, picFileDestName="";
            uint uniqueID = 0;

            foreach (ExtendedTreeNode node in nodesToImport)
            {
                ListEntry entry = (ListEntry)node.NodeData;
                bgImageImporter.ReportProgress(0, new BgImageImporterState(entry, BgImageImporterState.BgImageImportedEventType.BeginImageImport));

                uniqueID = (uint)randGenerator.Next(1000000);
                vfsFileDestName = "db" + uniqueID.ToString() + ".mdb";
                while (File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, vfsFileDestName)))
                    vfsFileDestName = "db" + (uniqueID = (uint)randGenerator.Next(1000000)) + ".mdb";

                if (entry.imagePicture.Length > 0)
                {
                    picFileDestName = "pic" + randGenerator.Next(1000000).ToString() + Path.GetExtension(entry.imagePicture);
                    while (File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, picFileDestName)))
                        picFileDestName = "pic" + randGenerator.Next(1000000).ToString() + Path.GetExtension(entry.imagePicture);
                }

                if (entry.imageCategory.Length > 0 && !CategoryExists(entry.imageCategory))
                {
                    msgBox.Text = "The category '" + entry.imageCategory + "' does not exist. Create new category?";
                    if (msgBox.Show() == "Yes")
                        CategoryManager.AddCategory(entry.imageCategory, "");
                }
                if (ImageListManipulator.GetEntryCountWithID(uniqueID) > 0)
                    ImageListManipulator.DeleteEntry(uniqueID);

                try
                {
                    File.Copy(Path.Combine(txtImportDirectory.Text, entry.imageDbPath),
                              Path.Combine(AppSettingsManager.ImagesDirectory, vfsFileDestName), true);
                    if (entry.imagePicture.Length > 0)
                        File.Copy(Path.Combine(txtImportDirectory.Text, entry.imagePicture),
                                  Path.Combine(AppSettingsManager.ImagesDirectory, picFileDestName), true);
                }
                catch
                {
                    MessageBox.Show("Failed to import image " + entry.imageName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bgImageImporter.ReportProgress(0, new BgImageImporterState(entry, BgImageImporterState.BgImageImportedEventType.ImageImportFailed));
                    continue;
                }

                entry.imageID = uniqueID;
                entry.imageDbPath = vfsFileDestName;
                if (entry.imagePicture.Length > 0)
                    entry.imagePicture = picFileDestName;

                ImageListManipulator.AddEntry(entry);
                bgImageImporter.ReportProgress(0, new BgImageImporterState(entry, BgImageImporterState.BgImageImportedEventType.EndImageImport));
            }
            MessageBoxExManager.ResetSavedResponse("CategoryAddition");
        }

        private void bgImageImporter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BgImageImporterState importerState = (BgImageImporterState)e.UserState;

            if (importerState.EventType == BgImageImporterState.BgImageImportedEventType.BeginImageImport)
                wndImportProgress.BeginImportExport(importerState.Entry);
            else if (importerState.EventType == BgImageImporterState.BgImageImportedEventType.EndImageImport ||
                     importerState.EventType == BgImageImporterState.BgImageImportedEventType.ImageImportFailed)
                wndImportProgress.ImportExportComplete();
        }

        private void bgImageImporter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            wndImportProgress.Close();
            MessageBox.Show(Resources.msgImportSuccessful, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
    }

    internal class BgImageImporterState : Object
    {
        private ListEntry entry;
        private BgImageImportedEventType eventType;

        public ListEntry Entry
        {
            get
            {
                return entry;
            }
        }

        public BgImageImportedEventType EventType
        {
            get
            {
                return eventType;
            }
        }

        public BgImageImporterState(ListEntry e, BgImageImportedEventType eventCode)
        {
            entry = e;
            eventType = eventCode;
        }

        public enum BgImageImportedEventType
        {
            
            BeginImageImport,
            EndImageImport,
            ImportComplete,
            ImageImportFailed
        };
    }
}