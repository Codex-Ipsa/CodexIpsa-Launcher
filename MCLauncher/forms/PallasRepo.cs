using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class PallasRepo : Form
    {
        List<PallasManifest> pallasMods = new List<PallasManifest>();
        List<PallasVersions> pallasVersions = new List<PallasVersions>();

        public PallasRepo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ImageList modThumbnails = new ImageList();
            modThumbnails.ImageSize = new Size(32, 32);
            modListView.SmallImageList = modThumbnails;

            string pallasManifest = Globals.client.DownloadString(Globals.PallasManifest);
            pallasMods = JsonConvert.DeserializeObject<List<PallasManifest>>(pallasManifest);

            int i = 0;
            foreach (PallasManifest mod in pallasMods)
            {
                if (mod.thumbnail != null)
                    modThumbnails.Images.Add(Base64ToImage(mod.thumbnail));
                else
                    modThumbnails.Images.Add(Base64ToImage("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="));

                modListView.Items.Add(mod.name, i);
                i++;
            }
        }

        private void modListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count > 0)
            {
                comboBox1.Items.Clear();
                string id = pallasMods[modListView.SelectedItems[0].Index].id;
                Logger.Info("[PallasRepo]", pallasMods[modListView.SelectedItems[0].Index].id);
                webBrowser1.Navigate(new Uri($"http://pallas.dejvoss.cz/{id}/info.html"));

                string pallasVersion = Globals.client.DownloadString($"http://pallas.dejvoss.cz/{id}/manifest.json");
                pallasVersions = JsonConvert.DeserializeObject<List<PallasVersions>>(pallasVersion);
                int latestVer = 0;
                int x = 0;
                foreach (PallasVersions ver in pallasVersions)
                {
                    if (ver.latest)
                        latestVer = x;

                    comboBox1.Items.Add(ver.version);
                    x++;
                }
                comboBox1.SelectedIndex = latestVer;
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count > 0)
            {
                string id = pallasMods[modListView.SelectedItems[0].Index].id;
                string name = pallasMods[modListView.SelectedItems[0].Index].name;

                string version = pallasVersions[comboBox1.SelectedIndex].version;
                string url = pallasVersions[comboBox1.SelectedIndex].url;
                string json = pallasVersions[comboBox1.SelectedIndex].json;
                string type = pallasVersions[comboBox1.SelectedIndex].type;

                Logger.Info("[PallasRepo]", $"{id}, {version}, {url}, {json}");

                DownloadProgress.url = url;
                DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{id}-{version}.zip";
                DownloadProgress dp = new DownloadProgress();
                dp.ShowDialog();

                Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", json), $"{Globals.dataPath}\\data\\json\\{json}.json");
                Profile.modListWorker("add", name, version, $"{id}-{version}.zip", type, json, false);

                Profile.reloadModsList();
                this.Close();
            }
        }

        public Image Base64ToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            bytes.Reverse();

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }
    }

    class PallasManifest
    {
        public string name { get; set; }
        public string id { get; set; }
        public string thumbnail { get; set; }
        public string author { get; set; }
    }

    class PallasVersions
    {
        public string version { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string json { get; set; }
        public bool latest { get; set; }
    }
}
