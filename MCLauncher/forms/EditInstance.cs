using MCLauncher.classes.jsons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class EditInstance : Form
    {
        public string lastSelected = "";
        ToolTip toolTip = new ToolTip();
        public string instanceName = "";

        public EditInstance(String instanceName)
        {
            InitializeComponent();

            this.instanceName = instanceName;

            //disable resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

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
            saveBtn.Text = Strings.sj.btnSaveInst;

            grbXbox.Text = Strings.sj.grbGame;
            chkXboxDemo.Text = Strings.sj.chkUseDemo.Substring(0, Strings.sj.chkUseDemo.IndexOf(" ("));
            lblXboxProfName.Text = Strings.sj.lblProfName;

            chkLatest.Text = Strings.sj.chooseLatestRelease;
            chkLatestSnapshot.Text = Strings.sj.chooseLatestSnapshot;

            tabHome.Text = Strings.sj.cntHome;
            tabMods.Text = Strings.sj.tabMods;

            //get instance data
            String profileJson = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\instance.json");
            InstanceJson ij = JsonConvert.DeserializeObject<InstanceJson>(profileJson);

            //fill in stuff
            if (ij.edition == "x360")
                tabControl2.SelectedIndex = 2;
            else if (ij.edition == "javaedu")
                tabControl2.SelectedIndex = 1;
            else
                tabControl2.SelectedIndex = 0;

            lastSelected = ij.version;

            nameBox.Text = instanceName;
            dirBox.Text = ij.directory; //TODO CHECK FOR INVALID
            String[] res = ij.resolution.Split(new char[] { ' ' });
            resXBox.Text = res[0];
            resYBox.Text = res[1];
            String[] mem = ij.memory.Split(new char[] { ' ' });
            ramMaxBox.Value = int.Parse(mem[0]);
            ramMinBox.Value = int.Parse(mem[1]);
            jvmArgsBox.Text = ij.befCmd;
            gameArgsBox.Text = ij.aftCmd;

            chkProxy.Checked = ij.disProxy;
            chkUseDemo.Checked = ij.demo;
            chkOffline.Checked = ij.offline;
            chkMulti.Checked = ij.multiplayer;

            chkCustJava.Checked = ij.useJava;
            javaBox.Enabled = ij.useJava;
            javaBox.Text = ij.javaPath;

            chkCustJson.Checked = ij.useJson;
            jsonBox.Enabled = ij.useJson;
            jsonBox.Text = ij.jsonPath;

            chkClasspath.Checked = ij.useClass;
            classBox.Enabled = ij.useClass;
            classBox.Text = ij.classpath;

            chkAssetIndex.Checked = ij.useAssets;
            assetIndexBox.Enabled = ij.useAssets;
            assetIndexBox.Text = ij.assetsPath;

            chkXboxDemo.Checked = ij.xboxDemo;

            //latest and latestsnapshot stuff
            if (lastSelected.Contains("latest"))
            {
                if (lastSelected == "latest")
                {
                    chkLatest.Checked = true;
                }
                else if (lastSelected == "latestsnapshot")
                {
                    chkLatestSnapshot.Checked = true;
                }

                lastSelected = HomeScreen.getLatestVersion(lastSelected);
                vanillaList.Enabled = false;
            }

            //TODO LOAD MOD JSON

            //fill in edition specific stuff
            populateLists();
        }

        private void populateLists()
        {
            //vanilla list
            if (tabControl2.SelectedTab.Text == "Vanilla")
            {
                //clear list
                vanillaList.Items.Clear();
                vanillaList.Columns.Clear();

                //add columns
                vanillaList.Columns.Add(Strings.sj.rowName);
                vanillaList.Columns.Add(Strings.sj.rowType);
                vanillaList.Columns.Add(Strings.sj.rowReleased);

                //add items
                string manifest = Globals.client.DownloadString(Globals.javaManifest);
                List<JavaManifest> jm = JsonConvert.DeserializeObject<List<JavaManifest>>(manifest);
                foreach (JavaManifest ver in jm)
                {
                    string[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy") }; //dd.MM.yyyy HH:mm:ss

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

                //select latest loaded version
                if (vanillaList.Items.Count > 0)
                {
                    Console.WriteLine("AAAAAAAA " + lastSelected);
                    for (int i = vanillaList.Items.Count - 1; i >= 0; i--)
                    {
                        string ver = Regex.Replace(vanillaList.Items[i].Text, @"\(.*\)", "");
                        ver = ver.Replace(" ", "");

                        if (ver == lastSelected)
                        {
                            vanillaList.Items[i].Selected = true;
                            vanillaList.TopItem = vanillaList.Items[i];
                            break;
                        }
                    }
                }
            }

            //edu list
            else if (tabControl2.SelectedTab.Text == "MinecraftEdu")
            {
                //clear list
                eduList.Items.Clear();
                eduList.Columns.Clear();

                //add columns
                eduList.Columns.Add(Strings.sj.rowName);
                eduList.Columns.Add(Strings.sj.rowType);
                eduList.Columns.Add(Strings.sj.rowReleased);

                //add items
                string manifest = Globals.client.DownloadString(Globals.javaEduManifest);
                List<JavaManifest> jm = JsonConvert.DeserializeObject<List<JavaManifest>>(manifest);
                foreach (JavaManifest ver in jm)
                {
                    string[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy HH:mm:ss") };

                    eduList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
                }

                //set width after adding items
                eduList.Columns[0].Width = -1;
                eduList.Columns[1].Width = -1;
                eduList.Columns[2].Width = -2;

                //select first version
                eduList.Items[0].Selected = true;
                eduList.TopItem = eduList.Items[0];
            }

            //xbox list
            else if (tabControl2.SelectedTab.Text == "Xbox 360")
            {
                //clear list
                xboxList.Items.Clear();
                xboxList.Columns.Clear();

                //add columns
                xboxList.Columns.Add(Strings.sj.rowName);
                xboxList.Columns.Add(Strings.sj.rowType);
                xboxList.Columns.Add(Strings.sj.rowReleased);

                //add items
                string manifest = Globals.client.DownloadString(Globals.x360Manifest);
                List<JavaManifest> jm = JsonConvert.DeserializeObject<List<JavaManifest>>(manifest);
                foreach (JavaManifest ver in jm)
                {
                    string[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy HH:mm:ss") };

                    xboxList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
                }

                //set width after adding items
                xboxList.Columns[0].Width = -1;
                xboxList.Columns[1].Width = -1;
                xboxList.Columns[2].Width = -2;

                //select first version
                xboxList.Items[0].Selected = true;
                xboxList.TopItem = xboxList.Items[0];
            }
        }

        //save instance
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

            ij.version = lastSelected;

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

            ij.xboxDemo = chkXboxDemo.Checked;
            string json = JsonConvert.SerializeObject(ij);

            //create mod json
            ModJson mj = new ModJson();
            mj.data = 1;
            mj.items = new ModJsonEntry[0];
            string modJson = JsonConvert.SerializeObject(mj);

            //remove illegal characters from name
            string profileName = nameBox.Text.Replace("\\", "")
                .Replace("/", "")
                .Replace(":", "")
                .Replace("*", "")
                .Replace("?", "")
                .Replace("\"", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");

            //TODO RENAME PROFILE IF THE NAME CHANGED

            //create directories
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}");
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\");

            //write files
            File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json", json);
            File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\mods.json", modJson);

            HomeScreen.loadInstanceList();
            HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(profileName);
            HomeScreen.reloadInstance(profileName);

            this.Close();
        }

        private void vanillaBoxes_CheckedChanged(object sender, EventArgs e)
        {
            populateLists();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //populateLists();

            if (tabControl1.SelectedTab.Text == "Xbox 360")
            {
                grbGame.Visible = false;
                grbForExp.Visible = false;
                grbXbox.Visible = true;
            }
            else
            {
                grbGame.Visible = true;
                grbForExp.Visible = true;
                grbXbox.Visible = false;
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

        private void vanillaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vanillaList.SelectedItems.Count > 0)
            {
                lastSelected = vanillaList.SelectedItems[0].Text;

                if (lastSelected.Contains(" ("))
                    lastSelected = lastSelected.Substring(0, lastSelected.IndexOf(" ("));
            }
        }

        private void eduList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eduList.SelectedItems.Count > 0)
            {
                lastSelected = eduList.SelectedItems[0].Text;

                if (lastSelected.Contains(" ("))
                    lastSelected = lastSelected.Substring(0, lastSelected.IndexOf(" ("));
            }
        }

        private void xboxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xboxList.SelectedItems.Count > 0)
            {
                lastSelected = xboxList.SelectedItems[0].Text;

                if (lastSelected.Contains(" ("))
                    lastSelected = lastSelected.Substring(0, lastSelected.IndexOf(" ("));
            }
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

        private void dirBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
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

        private void jsonBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip.SetToolTip(jsonBox, Strings.sj.localOrUrl);
        }

        private void assetIndexBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip.SetToolTip(assetIndexBox, Strings.sj.localOrUrl);
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            xboxNameBox.Text = nameBox.Text;
        }

        private void xboxNameBox_TextChanged(object sender, EventArgs e)
        {
            nameBox.Text = xboxNameBox.Text;
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

                lastSelected = "latest";
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

                lastSelected = "latestsnapshot";
            }
            else
            {
                if (chkLatest.Checked)
                    vanillaList.Enabled = false;
                else
                    vanillaList.Enabled = true;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete this profile?\nYou can't take this back!", "Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Directory.Delete($"{Globals.dataPath}\\instance\\{instanceName}", true);
                HomeScreen.loadInstanceList();
                HomeScreen.Instance.cmbInstaces.SelectedIndex = 0;
                this.Close();
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            Process.Start($"{Globals.dataPath}\\instance\\{instanceName}\\");
        }
    }
}
