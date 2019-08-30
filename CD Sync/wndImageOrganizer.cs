using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CD_Sync_Portable
{
    internal partial class WndImageOrganizer : Form
    {
        string intro = "Welcome to the Image Organizer. With Image Organizer, you can: " + Environment.NewLine + Environment.NewLine +
                       "1. Easily view and edit your images' properties." + Environment.NewLine +
                       "2. Use drag-n-drop editing to change image categories." + Environment.NewLine +
                       "3. Easily & quickly perform common tasks such as importing, exporting & deleting images." + Environment.NewLine + Environment.NewLine +
                       "Select an image from the left to get started.";

        public WndImageOrganizer()
        {
            InitializeComponent();
        }

        private void wndImageOrganizer_Load(object sender, EventArgs e)
        {
            lblIntro.Text = intro;
        }

        private void AllNodesInactive()
        {
            lblIntro.Text = intro;
            btnEditProperties.Visible = false;
            btnDeleteAllSelected.Enabled = false;
            btnDeleteCurrent.Enabled = false;
            btnExportAll.Enabled = false;
            btnExportCurrent.Enabled = false;
            btnExportDirectoryTree.Enabled = false;
            btnExportFilelist.Enabled = false;
            btnSynchronize.Enabled = false;
        }

        private void NonImageNodeActivated()
        {

        }

        private void ImageNodeActivated()
        {
        }

        private void ImageNodeSelected()
        {
        }
    }
}