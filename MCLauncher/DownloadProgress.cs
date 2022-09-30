using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MCLauncher
{
    public partial class DownloadProgress : Form
    {
        public static string url;
        public static string savePath;
        WebClient wc;
        WebClient check;
        public static int fileSize = 0; //0 - null; 1 = can download; 2 = cancel //<-- what does this even mean????

        public DownloadProgress()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            wc = new WebClient();
            startDownload();
        }

        public void startDownload()
        {
            using (wc)
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(url), savePath);
            }
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            url = "";
            savePath = "";
            this.Close();
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLabel.Text = e.ProgressPercentage + "% | " + e.BytesReceived + " bytes / " + e.TotalBytesToReceive + " bytes";

            progressBarDownload.Value = e.ProgressPercentage;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            wc.CancelAsync();
            Thread.Sleep(100);
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }
        }
    }
}
