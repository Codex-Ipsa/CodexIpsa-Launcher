using MCLauncher.classes;
using MCLauncher.classes.jsons;
using MCLauncher.forms;
using MCLauncher.json.api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class HomeScreen : UserControl
    {
        public static HomeScreen Instance;
        public static string selectedEdition; //for checking which edition to launch
        public static string msPlayerName; //for "welcome" string
        public static string selectedInstance = "Default";
        public static string selectedVersion; //for the "ready to play X" string

        public static string lastInstance;

        public HomeScreen()
        {
            Instance = this;
            InitializeComponent();
            Logger.Info("[HomeScreen]", $"Last instance: {Settings.sj.instance}");
            lastInstance = Settings.sj.instance;

            if (File.Exists($"{Globals.dataPath}\\data\\seasonalDirt.png"))
            {
                panel1.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalDirt.png");
            }

            //Check if user is logged in
            checkAuth();

            if (!File.Exists($"{Globals.dataPath}\\instance\\Default\\instance.json") && !File.Exists($"{Globals.dataPath}\\instance\\Default\\instance.cfg"))
            {
                Profile prof = new Profile("Default", "def");
            }

            Logger.Info("[TEST0]", selectedInstance);
            loadInstanceList();
            selectedInstance = lastInstance;
            if (!File.Exists($"{Globals.dataPath}\\instance\\{selectedInstance}\\instance.json"))
                selectedInstance = "Default";
            Instance.cmbInstaces.SelectedIndex = Instance.cmbInstaces.FindString(selectedInstance);

            webBrowser1.Url = new Uri(Globals.changelogUrl);

            Discord.Init();
            Discord.ChangeMessage("Idling");
        }

        public static void checkAuth()
        {
            if (Settings.sj.refreshToken == String.Empty || Settings.sj.refreshToken == null)
            {
                Logger.Error($"[HomeScreen]", "User is not logged in");
                Instance.btnLogOut.Visible = false;
                Instance.btnLogIn.Visible = true;
                Instance.lblWelcome.Text = Strings.sj.lblWelcome.Replace("{playerName}", "Guest");

                JavaLauncher.msPlayerName = "Guest";
                JavaLauncher.msPlayerAccessToken = "fakeAccessTokenThisIsNotReal";
                JavaLauncher.msPlayerUUID = "fakePlayerIDThisIsNotReal";
                JavaLauncher.msPlayerMPPass = "fakeMPPassThisIsNotReal";

                if (Globals.requireAuth == true)
                {
                    Instance.btnPlay.Enabled = false;
                    Instance.cmbInstaces.Enabled = false;
                    Instance.btnEditInst.Enabled = false;
                    Instance.btnNewInst.Enabled = false;
                    Instance.lblLogInWarn.Text = Strings.sj.lblLogInWarn;
                }
                else
                {
                    Instance.btnPlay.Enabled = true;
                    Instance.cmbInstaces.Enabled = true;
                    Instance.btnEditInst.Enabled = true;
                    Instance.btnNewInst.Enabled = true;
                    Instance.lblLogInWarn.Text = Strings.sj.lblLogInWarn_Debug;
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
                    Settings.sj.refreshToken = String.Empty;
                    Settings.Save();
                    checkAuth();
                }
                else
                {
                    Instance.btnLogOut.Visible = true;
                    Instance.btnLogIn.Visible = false;
                    Instance.lblWelcome.Text = Strings.sj.lblWelcome.Replace("{playerName}", msPlayerName);
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
                    }
                    if (text.Contains("\"proxy\": true"))
                    {
                        text = text.Replace("\"proxy\": true", "\"disProxy\": false");
                        File.WriteAllText(($"{Globals.dataPath}\\instance\\{dirName}\\instance.json"), text);
                    }
                    else if (text.Contains("\"proxy\": false"))
                    {
                        text = text.Replace("\"proxy\": false", "\"disProxy\": false");
                        File.WriteAllText(($"{Globals.dataPath}\\instance\\{dirName}\\instance.json"), text);
                    }

                    instanceList.Add(dirName);
                }
                else if (File.Exists($"{Globals.dataPath}\\instance\\{dirName}\\instance.cfg"))
                {
                    updateFromSecondInst($"{Globals.dataPath}\\instance\\{dirName}\\");
                    instanceList.Add(dirName);
                }
            }
            Instance.cmbInstaces.DataSource = instanceList;
            Instance.cmbInstaces.Refresh();
            Profile.profileName = Instance.cmbInstaces.Text;
        }

        public static void reloadInstance(string instName)
        {
            //TODO this needs some rewrite so i don't need to do "Minecraft " + versionName lmaoo

            Logger.Info("[HomeScreen/reloadInstance]", $"Reload for {instName}");
            string json = File.ReadAllText($"{Globals.dataPath}\\instance\\{instName}\\instance.json");
            var pj = JsonConvert.DeserializeObject<profileJson>(json);
            selectedInstance = Instance.cmbInstaces.Text;
            selectedVersion = "Minecraft " + pj.version;
            //selectedVersion = pj.version;
            selectedEdition = pj.edition;

            Logger.Info("[HomeScreen/reloadInstance]", $"ver: {selectedVersion}, ed: {selectedEdition}");

            if (selectedVersion.Contains("latest"))
            {
                selectedVersion = "Minecraft " + getLatestVersion(pj.version);
            }

            string modJson = File.ReadAllText($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\mods.json");

            string tempName = null;
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(modJson);
            foreach (ModJsonEntry ent in mj.items)
            {
                if (ent.disabled == false)
                {
                    if (tempName == null && !String.IsNullOrWhiteSpace(ent.name) && !String.IsNullOrWhiteSpace(ent.version))
                    {
                        tempName = ent.name + " " + ent.version;
                    }
                }
            }
            if (!String.IsNullOrWhiteSpace(tempName))
            {
                selectedVersion = tempName;
            }

            Instance.lblReady.Text = Strings.sj.lblReady.Replace("{verInfo}", selectedVersion);
            Profile.profileName = Instance.cmbInstaces.Text;
        }

        public static void updateFromSecondInst(string path)
        {
            string content = File.ReadAllText($"{path}\\instance.cfg");
            var orig = JsonConvert.DeserializeObject<List<instanceV2>>(content);

            foreach (var oj in orig)
            {
                string saveData = "";
                saveData += $"{{\n";
                saveData += $"  \"data\": 2,\n";
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
                saveData += $"  \"useJava\": {bool.Parse(oj.useCustomJava.ToString().ToLower()).ToString().ToLower()},\n";
                saveData += $"  \"javaPath\": \"{oj.customJava}\",\n";
                saveData += $"  \"useJson\": false,\n";
                saveData += $"  \"jsonPath\": \"\",\n";
                saveData += $"  \"useClass\": false,\n";
                saveData += $"  \"classpath\": \"\",\n";
                saveData += $"  \"demo\": false,\n";
                saveData += $"  \"modded\": false,\n";
                saveData += $"  \"offline\": {bool.Parse(oj.offlineMode.ToString().ToLower()).ToString().ToLower()},\n";
                saveData += $"  \"disProxy\": false,\n";
                saveData += $"  \"multiplayer\": false,\n";
                saveData += $"  \"xboxDemo\": false,\n";
                saveData += $"  \"useAssets\": false,\n";
                saveData += $"  \"assetsPath\": \"\"\n";
                saveData += $"}}";
                Logger.Info("[HomeScreen/updateFromLegacyInst]", $"Updated instance");
                Console.WriteLine(saveData);
                File.WriteAllText($"{path}\\instance.json", saveData);
                File.Delete($"{path}\\instance.cfg");
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
            if (selectedEdition == "x360")
                XboxLauncher.Launch(selectedInstance);
            else
            {
                JavaLauncher jl = new JavaLauncher();
                jl.Launch(selectedInstance);
            }
            /*if (selectedEdition == "java")
                LaunchJava.LaunchGame();

            else if (selectedEdition == "x360")
                LaunchXbox360.LaunchGame();

            else if (selectedEdition == "edu")
                LaunchJava.LaunchGame();*/
        }

        private void btnNewInst_Click(object sender, EventArgs e)
        {
            NewInstance ni = new NewInstance();
            ni.ShowDialog();
        }

        private void btnEditInst_Click(object sender, EventArgs e)
        {
            EditInstance ei = new EditInstance(selectedInstance);
            ei.ShowDialog();
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
                Instance.lblWelcome.Text = Strings.sj.lblWelcome.Replace("{playerName}", msPlayerName);
                this.Refresh();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Logger.Info($"[HomeScreen]", "Logging out");

            JavaLauncher.msPlayerName = "Guest";
            JavaLauncher.msPlayerAccessToken = "fakeAccessTokenThisIsNotReal";
            JavaLauncher.msPlayerUUID = "fakePlayerIDThisIsNotReal";
            JavaLauncher.msPlayerMPPass = "fakeMPPassThisIsNotReal";

            Settings.sj.refreshToken = String.Empty;
            Settings.Save();
            checkAuth();
        }

        private void cmbInstaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.Info("[TEST2]", cmbInstaces.Text);
            reloadInstance(cmbInstaces.Text);
            Settings.sj.instance = cmbInstaces.Text;
            Settings.Save();
        }

        private void cmbInstaces_Click(object sender, EventArgs e)
        {
            //loadInstanceList();
        }

        //gets latest snapshot or release version
        public static String getLatestVersion(String whichOne)
        {
            String latestJson = "";
            using (WebClient cl = new WebClient())
            {
                latestJson = cl.DownloadString(Globals.javaLatest);
            }

            LatestVersionJson lj = JsonConvert.DeserializeObject<LatestVersionJson>(latestJson);

            if (whichOne == "latest")
            {
                Logger.Info("[HomeScreen/reloadInstance]", $"Translate 'latest' to {lj.release}");
                return lj.release;
            }
            else if (whichOne == "latestsnapshot")
            {
                Logger.Info("[HomeScreen/reloadInstance]", $"Translate 'latestsnapshot' to {lj.snapshot}");
                return lj.snapshot;
            }

            //this shouldn't happen but it wont compile
            return null;
        }
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
        public string useCustomJava { get; set; }
        public string customJava { get; set; }
        public string offlineMode { get; set; }
        public string useProxy { get; set; }
        public string jvmArgs { get; set; }
    }
}
