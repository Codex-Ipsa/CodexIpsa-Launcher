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
        public static string updateCheckMode;
        public static Settings InstanceSetting;

        public Settings()
        {
            InstanceSetting = this;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            checkForBranches();
        }

        private void checkForBranches()
        {
            Console.WriteLine($"[VerCheck] Loading updates list...");

            int index;
            string tempName;

            List<string> brIdList = new List<string>();
            List<string> brNameList = new List<string>();
            List<string> brVersionList = new List<string>();
            List<string> brUrlList = new List<string>();

            List<string> brFinalList = new List<string>();

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.updateInfo);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    brFinalList.Add($"{vers.brName} - {vers.brVer} [{vers.brId}]");
                }
                index = comboUpdateSelect.FindStringExact(comboUpdateSelect.Text);
                comboUpdateSelect.DataSource = brFinalList;
                Console.WriteLine("index is " + index);
                //comboUpdateSelect.SelectionStart = index;
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            //TODO: save
            this.Close();
        }

        private void btnUpdates_Click(object sender, EventArgs e)
        {
            updateCheckMode = "button";
            checkForUpdates();
        }

        public static void checkForUpdates()
        {
            if(updateCheckMode == "button")
            {
                Console.WriteLine($"[VerCheck] Checking for updates (called by user).");

                int index;
                string tempVer;

                List<string> brIdList = new List<string>();
                List<string> brNameList = new List<string>();
                List<string> brVersionList = new List<string>();
                List<string> brUrlList = new List<string>();

                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(Globals.updateInfo);
                    List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                    foreach (var vers in data)
                    {
                        brIdList.Add(vers.brId);
                        Console.WriteLine($"[VerCheck] Branch found: {vers.brId}");
                        brNameList.Add(vers.brName);
                        brVersionList.Add(vers.brVer);
                        brUrlList.Add(vers.brUrl);
                    }
                    index = InstanceSetting.comboUpdateSelect.FindStringExact(InstanceSetting.comboUpdateSelect.Text);

                    Console.WriteLine($"[VerCheck] Selected index: {index}");
                    Console.WriteLine($"[VerCheck] Corresponding branch: {brIdList[index]}");
                    Console.WriteLine($"[VerCheck] Corresponding name: {brNameList[index]}");
                    Console.WriteLine($"[VerCheck] Corresponding version: {brVersionList[index]}");
                    Console.WriteLine($"[VerCheck] Corresponding url: {brUrlList[index]}");

                    if (Globals.verCurrent != brVersionList[2])
                    {
                        Console.WriteLine($"[VerCheck] NEW VERSION DETECTED!");
                        Console.WriteLine($"[VerCheck] Corresponding url: {brUrlList[index]}");

                        using (FileStream fs = File.Create($"{Globals.currentPath}\\.codexipsa\\updateTemp.cfg"))
                        {
                            byte[] config = new UTF8Encoding(true).GetBytes($"[\n{{\n\"brId\":\"{brIdList[index]}\",\n\"brUrl\":\"{brUrlList[index]}\"\n}}\n]");

                            fs.Write(config, 0, config.Length);
                        }

                        updateCheckMode = "null";
                    }
                    else
                    {
                        Console.WriteLine($"[VerCheck] No new version detected.");
                        updateCheckMode = "null";
                    }
                }
            }
            else if (updateCheckMode == "startup")
            {
                Console.WriteLine($"[VerCheck] Checking for updates (called by startup).");

            }
        }
    }
}
