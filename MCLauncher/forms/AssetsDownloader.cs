using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MCLauncher.forms
{
    public partial class AssetsDownloader : Form
    {
        public string assetUrl = "";
        public string assetName = "";
        public bool isVirt = false;
        public Dictionary<string, AssetIndexObject> dict = new Dictionary<string, AssetIndexObject>();

        public AssetsDownloader(string assetsUrl, string assetsName)
        {
            assetUrl = assetsUrl;
            assetName = assetsName;
            InitializeComponent();

            //Load lang
            lblDlFiles.Text = Strings.lblDlAssets;
            lblLoading.Text = Strings.lblLoading;

            Logger.Info("[AssetsDownloader]", $"Starting for {assetsName};{assetsUrl}");

            Directory.CreateDirectory($"{Globals.dataPath}\\assets\\indexes\\");
            Globals.client.DownloadFile(assetUrl, $"{Globals.dataPath}\\assets\\indexes\\{assetName}.json");
            string manifest = File.ReadAllText($"{Globals.dataPath}\\assets\\indexes\\{assetName}.json");

            var data = (JObject)JsonConvert.DeserializeObject(manifest);
            dict = JsonConvert.DeserializeObject<Dictionary<string, AssetIndexObject>>(data["objects"].ToString());
            Logger.Info("[AssetsDownloader]", $"Count {dict.Count}");

            if (data["virtual"] != null)
                isVirt = true;
            Logger.Info("[AssetsDownloader]", $"Virtual {isVirt}");

            progressBarDownload.Value = 0;
            progressBarDownload.Maximum = dict.Count;

            backgroundWorker1.RunWorkerAsync();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //TODO cancel without crash lmao
            backgroundWorker1.CancelAsync();
            backgroundWorker1.Dispose();
            Globals.client.Dispose();
            Globals.client = new System.Net.WebClient();
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            foreach (KeyValuePair<string, AssetIndexObject> entry in dict)
            {
                string filePath = "";
                string firstTwo = entry.Value.hash.Substring(0, 2);
                if (isVirt)
                {
                    filePath = $"{Globals.dataPath}/assets/virtual/{assetName}/{entry.Key}";
                }
                else
                {
                    filePath = $"{Globals.dataPath}/assets/objects/{firstTwo}/{entry.Value.hash}";
                }

                if (!File.Exists(filePath))
                {
                    Logger.Info("[AssetIndex]", $"Downloaded {entry.Key}");
                    string path = filePath.Substring(0, filePath.LastIndexOf("/"));
                    Directory.CreateDirectory(path);
                    Globals.client.DownloadFile($"https://resources.download.minecraft.net/{firstTwo}/{entry.Value.hash}", filePath);
                    i++;
                    backgroundWorker1.ReportProgress(i);
                }
                else
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Length != entry.Value.size)
                    {
                        Logger.Error("[AssetIndex]", $"Bad item: {entry.Key} {fi.Length}::{entry.Value.size}");
                        File.Delete(filePath);
                        string path = filePath.Substring(0, filePath.LastIndexOf("/"));
                        Directory.CreateDirectory(path);
                        Globals.client.DownloadFile($"https://resources.download.minecraft.net/{firstTwo}/{entry.Value.hash}", filePath);
                        Logger.Info("[AssetIndex]", $"Redownloaded {entry.Key}");
                    }
                    i++;
                    backgroundWorker1.ReportProgress(i);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            decimal proc = ((decimal)e.ProgressPercentage / (decimal)dict.Count) * 100m;
            lblLoading.Text = $"{(int)proc}% | {e.ProgressPercentage} / {dict.Count} files downloaded";
            progressBarDownload.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
