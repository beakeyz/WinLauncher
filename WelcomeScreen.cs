using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinLauncher.src;

namespace WinLauncher
{
    public partial class WelcomeScreen : Form
    {
        public App parent;
        public bool tryingShutdown;

        public WelcomeScreen(App parent)
        {
            if (parent != null)
                this.parent = parent;

            this.tryingShutdown = false;
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.tryingShutdown = true;
            Application.Exit();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
