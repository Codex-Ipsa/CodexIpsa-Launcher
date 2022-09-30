using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class WindowHome : UserControl
    {
        public WindowHome()
        {
            InitializeComponent();

            //Load lang
            btnPlay.Text = Strings.btnPlay;
            btnLogIn.Text = Strings.btnLogIn;
            btnNewInst.Text = Strings.btnNewInst;
            btnEditInst.Text = Strings.btnEditInst;

            webBrowser.Url = new Uri(Globals.changelog, UriKind.Absolute);
            webBrowser.Refresh();
            Logger.logMessage($"[MainWindow]", $"Changelog loaded");
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

        }
    }
}
