using MCLauncher.controls;
using MCLauncher.json.launcher;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class EditInstance : Form
    {
        public InstanceGui instanceGui;
        public ModsGui modsGui;

        public EditInstance(String instanceName)
        {
            InitializeComponent();

            //disable resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            instanceGui = new InstanceGui(this, true);
            this.tabHome.Controls.Add(instanceGui);

            modsGui = new ModsGui(instanceName);
            this.tabMods.Controls.Add(modsGui);

            //load lang
            tabHome.Text = Strings.sj.cntHome;
            tabMods.Text = Strings.sj.tabMods;

            //get instance data
            String profileJson = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\instance.json");
            InstanceJson ij = JsonConvert.DeserializeObject<InstanceJson>(profileJson);

            //fill in stuff
            if (ij.edition == "x360")
            {
                instanceGui.tabControl1.SelectedIndex = 2;
                instanceGui.grbGame.Visible = false;
                instanceGui.grbForExp.Visible = false;
                instanceGui.grbXbox.Visible = true;
            }
            else if (ij.edition == "javaedu")
                instanceGui.tabControl1.SelectedIndex = 1;
            else
                instanceGui.tabControl1.SelectedIndex = 0;

            instanceGui.selectedVersion = ij.version;
            instanceGui.playTime = ij.playTime;

            instanceGui.nameBox.Text = instanceName;
            instanceGui.originalName = instanceName;
            instanceGui.dirBox.Text = ij.directory; //TODO CHECK FOR INVALID

            instanceGui.chkReso.Checked = ij.useResolution;
            String[] res = ij.resolution.Split(new char[] { ' ' });
            instanceGui.resXBox.Text = res[0];
            instanceGui.resXBox.Enabled = ij.useResolution;
            instanceGui.resYBox.Text = res[1];
            instanceGui.resYBox.Enabled = ij.useResolution;
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
            instanceGui.javaBtn.Enabled = ij.useJava;

            instanceGui.chkCustJson.Checked = ij.useJson;
            instanceGui.jsonBox.Enabled = ij.useJson;
            instanceGui.jsonBox.Text = ij.jsonPath;
            instanceGui.jsonBtn.Enabled = ij.useJson;

            instanceGui.chkClasspath.Checked = ij.useClass;
            instanceGui.classBox.Enabled = ij.useClass;
            instanceGui.classBox.Text = ij.classpath;

            instanceGui.chkAssetIndex.Checked = ij.useAssets;
            instanceGui.assetIndexBox.Enabled = ij.useAssets;
            instanceGui.assetIndexBox.Text = ij.assetsPath;
            instanceGui.assetIndexBtn.Enabled = ij.useAssets;

            instanceGui.chkServerIP.Checked = ij.useServerIP;
            instanceGui.serverIPBox.Enabled = ij.useServerIP;
            instanceGui.serverIPBox.Text = ij.serverIP;

            instanceGui.chkXboxDemo.Checked = ij.xboxDemo;

            //filter
            if (ij.filter != null)
            {
                if (!ij.filter.Contains("release"))
                    instanceGui.chkRelease.Checked = false;
                if (!ij.filter.Contains("snapshot"))
                    instanceGui.chkSnapshot.Checked = false;
                if (!ij.filter.Contains("experimental"))
                    instanceGui.chkExperimental.Checked = false;
                if (!ij.filter.Contains("other"))
                    instanceGui.chkOther.Checked = false;
                if (!ij.filter.Contains("beta"))
                    instanceGui.chkBeta.Checked = false;
                if (!ij.filter.Contains("alpha"))
                    instanceGui.chkAlpha.Checked = false;
                if (!ij.filter.Contains("infdev"))
                    instanceGui.chkInfdev.Checked = false;
                if (!ij.filter.Contains("indev"))
                    instanceGui.chkIndev.Checked = false;
                if (!ij.filter.Contains("classic"))
                    instanceGui.chkClassic.Checked = false;
                if (!ij.filter.Contains("preclassic"))
                    instanceGui.chkPreclassic.Checked = false;
            }

            //set init to true so version list can be loaded
            instanceGui.initialized = true;

            //load lists
            instanceGui.loadJavaList();
            instanceGui.loadEduList();
            instanceGui.loadXboxList();

            //select version
            if (ij.edition == "java")
                instanceGui.selectInList(instanceGui.vanillaList, ij.version);
            else if (ij.edition == "javaedu")
                instanceGui.selectInList(instanceGui.eduList, ij.version);
            else if (ij.edition == "x360")
                instanceGui.selectInList(instanceGui.xboxList, ij.version);

            //latest and latestsnapshot stuff
            if (ij.version.Contains("latest"))
            {
                if (ij.version == "latest")
                {
                    instanceGui.chkLatest.Checked = true;
                }
                else if (ij.version == "latestsnapshot")
                {
                    instanceGui.chkLatestSnapshot.Checked = true;
                }

                instanceGui.selectedVersion = HomeScreen.getLatestVersion(ij.version);
                instanceGui.vanillaList.Enabled = false;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                modsGui.loadModloaderButtons(instanceGui.selectedVersion);
            }
        }
    }
}
