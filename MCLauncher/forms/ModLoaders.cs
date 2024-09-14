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

            //set window title
            if (loader == "forge")
                this.Text = "Install Forge";
            else if (loader == "fabric")
                this.Text = "Install Fabric";
            else if (loader == "risugami")
                this.Text = "Install Risugami's Modloader";
            else if (loader == "neoforge")
                this.Text = "Install Neoforge";
            else if (loader == "quilt")
                this.Text = "Install Quilt";
            else if (loader == "liteloader")
                this.Text = "Install LiteLoader";

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
            else if (loader == "risugami")
            {
                for (int i = 0; i < manifest.risugami.Count(); i++)
                {
                    Risugami r = manifest.risugami[i];

                    int icon = -1;
                    if (i == 0)
                        icon = 0;
                    else
                        icon = -1;

                    listView1.Items.Add(r.id, icon);
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
                if (forge.type == "json")
                {
                    String forgeManifest = Globals.client.DownloadString(forge.json);
                    forgeManifest = forgeManifest.Replace("{forgeVer}", forge.id).Replace("{forgeUrl}", forge.url).Replace("{forgeSize}", forge.size.ToString());
                    File.WriteAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\minecraftforge-{forge.id}.json", forgeManifest);

                    //add to modlist
                    theModsGui.addModList($"Forge {version}", forge.id, $"minecraftforge-{forge.id}.json", "json", version);
                }
                else if (forge.type == "jarmod")
                {
                    //download jarmod zip
                    DownloadProgress.url = forge.url;
                    DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\minecraftforge-{forge.id}.zip";
                    DownloadProgress dp = new DownloadProgress();
                    dp.ShowDialog();

                    //add to modlist
                    theModsGui.addModList($"Forge {version}", forge.id, $"minecraftforge-{forge.id}.zip", "jarmod", version);

                    //download supplement(s) if they exist
                    if (forge.supplement != null)
                    {
                        foreach (Forge sup in forge.supplement)
                        {
                            //download
                            DownloadProgress.url = sup.url;
                            DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{sup.id}.zip";
                            dp = new DownloadProgress();
                            dp.ShowDialog();

                            //add to modlist
                            theModsGui.addModList("", "", $"{sup.id}.zip", sup.type, sup.json);
                        }
                    }
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
                theModsGui.addModList($"Fabric {version}", loaderVer, $"fabric-{version}-{loaderVer}.json", "json", version);
            }
            //download risugami's modloader
            else if (loader == "risugami")
            {
                Risugami risugami = manifest.risugami[listView1.SelectedItems[0].Index];

                //download risugami
                DownloadProgress.url = risugami.url;
                DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\modloader-{risugami.id}.zip";
                DownloadProgress download = new DownloadProgress();
                download.ShowDialog();

                //download modloadermp if available
                if (risugami.urlmp != null)
                {
                    DownloadProgress.url = risugami.urlmp;
                    DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\modloadermp-{risugami.id}.zip";
                    DownloadProgress download2 = new DownloadProgress();
                    download2.ShowDialog();
                }

                //add to modlist
                theModsGui.addModList($"Risugami's Modloader", risugami.id, $"modloader-{risugami.id}.zip", "jarmod", version);
                theModsGui.addModList($"", "", $"modloadermp-{risugami.id}.zip", "jarmod", version);
            }
            this.Close();
        }
    }
}
