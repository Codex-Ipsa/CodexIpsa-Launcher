using MCLauncher.controls;
using MCLauncher.json.api;
using MCLauncher.launchers.fabric;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class ModLoaders : Form
    {
        public ModsGui theModsGui;
        public ModloadersJson manifest;
        public String gameVersion;
        public LoaderType loader;
        public String instanceName;

        public  ModLoaders(String gameVersion, LoaderType loader, String instanceName, ModloadersJson mm, ModsGui modsGui)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //set window title
            if (loader == LoaderType.Forge)
                this.Text = "Install Forge";
            else if (loader == LoaderType.Fabric)
                this.Text = "Install Fabric";
            else if (loader == LoaderType.Babric)
                this.Text = "Install Babric";
            else if (loader == LoaderType.LegacyFabric)
                this.Text = "Install Legacy Fabric";
            else if (loader == LoaderType.Risugami)
                this.Text = "Install Risugami's Modloader";

            //unimplemented
            else if (loader == LoaderType.NeoForge)
                this.Text = "Install Neoforge";
            else if (loader == LoaderType.Quilt)
                this.Text = "Install Quilt";
            else if (loader == LoaderType.LiteLoader)
                this.Text = "Install LiteLoader";

            listView1.Columns[0].Width = -1;
            listView1.Columns[1].Width = -2;

            this.theModsGui = modsGui;
            this.gameVersion = gameVersion;
            this.loader = loader;
            this.instanceName = instanceName;
            this.manifest = mm;

            //load forge versions
            int recommendedVer = 0;
            if (loader == LoaderType.Forge)
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
            else if (loader == LoaderType.Fabric || loader == LoaderType.Babric || loader == LoaderType.LegacyFabric)
            {
                List<String> loaders = FabricWorker.getLoaderVersions(gameVersion, loader);
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
            else if (loader == LoaderType.Risugami)
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
            if (loader == LoaderType.Forge)
            {
                Forge forge = manifest.forge[listView1.SelectedItems[0].Index];

                //json based
                if (forge.type == "json")
                {
                    String forgeManifest = Globals.client.DownloadString(forge.json);
                    forgeManifest = forgeManifest.Replace("{forgeVer}", forge.id).Replace("{forgeUrl}", forge.url).Replace("{forgeSize}", forge.size.ToString());
                    File.WriteAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\minecraftforge-{forge.id}.json", forgeManifest);

                    //add to modlist
                    theModsGui.addModList($"Forge {gameVersion}", forge.id, $"minecraftforge-{forge.id}.json", "json", gameVersion);
                }
                else if (forge.type == "jarmod")
                {
                    //download jarmod zip
                    DownloadProgress.url = forge.url;
                    DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\minecraftforge-{forge.id}.zip";
                    DownloadProgress dp = new DownloadProgress();
                    dp.ShowDialog();

                    //add to modlist
                    String jsonToAdd = gameVersion;
                    if (forge.json != null)
                    {
                        String fileName = forge.json.Substring(forge.json.LastIndexOf('/') + 1);
                        Globals.client.DownloadFile(forge.json, $"{Globals.dataPath}\\data\\json\\{fileName}");
                        jsonToAdd = fileName.Replace(".json", "");
                    }

                    theModsGui.addModList($"Forge {gameVersion}", forge.id, $"minecraftforge-{forge.id}.zip", "jarmod", jsonToAdd);

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
            else if (loader == LoaderType.Fabric || loader == LoaderType.Babric || loader == LoaderType.LegacyFabric)
            {
                String loaderVer = listView1.SelectedItems[0].Text;
                //get mod json
                String moddedJson = FabricWorker.createModJson(gameVersion, loaderVer, loader);

                //get name and ID for saving
                String[] loaderInfo = new String[] { "Fabric", "fabric" };
                if(loader == LoaderType.Babric)
                    loaderInfo = new String[] { "Babric", "babric" };
                else if(loader == LoaderType.LegacyFabric)
                    loaderInfo = new String[] { "Leagcy Fabric", "legacyfabric" };

                //save json
                File.WriteAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{loaderInfo[1]}-{gameVersion}-{loaderVer}.json", moddedJson);

                //add to modlist
                theModsGui.addModList($"{loaderInfo[0]} {gameVersion}", loaderVer, $"{loaderInfo[1]}-{gameVersion}-{loaderVer}.json", "json", gameVersion);
            }
            //download risugami's modloader
            else if (loader == LoaderType.Risugami)
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
                theModsGui.addModList($"Risugami's Modloader", risugami.id, $"modloader-{risugami.id}.zip", "jarmod", gameVersion);
                theModsGui.addModList($"", "", $"modloadermp-{risugami.id}.zip", "jarmod", gameVersion);
            }
            this.Close();
        }

        public enum LoaderType
        {
            None,
            Forge,
            Risugami,
            Fabric, //regular
            Babric, //b1.7.3
            LegacyFabric, //r1.3 - 1.13

            //unimplemented, don't use yet!!
            Quilt,
            NeoForge,
            LiteLoader
        }
    }
}
