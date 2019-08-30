using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CD_Sync_Portable
{
    internal partial class WndNewImageProgress : Form
    {
        private UInt32 tick, totalDirs, totalFiles, dirsSkipped, filesSkipped, filesAdded, dirsAdded;
        private float percentComplete;
        private System.Timers.Timer timer;
        public UInt32 elapsedSecs;

        public WndNewImageProgress()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            elapsedSecs += 1;
            lblElapsedTime.Text = "Elapsed: " + (elapsedSecs / 60).ToString() + " mins, " + (elapsedSecs % 60).ToString() + " secs";
        }

        public DialogResult ShowDialog(UInt32 tDirs, UInt32 tFiles)
        {
            tick = 0;
            totalDirs = tDirs;
            totalFiles = tFiles;
            dirsAdded = 0;
            dirsSkipped = 0;
            filesAdded = 0;
            filesSkipped = 0;
            percentComplete = 0;
            elapsedSecs = 0;
            lblTotalDirs.Text = totalDirs.ToString();
            lblTotalFiles.Text = totalFiles.ToString();
            timer.Start();
            return base.ShowDialog();
        }

        public void Update(string curItem, UInt32 dirsSkipped, UInt32 filesSkipped, UInt32 dirAdded, UInt32 fileAdded)
        {
            tick += (dirsSkipped + filesSkipped + dirAdded + fileAdded);
            if ((totalDirs + totalFiles) > 0)
                percentComplete = (float)((tick * 100) / (totalDirs + totalFiles));
            lblPercentComplete.Text = percentComplete.ToString() + "% Completed";

            this.dirsSkipped += dirsSkipped;
            this.filesSkipped += filesSkipped;
            this.dirsAdded += dirAdded;
            this.filesAdded += fileAdded;
            progressBar.Value = (Int32)percentComplete;

            if (btnMore.Text == "<< &Hide Details")
            {
                lblRemainingDirs.Text = (totalDirs - (this.dirsSkipped + this.dirsAdded)).ToString();
                lblRemainingFiles.Text = (totalFiles - (this.filesSkipped + this.filesAdded)).ToString();
                lblDirsAdded.Text = this.dirsAdded.ToString();
                lblFilesAdded.Text = this.filesAdded.ToString();
                lblDirsSkipped.Text = this.dirsSkipped.ToString();
                lblFilesSkipped.Text = this.filesSkipped.ToString();
                lblCurrentItem.Text = curItem;
            }
        }
        
        private void btnMore_Click(object sender, EventArgs e)
        {
            if (btnMore.Text == "&Details >>")
            {
                this.Height += 235;
                lblRemainingDirs.Text = (totalDirs - (dirsSkipped + dirsAdded)).ToString();
                lblRemainingFiles.Text = (totalFiles - (filesSkipped + filesAdded)).ToString();
                lblDirsAdded.Text = dirsAdded.ToString();
                lblFilesAdded.Text = filesAdded.ToString();
                btnMore.Text = "<< &Hide Details";
            }
            else
            {
                this.Height -= 235;
                btnMore.Text = "&Details >>";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.promptCancel, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                timer.Stop();
        }

        public void ProcessCompleted()
        {
            timer.Stop();
            this.DialogResult = DialogResult.OK;
        }

        public void ProcessAborted()
        {
            timer.Stop();
            this.DialogResult = DialogResult.Abort;
        }
    }
}