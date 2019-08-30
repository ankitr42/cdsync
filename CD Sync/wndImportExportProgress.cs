using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CD_Sync_Portable
{
    internal partial class WndImportExportProgress : Form
    {
        Thread thread;
        private bool isBusy;

        public WndImportExportProgress(int totalImages, bool isImporting)
        {
            InitializeComponent();
            pBarExportProgress.Maximum = totalImages;
            if (isImporting)
            {
                label1.Text = "Importing images";
                grpCurrentImageInfo.Text = "Currently importing";
            }
        }

        public void ShowDialogAsync()
        {
            if (this.Visible)
                return;

            thread = new Thread(new ThreadStart(ShowDialogInternal));
            thread.Start();
        }

        public void EndShowDialogAsync()
        {
            if (!this.Visible)
                return;
            
            base.Close();
            if (thread.IsAlive)
                thread.Abort();
        }

        private void ShowDialogInternal()
        {
            base.ShowDialog();
        }

        public void BeginImportExport(ListEntry entry)
        {
            if (isBusy == true)
                throw new InvalidOperationException("BeginExport cannot be called twice in a row without calling ExportComplete in between.");
            
            isBusy = true;

            lblImageInfo.Text = entry.imageName;
            lblImageInfo.Text += Environment.NewLine + "Category: " + entry.imageCategory;
            lblImageInfo.Text += Environment.NewLine + "Database file: " + entry.imageDbPath;
            if (entry.imagePicture.Length > 0)
                lblImageInfo.Text += Environment.NewLine + "Picture file: " + entry.imagePicture;
        }

        public void ImportExportComplete()
        {
            isBusy = false;

            pBarExportProgress.PerformStep();
            lblPercentComplete.Text = (((float)(pBarExportProgress.Value / pBarExportProgress.Maximum)) * 100).ToString() + "% Complete.";
        }
    }
}