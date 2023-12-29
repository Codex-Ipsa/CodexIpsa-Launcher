using MCLauncher.classes.ipsajson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MCLauncher.forms
{
    public partial class ModLoaders : Form
    {
        public List<ModLoaderManifest> mj;
        public string loaderType = "";
        public string gameVersion = "";

        public ModLoaders(string version, string loader)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            listView1.Columns[0].Width = 100;
            listView1.Columns[1].Width = -2;

            loaderType = loader;
            gameVersion = version;

            if (loader == "fabric")
            {
                List<string> versions = FabricParser.GetList();
                foreach (string ver in versions)
                    listView1.Items.Add(ver);
                //foreach (ModLoaderItem item in m.items)
                //{
                //    listView1.Items.Add(new ListViewItem(new[] { item.id.Replace("minecraftforge-", ""), item.released.Replace("T", " ") }));
                //}
            }
            else
            {
                string jsonFile = Globals.client.DownloadString(Globals.Modloaders.Replace("{ver}", version));
                mj = JsonConvert.DeserializeObject<List<ModLoaderManifest>>(jsonFile);
                foreach (ModLoaderManifest m in mj)
                {
                    if (m.name == "forge" && loader == "forge")
                    {
                        foreach (ModLoaderItem item in m.items)
                        {
                            listView1.Items.Add(new ListViewItem(new[] { item.id.Replace("minecraftforge-", ""), item.released.Replace("T", " ") }));
                        }
                    }
                    else if (m.name == "modloader" && loader == "modloader")
                    {
                        //foreach (ModLoaderItem item in m.items)
                        //{
                        //    listView1.Items.Add(new ListViewItem(new[] { item.id.Replace("minecraftforge-", ""), item.released.Replace("T", " ") }));
                        //}
                    }
                }
            }

            listView1.Select();
            listView1.Items[0].Selected = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(loaderType == "fabric")
            {
                string newJson = FabricParser.versionJson(gameVersion, listView1.SelectedItems[0].Text);

                File.WriteAllText($"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\fabric-loader-{gameVersion}-{listView1.SelectedItems[0].Text}.json", newJson);

                Profile.modListWorker("add", "Fabric", $"{gameVersion}-{listView1.SelectedItems[0].Text}", $"fabric-loader-{gameVersion}-{listView1.SelectedItems[0].Text}.json", "json", "");
                Profile.reloadModsList();
            }
            else if(loaderType == "forge")
            {
                ModLoaderItem item = mj[0].items[listView1.SelectedItems[0].Index];
                Console.WriteLine(item.id);

                string ext = ".zip";
                if (item.type == "json")
                    ext = ".json";

                string[] split = item.id.Replace("minecraftforge-", "").Split(new[] { '-' }, 2);
                string forgeVersion = split[1];
                string gameVersion = split[0];
                Logger.Error("[ModLoaders]", $"item.id; {item.id} forgeVer; {forgeVersion} gameVer; {gameVersion}");

                Logger.Error("[ModLoaders]", $"item url; {item.url} gmver; {gameVersion}");

                if (item.type == "json")
                {
                    Logger.Error("[ModLoaders]", $"CALLED!!!");
                    DownloadProgress.url = $"https://codex-ipsa.dejvoss.cz/launcher/modloader/forge/minecraftforge-{gameVersion}.json";
                }
                else
                    DownloadProgress.url = item.url;

                Logger.Error("[ModLoaders]", $"dp url; {DownloadProgress.url}");

                DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{item.id}{ext}";
                DownloadProgress dp = new DownloadProgress();
                dp.ShowDialog();

                if(item.type == "json")
                {
                    string original = File.ReadAllText($"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{item.id}{ext}");
                    string updated = original.Replace("{forgeVer}", forgeVersion).Replace("{forgeUrl}", item.url);
                    File.WriteAllText($"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{item.id}{ext}", updated);
                }

                Profile.modListWorker("add", "Forge", forgeVersion, $"{item.id}{ext}", item.type, item.json);
                Profile.reloadModsList();
            }

            this.Close();
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
