﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.controls
{
    public partial class SettingsScreen : UserControl
    {
        public static List<string> nameList = new List<string>();
        public static List<string> idList = new List<string>();
        public static List<string> versionList = new List<string>();
        public static List<string> urlList = new List<string>();
        public static List<string> noteList = new List<string>();

        public static List<string> languageList = new List<string>();
        public static List<string> langNameList = new List<string>();

        public static string updateCheckMode;
        public static SettingsScreen InstanceSetting;

        public static int branchIndex;

        public static bool isUpdating;
        public static bool isFirstLangCheck = true;

        public SettingsScreen()
        {
            InstanceSetting = this;
            InitializeComponent();

            //Lang
            lblJre8.Text = "Java 8";
            lblJre17.Text = "Java 17";

            //Seasonal background
            if (File.Exists($"{Globals.dataPath}\\data\\seasonalStone.png"))
            {
                this.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalStone.png");
            }

            //center panel
            pnlCenter.Location = new Point(
                this.ClientSize.Width / 2 - pnlCenter.Size.Width / 2,
                this.ClientSize.Height / 2 - pnlCenter.Size.Height / 2);
            pnlCenter.Anchor = AnchorStyles.None;


            loadData();
            cmbUpdateSelect.DataSource = nameList;
            int index1 = idList.FindIndex(collection => collection.SequenceEqual(Globals.branch));
            cmbUpdateSelect.SelectedIndex = index1;
            branchIndex = cmbUpdateSelect.SelectedIndex;
            cmbLangSelect.DataSource = langNameList;

            if (Properties.Settings.Default.discordRpc)
                chkDiscordRpc.Checked = true;
            else
                chkDiscordRpc.Checked = false;

            //JREs
            cmbJre8.Text = Properties.Settings.Default.jre8;
            cmbJre17.Text = Properties.Settings.Default.jre17;
        }

        public static void loadData()
        {
            //Clear lists just in case
            nameList.Clear();
            idList.Clear();
            versionList.Clear();
            urlList.Clear();
            noteList.Clear();
            languageList.Clear();
            langNameList.Clear();

            //Get update info
            WebClient client = new WebClient();
            string jsonData = client.DownloadString(Globals.updateInfo);
            List<settingsJson> data = JsonConvert.DeserializeObject<List<settingsJson>>(jsonData);
            foreach (var vers in data)
            {
                nameList.Add($"{vers.brName} - {vers.brVer} [{vers.brId}]");
                idList.Add(vers.brId);
                urlList.Add(vers.brUrl);
                versionList.Add(vers.brVer);
                noteList.Add(vers.brNote);
            }

            string json = client.DownloadString(Globals.languageIndex);
            byte[] jsonArr = Encoding.Default.GetBytes(json);
            string langData = Encoding.UTF8.GetString(jsonArr);
            List<settingsJson> lang = JsonConvert.DeserializeObject<List<settingsJson>>(langData);
            foreach (var vers in lang)
            {
                languageList.Add(vers.title);
                langNameList.Add(vers.name);
            }
        }

        public static void checkForUpdates(string branchToCheck)
        {
            loadData();
            branchIndex = idList.FindIndex(collection => collection.SequenceEqual(branchToCheck));

            Logger.Info("[Settings]", $"Branch to check: {idList[branchIndex]}");

            if (Globals.verCurrent != versionList[branchIndex])
            {
                Logger.Info("[Settings]", $"New update is available!");
                Update upd = new Update(versionList[branchIndex], noteList[branchIndex], urlList[branchIndex]);
                upd.ShowDialog();
            }
            else
            {
                Logger.Info("[Settings]", $"No new update is available.");
            }
        }

        private void cmbUpdateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchIndex = cmbUpdateSelect.SelectedIndex;
            try
            {
                Logger.Info("[Settings]", $"Index: {branchIndex}, version: {versionList[branchIndex]}, branch: {idList[branchIndex]}");
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Logger.Info("[Settings]", $"Got an exception, index: {branchIndex}");
            }
        }

        private void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            checkForUpdates(idList[branchIndex]);
        }

        private void cmbLangSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isFirstLangCheck)
            {
                Logger.Info("[Settings]", $"PrefLang: {Properties.Settings.Default.prefLanguage}");
                isFirstLangCheck = false;

                if(Properties.Settings.Default.prefLanguage == "english" || Properties.Settings.Default.prefLanguage == String.Empty || Properties.Settings.Default.prefLanguage == null)
                {
                    Strings.reloadLangs("english");
                }
                else
                {
                    int index = languageList.FindIndex(a => a.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Properties.Settings.Default.prefLanguage.ToLower())));
                    Logger.Error("[Settings]", $"Lang {Properties.Settings.Default.prefLanguage} found on {index}");
                    cmbLangSelect.SelectedIndex = cmbLangSelect.FindString(langNameList[index]);
                }
            }
            else
            {
                int index = langNameList.FindIndex(a => a.Contains(cmbLangSelect.Text));
                Properties.Settings.Default.prefLanguage = languageList[index].ToLower();
                Properties.Settings.Default.Save();
                Strings.reloadLangs(languageList[index].ToLower());
            }
        }

        private void chkDiscordRpc_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDiscordRpc.Checked)
            {
                Properties.Settings.Default.discordRpc = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.discordRpc = false;
                Properties.Settings.Default.Save();
            }
        }

        private void btnJre8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executables|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cmbJre8.Text = ofd.FileName;
                Properties.Settings.Default.jre8 = ofd.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void btnJre17_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executables|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cmbJre17.Text = ofd.FileName;
                Properties.Settings.Default.jre17 = ofd.FileName;
                Properties.Settings.Default.Save();
            }
        }
    }

    public class settingsJson
    {
        public string brName { get; set; }
        public string brVer { get; set; }
        public string brId { get; set; }
        public string brUrl { get; set; }
        public string brNote { get; set; }

        public string title { get; set; }
        public string name { get; set; }
    }
}
