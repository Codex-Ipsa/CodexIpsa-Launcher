using MCLauncher.json.api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
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

            if (Settings.sj.discordRPC)
                chkDiscordRpc.Checked = true;
            else
                chkDiscordRpc.Checked = false;

            //JREs
            cmbJre8.Text = Settings.sj.jre8;
            cmbJre17.Text = Settings.sj.jre17;
            cmbJre21.Text = Settings.sj.jre21;
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
            if (!Globals.offlineMode)
            {
                WebClient client = new WebClient();
                string jsonData = client.DownloadString(Globals.updateInfo);
                List<UpdateJson> data = JsonConvert.DeserializeObject<List<UpdateJson>>(jsonData);
                foreach (var vers in data)
                {
                    nameList.Add($"{vers.brName} - {vers.brVer} [{vers.brId}]");
                    idList.Add(vers.brId);
                    urlList.Add(vers.brUrl);
                    versionList.Add(vers.brVer);
                    noteList.Add(vers.brNote);
                }

                string json = client.DownloadString(Globals.languageList);
                byte[] jsonArr = Encoding.Default.GetBytes(json);
                string langData = Encoding.UTF8.GetString(jsonArr);
                List<LanguagesJson> lang = JsonConvert.DeserializeObject<List<LanguagesJson>>(langData);
                foreach (var vers in lang)
                {
                    languageList.Add(vers.title);
                    langNameList.Add(vers.name);
                }
            }
            else
            {
                nameList.Add($"{Globals.branch} - {Globals.verCurrent} [{Globals.branch.ToLower()}]");

                languageList.Add("english");
                langNameList.Add("English");
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
                if (!isFirstLangCheck)
                    MessageBox.Show(Strings.sj.noUpdate, "Update manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (isFirstLangCheck)
            {
                Logger.Info("[Settings]", $"PrefLang: {Settings.sj.language}");
                isFirstLangCheck = false;

                if (Settings.sj.language == "english" || Settings.sj.language == String.Empty || Settings.sj.language == null)
                {
                    Strings.reloadLangs("english");
                }
                else
                {
                    int index = languageList.FindIndex(a => a.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Settings.sj.language.ToLower())));
                    Logger.Error("[Settings]", $"Lang {Settings.sj.language} found on {index}");
                    cmbLangSelect.SelectedIndex = cmbLangSelect.FindString(langNameList[index]);
                }
            }
            else
            {
                int index = langNameList.FindIndex(a => a.Contains(cmbLangSelect.Text));
                Settings.sj.language = languageList[index].ToLower();
                Settings.Save();
                Strings.reloadLangs(languageList[index].ToLower());
            }
        }

        private void chkDiscordRpc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscordRpc.Checked)
            {
                Settings.sj.discordRPC = true;
                Settings.Save();
            }
            else
            {
                Settings.sj.discordRPC = false;
                Settings.Save();
            }
        }

        private void btnJre8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executables|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cmbJre8.Text = ofd.FileName;
                Settings.sj.jre8 = ofd.FileName;
                Settings.Save();
            }
        }

        private void btnJre17_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executables|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cmbJre17.Text = ofd.FileName;
                Settings.sj.jre17 = ofd.FileName;
                Settings.Save();
            }
        }

        private void btnJre21_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executables|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cmbJre21.Text = ofd.FileName;
                Settings.sj.jre21 = ofd.FileName;
                Settings.Save();
            }
        }

        private void btnGetJava8_Click(object sender, EventArgs e)
        {
            DownloadJava(8);
        }

        private void btnGetJava17_Click(object sender, EventArgs e)
        {
            DownloadJava(17);
        }

        private void btnGetJava21_Click(object sender, EventArgs e)
        {
            DownloadJava(21);
        }

        private void cmbJre8_TextUpdate(object sender, EventArgs e)
        {
            Settings.sj.jre8 = cmbJre8.Text;
            Settings.Save();
        }

        private void cmbJre17_TextUpdate(object sender, EventArgs e)
        {
            Settings.sj.jre17 = cmbJre17.Text;
            Settings.Save();
        }

        private void cmbJre21_TextUpdate(object sender, EventArgs e)
        {
            Settings.sj.jre21 = cmbJre21.Text;
            Settings.Save();
        }

        public void DownloadJava(int targetMajor)
        {
            string jsonData = Globals.client.DownloadString(Globals.JavaInstalls);
            List<javaInstallsManifest> data = JsonConvert.DeserializeObject<List<javaInstallsManifest>>(jsonData);
            foreach (var vers in data)
            {
                if (vers.major == targetMajor)
                {
                    bool shouldDownload = false;

                    //Download if not present
                    if (!Directory.Exists($"{Globals.dataPath}\\jre\\jre{vers.major}"))
                    {
                        shouldDownload = true;
                    }
                    //Download if update available
                    else if (!File.Exists($"{Globals.dataPath}\\jre\\jre{vers.major}\\version.txt") || File.ReadAllText($"{Globals.dataPath}\\jre\\jre{vers.major}\\version.txt") != vers.id)
                    {
                        DialogResult dialogResult = MessageBox.Show(Strings.sj.javaUpdate.Replace("{ver}", vers.major.ToString()), "Java manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            shouldDownload = true;
                        }
                    }
                    //Redownload if latest exists
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(Strings.sj.javaRedownload.Replace("{ver}", vers.major.ToString()), "Java manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            shouldDownload = true;
                        }
                    }

                    if (shouldDownload)
                    {
                        if (Directory.Exists($"{Globals.dataPath}\\jre\\jre{vers.major}"))
                            Directory.Delete($"{Globals.dataPath}\\jre\\jre{vers.major}", true);

                        Directory.CreateDirectory($"{Globals.dataPath}\\jre\\jre{vers.major}");
                        DownloadProgress.url = vers.url;
                        DownloadProgress.savePath = $"{Globals.dataPath}\\jre\\temp.zip";
                        DownloadProgress dp = new DownloadProgress();
                        dp.ShowDialog();

                        try
                        {
                            ZipFile.ExtractToDirectory($"{Globals.dataPath}\\jre\\temp.zip", $"{Globals.dataPath}\\jre\\jre{vers.major}");
                            File.Delete($"{Globals.dataPath}\\jre\\temp.zip");
                            File.WriteAllText($"{Globals.dataPath}\\jre\\jre{vers.major}\\version.txt", vers.id);

                            DialogResult dialogResult = MessageBox.Show(Strings.sj.javaSetDefault.Replace("{ver}", vers.major.ToString()), "Java manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (vers.major == 8)
                                {
                                    cmbJre8.Text = $"{Globals.dataPath}\\jre\\jre{vers.major}\\{vers.executable}";
                                    Settings.sj.jre8 = $"{Globals.dataPath}\\jre\\jre{vers.major}\\{vers.executable}";
                                    Settings.Save();
                                }
                                else if (vers.major == 17)
                                {
                                    cmbJre17.Text = $"{Globals.dataPath}\\jre\\jre{vers.major}\\{vers.executable}";
                                    Settings.sj.jre17 = $"{Globals.dataPath}\\jre\\jre{vers.major}\\{vers.executable}";
                                    Settings.Save();
                                }
                                else if (vers.major == 21)
                                {
                                    cmbJre21.Text = $"{Globals.dataPath}\\jre\\jre{vers.major}\\{vers.executable}";
                                    Settings.sj.jre21 = $"{Globals.dataPath}\\jre\\jre{vers.major}\\{vers.executable}";
                                    Settings.Save();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("[SettingsScreen]", $"Failed to download/install Java {vers.id}; {vers.url}; {ex.Message}");
                        }
                    }
                }
            }
        }
    }

    public class javaInstallsManifest
    {
        public int major { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public int size { get; set; }
        public string executable { get; set; }
    }
}
