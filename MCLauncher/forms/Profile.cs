﻿using MCLauncher.classes;
using MCLauncher.classes.jsons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MCLauncher.forms
{
    public partial class Profile : Form
    {
        public static string profileName = "";
        public static string version = "b1.7.3";
        public static string edition = "java";
        public static string profMode = "";

        public List<VersionManifest> vj = new List<VersionManifest>();
        public static string lastSelected;
        public static string lastAlt;
        public static string lastDate;
        public static string lastType;
        public static Profile Instance;

        public static bool isInitial;
        public string origName;


        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();


        public Profile(string profile, string mode)
        {
            InitializeComponent();

            Instance = this;
            this.MaximizeBox = false;
            isInitial = true;

            //Load lang
            grbGame.Text = Strings.grbGame;
            lblProfName.Text = Strings.lblProfName;
            lblGameDir.Text = Strings.lblGameDir;
            lblReso.Text = Strings.lblReso;
            lblMem.Text = Strings.lblMem;
            lblMemMax.Text = Strings.lblMemMax;
            lblMemMin.Text = Strings.lblMemMin;
            lblBefCmd.Text = Strings.lblBefCmd;
            lblAftCmd.Text = Strings.lblAftCmd;
            chkProxy.Text = Strings.chkProxy;
            chkUseDemo.Text = Strings.chkUseDemo;
            chkOffline.Text = Strings.chkOffline;
            chkMulti.Text = Strings.chkMulti;
            grbForExp.Text = Strings.grbForExp;
            chkCustJava.Text = Strings.chkCustJava;
            chkCustJson.Text = Strings.chkCustJson;
            chkClasspath.Text = Strings.chkClasspath;
            chkAssetIndex.Text = Strings.chkAssetIndex;
            saveBtn.Text = Strings.btnSaveInst;
            openBtn.Text = Strings.btnOpenDir;
            deleteBtn.Text = Strings.btnDeleteInst;

            btnMoveUp.Text = Strings.btnMoveUp;
            btnMoveDown.Text = Strings.btnMoveDown;
            btnRemove.Text = Strings.btnRemove;
            btnForge.Text = Strings.btnForge;
            btnFabric.Text = Strings.btnFabric;
            btnMLoader.Text = Strings.btnMLoader;
            btnRepos.Text = Strings.btnRepos;
            btnAddToJar.Text = Strings.btnAddToJar;
            btnReplaceJar.Text = Strings.btnReplaceJar;
            btnOpenDotMc.Text = Strings.btnOpenDotMc;

            grbXboxGame.Text = Strings.grbGame;
            chkXboxDemo.Text = Strings.chkUseDemo.Substring(0, Strings.chkUseDemo.IndexOf("("));
            lblXboxProfName.Text = Strings.lblProfName;

            tabControl1.TabPages[0].Text = Strings.cntHome;
            tabControl1.TabPages[1].Text = Strings.tabMods;

            profileName = profile;
            origName = profileName;
            profMode = mode;

            listView1.Columns.Add(Strings.rowName);
            listView1.Columns.Add(Strings.rowType);
            listView1.Columns.Add(Strings.rowReleased);

            if (profMode == "new")
            {
                editionBox.SelectedIndex = editionBox.Items.IndexOf("Java Edition");
                nameBox.Text = profileName;
                xboxNameBox.Text = profileName;
                resXBox.Text = "854";
                resYBox.Text = "480";
                ramMaxBox.Value = 512;
                ramMinBox.Value = 512;
                classBox.Enabled = false;
                jsonBox.Enabled = false;
                jsonBtn.Enabled = false;
                javaBox.Enabled = false;
                javaBtn.Enabled = false;
                assetIndexBox.Enabled = false;
                assetIndexBtn.Enabled = false;
                tabControl1.TabPages.Remove(tabControl1.TabPages[1]);

                string manifest;
                if (!Globals.offlineMode)
                    manifest = Globals.client.DownloadString(Globals.javaManifest);
                else
                    manifest = File.ReadAllText($"{Globals.dataPath}\\data\\downloaded.json");

                vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);
                reloadVerBox("java");

                deleteBtn.Visible = false;
                openBtn.Visible = false;
                exportBtn.Visible = false;
                saveBtn.Text = Strings.createProfile;
            }
            else if (profMode == "def")
            {
                nameBox.Text = profileName;
                xboxNameBox.Text = profileName;
                resXBox.Text = "854";
                resYBox.Text = "480";
                ramMaxBox.Value = 512;
                ramMinBox.Value = 512;
            }
            else if (profMode == "edit")
            {
                string data = File.ReadAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json");
                var dj = JsonConvert.DeserializeObject<ProfileInfo>(data);

                version = dj.version;
                nameBox.Text = profileName;
                xboxNameBox.Text = profileName;
                dirBox.Text = dj.directory;
                string[] res = dj.resolution.Split(' ');
                resXBox.Text = res[0];
                resYBox.Text = res[1];
                string[] mem = dj.memory.Split(' ');
                ramMaxBox.Value = int.Parse(mem[0]);
                ramMinBox.Value = int.Parse(mem[1]);
                befBox.Text = dj.befCmd;
                aftBox.Text = dj.aftCmd;
                chkCustJava.Checked = dj.useJava;
                javaBox.Text = dj.javaPath;
                if (chkCustJava.Checked)
                {
                    javaBox.Enabled = true;
                    javaBtn.Enabled = true;
                }
                else
                {
                    javaBox.Enabled = false;
                    javaBtn.Enabled = false;
                }
                chkCustJson.Checked = dj.useJson;
                jsonBox.Text = dj.jsonPath;
                if (chkCustJson.Checked)
                {
                    jsonBox.Enabled = true;
                    jsonBtn.Enabled = true;
                }
                else
                {
                    jsonBox.Enabled = false;
                    jsonBtn.Enabled = false;
                }
                chkClasspath.Checked = dj.useClass;
                if (chkClasspath.Checked)
                    classBox.Enabled = true;
                else
                    classBox.Enabled = false;
                classBox.Text = dj.classpath;
                chkUseDemo.Checked = dj.demo;
                chkOffline.Checked = dj.offline;
                chkProxy.Checked = dj.disProxy;
                chkMulti.Checked = dj.multiplayer;
                chkXboxDemo.Checked = dj.xboxDemo;
                chkAssetIndex.Checked = dj.useAssets;
                assetIndexBox.Text = dj.assetsPath;
                if (chkAssetIndex.Checked)
                {
                    assetIndexBox.Enabled = true;
                    assetIndexBtn.Enabled = true;
                }
                else
                {
                    assetIndexBox.Enabled = false;
                    assetIndexBtn.Enabled = false;
                }

                if (dj.edition == "x360")
                {
                    edition = "x360";
                    editionBox.SelectedIndex = 2;
                }
                else if (dj.edition == "javaedu")
                {
                    edition = "javaedu";
                    editionBox.SelectedIndex = 1;
                }
                else
                {
                    edition = "java";
                    editionBox.SelectedIndex = 0;
                }

                string manifest = "";
                if (!Globals.offlineMode)
                {
                    if (dj.edition == "java")
                        manifest = Globals.client.DownloadString(Globals.javaManifest);
                    else if (dj.edition == "x360")
                        manifest = Globals.client.DownloadString(Globals.x360Manifest);
                    else if (dj.edition == "javaedu")
                        manifest = Globals.client.DownloadString(Globals.javaEduManifest);
                }
                else
                {
                    manifest = File.ReadAllText($"{Globals.dataPath}\\data\\downloaded.json");
                }

                vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);
                reloadVerBox(dj.edition);

                reloadModsList();
                isInitial = false;
            }

            modView.Columns[0].Text = Strings.rowName;
            modView.Columns[1].Text = Strings.rowType;
            modView.Columns[2].Text = Strings.rowConfig;

            if (profMode == "def")
            {
                listView1.SelectedItems.Clear();
                lastSelected = "b1.7.3";
                saveData();
            }
            else if (profMode == "new")
            {
                var item = listView1.FindItemWithText("b1.7.3");
                listView1.Items[listView1.Items.IndexOf(item)].Selected = true;
                listView1.EnsureVisible(listView1.Items.IndexOf(item));
            }
        }

        public void reloadVerBox(string edition)
        {
            listView1.Items.Clear();

            foreach (var ver in vj)
            {
                string[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy HH:mm:ss") };

                if (edition == "java") //java
                {
                    if (!checkForge.Checked && !checkFabric.Checked && !checkMLoader.Checked)
                    {
                        if (checkPreClassic.Checked && row[0] == "pre-classic")
                            listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                        if (checkClassic.Checked && row[0] == "classic")
                            listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                        if (checkIndev.Checked && row[0] == "indev")
                            listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                        if (checkInfdev.Checked && row[0] == "infdev")
                            listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                        if (checkAlpha.Checked && row[0] == "alpha")
                            listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                        if (checkBeta.Checked && row[0] == "beta")
                            listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                        if (checkRelease.Checked && row[0] == "release")
                            listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                        if (checkSnapshot.Checked && row[0] == "snapshot")
                            listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                        if (checkExperimental.Checked && row[0] == "experimental")
                            listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
                    }
                    else
                    {
                        if (checkForge.Checked)
                        {
                            if (checkBeta.Checked && row[0] == "beta" && checkForge.Checked && ver.forge)
                                listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                            if (checkRelease.Checked && row[0] == "release" && checkForge.Checked && ver.forge)
                                listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                            if (checkSnapshot.Checked && row[0] == "snapshot" && checkForge.Checked && ver.forge)
                                listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
                        }
                        if (checkFabric.Checked)
                        {
                            if (checkRelease.Checked && row[0] == "release" && checkFabric.Checked && ver.fabric)
                                listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                            if (checkSnapshot.Checked && row[0] == "snapshot" && checkFabric.Checked && ver.fabric)
                                listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
                        }

                        if (checkMLoader.Checked)
                        {
                            if (checkAlpha.Checked && row[0] == "alpha" && checkMLoader.Checked && ver.risugami.Contains("true"))
                                listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                            if (checkBeta.Checked && row[0] == "beta" && checkMLoader.Checked && ver.risugami.Contains("true"))
                                listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                            if (checkRelease.Checked && row[0] == "release" && checkMLoader.Checked && ver.risugami.Contains("true"))
                                listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
                        }

                    }
                }
                else //xbox and edu
                {
                    listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
                }
            }
            listView1.Columns[0].Width = -1;
            listView1.Columns[1].Width = -1;
            listView1.Columns[2].Width = -2;

            //select latest loaded version
            if (listView1.Items.Count > 0)
            {
                //Console.WriteLine($"CHECKING FOR \"{version}\"");
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    string ver = Regex.Replace(listView1.Items[i].Text, @"\(.*\)", "");
                    ver = ver.Replace(" ", "");
                    //Console.WriteLine($"\"{ver}\"");
                    if (ver == version)
                    {
                        listView1.Items[i].Selected = true;
                        listView1.TopItem = listView1.Items[i];
                        break;
                    }
                }
            }
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void checkPreClassic_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox("java");
        }

        private void checkClassic_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox("java");
        }

        private void checkIndev_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox("java");
        }

        private void checkInfdev_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox("java");
        }

        private void checkAlpha_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox("java");
        }

        private void checkBeta_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox("java");
        }

        private void checkRelease_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox("java");
        }

        private void checkSnapshot_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox("java");
        }

        private void checkExperimental_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox("java");
        }

        private void checkForge_CheckedChanged(object sender, EventArgs e)
        {
            //checkFabric.Checked = false;
            //checkMLoader.Checked = false;
            reloadVerBox("java");
        }

        private void checkFabric_CheckedChanged(object sender, EventArgs e)
        {
            //checkForge.Checked = false;
            //checkMLoader.Checked = false;
            reloadVerBox("java");
        }

        private void checkMLoader_CheckedChanged(object sender, EventArgs e)
        {
            //checkForge.Checked = false;
            //checkFabric.Checked = false;
            reloadVerBox("java");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                lastSelected = listView1.SelectedItems[0].SubItems[0].Text;

                if (lastSelected.Contains(" ("))
                    lastSelected = lastSelected.Substring(0, lastSelected.IndexOf(" ("));

                if (listView1.SelectedItems[0].SubItems[0].Text.Contains(" ("))
                    lastAlt = listView1.SelectedItems[0].SubItems[0].Text.Split('(', ')')[1];
                else
                    lastAlt = "";

                //get the position of the version in manifest for correct loader buttons
                int res = 0;
                for (int i = 0; i < vj.Count; i++)
                {
                    if (vj[i].id == lastSelected)
                    {
                        res = i;
                        break;
                    }
                }

                //debug prints
                lastType = listView1.SelectedItems[0].SubItems[1].Text;
                lastDate = listView1.SelectedItems[0].SubItems[2].Text;
                lastDate = DateTime.ParseExact(lastDate, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-ddTHH:mm:ss+00:00");
                Logger.Info("[Profile]", $"Selected {lastSelected};{lastType};{lastDate};forge {vj[res].forge};fabric {vj[res].fabric};risugami {vj[res].risugami}");

                //load modloaders
                if (vj[res].forge)
                {
                    btnForge.Enabled = true;
                }
                else
                {
                    btnForge.Enabled = false;
                }

                if (vj[res].fabric)
                {
                    btnFabric.Enabled = true;
                }
                else
                {
                    btnFabric.Enabled = false;
                }
                if(vj[res].risugami != null)
                {
                    if (vj[res].risugami.Contains("true"))
                    {
                        btnMLoader.Enabled = true;
                    }
                    else
                    {
                        btnMLoader.Enabled = false;
                    }
                }
                else
                {
                    btnMLoader.Enabled = false;
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveData();
        }

        public void saveData()
        {
            if (listView1.SelectedIndices.Count == 1)
            {
                version = listView1.SelectedItems[0].SubItems[0].Text;

                if (version.Contains(" ("))
                    version = version.Substring(0, version.IndexOf(" ("));

                string type = listView1.SelectedItems[0].SubItems[1].Text;
                string date = listView1.SelectedItems[0].SubItems[2].Text;
                Logger.Info(this.GetType().Name, $"ver {version}, type {type}, date {date}");
            }
            else
            {
                version = lastSelected;
                if (version.Contains(" ("))
                    version = version.Substring(0, version.IndexOf(" ("));
            }

            profileName = nameBox.Text;

            string saveData = "";
            saveData += $"{{\n";
            saveData += $"  \"data\": 3,\n";
            saveData += $"  \"edition\": \"{edition.Replace("\"", "\\\"")}\",\n";
            saveData += $"  \"version\": \"{version.Replace("\"", "\\\"")}\",\n";
            saveData += $"  \"directory\": \"{dirBox.Text.Replace("\"", "\\\"")}\",\n";
            saveData += $"  \"resolution\": \"{resXBox.Text.Replace("\"", "\\\"")} {resYBox.Text.Replace("\"", "\\\"")}\",\n";
            saveData += $"  \"memory\": \"{ramMaxBox.Value} {ramMinBox.Value}\",\n";
            saveData += $"  \"befCmd\": \"{befBox.Text.Replace("\"", "\\\"")}\",\n";
            saveData += $"  \"aftCmd\": \"{aftBox.Text.Replace("\"", "\\\"")}\",\n";
            saveData += $"  \"useJava\": {chkCustJava.Checked.ToString().ToLower()},\n";
            saveData += $"  \"javaPath\": \"{javaBox.Text.Replace("\"", "\\\"")}\",\n";
            saveData += $"  \"useJson\": {chkCustJson.Checked.ToString().ToLower()},\n";
            saveData += $"  \"jsonPath\": \"{jsonBox.Text.Replace("\"", "\\\"")}\",\n";
            saveData += $"  \"useClass\": {chkClasspath.Checked.ToString().ToLower()},\n";
            saveData += $"  \"classpath\": \"{classBox.Text.Replace("\"", "\\\"")}\",\n";
            saveData += $"  \"demo\": {chkUseDemo.Checked.ToString().ToLower()},\n";
            saveData += $"  \"modded\": false,\n";
            saveData += $"  \"offline\": {chkOffline.Checked.ToString().ToLower()},\n";
            saveData += $"  \"disProxy\": {chkProxy.Checked.ToString().ToLower()},\n";
            saveData += $"  \"multiplayer\": {chkMulti.Checked.ToString().ToLower()},\n";
            saveData += $"  \"xboxDemo\": {chkXboxDemo.Checked.ToString().ToLower()},\n";
            saveData += $"  \"useAssets\": {chkAssetIndex.Checked.ToString().ToLower()},\n";
            saveData += $"  \"assetsPath\": \"{assetIndexBox.Text.Replace("\"", "\\\"")}\"\n";
            saveData += $"}}";

            //remove illegal characters from name
            profileName = profileName.Replace("\\", "")
                .Replace("/", "")
                .Replace(":", "")
                .Replace("*", "")
                .Replace("?", "")
                .Replace("\"", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");

            if (profMode == "new")
            {
                if (Directory.Exists($"{Globals.dataPath}\\instance\\{profileName}"))
                {
                    int iter = 1;
                    do
                    {
                        if (profileName.Contains("_"))
                            profileName = profileName.Substring(0, profileName.LastIndexOf("_")) + "_" + iter;
                        else
                            profileName = profileName + "_" + iter;
                        iter++;
                    }
                    while (Directory.Exists($"{Globals.dataPath}\\instance\\{profileName}"));
                }
            }

            if (origName != profileName && profMode == "edit")
            {
                if (Directory.Exists($"{Globals.dataPath}\\instance\\{profileName}\\"))
                {
                    MessageBox.Show($"A profile with this name already exists, please use a different name.", "Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Logger.Info("[Profile]", "Renaming the profile. This may take a while.");
                    try
                    {
                        Directory.Move($"{Globals.dataPath}\\instance\\{origName}\\", $"{Globals.dataPath}\\instance\\{profileName}\\");
                        File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json", saveData);

                        string tempName = profileName; //loadInstanceList() overwrites profileName, so I had to do this shit lmao
                        HomeScreen.loadInstanceList();
                        HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(tempName);
                        HomeScreen.reloadInstance(tempName);
                    }
                    catch (System.IO.IOException e)
                    {
                        MessageBox.Show($"Could not rename the profile: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Error("[Profile]", $"Could not rename the profile: {e.Message}");
                    }

                    this.Close();
                }
            }
            else
            {
                Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}");
                Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\");
                if (!File.Exists($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\mods.json"))
                {
                    File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\mods.json", $"{{\"data\":1,\"items\":[]}}");
                }

                File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json", saveData);

                string tempName = profileName; //loadInstanceList() overwrites profileName, so I had to do this shit lmao
                HomeScreen.loadInstanceList();
                HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(tempName);
                HomeScreen.reloadInstance(tempName);

                this.Close();
            }
        }

        public bool nameCheck()
        {
            return false;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            Process.Start($"{Globals.dataPath}\\instance\\{profileName}\\");
        }

        private void DirBox_TextChanged(object sender, EventArgs e)
        {
            dirBox.Text = dirBox.Text.Replace("\\", "/");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = $"{Globals.dataPath}\\instance\\{profileName}\\";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    dirBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void ramMinBox_ValueChanged(object sender, EventArgs e)
        {
            if (ramMinBox.Value > ramMaxBox.Value)
            {
                ramMaxBox.Value = ramMinBox.Value;
            }
        }

        private void ramMaxBox_ValueChanged(object sender, EventArgs e)
        {
            if (ramMaxBox.Value < ramMinBox.Value)
            {
                ramMinBox.Value = ramMaxBox.Value;
            }
        }

        private void btnRepo_Click(object sender, EventArgs e)
        {
            PallasRepo pr = new PallasRepo();
            pr.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.zip, *.jar)|*.zip;*.jar";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\");
                    string safeFileName = openFileDialog.SafeFileName;
                    string fileType = safeFileName.Substring(safeFileName.LastIndexOf('.') + 1);
                    safeFileName = safeFileName.Replace("." + fileType, "");

                    //checks if exists and adds a _<int> at the end
                    if (File.Exists($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{safeFileName}.{fileType}"))
                    {
                        int iter = 1;
                        do
                        {
                            if (safeFileName.Contains("_"))
                                safeFileName = safeFileName.Substring(0, safeFileName.LastIndexOf("_")) + "_" + iter;
                            else
                                safeFileName = safeFileName + "_" + iter;
                            iter++;

                            Console.WriteLine($"{safeFileName}.{fileType}   {iter}");
                        }
                        while (File.Exists($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{safeFileName}.{fileType}"));
                    }

                    File.Copy(openFileDialog.FileName, $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{safeFileName}.{fileType}");
                    modListWorker("add", "", "", $"{safeFileName}.{fileType}", "jarmod", "");
                    reloadModsList();
                }
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.jar)|*.jar";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string safeFileName = openFileDialog.SafeFileName;
                    string fileType = safeFileName.Substring(safeFileName.LastIndexOf('.') + 1);
                    safeFileName = safeFileName.Replace("." + fileType, "");

                    //checks if exists and adds a _<int> at the end
                    if (File.Exists($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{safeFileName}.{fileType}"))
                    {
                        int iter = 1;
                        do
                        {
                            if (safeFileName.Contains("_"))
                                safeFileName = safeFileName.Substring(0, safeFileName.LastIndexOf("_")) + "_" + iter;
                            else
                                safeFileName = safeFileName + "_" + iter;
                            iter++;

                            Console.WriteLine($"{safeFileName}.{fileType}   {iter}");
                        }
                        while (File.Exists($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{safeFileName}.{fileType}"));
                    }

                    File.Copy(openFileDialog.FileName, $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{safeFileName}.{fileType}");
                    modListWorker("add", "", "", $"{safeFileName}.{fileType}", "cusjar", "");
                    reloadModsList();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                File.Delete($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{modView.SelectedItems[0].Text}");
                modListWorker("remove", "", "", modView.SelectedItems[0].Text, "", "");
                reloadModsList();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                modListWorker("mdown", "", "", modView.SelectedItems[0].Text, "", "");
                reloadModsList();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                modListWorker("mup", "", "", modView.SelectedItems[0].Text, "", "");
                reloadModsList();
            }
        }

        public static void modListWorker(string mode, string name, string version, string file, string type, string json)
        {
            string indexPath = $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\mods.json";
            if (!File.Exists(indexPath))
                File.WriteAllText(indexPath, $"{{\"data\": 1, \"items\": []}}");
            string jsonFile = File.ReadAllText(indexPath);
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(jsonFile);

            List<ModJsonEntry> entries = new List<ModJsonEntry>();

            foreach (ModJsonEntry ent in mj.items)
            {
                //Logger.Info("[Profile/ModListWorker]", $"{ent.file} {!ent.disabled}");
                entries.Add(ent);
            }

            if (mode == "add")
            {
                ModJsonEntry newEntry = new ModJsonEntry();
                newEntry.name = name;
                newEntry.version = version;
                newEntry.file = file;
                newEntry.type = type;
                newEntry.json = json;
                newEntry.disabled = false;
                entries.Add(newEntry);
            }
            else if (mode == "remove")
            {
                int i = 0;
                foreach (ModJsonEntry ent in mj.items)
                {
                    if (ent.file == file)
                    {
                        break;
                    }
                    i++;
                }
                entries.RemoveAt(i);
            }
            else if (mode == "mup")
            {
                int i = 0;
                ModJsonEntry item = new ModJsonEntry();
                foreach (ModJsonEntry ent in mj.items)
                {
                    if (ent.file == file)
                    {
                        item = ent;
                        break;
                    }
                    i++;
                }
                if (i > 0)
                {
                    entries.RemoveAt(i);
                    entries.Insert(i - 1, item);
                }
            }
            else if (mode == "mdown")
            {
                int i = 0;
                ModJsonEntry item = new ModJsonEntry();
                foreach (ModJsonEntry ent in mj.items)
                {
                    if (ent.file == file)
                    {
                        item = ent;
                        break;
                    }
                    i++;
                }
                if (i + 1 < entries.Count)
                {
                    //Console.WriteLine(i);
                    //Console.WriteLine(entries.Count);
                    entries.RemoveAt(i);
                    //Console.WriteLine(i);
                    //Console.WriteLine(entries.Count);
                    entries.Insert(i + 1, item);
                }
            }

            string toSave = $"{{\n";
            toSave += "  \"data\": 2,";
            toSave += "  \"items\": [\n";
            int y = 0;
            foreach (ModJsonEntry ent in entries)
            {
                toSave += $"    {{\n";
                toSave += $"      \"name\": \"{ent.name}\",\n";
                toSave += $"      \"version\": \"{ent.version}\",\n";
                toSave += $"      \"file\": \"{ent.file}\",\n";
                toSave += $"      \"type\": \"{ent.type}\",\n";
                toSave += $"      \"json\": \"{ent.json}\",\n";
                toSave += $"      \"disabled\": {(ent.disabled).ToString().ToLower()}\n";
                toSave += $"    }},\n";
                y++;
            }
            if (y > 0)
            {
                toSave = toSave.Remove(toSave.LastIndexOf(",")) + "\n";
            }
            toSave += $"  ]\n";
            toSave += $"}}";

            File.WriteAllText(indexPath, toSave);
            //Console.WriteLine(toSave);
        }

        public static void reloadModsList()
        {
            string indexPath = $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\mods.json";
            if (!File.Exists(indexPath))
                File.WriteAllText(indexPath, $"{{\"data\": 1, \"items\": []}}");
            string json = File.ReadAllText(indexPath);
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(json);

            List<ModJsonEntry> entries = new List<ModJsonEntry>();

            foreach (ModJsonEntry ent in mj.items)
            {
                entries.Add(ent);
            }

            Instance.modView.Items.Clear();

            foreach (ModJsonEntry mje in mj.items)
            {
                ListViewItem item = new ListViewItem(new[] { mje.file, mje.type, mje.json });
                item.Checked = !mje.disabled;
                Instance.modView.Items.Add(item);
            }

            Instance.modView.Columns[0].Width = Instance.modView.Width / 2;
            Instance.modView.Columns[1].Width = Instance.modView.Width / 4;
            Instance.modView.Columns[2].Width = -2;
        }

        private void javaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustJava.Checked)
            {
                javaBox.Enabled = true;
                javaBtn.Enabled = true;
            }
            else
            {
                javaBox.Enabled = false;
                javaBtn.Enabled = false;
            }
        }

        private void jsonCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustJson.Checked)
            {
                jsonBox.Enabled = true;
                jsonBtn.Enabled = true;
            }
            else
            {
                jsonBox.Enabled = false;
                jsonBtn.Enabled = false;
            }
        }

        private void classCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClasspath.Checked)
            {
                classBox.Enabled = true;
            }
            else
            {
                classBox.Enabled = false;
            }
        }

        private void JavaBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executables|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                javaBox.Text = ofd.FileName;
            }
        }

        private void JsonBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".JSON files|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                jsonBox.Text = ofd.FileName;
            }
        }

        private void JavaBox_TextChanged(object sender, EventArgs e)
        {
            javaBox.Text = javaBox.Text.Replace("\\", "/");
        }

        private void JsonBox_TextChanged(object sender, EventArgs e)
        {
            jsonBox.Text = jsonBox.Text.Replace("\\", "/");
        }

        private void editionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editionBox.Text.Contains("Xbox 360"))
            {
                edition = "x360";
                javaPanel.Visible = false;
                xboxPanel.Visible = true;

                checkPreClassic.Visible = false;
                checkClassic.Visible = false;
                checkIndev.Visible = false;
                checkInfdev.Visible = false;
                checkAlpha.Visible = false;
                checkBeta.Visible = false;
                checkRelease.Visible = false;
                checkSnapshot.Visible = false;
                checkExperimental.Visible = false;
                checkForge.Visible = false;
                checkFabric.Visible = false;
                checkMLoader.Visible = false;

                string manifest = Globals.client.DownloadString(Globals.x360Manifest);
                vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);
                reloadVerBox("x360");
            }
            else if (editionBox.Text.Contains("MinecraftEdu"))
            {
                edition = "javaedu";
                javaPanel.Visible = true;
                xboxPanel.Visible = false;

                checkPreClassic.Visible = false;
                checkClassic.Visible = false;
                checkIndev.Visible = false;
                checkInfdev.Visible = false;
                checkAlpha.Visible = false;
                checkBeta.Visible = false;
                checkRelease.Visible = false;
                checkSnapshot.Visible = false;
                checkExperimental.Visible = false;
                checkForge.Visible = false;
                checkFabric.Visible = false;
                checkMLoader.Visible = false;

                string manifest = Globals.client.DownloadString(Globals.javaEduManifest);
                vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);
                reloadVerBox("javaedu");
            }
            else
            {
                edition = "java";
                javaPanel.Visible = true;
                xboxPanel.Visible = false;

                checkPreClassic.Visible = true;
                checkClassic.Visible = true;
                checkIndev.Visible = true;
                checkInfdev.Visible = true;
                checkAlpha.Visible = true;
                checkBeta.Visible = true;
                checkRelease.Visible = true;
                checkSnapshot.Visible = true;
                checkExperimental.Visible = true;
                checkForge.Visible = true;
                checkFabric.Visible = true;
                checkMLoader.Visible = true;

                if (!isInitial) //shitty fix but it doesn't crash anymore :troll:
                {
                    string manifest = Globals.client.DownloadString(Globals.javaManifest);
                    vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);
                    reloadVerBox("java");
                }
            }

            Logger.Error("[Profile]", $"EDITION: {edition}");
        }

        private void assetIndexBox_TextChanged(object sender, EventArgs e)
        {
            assetIndexBox.Text = assetIndexBox.Text.Replace("\\", "/");
        }

        private void assetIndexBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".JSON files|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                assetIndexBox.Text = ofd.FileName;
            }
        }

        private void assetIndexBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip.SetToolTip(assetIndexBox, Strings.localOrUrl);
        }

        private void jsonBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip.SetToolTip(jsonBox, Strings.localOrUrl);
        }

        private void chkAssetIndex_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAssetIndex.Checked)
            {
                assetIndexBtn.Enabled = true;
                assetIndexBox.Enabled = true;
            }
            else
            {
                assetIndexBtn.Enabled = false;
                assetIndexBox.Enabled = false;
            }
        }

        private void btnOpenDotMc_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");
            Process.Start($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete this profile?\nYou can't take this back!", "Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Directory.Delete($"{Globals.dataPath}\\instance\\{profileName}", true);
                HomeScreen.loadInstanceList();
                HomeScreen.Instance.cmbInstaces.SelectedIndex = 0;
                this.Close();
            }
        }

        private void xboxNameBox_TextChanged(object sender, EventArgs e)
        {
            nameBox.Text = xboxNameBox.Text;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            xboxNameBox.Text = nameBox.Text;
        }

        private void btnForge_Click(object sender, EventArgs e)
        {
            string temp = Regex.Replace(listView1.SelectedItems[0].Text, @"\(.*\)", "");
            temp = temp.Replace(" ", "");
            ModLoaders ml = new ModLoaders(temp, "forge");
            ml.ShowDialog();
        }

        private void btnFabric_Click(object sender, EventArgs e)
        {
            string temp = Regex.Replace(listView1.SelectedItems[0].Text, @"\(.*\)", "");
            temp = temp.Replace(" ", "");
            ModLoaders ml = new ModLoaders(temp, "fabric");
            ml.ShowDialog();
        }

        private void modView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            for (int i = 0; i < modView.Items.Count; i++)
            {
                string indexPath = $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\mods.json";
                string json = File.ReadAllText(indexPath);
                ModJson mj = JsonConvert.DeserializeObject<ModJson>(json);
                List<ModJsonEntry> entries = new List<ModJsonEntry>();

                mj.items[i].disabled = !modView.Items[i].Checked;

                string outJson = JsonConvert.SerializeObject(mj);
                File.WriteAllText(indexPath, outJson);

            }
        }

        private void btnMLoader_Click(object sender, EventArgs e)
        {
            Console.WriteLine(listView1.SelectedItems[0].Text);
            string temp = Regex.Replace(listView1.SelectedItems[0].Text, @"\(.*\)", "");
            Console.WriteLine(temp);
            temp = temp.Replace(" ", "");

            foreach (var t in vj)
            {
                if (t.id == temp)
                {
                    if (t.risugami == "truemp")
                    {
                        DownloadProgress.url = $"https://codex-ipsa.dejvoss.cz/launcher/modloader/risugami/modloader-{temp}.zip";
                        DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\modloader-{temp}.zip";
                        DownloadProgress dp = new DownloadProgress();
                        dp.ShowDialog();
                        Profile.modListWorker("add", "ModLoader", $"{temp}", $"modloader-{temp}.zip", "jarmod", "");

                        DownloadProgress.url = $"https://codex-ipsa.dejvoss.cz/launcher/modloader/risugami/modloadermp-{temp}.zip";
                        DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\modloadermp-{temp}.zip";
                        DownloadProgress dp2 = new DownloadProgress();
                        dp2.ShowDialog();
                        Profile.modListWorker("add", "", $"", $"modloadermp-{temp}.zip", "jarmod", "");

                        Profile.reloadModsList();
                    }
                    else if (t.risugami == "true")
                    {
                        DownloadProgress.url = $"https://codex-ipsa.dejvoss.cz/launcher/modloader/risugami/modloader-{temp}.zip";
                        DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\modloader-{temp}.zip";
                        DownloadProgress dp = new DownloadProgress();
                        dp.ShowDialog();
                        Profile.modListWorker("add", "ModLoader", $"{temp}", $"modloader-{temp}.zip", "jarmod", "");

                        Profile.reloadModsList();
                    }
                }
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Zip files (*.zip)|*.zip";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Logger.Info("[Profile]", $"Exporting {Profile.profileName}, this may take a while...");
                try
                {
                    using (File.Create(sfd.FileName)) { };

                    using (FileStream zipToOpen = new FileStream(sfd.FileName, FileMode.Open))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                        {
                            string[] files = Directory.GetFiles($"{Globals.dataPath}\\instance\\{Profile.profileName}", "*.*", SearchOption.AllDirectories);
                            foreach (string source in files)
                            {
                                string name = source.Replace($"{Globals.dataPath}\\instance\\{Profile.profileName}\\", "");

                                if (name.Contains("jarmods\\temp") || name.Contains("jarmods\\patch") || name.Contains(".minecraft\\resources") || name.Contains(".minecraft\\logs") || name.EndsWith(".log") || name.EndsWith(".log.gz"))
                                {
                                    continue;
                                }
                                ZipArchiveEntry dirEntry = archive.CreateEntryFromFile(source, name);
                                Logger.Info("[Profile]", $"Loaded file {name}");
                            }
                        }
                        zipToOpen.Dispose();
                    }
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show($"Could not export the profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.Error("[Profile]", $"Could not export the profile: {ex.Message}");
                }

                Logger.Info("[Profile]", $"Done!");
            }
        }

        private void iconBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG files|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(ofd.FileName, $"{Globals.dataPath}\\instance\\{Profile.profileName}\\icon.png");
            }
        }
    }

    public class VersionManifest
    {
        public string id { get; set; }
        public string alt { get; set; }
        public string type { get; set; }
        public DateTime released { get; set; }
        public bool forge { get; set; }
        public bool fabric { get; set; }
        public string risugami { get; set; }
    }

    public class ProfileInfo
    {
        public int data { get; set; }
        public string edition { get; set; }
        public string version { get; set; }
        public string directory { get; set; }
        public string resolution { get; set; }
        public string memory { get; set; }
        public string befCmd { get; set; }
        public string aftCmd { get; set; }
        public bool useJava { get; set; }
        public string javaPath { get; set; }
        public bool useJson { get; set; }
        public string jsonPath { get; set; }
        public bool useClass { get; set; }
        public string classpath { get; set; }
        public bool demo { get; set; }
        public bool offline { get; set; }
        public bool disProxy { get; set; }
        public bool multiplayer { get; set; }
        public bool xboxDemo { get; set; }
        public bool useAssets { get; set; }
        public string assetsPath { get; set; }
    }
}
