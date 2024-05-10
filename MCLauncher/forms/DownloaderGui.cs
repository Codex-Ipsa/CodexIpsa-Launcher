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

namespace MCLauncher.forms
{
    public partial class DownloaderGui : Form
    {
        public double totalSize = 0;
        public DownloaderGui(List<DownloadObject> download)
        {
            InitializeComponent();

            foreach (var h in download)
            {
                WebClient client = new WebClient();
                client.OpenRead(h.url);
                double bytes_total = Convert.ToDouble(client.ResponseHeaders["Content-Length"]);
                totalSize += bytes_total;
            }

            ProgressLabel.Text = $"0 / {totalSize} bytes";
        }
    }

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
