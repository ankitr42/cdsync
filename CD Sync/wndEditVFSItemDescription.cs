using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CD_Sync_Portable
{
    internal partial class WndEditVFSItemDescription : Form
    {
        public string ItemDescription
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public WndEditVFSItemDescription(string itemDesc)
        {
            InitializeComponent();

            txtDescription.Text = itemDesc;
            if (itemDesc.Length == 0)
                txtDescription_TextChanged(null, null);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblCharCount.Text = "You have " + (1024 - txtDescription.Text.Length).ToString() + " characters remaining.";
        }
    }
}