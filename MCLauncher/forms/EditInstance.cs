using MCLauncher.classes.jsons;
using MCLauncher.controls;
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
        public EditInstance(String instanceName)
        {
            InitializeComponent();

            //disable resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InstanceGui instanceGui = new InstanceGui(this, true);
            this.tabHome.Controls.Add(instanceGui);

            ModsGui modsGui = new ModsGui(instanceName);
            this.tabMods.Controls.Add(modsGui);

            //load lang
            tabHome.Text = Strings.sj.cntHome;
            tabMods.Text = Strings.sj.tabMods;

            //get instance data
            String profileJson = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\instance.json");
            InstanceJson ij = JsonConvert.DeserializeObject<InstanceJson>(profileJson);

            //fill in stuff
            if (ij.edition == "x360")
                instanceGui.tabControl1.SelectedIndex = 2;
            else if (ij.edition == "javaedu")
                instanceGui.tabControl1.SelectedIndex = 1;
            else
                instanceGui.tabControl1.SelectedIndex = 0;

            instanceGui.selectedVersion = ij.version;

            instanceGui.nameBox.Text = instanceName;
            instanceGui.dirBox.Text = ij.directory; //TODO CHECK FOR INVALID
            String[] res = ij.resolution.Split(new char[] { ' ' });
            instanceGui.resXBox.Text = res[0];
            instanceGui.resYBox.Text = res[1];
            String[] mem = ij.memory.Split(new char[] { ' ' });
            instanceGui.ramMaxBox.Value = int.Parse(mem[0]);
            instanceGui.ramMinBox.Value = int.Parse(mem[1]);
            instanceGui.jvmArgsBox.Text = ij.befCmd;
            instanceGui.gameArgsBox.Text = ij.aftCmd;

            instanceGui.chkProxy.Checked = ij.disProxy;
            instanceGui.chkUseDemo.Checked = ij.demo;
            instanceGui.chkOffline.Checked = ij.offline;
            instanceGui.chkMulti.Checked = ij.multiplayer;

            instanceGui.chkCustJava.Checked = ij.useJava;
            instanceGui.javaBox.Enabled = ij.useJava;
            instanceGui.javaBox.Text = ij.javaPath;

            instanceGui.chkCustJson.Checked = ij.useJson;
            instanceGui.jsonBox.Enabled = ij.useJson;
            instanceGui.jsonBox.Text = ij.jsonPath;

            instanceGui.chkClasspath.Checked = ij.useClass;
            instanceGui.classBox.Enabled = ij.useClass;
            instanceGui.classBox.Text = ij.classpath;

            instanceGui.chkAssetIndex.Checked = ij.useAssets;
            instanceGui.assetIndexBox.Enabled = ij.useAssets;
            instanceGui.assetIndexBox.Text = ij.assetsPath;

            instanceGui.chkXboxDemo.Checked = ij.xboxDemo;

            //latest and latestsnapshot stuff
            if (instanceGui.selectedVersion.Contains("latest"))
            {
                if (instanceGui.selectedVersion == "latest")
                {
                    instanceGui.chkLatest.Checked = true;
                }
                else if (instanceGui.selectedVersion == "latestsnapshot")
                {
                    instanceGui.chkLatestSnapshot.Checked = true;
                }

                instanceGui.selectedVersion = HomeScreen.getLatestVersion(instanceGui.selectedVersion);
                instanceGui.vanillaList.Enabled = false;
            }

            instanceGui.selectInList(instanceGui.vanillaList, ij.version);

            //TODO LOAD MOD JSON

            //fill in edition specific stuff
            //populateLists();
        }

     

        //save instance
        /*private void saveBtn_Click(object sender, EventArgs e)
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
        }*/
    }
}
