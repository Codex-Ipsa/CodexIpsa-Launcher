﻿using MCLauncher.controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class PallasRepo : Form
    {
        List<PallasManifest> pallasMods = new List<PallasManifest>();
        List<PallasVersion> pallasVersions = new List<PallasVersion>();

        public static ModsGui theModsGui;

        public PallasRepo(ModsGui modsGui)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            modListView.Columns[0].Width = -1;

            theModsGui = modsGui;

            //img list properties
            ImageList modThumbnails = new ImageList();
            modThumbnails.ImageSize = new Size(32, 32);
            modListView.SmallImageList = modThumbnails;
            modListView.SmallImageList.ColorDepth = ColorDepth.Depth16Bit;

            //get avvailable mods
            string pallasManifest = Globals.client.DownloadString(Globals.PallasManifest);
            pallasMods = JsonConvert.DeserializeObject<List<PallasManifest>>(pallasManifest);

            int i = 0;
            foreach (PallasManifest mod in pallasMods)
            {
                //set thumbnails
                if (!string.IsNullOrWhiteSpace(mod.thumbnail))
                    modThumbnails.Images.Add(Base64ToImage(mod.thumbnail));
                else
                    modThumbnails.Images.Add(Base64ToImage("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="));

                //add mods to listview
                modListView.Items.Add(mod.name, i);
                i++;
            }

            modListView.Items[0].Selected = true;
        }

        private void modListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count > 0)
            {
                //load browser stuff
                comboBox1.Items.Clear();
                string id = pallasMods[modListView.SelectedItems[0].Index].id;
                Logger.Info("[PallasRepo]", pallasMods[modListView.SelectedItems[0].Index].id);
                webBrowser1.Navigate(new Uri($"http://pallas.dejvoss.cz/{id}/info.html"));

                //load versions
                string pallasVersion = Globals.client.DownloadString($"http://pallas.dejvoss.cz/{id}/manifest.json");
                pallasVersions = JsonConvert.DeserializeObject<List<PallasVersion>>(pallasVersion);
                int latestVer = 0;
                int x = 0;
                foreach (PallasVersion ver in pallasVersions)
                {
                    if (ver.latest)
                        latestVer = x;

                    comboBox1.Items.Add(ver.version);
                    x++;
                }
                //set latest ver
                comboBox1.SelectedIndex = latestVer;
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count > 0)
            {
                //download mod
                string id = pallasMods[modListView.SelectedItems[0].Index].id;
                string name = pallasMods[modListView.SelectedItems[0].Index].name;
                bool isntMod = pallasMods[modListView.SelectedItems[0].Index].isntMod;

                string version = pallasVersions[comboBox1.SelectedIndex].version;
                string url = pallasVersions[comboBox1.SelectedIndex].url;
                string json = pallasVersions[comboBox1.SelectedIndex].json;
                string type = pallasVersions[comboBox1.SelectedIndex].type;
                string[] supplement = pallasVersions[comboBox1.SelectedIndex].supplement;

                Logger.Info("[PallasRepo]", $"{id}, {version}, {url}, {json}");

                if (isntMod) //temp? this looks better since you can't fit in "Omniarchive April Fools 2023 c0.0.12a_03-asbestos" LMAO
                {
                    name = "Minecraft";
                }

                if (!string.IsNullOrWhiteSpace(url))
                {
                    if (File.Exists($"{Globals.dataPath}\\instance\\{theModsGui.instanceName}\\jarmods\\{id}-{version}.zip"))
                    {
                        File.Delete($"{Globals.dataPath}\\instance\\{theModsGui.instanceName}\\jarmods\\{id}-{version}.zip");
                        theModsGui.removeModList($"{id}-{version}.zip");
                    }

                    DownloadProgress.url = url;
                    DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{theModsGui.instanceName}\\jarmods\\{id}-{version}.zip";
                    DownloadProgress dp = new DownloadProgress();
                    dp.ShowDialog();

                    Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", json).Replace("{type}", "java"), $"{Globals.dataPath}\\data\\json\\{json}.json");
                    theModsGui.addModList(name, version, $"{id}-{version}.zip", type, json);
                }
                else //assume it's a json type mod if there's no url
                {
                    if (File.Exists($"{Globals.dataPath}\\instance\\{theModsGui.instanceName}\\jarmods\\{id}-{version}.json"))
                    {
                        File.Delete($"{Globals.dataPath}\\instance\\{theModsGui.instanceName}\\jarmods\\{id}-{version}.json");
                        theModsGui.removeModList($"{id}-{version}.zip");
                    }

                    Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", json).Replace("{type}", "java"), $"{Globals.dataPath}\\instance\\{theModsGui.instanceName}\\jarmods\\{id}-{version}.json");
                    theModsGui.addModList(name, version, $"{id}-{version}.zip", type, json);
                }

                //get supplements
                if (supplement != null)
                {
                    foreach (string sup in supplement)
                    {
                        string fileName = sup.Substring(sup.LastIndexOf('/') + 1);
                        DownloadProgress.url = sup;
                        DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{theModsGui.instanceName}\\jarmods\\{fileName}";
                        DownloadProgress dp = new DownloadProgress();
                        dp.ShowDialog();

                        theModsGui.addModList("", "", fileName, "jarmod", "");
                    }
                }

                theModsGui.saveModList();
                theModsGui.reloadModList();

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

        public static string[] checkForUpdate(String instanceName, string checkName, string checkVersion)
        {
            string pallasManifest = Globals.client.DownloadString(Globals.PallasManifest);
            List<PallasManifest> pallasMods = JsonConvert.DeserializeObject<List<PallasManifest>>(pallasManifest);

            foreach (PallasManifest mod in pallasMods)
            {
                if (mod.name == checkName)
                {
                    if (mod.isntMod == true)
                    {
                        return null;
                    }

                    string pallasVersion = Globals.client.DownloadString($"http://pallas.dejvoss.cz/{mod.id}/manifest.json");
                    List<PallasVersion> pallasVersions = JsonConvert.DeserializeObject<List<PallasVersion>>(pallasVersion);
                    foreach (PallasVersion ver in pallasVersions)
                    {
                        if (ver.latest == true)
                        {
                            if (checkVersion != ver.version)
                            {
                                DialogResult dialogResult = MessageBox.Show($"Update {ver.version} of {mod.name} is available!\nWould you like to download it?", "Mod update available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    DownloadMod(instanceName, mod, ver, checkVersion);
                                    return new string[] { ver.version, ver.json, $"{mod.id}-{ver.version}.zip", ver.type };
                                }
                            }
                            else
                            {
                                if (ver.version == "latest")
                                {
                                    WebClient client = new WebClient();
                                    client.OpenRead(ver.url);
                                    Int64 bytes_total = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
                                    Int64 existFile = new FileInfo($"{Globals.dataPath}\\instance\\{theModsGui.instanceName}\\jarmods\\{mod.id}-{checkVersion}.zip").Length;

                                    if (bytes_total != existFile)
                                    {
                                        DialogResult dialogResult = MessageBox.Show($"Update {ver.version} of {mod.name} is available!\nWould you like to download it?", "Mod update available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            DownloadMod(instanceName, mod, ver, checkVersion);
                                            return new string[] { ver.version, ver.json, $"{mod.id}-{ver.version}.zip", ver.type };
                                        }
                                    }
                                }

                                Logger.Info("[PallasRepo/Update]", $"{mod.id} is up to date");
                            }
                        }
                    }
                }
            }
            return null;
        }

        //update mod and remove old version
        public static void DownloadMod(String instanceName, PallasManifest mod, PallasVersion ver, string checkVersion)
        {
            theModsGui = new ModsGui(instanceName);

            Logger.Info("[PallasRepo/DownloadMod]", $"{mod.id}, {ver.version}, {ver.url}, {ver.json}");

            File.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{mod.id}-{checkVersion}.zip");
            theModsGui.removeModList($"{mod.id}-{checkVersion}.zip");

            DownloadProgress.url = ver.url;
            DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{mod.id}-{ver.version}.zip";
            DownloadProgress dp = new DownloadProgress();
            dp.ShowDialog();

            Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", ver.json).Replace("{type}", "java"), $"{Globals.dataPath}\\data\\json\\{ver.json}.json");
            theModsGui.addModList(mod.name, ver.version, $"{mod.id}-{ver.version}.zip", ver.type, ver.json);
            HomeScreen.selectedVersion = $"{mod.name} {ver.version}";
            HomeScreen.Instance.lblReady.Text = Strings.sj.lblReady.Replace("{verInfo}", HomeScreen.selectedVersion);
        }
    }

    public class PallasManifest
    {
        public string name { get; set; }
        public string id { get; set; }
        public string thumbnail { get; set; }
        public string author { get; set; }
        public bool isntMod { get; set; }
    }

    public class PallasVersion
    {
        public string version { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string json { get; set; }
        public bool latest { get; set; }
        public string[] supplement { get; set; }
    }
}
