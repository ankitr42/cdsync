namespace Customized_Controls
{
    partial class VideoPlayer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPlayer));
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.toolStripControls = new System.Windows.Forms.ToolStrip();
            this.btnPlayPause = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnRewind = new System.Windows.Forms.ToolStripButton();
            this.btnForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFullScreen = new System.Windows.Forms.ToolStripButton();
            this.pBarPlaybackProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblCurrentPosition = new System.Windows.Forms.ToolStripLabel();
            this.panelVideo = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rewindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripControls.SuspendLayout();
            this.panelVideo.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrProgress
            // 
            this.tmrProgress.Interval = 1000;
            this.tmrProgress.Tick += new System.EventHandler(this.tmrProgress_Tick);
            // 
            // toolStripControls
            // 
            this.toolStripControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripControls.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlayPause,
            this.btnStop,
            this.btnRewind,
            this.btnForward,
            this.toolStripSeparator1,
            this.btnFullScreen,
            this.pBarPlaybackProgress,
            this.lblCurrentPosition});
            this.toolStripControls.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripControls.Location = new System.Drawing.Point(0, 172);
            this.toolStripControls.MaximumSize = new System.Drawing.Size(0, 25);
            this.toolStripControls.MinimumSize = new System.Drawing.Size(0, 25);
            this.toolStripControls.Name = "toolStripControls";
            this.toolStripControls.Size = new System.Drawing.Size(365, 25);
            this.toolStripControls.Stretch = true;
            this.toolStripControls.TabIndex = 3;
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPlayPause.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayPause.Image")));
            this.btnPlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlayPause.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(25, 25);
            this.btnPlayPause.Text = "4";
            this.btnPlayPause.ToolTipText = "Play/Pause (Ctrl+P)";
            this.btnPlayPause.MouseLeave += new System.EventHandler(this.btnPlayPause_MouseLeave);
            this.btnPlayPause.MouseEnter += new System.EventHandler(this.btnPlayPause_MouseEnter);
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStop.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(25, 25);
            this.btnStop.Text = "<";
            this.btnStop.ToolTipText = "Stop (Ctrl+S)";
            this.btnStop.MouseLeave += new System.EventHandler(this.btnStop_MouseLeave);
            this.btnStop.MouseEnter += new System.EventHandler(this.btnStop_MouseEnter);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRewind
            // 
            this.btnRewind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRewind.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRewind.Image = ((System.Drawing.Image)(resources.GetObject("btnRewind.Image")));
            this.btnRewind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRewind.Name = "btnRewind";
            this.btnRewind.Size = new System.Drawing.Size(25, 22);
            this.btnRewind.Text = "7";
            this.btnRewind.ToolTipText = "Rewind 5 seconds (Ctrl+Left Arrow)";
            this.btnRewind.MouseLeave += new System.EventHandler(this.btnRewind_MouseLeave);
            this.btnRewind.MouseEnter += new System.EventHandler(this.btnRewind_MouseEnter);
            this.btnRewind.Click += new System.EventHandler(this.btnRewind_Click);
            // 
            // btnForward
            // 
            this.btnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnForward.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(25, 22);
            this.btnForward.Text = "8";
            this.btnForward.ToolTipText = "Forward 5 seconds (Ctrl+Right Arrow)";
            this.btnForward.MouseLeave += new System.EventHandler(this.btnForward_MouseLeave);
            this.btnForward.MouseEnter += new System.EventHandler(this.btnForward_MouseEnter);
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullScreen.Image = global::Customized_Controls.Properties.Resources.videoPlayer_Fullscreen_16x16x32;
            this.btnFullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(23, 22);
            this.btnFullScreen.ToolTipText = "Fullscreen/Exit Fullscreen (Ctrl+F)";
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // pBarPlaybackProgress
            // 
            this.pBarPlaybackProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pBarPlaybackProgress.AutoSize = false;
            this.pBarPlaybackProgress.Maximum = 0;
            this.pBarPlaybackProgress.Name = "pBarPlaybackProgress";
            this.pBarPlaybackProgress.Size = new System.Drawing.Size(150, 22);
            this.pBarPlaybackProgress.Step = 1;
            this.pBarPlaybackProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBarPlaybackProgress.ToolTipText = "Progress";
            this.pBarPlaybackProgress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBarPlaybackProgress_MouseDown);
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblCurrentPosition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(16, 22);
            this.lblCurrentPosition.Text = "   ";
            // 
            // panelVideo
            // 
            this.panelVideo.Controls.Add(this.menuStrip);
            this.panelVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVideo.Location = new System.Drawing.Point(0, 0);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(365, 172);
            this.panelVideo.TabIndex = 4;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.rewindToolStripMenuItem,
            this.forwardToolStripMenuItem,
            this.fullScreenToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(365, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.Visible = false;
            // 
            // playPauseToolStripMenuItem
            // 
            this.playPauseToolStripMenuItem.Name = "playPauseToolStripMenuItem";
            this.playPauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.playPauseToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.playPauseToolStripMenuItem.Text = "Play/Pause";
            this.playPauseToolStripMenuItem.Click += new System.EventHandler(this.playPauseToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // rewindToolStripMenuItem
            // 
            this.rewindToolStripMenuItem.Name = "rewindToolStripMenuItem";
            this.rewindToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.rewindToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.rewindToolStripMenuItem.Text = "Rewind";
            this.rewindToolStripMenuItem.Click += new System.EventHandler(this.rewindToolStripMenuItem_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.forwardToolStripMenuItem.Text = "Forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.fullScreenToolStripMenuItem.Text = "FullScreen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // VideoPlayer
            // 
            this.Controls.Add(this.panelVideo);
            this.Controls.Add(this.toolStripControls);
            this.Name = "VideoPlayer";
            this.Size = new System.Drawing.Size(365, 197);
            this.toolStripControls.ResumeLayout(false);
            this.toolStripControls.PerformLayout();
            this.panelVideo.ResumeLayout(false);
            this.panelVideo.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrProgress;
        private System.Windows.Forms.ToolStrip toolStripControls;
        private System.Windows.Forms.ToolStripButton btnPlayPause;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnRewind;
        private System.Windows.Forms.ToolStripButton btnForward;
        private System.Windows.Forms.Panel panelVideo;
        private System.Windows.Forms.ToolStripProgressBar pBarPlaybackProgress;
        private System.Windows.Forms.ToolStripLabel lblCurrentPosition;
        private System.Windows.Forms.ToolStripButton btnFullScreen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
    }
}
