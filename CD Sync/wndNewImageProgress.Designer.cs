namespace CD_Sync_Portable
{
    partial class WndNewImageProgress
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnMore = new System.Windows.Forms.Button();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblCurrentItem = new System.Windows.Forms.Label();
            this.lblDirsSkipped = new System.Windows.Forms.Label();
            this.lblDirsAdded = new System.Windows.Forms.Label();
            this.lblFilesSkipped = new System.Windows.Forms.Label();
            this.lblFilesAdded = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.lblRemainingFiles = new System.Windows.Forms.Label();
            this.lblRemainingDirs = new System.Windows.Forms.Label();
            this.lblTotalDirs = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPercentComplete = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(5, 21);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(380, 25);
            this.progressBar.TabIndex = 2;
            // 
            // btnMore
            // 
            this.btnMore.AutoSize = true;
            this.btnMore.Location = new System.Drawing.Point(5, 69);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(90, 28);
            this.btnMore.TabIndex = 3;
            this.btnMore.Text = "&Details >>";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblCurrentItem);
            this.grpDetails.Controls.Add(this.lblDirsSkipped);
            this.grpDetails.Controls.Add(this.lblDirsAdded);
            this.grpDetails.Controls.Add(this.lblFilesSkipped);
            this.grpDetails.Controls.Add(this.lblFilesAdded);
            this.grpDetails.Controls.Add(this.lblTotalFiles);
            this.grpDetails.Controls.Add(this.lblRemainingFiles);
            this.grpDetails.Controls.Add(this.lblRemainingDirs);
            this.grpDetails.Controls.Add(this.lblTotalDirs);
            this.grpDetails.Controls.Add(this.label7);
            this.grpDetails.Controls.Add(this.label3);
            this.grpDetails.Controls.Add(this.label10);
            this.grpDetails.Controls.Add(this.label8);
            this.grpDetails.Controls.Add(this.label9);
            this.grpDetails.Controls.Add(this.label6);
            this.grpDetails.Controls.Add(this.label5);
            this.grpDetails.Controls.Add(this.label4);
            this.grpDetails.Controls.Add(this.label2);
            this.grpDetails.Location = new System.Drawing.Point(5, 128);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(380, 206);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Details";
            // 
            // lblCurrentItem
            // 
            this.lblCurrentItem.Location = new System.Drawing.Point(21, 150);
            this.lblCurrentItem.Name = "lblCurrentItem";
            this.lblCurrentItem.Size = new System.Drawing.Size(356, 47);
            this.lblCurrentItem.TabIndex = 0;
            this.lblCurrentItem.Text = "---";
            // 
            // lblDirsSkipped
            // 
            this.lblDirsSkipped.AutoSize = true;
            this.lblDirsSkipped.Location = new System.Drawing.Point(119, 90);
            this.lblDirsSkipped.Name = "lblDirsSkipped";
            this.lblDirsSkipped.Size = new System.Drawing.Size(13, 13);
            this.lblDirsSkipped.TabIndex = 0;
            this.lblDirsSkipped.Text = "0";
            // 
            // lblDirsAdded
            // 
            this.lblDirsAdded.AutoSize = true;
            this.lblDirsAdded.Location = new System.Drawing.Point(119, 67);
            this.lblDirsAdded.Name = "lblDirsAdded";
            this.lblDirsAdded.Size = new System.Drawing.Size(13, 13);
            this.lblDirsAdded.TabIndex = 0;
            this.lblDirsAdded.Text = "0";
            // 
            // lblFilesSkipped
            // 
            this.lblFilesSkipped.AutoSize = true;
            this.lblFilesSkipped.Location = new System.Drawing.Point(329, 90);
            this.lblFilesSkipped.Name = "lblFilesSkipped";
            this.lblFilesSkipped.Size = new System.Drawing.Size(13, 13);
            this.lblFilesSkipped.TabIndex = 0;
            this.lblFilesSkipped.Text = "0";
            // 
            // lblFilesAdded
            // 
            this.lblFilesAdded.AutoSize = true;
            this.lblFilesAdded.Location = new System.Drawing.Point(329, 67);
            this.lblFilesAdded.Name = "lblFilesAdded";
            this.lblFilesAdded.Size = new System.Drawing.Size(13, 13);
            this.lblFilesAdded.TabIndex = 0;
            this.lblFilesAdded.Text = "0";
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(329, 21);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFiles.TabIndex = 0;
            this.lblTotalFiles.Text = "0";
            // 
            // lblRemainingFiles
            // 
            this.lblRemainingFiles.AutoSize = true;
            this.lblRemainingFiles.Location = new System.Drawing.Point(329, 44);
            this.lblRemainingFiles.Name = "lblRemainingFiles";
            this.lblRemainingFiles.Size = new System.Drawing.Size(13, 13);
            this.lblRemainingFiles.TabIndex = 0;
            this.lblRemainingFiles.Text = "0";
            // 
            // lblRemainingDirs
            // 
            this.lblRemainingDirs.AutoSize = true;
            this.lblRemainingDirs.Location = new System.Drawing.Point(119, 44);
            this.lblRemainingDirs.Name = "lblRemainingDirs";
            this.lblRemainingDirs.Size = new System.Drawing.Size(13, 13);
            this.lblRemainingDirs.TabIndex = 0;
            this.lblRemainingDirs.Text = "0";
            // 
            // lblTotalDirs
            // 
            this.lblTotalDirs.AutoSize = true;
            this.lblTotalDirs.Location = new System.Drawing.Point(119, 21);
            this.lblTotalDirs.Name = "lblTotalDirs";
            this.lblTotalDirs.Size = new System.Drawing.Size(13, 13);
            this.lblTotalDirs.TabIndex = 0;
            this.lblTotalDirs.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Files remaining";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Directories remaining";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Directories skipped";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Directories added";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(228, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Files skipped";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Files added";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total directories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current item";
            // 
            // lblPercentComplete
            // 
            this.lblPercentComplete.AutoSize = true;
            this.lblPercentComplete.Location = new System.Drawing.Point(161, 76);
            this.lblPercentComplete.Name = "lblPercentComplete";
            this.lblPercentComplete.Size = new System.Drawing.Size(68, 13);
            this.lblPercentComplete.TabIndex = 4;
            this.lblPercentComplete.Text = "0% Complete";
            this.lblPercentComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(295, 69);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creating new image";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblElapsedTime.Location = new System.Drawing.Point(127, 4);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblElapsedTime.Size = new System.Drawing.Size(256, 14);
            this.lblElapsedTime.TabIndex = 1;
            this.lblElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WndNewImageProgress
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(390, 105);
            this.ControlBox = false;
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPercentComplete);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndNewImageProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblPercentComplete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalDirs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRemainingDirs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRemainingFiles;
        private System.Windows.Forms.Label lblDirsAdded;
        private System.Windows.Forms.Label lblFilesAdded;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDirsSkipped;
        private System.Windows.Forms.Label lblFilesSkipped;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblElapsedTime;
    }
}