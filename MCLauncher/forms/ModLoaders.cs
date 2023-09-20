using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class ModLoaders : Form
    {
        public List<ModLoaderManifest> mj;

        public ModLoaders(string url)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            listView1.Columns[0].Width = 100;
            listView1.Columns[1].Width = -2;

            string jsonFile = Globals.client.DownloadString(url);
            mj = JsonConvert.DeserializeObject<List<ModLoaderManifest>>(jsonFile);
            foreach(ModLoaderManifest m in mj)
            {
                if(m.name == "forge")
                {
                    foreach(ModLoaderItem item in m.items)
                    {
                        listView1.Items.Add(new ListViewItem(new[] { item.id.Replace("minecraftforge-1.5.2-", ""), item.released }));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModLoaderItem item = mj[0].items[listView1.SelectedItems[0].Index];
            Console.WriteLine(item.id);

            DownloadProgress.url = item.url;
            DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{item.id}.zip";
            DownloadProgress dp = new DownloadProgress();
            dp.ShowDialog();

            string version = item.id.Substring(item.id.IndexOf('-') + 1);
            Profile.modListWorker("add", "Forge", version, $"{item.id}.zip", item.type, item.json, false);
            Profile.reloadModsList();
            //WIP
        }
    }

    public class ModLoaderManifest
    {
        public string name { get; set; }
        public ModLoaderItem[] items { get; set; }
    }

    public class ModLoaderItem
    {
        public string id { get; set; }
        public string json { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string released { get; set; }
        public bool recommended { get; set; }
    }
}
