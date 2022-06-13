using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class MainWindow : Form
    {
        public static MainWindow Instance;

        public MainWindow()
        {
            Instance = this;
            Properties.Settings.Default.Reload();
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Set required things
            Logger.Log("Launcher started");
            this.Text = "MineC#raft Launcher v" + Globals.verDisplay; //window name
            webBrowser1.Url = new Uri(Globals.changelog, UriKind.Absolute); //changelog URL
            webBrowser1.Refresh();
            playerNameLabel.Text = "Welcome, " + Properties.Settings.Default.playerName; //username

            //Delete updaters if they exist for some reason
            if (File.Exists(Path.Combine(Globals.currentPath + "\\MCLauncherUpdater.exe")))
            {
                File.Delete(Globals.currentPath + "\\MCLauncherUpdater.exe");
            }
            if (File.Exists(Path.Combine(Globals.currentPath + "\\MCLauncherUpdaterDev.exe")))
            {
                File.Delete(Globals.currentPath + "\\MCLauncherUpdaterDev.exe");
            }
            this.Refresh(); //Does this need to be here? Who knows

            //Set default version
            /*using (var client = new WebClient())
            {
                string json = client.DownloadString(Globals.defaultVer);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                //Set the LaunchJava defaults
                foreach (var vers in data)
                {
                    LaunchJava.selectedVer = vers.verName;
                    LaunchJava.linkToJar = vers.verLink;
                    LaunchJava.typeVer = vers.verType;

                    gameVerLabel.Text = "Ready to play Minecraft " + vers.verName;
                }
            }*/

            //Create directories
            Directory.CreateDirectory(Path.Combine(Globals.currentPath, "bin"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "versions"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "instance"));

            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "libs"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin\\versions", "ps3"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "rpcs3"));

            if(!File.Exists($"{Globals.currentPath}\\bin\\instance\\readme.txt"))
            {
                using (FileStream fs = File.Create($"{Globals.currentPath}\\bin\\instance\\readme.txt"))
                {
                    byte[] config = new UTF8Encoding(true).GetBytes($"WARNING!\nDo not mess with anything in this folder!\nIt will corrupt the instance(s)!");
                    fs.Write(config, 0, config.Length);
                }
            }
            if(!Directory.Exists($"{Globals.currentPath}\\bin\\instance\\Default"))
            {
                InstanceManager.mode = "initial";
                InstanceManager.tempName = "Default";
                InstanceManager.createInstance();
            }
            checkForUpdates();
            loadInstanceList();

            string json = File.ReadAllText($"{Globals.currentPath}\\bin\\instance\\{InstanceManager.selectedInstance}\\instance.cfg");
            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

            //Set the LaunchJava stuff
            foreach (var vers in data)
            {
                LaunchJava.selectedVer = vers.gameVer;
                LaunchJava.linkToJar = vers.linkVer;
                LaunchJava.proxyPort = vers.proxyVer;
                LaunchJava.typeVer = vers.typeVer;
            }

            gameVerLabel.Text = "Ready to play Minecraft " + LaunchJava.selectedVer;
        }

        void checkForUpdates()
        {
            using (WebClient client = new WebClient())
            {
                string updateLauncherVer = "";

                try
                {
                    if (Globals.isDev == false)
                        updateLauncherVer = client.DownloadString(Globals.verCheck);
                    else
                        updateLauncherVer = client.DownloadString(Globals.verCheckDev);

                    if (updateLauncherVer != Globals.verCurrent)
                    {
                        Update updateForm = new Update();
                        updateForm.ShowDialog();
                    }
                }
                catch (WebException)
                {
                    Globals.offlineMode = true;
                    OfflineMode offlineMode = new OfflineMode();
                    offlineMode.ShowDialog();
                    //this.Text += " (Offline mode)";
                    this.Close();
                }

            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (VerSelect.checkTab == "java")
                LaunchJava.LaunchGame();

            else if (VerSelect.checkTab == "javaMod")
                LaunchJavaMod.LaunchGame();

            else if (VerSelect.checkTab == "x360")
                LaunchXbox360.LaunchGame();

            else if (VerSelect.checkTab == "ps3")
                LaunchPS3.LaunchGame();
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            string newName = usernameTextBox.Text;
            Properties.Settings.Default.playerName = newName;
            Properties.Settings.Default.Save();

            playerNameLabel.Text = "Welcome, " + newName;
            playerNameLabel.Refresh();
            newName = "";
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
            string[] dirs = Directory.GetDirectories($"{Globals.currentPath}\\bin\\instance\\", "*");

            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if(File.Exists($"{Globals.currentPath}\\bin\\instance\\{dirName}\\instance.cfg"))
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

        private void newInstBtn_Click(object sender, EventArgs e)
        {
            InstanceManager.cfgInstName = "New profile";
            InstanceManager.mode = "new";
            InstanceManager instMan = new InstanceManager();
            instMan.ShowDialog();
        }

        private void editInstBtn_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText($"{Globals.currentPath}\\bin\\instance\\{InstanceManager.selectedInstance}\\instance.cfg");
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

        public static void reloadInstance()
        {
            if(InstanceManager.mode != "initial")
            {
                InstanceManager.selectedInstance = Instance.comboBox1.Text;
            }

            Console.WriteLine("selected: " + InstanceManager.selectedInstance);

            string json = File.ReadAllText($"{Globals.currentPath}\\bin\\instance\\{InstanceManager.selectedInstance}\\instance.cfg");
            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

            //Set the LaunchJava stuff
            foreach (var vers in data)
            {
                LaunchJava.selectedVer = vers.gameVer;
                LaunchJava.linkToJar = vers.linkVer;
                LaunchJava.typeVer = vers.typeVer;
                LaunchJava.proxyPort = vers.proxyVer;
            }
            LaunchJava.instanceName = Instance.comboBox1.Text;
            Instance.gameVerLabel.Text = "Ready to play Minecraft " + LaunchJava.selectedVer;
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugTools dt = new DebugTools();
            dt.ShowDialog();
        }
    }
}
