using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Drawing;
using Registry_Manager;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using File_System_Browser_Library;
using Virtual_File_System_Library;
using System.Threading;
using Win32API;
using System.Drawing.Imaging;
using Microsoft.Win32;
using CD_Sync_Portable.Properties;
using Utils.MessageBoxExLib;

namespace CD_Sync_Portable
{
    internal enum IconSize
    {
        IconSmall = 1, IconLarge, IconExtraLarge
    };

    internal enum StandardIcons
    {
        IconFile = 0, IconExecutable = 2, IconFolderClosed, IconFolderOpen, IconSourceOnline = 9,
        IconSourceOffline, IconSearch = 22, IconMultipleTypes = 54
    };

    internal struct DirInfo
    {
        public UInt32 id;
        public string path;

        public DirInfo(UInt32 iD, string pATH)
        {
            id = iD;
            path = pATH;
        }
    }
    
    internal struct ListEntry
    {
        public UInt32 imageID;
        public string imageName;
        public string imageDescription;
        public string imagePicture;
        public string imageDbPath;
        public string imageSourcePath;
        public string imageCategory;
        public string imageSourceVolLabel;
        public string imageSourceFileSystem;
        public Byte imageSourceDriveType;

        public bool Equals(ListEntry temp)
        {
            if (imageID == temp.imageID)
                if (((imageName == null || imageName == "") && (temp.imageName == null || temp.imageName == "")) || imageName == temp.imageName)
                    if (((imageDescription == null || imageDescription == "") && (temp.imageDescription == null || temp.imageDescription == "")) || imageDescription == temp.imageDescription)
                        if (((imagePicture == null || imagePicture == "") && (temp.imagePicture == null || temp.imagePicture == "")) || imagePicture == temp.imagePicture)
                            if (((imageDbPath == null || imageDbPath == "") && (temp.imageDbPath == null || temp.imageDbPath == "")) || imageDbPath == temp.imageDbPath)
                                if (((imageSourcePath == null || imageSourcePath == "") && (temp.imageSourcePath == null || temp.imageSourcePath == "")) || imageSourcePath == temp.imageSourcePath)
                                    if (((imageCategory == null || imageCategory == "") && (temp.imageCategory == null || temp.imageCategory == "")) || imageCategory == temp.imageCategory)
                                        if (((imageSourceVolLabel == null || imageSourceVolLabel == "") && (temp.imageSourceVolLabel == null || temp.imageSourceVolLabel == "")) || imageSourceVolLabel == temp.imageSourceVolLabel)
                                            if (((imageSourceFileSystem == null || imageSourceFileSystem == "") && (temp.imageSourceFileSystem == null || temp.imageSourceFileSystem == "")) || imageSourceFileSystem == temp.imageSourceFileSystem)
                                                if (imageSourceDriveType == temp.imageSourceDriveType)
                                                    return true;
            return false;
        }

        public ListEntry Clone()
        {
            ListEntry temp = new ListEntry();
            temp.imageID = imageID;
            if (imageName != null)
                temp.imageName = String.Copy(imageName);
            if (imageDescription != null)
                temp.imageDescription = String.Copy(imageDescription);
            if (imagePicture != null)
                temp.imagePicture = String.Copy(imagePicture);
            if (imageDbPath != null)
                temp.imageDbPath = String.Copy(imageDbPath);
            if (imageSourcePath != null)
                temp.imageSourcePath = String.Copy(imageSourcePath);
            if (imageCategory != null)
                temp.imageCategory = String.Copy(imageCategory);
            if (imageSourceVolLabel != null)
                temp.imageSourceVolLabel = String.Copy(imageSourceVolLabel);
            if (imageSourceFileSystem != null)
                temp.imageSourceFileSystem = String.Copy(imageSourceFileSystem);
            temp.imageSourceDriveType = imageSourceDriveType;

            return temp;
        }

        public void Initialize()
        {
            imageName = String.Empty;
            imageDescription = String.Empty;
            imagePicture = String.Empty;
            imageDbPath = String.Empty;
            imageSourcePath = String.Empty;
            imageCategory = String.Empty;
            imageSourceVolLabel = String.Empty;
            imageSourceFileSystem = String.Empty;
            imageSourceDriveType = 0;
        }
    }

    internal struct ImageCategory
    {
        public string categoryName;
        public string categoryDesc;

        public ImageCategory(string name, string desc)
        {
            categoryName = name;
            categoryDesc = desc;
        }
    }
    
    internal struct FilterSettings
    {
        public bool sizeFilter;
        public UInt64 minSize, maxSize;
        public bool attrFilter, exHidden, exSystem, exArchive, exROnly, exCompressed, exEncrypted;
        public bool dateFilter, cDate, mDate, aDate;
        public DateTime cDateBegin, cDateEnd, mDateBegin, mDateEnd, aDateBegin, aDateEnd;
        public bool fTypeFilter;
        public string fTypes;
        public List<string> excludedFiles, excludedDirectories;
    }

    internal struct ExtendedFileInfo
    {
        public Icon fileIcon;
        public String artist;
        public String album;
        public UInt16 albumYear;
        public UInt16 trackNo;
        public UInt32 trackDurtion;
        public String genre;
        public UInt32 bitRate;
        public UInt16 frameRate;
        public UInt32 sampleRate;
        public UInt16 height;
        public UInt16 width;
        public String owner;
        public String author;
        public String title;
        public String subject;
        public String category;
        public UInt16 pages;
        public String comments;
        public String copyright;
        public String company;
        public String description;
        public UInt16 majorV;
        public UInt16 minorV;
        public UInt16 revision;
        public String productName;
        public UInt16 majorPV;
        public UInt16 minorPV;
        public UInt16 pRevision;
    }

    internal struct FilterExtendedInfo
    {
        public bool copyExtendedInfo;
        public bool copyFileVersionInfo;
        public bool copyAVInfo;
        public bool copyDocumentInfo;        
        public bool copyFileIcon;
    }

    internal delegate void ListEntryProcessorDelegate(ListEntry entry);

    internal class FSItem
    {
        public string fsItemName;
        public ulong fsItemSize;
        public DateTime fsItemModifiedDate;
        public DateTime fsItemCreatedDate;
        public DateTime fsItemAccessedDate;
        public FileAttributes fsItemAttributes;
        public int fsItemParentId;
    }
    
    internal class FileTypeInfo
    {
        public string typeExt;
        public string typeName;
        public string opensWithName;
        public string opensWithPath;
        public Icon extraLargeIcon, largeIcon, smallIcon;

        public FileTypeInfo Clone()
        {
            FileTypeInfo temp = new FileTypeInfo();

            if (typeExt != null)
                temp.typeExt = String.Copy(typeExt);
            if (typeName != null)
                temp.typeName = String.Copy(typeName);
            if (opensWithName != null)
                temp.opensWithName = String.Copy(opensWithName);
            if (opensWithPath != null)
                temp.opensWithPath = String.Copy(opensWithPath);

            if (extraLargeIcon != null)
                temp.extraLargeIcon = (Icon)extraLargeIcon.Clone();
            if (largeIcon != null)
                temp.largeIcon = (Icon)largeIcon.Clone();
            if (smallIcon != null)
                temp.smallIcon = (Icon)smallIcon.Clone();

            return temp;
        }
    }

    internal class ImageEmptyException : ApplicationException
    {
        ImageEmptyException(string message)
            : base(message)
        {
        }
    }
    
    internal class SourceEmptyException : ApplicationException
    {
        SourceEmptyException(string message)
            : base(message)
        {
        }
    }

    internal class FSToVFSHandler
    {
        private string sourcePath, pictureSourcePath, imageCategory, imageName, imageDescription, imageDbPath, pictureDestPath;
        private ListEntry imageListEntry;
        private VFS virtualFS;
        private FSBrowser fsBrowser;
        private WndNewImageProgress progressWindow;
        private WndWaitBanner waitWindow;
        private Random randomGenerator;
        private UInt32 totalDirs, totalFiles, tick, skippedDirs, skippedFiles, uniqueID;
        private List<DirInfo> dirInfo;
        private FilterExtendedInfo filterExInfo;
        private MessageBoxEx msgBox;
        private bool retVal, rootLevel;
        private int scanDepth;
        
        // Variables used by the GetTotalFiles() and GetTotalSubDirectories() methods.
        private uint files;
        private uint directories;

        public FSToVFSHandler(string rootPath, string picPath, string category, string name, string desc, FilterExtendedInfo filterExInfo,
                                      FilterSettings filterSettings, int scanDepth)
        {
            sourcePath = rootPath;
            pictureSourcePath = picPath;
            imageCategory = category;
            imageName = name;
            imageDescription = desc;

            virtualFS = new VFS();
            fsBrowser = new FSBrowser();
            randomGenerator = new Random();
            dirInfo = new List<DirInfo>();
            this.filterExInfo = filterExInfo;
            this.scanDepth = scanDepth;
            fsBrowser.ProcessCompleted += new ProcessCompleteEventHandler(fsBrowser_ProcessCompleted);
            msgBox = MessageBoxExManager.GetMessageBox("FSBrowserException");

            FSItemFilterationHandler.Initialize(filterSettings);
        }

        public void Initialize(string rootPath, string picPath, string category, string name, string desc, FilterExtendedInfo filterExInfo,
                                      FilterSettings filterSettings, int scanDepth)
        {
            sourcePath = rootPath;
            pictureSourcePath = picPath;
            imageCategory = category;
            imageName = name;
            imageDescription = desc;
            this.filterExInfo = filterExInfo;
            this.scanDepth = scanDepth;

            FSItemFilterationHandler.Initialize(filterSettings);
        }

        public bool Start()
        {
            totalDirs = 0;
            totalFiles = 0;
            tick = 0;
            skippedDirs = 0;
            skippedFiles = 0;
            uniqueID = 0;
            rootLevel = true;
            progressWindow = new WndNewImageProgress();
            waitWindow = new WndWaitBanner(String.Empty);
            DriveInfo drvInfo = new DriveInfo(sourcePath);

            waitWindow.SetMessage("Calculating total files and directories. Please wait...");
            waitWindow.Show();

            directories = 0;
            files = 0;
            GetTotalSubdirectories(sourcePath);
            GetTotalFiles(sourcePath);
            totalDirs = directories;
            totalFiles = files;

            waitWindow.Close();

            if ((totalDirs + totalFiles) == 0)
            {
                MessageBox.Show(Properties.Resources.msgSourceEmpty, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            while (true)
            {
                uniqueID = (UInt32)randomGenerator.Next(1000000);
                imageDbPath = "db" + uniqueID.ToString() + ".mdb";
                if (!File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, imageDbPath)))
                {
                    File.Copy(Path.Combine(AppSettingsManager.AppInstallationDirectory, AppSettingsManager.VFSSampleDatabase),
                        Path.Combine(AppSettingsManager.ImagesDirectory, imageDbPath), true);
                    if (pictureSourcePath != "")
                    {
                        pictureDestPath = "pic" + randomGenerator.Next(1000000).ToString() + Path.GetExtension(pictureSourcePath);
                        while (File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, pictureDestPath)))
                            pictureDestPath = "pic" + randomGenerator.Next(1000000).ToString() + Path.GetExtension(pictureSourcePath);
                        
                        File.Copy(pictureSourcePath, Path.Combine(AppSettingsManager.ImagesDirectory, pictureDestPath), true);
                    }
                    if (ImageListManipulator.GetEntryCountWithID(uniqueID) > 0)
                        ImageListManipulator.DeleteEntry(uniqueID);
                    break;
                }
            }

