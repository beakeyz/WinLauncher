using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using WinLauncher.src;

namespace WinLauncher
{
    public partial class WinLauncher : Form
    {
        public App parent;

        public WinLauncher(App parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.statusUpdateLabel.Visible = false;
            this.statusUpdateLabel.Text = "";
            if (this.btnDefaultDir.Checked)
            {
                this.btnDirChoose.Visible = false;
            }
        }

        private void btnDirChoose_Click(object sender, EventArgs e)
        {
            this.dirChoice.ShowDialog();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            this.parent.HandleDownload();
        }

        // Event to track the progress
        public void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.InstallationProgressBar.Value = e.ProgressPercentage;

            this.parent.SetStatus(true, "Downloading... (" + this.InstallationProgressBar.Value + "%)");

            if (this.InstallationProgressBar.Value == 100)
            {
                this.parent.SetStatus(true, "Download complete!");
            }
        }

        private void btnDefaultDir_CheckedChanged(object sender, EventArgs e)
        {
            this.btnDirChoose.Visible = !this.btnDefaultDir.Checked;
            if (this.btnDefaultDir.Checked)
            {
                this.dirChoice.SelectedPath = parent.DEFAULT_PATH;
            }
        }
    }
}
