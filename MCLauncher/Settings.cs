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

namespace MCLauncher
{
    public partial class Settings : Form
    {
        public static List<string> nameList = new List<string>();
        public static List<string> idList = new List<string>();
        public static List<string> versionList = new List<string>();
        public static List<string> urlList = new List<string>();
        public static List<string> noteList = new List<string>();


        public static string updateCheckMode;
        public static Settings InstanceSetting;

        public static int branchIndex;

        public Settings()
        {
            //Initialize
            InstanceSetting = this;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            loadData();
            comboUpdateSelect.DataSource = nameList;
            int index1 = idList.FindIndex(collection => collection.SequenceEqual(Globals.branch));
            comboUpdateSelect.SelectedIndex = index1;
            branchIndex = comboUpdateSelect.SelectedIndex;


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

            Logger.logError("[Settings]", idList[branchIndex]);

            if (Globals.verCurrent != versionList[branchIndex])
            {
                Logger.logError("[Settings]", $"New update is available!");

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
                Logger.logError("[Settings]", $"No new update is available.");
            }
        }

        private void comboUpdateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchIndex = comboUpdateSelect.SelectedIndex;
            Logger.logError("[Settings]", $"i:{branchIndex}, v:{versionList[branchIndex]}, b:{idList[branchIndex]}");
        }

        private void btnUpdates_Click(object sender, EventArgs e)
        {
            checkForUpdates(idList[branchIndex]);
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Close();
        }

        public static void saveSettings()
        {
            
        }

        /*private void comboUpdateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            cfgBranchIndex = comboUpdateSelect.FindStringExact(comboUpdateSelect.Text);
            Logger.logMessage("[BranchCheck]", $"Index: {cfgBranchIndex}");
            Logger.logMessage("[BranchCheck]", $"Selected branchId: {branchIdList[cfgBranchIndex]}");
            Logger.logMessage("[BranchCheck]", $"Branch ver: {branchVerList[cfgBranchIndex]}");
            Logger.logMessage("[BranchCheck]", $"Branch url: {branchUrlList[cfgBranchIndex]}");

            cfgLatestVer = branchVerList[cfgBranchIndex];
            cfgLatestUrl = branchUrlList[cfgBranchIndex];
        }

        public static void checkForBranches()
        {
            branchList.Clear();
            branchIdList.Clear();
            branchVerList.Clear();
            branchUrlList.Clear();
            Console.WriteLine($"[BranchCheck] Loading updates list...");

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.updateInfo);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    branchList.Add($"{vers.brName} - {vers.brVer} [{vers.brId}]");
                    branchIdList.Add(vers.brId);
                    branchVerList.Add(vers.brVer);
                    branchUrlList.Add(vers.brUrl);
                }

                InstanceSetting.comboUpdateSelect.DataSource = branchList;
                cfgBranchIndex = InstanceSetting.comboUpdateSelect.FindStringExact(InstanceSetting.comboUpdateSelect.Text);
                Console.WriteLine($"[BranchCheck] Index is {cfgBranchIndex}");
                Console.WriteLine($"[BranchCheck] Selected branchId: {branchIdList[cfgBranchIndex]}");
                Console.WriteLine($"[BranchCheck] Branch ver: {branchVerList[cfgBranchIndex]}");
                Console.WriteLine($"[BranchCheck] Branch url: {branchUrlList[cfgBranchIndex]}");
                cfgLatestVer = branchVerList[cfgBranchIndex];
                cfgLatestUrl = branchUrlList[cfgBranchIndex];
                //TODO: set selectedIndex
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void btnUpdates_Click(object sender, EventArgs e)
        {
            updateCheckMode = "button";
            checkForUpdates(branchIdList[cfgBranchIndex]);
        }

        public static void checkForUpdates(string targetBranch)
        {
            Console.WriteLine($"[VerCheck] Checking for updates on branchId {targetBranch}.");

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.updateInfo);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    branchList.Add($"{vers.brName} - {vers.brVer} [{vers.brId}]");
                    branchIdList.Add(vers.brId);
                    branchVerList.Add(vers.brVer);
                    branchUrlList.Add(vers.brUrl);
                }

                cfgBranchIndex = branchIdList.FindIndex(x => x.StartsWith(targetBranch));
                Console.WriteLine($"[VerCheck] Index is {cfgBranchIndex}");
                Console.WriteLine($"[VerCheck] Selected branchId: {branchIdList[cfgBranchIndex]}");
                Console.WriteLine($"[VerCheck] Branch ver: {branchVerList[cfgBranchIndex]}");
                Console.WriteLine($"[VerCheck] Branch url: {branchUrlList[cfgBranchIndex]}");
                cfgLatestVer = branchVerList[cfgBranchIndex];
                cfgLatestUrl = branchUrlList[cfgBranchIndex];
                //TODO: set selectedIndex
            }

            if (Globals.verCurrent != cfgLatestVer)
            {
                Console.WriteLine($"[VerCheck] New version found!");

                using (FileStream fs = File.Create($"{Globals.currentPath}\\.codexipsa\\update.cfg"))
                {
                    byte[] config = new UTF8Encoding(true).GetBytes($"{cfgLatestUrl}");

                    fs.Write(config, 0, config.Length);
                }

                string temp = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\update.cfg");
                Console.WriteLine($"[VerCheck] url from text is: {temp}");

                Update upd = new Update("new ver", "update info");
                upd.ShowDialog();
            }
            else
            {
                Console.WriteLine($"[VerCheck] Nope, no new version.");
            }
        }

        public static void saveSettings()
        {
            //TODO: save
            //foreach (var form in Application.OpenForms.OfType<Settings>().ToList())form.Close();
        }*/
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
