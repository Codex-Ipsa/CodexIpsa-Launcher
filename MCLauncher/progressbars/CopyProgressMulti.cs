using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.progressbars
{
    public partial class CopyProgressMulti : Form
    {
        WebClient wc;
        int entireSize;
        int downloaded;
        public CopyProgressMulti(List<string> source, List<string> destination, int fullSize)
        {
            InitializeComponent();
            progressBarDownload.Maximum = fullSize;
            entireSize = fullSize;
            wc = new WebClient();
            Worker(source, destination);
        }

        public void Worker(List<string> source, List<string> destination)
        {
            int i = 0;
            foreach(string s in source)
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                Console.WriteLine($"Copying {s}...");
                wc.DownloadFileAsync(new Uri(s), destination[i]);
                i++;
            }
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLabel.Text = e.ProgressPercentage + "% | " + e.BytesReceived + " bytes / " + entireSize + " bytes";

            //progressBarDownload.Value += (int)e.BytesReceived;
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
