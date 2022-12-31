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

namespace MCLauncher.progressbars
{
    public partial class DownloadProgressMulti : Form
    {
        WebClient client;

        List<string> theUrls = new List<string>();
        List<string> thePaths = new List<string>();
        int theSize;

        int currentInt = 0;

        public DownloadProgressMulti(List<string> urls, List<string> paths, int totalSize)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            progressBarDownload.Maximum = totalSize;

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
                Console.WriteLine($"Downloading {theUrls[currentInt]}");
                client.DownloadFileAsync(new Uri(theUrls[currentInt]), thePaths[currentInt]);
                currentInt++;
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLabel.Text = e.ProgressPercentage + "% | " + e.BytesReceived + " bytes / " + theSize + " bytes";
            //progressBarDownload.Value += (int)e.BytesReceived;
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

        }
    }
}
