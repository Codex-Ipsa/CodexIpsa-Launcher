using System;
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
            usernameLabel.Text = "Username: " + Properties.Settings.Default.playerName;

            //Delete updaters if they exist for some reason
            if (File.Exists(Path.Combine(Globals.currentPath + "\\MCLauncherUpdater.exe")))
            {
                File.Delete(Globals.currentPath + "\\MCLauncherUpdater.exe");
            }
            if (File.Exists(Path.Combine(Globals.currentPath + "\\MCLauncherDevUpdater.exe")))
            {
                File.Delete(Globals.currentPath + "\\MCLauncherDevUpdater.exe");
            }
            this.Refresh(); //Does this need to be here? Who knows

            //Create directories
            Directory.CreateDirectory(Path.Combine(Globals.currentPath, "bin"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "versions"));
            //Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "libs"));
            //Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin\\versions", "java"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin\\versions", "x360"));
            //Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin\\versions", "ps3"));
            Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "xenia"));
            //Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "rpcs3"));
            //Directory.CreateDirectory(Path.Combine(Globals.currentPath + "\\bin", "mods"));

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

        private void btnVerSelect_Click(object sender, EventArgs e)
        {
            VerSelect verSelect = new VerSelect();
            verSelect.ShowDialog();


            if (VerSelect.checkTab == "java")
                verSelected.Text = LaunchJava.selectedVer;

            else if (VerSelect.checkTab == "javaMod")
                verSelected.Text = LaunchJavaMod.selectedVer;

            else if (VerSelect.checkTab == "x360")
                verSelected.Text = LaunchXbox360.selectedVer;

            else if (VerSelect.checkTab == "ps3")
                verSelected.Text = LaunchPS3.selectedVer;
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

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            string newName = usernameTextBox.Text;
            Properties.Settings.Default.playerName = newName;
            Properties.Settings.Default.Save();

            usernameLabel.Text = "Username: " + newName;
            usernameLabel.Refresh();
            newName = "";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About credits = new About();
            credits.ShowDialog();
        }
    }
}
