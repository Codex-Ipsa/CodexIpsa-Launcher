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
    public partial class DownloadProgressMulti : Form
    {
        WebClient client;
        public DownloadProgressMulti(List<string> urls, List<string> paths, int totalSize)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            progressBarDownload.Maximum = totalSize;
            client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            startDownload(urls, paths, totalSize);
        }

        public void startDownload(List<string> urls, List<string> paths, int totalSize)
        {
            int i = 0;
            foreach(String url in urls)
            {
                client.DownloadFileAsync(new Uri(url), paths[i]);
                //TODO: DOWWNLOAD FILE COMPLETED LIKE IN THE ACCEPTED ANSWER
                //https://stackoverflow.com/questions/2042258/webclient-downloadfileasync-download-files-one-at-a-time
                i++;
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        { 
            progressBarDownload.Value = (int)e.BytesReceived;
        }

            private void cancelBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
