using MCLauncher.classes;
using MCLauncher.forms;
using MCLauncher.json.api;
using MCLauncher.json.launcher;
using MCLauncher.launchers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class HomeScreen : UserControl
    {
        public static HomeScreen Instance;
        public static string selectedEdition; //for checking which edition to launch

        public static string selectedInstance = "Default";
        public static string selectedVersion; //for the "ready to play X" string

        public static string lastInstance;

        public bool initialized = false;

        public HomeScreen()
        {
            Instance = this;
            InitializeComponent();

            Logger.Info("[HomeScreen]", $"Last instance: {Settings.sj.instance}");
            lastInstance = Settings.sj.instance;

            panel1.BackgroundImage = Themes.dirt;

            //Check if user is logged in
            checkAuth();

            if (!File.Exists($"{Globals.dataPath}\\instance\\Default\\instance.json"))
            {
                InstanceJson ij = new InstanceJson();
                ij.data = 3;
                ij.edition = "java";
                ij.version = "b1.7.3";
                ij.resolution = "854 480";
                ij.memory = "512 512";
                String serialized = JsonConvert.SerializeObject(ij);

                Directory.CreateDirectory($"{Globals.dataPath}\\instance\\Default\\jarmods");
                File.WriteAllText($"{Globals.dataPath}\\instance\\Default\\instance.json", serialized);

                ModJson mj = new ModJson();
                mj.items = new ModJsonEntry[0];

                String modJson = JsonConvert.SerializeObject(mj);
                File.WriteAllText($"{Globals.dataPath}\\instance\\Default\\jarmods\\mods.json", modJson);
            }

            loadInstanceList();
            initialized = true;

            selectedInstance = lastInstance;
            if (!File.Exists($"{Globals.dataPath}\\instance\\{selectedInstance}\\instance.json"))
                selectedInstance = "Default";

            int instanceIndex = Instance.cmbInstaces.FindString(selectedInstance); ;
            Instance.cmbInstaces.SelectedIndex = instanceIndex;
            if (instanceIndex == 0) //this fixes loading instance if last selected is the first one in combobox
            {
                reloadInstance(cmbInstaces.Text);
            }

            if (!Globals.offlineMode)
            {
                String changelog = Globals.client.DownloadString(Globals.changelogUrl).Replace("http://files.codex-ipsa.cz/seasonal/defaultStone.png", Themes.stonePath);
                webBrowser1.DocumentText = changelog;
            }
            else
            {
                webBrowser1.DocumentText = "<center><b>Internet connection not available.</b><br>This feature is in an early phase, expect things to be broken!</center>";
            }

            Discord.Init();
            Discord.ChangeMessage("Idling");
        }

        //checks for authentication
        public static void checkAuth()
        {
            Logger.Info("[HomeScreen/checkAuth]", "Checking authentication...");

            if (Settings.sj.refreshToken == String.Empty || Settings.sj.refreshToken == null)
            {
                Logger.Error($"[HomeScreen]", "User is not logged in");
                loadUserInfo("Guest", Strings.sj.lblLogInWarn);
                enableButtons(false);

                MSAuth.msUsername = "Guest";
                MSAuth.msAccessToken = "fakeuuid";
                MSAuth.msUUID = "fakeaccess";
            }
            else
            {
                Logger.Info($"[HomeScreen]", "User is logged in, re-checking everything");

                if (Globals.offlineMode)
                {
                    Logger.Info($"[HomeScreen]", "Offline mode active, loading cached info");
                    MSAuth.msUsername = Settings.sj.username;
                    MSAuth.msAccessToken = "fakeuuid";
                    MSAuth.msUUID = "fakeaccess";
                    return;
                }
                else
                {
                    MSAuth.refreshAuth(false);
                }
            }

            Logger.Info("[HomeScreen/checkAuth]", $"TOKEN: {MSAuth.msAccessToken}");
        }

        //loads user info and auth message
        public static void loadUserInfo(String username, String authMsg)
        {
            Instance.lblWelcome.Text = Strings.sj.lblWelcome.Replace("{playerName}", username);
            Instance.lblLogInWarn.Text = authMsg;
        }

        //enables/disables buttons depending on auth status
        public static void enableButtons(bool enable)
        {
            Instance.btnLogOut.Visible = enable;
            Instance.btnLogIn.Visible = !enable;

            Instance.btnPlay.Enabled = enable;

            Instance.cmbInstaces.Enabled = enable;
            Instance.btnEditInst.Enabled = enable;
            Instance.btnNewInst.Enabled = enable;

            Instance.lblLogInWarn.Visible = !enable;
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
                    instanceList.Add(dirName);
                }
            }
            Instance.cmbInstaces.DataSource = instanceList;
            Instance.cmbInstaces.Refresh();
        }

        public static void reloadInstance(string instName)
        {
            //TODO this needs some rewrite so i don't need to do "Minecraft " + versionName lmaoo

            Logger.Info("[HomeScreen/reloadInstance]", $"Reload for {instName}");
            string json = File.ReadAllText($"{Globals.dataPath}\\instance\\{instName}\\instance.json");
            InstanceJson ij = JsonConvert.DeserializeObject<InstanceJson>(json);
            selectedInstance = Instance.cmbInstaces.Text;
            selectedVersion = "Minecraft " + ij.version;
            selectedEdition = ij.edition;

            Logger.Info("[HomeScreen/reloadInstance]", $"ver: {selectedVersion}, ed: {selectedEdition}");

            if (selectedVersion.Contains("latest"))
            {
                selectedVersion = "Minecraft " + getLatestVersion(ij.version);
            }

            //get mod name
            if(!File.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\mods.json")) //if file doesn't exist for some reason
            {
                File.WriteAllText($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\mods.json", "{\"items\":[]}");
            }

            string modJson = File.ReadAllText($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\mods.json");
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(modJson);
           
            var modInfo = ModWorker.getPatchName(mj);
            if (modInfo.Item2 != null)
            {
                selectedVersion = $"{modInfo.Item1} {modInfo.Item2}";
            }

            //Ready to play text
            Instance.lblReady.Text = Strings.sj.lblReady.Replace("{verInfo}", selectedVersion);
            Instance.loadPlayTime(instName, ij);
        }

        public void loadPlayTime(String instanceName, InstanceJson ij)
        {
            if (instanceName != cmbInstaces.Text)
                return;

            //Played for text
            TimeSpan t = TimeSpan.FromMilliseconds(ij.playTime);
            String playedForText = "Played for ";
            if (t.Days == 1)
                playedForText += $"{t.Days} {Strings.sj.lblPlayedForDay} ";
            else if (t.Days > 1)
                playedForText += $"{t.Days} {Strings.sj.lblPlayedForDays} ";

            if (t.Hours == 1)
                playedForText += $"{t.Hours} {Strings.sj.lblPlayedForHour} ";
            else if (t.Hours > 1)
                playedForText += $"{t.Hours} {Strings.sj.lblPlayedForHours} ";

            if (t.Minutes == 1)
                playedForText += $"{t.Minutes} {Strings.sj.lblPlayedForMinute} ";
            else if (t.Minutes > 1)
                playedForText += $"{t.Minutes} {Strings.sj.lblPlayedForMinutes} ";

            if (t.Seconds == 1)
                playedForText += $"{t.Seconds} {Strings.sj.lblPlayedForSecond}";
            else if (t.Seconds > 1)
                playedForText += $"{t.Seconds} {Strings.sj.lblPlayedForSeconds}";

            if (t.TotalMilliseconds == 0)
                playedForText = Strings.sj.lblHaventPlayed;

            lblPlayedFor.Text = playedForText;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (selectedEdition == "x360")
            {
                XboxLauncher.Launch(selectedInstance);
            }
            else
            {
                JavaLauncher.Launch(selectedInstance);
            }
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
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Logger.Info($"[HomeScreen]", "Logging out");

            MSAuth.msUsername = "Guest";
            MSAuth.msAccessToken = "fakeuuid";
            MSAuth.msUUID = "fakeaccess";

            Settings.sj.refreshToken = String.Empty;
            Settings.Save();
            checkAuth();
        }

        private void cmbInstaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Logger.Info("[TEST2]", cmbInstaces.Text);
            if (initialized == true)
            {
                reloadInstance(cmbInstaces.Text);
                Settings.sj.instance = cmbInstaces.Text;
                Settings.Save();
            }
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
}
