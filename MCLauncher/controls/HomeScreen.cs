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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
using Color = System.Drawing.Color;

namespace MCLauncher
{
    public partial class HomeScreen : UserControl
    {
        public static HomeScreen Instance;
        public static string selectedEdition;
        public static string msPlayerName;
        public static string selectedInstance = "Default";
        public static string selectedVersion; //for the "ready to play X" string

        public HomeScreen()
        {
              
            Instance = this;
            InitializeComponent();

            /*if (!File.Exists($"{Globals.dataPath}\\settings.cfg"))
            {
                SettingData.saveData("null")
            }
            SettingData.saveData();*/

            Logger.Info("[HomeScreen]", $"Last instance: {Properties.Settings.Default.lastInstance}");

            if(Properties.Settings.Default.lastInstance == String.Empty || Properties.Settings.Default.lastInstance == null)
                selectedInstance = "Default";
            else
                selectedInstance = Properties.Settings.Default.lastInstance;

            pnlChangelog.AutoScroll = true;

            if (File.Exists($"{Globals.currentPath}\\.codexipsa\\data\\seasonalDirt.png"))
            {
                panel1.BackgroundImage = Image.FromFile($"{Globals.currentPath}\\.codexipsa\\data\\seasonalDirt.png");
            }
            if (File.Exists($"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png"))
            {
                this.BackgroundImage = Image.FromFile($"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png");
            }

            //JSON changelog system
            loadChangelog();

            //Check if user is logged in
            checkAuth();

            if (!Directory.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\Default"))
            {
                InstanceManager.Start("Default", "initial");
            }       

            //Load instance list
            loadInstanceList();
            if(!File.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\{selectedInstance}\\instance.cfg"))
            {
                selectedInstance = "Default";
            }
            cmbInstaces.SelectedIndex = cmbInstaces.FindString(selectedInstance);
            reloadInstance(selectedInstance);

            string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{selectedInstance}\\instance.cfg");
            List<instanceObjects> data = JsonConvert.DeserializeObject<List<instanceObjects>>(json);
            Logger.Info("[HomeScreen]", $"Selected instance: {selectedInstance}");
            //Logger.logError("[HomeScreen]", $"{Globals.currentPath}\\.codexipsa\\instance\\{selectedInstance}\\instance.cfg");

            //Set the LaunchJava stuff
            foreach (var vers in data)
            {
                if(vers.edition == "Xbox 360 Edition")
                {
                    LaunchXbox360.ver = vers.version;
                    LaunchXbox360.url = vers.url;
                    LaunchXbox360.type = vers.type;
                    selectedEdition = "x360";
                    Instance.lblReady.Text = $"{Strings.lblReady} {LaunchXbox360.ver}";
                }
                else 
                {
                    LaunchJava.launchVerName = vers.version;
                    LaunchJava.launchVerUrl = vers.url;
                    LaunchJava.launchVerType = vers.type;
                    selectedEdition = "java";
                    Instance.lblReady.Text = $"{Strings.lblReady} {LaunchJava.launchVerName}";
                }
            }

            //load pref language TODO: THIS THROWS
            /*if(Properties.Settings.Default.prefLanguage.ToLower() != "english" || Properties.Settings.Default.prefLanguage.ToLower() != null || Properties.Settings.Default.prefLanguage.ToLower() != String.Empty)
            {
                Strings.reloadLangs(Properties.Settings.Default.prefLanguage);
            }*/
        }

        public static void checkAuth()
        {
            if (Properties.Settings.Default.msRefreshToken == String.Empty || Properties.Settings.Default.msRefreshToken == null)
            {
                Logger.Error($"[HomeScreen]", "User is not logged in");
                Instance.btnLogOut.Visible = false;
                Instance.btnLogIn.Visible = true;
                Instance.lblWelcome.Text = $"{Strings.lblWelcome} Guest";
                LaunchJava.launchPlayerName = "Guest";
                LaunchJava.launchPlayerUUID = "null";
                LaunchJava.launchPlayerAccessToken = "null";
                LaunchJava.launchMpPass = "null";
                if (Globals.requireAuth == true)
                {
                    Instance.btnPlay.Enabled = false;
                    Instance.cmbInstaces.Enabled = false;
                    Instance.btnEditInst.Enabled = false;
                    Instance.btnNewInst.Enabled = false;
                    Instance.lblLogInWarn.Text = Strings.lblLogInWarn;
                }
                else
                {
                    Instance.btnPlay.Enabled = true;
                    Instance.cmbInstaces.Enabled = true;
                    Instance.btnEditInst.Enabled = true;
                    Instance.btnNewInst.Enabled = true;
                    Instance.lblLogInWarn.Text = Strings.lblLogInWarn_Debug;
                }
            }
            else
            {
                Logger.Info($"[HomeScreen]", "User is logged in, re-checking everything");
                MSAuth.usernameFromRefreshToken();
                if (MSAuth.hasErrored == true)
                {
                    Logger.Info($"[HomeScreen]", $"MSAuth returned hasErrored. Please re-log in.");
                    MSAuth.hasErrored = false;
                    Properties.Settings.Default.msRefreshToken = String.Empty;
                    Properties.Settings.Default.Save();
                    checkAuth();
                }
                else
                {
                    Instance.btnLogOut.Visible = true;
                    Instance.btnLogIn.Visible = false;
                    Instance.lblWelcome.Text = $"{Strings.lblWelcome} {msPlayerName}";
                    Instance.btnPlay.Enabled = true;
                    Instance.lblLogInWarn.Text = "";
                    Instance.cmbInstaces.Enabled = true;
                    Instance.btnEditInst.Enabled = true;
                    Instance.btnNewInst.Enabled = true;
                }
            }
        }

        public static void loadInstanceList()
        {
            List<string> instanceList = new List<string>();
            string[] dirs = Directory.GetDirectories($"{Globals.currentPath}\\.codexipsa\\instance\\", "*");

            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if (File.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\{dirName}\\instance.cfg"))
                {
                    string text = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{dirName}\\instance.cfg");
                    if(text.Contains("instVer") && text.Contains("instType"))
                    {
                        updateFromLegacyInst($"{Globals.currentPath}\\.codexipsa\\instance\\{dirName}");
                        instanceList.Add(dirName);
                    }
                    else
                    {
                        instanceList.Add(dirName);
                    }
                }
                else
                {
                    //do nothing
                }

                //Console.WriteLine(dir);
            }
            Instance.cmbInstaces.DataSource = instanceList;
            Instance.cmbInstaces.Refresh();
            LaunchJava.currentInstance = Instance.cmbInstaces.Text;
        }

        public static void reloadInstance(string instName)
        {
            Logger.Info("[HomeScreen/ReloadInstance]", "ReloadInstance called!");
            string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{instName}\\instance.cfg");
            List<instanceObjects> data = JsonConvert.DeserializeObject<List<instanceObjects>>(json);
            foreach (var item in data)
            {
                if(item.edition == "Java Edition" || item.edition == "MinecraftEdu")
                {
                    Logger.Info("[HomeScreen/ReloadInstance]", "Load Java base");
                    selectedEdition = "java";
                    LaunchJava.currentInstance = instName;
                    LaunchJava.launchDir = item.directory;
                    LaunchJava.launchResX = item.resolutionX;
                    LaunchJava.launchResY = item.resolutionY;
                    LaunchJava.launchRamMax = item.ramMax;
                    LaunchJava.launchRamMin = item.ramMin;
                    LaunchJava.launchVerName = item.version;
                    selectedVersion = item.version;
                    LaunchJava.launchVerType = item.type;
                    LaunchJava.launchVerUrl = item.url;
                    LaunchJava.launchJavaLocation = item.customJava;
                    LaunchJava.useCustJava = bool.Parse(item.useCustomJava);
                    LaunchJava.launchJvmArgs = item.jvmArgs;
                    LaunchJava.useCustJvm = bool.Parse(item.useJvmArgs);
                    //LaunchJava.launchMethod = item.launchMethod;
                    if (json.Contains("customJar"))
                    {
                        LaunchJava.useCustJar = bool.Parse(item.useCustomJar);
                        LaunchJava.custJarLocation = item.customJar;
                    }
                    LaunchJava.useOfflineMode = bool.Parse(item.offlineMode);
                    if(json.Contains("useProxy"))
                    {
                        LaunchJava.useProxy = bool.Parse(item.useProxy);
                    }
                    Instance.lblReady.Text = $"{Strings.lblReady} {item.version}";
                }
                else if (item.edition == "Xbox 360 Edition")
                {
                    Logger.Info("[HomeScreen/ReloadInstance]", "Load X360 base");
                    selectedEdition = "x360";
                    LaunchXbox360.ver = item.version;
                    selectedVersion = item.version;
                    LaunchXbox360.url = item.url;
                    LaunchXbox360.type = item.type;
                    Instance.lblReady.Text = $"{Strings.lblReady} {item.version}";
                }
                else if (item.edition == "PlayStation3 Edition")
                {
                    Logger.Info("[HomeScreen/ReloadInstance]", "Load PS3 base");
                }
                else
                {
                    Logger.Error("[HomeScreen/ReloadInstance]", "How did this get called? Whaat!?");
                }
            }
        }

        public static void loadChangelog()
        {
            using (WebClient client = new WebClient())
            {
                int y = 5;
                int x = 2;
                string json = client.DownloadString(Globals.changelogJson);
                List<changelogJson> data = JsonConvert.DeserializeObject<List<changelogJson>>(json);

                foreach (var vers in data)
                {
                    if (vers.type == "header")
                    {
                        Label labelHead = new Label();
                        labelHead.Text = $"{vers.title}";
                        labelHead.Location = new Point(x, y);
                        labelHead.Font = new Font("Arial", 16, FontStyle.Regular);
                        labelHead.AutoSize = true;
                        labelHead.ForeColor = Color.White;
                        Instance.pnlChangelog.Controls.Add(labelHead);
                        y += 14 * 3;
                    }
                    else if (vers.type == "post")
                    {
                        Label labelHead = new Label();
                        labelHead.Text = $"{vers.title}";
                        labelHead.Location = new Point(x, y);
                        labelHead.Font = new Font("Arial", 14, FontStyle.Regular);
                        labelHead.AutoSize = true;
                        labelHead.ForeColor = Color.White;
                        Instance.pnlChangelog.Controls.Add(labelHead);
                        y += 13 * 2;

                        Label labelDate = new Label();
                        labelDate.Text = $"{vers.date}";
                        labelDate.Location = new Point(x, y);
                        labelDate.Font = new Font("Arial", 12, FontStyle.Italic);
                        labelDate.AutoSize = true;
                        labelDate.ForeColor = Color.White;
                        Instance.pnlChangelog.Controls.Add(labelDate);
                        y += 12 * 2;

                        int strLog = 1;
                        string[] result = vers.content.Split(new[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
                        foreach(string s in result)
                        {
                            Label labelText = new Label();
                            labelText.Text = $"{s}";
                            labelText.Location = new Point(x, y);
                            labelText.Font = new Font("Arial", 12, FontStyle.Regular);
                            labelText.AutoSize = true;
                            labelText.ForeColor = Color.White;
                            Instance.pnlChangelog.Controls.Add(labelText);
                            if(strLog < result.Length)
                            {
                                y += 12 * 2;
                            }
                            else if(strLog >= result.Length)
                            {
                                y += 12 * 3;
                            }
                            strLog++;
                        }
                        strLog = 1;
                    }
                    else if (vers.type == "announcement")
                    {
                        Label labelHead = new Label();
                        labelHead.Text = $"{vers.title}";
                        labelHead.Location = new Point(x, y);
                        labelHead.Font = new Font("Arial", 16, FontStyle.Regular);
                        labelHead.AutoSize = true;
                        labelHead.ForeColor = Color.Red;
                        Instance.pnlChangelog.Controls.Add(labelHead);
                        y += 12 * 3;
                    }
                }

                y = y -= 12 * 2;
                Label labelEmpty = new Label();
                labelEmpty.Text = $"";
                labelEmpty.Location = new Point(x, y);
                labelEmpty.Font = new Font("Arial", 12, FontStyle.Regular);
                labelEmpty.AutoSize = true;
                labelEmpty.ForeColor = Color.Red;
                Instance.pnlChangelog.Controls.Add(labelEmpty);
            }
        }

        public static void updateFromLegacyInst(string path)
        {
            int index = path.LastIndexOf("\\") + 1;
            string name = path.Substring(index, path.Length - index);

            string text = File.ReadAllText($"{path}\\instance.cfg");
            if (text.Contains("classroom"))
            {
                text = text.Replace($"[\n{{", $"[\n{{\n\"name\":\"{name}\",\n\"edition\":\"MinecraftEdu\",");
            }
            else
            {
                text = text.Replace($"[\n{{", $"[\n{{\n\"name\":\"{name}\",\n\"edition\":\"Java Edition\",");
            }
            text = text.Replace("instVer", "version");
            text = text.Replace("instType", "type");
            text = text.Replace("instUrl", "url");
            text = text.Replace("instDir", "directory");
            text = text.Replace("instResWidth", "resolutionX");
            text = text.Replace("instResHeight", "resolutionY");
            text = text.Replace("instRamMin", "ramMin");
            text = text.Replace("instRamMax", "ramMax");
            text = text.Replace("useCustJava", "useCustomJava");
            text = text.Replace("instCustJava", "customJava");
            text = text.Replace("useCustJvm", "useJvmArgs");
            text = text.Replace("instCustJvm", "jvmArgs");
            text = text.Replace("useCustMethod", "useLaunchMethod");
            text = text.Replace("instCustMethod", "launchMethod");
            text = text.Replace("\"useCustJar\":\"False\",", String.Empty);
            text = text.Replace("\"instCustJar\":\"\",", String.Empty);
            text = text.Replace("useOfflineMode", "offlineMode");
            Logger.Info("[HomeScreen/updateFromLegacyInst]", $"Updated instance: {name}");
            Console.WriteLine(text);
            File.WriteAllText($"{path}\\instance.cfg", text);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (selectedEdition == "java")
                LaunchJava.LaunchGame();

            else if (selectedEdition == "x360")
                LaunchXbox360.LaunchGame();

            else if (selectedEdition == "edu")
                LaunchJava.LaunchGame();
        }

        private void btnNewInst_Click(object sender, EventArgs e)
        {
            InstanceManager man = new InstanceManager("New profile", "new");
            man.ShowDialog();
        }

        private void btnEditInst_Click(object sender, EventArgs e)
        {
            InstanceManager man = new InstanceManager(cmbInstaces.Text, "edit");
            man.ShowDialog();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //Calling MSAuth
            Logger.Info($"[HomeScreen]", "Calling MSAuth");
            MSAuth auth = new MSAuth();
            auth.ShowDialog();

            if (MSAuth.hasErrored == true)
            {
                Logger.Info($"[HomeScreen]", $"MSAuth returned hasErrored. Please try again.");
                MSAuth.hasErrored = false;
            }
            else
            {
                Instance.btnLogOut.Visible = true;
                Instance.btnLogIn.Visible = false;
                Instance.lblWelcome.Text = $"{Strings.lblWelcome} {msPlayerName}";
                this.Refresh();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Logger.Info($"[HomeScreen]", "Logging out");
            LaunchJava.launchPlayerName = "Guest";
            LaunchJava.launchPlayerUUID = "null";
            LaunchJava.launchPlayerAccessToken = "null";
            LaunchJava.launchMpPass = "null";
            Properties.Settings.Default.msRefreshToken = String.Empty;
            Properties.Settings.Default.Save();
            checkAuth();
        }

        private void cmbInstaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadInstance(cmbInstaces.Text);
            Properties.Settings.Default.lastInstance = cmbInstaces.Text;
            Properties.Settings.Default.Save();
        }

        private void cmbInstaces_Click(object sender, EventArgs e)
        {
            //loadInstanceList();
        }

        private void pnlChangelog_Scroll(object sender, ScrollEventArgs e)
        {
            pnlChangelog.Invalidate();
        }

        /*public static void playBtnDis(string label)
        {
            Instance.btnPlay.Enabled = false;
            Instance.lblLogInWarn.Text = label;
        }

        public static void playBtnEn(string label)
        {
            Instance.btnPlay.Enabled = true;
            Instance.lblLogInWarn.Text = label;
        }*/
    }

    public class changelogJson
    {
        public string type { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string content { get; set; }
        public string brNote { get; set; }
    }
}
