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

        public MainWindow()
        {
            Instance = this;
            Properties.Settings.Default.Reload();
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Set required things
            Console.WriteLine($"[MainWindow] MineC#raft Launcher has started!");
            this.Text = $"MineC#raft Launcher v{Globals.verDisplay} [branch {Globals.codebase}]"; //window name
            Console.WriteLine($"[MainWindow] Version {Globals.verDisplay}, Branch {Globals.codebase}");

            webBrowser1.Url = new Uri(Globals.changelog, UriKind.Absolute); //changelog URL
            webBrowser1.Refresh();
            Console.WriteLine($"[MainWindow] Browser URL set");
            playerNameLabel.Text = "Welcome, " + Properties.Settings.Default.playerName; //username

            //Delete updater if it exists for some reason
            if (File.Exists($"{Globals.currentPath}\\LauncherUpdater.exe"))
                File.Delete($"{Globals.currentPath}\\LauncherUpdater.exe");


            //Check for updates
            Console.WriteLine($"[MainWindow] Checking for updates..");
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
                Console.WriteLine($"[MainWindow] Found branch {Globals.branch} on index {index}");

                if(index == -1)
                {
                    Console.WriteLine($"[MainWindow] Current branch is no longer supported!");
                }
                else
                {
                    Console.WriteLine($"[MainWindow] Success! Moving over to VerCheck.");
                    Settings.checkForUpdates(Globals.branch);
                }

                //TODO: set selectedIndex
            }

            //Create directories
            Directory.CreateDirectory(Path.Combine(Globals.currentPath, ".codexipsa"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\.codexipsa", "versions"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\.codexipsa", "instance"));

            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\.codexipsa", "libs"));

            /*if(!File.Exists($"{Globals.currentPath}\\bin\\instance\\readme.txt"))
            {
                using (FileStream fs = File.Create($"{Globals.currentPath}\\bin\\instance\\readme.txt"))
                {
                    byte[] config = new UTF8Encoding(true).GetBytes($"WARNING!\nDo not mess with anything in this folder!\nIt will corrupt the instance(s)!");
                    fs.Write(config, 0, config.Length);
                }
            }*/

            //Temporary calling MSAuth
            Console.WriteLine($"[MainWindow Debug] Calling MSAuth");
            MSAuth auth = new MSAuth();
            auth.ShowDialog();

            if(!Directory.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\Default"))
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
                LaunchJava.launchVerName = vers.gameVer;
                LaunchJava.launchVerUrl = vers.linkVer;
                LaunchJava.launchVerType = vers.typeVer;
            }
            Instance.gameVerLabel.Text = "Ready to play Minecraft " + LaunchJava.launchVerName;
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

        public static void reloadInstance()
        {
            if(InstanceManager.mode != "initial")
            {
                InstanceManager.selectedInstance = Instance.comboBox1.Text;
            }

            Console.WriteLine("selected: " + InstanceManager.selectedInstance);

            string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{InstanceManager.selectedInstance}\\instance.cfg");
            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

            //Set the LaunchJava stuff
            foreach (var vers in data)
            {
                LaunchJava.launchVerName = vers.gameVer;
                LaunchJava.launchVerUrl = vers.linkVer;
                LaunchJava.launchVerType = vers.typeVer;
            }
            LaunchJava.currentInstance = Instance.comboBox1.Text;
            Instance.gameVerLabel.Text = "Ready to play Minecraft " + LaunchJava.launchVerName;
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
    }
}
