using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Customized_Controls
{
    public partial class CustomPreviewControl : UserControl
    {
        private Label lblTextBanner;
        private PictureBox pBox;
        private AudioPlayer audPlayer;
        private VideoPlayer vidPlayer;
        private PreviewMode curPreviewMode;
        private string generatingPreviewNotice;
        private string previewErrorNotice;
        private string invalidFileTypeNotice;
        private string fileNotFoundNotice;

        public CustomPreviewControl()
        {
            //■ ►
            InitializeComponent();
            //
            // pBox
            //
            pBox = new PictureBox();
            pBox.SizeMode = PictureBoxSizeMode.Zoom;
            pBox.Dock = DockStyle.Fill;

            //
            // lblTextBanner
            //
            lblTextBanner = new Label();
            lblTextBanner.AutoSize = false;
            lblTextBanner.AutoEllipsis = false;
            lblTextBanner.Dock = DockStyle.Fill;
            lblTextBanner.TextAlign = ContentAlignment.MiddleCenter;

            //
            // vidPlayer
            //
            vidPlayer = new VideoPlayer();

            //
            // audPlayer
            //
            audPlayer = new AudioPlayer();
        }

        public PreviewMode CurrentPreviewMode
        {
            get
            {
                return curPreviewMode;
            }
        }

        public string GeneratingPreviewNotice
        {
            get
            {
                return generatingPreviewNotice;
            }
            set
            {
                generatingPreviewNotice = value;
            }
        }

        public string PreviewErrorNotice
        {
            get
            {
                return previewErrorNotice;
            }
            set
            {
                previewErrorNotice = value;
            }
        }

        public string InvalidFileTypeNotice
        {
            get
            {
                return invalidFileTypeNotice;
            }
            set
            {
                invalidFileTypeNotice = value;
            }
        }

        public string FileNotFoundNotice
        {
            get
            {
                return fileNotFoundNotice;
            }
            set
            {
                fileNotFoundNotice = value;
            }
        }

        public void Preview(string filePath, bool previewAsText, bool autoPlayV, bool autoPlayA)
        {
            string extension;
            if (!previewAsText)
                if (generatingPreviewNotice.Length > 0)
                    Preview(generatingPreviewNotice, true, false, false);

            if (!previewAsText)
                if (!File.Exists(filePath))
                {
                    filePath = fileNotFoundNotice;
                    previewAsText = true;
                }

            if (curPreviewMode == PreviewMode.Video)
            {
                vidPlayer.CloseVideo();
                vidPlayer.Parent = null;
            }
            if (curPreviewMode == PreviewMode.Audio)
            {
                audPlayer.CloseAudio();
                audPlayer.Parent = null;
            }
            if (curPreviewMode == PreviewMode.Image)
            {
                pBox.Image = null;
            }

            if (previewAsText)
            {
                if (curPreviewMode != PreviewMode.Text)
                {
                    this.Controls.Clear();
                    this.Controls.Add(lblTextBanner);
                    curPreviewMode = PreviewMode.Text;
                }
                lblTextBanner.Text = filePath;
            }
            else
            {
                try
                {
                    extension = Path.GetExtension(filePath);
                    if (IsFileTypeImage(extension))
                    {
                        pBox.Image = Image.FromFile(filePath);
                        if (curPreviewMode != PreviewMode.Image)
                        {
                            this.Controls.Clear();
                            this.Controls.Add(pBox);
                        }
                        curPreviewMode = PreviewMode.Image;
                    }
                    else if (IsFileTypeAudio(extension))
                    {
                        audPlayer.OpenAudio(filePath, autoPlayA);
                        if (curPreviewMode != PreviewMode.Audio)
                            this.Controls.Clear();
                        audPlayer.Parent = this;
                        audPlayer.Dock = DockStyle.Fill;

                        curPreviewMode = PreviewMode.Audio;
                    }
                    else if (IsFileTypeVideo(extension))
                    {
                        vidPlayer.OpenVideo(filePath, autoPlayV);
                        if (curPreviewMode != PreviewMode.Video)
                            this.Controls.Clear();
                        vidPlayer.Parent = this;
                        vidPlayer.Dock = DockStyle.Fill;

                        curPreviewMode = PreviewMode.Video;
                    }
                    else
                        Preview(invalidFileTypeNotice, true, false, false);
                }
                catch
                {
                    Preview(previewErrorNotice, true, false, false);
                }
            }
            this.Refresh();
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
                filePath == ".mov" || filePath == ".flv")
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
    }

    //public class ParentResizeRequestedEventArgs : EventArgs
    //{
    //    private int clientAreaWidth;
    //    private int clientAreaHeight;

    //    public ParentResizeRequestedEventArgs(int clientWidth, int clientHeight)
    //    {
    //        clientAreaWidth = clientWidth;
    //        clientAreaHeight = clientHeight;
    //    }

    //    public int ClientAreaWidth
    //    {
    //        get { return clientAreaWidth; }
    //        set { clientAreaWidth = value; }
    //    }

    //    public int ClientAreaHeight
    //    {
    //        get { return clientAreaHeight; }
    //        set { clientAreaHeight = value; }
    //    }
    //}

    public enum PreviewMode
    {
        None=0, Text, Image, Video, Audio
    };
}