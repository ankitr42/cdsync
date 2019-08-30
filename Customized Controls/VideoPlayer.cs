using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Customized_Controls
{
    // 4;<78
    public partial class VideoPlayer : UserControl
    {
        private bool isFileLoaded;
        private Video vidPlayer;
        private TimeSpan duration;

        public VideoPlayer()
        {
            InitializeComponent();
        }

        void vidPlayer_Ending(object sender, EventArgs e)
        {
            btnStop_Click(null, null);
            vidPlayer.Fullscreen = false;
        }

        public void OpenVideo(string filePath, bool autoPlay)
        {
            try
            {
                vidPlayer = Video.FromFile(filePath);
                vidPlayer.Owner = panelVideo;
                vidPlayer.Ending += new EventHandler(vidPlayer_Ending);
                pBarPlaybackProgress.Value = 0;
                lblCurrentPosition.Text = "00:00/00:00";
                if (vidPlayer.SeekingCaps.CanGetDuration)
                {
                    duration = new TimeSpan(0, 0, (int)vidPlayer.Duration);
                    
                    pBarPlaybackProgress.Maximum = (int)vidPlayer.Duration;
                    if (duration.Hours > 0)
                        lblCurrentPosition.Text = "00:00:00/" + duration.ToString();
                    else
                        lblCurrentPosition.Text = "00:00/" + duration.Minutes.ToString("D2") + ":" + duration.Seconds.ToString("D2");
                }
                isFileLoaded = true;
                if (autoPlay)
                    btnPlayPause_Click(null, null);
            }
            catch
            {
                vidPlayer = null;
                isFileLoaded = false;
                throw;
            }
        }

        public void CloseVideo()
        {
            if (isFileLoaded)
            {
                btnStop_Click(null, null);
                pBarPlaybackProgress.Maximum = 0;
                vidPlayer.Dispose();
                vidPlayer = null;
                isFileLoaded = false;
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (isFileLoaded)
            {
                if (!vidPlayer.Playing)
                {
                    vidPlayer.Play();
                    btnPlayPause.Text = ";";
                    tmrProgress.Enabled = true;
                }
                else
                {
                    vidPlayer.Pause();
                    btnPlayPause.Text = "4";
                    tmrProgress.Enabled = false;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)

        {
            if (isFileLoaded && !vidPlayer.Stopped)
            {
                vidPlayer.Stop();
                pBarPlaybackProgress.Value = 0;
                tmrProgress.Enabled = false;
                btnPlayPause.Text = "4";
                if (vidPlayer.SeekingCaps.CanGetDuration)
                    if (duration.Hours > 0)
                        lblCurrentPosition.Text = "00:00:00/" + duration.ToString();
                    else
                        lblCurrentPosition.Text = "00:00/" + duration.Minutes.ToString("D2") + 
                            ":" + duration.Seconds.ToString("D2");
            }
        }

        private void btnPlayPause_MouseEnter(object sender, EventArgs e)
        {
            btnPlayPause.ForeColor = Color.IndianRed;
        }

        private void btnPlayPause_MouseLeave(object sender, EventArgs e)
        {
            btnPlayPause.ForeColor = Color.Black;
        }

        private void btnStop_MouseEnter(object sender, EventArgs e)
        {
            btnStop.ForeColor = Color.IndianRed;
        }

        private void btnStop_MouseLeave(object sender, EventArgs e)
        {
            btnStop.ForeColor = Color.Black;
        }

        private void tmrProgress_Tick(object sender, EventArgs e)
        {
            TimeSpan temp = new TimeSpan(0, 0, (int)vidPlayer.CurrentPosition);

            pBarPlaybackProgress.Value = (int)vidPlayer.CurrentPosition;
            
            if (duration.Hours > 0)
                lblCurrentPosition.Text = temp.ToString() + "/" + duration.ToString();
            else
                lblCurrentPosition.Text = temp.Minutes.ToString("D2") + ":" + temp.Seconds.ToString("D2") + "/" +
                    duration.Minutes.ToString("D2") + ":" + duration.Seconds.ToString("D2");
        }

        private void btnRewind_Click(object sender, EventArgs e)
        {
            if (isFileLoaded)
            {
                if (vidPlayer.SeekingCaps.CanSeekBackwards)
                {
                    if (vidPlayer.CurrentPosition > 5)
                        vidPlayer.SeekCurrentPosition((vidPlayer.CurrentPosition - 5) * 10000000, SeekPositionFlags.AbsolutePositioning);
                    else
                        vidPlayer.SeekCurrentPosition(0, SeekPositionFlags.AbsolutePositioning);
                    tmrProgress_Tick(null, null);
                }
            }
        }

        private void btnRewind_MouseEnter(object sender, EventArgs e)
        {
            btnRewind.ForeColor = Color.IndianRed;
        }

        private void btnRewind_MouseLeave(object sender, EventArgs e)
        {
            btnRewind.ForeColor = Color.Black;
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (isFileLoaded)
            {
                if (vidPlayer.SeekingCaps.CanSeekForwards)
                {
                    if (vidPlayer.CurrentPosition + 5 < vidPlayer.Duration)
                        vidPlayer.SeekCurrentPosition((vidPlayer.CurrentPosition + 5) * 10000000, SeekPositionFlags.AbsolutePositioning);
                    else
                        vidPlayer.SeekCurrentPosition(vidPlayer.Duration, SeekPositionFlags.AbsolutePositioning);
                    tmrProgress_Tick(null, null);
                }
            }
        }

        private void btnForward_MouseEnter(object sender, EventArgs e)
        {
            btnForward.ForeColor = Color.IndianRed;
        }

        private void btnForward_MouseLeave(object sender, EventArgs e)
        {
            btnForward.ForeColor = Color.Black;
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (isFileLoaded)
            {
                if (vidPlayer.Fullscreen)
                    vidPlayer.Fullscreen = false;
                else
                    vidPlayer.Fullscreen = true;
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFullScreen_Click(null, null);
        }

        private void playPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPlayPause_Click(null, null);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStop_Click(null, null);
        }

        private void rewindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRewind_Click(null, null);
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnForward_Click(null, null);
        }

        private void pBarPlaybackProgress_MouseDown(object sender, MouseEventArgs e)
        {
            UInt64 locationToSeek;
            if (isFileLoaded)
            {
                try { locationToSeek = (UInt64)((vidPlayer.Duration / (float)pBarPlaybackProgress.Width) * e.X); }
                catch { return; }

                if (locationToSeek - vidPlayer.CurrentPosition > 0 && vidPlayer.SeekingCaps.CanSeekForwards)
                {
                    vidPlayer.SeekCurrentPosition(locationToSeek * 10000000, SeekPositionFlags.AbsolutePositioning);
                    tmrProgress_Tick(null, null);
                }
                else if (vidPlayer.SeekingCaps.CanSeekBackwards)
                {
                    vidPlayer.SeekCurrentPosition(locationToSeek * 10000000, SeekPositionFlags.AbsolutePositioning);
                    tmrProgress_Tick(null, null);
                }
            }
        }
    }
}