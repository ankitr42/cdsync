using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CD_Sync_Portable.Properties;

namespace CD_Sync_Portable
{
    internal partial class WndAltFileNameInputBox : Form
    {
        string parentDir, defExt;

        public WndAltFileNameInputBox()
        {
            InitializeComponent();
        }

        private void txtAltFileName_TextChanged(object sender, EventArgs e)
        {
            if (txtAltFileName.Text.Length == 0)
            {
                pBoxAvailabilityPic.Image = Resources.cross_16x16x32;
                lblFileNameAvailability.Text = "File Exists";
                btnOK.Enabled = false;
                btnOverwrite.Enabled = false;
                return;
            }

            if (File.Exists(Path.Combine(parentDir, txtAltFileName.Text)))
            {
                pBoxAvailabilityPic.Image = Resources.cross_16x16x32;
                lblFileNameAvailability.Text = "File Exists";
                btnOK.Enabled = false;
                btnOverwrite.Enabled = true;
            }
            else
            {
                pBoxAvailabilityPic.Image = Resources.tick_16x16x32;
                lblFileNameAvailability.Text = "Available";
                btnOK.Enabled = true;
                btnOverwrite.Enabled = false;
            }
        }

        private void txtAltFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string invalidChars = "/\\|*?\":<>";
            if (invalidChars.Contains(e.KeyChar.ToString()))
                e.Handled = true;
        }

        public string ShowDialog(string fileName, string parentDir, string message)
        {
            this.parentDir = parentDir;
            txtAltFileName.Text = fileName;
            defExt = Path.GetExtension(txtAltFileName.Text);
            lblMessage.Text = message;

            base.ShowDialog();

            if (String.Compare(Path.GetExtension(txtAltFileName.Text), defExt, true) != 0)
                txtAltFileName.Text += defExt;
            return txtAltFileName.Text;
        }
    }
}