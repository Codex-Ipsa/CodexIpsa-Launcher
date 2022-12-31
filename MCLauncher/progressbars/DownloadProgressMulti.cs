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
        int sizeReceived = 0;
        bool hasAdded = false;

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
                hasAdded = false;
                Console.WriteLine($"Downloading {theUrls[currentInt]}");
                client.DownloadFileAsync(new Uri(theUrls[currentInt]), thePaths[currentInt]);
                currentInt++;
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("THIS GOT CALLED");
            if(e.ProgressPercentage == 100 && hasAdded == false)
            {
                Console.WriteLine("THAT GOT CALLED");
                hasAdded = true;
                sizeReceived += (int)e.BytesReceived;
                Console.WriteLine("PERCENTAGE IS 100%");
                ProgressLabel.Text = e.ProgressPercentage + "% | " + (sizeReceived) + " bytes / " + theSize + " bytes";

                //progressBarDownload.Value = sizeReceived + (int)e.BytesReceived;
            }

            if (sizeReceived + e.BytesReceived > theSize)
            {
                Console.WriteLine("WARNING!!!!");
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

        }
    }
}
