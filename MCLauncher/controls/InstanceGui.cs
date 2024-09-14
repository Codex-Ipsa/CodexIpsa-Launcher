using MCLauncher.json.api;
using MCLauncher.json.launcher;
using MCLauncher.launchers.fabric;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MCLauncher.controls
{
    public partial class InstanceGui : UserControl
    {
        public Form parentForm;
        public String selectedVersion;
        public bool isEdit1 = false;
        public String originalName;

        public long playTime;

        public InstanceGui(Form form, bool isEdit)
        {
            InitializeComponent();

            parentForm = form;
            isEdit1 = isEdit;

            //load lang
            grbGame.Text = Strings.sj.grbGame;
            lblProfName.Text = Strings.sj.lblProfName;
            lblGameDir.Text = Strings.sj.lblGameDir;
            lblReso.Text = Strings.sj.lblReso;
            lblMem.Text = Strings.sj.lblMem;
            lblMemMax.Text = Strings.sj.lblMemMax;
            lblMemMin.Text = Strings.sj.lblMemMin;
            lblJvmArgs.Text = Strings.sj.lblBefCmd;
            lblGameArgs.Text = Strings.sj.lblAftCmd;
            chkProxy.Text = Strings.sj.chkProxy;
            chkUseDemo.Text = Strings.sj.chkUseDemo;
            chkOffline.Text = Strings.sj.chkOffline;
            chkMulti.Text = Strings.sj.chkMulti;
            grbForExp.Text = Strings.sj.grbForExp;
            chkCustJava.Text = Strings.sj.chkCustJava;
            chkCustJson.Text = Strings.sj.chkCustJson;
            chkClasspath.Text = Strings.sj.chkClasspath;
            chkAssetIndex.Text = Strings.sj.chkAssetIndex;
            chkServerIP.Text = Strings.sj.chkServerIP;
            saveBtn.Text = Strings.sj.btnSaveInst;
            deleteBtn.Text = Strings.sj.btnDeleteInst;
            openBtn.Text = Strings.sj.btnOpenDir;

            grbXbox.Text = Strings.sj.grbGame;
            chkXboxDemo.Text = Strings.sj.chkUseDemo.Substring(0, Strings.sj.chkUseDemo.IndexOf(" ("));
            lblXboxProfName.Text = Strings.sj.lblProfName;

            chkLatest.Text = Strings.sj.chooseLatestRelease;
            chkLatestSnapshot.Text = Strings.sj.chooseLatestSnapshot;

            if (!isEdit)
            {
                saveBtn.Text = Strings.sj.createProfile;

                deleteBtn.Visible = false;
                openBtn.Visible = false;
            }

            loadJavaList();
            loadEduList();
            loadXboxList();
        }

        public void loadJavaList()
        {
            //clear list
            vanillaList.Items.Clear();
            vanillaList.Columns.Clear();

            //add columns
            vanillaList.Columns.Add(Strings.sj.rowName);
            vanillaList.Columns.Add(Strings.sj.rowType);
            vanillaList.Columns.Add(Strings.sj.rowReleased);

            //add items
            String manifest = Globals.client.DownloadString(Globals.javaManifest);
            List<VersionListJson> jm = JsonConvert.DeserializeObject<List<VersionListJson>>(manifest);
            foreach (VersionListJson ver in jm)
            {
                String[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy") }; //dd.MM.yyyy HH:mm:ss

                if (vanillaPreclassic.Checked && row[0] == "pre-classic")
                    vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                if (vanillaClassic.Checked && row[0] == "classic")
                    vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                if (vanillaIndev.Checked && row[0] == "indev")
                    vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                if (vanillaInfdev.Checked && row[0] == "infdev")
                    vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                if (vanillaAlpha.Checked && row[0] == "alpha")
                    vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                if (vanillaBeta.Checked && row[0] == "beta")
                    vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                if (vanillaRelease.Checked && row[0] == "release")
                    vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                if (vanillaSnapshot.Checked && row[0] == "snapshot")
                    vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                if (vanillaExperimental.Checked && row[0] == "experimental")
                    vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
            }

            //set width after adding items
            vanillaList.Columns[0].Width = -1;
            vanillaList.Columns[1].Width = -1;
            vanillaList.Columns[2].Width = -2;

            //select first item
            if (vanillaList.Items.Count > 0)
            {
                vanillaList.Items[0].Selected = true;
                vanillaList.TopItem = vanillaList.Items[0];
            }
        }

        public void loadEduList()
        {
            //clear list
            eduList.Items.Clear();
            eduList.Columns.Clear();

            //add columns
            eduList.Columns.Add(Strings.sj.rowName);
            eduList.Columns.Add(Strings.sj.rowType);
            eduList.Columns.Add(Strings.sj.rowReleased);

            //add items
            String manifest = Globals.client.DownloadString(Globals.javaEduManifest);
            List<VersionListJson> jm = JsonConvert.DeserializeObject<List<VersionListJson>>(manifest);
            foreach (VersionListJson ver in jm)
            {
                String[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy HH:mm:ss") };

                eduList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
            }

            //set width after adding items
            eduList.Columns[0].Width = -1;
            eduList.Columns[1].Width = -1;
            eduList.Columns[2].Width = -2;

            //select first item
            eduList.Items[0].Selected = true;
            eduList.TopItem = eduList.Items[0];
        }

        public void loadXboxList()
        {
            //clear list
            xboxList.Items.Clear();
            xboxList.Columns.Clear();

            //add columns
            xboxList.Columns.Add(Strings.sj.rowName);
            xboxList.Columns.Add(Strings.sj.rowType);
            xboxList.Columns.Add(Strings.sj.rowReleased);

            //add items
            String manifest = Globals.client.DownloadString(Globals.x360Manifest);
            List<VersionListJson> jm = JsonConvert.DeserializeObject<List<VersionListJson>>(manifest);
            foreach (VersionListJson ver in jm)
            {
                String[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy HH:mm:ss") };

                xboxList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
            }

            //set width after adding items
            xboxList.Columns[0].Width = -1;
            xboxList.Columns[1].Width = -1;
            xboxList.Columns[2].Width = -2;

            //select first item
            xboxList.Items[0].Selected = true;
            xboxList.TopItem = xboxList.Items[0];
        }

        //Finds and selects a version in the ver list
        public void selectInList(ListView list, String name)
        {
            Logger.Info("[InstanceGui/selectInList]", $"Searching for {name}...");

            int pos = 0;
            for (int i = list.Items.Count - 1; i > 0; i--)
            {
                String thisVer = list.Items[i].Text.Split()[0]; //removes (alt) text
                if (thisVer == name)
                {
                    pos = i;
                    break;
                }
            }

            //selects the version
            Logger.Info("[InstanceGui/selectInList]", $"Found {name} at pos: {pos}");
            list.Items[pos].Selected = true;
            list.TopItem = list.Items[pos];
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //create instance json
            InstanceJson ij = new InstanceJson();
            ij.data = 3;
            ij.edition = "java";

            if (tabControl1.SelectedTab.Text == "Xbox 360")
                ij.edition = "x360";
            else if (tabControl1.SelectedTab.Text == "MinecraftEdu")
                ij.edition = "javaedu";

            ij.version = selectedVersion;
            if (chkLatest.Checked)
                ij.version = "latest";
            else if (chkLatestSnapshot.Checked)
                ij.version = "latestsnapshot";

            ij.directory = dirBox.Text; //TODO CHECK FOR INVALID
            ij.resolution = $"{resXBox.Text} {resYBox.Text}";
            ij.memory = $"{ramMaxBox.Value} {ramMinBox.Value}";
            ij.befCmd = jvmArgsBox.Text;
            ij.aftCmd = gameArgsBox.Text;

            ij.disProxy = chkProxy.Checked;
            ij.demo = chkUseDemo.Checked;
            ij.offline = chkOffline.Checked;
            ij.multiplayer = chkMulti.Checked;

            ij.useJava = chkCustJava.Checked;
            ij.javaPath = javaBox.Text;
            ij.useJson = chkCustJson.Checked;
            ij.jsonPath = jsonBox.Text;
            ij.useClass = chkClasspath.Checked;
            ij.classpath = classBox.Text;
            ij.useAssets = chkAssetIndex.Checked;
            ij.assetsPath = assetIndexBox.Text;
            ij.useServerIP = chkServerIP.Checked;
            ij.serverIP = serverIPBox.Text;

            ij.xboxDemo = chkXboxDemo.Checked;

            ij.playTime = this.playTime;

            string json = JsonConvert.SerializeObject(ij);

            //get profile name
            string profileName = nameBox.Text;

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

            //check if profile already exists => add _X
            if (!isEdit1 || originalName != profileName)
            {
                string newName = profileName;
                int iter = 1;
                while (Directory.Exists($"{Globals.dataPath}\\instance\\{newName}"))
                {
                    newName = profileName + "_" + iter;
                    iter++;
                }
                profileName = newName;
            }

            //move old profile if renaming
            if (isEdit1)
            {
                if (!String.IsNullOrEmpty(originalName))
                {
                    if (profileName != originalName)
                    {
                        Logger.Info("[InstanceGui]", $"Renaming instance {originalName} -> {profileName}...");
                        Directory.Move($"{Globals.dataPath}\\instance\\{originalName}", $"{Globals.dataPath}\\instance\\{profileName}");
                    }
                }
            }

            //create directories
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}");
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\");

            //write profile json
            File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json", json);

            //if isnt edit stuff
            if (!isEdit1)
            {
                //create modjson
                ModJson mj = new ModJson();
                mj.items = new ModJsonEntry[0];

                String modJson = JsonConvert.SerializeObject(mj);
                File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\mods.json", modJson);
            }

            HomeScreen.loadInstanceList();
            HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(profileName);
            HomeScreen.reloadInstance(profileName);

            parentForm.Close();
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            xboxNameBox.Text = nameBox.Text;
        }

        private void xboxNameBox_TextChanged(object sender, EventArgs e)
        {
            nameBox.Text = xboxNameBox.Text;
        }

        private void ramMaxBox_ValueChanged(object sender, EventArgs e)
        {
            if (ramMaxBox.Value < ramMinBox.Value)
            {
                ramMinBox.Value = ramMaxBox.Value;
            }
        }

        private void ramMinBox_ValueChanged(object sender, EventArgs e)
        {
            if (ramMinBox.Value > ramMaxBox.Value)
            {
                ramMaxBox.Value = ramMinBox.Value;
            }
        }

        private void chkClasspath_CheckedChanged(object sender, EventArgs e)
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

        private void chkCustJson_CheckedChanged(object sender, EventArgs e)
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

        private void chkCustJava_CheckedChanged(object sender, EventArgs e)
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

        private void chkAssetIndex_CheckedChanged(object sender, EventArgs e)
        {
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
        }

        private void chkServerIP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServerIP.Checked)
            {
                serverIPBox.Enabled = true;
            }
            else
            {
                serverIPBox.Enabled = false;
            }
        }

        private void dirBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = $"{Globals.dataPath}\\instance\\";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    dirBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void jsonBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".JSON files|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                jsonBox.Text = ofd.FileName;
            }
        }

        private void javaBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executables|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                javaBox.Text = ofd.FileName;
            }
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

        private void vanillaCheck_CheckedChanged(object sender, EventArgs e)
        {
            loadJavaList();
        }

        private void chkLatest_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLatest.Checked)
            {
                vanillaRelease.Checked = true;

                for (int i = 0; i < vanillaList.Items.Count; i++)
                {
                    if (vanillaList.Items[i].SubItems[1].Text == "release")
                    {
                        vanillaList.Items[i].Selected = true;
                        vanillaList.Items[i].EnsureVisible();
                        break;
                    }
                }

                vanillaList.Enabled = false;
                chkLatestSnapshot.Checked = false;

                selectedVersion = "latest";
            }
            else
            {
                if (chkLatestSnapshot.Checked)
                    vanillaList.Enabled = false;
                else
                    vanillaList.Enabled = true;
            }
        }

        private void chkLatestSnapshot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLatestSnapshot.Checked)
            {
                vanillaSnapshot.Checked = true;

                for (int i = 0; i < vanillaList.Items.Count; i++)
                {
                    if (vanillaList.Items[i].SubItems[1].Text == "snapshot" || vanillaList.Items[i].SubItems[1].Text == "release")
                    {
                        vanillaList.Items[i].Selected = true;
                        vanillaList.Items[i].EnsureVisible();
                        break;
                    }
                }

                vanillaList.Enabled = false;
                chkLatest.Checked = false;

                selectedVersion = "latestsnapshot";
            }
            else
            {
                if (chkLatest.Checked)
                    vanillaList.Enabled = false;
                else
                    vanillaList.Enabled = true;
            }
        }

        private void vanillaList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = vanillaList.Columns[e.ColumnIndex].Width;
        }

        private void eduList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = eduList.Columns[e.ColumnIndex].Width;
        }

        private void xboxList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = xboxList.Columns[e.ColumnIndex].Width;
        }

        private void vanillaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vanillaList.SelectedItems.Count > 0)
            {
                selectedVersion = vanillaList.SelectedItems[0].Text;

                if (selectedVersion.Contains(" ("))
                    selectedVersion = selectedVersion.Substring(0, selectedVersion.IndexOf(" ("));

                Logger.Info("{TEST!!}", FabricWorker.getFabricName(selectedVersion));
            }
        }

        private void eduList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eduList.SelectedItems.Count > 0)
            {
                selectedVersion = eduList.SelectedItems[0].Text;

                if (selectedVersion.Contains(" ("))
                    selectedVersion = selectedVersion.Substring(0, selectedVersion.IndexOf(" ("));
            }
        }

        private void xboxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xboxList.SelectedItems.Count > 0)
            {
                selectedVersion = xboxList.SelectedItems[0].Text;

                if (selectedVersion.Contains(" ("))
                    selectedVersion = selectedVersion.Substring(0, selectedVersion.IndexOf(" ("));
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete this profile?\nYou can't take this back!", "Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Directory.Delete($"{Globals.dataPath}\\instance\\{nameBox.Text}", true);
                HomeScreen.loadInstanceList();
                HomeScreen.Instance.cmbInstaces.SelectedIndex = 0;
                parentForm.Close();
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            Process.Start($"{Globals.dataPath}\\instance\\{nameBox.Text}\\");
        }
    }
}
