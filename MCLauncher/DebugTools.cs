using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MCLauncher
{
    public partial class DebugTools : Form
    {
        public static bool cstJava = false;
        public static string newPath = $"{Globals.currentPath}\\bin\\java\\bin\\java.exe";
        public static string dlLink;
        public static string dlVer;

        public DebugTools()
        {
            InitializeComponent();
            if(cstJava == false)
            {
                checkBox1.Checked = false;
                LaunchJava.javaLocation = "java.exe";
            }
            else
            {
                checkBox1.Checked = true;
                LaunchJava.javaLocation = newPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\java");

            using (var client = new WebClient())
            {
                string json = client.DownloadString(Globals.jre8Link);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    dlLink = vers.jreLink;
                    dlVer = vers.jreVer;
                }
            }

            if (!File.Exists($"{Globals.currentPath}\\bin\\java\\ver.txt"))
            {
                using (StreamWriter writer = new StreamWriter($"{Globals.currentPath}\\bin\\java\\ver.txt"))
                {
                    writer.Write(dlVer);
                }

                using (var client = new WebClient())
                {
                    DownloadProgress.url = dlLink;
                    DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\java\\java.zip";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();
                }

                ZipFile.ExtractToDirectory($"{Globals.currentPath}\\bin\\java\\java.zip", $"{Globals.currentPath}\\bin\\java");
                File.Delete($"{Globals.currentPath}\\bin\\java\\java.zip");
            }
            else
            {
                //TODO: CHECK FOR UPDATES
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                cstJava = false;
                LaunchJava.javaLocation = "java.exe";
            }
            else
            {
                cstJava = true;
                LaunchJava.javaLocation = newPath;
            }
        }
    }
}
