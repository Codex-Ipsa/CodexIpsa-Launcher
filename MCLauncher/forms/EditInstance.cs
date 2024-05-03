﻿using MCLauncher.classes.jsons;
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
            instanceGui.originalName = instanceName;
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

            instanceGui.selectInList(instanceGui.vanillaList, ij.version);

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
        }
    }
}
