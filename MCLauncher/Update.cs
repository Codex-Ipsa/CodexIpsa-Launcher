using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class Update : Form
    {
        public string UrlString;
        public Update(string ver, string info, string url)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            infoLabel.Text = $"{ver}\n\n{info}";
            UrlString = url;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            DownloadUpdate(UrlString);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void DownloadUpdate(string url)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(Globals.updaterUrl, $"{Globals.currentPath}\\LauncherUpdater.exe");
            }

            System.Diagnostics.Process.Start($"{Globals.currentPath}\\LauncherUpdater.exe -url \"{url}\"");
            Application.Exit();
        }
    }
}
