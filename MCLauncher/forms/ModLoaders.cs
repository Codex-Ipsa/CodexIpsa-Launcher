using MCLauncher.classes.ipsajson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MCLauncher.forms
{
    public partial class ModLoaders : Form
    {
        public ModloadersManifest manifest;
        public String version;
        public String loader;
        public String instanceName;

        public ModLoaders(String version, String loader, String instanceName, ModloadersManifest mm)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            listView1.Columns[0].Width = -1;
            listView1.Columns[1].Width = -2;

            this.version = version;
            this.loader = loader;
            this.instanceName = instanceName;
            this.manifest = mm;

            if (loader == "forge")
            {
                foreach (var t in manifest.forge)
                {
                    int icon = -1;
                    if(t.recommended)
                        icon = 0;

                    String[] item = new String[] { t.released };
                    listView1.Items.Add(t.id, icon).SubItems.AddRange(item);
                }
            }


            listView1.Select();
            listView1.Items[0].Selected = true;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            //download forge
            if (loader == "forge")
            {
                if (manifest.forge[listView1.SelectedItems[0].Index].type == "json")
                {
                    List<DownloadObject> list = new List<DownloadObject>();
                    list.Add(new DownloadObject(manifest.forge[listView1.SelectedItems[0].Index].url, $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\minecrafforge-{manifest.forge[listView1.SelectedItems[0].Index].id}.zip"));
                    list.Add(new DownloadObject(manifest.forge[listView1.SelectedItems[0].Index].url, $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\minecrafforge-{manifest.forge[listView1.SelectedItems[0].Index].id}.zip"));
                    DownloaderGui dg = new DownloaderGui(list);
                    dg.ShowDialog();

                    //TODO
                    //Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", json).Replace("{type}", "java"), $"{Globals.dataPath}\\data\\json\\{json}.json");
                    //theModsGui.addModList(name, version, $"{id}-{version}.zip", type, json);
                }
                else //type == jarmod
                {
                    //DownloadProgress.url = manifest.forge[listView1.SelectedItems[0].Index].url;
                    //DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{id}-{version}.zip";
                    //DownloadProgress dp = new DownloadProgress();
                    //dp.ShowDialog();

                }
            }
            this.Close();
        }
    }
}
