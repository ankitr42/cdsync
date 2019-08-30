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
    public partial class AudioPlayer : UserControl
    {
        private Audio audPlayer;
        private TimeSpan duration;
        private bool isFileLoaded;

        public AudioPlayer()
        {
            InitializeComponent();
        }

        public void OpenAudio(string filePath, bool autoPlay)
        {
            try
            {
                audPlayer = Audio.FromFile(filePath);
                audPlayer.Ending += new EventHandler(audPlayer_Ending);
                pBarPlaybackProgress.Value = 0;
                lblCurrentPosition.Text = "00:00/00:00";
                if (audPlayer.SeekingCaps.CanGetDuration)
                {
                    duration = new TimeSpan(0, 0, (int)audPlayer.Duration);

                    pBarPlaybackProgress.Maximum = (int)audPlayer.Duration;
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
                audPlayer = null;
                isFileLoaded = false;
                throw;
            }
        }

        void audPlayer_Ending(object sender, EventArgs e)
        {
            btnStop_Click(null, null);
        }

        public void CloseAudio()
        {
            if (isFileLoaded)
            {
                btnStop_Click(null, null);
                pBarPlaybackProgress.Maximum = 0;
                audPlayer.Dispose();
                audPlayer = null;
                isFileLoaded = false;
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (isFileLoaded)
            {
                if (!audPlayer.Playing)
                {
                    audPlayer.Play();
                    btnPlayPause.Text = ";";
                    tmrProgress.Enabled = true;
                }
                else
                {
                    audPlayer.Pause();
                    btnPlayPause.Text = "4";
                    tmrProgress.Enabled = false;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isFileLoaded && !audPlayer.Stopped)
            {
                audPlayer.Stop();
                pBarPlaybackProgress.Value = 0;
                tmrProgress.Enabled = false;
                btnPlayPause.Text = "4";
                if (audPlayer.SeekingCaps.CanGetDuration)
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
            TimeSpan temp = new TimeSpan(0, 0, (int)audPlayer.CurrentPosition);

            pBarPlaybackProgress.Value = (int)audPlayer.CurrentPosition;

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
                if (audPlayer.SeekingCaps.CanSeekBackwards)
                {
                    if (audPlayer.CurrentPosition > 5)
                        audPlayer.SeekCurrentPosition((audPlayer.CurrentPosition - 5) * 10000000, SeekPositionFlags.AbsolutePositioning);
                    else
                        audPlayer.SeekCurrentPosition(0, SeekPositionFlags.AbsolutePositioning);
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
                if (audPlayer.SeekingCaps.CanSeekForwards)
                {
                    if (audPlayer.CurrentPosition + 5 < audPlayer.Duration)
                        audPlayer.SeekCurrentPosition((audPlayer.CurrentPosition + 5) * 10000000, SeekPositionFlags.AbsolutePositioning);
                    else
                        audPlayer.SeekCurrentPosition(audPlayer.Duration, SeekPositionFlags.AbsolutePositioning);
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
                try { locationToSeek = (UInt64)((audPlayer.Duration / (float)pBarPlaybackProgress.Width) * e.X); }
                catch { return; }

                if (locationToSeek - audPlayer.CurrentPosition > 0 && audPlayer.SeekingCaps.CanSeekForwards)
                {
                    audPlayer.SeekCurrentPosition(locationToSeek * 10000000, SeekPositionFlags.AbsolutePositioning);
                    tmrProgress_Tick(null, null);
                }
                else if (audPlayer.SeekingCaps.CanSeekBackwards)
                {
                    audPlayer.SeekCurrentPosition(locationToSeek * 10000000, SeekPositionFlags.AbsolutePositioning);
                    tmrProgress_Tick(null, null);
                }
            }
        }
    }
}