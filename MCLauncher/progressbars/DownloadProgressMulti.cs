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
            client = new WebClient();
            startDownload(urls, paths, totalSize);
        }

        public void startDownload(List<string> urls, List<string> paths, int totalSize)
        {
            int i = 0;
            foreach(string url in urls)
            {

                i++;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
