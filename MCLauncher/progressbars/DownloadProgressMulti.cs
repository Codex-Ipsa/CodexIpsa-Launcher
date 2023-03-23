using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MCLauncher.progressbars
{
    public partial class DownloadProgressMulti : Form
    {
        WebClient client;
        List<string> theUrls = new List<string>();
        List<string> thePaths = new List<string>();
        double theSize;
        int sizeReceived = 0;
        bool hasAdded = false;
        int currentInt = 0;

        public DownloadProgressMulti(List<string> urls, List<string> paths, double totalSize, string message)
        {
            InitializeComponent();

            //Lang
            this.Text = Strings.lblDlFiles;
            label1.Text = Strings.lblDlFiles;
            ProgressLabel.Text = Strings.lblLoading;
            cancelBtn.Text = Strings.btnCancel;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            progressBarDownload.Maximum = (int)totalSize;
            label1.Text = message;

            theUrls = urls;
            thePaths = paths;
            theSize = totalSize;

            client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            startDownload();
        }

        public void startDownload()
        {
            if(currentInt < theUrls.Count)
            {
                hasAdded = false;
                Logger.Info("[DownloadProgressMulti]",$"Downloading {theUrls[currentInt]}...");
                client.DownloadFileAsync(new Uri(theUrls[currentInt]), thePaths[currentInt]);
                currentInt++;
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.WriteLine("THIS GOT CALLED");
            if(e.ProgressPercentage == 100 && hasAdded == false)
            {
                //Console.WriteLine("THAT GOT CALLED");
                hasAdded = true;
                sizeReceived += (int)e.BytesReceived;
                //Console.WriteLine("PERCENTAGE IS 100%");
                ProgressLabel.Text = $"{(sizeReceived * 100.0 / theSize).ToString("N0")}% | {sizeReceived} {Strings.bytes} / {theSize} {Strings.bytes}";

                progressBarDownload.Value = sizeReceived;
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(currentInt >= theUrls.Count)
            {
                this.Close();
            }
            else
            {
                startDownload();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            currentInt = theUrls.Count;
            client.CancelAsync();

            foreach(string path in thePaths)
            {
                if(File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
    }
}
