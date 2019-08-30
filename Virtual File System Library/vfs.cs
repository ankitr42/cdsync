using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Virtual_File_System_Library
{
    public struct VFSEntry
    {
        // General file properties
        public Int32 parentDir;
        public String name;
        public UInt64 size;
        public Boolean isDir;
        public byte[] fileIcon;
        public UInt32 entryNo;
        public DateTime created;
        public DateTime accessed;
        public DateTime modified;
        
        // Music properties
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
        
        // Document properties
        public String owner;
        public String author;
        public String title;
        public String subject;
        public String category;
        public UInt16 pages;
        public String comments;
        public String copyright;
        
        // File attributes
        public Boolean isROnly;
        public Boolean isArch;
        public Boolean isHidden;
        public Boolean isSystem;
        public Boolean isCompressed;
        public Boolean isEncrypted;
        
        // Program information
        public String company;
        public String description;
        public UInt32 majorV;
        public UInt32 minorV;
        public UInt32 revision;
        public String productName;
        public UInt32 majorPV;
        public UInt32 minorPV;
        public UInt32 pRevision;
    }

    public struct VFSSearchTerm
    {
        public List<UInt32> parentDirEntries;
        public VFSEntry entry;
        public UInt64 minSize, maxSize;
        public DateTime bCreatedDate, eCreatedDate;
        public DateTime bAccessedDate, eAccessedDate;
        public DateTime bModifiedDate, eModifiedDate;
        //public string description;
        //public ushort majorV, minorV, revision;
        public UInt32 minBitRate, maxBitRate;
        public UInt32 minSampleRate, maxSampleRate;
        public UInt16 minHeight, maxHeight;
        public UInt16 minWidth, maxWidth;
    }

    public struct VFSSearchOptions
    {
        public bool matchAttributes;
        public bool searchOnlyForDirectories;
        public bool searchOnlyForFiles;
        public bool matchDescription, matchDescriptionSubstring;
        public bool matchArtist, matchArtistSubstring;
        public bool matchAlbum, matchAlbumSubstring;
        public bool matchGenre, matchGenreSubstring;
        public bool matchAuthor, matchAuthorSubstring;
        public bool matchTitle, matchTitleSubstring;
        public bool matchSubject, matchSubjectSubstring;
        public bool matchCategory, matchCategorySubstring;
        public bool matchComments, matchCommentsSubstring;
        public bool matchCompany, matchCompanySubstring;

        public bool sizeLBound, sizeUBound, sizeRange, sizeExact;
        public bool cDateLBound, cDateUBound, cDateRange, cDateExact;
        public bool aDateLBound, aDateUBound, aDateRange, aDateExact;
        public bool mDateLBound, mDateUBound, mDateRange, mDateExact;
        //public bool durationLBound, durationUBound, durationRange, durationExact;
        public bool bitRateLBound, bitRateUBound, bitRateRange, bitRateExact;
        public bool sampleRateLBound, sampleRateUBound, sampleRateRange, sampleRateExact;
        //public bool dimensionsLBound, dimensionsUBound, dimensionsRange, dimensionsExact;
    }

    public struct VFSSearchResult
    {
        public VFSEntry entry;
        public string fullPath;
        public object userData;

        public VFSSearchResult(VFSEntry entry, string fullPath, object userData)
        {
            this.entry = entry;
            this.fullPath = fullPath;
            this.userData = userData;
        }
    }

    public delegate void VFSEntryProcessorDelegate(VFSEntry entry);

    public delegate bool SearchResultProcessorDelegate(VFSSearchResult result);

    public class VFS
    {
        private OleDbConnection dbConnection;
        private OleDbCommand dbCommand;
        private OleDbDataReader dbReader;
        private object synchronization;
        
        /// <summary>
        /// Initializes a new instance of Virutual File System.
        /// </summary>
        public VFS()
        {
            dbConnection = new OleDbConnection();
            
            dbCommand = new OleDbCommand();
            dbCommand.Connection = dbConnection;

            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());
            dbCommand.Parameters.Add(new OleDbParameter());

            synchronization = new object();
        }

        /// <summary>
        /// Initializes a new instance of the Virtual File System with the specified cache size.
        /// </summary>
        /// <param name="cacheSize">The number of entries that the cache will hold. Must be between 0 and 4097</param>
        //public VFS(int cacheSize)
        //{
        //    if (cacheSize < 1 || cacheSize > 4096)
        //        throw new ArgumentException("Invalid cache size.");

        //    dbConnection = new OleDbConnection();

        //    dbCommand = new OleDbCommand();
        //    dbCommand.Connection = dbConnection;
        //    dbCommand.Parameters.Add(new OleDbParameter());
        //    entryCache = new List<VFSEntry>(cacheSize);
        //}
        public void OpenConnection(string dbPath)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + dbPath +
                    "; Jet OLEDB:Database Password=SSBBbSBUaGUgT25l;";
                dbConnection.Open();
            }
            else
                throw (new InvalidOperationException("A connection is already open."));
        }

        public void CloseConnection(bool waitTillClosed)
        {
            if (dbConnection.State != ConnectionState.Closed)
                dbConnection.Close();
            if (waitTillClosed)
                while (dbConnection.State != ConnectionState.Closed)
                    Thread.Sleep(10);
        }

        public int AddEntry(VFSEntry entry)
        {
            int rowsAffected = 0;
            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            lock (synchronization)
            {
                dbCommand.CommandText = "INSERT INTO DirectoryTree VALUES(" + entry.parentDir.ToString() + ", ?, "
                    + entry.size.ToString() + ", " + entry.isDir.ToString() + ", ?, " + entry.entryNo.ToString() + ", \""
                    + entry.created.ToString() + "\", \"" + entry.accessed.ToString() + "\", \"" + entry.modified.ToString()
                    + "\", ?, ?, " + entry.albumYear.ToString() + ", " + entry.trackNo.ToString() + ", "
                    + entry.trackDurtion.ToString() + ", ?, " + entry.bitRate.ToString() + ", " + entry.frameRate.ToString()
                    + ", " + entry.sampleRate.ToString() + ", " + entry.height.ToString() + ", " + entry.width.ToString()
                    + ", ?, ?, ?, ?, ?, " + entry.pages.ToString() + ", ?, ?, " + entry.isROnly.ToString() + ", "
                    + entry.isArch.ToString() + ", " + entry.isHidden.ToString() + ", " + entry.isSystem.ToString() + ", "
                    + entry.isCompressed.ToString() + ", " + entry.isEncrypted.ToString() + ", ?, ?, " + entry.majorV.ToString()
                    + ", " + entry.minorV.ToString() + ", " + entry.revision.ToString() + ", ?, " + entry.majorPV.ToString()
                    + ", " + entry.minorPV.ToString() + ", " + entry.pRevision.ToString() + ");";

                dbCommand.Parameters[1].OleDbType = OleDbType.VarBinary;
                dbCommand.Parameters[0].Value = entry.name;
                dbCommand.Parameters[1].Value = (entry.fileIcon == null) ? (object)DBNull.Value : entry.fileIcon;
                dbCommand.Parameters[2].Value = (entry.artist == null) ? "" : entry.artist;
                dbCommand.Parameters[3].Value = (entry.album == null) ? "" : entry.album;
                dbCommand.Parameters[4].Value = (entry.genre == null) ? "" : entry.genre;
                dbCommand.Parameters[5].Value = (entry.owner == null) ? "" : entry.owner;
                dbCommand.Parameters[6].Value = (entry.author == null) ? "" : entry.author;
                dbCommand.Parameters[7].Value = (entry.title == null) ? "" : entry.title;
                dbCommand.Parameters[8].Value = (entry.subject == null) ? "" : entry.subject;
                dbCommand.Parameters[9].Value = (entry.category == null) ? "" : entry.category;
                dbCommand.Parameters[10].Value = (entry.comments == null) ? "" : entry.comments;
                dbCommand.Parameters[11].Value = (entry.copyright == null) ? "" : entry.copyright;
                dbCommand.Parameters[12].Value = (entry.company == null) ? "" : entry.company;
                dbCommand.Parameters[13].Value = (entry.description == null) ? "" : entry.description;
                dbCommand.Parameters[14].Value = (entry.productName == null) ? "" : entry.productName;
                rowsAffected = dbCommand.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public int DeleteEntry(UInt32 entryNo, bool cascadeDelete)
        {
            Queue<UInt32> entriesToDelete = new Queue<uint>();
            int rowsAffected = 0;
            uint temp;

            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            lock (synchronization)
            {
                entriesToDelete.Enqueue(entryNo);
                while (entriesToDelete.Count > 0)
                {
                    temp = entriesToDelete.Dequeue();
                    dbCommand.CommandText = "DELETE FROM DirectoryTree WHERE EntryNumber = " + temp.ToString() + ";";
                    rowsAffected += dbCommand.ExecuteNonQuery();
                    // If it's a cascade delete operation, add child directories to list before deleting.
                    if (cascadeDelete)
                    {
                        dbCommand.CommandText = "SELECT EntryNumber FROM DirectoryTree WHERE ParentDirectory = " + temp.ToString() +
                                                " AND IsDirectory = True";
                        dbReader = dbCommand.ExecuteReader();

                        while (dbReader.Read())
                            entriesToDelete.Enqueue((uint)dbReader.GetInt32(0));
                        dbReader.Close();
                    }
                    // Delete child entries.
                    dbCommand.CommandText = "DELETE FROM DirectoryTree WHERE ParentDirectory = " + temp.ToString() + ";";
                    rowsAffected += dbCommand.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public VFSEntry ReadEntry(UInt32 entryNo)
        {
            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            VFSEntry tempEntry;

            lock (synchronization)
            {
                try
                {
                    dbCommand.CommandText = "SELECT * FROM DirectoryTree WHERE EntryNumber=" + entryNo.ToString();
                    dbReader = dbCommand.ExecuteReader();
                    dbReader.Read();

                    tempEntry = TranslateDbReader(ref dbReader);
                }
                finally
                {
                    dbReader.Close();
                }
            }

            return tempEntry;
        }

        public int GetTotalEntries()
        {
            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            int rowCount = 0;
            lock (synchronization)
            {
                dbCommand.CommandText = "SELECT Count(*) FROM DirectoryTree;";

                dbReader = dbCommand.ExecuteReader();
                dbReader.Read();

                rowCount = dbReader.GetInt32(0);

                dbReader.Close();
            }
            return rowCount;
        }

        public int GetTotalEntries(string whereClause)
        {
            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            int rowCount = 0;
            lock (synchronization)
            {
                dbCommand.CommandText = "SELECT Count(*) FROM DirectoryTree WHERE " + whereClause + ";";

                dbReader = dbCommand.ExecuteReader();
                dbReader.Read();

                rowCount = dbReader.GetInt32(0);

                dbReader.Close();
            }
            return rowCount;
        }

        public int ReadSubEntries(UInt32 parent, VFSEntryProcessorDelegate VFSEntryProcessor)
        {
            if (VFSEntryProcessor == null)
                throw new ArgumentNullException("VFSEntryProcessor cannot be null.");

            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            int rowCount = 0;

            lock (synchronization)
            {
                try
                {
                    dbCommand.CommandText = "SELECT * FROM DirectoryTree WHERE ParentDirectory=" + parent.ToString();
                    dbReader = dbCommand.ExecuteReader();

                    while (dbReader.Read())
                    {
                        VFSEntryProcessor(TranslateDbReader(ref dbReader));
                        rowCount++;
                    }
                }
                finally
                {
                    dbReader.Close();
                }
            }
            return rowCount;
        }

        public int UpdateEntry(UInt32 entryNo, VFSEntry newEntry)
        {
            int rowsAffected = 0;
            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            lock (synchronization)
            {
                dbCommand.CommandText = "UPDATE DirectoryTree SET ParentDirectory=" + newEntry.parentDir.ToString() + ", Name=?, ItemSize=" + newEntry.size.ToString()
                    + ", IsDirectory=" + newEntry.isDir.ToString() + ", FileIcon=?, EntryNumber=" + newEntry.entryNo.ToString() + ", CreatedDate=\""
                    + newEntry.created.ToString() + "\", LastAccessedDate=\"" + newEntry.accessed.ToString() + "\", LastModifiedDate=\"" + newEntry.modified.ToString()
                    + "\", Artist=?, Album=?, AlbumYear=" + newEntry.albumYear.ToString() + ", TrackNo=" + newEntry.trackNo.ToString() + ", Duration="
                    + newEntry.trackDurtion.ToString() + ", Genre=?, BitRate=" + newEntry.bitRate.ToString() + ", FrameRate=" + newEntry.frameRate.ToString()
                    + ", SampleRate=" + newEntry.sampleRate.ToString() + ", Height=" + newEntry.height.ToString() + ", Width=" + newEntry.width.ToString()
                    + ", Owner=?, Author=?, Title=?, Subject=?, Category=?, Pages=" + newEntry.pages.ToString() + ", Comments=?, Copyright=?, IsReadOnly="
                    + newEntry.isROnly.ToString() + ", IsArchive=" + newEntry.isArch.ToString() + ", IsHidden=" + newEntry.isHidden.ToString() + ", IsSystem="
                    + newEntry.isSystem.ToString() + ", IsCompressed=" + newEntry.isCompressed.ToString() + ", IsEncrypted=" + newEntry.isEncrypted.ToString()
                    + ", Company=?, Description=?, MajorVersion=" + newEntry.majorV.ToString() + ", MinorVersion=" + newEntry.minorV.ToString() + ", Revision="
                    + newEntry.revision.ToString() + ", ProductName=?, MajorPVersion=" + newEntry.majorPV.ToString() + ", MinorPVersion=" + newEntry.minorPV.ToString()
                    + ", PRevision=" + newEntry.pRevision.ToString() + " WHERE EntryNumber=" + entryNo.ToString() + ";";

                dbCommand.Parameters[1].OleDbType = OleDbType.VarBinary;
                dbCommand.Parameters[0].Value = newEntry.name;
                dbCommand.Parameters[1].Value = (newEntry.fileIcon == null) ? (object)DBNull.Value : newEntry.fileIcon;
                dbCommand.Parameters[2].Value = (newEntry.artist == null) ? "" : newEntry.artist;
                dbCommand.Parameters[3].Value = (newEntry.album == null) ? "" : newEntry.album;
                dbCommand.Parameters[4].Value = (newEntry.genre == null) ? "" : newEntry.genre;
                dbCommand.Parameters[5].Value = (newEntry.owner == null) ? "" : newEntry.owner;
                dbCommand.Parameters[6].Value = (newEntry.author == null) ? "" : newEntry.author;
                dbCommand.Parameters[7].Value = (newEntry.title == null) ? "" : newEntry.title;
                dbCommand.Parameters[8].Value = (newEntry.subject == null) ? "" : newEntry.subject;
                dbCommand.Parameters[9].Value = (newEntry.category == null) ? "" : newEntry.category;
                dbCommand.Parameters[10].Value = (newEntry.comments == null) ? "" : newEntry.comments;
                dbCommand.Parameters[11].Value = (newEntry.copyright == null) ? "" : newEntry.copyright;
                dbCommand.Parameters[12].Value = (newEntry.company == null) ? "" : newEntry.company;
                dbCommand.Parameters[13].Value = (newEntry.description == null) ? "" : newEntry.description;
                dbCommand.Parameters[14].Value = (newEntry.productName == null) ? "" : newEntry.productName;
                rowsAffected = dbCommand.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public int SearchVFS(VFSSearchTerm sTerm, VFSSearchOptions options, SearchResultProcessorDelegate SearchResultProcessor, object userData)
        {
            OleDbCommand searchCommand = new OleDbCommand();
            OleDbDataReader searchResultReader = null;
            VFSEntry entry = sTerm.entry;
            List<UInt32> parentEntries = sTerm.parentDirEntries;
            int rowCount = 0, parentDir = -1;
            string path = "";

            if (SearchResultProcessor == null)
                throw new ArgumentNullException("SearchResultProcessor cannot be null.");

            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            lock (synchronization)
            {
                searchCommand.Connection = dbConnection;

                searchCommand.CommandText = "SELECT * FROM DirectoryTree WHERE EntryNumber > 0 AND Name LIKE \"" + PrepareStringForQuery(entry.name, true) + "\"";

                #region
                if (options.sizeLBound)
                    searchCommand.CommandText += " AND ItemSize > " + sTerm.minSize;
                else if (options.sizeUBound)
                    searchCommand.CommandText += " AND ItemSize < " + sTerm.maxSize;
                else if (options.sizeRange)
                    searchCommand.CommandText += " AND ItemSize BETWEEN " + sTerm.minSize.ToString() + " AND " +
                        sTerm.maxSize.ToString();
                else if (options.sizeExact)
                    searchCommand.CommandText += " AND ItemSize=" + sTerm.minSize.ToString();
                #endregion

                #region
                if (options.matchAttributes)
                {
                    if (entry.isArch)
                        searchCommand.CommandText += " AND IsArchive=TRUE";
                    if (entry.isHidden)
                        searchCommand.CommandText += " AND IsHidden=TRUE";
                    if (entry.isROnly)
                        searchCommand.CommandText += " AND IsReadOnly=TRUE";
                    if (entry.isSystem)
                        searchCommand.CommandText += " AND IsSystem=TRUE";
                    if (entry.isEncrypted)
                        searchCommand.CommandText += " AND IsEncrypted=TRUE";
                    if (entry.isCompressed)
                        searchCommand.CommandText += " AND IsCompressed=TRUE";
                }
                if (options.searchOnlyForDirectories)
                    searchCommand.CommandText += " AND IsDirectory=True";
                else if (options.searchOnlyForFiles)
                    searchCommand.CommandText += " AND IsDirectory=False";
                #endregion

                #region
                if (options.cDateLBound)
                    searchCommand.CommandText += " AND CreatedDate > " + sTerm.bCreatedDate.ToString();
                else if (options.cDateUBound)
                    searchCommand.CommandText += " AND CreatedDate < " + sTerm.eCreatedDate.ToString();
                else if (options.cDateRange)
                    searchCommand.CommandText += " AND CreatedDate BETWEEN " + sTerm.bCreatedDate.ToString() +
                        " AND " + sTerm.eCreatedDate.ToString();
                else if (options.cDateExact)
                    searchCommand.CommandText += " AND CreatedDate=" + sTerm.bCreatedDate.ToString();
                #endregion

                #region
                if (options.aDateLBound)
                    searchCommand.CommandText += " AND LastAccessedDate > " + sTerm.bAccessedDate.ToString();
                else if (options.aDateUBound)
                    searchCommand.CommandText += " AND LastAccessedDate < " + sTerm.eAccessedDate.ToString();
                else if (options.aDateRange)
                    searchCommand.CommandText += " AND LastAccessedDate BETWEEN " + sTerm.bAccessedDate.ToString() +
                        " AND " + sTerm.eAccessedDate.ToString();
                else if (options.aDateExact)
                    searchCommand.CommandText += " AND LastAccessedDate=" + sTerm.bAccessedDate.ToString();
                #endregion

                #region
                if (options.mDateLBound)
                    searchCommand.CommandText += " AND LastModifiedDate > " + sTerm.bModifiedDate.ToString();
                else if (options.mDateUBound)
                    searchCommand.CommandText += " AND LastModifiedDate < " + sTerm.eModifiedDate.ToString();
                else if (options.mDateRange)
                    searchCommand.CommandText += " AND LastModifiedDate BETWEEN " + sTerm.bModifiedDate.ToString() +
                        " AND " + sTerm.eModifiedDate.ToString();
                else if (options.mDateExact)
                    searchCommand.CommandText += " AND LastModifiedDate=" + sTerm.bModifiedDate.ToString();
                #endregion

                if (options.matchArtist)
                    searchCommand.CommandText += " AND Artist LIKE \"" + (options.matchArtistSubstring ? "%" : "") +
                        PrepareStringForQuery(entry.artist, false) + (options.matchArtistSubstring ? "%" : "") + "\"";

                if (options.matchAlbum)
                    searchCommand.CommandText += " AND Album LIKE \"" + (options.matchAlbumSubstring ? "%" : "") +
                        PrepareStringForQuery(entry.album, false) + (options.matchAlbumSubstring ? "%" : "") + "\"";

                if (options.matchGenre)
                    searchCommand.CommandText += " AND Genre LIKE \"" + (options.matchGenreSubstring ? "%" : "") +
                        PrepareStringForQuery(entry.genre, false) + (options.matchGenreSubstring ? "%" : "") + "\"";

                if (options.matchDescription)
                    searchCommand.CommandText += " AND Description LIKE \"" + (options.matchDescriptionSubstring ? "%" : "") +
                        PrepareStringForQuery(entry.description, false) + (options.matchDescriptionSubstring ? "%" : "") + "\"";

                if (options.matchAuthor)
                    searchCommand.CommandText += " AND Author LIKE \"" + (options.matchAuthorSubstring ? "%" : "") +
                        PrepareStringForQuery(entry.author, false) + (options.matchAuthorSubstring ? "%" : "") + "\"";

                if (options.matchTitle)
                    searchCommand.CommandText += " AND Title LIKE \"" + (options.matchTitleSubstring ? "%" : "") +
                        PrepareStringForQuery(entry.title, false) + (options.matchTitleSubstring ? "%" : "") + "\"";

                if (options.matchSubject)
                    searchCommand.CommandText += " AND Subject LIKE \"" + (options.matchSubjectSubstring ? "%" : "") +
                        PrepareStringForQuery(entry.subject, false) + (options.matchSubjectSubstring ? "%" : "") + "\"";

                if (options.matchCategory)
                    searchCommand.CommandText += " AND Category LIKE \"" + (options.matchCategorySubstring ? "%" : "") +
                        PrepareStringForQuery(entry.category, false) + (options.matchCategorySubstring ? "%" : "") + "\"";

                if (options.matchComments)
                    searchCommand.CommandText += " AND Comments LIKE \"" + (options.matchCommentsSubstring ? "%" : "") +
                        PrepareStringForQuery(entry.comments, false) + (options.matchCommentsSubstring ? "%" : "") + "\"";

                if (options.matchCompany)
                    searchCommand.CommandText += " AND Company LIKE \"" + (options.matchCompanySubstring ? "%" : "") +
                        PrepareStringForQuery(entry.company, false) + (options.matchCompanySubstring ? "%" : "") + "\"";

                if (options.bitRateLBound)
                    searchCommand.CommandText += " AND BitRate > " + sTerm.minBitRate.ToString();
                else if (options.bitRateUBound)
                    searchCommand.CommandText += " AND BitRate < " + sTerm.maxBitRate.ToString();
                else if (options.bitRateRange)
                    searchCommand.CommandText += " AND BitRate BETWEEN " + sTerm.minBitRate.ToString() + " AND " +
                        sTerm.maxBitRate.ToString();
                else if (options.bitRateExact)
                    searchCommand.CommandText += " AND BitRate = " + sTerm.minBitRate.ToString();

                if (options.sampleRateLBound)
                    searchCommand.CommandText += " AND SampleRate > " + sTerm.minSampleRate.ToString();
                else if (options.sampleRateUBound)
                    searchCommand.CommandText += " AND SampleRate < " + sTerm.maxSampleRate.ToString();
                else if (options.sampleRateRange)
                    searchCommand.CommandText += " AND SampleRate BETWEEN " + sTerm.minSampleRate.ToString() + " AND " +
                        sTerm.maxSampleRate.ToString();
                else if (options.sampleRateExact)
                    searchCommand.CommandText += " AND SampleRate = " + sTerm.minSampleRate.ToString();

                searchCommand.CommandText += ";";

                try
                {
                    searchResultReader = searchCommand.ExecuteReader();
                    while (searchResultReader.Read())
                    {
                        rowCount++;
                        VFSEntry temp = TranslateDbReader(ref searchResultReader);
                        if (temp.parentDir != parentDir)
                        {
                            parentDir = temp.parentDir;
                            path = GetPathFromList(TracePathToEntry((uint)temp.parentDir));
                        }
                        if (!SearchResultProcessor(new VFSSearchResult(temp, path, userData)))
                            break;
                    }
                }
                finally
                {
                    searchResultReader.Close();
                }
            }
            return rowCount;
        }

        private VFSEntry TranslateDbReader(ref OleDbDataReader dbReader)
        {
            VFSEntry tempEntry;
            Object tempIcon;

            tempEntry.parentDir = (int)dbReader.GetValue(0);
            tempEntry.name = (string)dbReader.GetValue(1);
            tempEntry.size = (UInt64)((Double)dbReader.GetValue(2));
            tempEntry.isDir = (bool)dbReader.GetValue(3);
            
            tempIcon = dbReader.GetValue(4);
            if (tempIcon == DBNull.Value)
                tempEntry.fileIcon = null;
            else
                tempEntry.fileIcon = (byte[])tempIcon;

            tempEntry.entryNo = (uint)(int)dbReader.GetValue(5);
            tempEntry.created = (DateTime)dbReader.GetValue(6);
            tempEntry.accessed = (DateTime)dbReader.GetValue(7);
            tempEntry.modified = (DateTime)dbReader.GetValue(8);
            tempEntry.artist = (string)dbReader.GetValue(9);
            tempEntry.album = (string)dbReader.GetValue(10);
            tempEntry.albumYear = (UInt16)(Int16)dbReader.GetValue(11);
            tempEntry.trackNo = (UInt16)(Int16)dbReader.GetValue(12);
            tempEntry.trackDurtion = (uint)(int)dbReader.GetValue(13);
            tempEntry.genre = (string)dbReader.GetValue(14);
            tempEntry.bitRate = (uint)(int)dbReader.GetValue(15);
            tempEntry.frameRate = (UInt16)(Int16)dbReader.GetValue(16);
            tempEntry.sampleRate = (uint)(int)dbReader.GetValue(17);
            tempEntry.height = (UInt16)(Int16)dbReader.GetValue(18);
            tempEntry.width = (UInt16)(Int16)dbReader.GetValue(19);
            tempEntry.owner = (string)dbReader.GetValue(20);
            tempEntry.author = (string)dbReader.GetValue(21);
            tempEntry.title = (string)dbReader.GetValue(22);
            tempEntry.subject = (string)dbReader.GetValue(23);
            tempEntry.category = (string)dbReader.GetValue(24);
            tempEntry.pages = (UInt16)(Int16)dbReader.GetValue(25);
            tempEntry.comments = (string)dbReader.GetValue(26);
            tempEntry.copyright = (string)dbReader.GetValue(27);
            tempEntry.isROnly = (bool)dbReader.GetValue(28);
            tempEntry.isArch = (bool)dbReader.GetValue(29);
            tempEntry.isHidden = (bool)dbReader.GetValue(30);
            tempEntry.isSystem = (bool)dbReader.GetValue(31);
            tempEntry.isCompressed = (bool)dbReader.GetValue(32);
            tempEntry.isEncrypted = (bool)dbReader.GetValue(33);
            tempEntry.company = (string)dbReader.GetValue(34);
            tempEntry.description = (string)dbReader.GetValue(35);
            tempEntry.majorV = (uint)(int)dbReader.GetValue(36);
            tempEntry.minorV = (uint)(int)dbReader.GetValue(37);
            tempEntry.revision = (uint)(int)dbReader.GetValue(38);
            tempEntry.productName = (string)dbReader.GetValue(39);
            tempEntry.majorPV = (uint)(int)dbReader.GetValue(40);
            tempEntry.minorPV = (uint)(int)dbReader.GetValue(41);
            tempEntry.pRevision = (uint)(int)dbReader.GetValue(42);

            return tempEntry;
        }

        /// <summary>
        /// Adds the escape character '\' to the string wherever " occurs unescaped.
        /// </summary>
        /// <param name="strToEscape">The string to be interspered with the escape character.</param>
        /// <returns>The modified string.</returns>
        private string PrepareStringForQuery(string strToPrepare, bool isFileName)
        {
            char[] arr = strToPrepare.ToCharArray();
            string newStr = "";

            if (isFileName)
            {
                foreach (char ch in arr)
                {
                    if (ch == '/' || ch == '\\' || ch == ':' || ch == '"' || ch == '<' || ch == '>' || ch == '|')
                        continue;
                    else if (ch == '*')
                    {
                        newStr += "%";
                        continue;
                    }
                    else if (ch == '?')
                    {
                        newStr += "_";
                        continue;
                    }
                    else if (ch == '_' || ch == '%' || ch == '#' || ch == '[')
                    {
                        newStr += "[" + ch.ToString() + "]";
                        continue;
                    }

                    newStr += ch.ToString();
                }
            }
            else
            {
                foreach (char ch in arr)
                {
                    if (ch == '_' || ch == '%' || ch == '#' || ch == '[')
                    {
                        newStr += "[" + ch.ToString() + "]";
                        continue;
                    }
                    newStr += ch.ToString();
                }
            }
            return newStr;
        }

        public ConnectionState GetDbState()
        {
            return dbConnection.State;
        }

        //public List<UInt32> GetSubEntryIDs(UInt32 startEntryNumber)
        //{
        //    List<UInt32> temp = new List<uint>();

        //    dbCommand.CommandText = "SELECT EntryNumber FROM DirectoryTree WHERE ParentDirectory=" + startEntryNumber.ToString() + ";";
        //    dbReader = dbCommand.ExecuteReader();

        //    while (dbReader.Read())
        //        temp.Add((UInt32)dbReader.GetInt32(0));

        //    return temp;
        //}

        /// <summary>
        /// Generates a list of entry numbers describing the full path from the root to the specified entry.
        /// </summary>
        /// <param name="entryNo">The entry number of the entry whose path is to be traced.</param>
        /// <returns>A list of entry numbers describing the fully qualified path of the argument entry.</returns>
        public List<UInt32> TracePathToEntry(UInt32 entryNo)
        {
            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            VFSEntry tempEntry = ReadEntry(entryNo);
            List<UInt32> path = new List<UInt32>();

            while (tempEntry.parentDir != -1)
            {
                path.Add(tempEntry.entryNo);
                tempEntry = ReadEntry((UInt32)tempEntry.parentDir);
            }
            path.Add(tempEntry.entryNo);
            path.Reverse();

            return path;
        }

        /// <summary>
        /// Returns a list of strings which reflects the path heirarchy represented by the pathIDs parameter.
        /// </summary>
        /// <param name="pathIds">A list of integers.</param>
        /// <returns>A list of strings where each string represents the name of a path component.</returns>
        public List<string> GetPathComponentStrings(List<UInt32> pathIDs)
        {
            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            List<string> path = new List<string>();

            foreach (UInt32 pathID in pathIDs)
                path.Add(ReadEntry(pathID).name);
            
            return path;
        }

        public string GetPathFromList(List<UInt32> pathIDs)
        {
            if (dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("The connection is not open.");

            string path;

            path = "";
            foreach (UInt32 pathID in pathIDs)
                path += ReadEntry(pathID).name + "\\";

            return path;
        }
    }
}