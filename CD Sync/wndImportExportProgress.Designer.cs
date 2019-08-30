namespace CD_Sync_Portable
{
    partial class WndImportExportProgress
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
            this.pBarExportProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCurrentImageInfo = new System.Windows.Forms.GroupBox();
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.lblPercentComplete = new System.Windows.Forms.Label();
            this.grpCurrentImageInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBarExportProgress
            // 
            this.pBarExportProgress.Location = new System.Drawing.Point(6, 23);
            this.pBarExportProgress.Name = "pBarExportProgress";
            this.pBarExportProgress.Size = new System.Drawing.Size(380, 25);
            this.pBarExportProgress.Step = 1;
            this.pBarExportProgress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exporting images";
            // 
            // grpCurrentImageInfo
            // 
            this.grpCurrentImageInfo.Controls.Add(this.lblImageInfo);
            this.grpCurrentImageInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCurrentImageInfo.Location = new System.Drawing.Point(0, 72);
            this.grpCurrentImageInfo.Name = "grpCurrentImageInfo";
            this.grpCurrentImageInfo.Size = new System.Drawing.Size(394, 80);
            this.grpCurrentImageInfo.TabIndex = 3;
            this.grpCurrentImageInfo.TabStop = false;
            this.grpCurrentImageInfo.Text = "Currently exporting";
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.AutoSize = true;
            this.lblImageInfo.Location = new System.Drawing.Point(6, 16);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(16, 13);
            this.lblImageInfo.TabIndex = 0;
            this.lblImageInfo.Text = "   ";
            // 
            // lblPercentComplete
            // 
            this.lblPercentComplete.AutoSize = true;
            this.lblPercentComplete.Location = new System.Drawing.Point(161, 56);
            this.lblPercentComplete.Name = "lblPercentComplete";
            this.lblPercentComplete.Size = new System.Drawing.Size(68, 13);
            this.lblPercentComplete.TabIndex = 2;
            this.lblPercentComplete.Text = "0% Complete";
            // 
            // WndImportExportProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 152);
            this.ControlBox = false;
            this.Controls.Add(this.grpCurrentImageInfo);
            this.Controls.Add(this.lblPercentComplete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBarExportProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndImportExportProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpCurrentImageInfo.ResumeLayout(false);
            this.grpCurrentImageInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBarExportProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpCurrentImageInfo;
        private System.Windows.Forms.Label lblPercentComplete;
        private System.Windows.Forms.Label lblImageInfo;

    }
}