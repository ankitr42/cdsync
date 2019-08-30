using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using CD_Sync_Portable.Properties;
using Virtual_File_System_Library;
using System.Threading;

namespace CD_Sync_Portable
{
    internal partial class WndExportFileList : Form
    {
        private string imageName;
        private VFS virtualFS;
        private Queue<UInt32> dirsToExport;
        
        // Variables required by the code to export XML.
        private XmlDocument exportDoc;
        private XmlElement currentNode;
        private Queue<XmlElement> xmlElements;

        // Variables required by the code to export HTML.
        // private StreamWriter htmlStream;

        public WndExportFileList(string imageName, VFS virtualFS)
        {
            InitializeComponent();

            this.imageName = imageName;
            this.virtualFS = virtualFS;
            exportDoc = new XmlDocument();
            dirsToExport = new Queue<uint>();
            xmlElements = new Queue<XmlElement>();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                txtFileName.Text = saveFileDialog.FileName;
        }

        //private void rBtnHTML_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rBtnHTML.Checked)
        //    {
        //        if (txtFileName.Text.Length > 0)
        //            txtFileName.Text = Path.ChangeExtension(txtFileName.Text, ".html");
        //    }
        //}

        //private void rBtnXML_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rBtnXML.Checked)
        //    {
        //        if (txtFileName.Text.Length > 0)
        //            txtFileName.Text = Path.ChangeExtension(txtFileName.Text, ".xml");
        //    }
        //}

        //private void rBtnText_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rBtnText.Checked)
        //    {
        //        if (txtFileName.Text.Length > 0)
        //            txtFileName.Text = Path.ChangeExtension(txtFileName.Text, ".txt");
        //    }
        //}

