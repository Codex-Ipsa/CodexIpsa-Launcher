using MCLauncher.classes.jsons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class NewInstance : Form
    {
        public string lastSelected = "";
        ToolTip toolTip = new ToolTip();

        public NewInstance()
        {
            InitializeComponent();

            //disable resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //load lang
            grbGame.Text = Strings.grbGame;
            lblProfName.Text = Strings.lblProfName;
            lblGameDir.Text = Strings.lblGameDir;
            lblReso.Text = Strings.lblReso;
            lblMem.Text = Strings.lblMem;
            lblMemMax.Text = Strings.lblMemMax;
            lblMemMin.Text = Strings.lblMemMin;
            //lblBefCmd.Text = Strings.lblBefCmd;
            //lblAftCmd.Text = Strings.lblAftCmd;
            chkProxy.Text = Strings.chkProxy;
            chkUseDemo.Text = Strings.chkUseDemo;
            chkOffline.Text = Strings.chkOffline;
            chkMulti.Text = Strings.chkMulti;
            grbForExp.Text = Strings.grbForExp;
            chkCustJava.Text = Strings.chkCustJava;
            chkCustJson.Text = Strings.chkCustJson;
            chkClasspath.Text = Strings.chkClasspath;
            chkAssetIndex.Text = Strings.chkAssetIndex;
            saveBtn.Text = Strings.createProfile;

            grbXbox.Text = Strings.grbGame;
            chkXboxDemo.Text = Strings.chkUseDemo.Substring(0, Strings.chkUseDemo.IndexOf(" ("));
            lblXboxProfName.Text = Strings.lblProfName;

            //fill in shared stuff
            nameBox.Text = "New profile";
            ramMinBox.Value = 512;
            ramMaxBox.Value = 512;
            resXBox.Text = "854";
            resYBox.Text = "480";
            javaBox.Enabled = false;
            javaBtn.Enabled = false;
            jsonBox.Enabled = false;
            jsonBtn.Enabled = false;
            classBox.Enabled = false;
            assetIndexBox.Enabled = false;
            assetIndexBtn.Enabled = false;

            //fill in edition specific stuff
            populateLists();
        }

        private void populateLists()
        {
            //vanilla list
            if (tabControl1.SelectedTab.Text == "Vanilla")
            {
                //clear list
                vanillaList.Items.Clear();
                vanillaList.Columns.Clear();

                //add columns
                vanillaList.Columns.Add(Strings.rowName);
                vanillaList.Columns.Add(Strings.rowType);
                vanillaList.Columns.Add(Strings.rowReleased);

                //add items
                string manifest = Globals.client.DownloadString(Globals.javaManifest);
                List<JavaManifest> jm = JsonConvert.DeserializeObject<List<JavaManifest>>(manifest);
                foreach (JavaManifest ver in jm)
                {
                    string[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy HH:mm:ss") };

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

                //scroll to default version (b1.7.3)
                ListViewItem item = vanillaList.FindItemWithText("b1.7.3");
                int indexOf = vanillaList.Items.IndexOf(item);
                if (indexOf > 0)
                {
                    vanillaList.Items[indexOf].Selected = true;
                    vanillaList.TopItem = vanillaList.Items[indexOf];
                }
            }

            //edu list
            else if (tabControl1.SelectedTab.Text == "MinecraftEdu")
            {
                //clear list
                eduList.Items.Clear();
                eduList.Columns.Clear();

                //add columns
                eduList.Columns.Add(Strings.rowName);
                eduList.Columns.Add(Strings.rowType);
                eduList.Columns.Add(Strings.rowReleased);

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
            else if (tabControl1.SelectedTab.Text == "Xbox 360")
            {
                //clear list
                xboxList.Items.Clear();
                xboxList.Columns.Clear();

                //add columns
                xboxList.Columns.Add(Strings.rowName);
                xboxList.Columns.Add(Strings.rowType);
                xboxList.Columns.Add(Strings.rowReleased);

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

        //TODO (hell)
        private void button1_Click(object sender, EventArgs e)
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
            ij.jvm = jvmBox.Text;
            //ij.befCmd = befBox.Text;
            //ij.aftCmd = aftBox.Text;

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

            //check if profile already exists => add _X
            string newName = profileName;
            int iter = 1;
            while (Directory.Exists($"{Globals.dataPath}\\instance\\{newName}"))
            {
                newName = profileName + "_" + iter;
                iter++;
            }
            profileName = newName;

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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateLists();

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

        private void javaBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executables|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                javaBox.Text = ofd.FileName;
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
            toolTip.SetToolTip(jsonBox, Strings.localOrUrl);
        }

        private void assetIndexBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip.SetToolTip(assetIndexBox, Strings.localOrUrl);
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

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            xboxNameBox.Text = nameBox.Text;
        }

        private void xboxNameBox_TextChanged(object sender, EventArgs e)
        {
            nameBox.Text = xboxNameBox.Text;
        }
    }
}
