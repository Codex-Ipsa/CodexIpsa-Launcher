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
        public static int fileSize = 0; //0 - null; 1 = can download; 2 = cancel

        public DownloadProgress()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            wc = new WebClient();
            //This is retarded and doesn't work
            /*check = new WebClient();

            using(check)
            {
                wc.OpenRead(url);
                Int64 size = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);

                if(size < 100000000)
                {
                    startDownload();
                }
                else
                {
                    sizeWarn();
                }
            }*/
            startDownload();
        }

        public void sizeWarn()
        {
            //This is also retarded and doesn't work
            LargeDownloadWarn warn = new LargeDownloadWarn();
            warn.ShowDialog();

            if (fileSize == 1)
            {
                startDownload();
                fileSize = 0;
            }
            else
            {
                fileSize = 0;
                wc.CancelAsync();
                Thread.Sleep(100);
                this.Close();
            }
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

        //public static bool largeFile = false;
        /*WebClient wc = new WebClient();

        public DownloadProgress()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

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

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLabel.Text = e.ProgressPercentage + "% | " + e.BytesReceived + " bytes / " + e.TotalBytesToReceive + " bytes";

            progressBarDownload.Value = e.ProgressPercentage;
        }

        public void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            wc.CancelAsync();
            url = "";
            savePath = "";
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            wc.CancelAsync();

            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }

            url = "";
            savePath = "";
            this.Close();
        }*/
    }
}