        private void btnExport_Click(object sender, EventArgs e)
        {
            VFSEntryProcessorDelegate vfsEntryProcessorXml = new VFSEntryProcessorDelegate(VFSEntryProcessorXML);
            //VFSEntryProcessorDelegate vfsEntryProcessorHtml = new VFSEntryProcessorDelegate(VFSEntryProcessorHTML);
            WndWaitBanner wnd = new WndWaitBanner("Exporting filelist. Please wait...");
            wnd.Owner = this;

            dirsToExport.Enqueue(0);

            if (txtFileName.Text.Length == 0)
            {
                MessageBox.Show(Resources.msgNoFileNameSpecified, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            wnd.ShowDialogAsync();

            #region HTML export code
            //if (rBtnHTML.Checked)
            //{
            //    htmlStream = new StreamWriter(txtFileName.Text, false, Encoding.Default);
                
            //    htmlStream.WriteLine("<html>");
            //    htmlStream.WriteLine("<head>");
            //    htmlStream.WriteLine("<title>Filelist for image {0}</title>", imageName);
            //    htmlStream.WriteLine("</head>");
            //    htmlStream.WriteLine("<body>");
            //    htmlStream.WriteLine("<h2 align=\"center\">Filelist for image {0}</h1><br><br><br>", imageName);

            //    while (dirsToExport.Count > 0)
            //    {
            //        if (dirsToExport.Peek() == 0)
            //            htmlStream.WriteLine("<b>Root</b><br>");
            //        else
            //            htmlStream.WriteLine("<b>{0}</b><br>", virtualFS.GetPathFromList(virtualFS.TracePathToEntry(dirsToExport.Peek())));
                        
            //        htmlStream.WriteLine("<table width=\"100%\" cellspacing=\"1\" border=\"0\">");
            //        htmlStream.WriteLine("<tr>");
            //        htmlStream.WriteLine("<th>Name</th>");
                    
            //        if (chkShowSize.Checked)
            //            htmlStream.WriteLine("<th>Size</th>");
            //        if (chkShowAttributes.Checked)
            //            htmlStream.WriteLine("<th>Attributes</th>");
            //        if (chkShowCreatedDate.Checked)
            //            htmlStream.WriteLine("<th>Created</th>");
            //        if (chkShowAccessedDate.Checked)
            //            htmlStream.WriteLine("<th>Accessed</th>");
            //        if (chkShowModifiedDate.Checked)
            //            htmlStream.WriteLine("<th>Modified</th>");
            //        if (chkShowArtist.Checked)
            //            htmlStream.WriteLine("<th>Artist</th>");
            //        if (chkShowAlbum.Checked)
            //            htmlStream.WriteLine("<th>Album</th>");
            //        if (chkShowAlbumYear.Checked)
            //            htmlStream.WriteLine("<th>Album Year</th>");
            //        if (chkShowTrackNumber.Checked)
            //            htmlStream.WriteLine("<th>Track Number</th>");
            //        if (chkShowDuration.Checked)
            //            htmlStream.WriteLine("<th>Duration</th>");
            //        if (chkShowGenre.Checked)
            //            htmlStream.WriteLine("<th>Genre</th>");
            //        if (chkShowBitrate.Checked)
            //            htmlStream.WriteLine("<th>Bitrate</th>");
            //        if (chkShowSampleRate.Checked)
            //            htmlStream.WriteLine("<th>Sample Rate</th>");
            //        if (chkShowDimensions.Checked)
            //            htmlStream.WriteLine("<th>Dimensions</th>");
            //        if (chkShowAuthor.Checked)
            //            htmlStream.WriteLine("<th>Author</th>");
            //        if (chkShowTitle.Checked)
            //            htmlStream.WriteLine("<th>Title</th>");
            //        if (chkShowSubject.Checked)
            //            htmlStream.WriteLine("<th>Subject</th>");
            //        if (chkShowCategory.Checked)
            //            htmlStream.WriteLine("<th>Category</th>");
            //        if (chkShowPages.Checked)
            //            htmlStream.WriteLine("<th>Pages</th>");
            //        if (chkShowComments.Checked)
            //            htmlStream.WriteLine("<th>Comments</th>");
            //        if (chkShowCopyright.Checked)
            //            htmlStream.WriteLine("<th>Copyright</th>");
            //        if (chkShowCompany.Checked)
            //            htmlStream.WriteLine("<th>Company</th>");
            //        if (chkShowDescription.Checked)
            //            htmlStream.WriteLine("<th>Description</th>");
            //        if (chkShowVersion.Checked)
            //            htmlStream.WriteLine("<th>Version</th>");
            //        if (chkShowProductName.Checked)
            //            htmlStream.WriteLine("<th>Product</th>");
            //        if (chkShowProductVersion.Checked)
            //            htmlStream.WriteLine("<th>Product Version</th>");
                    
            //        htmlStream.WriteLine("</tr>");
            //        virtualFS.ReadSubEntries(dirsToExport.Dequeue(), vfsEntryProcessorHtml);
            //        htmlStream.WriteLine("</table><br><br>");
            //    }
            //    htmlStream.WriteLine("</body>");
            //    htmlStream.WriteLine("</html>");
            //    htmlStream.Close();
            //}
#endregion

            exportDoc.AppendChild(exportDoc.CreateXmlDeclaration("1.0", "", ""));
            exportDoc.AppendChild(exportDoc.CreateComment(String.Format("Generated by CD Sync Portable. Filelist for image {0}.", imageName)));
            exportDoc.AppendChild(exportDoc.CreateElement("Root"));
            exportDoc.DocumentElement.SetAttribute("ImageName", imageName);

            xmlElements.Enqueue(exportDoc.DocumentElement);
            while (dirsToExport.Count > 0)
            {
                currentNode = xmlElements.Dequeue();
                virtualFS.ReadSubEntries(dirsToExport.Dequeue(), vfsEntryProcessorXml);
            }

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            writerSettings.NewLineChars = Environment.NewLine;

            XmlWriter tempWriter = XmlWriter.Create(txtFileName.Text, writerSettings);
            exportDoc.WriteTo(tempWriter);
            tempWriter.Close();

            wnd.EndShowDialogAsync();
            MessageBox.Show(Resources.msgExportSuccessful, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void VFSEntryProcessorXML(VFSEntry entry)
        {
            XmlElement element;
            string temp = "";

            #region XmlElement creation code

            element = exportDoc.CreateElement("DirectoryEntry");
            element.SetAttribute("Name", entry.name);
            
            if (chkShowSize.Checked && !entry.isDir)
                element.SetAttribute("Size", entry.size.ToString());
            if (chkShowAttributes.Checked)
            {
                temp += (entry.isDir) ? "D" : "";
                temp += (entry.isArch) ? "A" : "";
                temp += (entry.isROnly) ? "R" : "";
                temp += (entry.isSystem) ? "S" : "";
                temp += (entry.isHidden) ? "H" : "";
                temp += (entry.isCompressed) ? "C" : "";
                temp += (entry.isEncrypted) ? "E" : "";
                element.SetAttribute("Attrubutes", temp);
            }
            if (chkShowCreatedDate.Checked)
                element.SetAttribute("CreatedDate", entry.created.ToString());
            if (chkShowAccessedDate.Checked)
                element.SetAttribute("AccessedDate", entry.accessed.ToString());
            if (chkShowModifiedDate.Checked)
                element.SetAttribute("Modified", entry.modified.ToString());
            if (chkShowArtist.Checked && !entry.isDir)
                element.SetAttribute("Artist", entry.album);
            if (chkShowAlbum.Checked && !entry.isDir)
                element.SetAttribute("Album", entry.album);
            if (chkShowAlbumYear.Checked && !entry.isDir)
                element.SetAttribute("AlbumYear", entry.albumYear.ToString());
            if (chkShowTrackNumber.Checked && !entry.isDir)
                element.SetAttribute("TrackNumber", entry.trackNo.ToString());
            if (chkShowDuration.Checked && !entry.isDir)
                element.SetAttribute("Duration", entry.trackDurtion.ToString());
            if (chkShowGenre.Checked && !entry.isDir)
                element.SetAttribute("Genre", entry.genre);
            if (chkShowBitrate.Checked && !entry.isDir)
                element.SetAttribute("Bitrate", entry.bitRate.ToString());
            if (chkShowSampleRate.Checked && !entry.isDir)
                element.SetAttribute("SampleRate", entry.sampleRate.ToString());
            if (chkShowDimensions.Checked && !entry.isDir)
                element.SetAttribute("Dimensions", entry.width.ToString() + "x" + entry.height.ToString());
            if (chkShowAuthor.Checked && !entry.isDir)
                element.SetAttribute("Author", entry.author);
            if (chkShowTitle.Checked && !entry.isDir)
                element.SetAttribute("Title", entry.title);
            if (chkShowSubject.Checked && !entry.isDir)
                element.SetAttribute("Subject", entry.subject);
            if (chkShowCategory.Checked && !entry.isDir)
                element.SetAttribute("Category", entry.category);
            if (chkShowPages.Checked && !entry.isDir)
                element.SetAttribute("Pages", entry.pages.ToString());
            if (chkShowComments.Checked && !entry.isDir)
                element.SetAttribute("Comments", entry.comments);
            if (chkShowCopyright.Checked && !entry.isDir)
                element.SetAttribute("Copyright", entry.company);
            if (chkShowCompany.Checked && !entry.isDir)
                element.SetAttribute("Company", entry.company);
            if (chkShowDescription.Checked)
                element.SetAttribute("Description", entry.description);
            if (chkShowVersion.Checked && !entry.isDir)
                element.SetAttribute("FileVersion", entry.majorV.ToString() + "." + 
                                                    entry.minorV.ToString() + "." +
                                                    entry.revision.ToString());
            if (chkShowProductName.Checked && !entry.isDir)
                element.SetAttribute("ProductName", entry.productName);
            if (chkShowProductVersion.Checked && !entry.isDir)
                element.SetAttribute("ProductVersion", entry.majorPV.ToString() + "." +
                                                       entry.minorPV.ToString() + "." +
                                                       entry.pRevision.ToString());
            #endregion

            if (entry.isDir)
            {
                dirsToExport.Enqueue(entry.entryNo);
                xmlElements.Enqueue(element);
                currentNode.AppendChild(element);
            }
            else
                currentNode.AppendChild(element);
        }

        #region HTML export code
        //private void VFSEntryProcessorHTML(VFSEntry entry)
        //{
        //    string temp = "";

        //    if (entry.isDir)
        //        dirsToExport.Enqueue(entry.entryNo);

        //    htmlStream.WriteLine("<tr>");

        //    htmlStream.WriteLine("<td>{0}</td>", entry.isDir ? entry.name + "\\" : entry.name);
        //    if (chkShowSize.Checked)
        //    { 
        //        if (!entry.isDir)
        //            htmlStream.WriteLine("<td>{0}</td>", GeneralMethods.GetFormattedSizeForColumn(entry.size));
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowAttributes.Checked)
        //    {
        //        temp += (entry.isDir) ? "D" : "";
        //        temp += (entry.isArch) ? "A" : "";
        //        temp += (entry.isROnly) ? "R" : "";
        //        temp += (entry.isSystem) ? "S" : "";
        //        temp += (entry.isHidden) ? "H" : "";
        //        temp += (entry.isCompressed) ? "C" : "";
        //        temp += (entry.isEncrypted) ? "E" : "";
                
        //        htmlStream.WriteLine("<td>{0}</td>", temp);
        //    }
        //    if (chkShowCreatedDate.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.created.ToString());
        //    if (chkShowAccessedDate.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.accessed.ToString());
        //    if (chkShowModifiedDate.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.modified.ToString());
        //    if (chkShowVersion.Checked)
        //    {
        //        if (entry.majorV + entry.minorV + entry.revision > 0)
        //            htmlStream.WriteLine("<td>{0}.{0}.{0}</td>", entry.majorV, entry.minorV, entry.revision);
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowProductName.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.productName);
        //    if (chkShowProductVersion.Checked)
        //    {
        //        if (entry.majorPV + entry.minorPV + entry.pRevision > 0)
        //            htmlStream.WriteLine("<td>{0}.{0}.{0}</td>", entry.majorPV, entry.minorPV, entry.pRevision);
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowArtist.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.artist);
        //    if (chkShowAlbum.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.album);
        //    if (chkShowAlbumYear.Checked)
        //    {
        //        if (!entry.isDir && entry.albumYear > 1000)
        //            htmlStream.WriteLine("<td>{0}</td>", entry.albumYear);
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowTrackNumber.Checked)
        //    {
        //        if (!entry.isDir && entry.trackNo > 0)
        //            htmlStream.WriteLine("<td>{0}</td>", entry.trackNo);
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowDuration.Checked)
        //    {
        //        if (!entry.isDir && entry.trackDurtion > 0)
        //            htmlStream.WriteLine("<td>{0}</td>", (new TimeSpan(0, 0, (int)entry.trackDurtion)).ToString());
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowGenre.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.genre);
        //    if (chkShowBitrate.Checked)
        //    {
        //        if (!entry.isDir && entry.bitRate > 0)
        //            htmlStream.WriteLine("<td>{0}</td>", GeneralMethods.GetFormattedBitrate(entry.bitRate));
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowSampleRate.Checked)
        //    {
        //        if (!entry.isDir && entry.sampleRate > 0)
        //            htmlStream.WriteLine("<td>{0}</td>", entry.sampleRate.ToString() + "Hz");
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowDimensions.Checked)
        //    {
        //        if (!entry.isDir && entry.width + entry.height > 0)
        //            htmlStream.WriteLine("<td>{0}</td>", entry.width.ToString() + "x" + entry.height.ToString());
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowAuthor.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.author);
        //    if (chkShowTitle.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.title);
        //    if (chkShowSubject.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.subject);
        //    if (chkShowCategory.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.category);
        //    if (chkShowPages.Checked)
        //    {
        //        if (!entry.isDir && entry.pages > 0)
        //            htmlStream.WriteLine("<td>{0}</td>", entry.pages);
        //        else
        //            htmlStream.WriteLine("<td>&nbsp;</td>");
        //    }
        //    if (chkShowComments.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.comments);
        //    if (chkShowCopyright.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.copyright);
        //    if (chkShowCompany.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.copyright);
        //    if (chkShowDescription.Checked)
        //        htmlStream.WriteLine("<td>{0}</td>", entry.description);

        //    htmlStream.WriteLine("</tr>");
        //}
        #endregion

        private void chkSelectAllFileProps_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAllFileProps.Checked)
            {
                chkShowSize.Checked = true;
                chkShowAttributes.Checked = true;
                chkShowCreatedDate.Checked = true;
                chkShowAccessedDate.Checked = true;
                chkShowModifiedDate.Checked = true;
                chkShowDescription.Checked = true;
                chkShowVersion.Checked = true;
                chkShowProductName.Checked = true;
                chkShowProductVersion.Checked = true;
            }
            else
            {
                chkShowSize.Checked = false;
                chkShowAttributes.Checked = false;
                chkShowCreatedDate.Checked = false;
                chkShowAccessedDate.Checked = false;
                chkShowModifiedDate.Checked = false;
                chkShowDescription.Checked = false;
                chkShowVersion.Checked = false;
                chkShowProductName.Checked = false;
                chkShowProductVersion.Checked = false;
            }
        }

        private void chkSelectAllAVProps_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAllAVProps.Checked)
            {
                chkShowArtist.Checked = true;
                chkShowAlbum.Checked = true;
                chkShowAlbumYear.Checked = true;
                chkShowTrackNumber.Checked = true;
                chkShowDuration.Checked = true;
                chkShowGenre.Checked = true;
                chkShowBitrate.Checked = true;
                chkShowSampleRate.Checked = true;
                chkShowDimensions.Checked = true;
            }
            else
            {
                chkShowArtist.Checked = false;
                chkShowAlbum.Checked = false;
                chkShowAlbumYear.Checked = false;
                chkShowTrackNumber.Checked = false;
                chkShowDuration.Checked = false;
                chkShowGenre.Checked = false;
                chkShowBitrate.Checked = false;
                chkShowSampleRate.Checked = false;
                chkShowDimensions.Checked = false;
            }
        }

        private void chkSelectAllDocProps_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAllDocProps.Checked)
            {
                chkShowAuthor.Checked = true;
                chkShowTitle.Checked = true;
                chkShowSubject.Checked = true;
                chkShowCategory.Checked = true;
                chkShowPages.Checked = true;
                chkShowComments.Checked = true;
                chkShowCopyright.Checked = true;
                chkShowCompany.Checked = true;
            }
            else
            {
                chkShowAuthor.Checked = false;
                chkShowTitle.Checked = false;
                chkShowSubject.Checked = false;
                chkShowCategory.Checked = false;
                chkShowPages.Checked = false;
                chkShowComments.Checked = false;
                chkShowCopyright.Checked = false;
                chkShowCompany.Checked = false;
            }
        }
    }
}