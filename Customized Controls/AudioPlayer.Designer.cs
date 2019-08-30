namespace Customized_Controls
{
    partial class AudioPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioPlayer));
            this.toolStripControls = new System.Windows.Forms.ToolStrip();
            this.btnPlayPause = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnRewind = new System.Windows.Forms.ToolStripButton();
            this.btnForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pBarPlaybackProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblCurrentPosition = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rewindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.toolStripControls.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.pBarPlaybackProgress,
            this.lblCurrentPosition});
            this.toolStripControls.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripControls.Location = new System.Drawing.Point(0, 160);
            this.toolStripControls.MaximumSize = new System.Drawing.Size(0, 25);
            this.toolStripControls.MinimumSize = new System.Drawing.Size(0, 25);
            this.toolStripControls.Name = "toolStripControls";
            this.toolStripControls.Size = new System.Drawing.Size(340, 25);
            this.toolStripControls.Stretch = true;
            this.toolStripControls.TabIndex = 4;
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
            this.btnStop.ToolTipText = "Stop(Ctrl+S)";
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
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.rewindToolStripMenuItem,
            this.forwardToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(340, 24);
            this.menuStrip.TabIndex = 5;
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
            // tmrProgress
            // 
            this.tmrProgress.Interval = 1000;
            this.tmrProgress.Tick += new System.EventHandler(this.tmrProgress_Tick);
            // 
            // AudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.toolStripControls);
            this.Name = "AudioPlayer";
            this.Size = new System.Drawing.Size(340, 185);
            this.toolStripControls.ResumeLayout(false);
            this.toolStripControls.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripControls;
        private System.Windows.Forms.ToolStripButton btnPlayPause;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnRewind;
        private System.Windows.Forms.ToolStripButton btnForward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar pBarPlaybackProgress;
        private System.Windows.Forms.ToolStripLabel lblCurrentPosition;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.Timer tmrProgress;
    }
}
