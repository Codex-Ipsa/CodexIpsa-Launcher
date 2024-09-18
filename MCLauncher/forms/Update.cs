using MCLauncher.controls;
using System;
using System.Diagnostics;
using System.Net;
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

            //Lang
            this.Text = Strings.sj.updateAvail;
            label1.Text = Strings.sj.lblUpdateAvail;
            cancelBtn.Text = Strings.sj.btnNo;
            updateBtn.Text = Strings.sj.btnYes;
            label2.Text = Strings.sj.lblDoDown;

            infoLabel.Text = $"{ver}\n\n{Strings.sj.lblWhatsNew}\n{info}";
            UrlString = url;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            SettingsScreen.isUpdating = true;
            DownloadUpdate(UrlString);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            SettingsScreen.isUpdating = false;
            this.Close();
        }

        public static void DownloadUpdate(string url)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(Globals.updaterUrl, $"{Globals.currentPath}\\LauncherUpdater.exe");
            }

            var processU = new Process
            {
                StartInfo =
                {
                  FileName = $"{Globals.currentPath}\\LauncherUpdater.exe",
                  Arguments = $"-url \"{url}\""
                }
            };
            processU.Start();
            Application.Exit();
        }
    }
}
