using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CD_Sync_Portable
{
    internal partial class WndWaitBanner : Form
    {
        Thread newThread;

        public WndWaitBanner(string message)
        {
            InitializeComponent();
            lblWaitMessage.Text = message;
        }

        public void SetMessage(string message)
        {
            lblWaitMessage.Text = message;
        }

        private void ShowDialogInternal()
        {
            base.ShowDialog();
        }

        public void ShowDialogAsync()
        {
            if (this.Visible)
                return;

            newThread = new Thread(new ThreadStart(ShowDialogInternal));
            newThread.Start();
        }

        public void EndShowDialogAsync()
        {
            base.Close();
            if (newThread.IsAlive)
                newThread.Abort();
        }

        private void lblWaitMessage_TextChanged(object sender, EventArgs e)
        {
            this.Width = lblWaitMessage.Width + 50;
        }
    }
}