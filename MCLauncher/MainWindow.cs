using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            Properties.Settings.Default.Reload();
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Set needed things - window name, changelog, username
            this.Text = "MineC#raft Launcher v" + Globals.verDisplay;
            webBrowser1.Url = new Uri(Globals.changelog, UriKind.Absolute);
            playerNameLabel.Text = "Welcome, " + Properties.Settings.Default.playerName;

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
            using (var client = new WebClient())
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
            }

            //Create directories
            Directory.CreateDirectory(Path.Combine(Globals.currentPath, "bin"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "versions"));

            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "libs"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin\\versions", "ps3"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "rpcs3"));
            

            //TEMPORARILY DISABLED, MAKE SURE IT'S ON!!!
            checkForUpdates();
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
    }
}
