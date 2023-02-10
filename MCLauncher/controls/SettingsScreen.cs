using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public static string updateCheckMode;
        public static SettingsScreen InstanceSetting;

        public static int branchIndex;

        public static bool isUpdating;
        public static bool isFirstLangCheck = true;

        public SettingsScreen()
        {
            InstanceSetting = this;
            InitializeComponent();

            //Seasonal background
            if (File.Exists($"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png"))
            {
                this.BackgroundImage = Image.FromFile($"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png");
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
            cmbLangSelect.DataSource = languageList;
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

            string langData = client.DownloadString(Globals.languageIndex);
            List<settingsJson> lang = JsonConvert.DeserializeObject<List<settingsJson>>(langData);
            foreach (var vers in lang)
            {
                languageList.Add(vers.title);
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
                isFirstLangCheck = false;

                if(Properties.Settings.Default.prefLanguage == "english" || Properties.Settings.Default.prefLanguage == String.Empty || Properties.Settings.Default.prefLanguage == null)
                {
                    Strings.reloadLangs("english");
                }
                else
                {
                    cmbLangSelect.SelectedIndex = cmbLangSelect.FindString(Properties.Settings.Default.prefLanguage);
                }
            }
            else
            {
                Logger.Info("[Settings]", $"PrefLang: {Properties.Settings.Default.prefLanguage}");

                Properties.Settings.Default.prefLanguage = cmbLangSelect.Text.ToLower();
                Properties.Settings.Default.Save();
                Strings.reloadLangs(cmbLangSelect.Text.ToLower());
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
    }
}
