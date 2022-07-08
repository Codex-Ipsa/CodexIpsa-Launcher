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
        public static List<string> branchList = new List<string>();
        public static List<string> branchIdList = new List<string>();
        public static List<string> branchVerList = new List<string>();
        public static List<string> branchUrlList = new List<string>();


        public static string updateCheckMode;
        public static Settings InstanceSetting;

        public static int cfgBranchIndex;
        public static string cfgLatestVer;
        public static string cfgLatestUrl;

        public Settings()
        {
            InstanceSetting = this;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            checkForBranches();
        }

        private void comboUpdateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            cfgBranchIndex = comboUpdateSelect.FindStringExact(comboUpdateSelect.Text);
            Console.WriteLine($"[BranchCheck] Index is {cfgBranchIndex}");
            Console.WriteLine($"[BranchCheck] Selected branchId: {branchIdList[cfgBranchIndex]}");
            Console.WriteLine($"[BranchCheck] Branch ver: {branchVerList[cfgBranchIndex]}");
            Console.WriteLine($"[BranchCheck] Branch url: {branchUrlList[cfgBranchIndex]}");
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

                Update upd = new Update();
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
        }
    }
}
