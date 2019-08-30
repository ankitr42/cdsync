namespace CD_Sync_Portable
{
    partial class WndAltFileNameInputBox
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtAltFileName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOverwrite = new System.Windows.Forms.Button();
            this.pBoxAvailabilityPic = new System.Windows.Forms.PictureBox();
            this.lblFileNameAvailability = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAvailabilityPic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.Location = new System.Drawing.Point(5, 5);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(375, 49);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "  ";
            // 
            // txtAltFileName
            // 
            this.txtAltFileName.Location = new System.Drawing.Point(6, 59);
            this.txtAltFileName.MaxLength = 25;
            this.txtAltFileName.Name = "txtAltFileName";
            this.txtAltFileName.Size = new System.Drawing.Size(288, 20);
            this.txtAltFileName.TabIndex = 1;
            this.txtAltFileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAltFileName_KeyPress);
            this.txtAltFileName.TextChanged += new System.EventHandler(this.txtAltFileName_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(118, 90);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnOverwrite.Location = new System.Drawing.Point(199, 90);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Size = new System.Drawing.Size(76, 23);
            this.btnOverwrite.TabIndex = 4;
            this.btnOverwrite.Text = "Over&write";
            this.btnOverwrite.UseVisualStyleBackColor = true;
            // 
            // pBoxAvailabilityPic
            // 
            this.pBoxAvailabilityPic.Image = global::CD_Sync_Portable.Properties.Resources.cross_16x16x32;
            this.pBoxAvailabilityPic.Location = new System.Drawing.Point(300, 61);
            this.pBoxAvailabilityPic.Name = "pBoxAvailabilityPic";
            this.pBoxAvailabilityPic.Size = new System.Drawing.Size(16, 16);
            this.pBoxAvailabilityPic.TabIndex = 3;
            this.pBoxAvailabilityPic.TabStop = false;
            // 
            // lblFileNameAvailability
            // 
            this.lblFileNameAvailability.AutoSize = true;
            this.lblFileNameAvailability.Location = new System.Drawing.Point(319, 62);
            this.lblFileNameAvailability.Name = "lblFileNameAvailability";
            this.lblFileNameAvailability.Size = new System.Drawing.Size(53, 13);
            this.lblFileNameAvailability.TabIndex = 2;
            this.lblFileNameAvailability.Text = "File Exists";
            // 
            // WndAltFileNameInputBox
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(374, 119);
            this.ControlBox = false;
            this.Controls.Add(this.pBoxAvailabilityPic);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtAltFileName);
            this.Controls.Add(this.lblFileNameAvailability);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnOverwrite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WndAltFileNameInputBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAvailabilityPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtAltFileName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnOverwrite;
        private System.Windows.Forms.PictureBox pBoxAvailabilityPic;
        private System.Windows.Forms.Label lblFileNameAvailability;
    }
}