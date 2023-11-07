using MCLauncher.forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static MCLauncher.Strings;

namespace MCLauncher
{
    public partial class ModsRepo : Form
    {
        //TODO: make this use listviews instead you fucking goof
        //current status: crashes LMFAO
        List<RepoJson> repoJsons = new List<RepoJson>();
        ListViewItem lastModSelect;
        ListViewItem lastVerSelect;

        public ModsRepo()
        {
            InitializeComponent();

            ImageList modThumbnails = new ImageList();
            modThumbnails.ImageSize = new Size(16, 16);
            listView1.SmallImageList = modThumbnails;

            string json = Globals.client.DownloadString(Globals.ModRepoManifest);
            repoJsons = JsonConvert.DeserializeObject<List<RepoJson>>(json);

            int i = 0;
            foreach (var r in repoJsons)
            {
                //load thumbnail if exists, if not use some default one
                if (r.thumbnail != null)
                    modThumbnails.Images.Add(Base64ToImage(r.thumbnail));
                else
                    modThumbnails.Images.Add(Base64ToImage("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="));

                listView1.Items.Add(r.name, i);

                if (i == 0)
                {
                    foreach (var t in r.items)
                    {
                        listView2.Items.Add(t.version);
                    }
                }
                i++;
            }
            listView1.Items[0].Selected = true;
            listView1.Select();
            listView2.Items[0].Selected = true;
            listView2.Select();
            listView1.Columns[0].Width = -1;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                listView2.Items.Clear();
                Console.WriteLine(repoJsons[listView1.SelectedIndices[0]].id);
                foreach (RepoInfo item in repoJsons[listView1.SelectedIndices[0]].items)
                {
                    listView2.Items.Add(item.version);
                }
                listView2.Items[0].Selected = true;
                lastModSelect = listView1.SelectedItems[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count > 0) //just in case
            {
                RepoJson r = repoJsons[listView1.SelectedIndices[0]];
                RepoInfo t = r.items[listView2.SelectedIndices[0]];
                Console.WriteLine(repoJsons[listView1.SelectedIndices[0]].items[listView2.SelectedIndices[0]].version);
                Logger.Info("[ModsRepo]", $"{r.id}, {t.version}, {t.url}, {t.json}");

                DownloadProgress.url = t.url;
                DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{r.id}-{t.version}.zip";
                DownloadProgress dp = new DownloadProgress();
                dp.ShowDialog();

                Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", t.json), $"{Globals.dataPath}\\data\\json\\{t.json}.json");
                Profile.modListWorker("add", r.name, t.version, $"{r.id}-{t.version}.zip", t.type, t.json, false);

                Profile.reloadModsList();
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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

    class RepoJson
    {
        public string name { get; set; }
        public string id { get; set; }
        public string thumbnail { get; set; }
        public RepoInfo[] items { get; set; }
    }

    class RepoInfo
    {
        public string version { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string json { get; set; }
    }
}

