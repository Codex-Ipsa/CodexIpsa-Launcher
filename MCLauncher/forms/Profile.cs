using MCLauncher.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

                string manifest = Globals.client.DownloadString(Globals.javaManifest);
                vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);
                reloadVerBox("java");

                deleteBtn.Visible = false;
                openBtn.Visible = false;
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
                if (dj.edition == "java")
                    manifest = Globals.client.DownloadString(Globals.javaManifest);
                else if (dj.edition == "x360")
                    manifest = Globals.client.DownloadString(Globals.x360Manifest);
                else if (dj.edition == "javaedu")
                    manifest = Globals.client.DownloadString(Globals.javaEduManifest);

                vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);
                reloadVerBox(dj.edition);

                reloadModsList();
                isInitial = false;
            }

            modView.Columns[0].Text = Strings.rowName;
            modView.Columns[1].Text = Strings.rowType;
            modView.Columns[2].Text = Strings.rowConfig;
            modView.Columns[3].Text = Strings.rowUpdate;

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

                if (edition == "java")
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
                    listView1.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
                }
            }
            listView1.Columns[0].Width = -1;
            listView1.Columns[1].Width = -1;
            listView1.Columns[2].Width = -2;

            if (listView1.Items.Count > 0)
            {
                var item = listView1.FindItemWithText(version, true, 0, false);

                if (item != null)
                {
                    listView1.Items[listView1.Items.IndexOf(item)].Selected = true;
                    listView1.EnsureVisible(listView1.Items.IndexOf(item));
                    saveBtn.Enabled = true;
                }
                else if (listView1.Items.Count == 0)
                    saveBtn.Enabled = false;
                else
                {
                    item = listView1.FindItemWithText(version, true, 0);
                    if (item != null)
                    {
                        saveBtn.Enabled = true;
                        listView1.Items[listView1.Items.IndexOf(item)].Selected = true;
                        listView1.EnsureVisible(listView1.Items.IndexOf(item));
                    }
                    else
                    {
                        listView1.Items[0].Selected = true;
                        listView1.EnsureVisible(listView1.Items[0].Index);
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

                lastType = listView1.SelectedItems[0].SubItems[1].Text;
                lastDate = listView1.SelectedItems[0].SubItems[2].Text;
                lastDate = DateTime.ParseExact(lastDate, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-ddTHH:mm:ss+00:00");
                Console.WriteLine($"{lastSelected};{lastType};{lastDate}");

                //load modloaders
                if (vj[listView1.SelectedItems[0].Index].forge)
                {
                    btnForge.Enabled = true;
                }
                else
                {
                    btnForge.Enabled = false;
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
            saveData += $"  \"edition\": \"{edition}\",\n";
            saveData += $"  \"version\": \"{version}\",\n";
            saveData += $"  \"directory\": \"{dirBox.Text}\",\n";
            saveData += $"  \"resolution\": \"{resXBox.Text} {resYBox.Text}\",\n";
            saveData += $"  \"memory\": \"{ramMaxBox.Value} {ramMinBox.Value}\",\n";
            saveData += $"  \"befCmd\": \"{befBox.Text}\",\n";
            saveData += $"  \"aftCmd\": \"{aftBox.Text}\",\n";
            saveData += $"  \"useJava\": {chkCustJava.Checked.ToString().ToLower()},\n";
            saveData += $"  \"javaPath\": \"{javaBox.Text}\",\n";
            saveData += $"  \"useJson\": {chkCustJson.Checked.ToString().ToLower()},\n";
            saveData += $"  \"jsonPath\": \"{jsonBox.Text}\",\n";
            saveData += $"  \"useClass\": {chkClasspath.Checked.ToString().ToLower()},\n";
            saveData += $"  \"classpath\": \"{classBox.Text}\",\n";
            saveData += $"  \"demo\": {chkUseDemo.Checked.ToString().ToLower()},\n";
            saveData += $"  \"modded\": false,\n";
            saveData += $"  \"offline\": {chkOffline.Checked.ToString().ToLower()},\n";
            saveData += $"  \"disProxy\": {chkProxy.Checked.ToString().ToLower()},\n";
            saveData += $"  \"multiplayer\": {chkMulti.Checked.ToString().ToLower()},\n";
            saveData += $"  \"xboxDemo\": {chkXboxDemo.Checked.ToString().ToLower()},\n";
            saveData += $"  \"useAssets\": {chkAssetIndex.Checked.ToString().ToLower()},\n";
            saveData += $"  \"assetsPath\": \"{assetIndexBox.Text}\"\n";
            saveData += $"}}";

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
                    Directory.Move($"{Globals.dataPath}\\instance\\{origName}\\", $"{Globals.dataPath}\\instance\\{profileName}\\");
                    File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json", saveData);

                    string tempName = profileName; //loadInstanceList() overwrites profileName, so I had to do this shit lmao
                    HomeScreen.loadInstanceList();
                    HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(tempName);
                    HomeScreen.reloadInstance(tempName);

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
            ModsRepo mr = new ModsRepo();
            mr.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.zip, *.jar)|*.zip;*.jar";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\");
                    File.Copy(openFileDialog.FileName, $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{openFileDialog.SafeFileName}");
                    modListWorker("add", "", "", openFileDialog.SafeFileName, "jarmod", "", false);
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
                    File.Copy(openFileDialog.FileName, $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{openFileDialog.SafeFileName}");
                    modListWorker("add", "", "", openFileDialog.SafeFileName, "cusjar", "", false);
                    reloadModsList();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                File.Delete($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{modView.SelectedItems[0].Text}");
                modListWorker("remove", "", "", modView.SelectedItems[0].Text, "", "", false);
                reloadModsList();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                modListWorker("mdown", "", "", modView.SelectedItems[0].Text, "", "", false);
                reloadModsList();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                modListWorker("mup", "", "", modView.SelectedItems[0].Text, "", "", false);
                reloadModsList();
            }
        }

        public static void modListWorker(string mode, string name, string version, string file, string type, string json, bool update)
        {
            string indexPath = $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\mods.json";
            if (!File.Exists(indexPath))
                File.WriteAllText(indexPath, $"{{\"data\": 1, \"items\": []}}");
            string jsonFile = File.ReadAllText(indexPath);
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(jsonFile);

            List<ModJsonEntry> entries = new List<ModJsonEntry>();

            foreach (ModJsonEntry ent in mj.items)
            {
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
                newEntry.update = update;
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
                    Console.WriteLine(i);
                    Console.WriteLine(entries.Count);
                    entries.RemoveAt(i);
                    Console.WriteLine(i);
                    Console.WriteLine(entries.Count);
                    entries.Insert(i + 1, item);
                }
            }

            string toSave = $"{{\n";
            toSave += "  \"data\": 1,";
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
                toSave += $"      \"update\": {ent.update.ToString().ToLower()}\n";
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
            Console.WriteLine(toSave);
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
                ListViewItem item = new ListViewItem(new[] { mje.file, mje.type, mje.json, mje.update.ToString() });
                Instance.modView.Items.Add(item);
            }

            Instance.modView.Columns[0].Width = Instance.modView.Width / 3;
            Instance.modView.Columns[1].Width = Instance.modView.Width / 4;
            Instance.modView.Columns[2].Width = Instance.modView.Width / 4;
            Instance.modView.Columns[3].Width = -2;
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

                string manifest = Globals.client.DownloadString(Globals.javaEduManifest);
                vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);
                reloadVerBox("java");
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
            ModLoaders ml = new ModLoaders(Globals.Modloaders.Replace("{ver}", temp));
            ml.ShowDialog();
        }
    }

    public class VersionManifest
    {
        public string id { get; set; }
        public string alt { get; set; }
        public string type { get; set; }
        public DateTime released { get; set; }
        public bool forge { get; set; }
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

    class ModJson
    {
        public int data { get; set; }
        public ModJsonEntry[] items { get; set; }
    }

    class ModJsonEntry
    {
        public string name { get; set; }
        public string version { get; set; }
        public string file { get; set; }
        public string type { get; set; }
        public string json { get; set; }
        public bool update { get; set; }
    }
}
