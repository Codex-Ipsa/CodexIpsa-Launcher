using MCLauncher.classes;
using MCLauncher.controls;
using MCLauncher.json.api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class MainWindow : Form
    {
        public static MainWindow Instance;
        HomeScreen homeScr;
        CreditsScreen creditsScr;
        SettingsScreen settingsScr;

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
            loadMainWindow();
        }

        public void addHome()
        {
            homeScr.Location = new Point(0, 24);
            homeScr.Dock = DockStyle.Fill;
            homeScr.Padding = new Padding(0, 24, 0, 0);

            this.Controls.Add(homeScr);
            this.Controls.Remove(creditsScr);
            this.Controls.Remove(settingsScr);
        }

        public void addCredits()
        {
            creditsScr.Location = new Point(0, 24);
            creditsScr.Dock = DockStyle.Fill;
            creditsScr.Padding = new Padding(0, 24, 0, 0);

            this.Controls.Add(creditsScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(settingsScr);
        }

        public void addSettings()
        {
            settingsScr.Location = new Point(0, 24);
            settingsScr.Dock = DockStyle.Fill;
            settingsScr.Padding = new Padding(0, 24, 0, 0);

            this.Controls.Add(settingsScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(creditsScr);
        }

        public void loadMainWindow()
        {
            //Set the window name
            this.Text = $"Codex-Ipsa Launcher v{Globals.verDisplay} [branch {Globals.branch}]";

            //Create directories
            Directory.CreateDirectory($"{Globals.dataPath}");
            Directory.CreateDirectory($"{Globals.dataPath}\\versions");
            Directory.CreateDirectory($"{Globals.dataPath}\\instance");
            Directory.CreateDirectory($"{Globals.dataPath}\\libs");
            Directory.CreateDirectory($"{Globals.dataPath}\\assets");
            Directory.CreateDirectory($"{Globals.dataPath}\\data\\json");

            //load settings
            Settings.Reload();

            //Delete updater if it exists
            if (File.Exists($"{Globals.currentPath}\\LauncherUpdater.exe"))
                File.Delete($"{Globals.currentPath}\\LauncherUpdater.exe");

            //check for internet
            //TODO get offline manifest and display error message
            //TODO display no internet available message if manifest 404s
            try
            {
                string offjson = Globals.client.DownloadString(Globals.offlineManifest);
                OfflineJson oj = JsonConvert.DeserializeObject<OfflineJson>(offjson);
                if (oj.offline)
                {
                    Logger.Error($"[MainWindow]", $"Servers are down! Reason: {oj.message}");
                    Globals.offlineMode = true;
                }
            }
            catch
            {
                Logger.Error($"[MainWindow]", "Internet connection not available!");
                Globals.offlineMode = true;
            }

            //Check for updates
            Logger.Info($"[MainWindow]", "Checking for updates..");
            List<string> branchIds = new List<string>();

            if (!Globals.offlineMode)
            {
                string jsonUpd = Globals.client.DownloadString(Globals.updateInfo);
                List<UpdateJson> dataUpd = JsonConvert.DeserializeObject<List<UpdateJson>>(jsonUpd);

                foreach (var vers in dataUpd)
                {
                    branchIds.Add(vers.id);
                }

                int index = branchIds.FindIndex(x => x.StartsWith(Globals.branch));
                Logger.Info($"[MainWindow]", $"Branch {Globals.branch} is on {index}");

                if (index == -1)
                {
                    Logger.Error("[MainWindow]", $"Current branch is no longer supported!");
                    MessageBox.Show($"Your branch is no longer supported!\nPlease update your launcher.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SettingsScreen.checkForUpdates(Globals.branch);
                }
            }

            //always download version manifests for later offline usage
            if (!Globals.offlineMode)
            {
                Globals.client.DownloadFile(Globals.javaManifest, Globals.javaManifestFile);
                Globals.client.DownloadFile(Globals.javaEduManifest, Globals.javaEduManifestFile);
                Globals.client.DownloadFile(Globals.x360Manifest, Globals.x360ManifestFile);
            }

            //load theme
            Themes.loadTheme();

            //set theme
            menuStrip1.BackgroundImage = Themes.dirt;
            this.BackgroundImage = Themes.stone;

            if (SettingsScreen.isUpdating == false)
            {
                //this is done here so it initializes first
                homeScr = new HomeScreen();
                creditsScr = new CreditsScreen();
                settingsScr = new SettingsScreen();
                addHome();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addHome();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCredits();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSettings();
        }

        private void MainWindow_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            ResumeLayout();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Discord.client != null)
                Discord.client.Dispose();
        }
    }
}