            fsBrowser.Initialize(sourcePath, scanDepth, FSItemProcessor, fsBrowser_ExceptionHandler);
            virtualFS.OpenConnection(Path.Combine(AppSettingsManager.ImagesDirectory, imageDbPath));

            VFSEntry temp = new VFSEntry();
            temp.parentDir = -1;
            temp.entryNo = 0;
            temp.name = imageName;
            temp.isDir = true;
            virtualFS.AddEntry(temp);

            if (fsBrowser.GetInternalThreadState() != System.Threading.ThreadState.Unstarted)
                fsBrowser.Reset();

            fsBrowser.Start();

            progressWindow.ShowDialog(totalDirs, totalFiles);

            if (progressWindow.DialogResult == DialogResult.OK)
            {
                if (virtualFS.GetTotalEntries() < 2)
                {
                    MessageBox.Show(Properties.Resources.msgImageEmpty, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show(Properties.Resources.promptKeepImage, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        virtualFS.CloseConnection(true);
                        File.Delete(Path.Combine(AppSettingsManager.ImagesDirectory, imageDbPath));
                        if (pictureDestPath != null && File.Exists(Path.Combine(AppSettingsManager.ImagesDirectory, pictureDestPath)))
                            File.Delete(Path.Combine(AppSettingsManager.ImagesDirectory, pictureDestPath));

                        return true;
                    }
                }

                virtualFS.CloseConnection(true);
                imageListEntry = new ListEntry();
                imageListEntry.imageID = uniqueID;
                imageListEntry.imageSourcePath = sourcePath;
                if (pictureSourcePath != String.Empty)
                    imageListEntry.imagePicture = pictureDestPath;
                else
                    imageListEntry.imagePicture = "";
                imageListEntry.imageCategory = imageCategory;
                imageListEntry.imageDbPath = imageDbPath;
                imageListEntry.imageDescription = imageDescription;
                imageListEntry.imageName = imageName;
                if (drvInfo.IsReady)
                {
                    imageListEntry.imageSourceVolLabel = drvInfo.VolumeLabel;
                    imageListEntry.imageSourceFileSystem = drvInfo.DriveFormat;
                    imageListEntry.imageSourceDriveType = (Byte)drvInfo.DriveType;
                }

                ImageListManipulator.AddEntry(imageListEntry);
                MessageBox.Show(Properties.Resources.msgImageCreated + " Time taken: " +
                    (progressWindow.elapsedSecs / 60).ToString() + " minutes, " +
                    (progressWindow.elapsedSecs % 60).ToString() + " seconds."
                    , "Process complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                progressWindow.Dispose();
                return true;
            }
            else if (progressWindow.DialogResult == DialogResult.Cancel)
            {
                Halt();

                progressWindow.Dispose();
                return false;
            }
            return true;
        }

        public void Halt()
        {
            fsBrowser.Halt(true);
            virtualFS.CloseConnection(true);
            try
            {
                File.Delete(Path.Combine(AppSettingsManager.ImagesDirectory, imageDbPath));
                if (pictureDestPath.Length > 0)
                    File.Delete(Path.Combine(AppSettingsManager.ImagesDirectory, pictureDestPath));
            }
            catch { }

            dirInfo.Clear();
            return;
        }

        private bool FSItemProcessor(string fsItemName)
        {
            retVal = false;
            FSItem fsItem;

            if (fsItemName != "\\")
            {
                tick++;

                fsItem = GetFileInfo(fsItemName);

                if (FSItemFilterationHandler.Filter(fsItem))
                {
                    retVal = true;
                    if ((fsItem.fsItemAttributes & FileAttributes.Directory) != 0)
                    {
                        progressWindow.Update(fsItem.fsItemName, 0, 0, 1, 0);
                        dirInfo.Add(new DirInfo(tick, fsItem.fsItemName));
                    }
                    else
                        progressWindow.Update(fsItem.fsItemName, 0, 0, 0, 1);

                    if (!rootLevel)
                    {
                        foreach (DirInfo dInfo in dirInfo)
                        {
                            if (Path.GetDirectoryName(fsItem.fsItemName) == dInfo.path)
                                fsItem.fsItemParentId = (Int32)dInfo.id;
                        }
                    }
                    else
                        fsItem.fsItemParentId = 0;

                    try
                    {
                        virtualFS.AddEntry(TranslateFSItemToVFSEntry(fsItem));
                    }
                    catch
                    {
                        msgBox.Text = "There was an error processing '" + fsItemName +
                                        "'. The item was not added to the database.";
                        msgBox.Show();
                        // MessageBox.Show("There was an error processing '" + fsItemName +
                        //    "'. The item was not added to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if ((fsItem.fsItemAttributes & FileAttributes.Directory) != 0)
                    {
                        directories = 0;
                        files = 0;
                        GetTotalSubdirectories(fsItem.fsItemName);
                        GetTotalFiles(fsItem.fsItemName);
                        skippedDirs = directories;
                        skippedFiles = files;

                        progressWindow.Update(fsItem.fsItemName, 1 + skippedDirs, skippedFiles, 0, 0);
                    }
                    else
                        progressWindow.Update(fsItem.fsItemName, 0, 1, 0, 0);
                }
            }
            else
                rootLevel = false;

            return retVal;
        }

        private VFSEntry TranslateFSItemToVFSEntry(FSItem fsItem)
        {
            VFSEntry vfsEntry = new VFSEntry();

            vfsEntry.entryNo = tick;
            vfsEntry.parentDir = fsItem.fsItemParentId;
            vfsEntry.name = fsItem.fsItemName.Substring(fsItem.fsItemName.LastIndexOf("\\") + 1);

            vfsEntry.isDir = ((fsItem.fsItemAttributes & FileAttributes.Directory) != 0) ? true : false;

            vfsEntry.accessed = fsItem.fsItemAccessedDate;
            vfsEntry.created = fsItem.fsItemCreatedDate;
            vfsEntry.modified = fsItem.fsItemModifiedDate;

            vfsEntry.isArch = ((fsItem.fsItemAttributes & FileAttributes.Archive) != 0) ? true : false;
            vfsEntry.isROnly = ((fsItem.fsItemAttributes & FileAttributes.ReadOnly) != 0) ? true : false;
            vfsEntry.isHidden = ((fsItem.fsItemAttributes & FileAttributes.Hidden) != 0) ? true : false;
            vfsEntry.isSystem = ((fsItem.fsItemAttributes & FileAttributes.System) != 0) ? true : false;
            vfsEntry.isCompressed = ((fsItem.fsItemAttributes & FileAttributes.Compressed) != 0) ? true : false;
            vfsEntry.isEncrypted = ((fsItem.fsItemAttributes & FileAttributes.Encrypted) != 0) ? true : false;
            vfsEntry.size = fsItem.fsItemSize;

            if (filterExInfo.copyExtendedInfo && ((fsItem.fsItemAttributes & FileAttributes.Directory) == 0))
            {
                if (filterExInfo.copyFileVersionInfo)
                {
                    try
                    {
                        FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(fsItem.fsItemName);

                        vfsEntry.comments = fileVersionInfo.Comments;
                        vfsEntry.company = fileVersionInfo.CompanyName;
                        vfsEntry.copyright = fileVersionInfo.LegalCopyright;
                        vfsEntry.description = fileVersionInfo.FileDescription;
                        vfsEntry.productName = fileVersionInfo.ProductName;
                        vfsEntry.majorPV = (ushort)fileVersionInfo.ProductMajorPart;
                        vfsEntry.minorPV = (ushort)fileVersionInfo.ProductMinorPart;
                        vfsEntry.pRevision = (ushort)fileVersionInfo.ProductBuildPart;
                        vfsEntry.majorV = (ushort)fileVersionInfo.FileMajorPart;
                        vfsEntry.minorV = (ushort)fileVersionInfo.FileMinorPart;
                        vfsEntry.revision = (ushort)fileVersionInfo.FileBuildPart;
                    }
                    catch
                    {
                    }
                }
                if (filterExInfo.copyAVInfo)
                {
                    if (GeneralMethods.IsFileTypeAudio(fsItem.fsItemName) || GeneralMethods.IsFileTypeVideo(fsItem.fsItemName))
                    {
                        try
                        {
                            TagLib.File avFile = TagLib.File.Create(fsItem.fsItemName, TagLib.ReadStyle.Average);

                            vfsEntry.title = avFile.Tag.Title;
                            if (avFile.Tag.AlbumArtists.Length > 0)
                                vfsEntry.artist = avFile.Tag.AlbumArtists[0];
                            vfsEntry.trackNo = (ushort)avFile.Tag.Track;
                            vfsEntry.album = avFile.Tag.Album;
                            vfsEntry.albumYear = (ushort)avFile.Tag.Year;
                            if (avFile.Tag.Genres.Length > 0)
                                vfsEntry.genre = avFile.Tag.Genres[0];
                            vfsEntry.bitRate = (uint)avFile.Properties.AudioBitrate;
                            //vfsEntry.frameRate = avFile.
                            vfsEntry.height = (ushort)avFile.Properties.VideoHeight;
                            vfsEntry.sampleRate = (uint)avFile.Properties.AudioSampleRate;
                            vfsEntry.trackDurtion = (uint)avFile.Properties.Duration.TotalSeconds;
                            vfsEntry.width = (ushort)avFile.Properties.VideoWidth;
                        }
                        catch
                        {
                        }
                    }
                    else if (GeneralMethods.IsFileTypeImage(fsItem.fsItemName))
                    {
                        Size imageSize;
                        try
                        {
                            imageSize = ImageHeaderReader.GetDimensions(fsItem.fsItemName);
                            vfsEntry.width = (ushort)imageSize.Width;
                            vfsEntry.height = (ushort)imageSize.Height;
                        }
                        catch
                        {
                        }
                    }
                }
                if (filterExInfo.copyDocumentInfo && GeneralMethods.IsFileTypeDocument(fsItem.fsItemName))
                {
                    DSOFile.OleDocumentProperties docProp = new DSOFile.OleDocumentPropertiesClass();
                    try
                    {
                        docProp.Open(fsItem.fsItemName, true, DSOFile.dsoFileOpenOptions.dsoOptionDefault);
                        vfsEntry.author = docProp.SummaryProperties.Author;
                        vfsEntry.category = docProp.SummaryProperties.Category;

                        vfsEntry.comments = docProp.SummaryProperties.Comments;
                        vfsEntry.company = docProp.SummaryProperties.Company;

                        vfsEntry.pages = (ushort)docProp.SummaryProperties.PageCount;
                        vfsEntry.subject = docProp.SummaryProperties.Subject;
                        vfsEntry.title = docProp.SummaryProperties.Title;

                        docProp.Close(false);
                    }
                    catch
                    {
                    }
                }
                if (filterExInfo.copyFileIcon)
                {
                    string temp = Path.GetExtension(vfsEntry.name);

                    if ((String.Compare(temp, ".exe", true) == 0) || (String.Compare(temp, ".scr", true) == 0) ||
                        (String.Compare(temp, ".ico", true) == 0) || (String.Compare(temp, ".cur", true) == 0))
                        vfsEntry.fileIcon = IconFunctions.IconToBytes(IconFunctions.ExtractSingleIcon(fsItem.fsItemName, 0));
                }
            }
            return vfsEntry;
        }

        private FSItem GetFileInfo(string fsItemName)
        {
            FSItem fsItem = new FSItem();

            if (fsItemName.Length < 1)
                return null;

            try
            {
                FileInfo fInfo = new FileInfo(fsItemName);

                fsItem.fsItemName = fsItemName;
                fsItem.fsItemAccessedDate = fInfo.LastAccessTime;
                fsItem.fsItemCreatedDate = fInfo.CreationTime;
                fsItem.fsItemModifiedDate = fInfo.LastWriteTime;

                fsItem.fsItemAttributes = fInfo.Attributes;
                if ((fsItem.fsItemAttributes & FileAttributes.Directory) == 0)
                    fsItem.fsItemSize = (ulong)fInfo.Length;
            }
            catch
            {
                if (Directory.Exists(fsItemName))
                {
                    fsItem.fsItemAttributes |= FileAttributes.Directory;
                    fsItem.fsItemSize = 0;
                }
            }

            return fsItem;
        }

        void fsBrowser_ProcessCompleted(object sender, EventArgs e)
        {
            dirInfo.Clear();
            //stopRequest = true;
            //MessageBox.Show(vfsEntryPool.Count.ToString());
            //while (vfsEntryDispatcherThread.ThreadState == System.Threading.ThreadState.Running) ;
            progressWindow.ProcessCompleted();
            progressWindow.Close();
            progressWindow.Dispose();
            MessageBoxExManager.ResetSavedResponse("FSBrowserException");
        }

        bool fsBrowser_ExceptionHandler(Exception ex)
        {
            msgBox.Text = "An error occured while processing directory '" + ex.Data["Path"] + "'" +
                          Environment.NewLine + Environment.NewLine + ex.Message;
            msgBox.Show();
            return true;
        }

        private void GetTotalFiles(string path)
        {
            string[] subDirs;
            try
            {
                subDirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                files += (uint)Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;
            }
            catch
            {
                return;
            }
            
            foreach (string dir in subDirs)
                GetTotalFiles(dir);
        }

        private void GetTotalSubdirectories(string path)
        {
            string[] subDirs;
            try
            {
                subDirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                directories += (uint)subDirs.Length;
            }
            catch
            {
                return;
            }

            foreach (string dir in subDirs)
                GetTotalSubdirectories(dir);
        }
    }

    internal class ImageExporter
    {
        //public delegate bool VFSDTreeExportCallbackDelegate();
        //public delegate bool VFSFileListExportCallbackDelegate();

        //public VFSDTreeExportCallbackDelegate 
        
        //public ImageExporter(VFSDTreeExportCallbackDelegate dTECallback, VFSFileListExportCallbackDelegate fLECallback)
        //{

        //}

        //public void ExportDirectoryTree(VFS virtualFS, uint rootEntry, 
    }
    
    internal class FileTypeManager
    {
        private RegistryBrowser rBrowser;
        private object synchronizationLock;
        private List<FileTypeInfo> fTypes;

        public FileTypeManager()
        {
            Icon[] tempIconArr;
            FileTypeInfo tempFileTypeInfo;

            synchronizationLock = new object();
            tempFileTypeInfo = new FileTypeInfo();
            fTypes = new List<FileTypeInfo>();
            rBrowser = new RegistryBrowser(Registry.ClassesRoot, false);

            tempFileTypeInfo.typeName = "File Folder";
            tempFileTypeInfo.typeExt = "*dir";
            tempIconArr = IconFunctions.ExtractStandardIconArray(StandardIcons.IconFolderClosed);
            tempFileTypeInfo.largeIcon = tempIconArr[0];
            tempFileTypeInfo.smallIcon = tempIconArr[1];
            fTypes.Add(tempFileTypeInfo);

            tempFileTypeInfo = new FileTypeInfo();

            tempFileTypeInfo.typeName = "Unknown";
            tempFileTypeInfo.typeExt = "*file";
            tempIconArr = IconFunctions.ExtractStandardIconArray(StandardIcons.IconFile);
            tempFileTypeInfo.largeIcon = tempIconArr[0];
            tempFileTypeInfo.smallIcon = tempIconArr[1];
            fTypes.Add(tempFileTypeInfo);

            tempFileTypeInfo = new FileTypeInfo();

            if (!GotoTypeProgID(".exe"))
                tempFileTypeInfo.typeName = "Application";
            else
                tempFileTypeInfo.typeName = (string)rBrowser.GetValue(String.Empty);
            tempFileTypeInfo.typeExt = ".exe";
            tempFileTypeInfo.opensWithName = "Self Executable";
            tempIconArr = IconFunctions.ExtractStandardIconArray(StandardIcons.IconExecutable);
            tempFileTypeInfo.largeIcon = tempIconArr[0];
            tempFileTypeInfo.smallIcon = tempIconArr[1];
            fTypes.Add(tempFileTypeInfo);

            tempFileTypeInfo = new FileTypeInfo();
            if (!GotoTypeProgID(".scr"))
                tempFileTypeInfo.typeName = "Screen Saver";
            else
                tempFileTypeInfo.typeName = (string)rBrowser.GetValue(String.Empty);
            tempFileTypeInfo.typeExt = ".scr";
            tempFileTypeInfo.opensWithName = "Self Executable";
            tempIconArr = IconFunctions.ExtractStandardIconArray(StandardIcons.IconExecutable);
            tempFileTypeInfo.largeIcon = tempIconArr[0];
            tempFileTypeInfo.smallIcon = tempIconArr[1];
            fTypes.Add(tempFileTypeInfo);
        }
        
        /// <summary>
        /// Returns the icon for a specified file type.
        /// </summary>
        /// <param name="type">The file type to get the icon for. For example .txt</param>
        /// <returns>An icon representing the file type if successfull, or null if unsuccessful.</returns>
        public Icon GetIconForType(string typeExt, IconSize iconSize)
        {
            FileTypeInfo tempFileTypeInfo;

            tempFileTypeInfo = GetFileTypeInfo(typeExt);
            if (tempFileTypeInfo == null)
                return null;
            else
            {
                if (iconSize == IconSize.IconExtraLarge)
                    return tempFileTypeInfo.extraLargeIcon;
                if (iconSize == IconSize.IconLarge)
                    return tempFileTypeInfo.largeIcon;
                if (iconSize == IconSize.IconSmall)
                    return tempFileTypeInfo.smallIcon;
                return null;
            }
        }

        public FileTypeInfo GetFileTypeInfo(string typeExt)
        {
            string temp;
            int tempInt = 0;
            FileTypeInfo tempFileTypeInfo;
            Icon[] tempIconArr;

            lock (synchronizationLock)
            {
                if (typeExt == null || typeExt == String.Empty)
                    typeExt = "*file";

                if (!typeExt.StartsWith("*"))
                    if (!typeExt.StartsWith("."))
                        typeExt = "." + typeExt;

                temp = typeExt.ToLower();
                foreach (FileTypeInfo tempType in fTypes)
                    if (tempType.typeExt == temp)
                        return tempType.Clone();

                try
                {
                    tempFileTypeInfo = new FileTypeInfo();
                    if (!GotoTypeProgID(typeExt))
                        return null;

                    tempFileTypeInfo.typeExt = temp;
                    tempFileTypeInfo.typeName = (string)rBrowser.GetValue(String.Empty);

                    if (rBrowser.BrowseTo("Shell"))
                    {
                        temp = (string)rBrowser.GetValue(String.Empty);
                        if (temp != null && temp != String.Empty)
                        {
                            if (rBrowser.BrowseTo(temp.Split(",".ToCharArray())[0] + "\\command"))
                                tempFileTypeInfo.opensWithPath = (string)rBrowser.GetValue(String.Empty);
                        }
                        else
                            if (rBrowser.BrowseTo("open\\command"))
                                tempFileTypeInfo.opensWithPath = (string)rBrowser.GetValue(String.Empty);

                        if (tempFileTypeInfo.opensWithPath.StartsWith("\"%1\""))
                            tempFileTypeInfo.opensWithName = "Self Executable";
                        else
                        {
                            tempFileTypeInfo.opensWithName = GetProgramDescriptionString(ref tempFileTypeInfo.opensWithPath);
                        }

                        GotoTypeProgID(typeExt);
                    }

                    temp = String.Empty;
                    if (rBrowser.BrowseTo("DefaultIcon"))
                    {
                        temp = (string)rBrowser.GetValue(String.Empty);

                        if (temp == "\"%1\"" || temp == "%1")
                        {
                            rBrowser.GotoParent();
                            if (rBrowser.BrowseTo("CLSID"))
                            {
                                temp = (string)rBrowser.GetValue(String.Empty);
                                rBrowser.GotoRoot();
                                if (rBrowser.BrowseTo("CLSID\\" + temp + "\\DefaultIcon"))
                                {
                                    temp = (string)rBrowser.GetValue(String.Empty);
                                    tempInt = PathParseIconLocation(ref temp);
                                    if (tempFileTypeInfo.typeName == null || tempFileTypeInfo.typeName == String.Empty)
                                    {
                                        rBrowser.GotoParent();
                                        tempFileTypeInfo.typeName = (string)rBrowser.GetValue(String.Empty);
                                    }
                                }
                                else
                                    temp = String.Empty;
                            }
                            else
                                temp = String.Empty;
                        }
                        else if (temp != null && temp != String.Empty)
                            tempInt = PathParseIconLocation(ref temp);
                        else
                            temp = String.Empty;

                        if (temp != null && temp != String.Empty)
                        {
                            tempIconArr = IconFunctions.ExtractIcon(temp, tempInt);
                            tempFileTypeInfo.largeIcon = tempIconArr[0];
                            tempFileTypeInfo.smallIcon = tempIconArr[1];
                        }
                    }

                    fTypes.Add(tempFileTypeInfo);
                }
                catch
                {
                    return null;
                }
                return tempFileTypeInfo;
            }
        }

        private bool GotoTypeProgID(string type)
        {
            string temp;

            if (type == null || type == String.Empty)
                throw new ArgumentException("The 'type' parameter cannot be null or an empty string.");

            rBrowser.GotoRoot();

            if (!rBrowser.CheckKeyExists(type))
                return false;

            rBrowser.BrowseTo(type);

            temp = (string)rBrowser.GetValue(String.Empty);

            rBrowser.GotoParent();

            if (!rBrowser.CheckKeyExists(temp))
                return false;

            rBrowser.BrowseTo(temp);
            return true;
        }

        /// <summary>
        /// Parses a file location string containing a file location and icon index, and returns separate values.
        /// Similar to the Shell's function with identical name. Any environment variables of the form %EnvVar% are
        /// also expanded to their values.
        /// </summary>
        /// <param name="path">The string containing the path to parse.</param>
        /// <returns> If the path refers to a .ico file, the return value
        /// is 0</returns>
        private int PathParseIconLocation(ref string path)
        {
            string[] temp;
            StringBuilder sb = new StringBuilder(260);

            if (path == null || path == String.Empty)
                throw new ArgumentException("The 'path' parameter cannot be null or an empty string.");

            temp = path.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            temp[0] = temp[0].Trim("\"".ToCharArray());

            WinShell.ExpandEnvironmentStrings(temp[0], sb, sb.Capacity);
            temp[0] = sb.ToString();
            
            if (temp.Length < 2)
                return 0;
            else
            {
                path = temp[0];
                return Convert.ToInt32(temp[1]);
            }
        }

        /// <summary>
        /// Determines a user friendly name of the program specified in the opensWithString parameter. 
        /// </summary>
        /// <param name="opensWithString">A string describing the path to the program whose friendly name is 
        /// to be retrieved. The input path can contain arguments, environment variables or relative path 
        /// information. On return, the parameter contains the filtered path to the program.</param>
        /// <returns>A user friendly description of the program specified by the opensWithString, or null
        /// if the path cannot be resolved or the program doesn't have a description string.</returns>
        private string GetProgramDescriptionString(ref string opensWithString)
        {
            StringBuilder sb = new StringBuilder(258);
            string[] pathComponents;
            string temp;

            try
            {
                if (opensWithString == null || opensWithString == String.Empty)
                    throw new ArgumentException("The 'opensWithString' cannot be null or an empty string.");

                if (opensWithString.StartsWith("rundll32.exe") || opensWithString.StartsWith("\"rundll32.exe\"") ||
                    opensWithString.StartsWith(Environment.SystemDirectory + "\\rundll32.exe") || opensWithString.StartsWith("\"" + Environment.SystemDirectory + "\\rundll32.exe\"") ||
                    opensWithString.StartsWith(Environment.GetEnvironmentVariable("windir") + "\\rundll32.exe") || opensWithString.StartsWith("\"" + Environment.GetEnvironmentVariable("windir") + "\\temp\""))
                {
                    pathComponents = opensWithString.Split(" ".ToCharArray());
                    pathComponents = pathComponents[1].Split(",".ToCharArray());
                    temp = pathComponents[0];
                }
                else
                {
                    sb.Append(opensWithString);
                    WinShell.PathRemoveArgs(sb);
                    temp = sb.ToString().Trim("\"".ToCharArray());
                    sb.Length = 0;
                }

                if (!Path.IsPathRooted(temp))
                {
                    WinShell.ExpandEnvironmentStrings(temp, sb, sb.Capacity);
                    temp = sb.ToString();
                }

                if (!Path.IsPathRooted(temp))
                {
                    if (File.Exists(Environment.SystemDirectory + "\\" + temp))
                        temp = Environment.SystemDirectory + "\\" + temp;
                    else if (File.Exists(Environment.GetEnvironmentVariable("windir") + "\\" + temp))
                        temp = Environment.GetEnvironmentVariable("windir") + "\\" + temp;
                    else if (File.Exists(Environment.CurrentDirectory + "\\" + temp))
                        temp = Environment.CurrentDirectory + "\\" + temp;
                    else if (File.Exists(Application.StartupPath + "\\" + temp))
                        temp = Application.StartupPath + "\\" + temp;
                    else
                    {
                        pathComponents = Environment.GetEnvironmentVariable("path").Split(";".ToCharArray());
                        foreach (string path in pathComponents)
                            if (File.Exists(path + "\\" + temp))
                            {
                                temp = path + "\\" + temp;
                                break;
                            }
                    }
                }
                
                opensWithString = temp;

                if (!Path.IsPathRooted(temp))
                    return null;
                else
                    return FileVersionInfo.GetVersionInfo(temp).FileDescription;
            }
            catch
            {
                return null;
            }
        }

        public void Close()
        {
            lock (synchronizationLock)
            {
                rBrowser.Close();
            }
        }
    }

    internal static class CategoryManager
    {
        private static XmlDocument settingsDoc = new XmlDocument();
        private static XmlNodeList nodeList;

        static CategoryManager()
        {
            settingsDoc.Load(Path.Combine(AppSettingsManager.AppInstallationDirectory, Resources.fileImageCategoriesXML));
        }

        public static List<ImageCategory> GetAllCategories()
        {
            List<ImageCategory> catList = new List<ImageCategory>();
            ImageCategory tempCategory;
            nodeList = settingsDoc.GetElementsByTagName("Category");

            foreach (XmlElement node in nodeList)
            {
                tempCategory = new ImageCategory();
                foreach (XmlElement temp in node.ChildNodes)
                {
                    if (temp.LocalName == "Name")
                        tempCategory.categoryName = temp.InnerText;
                    else
                        tempCategory.categoryDesc = temp.InnerText;
                }
                catList.Add(tempCategory);
            }

            return catList;
        }

        public static string GetCategory(string categoryName)
        {
            return FindCategoryNode(categoryName).GetAttribute("Description");
        }

        public static void AddCategory(string categoryName, string categoryDesc)
        {
            XmlNode temp = settingsDoc.CreateElement("Category"), temp1;

            temp1 = settingsDoc.CreateElement("Name");
            temp1.InnerText = categoryName;
            temp.AppendChild(temp1);
            temp1 = settingsDoc.CreateElement("Description");
            temp1.InnerText = categoryDesc;
            temp.AppendChild(temp1);

            settingsDoc.GetElementsByTagName("ImageCategories")[0].AppendChild(temp);

            settingsDoc.Save(Path.Combine(AppSettingsManager.AppInstallationDirectory, Resources.fileImageCategoriesXML));
        }

        public static void AddCategory(ImageCategory category)
        {
            AddCategory(category.categoryName, category.categoryDesc);
        }

        public static void RemoveCategory(string categoryName)
        {
            XmlElement temp = FindCategoryNode(categoryName);

            temp.ParentNode.RemoveChild(temp);
            settingsDoc.Save(Path.Combine(AppSettingsManager.AppInstallationDirectory, Resources.fileImageCategoriesXML));
        }

        public static void RemoveCategory(ImageCategory category)
        {
            RemoveCategory(category.categoryName);
        }

        private static XmlElement FindCategoryNode(string categoryName)
        {
            nodeList = settingsDoc.GetElementsByTagName("Name");

            foreach (XmlElement node in nodeList)
                if (node.InnerText == categoryName)
                    return (XmlElement)node.ParentNode;
            
            return null;
        }
    }

    internal static class AppSettingsManager
    {
        private static string imageListDbFileName;
        private static string imagesDirectory;
        private static string defaultBackupPath;
        private static string defaultRestorePath;
        private static string vfsSampleDatabase;
        private static string appInstallationDirectory;
        private static Color specialIconTextColor;
        private static bool showHiddenWithDistinctRepresentation;
        private static bool notifyOfInvisibleObjects;
        private static bool hideHidden;
        private static bool hideReadOnly;
        private static bool hideSystem;
        private static bool hideArchive;
        private static bool hideCompressed;
        private static bool hideEncrypted;
        private static bool notifyOfImagesInDeletedCategories;
        private static bool showExtensions;
        private static bool showObjectDetailsOnBottomPanel;
        private static bool showExtendedPropertiesPanel;
        private static View browserViewSetting;
        private static int imageBrowserWidth;
        private static int imageBrowserHeight;
        private static int vfsBrowserHeight;
        private static int extendedPropertiesPanelSplitterDistance;
        private static FormWindowState mainWindowState;
        private static int mainWindowWidth;
        private static int mainWindowHeight;
        private static int startPositionX;
        private static int startPositionY;
        private static bool autoPlayVideos;
        private static bool autoPlayAudios;
        
        // Details view columns
        private static bool showAccessedColumn;
        private static bool showAlbumColumn;
        private static bool showAlbumYearColumn;
        private static bool showArtistColumn;
        private static bool showAttributesColumn;
        private static bool showAuthorColumn;
        private static bool showBitrateColumn;
        private static bool showCategoryColumn;
        private static bool showCommentsColumn;
        private static bool showCompanyColumn;
        private static bool showCopyrightColumn;
        private static bool showCreatedDateColumn;
        private static bool showDescriptionColumn;
        //private static bool showFrameRateColumn;
        private static bool showGenreColumn;
        private static bool showDimensionsColumn;
        private static bool showModifiedDateColumn;
        //private static bool showOwnerColumn;
        private static bool showPagesColumn;
        private static bool showPVersionColumn;
        private static bool showSampleRateColumn;
        private static bool showSizeColumn;
        private static bool showSubjectColumn;
        private static bool showTitleColumn;
        private static bool showDurationColumn;
        private static bool showTrackNoColumn;
        private static bool showVersionColumn;
        private static bool showItemTypeColumn;
        private static bool showProductNameColumn;

        public static string ImageListDbFileName
        {
            get { return imageListDbFileName; }
            set { imageListDbFileName = value; }
        }
        public static string ImagesDirectory
        {
            get { return imagesDirectory; }
            set { imagesDirectory = value; }
        }
        public static string DefaultBackupPath
        {
            get { return defaultBackupPath; }
            set { defaultBackupPath = value; }
        }
        public static string DefaultRestorePath
        {
            get { return defaultRestorePath; }
            set { defaultRestorePath = value; }
        }
        public static string VFSSampleDatabase
        {
            get { return vfsSampleDatabase; }
            set { vfsSampleDatabase = value; }
        }
        public static string AppInstallationDirectory
        {
            get { return appInstallationDirectory; }
            set { appInstallationDirectory = value; }
        }
        public static Color SpecialIconTextColor
        {
            get { return specialIconTextColor; }
            set { specialIconTextColor = value; }
        }
        public static bool ShowHiddenWithDistinctRepresentation
        {
            get { return showHiddenWithDistinctRepresentation; }
            set { showHiddenWithDistinctRepresentation = value; }
        }
        public static bool NotifyOfInvisibleObjects
        {
            get { return notifyOfInvisibleObjects; }
            set { notifyOfInvisibleObjects = value; }
        }
        public static bool HideHidden
        {
            get { return hideHidden; }
            set { hideHidden = value; }
        }
        public static bool HideReadOnly
        {
            get { return hideReadOnly; }
            set { hideReadOnly = value; }
        }
        public static bool HideSystem
        {
            get { return hideSystem; }
            set { hideSystem = value; }
        }
        public static bool HideArchive
        {
            get { return hideArchive; }
            set { hideArchive = value; }
        }
        public static bool HideCompressed
        {
            get { return hideCompressed; }
            set { hideCompressed = value; }
        }
        public static bool HideEncrypted
        {
            get { return hideEncrypted; }
            set { hideEncrypted = value; }
        }
        public static bool NotifyOfImagesInDeletedCategories
        {
            get { return notifyOfImagesInDeletedCategories; }
            set { notifyOfImagesInDeletedCategories = value; }
        }
        public static bool ShowExtensions
        {
            get { return showExtensions; }
            set { showExtensions = value; }
        }
        public static bool ShowObjectDetailsOnBottomPanel
        {
            get { return showObjectDetailsOnBottomPanel; }
            set { showObjectDetailsOnBottomPanel = value; }
        }
        public static bool ShowExtendedPropertiesPanel
        {
            get { return showExtendedPropertiesPanel; }
            set { showExtendedPropertiesPanel = value; }
        }
        public static View BrowserViewSetting
        {
            get { return browserViewSetting; }
            set { browserViewSetting = value; }
        }
        public static int ImageBrowserWidth
        {
            get { return imageBrowserWidth; }
            set { imageBrowserWidth = value; }
        }
        public static int ImageBrowserHeight
        {
            get { return imageBrowserHeight; }
            set { imageBrowserHeight = value; }
        }
        public static int VFSBrowserHeight
        {
            get { return vfsBrowserHeight; }
            set { vfsBrowserHeight = value; }
        }
        public static int ExtendedPropertiesPanelSplitterDistance
        {
            get { return extendedPropertiesPanelSplitterDistance; }
            set { extendedPropertiesPanelSplitterDistance = value; }
        }
        public static FormWindowState MainWindowState
        {
            get { return mainWindowState; }
            set { mainWindowState = value; }
        }
        public static int MainWindowWidth
        {
            get { return mainWindowWidth; }
            set { mainWindowWidth = value; }
        }
        public static int MainWindowHeight
        {
            get { return mainWindowHeight; }
            set { mainWindowHeight = value; }

        }
        public static int StartPositionX
        {
            get { return startPositionX; }
            set { startPositionX = value; }
        }
        public static int StartPositionY
        {
            get { return startPositionY; }
            set { startPositionY = value; }
        }
        public static bool AutoPlayVideos
        {
            get { return autoPlayVideos; }
            set { autoPlayVideos = value; }
        }
        public static bool AutoPlayAudios
        {
            get { return autoPlayAudios; }
            set { autoPlayAudios = value; }
        }

        public static bool ShowAccessedDateColumn
        {
            get { return showAccessedColumn; }
            set { showAccessedColumn = value; }
        }
        public static bool ShowAlbumColumn
        {
            get { return showAlbumColumn; }
            set { showAlbumColumn = value; }
        }
        public static bool ShowAlbumYearColumn
        {
            get { return showAlbumYearColumn; }
            set { showAlbumYearColumn = value; }
        }
        public static bool ShowArtistColumn
        {
            get { return showArtistColumn; }
            set { showArtistColumn = value; }
        }
        public static bool ShowAttributesColumn
        {
            get { return showAttributesColumn; }
            set { showAttributesColumn = value; }
        }
        public static bool ShowAuthorColumn
        {
            get { return showAuthorColumn; }
            set { showAuthorColumn = value; }
        }
        public static bool ShowBitrateColumn
        {
            get { return showBitrateColumn; }
            set { showBitrateColumn = value; }
        }
        public static bool ShowCategoryColumn
        {
            get { return showCategoryColumn; }
            set { showCategoryColumn = value; }
        }
        public static bool ShowCommentsColumn
        {
            get { return showCommentsColumn; }
            set { showCommentsColumn = value; }
        }
        public static bool ShowCompanyColumn
        {
            get { return showCompanyColumn; }
            set { showCompanyColumn = value; }
        }
        public static bool ShowCopyrightColumn
        {
            get { return showCopyrightColumn; }
            set { showCopyrightColumn = value; }
        }
        public static bool ShowCreatedDateColumn
        {
            get { return showCreatedDateColumn; }
            set { showCreatedDateColumn = value; }
        }
        public static bool ShowDescriptionColumn
        {
            get { return showDescriptionColumn; }
            set { showDescriptionColumn = value; }
        }
        //public static bool ShowFrameRateColumn
        //{
        //    get { return showFrameRateColumn; }
        //    set { showFrameRateColumn = value; }
        //}
        public static bool ShowGenreColumn
        {
            get { return showGenreColumn; }
            set { showGenreColumn = value; }
        }
        public static bool ShowDimensionsColumn
        {
            get { return showDimensionsColumn; }
            set { showDimensionsColumn = value; }
        }
        public static bool ShowModifiedDateColumn
        {
            get { return showModifiedDateColumn; }
            set { showModifiedDateColumn = value; }
        }
        //public static bool ShowOwnerColumn
        //{
        //    get { return showOwnerColumn; }
        //    set { showOwnerColumn = value; }
        //}
        public static bool ShowPagesColumn
        {
            get { return showPagesColumn; }
            set { showPagesColumn = value; }
        }
        public static bool ShowProductNameColumn
        {
            get { return showProductNameColumn; }
            set { showProductNameColumn = value; }
        }
        public static bool ShowPVersionColumn
        {
            get { return showPVersionColumn; }
            set { showPVersionColumn = value; }
        }
        public static bool ShowSampleRateColumn
        {
            get { return showSampleRateColumn; }
            set { showSampleRateColumn = value; }
        }
        public static bool ShowSizeColumn
        {
            get { return showSizeColumn; }
            set { showSizeColumn = value; }
        }
        public static bool ShowSubjectColumn
        {
            get { return showSubjectColumn; }
            set { showSubjectColumn = value; }
        }
        public static bool ShowTitleColumn
        {
            get { return showTitleColumn; }
            set { showTitleColumn = value; }
        }
        public static bool ShowDurationColumn
        {
            get { return showDurationColumn; }
            set { showDurationColumn = value; }
        }
        public static bool ShowTrackNoColumn
        {
            get { return showTrackNoColumn; }
            set { showTrackNoColumn = value; }
        }
        public static bool ShowVersionColumn
        {
            get { return showVersionColumn; }
            set { showVersionColumn = value; }
        }
        public static bool ShowItemTypeColumn
        {
            get { return showItemTypeColumn; }
            set { showItemTypeColumn = value; }
        }

        static AppSettingsManager()
        {
            XmlDocument settingsDoc = new XmlDocument();
            XmlNodeList nodeList;
            List<string> detailColumns = new List<string>();
            int temp;

            try
            {
                settingsDoc.Load(Resources.fileConfigXML);

                defaultBackupPath = settingsDoc.GetElementsByTagName("DefaultBackupPath")[0].InnerText;
                defaultRestorePath = settingsDoc.GetElementsByTagName("DefaultRestorePath")[0].InnerText;
                try
                {
                    appInstallationDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                    imageListDbFileName = settingsDoc.GetElementsByTagName("ImageListDatabase")[0].InnerText;
                    vfsSampleDatabase = settingsDoc.GetElementsByTagName("VFSSampleDatabase")[0].InnerText;
                    imagesDirectory = Path.Combine(appInstallationDirectory, settingsDoc.GetElementsByTagName("ImagesDirectory")[0].InnerText);
                    if (!Directory.Exists(imagesDirectory))
                        Directory.CreateDirectory(imagesDirectory);
                }
                catch
                {
                    MessageBox.Show(Resources.msgErrorRetrievingCriticalSettings, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                specialIconTextColor = Color.FromArgb(Convert.ToInt32(settingsDoc.GetElementsByTagName("SpecialIconTextColor")[0].InnerText));

                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("ShowHiddenWithDistinctRepresentation")[0].InnerText);
                showHiddenWithDistinctRepresentation = (temp > 0)? true : false;

                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("NotifyOfInvisibleObjects")[0].InnerText);
                notifyOfInvisibleObjects = (temp > 0) ? true : false;

                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("HideObjectsWithAttributes")[0].InnerText);
                hideArchive = ((temp & (int)FileAttributes.FileAttributeArchive) > 0) ? true : false;
                hideReadOnly = ((temp & (int)FileAttributes.FileAttributeReadOnly) > 0) ? true : false;
                hideHidden = ((temp & (int)FileAttributes.FileAttributeHidden) > 0) ? true : false;
                hideSystem = ((temp & (int)FileAttributes.FileAttributeSystem) > 0) ? true : false;
                hideCompressed = ((temp & (int)FileAttributes.FileAttributeCompressed) > 0) ? true : false;
                hideEncrypted = ((temp & (int)FileAttributes.FileAttributeEncrypted) > 0) ? true : false;

                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("NotifyOfImagesInDeletedCategories")[0].InnerText);
                notifyOfImagesInDeletedCategories = (temp > 0) ? true : false;
                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("ShowExtensions")[0].InnerText);
                showExtensions = (temp > 0) ? true : false;
                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("ShowObjectDetailsOnBottomPanel")[0].InnerText);
                showObjectDetailsOnBottomPanel = (temp > 0) ? true : false;
                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("ShowExtendedPropertiesPanel")[0].InnerText);
                showExtendedPropertiesPanel = (temp > 0) ? true : false;
                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("BrowserViewSetting")[0].InnerText);
                if (temp == (int)View.Details || temp == (int)View.LargeIcon || temp == (int)View.List)
                    browserViewSetting = (View)temp;
                else
                    browserViewSetting = View.LargeIcon;
                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("MainWindowState")[0].InnerText);
                if (temp == (int)FormWindowState.Maximized || temp == (int)FormWindowState.Normal)
                    mainWindowState = (FormWindowState)temp;
                else
                    mainWindowState = FormWindowState.Maximized;
                imageBrowserWidth = Convert.ToInt32(settingsDoc.GetElementsByTagName("ImageBrowserWidth")[0].InnerText);
                imageBrowserHeight = Convert.ToInt32(settingsDoc.GetElementsByTagName("ImageBrowserHeight")[0].InnerText);
                vfsBrowserHeight = Convert.ToInt32(settingsDoc.GetElementsByTagName("VFSBrowserHeight")[0].InnerText);
                extendedPropertiesPanelSplitterDistance = Convert.ToInt32(settingsDoc.GetElementsByTagName("ExtendedPropertiesPanelSplitterDistance")[0].InnerText);
                mainWindowWidth = Convert.ToInt32(settingsDoc.GetElementsByTagName("MainWindowWidth")[0].InnerText);
                mainWindowHeight = Convert.ToInt32(settingsDoc.GetElementsByTagName("MainWindowHeight")[0].InnerText);
                startPositionX = Convert.ToInt32(settingsDoc.GetElementsByTagName("StartPositionX")[0].InnerText);
                startPositionY = Convert.ToInt32(settingsDoc.GetElementsByTagName("StartPositionY")[0].InnerText); 

                // The following checks are necessary to the visibility of the main window when restored.
                startPositionX = (startPositionX < 0) ? 1 : startPositionX;
                startPositionY = (startPositionY < 0) ? 1 : startPositionY;
                mainWindowWidth = (mainWindowWidth < 640) ? 640 : mainWindowWidth;
                mainWindowHeight = (mainWindowHeight < 480) ? 480 : mainWindowHeight;


                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("AutoPlayVideos")[0].InnerText);
                autoPlayVideos = (temp > 0) ? true : false;
                temp = Convert.ToInt32(settingsDoc.GetElementsByTagName("AutoPlayAudios")[0].InnerText);
                autoPlayAudios = (temp > 0) ? true : false;

                nodeList = settingsDoc.GetElementsByTagName("Column");
                foreach (XmlNode node in nodeList)
                    detailColumns.Add(node.InnerText);

                showAccessedColumn = detailColumns.Contains("Accessed");
                showAlbumColumn = detailColumns.Contains("Album");
                showAlbumYearColumn = detailColumns.Contains("AlbumYear");
                showArtistColumn = detailColumns.Contains("Artist");
                showAttributesColumn = detailColumns.Contains("Attributes");
                showAuthorColumn = detailColumns.Contains("Author");
                showBitrateColumn = detailColumns.Contains("Bitrate");
                showCategoryColumn = detailColumns.Contains("Category");
                showCommentsColumn = detailColumns.Contains("Comments");
                showCompanyColumn = detailColumns.Contains("Company");
                showCopyrightColumn = detailColumns.Contains("Copyright");
                showCreatedDateColumn = detailColumns.Contains("Created");
                showDescriptionColumn = detailColumns.Contains("Description");
                showDimensionsColumn = detailColumns.Contains("Dimensions");
                showDurationColumn = detailColumns.Contains("Duration");
                //showFrameRateColumn = detailColumns.Contains("FrameRate");
                showGenreColumn = detailColumns.Contains("Genre");
                showModifiedDateColumn = detailColumns.Contains("Modified");
                //showOwnerColumn = detailColumns.Contains("Owner");
                showPagesColumn = detailColumns.Contains("Pages");
                showPVersionColumn = detailColumns.Contains("PVersion");
                showSampleRateColumn = detailColumns.Contains("SampleRate");
                showSizeColumn = detailColumns.Contains("Size");
                showSubjectColumn = detailColumns.Contains("Subject");
                showTitleColumn = detailColumns.Contains("Title");
                showTrackNoColumn = detailColumns.Contains("TrackNumber");
                showVersionColumn = detailColumns.Contains("Version");
                showItemTypeColumn = detailColumns.Contains("ItemType");
                showProductNameColumn = detailColumns.Contains("ProductName");
            }
            catch
            {
                MessageBox.Show(Resources.msgErrorRetrievingSettings, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UpdateSettings()
        {
            XmlDocument settingsDoc = new XmlDocument();
            XmlElement tempElement, tempElement2;
            int temp = 0;

            try
            {
                settingsDoc.Load(Path.Combine(appInstallationDirectory, Resources.fileConfigXML));

                settingsDoc.GetElementsByTagName("ImageListDatabase")[0].InnerText = imageListDbFileName;
                // settingsDoc.GetElementsByTagName("ImagesDirectory")[0].InnerText = imagesDirectory;
                settingsDoc.GetElementsByTagName("DefaultBackupPath")[0].InnerText = defaultBackupPath;
                settingsDoc.GetElementsByTagName("DefaultRestorePath")[0].InnerText = defaultRestorePath;
                settingsDoc.GetElementsByTagName("VFSSampleDatabase")[0].InnerText = vfsSampleDatabase;

                settingsDoc.GetElementsByTagName("SpecialIconTextColor")[0].InnerText = specialIconTextColor.ToArgb().ToString();

                temp = showHiddenWithDistinctRepresentation ? 1 : 0;
                settingsDoc.GetElementsByTagName("ShowHiddenWithDistinctRepresentation")[0].InnerText = temp.ToString();

                temp = notifyOfInvisibleObjects ? 1 : 0;
                settingsDoc.GetElementsByTagName("NotifyOfInvisibleObjects")[0].InnerText = temp.ToString();

                temp = 0;
                temp |= (int)((hideArchive) ? FileAttributes.FileAttributeArchive : 0);
                temp |= (int)((hideReadOnly) ? FileAttributes.FileAttributeReadOnly : 0);
                temp |= (int)((hideHidden) ? FileAttributes.FileAttributeHidden : 0);
                temp |= (int)((hideSystem) ? FileAttributes.FileAttributeSystem : 0);
                temp |= (int)((hideCompressed) ? FileAttributes.FileAttributeCompressed : 0);
                temp |= (int)((hideEncrypted) ? FileAttributes.FileAttributeEncrypted : 0);
                settingsDoc.GetElementsByTagName("HideObjectsWithAttributes")[0].InnerText = temp.ToString();

                temp = ((notifyOfImagesInDeletedCategories) ? 1 : 0);
                settingsDoc.GetElementsByTagName("NotifyOfImagesInDeletedCategories")[0].InnerText = temp.ToString();
                temp = ((showExtensions) ? 1 : 0);
                settingsDoc.GetElementsByTagName("ShowExtensions")[0].InnerText = temp.ToString();
                temp = ((showObjectDetailsOnBottomPanel) ? 1 : 0);
                settingsDoc.GetElementsByTagName("ShowObjectDetailsOnBottomPanel")[0].InnerText = temp.ToString();
                temp = ((showExtendedPropertiesPanel) ? 1 : 0);
                settingsDoc.GetElementsByTagName("ShowExtendedPropertiesPanel")[0].InnerText = temp.ToString();
                temp = autoPlayVideos ? 1 : 0;
                settingsDoc.GetElementsByTagName("AutoPlayVideos")[0].InnerText = temp.ToString();
                temp = autoPlayAudios ? 1 : 0;
                settingsDoc.GetElementsByTagName("AutoPlayAudios")[0].InnerText = temp.ToString();

                tempElement = (XmlElement)settingsDoc.GetElementsByTagName("DetailColumnns")[0];
                tempElement.RemoveAll();

                if (showAccessedColumn)
                { 
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Accessed";
                    tempElement.AppendChild(tempElement2);
                }
                if (showAlbumColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Album";
                    tempElement.AppendChild(tempElement2);
                }
                if (showAlbumYearColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "AlbumYear";
                    tempElement.AppendChild(tempElement2);
                }
                if (showArtistColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Artist";
                    tempElement.AppendChild(tempElement2);
                }
                if (showAttributesColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Attributes";
                    tempElement.AppendChild(tempElement2);
                }
                if (showAuthorColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Author";
                    tempElement.AppendChild(tempElement2);
                }
                if (showBitrateColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Bitrate";
                    tempElement.AppendChild(tempElement2);
                }
                if (showCategoryColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Category";
                    tempElement.AppendChild(tempElement2);
                }
                if (showCommentsColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Comments";
                    tempElement.AppendChild(tempElement2);
                }
                if (showCompanyColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Company";
                    tempElement.AppendChild(tempElement2);
                }
                if (showCopyrightColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Copyright";
                    tempElement.AppendChild(tempElement2);
                }
                if (showCreatedDateColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Created";
                    tempElement.AppendChild(tempElement2);
                }
                if (showDescriptionColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Description";
                    tempElement.AppendChild(tempElement2);
                }
                if (showDimensionsColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Dimensions";
                    tempElement.AppendChild(tempElement2);
                }
                if (showDurationColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Duration";
                    tempElement.AppendChild(tempElement2);
                }
                if (showGenreColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Genre";
                    tempElement.AppendChild(tempElement2);
                }
                if (showModifiedDateColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Modified";
                    tempElement.AppendChild(tempElement2);
                }
                if (showPagesColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Pages";
                    tempElement.AppendChild(tempElement2);
                }
                if (showPVersionColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "PVersion";
                    tempElement.AppendChild(tempElement2);
                }
                if (showSampleRateColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "SampleRate";
                    tempElement.AppendChild(tempElement2);
                }
                if (showSizeColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Size";
                    tempElement.AppendChild(tempElement2);
                }
                if (showSubjectColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Subject";
                    tempElement.AppendChild(tempElement2);
                }
                if (showTitleColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Title";
                    tempElement.AppendChild(tempElement2);
                }
                if (showTrackNoColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "TrackNumber";
                    tempElement.AppendChild(tempElement2);
                }
                if (showVersionColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "Version";
                    tempElement.AppendChild(tempElement2);
                }
                if (showItemTypeColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "ItemType";
                    tempElement.AppendChild(tempElement2);
                }
                if (showProductNameColumn)
                {
                    tempElement2 = settingsDoc.CreateElement("Column");
                    tempElement2.InnerText = "ProductName";
                    tempElement.AppendChild(tempElement2);
                }
                //if (showFrameRateColumn).ToString() rBrowser.SetValue("FrameRate", String.Empty, RegistryValueKind.String); else rBrowser.DeleteValue("FrameRate");
                //if (showOwnerColumn).ToString() rBrowser.SetValue("Owner", String.Empty, RegistryValueKind.String); else rBrowser.DeleteValue("Owner");

                settingsDoc.Save(Path.Combine(appInstallationDirectory, Resources.fileConfigXML));
            }
            catch
            {
                MessageBox.Show(Resources.msgErrorSavingSettings);
            }
        }

        public static void SaveWindowMetrics()
        {
            XmlDocument settingsDoc = new XmlDocument();

            settingsDoc.Load(Path.Combine(appInstallationDirectory, Resources.fileConfigXML));

            settingsDoc.GetElementsByTagName("BrowserViewSetting")[0].InnerText = ((int)browserViewSetting).ToString();
            settingsDoc.GetElementsByTagName("MainWindowState")[0].InnerText = ((int)mainWindowState).ToString();
            settingsDoc.GetElementsByTagName("ImageBrowserWidth")[0].InnerText = imageBrowserWidth.ToString();
            settingsDoc.GetElementsByTagName("ImageBrowserHeight")[0].InnerText = imageBrowserHeight.ToString();
            settingsDoc.GetElementsByTagName("VFSBrowserHeight")[0].InnerText = vfsBrowserHeight.ToString();
            settingsDoc.GetElementsByTagName("ExtendedPropertiesPanelSplitterDistance")[0].InnerText = extendedPropertiesPanelSplitterDistance.ToString();
            settingsDoc.GetElementsByTagName("MainWindowWidth")[0].InnerText = mainWindowWidth.ToString();
            settingsDoc.GetElementsByTagName("MainWindowHeight")[0].InnerText = mainWindowHeight.ToString();
            settingsDoc.GetElementsByTagName("StartPositionX")[0].InnerText = startPositionX.ToString();
            settingsDoc.GetElementsByTagName("StartPositionY")[0].InnerText = startPositionY.ToString();

            settingsDoc.Save(Path.Combine(appInstallationDirectory, Resources.fileConfigXML));
        }

        private enum FileAttributes
        {
            FileAttributeArchive = 1, FileAttributeReadOnly, FileAttributeHidden = 4,
            FileAttributeSystem = 8, FileAttributeCompressed = 16, FileAttributeEncrypted = 32
        };
    }
    
    internal static class IconFunctions
    {
        private static Icon icon1, icon2;
        private static Icon[] iconArr = new Icon[2];
        private static IntPtr hIcon1, hIcon2 = new IntPtr();

        public static Icon IconFromBytes(byte[] bytes)
        {
            Icon icon;
            try
            {
                icon = new Icon(new MemoryStream(bytes));
            }
            catch (ArgumentException)
            {
                return null;
            }
            return icon;
        }

        public static byte[] IconToBytes(Icon icon)
        {
            MemoryStream mem = new MemoryStream();

            try
            {
                icon.Save(mem);
            }
            catch
            {
                return null;
            }

            return mem.ToArray();
        }

        public static Icon ExtractSingleIcon(string filePath)
        {
            hIcon1 = IntPtr.Zero;
            try
            {
                hIcon1 = WinIcons.ExtractIcon(IntPtr.Zero, filePath, 0);
                if (hIcon1 == IntPtr.Zero)
                    return null;

                icon1 = Icon.FromHandle(hIcon1);
                icon2 = (Icon)icon1.Clone();
                WinIcons.DestroyIcon(icon1.Handle);
            }
            catch
            {
                icon2 = null;
            }
            return icon2;
        }

        public static Icon ExtractSingleIcon(string filePath, int nIconIndex)
        {
            hIcon1 = IntPtr.Zero;
            try
            {
                hIcon1 = WinIcons.ExtractIcon(IntPtr.Zero, filePath, nIconIndex);
                if (hIcon1 == IntPtr.Zero)
                    return null;

                icon1 = Icon.FromHandle(hIcon1);
                icon2 = (Icon)icon1.Clone();
                WinIcons.DestroyIcon(icon1.Handle);
            }
            catch
            {
                icon2 = null;
            }
            return icon2;
        }

        public static Icon[] ExtractIcon(string filePath, int nIconIndex)
        {
            hIcon1 = IntPtr.Zero;
            hIcon2 = IntPtr.Zero;
            Array.Clear(iconArr, 0, iconArr.Length);
            try
            {
                WinIcons.ExtractIconEx(filePath, nIconIndex, ref hIcon1, ref hIcon2, 1);
                try
                {
                    icon1 = Icon.FromHandle(hIcon1);
                }
                catch
                {
                    icon1 = null;
                }

                icon2 = Icon.FromHandle(hIcon2);
                if (icon1 != null)
                    iconArr[0] = (Icon)icon1.Clone();
                iconArr[1] = (Icon)icon2.Clone();

                WinIcons.DestroyIcon(icon1.Handle);
                WinIcons.DestroyIcon(icon2.Handle);
            }
            catch
            {
                Array.Clear(iconArr, 0, iconArr.Length);
            }
            return iconArr;
        }

        public static Icon ExtractStandardIcon(StandardIcons iconToLoad)
        {
            return ExtractSingleIcon(Path.Combine(Environment.SystemDirectory, "shell32.dll"), (int)iconToLoad);
        }

        public static Icon[] ExtractStandardIconArray(StandardIcons iconToLoad)
        {
            return ExtractIcon(Path.Combine(Environment.SystemDirectory, "shell32.dll"), (int)iconToLoad);
        }
    }

    internal static class FSItemFilterationHandler
    {
        private static FilterSettings filterSettings;

        public static void Initialize(FilterSettings filters)
        {
            filterSettings = filters;
        }

        public static bool Filter(FSItem fsItem)
        {
            if (!(filterSettings.excludedFiles.Contains(fsItem.fsItemName) || filterSettings.excludedDirectories.Contains(fsItem.fsItemName)))
                if (SizeFilter(fsItem))
                    if (AttributeFilter(fsItem))
                        if (DateFilter(fsItem))
                            if (TypeFilter(fsItem))
                                return true;
            return false;
        }

        private static bool SizeFilter(FSItem fsItem)
        {
            if (filterSettings.sizeFilter && ((fsItem.fsItemAttributes & FileAttributes.Directory) == 0))
            {
                if (filterSettings.minSize < filterSettings.maxSize)
                {
                    if (fsItem.fsItemSize > filterSettings.minSize && fsItem.fsItemSize < filterSettings.maxSize)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (fsItem.fsItemSize > filterSettings.maxSize && fsItem.fsItemSize < filterSettings.minSize)
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }

        private static bool AttributeFilter(FSItem fsItem)
        {
            if (filterSettings.attrFilter && ((fsItem.fsItemAttributes & FileAttributes.Directory) == 0))
            {
                if (!(((fsItem.fsItemAttributes & FileAttributes.Archive) != 0) && filterSettings.exArchive))
                    if (!(((fsItem.fsItemAttributes & FileAttributes.ReadOnly) != 0) && filterSettings.exROnly))
                        if (!(((fsItem.fsItemAttributes & FileAttributes.Hidden) != 0) && filterSettings.exHidden))
                            if (!(((fsItem.fsItemAttributes & FileAttributes.System) != 0) && filterSettings.exSystem))
                                if (!(((fsItem.fsItemAttributes & FileAttributes.ReadOnly) != 0) && filterSettings.exCompressed))
                                    if (!(((fsItem.fsItemAttributes & FileAttributes.ReadOnly) != 0) && filterSettings.exEncrypted))
                                        return true;
                return false;
            }
            return true;
        }

        private static bool DateFilter(FSItem fsItem)
        {
            if (filterSettings.dateFilter && ((fsItem.fsItemAttributes & FileAttributes.Directory) != 0))
            {
                if (filterSettings.cDate)
                    if (!(fsItem.fsItemCreatedDate > filterSettings.cDateBegin && fsItem.fsItemCreatedDate < filterSettings.cDateEnd))
                        return false;

                if (filterSettings.mDate)
                    if (!(fsItem.fsItemModifiedDate > filterSettings.mDateBegin && fsItem.fsItemModifiedDate < filterSettings.mDateEnd))
                        return false;

                if (filterSettings.aDate)
                    if (!(fsItem.fsItemAccessedDate > filterSettings.aDateBegin && fsItem.fsItemAccessedDate < filterSettings.aDateEnd))
                        return false;
            }
            return true;
        }

        private static bool TypeFilter(FSItem fsItem)
        {
            string[] exts;
            string temp;
            
            exts = filterSettings.fTypes.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            if (exts.Length == 0)
                return true;
            temp = fsItem.fsItemName.ToLower();

            if (filterSettings.fTypeFilter)
            {
                foreach (string ext in exts)
                    if (((fsItem.fsItemAttributes & FileAttributes.Directory) == 0) && temp.EndsWith(ext))
                        return false;
                return true;
            }
            else
            {
                foreach (string ext in exts)
                    if (((fsItem.fsItemAttributes & FileAttributes.Directory) != 0) || temp.EndsWith(ext))
                        return true;
                return false;
            }
        }
    }

    internal static class ImageListManipulator
    {
        private static OleDbConnection listDb;
        private static OleDbCommand dbCommand;
        private static OleDbDataReader dReader;

        private static List<ListEntry> tempList;

        static ImageListManipulator()
        {
            listDb = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                Path.Combine(Application.StartupPath, AppSettingsManager.ImageListDbFileName) +
                "; Jet OLEDB:Database Password=RXhwZWxsaWFybXVz;");
            dbCommand = new OleDbCommand();

            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
        }

        public static void ReadAllEntries(ListEntryProcessorDelegate EntryProcessorCallback)
        {
            ListEntry entry;
            
            dbCommand.CommandText = "SELECT * FROM ImageList";
            dbCommand.Connection = listDb;

            try
            {
                listDb.Open();
                dReader = dbCommand.ExecuteReader();
                while (dReader.Read())
                {
                    entry = new ListEntry();
                    entry.imageID = (UInt32)((Int32)dReader.GetValue(0));
                    entry.imageName = (String)dReader.GetValue(1);
                    entry.imageDescription = (String)dReader.GetValue(2);
                    entry.imagePicture = (String)dReader.GetValue(3);
                    entry.imageDbPath = (String)dReader.GetValue(4);
                    entry.imageSourcePath = (String)dReader.GetValue(5);
                    entry.imageCategory = (String)dReader.GetValue(6);
                    entry.imageSourceVolLabel = (String)dReader.GetValue(7);
                    entry.imageSourceFileSystem = (String)dReader.GetValue(8);
                    entry.imageSourceDriveType = (Byte)dReader.GetValue(9);

                    EntryProcessorCallback(entry);
                }
            }
            finally
            {
                if (!dReader.IsClosed)
                    dReader.Close();
                if (listDb.State != System.Data.ConnectionState.Closed)
                    listDb.Close();
            }
        }

        public static ListEntry ReadEntry(UInt32 entryNumber)
        {
            ListEntry entry;

            dbCommand.CommandText = "SELECT * FROM ImageList WHERE id=" + entryNumber.ToString();
            dbCommand.Connection = listDb;

            try
            {
                listDb.Open();
                dReader = dbCommand.ExecuteReader();
                
                if (!dReader.Read())
                    throw new InvalidOperationException("No image with ID " + entryNumber.ToString() + " exists in the database.");
                
                entry.imageID = (UInt32)((Int32)dReader.GetValue(0));
                entry.imageName = (String)dReader.GetValue(1);
                entry.imageDescription = (String)dReader.GetValue(2);
                entry.imagePicture = (String)dReader.GetValue(3);
                entry.imageDbPath = (String)dReader.GetValue(4);
                entry.imageSourcePath = (String)dReader.GetValue(5);
                entry.imageCategory = (String)dReader.GetValue(6);
                entry.imageSourceVolLabel = (String)dReader.GetValue(7);
                entry.imageSourceFileSystem = (String)dReader.GetValue(8);
                entry.imageSourceDriveType = (Byte)dReader.GetValue(9);
            }
            finally
            {
                dReader.Close();
                if (listDb.State != System.Data.ConnectionState.Closed)
                    listDb.Close();
            }
            return entry;
        }

        public static void DeleteEntry(UInt32 entryNumber)
        {
            dbCommand.CommandText = "DELETE FROM ImageList WHERE ID=" + entryNumber.ToString();
            dbCommand.Connection = listDb;

            try
            {
                listDb.Open();
                dbCommand.ExecuteNonQuery();
            }
            finally
            {
                if (listDb.State != System.Data.ConnectionState.Closed)
                    listDb.Close();
            }
        }

        public static int AddEntry(ListEntry entry)
        {
            int retVal;

            try
            {
                dbCommand.Connection = listDb;
                dbCommand.Parameters[0].Value = entry.imageName;
                dbCommand.Parameters[1].Value = entry.imageDescription;
                dbCommand.Parameters[2].Value = entry.imagePicture;
                dbCommand.Parameters[3].Value = entry.imageDbPath;
                dbCommand.Parameters[4].Value = entry.imageSourcePath;
                dbCommand.Parameters[5].Value = entry.imageCategory;
                dbCommand.Parameters[6].Value = entry.imageSourceVolLabel;
                dbCommand.Parameters[7].Value = entry.imageSourceFileSystem;
                
                dbCommand.CommandText = "INSERT INTO ImageList VALUES(" + entry.imageID.ToString() + 
                    ", ?, ?, ?, ?, ?, ?, ?, ?, " + entry.imageSourceDriveType.ToString() + ");";
                
                listDb.Open();

                retVal = dbCommand.ExecuteNonQuery();
            }
            finally
            {
                if (listDb.State != System.Data.ConnectionState.Closed)
                    listDb.Close();
            }
            return retVal;
        }

        public static int UpdateEntry(UInt32 entryNumber, ListEntry newInfo)
        {
            int retVal;

            try
            {
                dbCommand.Connection = listDb;
                dbCommand.Parameters[0].Value = newInfo.imageName;
                dbCommand.Parameters[1].Value = newInfo.imageDescription;
                dbCommand.Parameters[2].Value = newInfo.imagePicture;
                dbCommand.Parameters[3].Value = newInfo.imageDbPath;
                dbCommand.Parameters[4].Value = newInfo.imageSourcePath;
                dbCommand.Parameters[5].Value = newInfo.imageCategory;
                dbCommand.Parameters[6].Value = newInfo.imageSourceVolLabel;
                dbCommand.Parameters[7].Value = newInfo.imageSourceFileSystem;
                
                dbCommand.CommandText = "UPDATE ImageList SET VolumeLabel=?, Description=?, CD_Image=?, DBPath=?, " +
                    "SourcePath=?, Category=?, SourceVolLabel=?, SourceFileSystem=?, DriveType=" + 
                    newInfo.imageSourceDriveType.ToString() + " WHERE ID=" + entryNumber.ToString() + ";";

                listDb.Open();

                retVal = dbCommand.ExecuteNonQuery();
            }
            finally
            {
                if (listDb.State != System.Data.ConnectionState.Closed)
                    listDb.Close();
            }
            return retVal;
        }

        public static uint GetEntryCountWithID(UInt32 entryNumber)
        {
            UInt32 temp = 0;

            try
            {
                listDb.Open();
                dbCommand.CommandText = "SELECT Count(*) FROM ImageList WHERE id=" + entryNumber.ToString();
                dbCommand.Connection = listDb;

                dReader = dbCommand.ExecuteReader();
                dReader.Read();

                temp = (uint)dReader.GetInt32(0);
            }
            finally
            {
                dReader.Close();
                if (listDb.State != System.Data.ConnectionState.Closed)
                    listDb.Close();
            }

            return temp;
        }

        public static List<ListEntry> GetAllImages()
        {
            tempList = new List<ListEntry>();

            ReadAllEntries(ListEntryProcessor);

            return tempList;
        }

        private static void ListEntryProcessor(ListEntry entry)
        {
            tempList.Add(entry);
        }
    }

    internal static class GeneralMethods
    {
        public static string GetFormattedSize(UInt64 sizeInBytes)
        {
            string[] conventions = { " Bytes", " KBytes", " MBytes", " GBytes", " TBytes", " PBytes" };
            int index = 0;
            double temp = sizeInBytes;

            while (temp >= 1024)
            {
                temp /= 1024;
                index++;
            }

            temp = Math.Round(temp, 2);

            return (((index > 0) ? temp.ToString("N02") : temp.ToString("N00")) + " " + conventions[index] + ((index > 0) ? (" (" + sizeInBytes.ToString("N00") + " bytes)") : ""));
        }
        public static string GetFormattedSizeForColumn(UInt64 sizeInBytes)
        {
            string[] conventions = { " Bytes", " KB", " MB", " GB", " TB", " PB" };
            int index = 0;

            while (sizeInBytes >= 1024)
            {
                sizeInBytes /= 1024;
                index++;
            }

            return sizeInBytes.ToString() + conventions[index];
        }
        public static Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bitmap)) 
            {
                g.FillRegion(new SolidBrush(SystemColors.Window), new Region(new Rectangle(0, 0, image.Width, image.Height)));
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity; 
                ImageAttributes attributes = new ImageAttributes(); 
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap); 
                g.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes); 
            }
            //bitmap.MakeTransparent(SystemColors.Window);
            return bitmap; 
        }
        public static bool IsFileTypeAudio(string filePath)
        {
            filePath = Path.GetExtension(filePath).ToLower();

            if (filePath == ".mp3" || filePath == ".ogg" || filePath == ".wma" || filePath == ".flac" ||
                filePath == ".mp2" || filePath == ".aiff" || filePath == ".wav" || filePath == ".au" || 
                filePath == ".aif" || filePath == ".mid" || filePath == ".rmi")
                return true;
            return false;
        }
        public static bool IsFileTypeVideo(string filePath)
        {
            filePath = Path.GetExtension(filePath).ToLower();
            
            if (filePath == ".mpg" || filePath == ".avi" || filePath == ".asf" || filePath == ".wmv" ||
                filePath == ".mpeg" || filePath == ".m1v" || filePath == ".mkv" || filePath == ".mp4" ||
                filePath == ".mov" || filePath == ".vob" || filePath == ".flv")
                return true;
            return false;
        }
        public static bool IsFileTypeDocument(string filePath)
        {
            filePath = Path.GetExtension(filePath).ToLower();
            if (filePath == ".doc" || filePath == ".docx" || filePath == ".docm" || filePath == ".dot" ||
                filePath == ".dotx" || filePath == ".xls" || filePath == ".xlsx" || filePath == ".xlsm" ||
                filePath == ".xlsb" || filePath == ".xla" || filePath == ".xlam" || filePath == ".xlam" ||
                filePath == ".ppt" || filePath == ".pptx" || filePath == ".pptm" || filePath == ".vsd")
                return true;
            return false;
        }
        public static bool IsFileTypeImage(string filePath)
        {
            filePath = Path.GetExtension(filePath).ToLower();

            if (filePath == ".jpg" || filePath == ".bmp" || filePath == ".png" || filePath == ".jpeg" ||
                filePath == ".gif" || filePath == ".tif" || filePath == ".ani" || filePath == ".cur" ||
                filePath == ".ico" || filePath == ".wmf" || filePath == ".emf")
                return true;
            return false;
        }
        public static string TruncatePathString(string pathString, int maxLen)
        {
            int tempInt;
            string tempString;

            if (pathString.Length < 1)
                throw new ArgumentException("The pathString must contain a non-zero length string.", "pathString");
            if (maxLen > pathString.Length || maxLen < 10)
                throw new ArgumentException("The maxLen parameter must be withing the range 10 to the number of characters in the pathString.", "maxLen");

            tempInt = maxLen / 2;

            tempString = pathString.Substring(0, tempInt - 2);
            tempString += "...";
            maxLen = maxLen - tempString.Length;
            maxLen = pathString.Length - maxLen;
            tempString += pathString.Substring(maxLen);

            return tempString;
        }
        public static string GetFormattedBitrate(UInt64 bps)
        {
            string[] conventions = { "Kbps", "Mbps", "Gbps", "Tbps", "Pbps" };
            int index = 0;

            while (bps >= 1000)
            {
                bps /= 1000;
                index++;
            }

            return (bps.ToString() + conventions[index]);
        }
        public static void GetMusicProperties(VFSEntry entry, ListView lView, int groupIndex)
        {
            if (entry.title.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Title", entry.title }, lView.Groups[groupIndex]));
            if (entry.artist.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Artist", entry.artist }, lView.Groups[groupIndex]));
            if (entry.album.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Album", entry.album }, lView.Groups[groupIndex]));
            if (entry.albumYear > 1500)
                lView.Items.Add(new ListViewItem(new string[] { "Album Year", entry.albumYear.ToString() }, lView.Groups[groupIndex]));
            if (entry.genre.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Genre", entry.genre }, lView.Groups[groupIndex]));
            if (entry.trackNo > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Track Number", entry.trackNo.ToString() }, lView.Groups[groupIndex]));
            if (entry.trackDurtion > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Duration", (new TimeSpan(0, 0, (int)entry.trackDurtion)).ToString() }, lView.Groups[groupIndex]));
        }
        public static void GetAudioProperties(VFSEntry entry, ListView lView, int groupIndex)
        {
            if (entry.bitRate > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Bitrate", GeneralMethods.GetFormattedBitrate(entry.bitRate) }, lView.Groups[groupIndex]));
            if (entry.sampleRate > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Sample Rate", entry.sampleRate.ToString() + "Hz" }, lView.Groups[groupIndex]));
        }
        public static void GetVideoProperties(VFSEntry entry, ListView lView, int groupIndex)
        {
            if (entry.height > 0 && entry.width > 0)
            {
                lView.Items.Add(new ListViewItem(new string[] { "Width", entry.width.ToString() }, lView.Groups[groupIndex]));
                lView.Items.Add(new ListViewItem(new string[] { "Height", entry.height.ToString() }, lView.Groups[groupIndex]));
            }
        }
        public static void GetImageProperties(VFSEntry entry, ListView lView, int groupIndex)
        {
            if (entry.height > 0 && entry.width > 0)
            {
                lView.Items.Add(new ListViewItem(new string[] { "Width", entry.width.ToString() }, lView.Groups[groupIndex]));
                lView.Items.Add(new ListViewItem(new string[] { "Height", entry.height.ToString() }, lView.Groups[groupIndex]));
            }
        }
        public static void GetDocumentProperties(VFSEntry entry, ListView lView, int groupIndex)
        {
            if (entry.author.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Author", entry.author }, lView.Groups[groupIndex]));
            if (entry.category.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Category", entry.category }, lView.Groups[groupIndex]));
            if (entry.comments.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Comments", entry.comments }, lView.Groups[groupIndex]));
            if (entry.company.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Company", entry.company }, lView.Groups[groupIndex]));
            if (entry.pages > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Pages", entry.pages.ToString() }, lView.Groups[groupIndex]));
            if (entry.subject.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Subject", entry.subject }, lView.Groups[groupIndex]));
            if (entry.title.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Title", entry.title }, lView.Groups[groupIndex]));
        }
        public static void GetGeneralFileProperties(VFSEntry entry, ListView lView, int groupIndex)
        {
            if (!GeneralMethods.IsFileTypeDocument(entry.name))
            {
                if (entry.comments.Length > 0)
                    lView.Items.Add(new ListViewItem(new string[] { "Comments", entry.comments }, lView.Groups[groupIndex]));
                if (entry.company.Length > 0)
                    lView.Items.Add(new ListViewItem(new string[] { "Company", entry.company }, lView.Groups[groupIndex]));
            }
            if (entry.copyright.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Copyright", entry.copyright }, lView.Groups[groupIndex]));
            if (entry.description.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Description", entry.description }, lView.Groups[groupIndex]));
            if (entry.productName.Length > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Product Name", entry.productName }, lView.Groups[groupIndex]));
            if (entry.majorPV + entry.minorPV + entry.pRevision > 0)
                lView.Items.Add(new ListViewItem(new string[] { "Product Version", entry.majorPV.ToString() 
                    + "." + entry.minorPV.ToString() + "." + entry.pRevision.ToString() }, lView.Groups[groupIndex]));
            if (entry.majorV + entry.minorV + entry.revision > 0)
                lView.Items.Add(new ListViewItem(new string[] { "File Version", entry.majorV.ToString() 
                    + "." + entry.minorV.ToString() + "." + entry.revision.ToString() }, lView.Groups[groupIndex]));
        }
    }

    internal static class ImageHeaderReader
    {
        private delegate Size Func(BinaryReader reader);
        private static Dictionary<byte[], Func> imageFormatDecoders = new Dictionary<byte[], Func>();

        static ImageHeaderReader()
        {
            imageFormatDecoders.Add(new byte[]{ 0x42, 0x4D }, DecodeBitmap);
            imageFormatDecoders.Add(new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 }, DecodeGif);
            imageFormatDecoders.Add(new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }, DecodeGif);
            imageFormatDecoders.Add(new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, DecodePng);
            imageFormatDecoders.Add(new byte[]{ 0xff, 0xd8 }, DecodeJfif);
        }

        /// <summary>
        /// Gets the dimensions of an image.
        /// </summary>
        /// <param name="path">The path of the image to get the dimensions of.</param>
        /// <returns>The dimensions of the specified image.</returns>
        /// <exception cref="ArgumentException">The image was of an unrecognised format.</exception>
        public static Size GetDimensions(string path)
        {
            try
            {
                using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(path)))
                {
                    return GetDimensions(binaryReader);
                }
            }
            catch
            {
                //do it the old fashioned way
                using (Bitmap b = new Bitmap(path))
                {
                    return b.Size;
                }
            }
        }

        /// <summary>        
        /// Gets the dimensions of an image.
        /// </summary>
        /// <param name="path">The path of the image to get the dimensions of.</param>
        /// <returns>The dimensions of the specified image.</returns>
        /// <exception cref="ArgumentException">The image was of an unrecognised format.</exception>
        public static Size GetDimensions(BinaryReader binaryReader)
        {
            int maxMagicBytesLength = 0;

            foreach (byte[] bytes in imageFormatDecoders.Keys)
                if (bytes.Length > maxMagicBytesLength)
                    maxMagicBytesLength = bytes.Length;

            byte[] magicBytes = new byte[maxMagicBytesLength];
            
            for (int i = 0; i < maxMagicBytesLength; i += 1)
            {
                magicBytes[i] = binaryReader.ReadByte();
                foreach (KeyValuePair<byte[], Func> kvPair in imageFormatDecoders)
                    if (StartsWith(magicBytes, kvPair.Key))
                        return kvPair.Value(binaryReader);
            }

            throw new ArgumentException();
        }

        private static bool StartsWith(byte[] thisBytes, byte[] thatBytes)
        {
            for (int i = 0; i < thatBytes.Length; i += 1)
            {
                if (thisBytes[i] != thatBytes[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static short ReadLittleEndianInt16(BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(short)];

            for (int i = 0; i < sizeof(short); i += 1)
            {
                bytes[sizeof(short) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToInt16(bytes, 0);
        }

        private static ushort ReadLittleEndianUInt16(BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(ushort)];

            for (int i = 0; i < sizeof(ushort); i += 1)
            {
                bytes[sizeof(ushort) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToUInt16(bytes, 0);
        }

        private static int ReadLittleEndianInt32(BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(int)];
            for (int i = 0; i < sizeof(int); i += 1)
            {
                bytes[sizeof(int) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToInt32(bytes, 0);
        }

        private static Size DecodeBitmap(BinaryReader binaryReader)
        {
            binaryReader.ReadBytes(16);
            int width = binaryReader.ReadInt32();
            int height = binaryReader.ReadInt32();
            return new Size(width, height);
        }

        private static Size DecodeGif(BinaryReader binaryReader)
        {
            int width = binaryReader.ReadInt16();
            int height = binaryReader.ReadInt16();
            return new Size(width, height);
        }

        private static Size DecodePng(BinaryReader binaryReader)
        {
            binaryReader.ReadBytes(8);
            int width = ReadLittleEndianInt32(binaryReader);
            int height = ReadLittleEndianInt32(binaryReader);
            return new Size(width, height);
        }

        private static Size DecodeJfif(BinaryReader binaryReader)
        {
            while (binaryReader.ReadByte() == 0xff)
            {
                byte marker = binaryReader.ReadByte();
                short chunkLength = ReadLittleEndianInt16(binaryReader);
                if (marker == 0xc0)
                {
                    binaryReader.ReadByte();
                    int height = ReadLittleEndianInt16(binaryReader);
                    int width = ReadLittleEndianInt16(binaryReader);
                    return new Size(width, height);
                }

                if (chunkLength < 0)
                {
                    ushort uchunkLength = (ushort)chunkLength;
                    binaryReader.ReadBytes(uchunkLength - 2);
                }
                else
                {
                    binaryReader.ReadBytes(chunkLength - 2);
                }
            }
            throw new ArgumentException();
        }
    }
}