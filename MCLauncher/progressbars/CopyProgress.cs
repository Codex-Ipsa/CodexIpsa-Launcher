using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace MCLauncher
{
    public partial class CopyProgress : Form
    {
        WebClient wc;
        public CopyProgress(string source, string destination)
        {
            InitializeComponent();
            Worker(source, destination);
            //File.Copy(source, destination);
        }

        public void Worker(string source, string destination)
        {
            var wc = new WebClient();
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            wc.DownloadFileAsync(new Uri(source), destination);
        }


        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLabel.Text = e.ProgressPercentage + "% | " + e.BytesReceived + " bytes / " + e.TotalBytesToReceive + " bytes";

            progressBarDownload.Value = e.ProgressPercentage;
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
