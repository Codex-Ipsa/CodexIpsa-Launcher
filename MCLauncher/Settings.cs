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
            //TODO for stuff like languages   
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
