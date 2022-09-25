using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class MainWindow : Form
    {
        public static MainWindow Instance;
        public static string msPlayerName;
        public static string selectedEdition = "java"; //TODO: LOAD THIS FROM INSTANCE

        public MainWindow()
        {
            Instance = this;
            Properties.Settings.Default.Reload();
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Set the window name
            Logger.logMessage($"[MainWindow]", $"MineC#raft Launcher has started!");
            this.Text = $"MineC#raft Launcher v{Globals.verDisplay} [branch {Globals.codebase}]"; //window name
            Console.Title = $"MineC#raft Launcher v{Globals.verDisplay} [branch {Globals.codebase}] CONSOLE";
            Logger.logMessage($"[MainWindow]", $"Version {Globals.verDisplay}, Branch {Globals.codebase}");

            //Changelog url
            webBrowser1.Url = new Uri(Globals.changelog, UriKind.Absolute);
            webBrowser1.Refresh();
            Logger.logMessage($"[MainWindow]", $"Changelog loaded");

            /*HomeWindow hw = new HomeWindow();
            Controls.Add(hw);
            hw.Dock = DockStyle.Fill;*/

            //Create directories
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\versions");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\assets");

            //Check if user is logged in
            checkAuth();

            //Delete updater if it exists
            if (File.Exists($"{Globals.currentPath}\\LauncherUpdater.exe"))
                File.Delete($"{Globals.currentPath}\\LauncherUpdater.exe");
            if (File.Exists($"{Globals.currentPath}\\.codexipsa\\update.cfg"))
                File.Delete($"{Globals.currentPath}\\.codexipsa\\update.cfg");

            //Check for updates
            Logger.logMessage($"[MainWindow]", "Checking for updates..");
            List<string> branchIds = new List<string>();

            using (WebClient client = new WebClient())
            {
                string jsonUpd = client.DownloadString(Globals.updateInfo);
                List<jsonObject> dataUpd = JsonConvert.DeserializeObject<List<jsonObject>>(jsonUpd);

                foreach (var vers in dataUpd)
                {
                    branchIds.Add(vers.brId);
                }

                int index = branchIds.FindIndex(x => x.StartsWith(Globals.branch));
                Logger.logMessage($"[MainWindow]", $"Branch {Globals.branch} is on {index}");

                if(index == -1)
                {
                    Logger.logError("[MainWindow]", $"Current branch is no longer supported!");
                    Warning wrn = new Warning("Your branch is no longer supported!");
                    wrn.ShowDialog();
                }
                else
                {
                    Settings.checkForUpdates(Globals.branch);
                }

                //TODO: set selectedIndex
            }

            if (!Directory.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\Default"))
            {
                InstanceManager.mode = "initial";
                InstanceManager.tempName = "Default";
                InstanceManager.createInstance();
            }
            loadInstanceList();

            string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{InstanceManager.selectedInstance}\\instance.cfg");
            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

            //Set the LaunchJava stuff
            foreach (var vers in data)
            {
                LaunchJava.launchVerName = vers.instVer;
                LaunchJava.launchVerUrl = vers.instUrl;
                LaunchJava.launchVerType = vers.instType;
            }
            Instance.gameVerLabel.Text = "Ready to play Minecraft " + LaunchJava.launchVerName;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (selectedEdition == "java")
                LaunchJava.LaunchGame();

            else if (selectedEdition == "x360")
                LaunchXbox360.LaunchGame();

            else if (selectedEdition == "ps3")
                LaunchPS3.LaunchGame();
            else if (selectedEdition == "edu")
                LaunchJava.LaunchGame();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About credits = new About();
            credits.ShowDialog();
        }

        private void changeVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerSelect verSelect = new VerSelect();
            verSelect.ShowDialog();


            if (VerSelect.checkTab == "java")
            {
                gameVerLabel.Text = "Ready to play Minecraft " + LaunchJava.selectedVer;
            }

            else if (VerSelect.checkTab == "javaMod")
            {
                gameVerLabel.Text = "Ready to play Modded " + LaunchJavaMod.selectedVer;
            }

            else if (VerSelect.checkTab == "x360")
            {
                gameVerLabel.Text = "Ready to play Minecraft X360 " + LaunchXbox360.selectedVer;
            }

            else if (VerSelect.checkTab == "ps3")
            {
                gameVerLabel.Text = "Ready to play Minecraft PS3 " + LaunchPS3.selectedVer;
            }
        }

        private void profilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstanceManager instMan = new InstanceManager();
            instMan.ShowDialog();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            loadInstanceList();
        }

        public void loadInstanceList()
        {
            List<string> instanceList = new List<string>();
            string[] dirs = Directory.GetDirectories($"{Globals.currentPath}\\.codexipsa\\instance\\", "*");

            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if(File.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\{dirName}\\instance.cfg"))
                {
                    instanceList.Add(dirName);
                }
                else
                {
                    //do nothing
                }

                //Console.WriteLine(dir);
            }
            comboBox1.DataSource = instanceList;
            comboBox1.Refresh();
            LaunchJava.instanceName = comboBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadInstance();
        }

        public static void reloadInstance()
        {
            if (InstanceManager.mode != "initial")
            {
                InstanceManager.selectedInstance = Instance.comboBox1.Text;
            }

            Logger.logMessage("[MainWindow]", $"Selected instance: {InstanceManager.selectedInstance}");

            string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{InstanceManager.selectedInstance}\\instance.cfg");
            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

            //Set the LaunchJava stuff
            foreach (var vers in data)
            {
                LaunchJava.launchVerName = vers.instVer;
                LaunchJava.launchVerUrl = vers.instUrl;
                LaunchJava.launchVerType = vers.instType;
                LaunchJava.launchWidth = vers.instResWidth;
                LaunchJava.launchHeight = vers.instResHeight;
                LaunchJava.launchXms = vers.instRamMin;
                LaunchJava.launchXmx = vers.instRamMax;
                //LaunchJava.javaLocation = vers.instCustJava;
                //LaunchJava.use //TODO!!!
            }
            LaunchJava.currentInstance = Instance.comboBox1.Text;
            Instance.gameVerLabel.Text = "Ready to play Minecraft " + LaunchJava.launchVerName;
        }

        private void newInstBtn_Click(object sender, EventArgs e)
        {
            InstanceManager.cfgInstName = "New profile";
            InstanceManager.mode = "new";
            InstanceManager instMan = new InstanceManager();
            instMan.ShowDialog();
        }

        private void editInstBtn_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{InstanceManager.selectedInstance}\\instance.cfg");
            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

            //Set the data
            /*foreach (var vers in data)
            {
                InstanceManager.cfgGameVer = vers.gameVer;
                InstanceManager.cfgTypeVer = vers.typeVer;
            }*/

            InstanceManager.cfgInstName = comboBox1.Text;
            InstanceManager.mode = "edit";
            InstanceManager instMan = new InstanceManager();
            instMan.ShowDialog();
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugTools dt = new DebugTools();
            dt.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings stg = new Settings();
            stg.ShowDialog();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //Calling MSAuth
            Logger.logMessage($"[MainWindow]", "Calling MSAuth");
            MSAuth auth = new MSAuth();
            auth.ShowDialog();

            if(MSAuth.hasErrored == true)
            {
                Logger.logMessage($"[MainWindow]", $"MSAuth returned hasErrored. Please try again.");
                MSAuth.hasErrored = false;
            }
            else
            {
                Instance.logoutBtn.Visible = true;
                Instance.loginBtn.Visible = false;
                Instance.playerNameLabel.Text = $"Welcome, {msPlayerName}";
                this.Refresh();
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Logger.logMessage($"[MainWindow]", "Logging out");
            LaunchJava.launchPlayerName = "Guest";
            LaunchJava.launchPlayerUUID = "null";
            LaunchJava.launchPlayerAccessToken = "null";
            LaunchJava.launchMpPass = "null";
            Properties.Settings.Default.msRefreshToken = String.Empty;
            Properties.Settings.Default.Save();
            checkAuth();
        }

        public static void checkAuth()
        {
            if (Properties.Settings.Default.msRefreshToken == String.Empty || Properties.Settings.Default.msRefreshToken == null)
            {
                Logger.logError($"[MainWindow]", "User is not logged in");
                Instance.logoutBtn.Visible = false;
                Instance.loginBtn.Visible = true;
                Instance.playerNameLabel.Text = "Welcome, Guest";
                LaunchJava.launchPlayerName = "Guest";
                LaunchJava.launchPlayerUUID = "null";
                LaunchJava.launchPlayerAccessToken = "null";
                LaunchJava.launchMpPass = "null";
                if(Globals.requireAuth == true)
                {
                    Instance.btnPlay.Enabled = false;
                    Instance.loginLabel.Text = "You need to log in to use the launcher!";
                }
                else
                {
                    Instance.btnPlay.Enabled = true;
                    Instance.loginLabel.Text = "MAKE SURE TO DISABLE THIS IN GLOBALS!!!";
                }
            }
            else
            {
                Logger.logMessage($"[MainWindow]", "User is logged in, re-checking everything");
                MSAuth.usernameFromRefreshToken();
                if(MSAuth.hasErrored == true)
                {
                    Logger.logMessage($"[MainWindow]", $"MSAuth returned hasErrored. Please re-log in.");
                    MSAuth.hasErrored = false;
                    Properties.Settings.Default.msRefreshToken = String.Empty;
                    Properties.Settings.Default.Save();
                    checkAuth();
                }
                else
                {
                    Instance.logoutBtn.Visible = true;
                    Instance.loginBtn.Visible = false;
                    Instance.playerNameLabel.Text = $"Welcome, {msPlayerName}";
                    Instance.btnPlay.Enabled = true;
                    Instance.loginLabel.Text = "";
                }
            }
        }
    }
}
