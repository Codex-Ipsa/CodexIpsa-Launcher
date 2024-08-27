using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class DownloaderGui : Form
    {
        public WebClient wc;
        public List<DownloadObject> downloadList;

        public double totalSize = 0;
        public int filesDownloaded = 0;

        public DownloaderGui(List<DownloadObject> downloads)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

            this.downloadList = downloads;

            //Lang

            //sets number of files
            label1.Text = $"Downloaded 0 / {downloadList.Count} files";

            //gets and sets the total size
            foreach (var h in downloadList)
            {
                WebClient client = new WebClient();
                client.OpenRead(h.url);
                double bytes_total = Convert.ToDouble(client.ResponseHeaders["Content-Length"]);
                totalSize += bytes_total;
                Console.WriteLine("totalSize " + totalSize);
            }
            ProgressLabel.Text = $"0 / {totalSize} bytes";
            progressBar.Maximum = downloadList.Count;

            //start the download
            Logger.Info("[DownloaderGui]", $"Starting for {downloadList.Count} files ({totalSize} bytes)");
            wc = new WebClient();
            downloadLoop();
        }

        //downloads a single file
        public void downloadLoop()
        {
            using (wc)
            {
                Logger.Info("[DownloaderGui]", $"Downloading {downloadList[filesDownloaded].url}...");
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(downloadList[filesDownloaded].url), downloadList[filesDownloaded].path);
                Console.WriteLine("afterdownloadfileasznc");
            }
        }

        //goes to downloadloop if there are more files to download
        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("one file finished");
            filesDownloaded++;

            if (filesDownloaded < downloadList.Count)
            {
                progressBar.Value++;
                downloadLoop();
            }
            else
            {
                wc.Dispose();
                Console.WriteLine("FINISHED!!!");
                this.Close();
            }
        }

        //updates the progressbar and texts
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.WriteLine("ACTUALLY DOWNLOADING!@!!");
            ProgressLabel.Text = $"{e.ProgressPercentage}% | {filesDownloaded} / {downloadList.Count} | {e.BytesReceived} {Strings.sj.bytes} / {totalSize} {Strings.sj.bytes}";

            //progressBar.Value = e.ProgressPercentage;
        }
    }

    //the obj
    public class DownloadObject
    {
        public String url;
        public String path;

        public DownloadObject(String url, String path)
        {
            this.url = url;
            this.path = path;
        }
    }
}
