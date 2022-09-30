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

        public static string updateCheckMode;
        public static SettingsScreen InstanceSetting;

        public static int branchIndex;

        public SettingsScreen()
        {
            InstanceSetting = this;
            InitializeComponent();

            //Load lang
            grbLauncher.Text = Strings.grbLauncher;
            grbUpdates.Text = Strings.grbUpdates;
            lblBranch.Text = Strings.lblBranch;
            lblLang.Text = Strings.lblLang;
            btnCheckUpdates.Text = Strings.btnCheckUpdates;

            loadData();
            cmbUpdateSelect.DataSource = nameList;
            int index1 = idList.FindIndex(collection => collection.SequenceEqual(Globals.branch));
            cmbUpdateSelect.SelectedIndex = index1;
            branchIndex = cmbUpdateSelect.SelectedIndex;
        }

        public static void loadData()
        {
            //Clear lists just in case
            nameList.Clear();
            idList.Clear();
            versionList.Clear();
            urlList.Clear();
            noteList.Clear();

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
        }

        public static void checkForUpdates(string branchToCheck)
        {
            loadData();
            branchIndex = idList.FindIndex(collection => collection.SequenceEqual(branchToCheck));

            Logger.logMessage("[Settings]", $"Branch to check: {idList[branchIndex]}");

            if (Globals.verCurrent != versionList[branchIndex])
            {
                Logger.logMessage("[Settings]", $"New update is available!");

                using (FileStream fs = File.Create($"{Globals.currentPath}\\.codexipsa\\update.cfg"))
                {
                    byte[] config = new UTF8Encoding(true).GetBytes($"{urlList[branchIndex]}");

                    fs.Write(config, 0, config.Length);
                }
                Update upd = new Update(versionList[branchIndex], noteList[branchIndex]);
                upd.ShowDialog();
            }
            else
            {
                Logger.logMessage("[Settings]", $"No new update is available.");
            }
        }

        private void cmbUpdateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchIndex = cmbUpdateSelect.SelectedIndex;
            Logger.logMessage("[Settings]", $"Index: {branchIndex}, version: {versionList[branchIndex]}, branch: {idList[branchIndex]}");
        }

        private void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            checkForUpdates(idList[branchIndex]);
        }
    }

    public class settingsJson
    {
        public string brName { get; set; }
        public string brVer { get; set; }
        public string brId { get; set; }
        public string brUrl { get; set; }
        public string brNote { get; set; }
    }
}
