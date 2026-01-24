using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class AssetsDownloader : Form
    {
        public string assetName = "";
        public bool isVirt = false;
        public Dictionary<string, AssetIndexObject> dict = new Dictionary<string, AssetIndexObject>();
        public WebClient assetClient = new WebClient();

        public bool doWork = true;

        public AssetsDownloader(string assetsUrl, string assetsName)
        {
            Uri assetUrl = new Uri(assetsUrl);
            assetName = assetsName;

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //Load lang
            lblDlFiles.Text = Strings.sj.lblDlAssets;
            lblLoading.Text = Strings.sj.lblLoading;
            cancelBtn.Text = Strings.sj.btnCancel;

            Logger.Info("[AssetsDownloader]", $"Starting for {assetsName};{assetsUrl}");

            Directory.CreateDirectory($"{Globals.dataPath}\\assets\\indexes\\");
            //if it's a local file copy it
            if (assetUrl.Scheme == "file")
            {
                File.Copy(assetUrl.LocalPath, $"{Globals.dataPath}\\assets\\indexes\\{assetName}.json", true);
            }
            else //else just dl from link
            {
                assetClient.DownloadFile(assetUrl, $"{Globals.dataPath}\\assets\\indexes\\{assetName}.json");
            }
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
            assetClient.Dispose();
            doWork = false;
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            Logger.Info("AssetIndex", $"Downloading assets... This may take a while...");
            foreach (KeyValuePair<string, AssetIndexObject> entry in dict)
            {
                if (!doWork)
                {
                    break;
                }
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
                    if (Globals.isDebug)
                        Logger.Info("[AssetIndex]", $"Downloaded {entry.Key}");

                    string path = filePath.Substring(0, filePath.LastIndexOf("/"));
                    Directory.CreateDirectory(path);
                    if (entry.Value.custom_url != null)  //custom_url was  in some old BC/Ipsa jsons, keeping it to not break them ig 
                        assetClient.DownloadFile($"{entry.Value.custom_url}", filePath);
                    else if (entry.Value.url != null)
                        assetClient.DownloadFile($"{entry.Value.url}", filePath);
                    else
                        assetClient.DownloadFile($"https://resources.download.minecraft.net/{firstTwo}/{entry.Value.hash}", filePath);
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
                        if (entry.Value.custom_url != null)
                            assetClient.DownloadFile($"{entry.Value.custom_url}", filePath); //custom_url was  in some old BC/Ipsa jsons, keeping it to not break them ig
                        else if (entry.Value.url != null)
                            assetClient.DownloadFile($"{entry.Value.url}", filePath);
                        else
                            assetClient.DownloadFile($"https://resources.download.minecraft.net/{firstTwo}/{entry.Value.hash}", filePath);
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

    public class AssetIndexManifest
    {
        public AssetIndexObject objects { get; set; }
        public bool isVirtual { get; set; }
    }

    public class AssetIndexObject
    {
        public int size { get; set; }
        public string hash { get; set; }
        public string custom_url { get; set; }
        public String url { get; set; }
    }

}
