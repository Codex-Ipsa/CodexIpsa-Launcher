using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class LargeDownloadWarn : Form
    {
        public static Int64 bytesTotal;

        public LargeDownloadWarn()
        {
            InitializeComponent();
            label1.Text = $"Warning! The file you are  trying to download\nis [SIZE] megabytes.\nWish to continue?";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //yes
            // DownloadProgress.largeFile = true;
            DownloadProgress.fileSize = 1;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //no
            //DownloadProgress.largeFile = false;
            DownloadProgress.fileSize = 2;
            this.Hide();
        }
    }
}
