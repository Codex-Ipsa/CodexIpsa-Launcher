using MCLauncher.classes;
using MCLauncher.forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
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
        public static string selectedEdition; //for checking which edition to launch
        public static string msPlayerName; //for "welcome" string
        public static string selectedInstance = "Default";
        public static string selectedVersion; //for the "ready to play X" string

        public HomeScreen()
        {
              
            Instance = this;
            InitializeComponent();
            
            DateTime ignore = new DateTime(2023, 4, 1);
            if (ignore.ToString("d-M-yyyy") == DateTime.Now.ToString("d-M-yyyy"))
            {
                int count = int.Parse(Globals.client.DownloadString("http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/april2023/count.txt"));
                Random ran = new Random();
                int adI = ran.Next(1, count);
                Directory.CreateDirectory($"{Globals.dataPath}\\data\\ignore\\");
                Globals.client.DownloadFile($"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/april2023/{adI}.png", $"{Globals.dataPath}\\data\\ignore\\{adI}.png");
                adPanel.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\ignore\\{adI}.png");
                adPanel.BringToFront();
            }
            else
                adPanel.Visible = false;

            Logger.Info("[HomeScreen]", $"Last instance: {Properties.Settings.Default.lastInstance}");

            if(Properties.Settings.Default.lastInstance == String.Empty || Properties.Settings.Default.lastInstance == null)
                selectedInstance = "Default";
            else
                selectedInstance = Properties.Settings.Default.lastInstance;

            pnlChangelog.AutoScroll = true;

            if (File.Exists($"{Globals.dataPath}\\data\\seasonalDirt.png"))
            {
                panel1.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalDirt.png");
            }
            if (File.Exists($"{Globals.dataPath}\\data\\seasonalStone.png"))
            {
                this.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalStone.png");
            }

            //JSON changelog system
            loadChangelog();

            //Check if user is logged in
            checkAuth();

            if (!File.Exists($"{Globals.dataPath}\\instance\\Default\\instance.json"))
            {
                Profile prof = new Profile("Default", "def");
            }       

            //Load instance list
            loadInstanceList();
            if(!File.Exists($"{Globals.dataPath}\\instance\\{selectedInstance}\\instance.json"))
            {
                selectedInstance = "Default";
            }
            cmbInstaces.SelectedIndex = cmbInstaces.FindString(selectedInstance);
            reloadInstance(selectedInstance);

            string json = File.ReadAllText($"{Globals.dataPath}\\instance\\{selectedInstance}\\instance.json");
            var pj = JsonConvert.DeserializeObject<profileJson>(json);
            Profile.version = pj.version;
            selectedVersion = pj.version;
            selectedEdition = pj.edition;
            Instance.lblReady.Text = $"{Strings.lblReady} {pj.version}";
        }

        public static void checkAuth()
        {
            if (Properties.Settings.Default.msRefreshToken == String.Empty || Properties.Settings.Default.msRefreshToken == null)
            {
                Logger.Error($"[HomeScreen]", "User is not logged in");
                Instance.btnLogOut.Visible = false;
                Instance.btnLogIn.Visible = true;
                Instance.lblWelcome.Text = $"{Strings.lblWelcome} Guest";

                JavaLauncher.msPlayerName = "Guest";
                JavaLauncher.msPlayerAccessToken = "-";
                JavaLauncher.msPlayerUUID = "-";
                JavaLauncher.msPlayerMPPass = "-";

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
            string[] dirs = Directory.GetDirectories($"{Globals.dataPath}\\instance\\", "*");

            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if (File.Exists($"{Globals.dataPath}\\instance\\{dirName}\\instance.json"))
                {
                    string text = File.ReadAllText($"{Globals.dataPath}\\instance\\{dirName}\\instance.json");
                    if (text.Contains("instVer") && text.Contains("instType"))
                    {
                        updateFromFirstInst($"{Globals.dataPath}\\instance\\{dirName}");
                        instanceList.Add(dirName);
                    }
                    else
                    {
                        instanceList.Add(dirName);
                    }
                }
                else if(File.Exists($"{Globals.dataPath}\\instance\\{dirName}\\instance.cfg"))
                {
                    updateFromSecondInst($"{Globals.dataPath}\\instance\\{dirName}\\instance.cfg");
                }

                //Console.WriteLine(dir);
            }
            Instance.cmbInstaces.DataSource = instanceList;
            Instance.cmbInstaces.Refresh();
            LaunchJava.currentInstance = Instance.cmbInstaces.Text;
        }

        public static void reloadInstance(string instName)
        {
            Logger.Info("HomeScreen/reloadInstance", $"Reload for {instName}");
            string json = File.ReadAllText($"{Globals.dataPath}\\instance\\{instName}\\instance.json");
            var pj = JsonConvert.DeserializeObject<profileJson>(json);
            selectedVersion = pj.version;
            selectedEdition = pj.edition;
            Instance.lblReady.Text = $"{Strings.lblReady} {pj.version}";
        }

        public static void loadChangelog()
        {
            using (WebClient client = new WebClient())
            {
                int y = 5;
                int x = 2;
                try
                {
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
                            string[] result = vers.content.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string s in result)
                            {
                                Label labelText = new Label();
                                labelText.Text = $"{s}";
                                labelText.Location = new Point(x, y);
                                labelText.Font = new Font("Arial", 12, FontStyle.Regular);
                                labelText.AutoSize = true;
                                labelText.ForeColor = Color.White;
                                Instance.pnlChangelog.Controls.Add(labelText);
                                if (strLog < result.Length)
                                {
                                    y += 12 * 2;
                                }
                                else if (strLog >= result.Length)
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
                catch (WebException e)
                {
                    Label labelHead = new Label();
                    labelHead.Text = $"Failed to load changelog!";
                    labelHead.Location = new Point(x, y);
                    labelHead.Font = new Font("Arial", 16, FontStyle.Regular);
                    labelHead.AutoSize = true;
                    labelHead.ForeColor = Color.Red;
                    Instance.pnlChangelog.Controls.Add(labelHead);
                    y += 12 * 3;
                }
            }
        }

        public static void updateFromSecondInst(string path)
        {
            var orig = JsonConvert.DeserializeObject<List<instanceV2>>(path);

            foreach (var oj in orig)
            {
                string saveData = "";
                saveData += $"{{\n";
                saveData += $"  \"data\": 1,\n";
                if (oj.edition == "Java Edition")
                    saveData += $"  \"edition\": \"java\",\n";
                else if (oj.edition == "Xbox 360 Edition")
                    saveData += $"  \"edition\": \"x360\",\n";
                saveData += $"  \"version\": \"{oj.version}\",\n";
                saveData += $"  \"directory\": \"{oj.directory}\",\n";
                saveData += $"  \"resolution\": \"{oj.resolutionX} {oj.resolutionY}\",\n";
                saveData += $"  \"memory\": \"{oj.ramMax} {oj.ramMin}\",\n";
                saveData += $"  \"befCmd\": \"\",\n";
                saveData += $"  \"aftCmd\": \"{oj.jvmArgs}\",\n";
                saveData += $"  \"javaPath\": \"{oj.customJava}\",\n";
                saveData += $"  \"jsonPath\": \"\",\n";
                saveData += $"  \"demo\": false,\n";
                saveData += $"  \"offline\": {bool.Parse(oj.offlineMode.ToLower())},\n";
                saveData += $"  \"proxy\": {bool.Parse(oj.useProxy.ToLower())},\n";
                saveData += $"  \"multiplayer\": false\n";
                saveData += $"}}";
                //TODO
            }
        }

        public static void updateFromFirstInst(string path)
        {
            int index = path.LastIndexOf("\\") + 1;
            string name = path.Substring(index, path.Length - index);

            string text = File.ReadAllText($"{path}\\instance.json");
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
            JavaLauncher.Launch(selectedInstance);
            /*if (selectedEdition == "java")
                LaunchJava.LaunchGame();

            else if (selectedEdition == "x360")
                LaunchXbox360.LaunchGame();

            else if (selectedEdition == "edu")
                LaunchJava.LaunchGame();*/
        }

        private void btnNewInst_Click(object sender, EventArgs e)
        {
            Profile pr = new Profile("New profile", "new");
            pr.ShowDialog();
            /*InstanceManager man = new InstanceManager("New profile", "new");
            man.ShowDialog();*/
        }

        private void btnEditInst_Click(object sender, EventArgs e)
        {
            Profile pr = new Profile(cmbInstaces.Text, "edit");
            pr.ShowDialog();
            /*InstanceManager man = new InstanceManager(cmbInstaces.Text, "edit");
            man.ShowDialog();*/
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

            JavaLauncher.msPlayerName = "Guest";
            JavaLauncher.msPlayerAccessToken = "-";
            JavaLauncher.msPlayerUUID = "-";
            JavaLauncher.msPlayerMPPass = "-";

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

        private void adPanel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://dejvoss.cz/secret/");
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

    public class profileJson
    {
        public int data { get; set; }
        public string version { get; set; }
        public string edition { get; set; }
    }

    public class instanceV2
    {
        public string name { get; set; }
        public string edition { get; set; }
        public string version { get; set; }
        public string directory { get; set; }
        public string resolutionX { get; set; }
        public string resolutionY { get; set; }
        public string ramMin { get; set; }
        public string ramMax { get; set; }
        public string customJava { get; set; }
        public string offlineMode { get; set; }
        public string useProxy { get; set; }
        public string jvmArgs { get; set; }
    }
}
