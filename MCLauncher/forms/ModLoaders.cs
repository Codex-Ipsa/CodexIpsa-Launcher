using MCLauncher.controls;
using MCLauncher.json.api;
using MCLauncher.launchers.fabric;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class ModLoaders : Form
    {
        public ModsGui theModsGui;
        public ModloadersJson manifest;
        public String version;
        public String loader;
        public String instanceName;

        public ModLoaders(String version, String loader, String instanceName, ModloadersJson mm, ModsGui modsGui)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            listView1.Columns[0].Width = -1;
            listView1.Columns[1].Width = -2;

            this.theModsGui = modsGui;
            this.version = version;
            this.loader = loader;
            this.instanceName = instanceName;
            this.manifest = mm;

            //load forge versions
            int recommendedVer = 0;
            if (loader == "forge")
            {
                for (int i = 0; i < manifest.forge.Count(); i++)
                {
                    Forge f = manifest.forge[i];

                    //get recommended version
                    int icon = -1;
                    if (f.recommended)
                    {
                        icon = 0;
                        recommendedVer = i;
                    }

                    //add to list
                    String[] item = new String[] { f.released };
                    listView1.Items.Add(f.id, icon).SubItems.AddRange(item);
                }
            }
            else if (loader == "fabric")
            {
                List<String> loaders = FabricWorker.getLoaderVersions(version);
                for (int i = 0; i < loaders.Count(); i++)
                {
                    int icon = -1;
                    if (i == 0)
                        icon = 0;
                    else
                        icon = -1;

                    listView1.Items.Add(loaders[i], icon);
                }

                recommendedVer = 0; //always recommend latest
            }

            //select recommended version
            listView1.Select();
            listView1.Items[recommendedVer].Selected = true;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            //download forge
            if (loader == "forge")
            {
                Forge forge = manifest.forge[listView1.SelectedItems[0].Index];

                //json based
                if (manifest.forge[listView1.SelectedItems[0].Index].type == "json")
                {
                    String forgeManifest = Globals.client.DownloadString(forge.json);
                    forgeManifest = forgeManifest.Replace("{forgeVer}", forge.id).Replace("{forgeUrl}", forge.url).Replace("{forgeSize}", forge.size.ToString());
                    File.WriteAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\minecraftforge-{forge.id}.json", forgeManifest);

                    //add to modlist
                    theModsGui.addModList($"Forge {version}", forge.id, $"minecraftforge-{forge.id}.json", "json", "");
                }
                else //type == jarmod
                {
                    //DownloadProgress.url = manifest.forge[listView1.SelectedItems[0].Index].url;
                    //DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{id}-{version}.zip";
                    //DownloadProgress dp = new DownloadProgress();
                    //dp.ShowDialog();
                }
            }
            //download fabric
            else if (loader == "fabric")
            {
                String loaderVer = listView1.SelectedItems[0].Text;
                //get mod json
                String moddedJson = FabricWorker.createModJson(version, loaderVer);
                
                //save json
                File.WriteAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\fabric-{version}-{loaderVer}.json", moddedJson);

                //add to modlist
                theModsGui.addModList($"Fabric {version}", loaderVer, $"fabric-{version}-{loaderVer}.json", "json", "");
            }
            this.Close();
        }
    }
}
