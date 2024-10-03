using MCLauncher.classes;
using MCLauncher.controls;
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
    public partial class MainWindow : Form
    {
        public static MainWindow Instance;
        HomeScreen homeScr;
        CreditsScreen creditsScr;
        SettingsScreen settingsScr;
        //ProfileScreen instanceScr;

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
            //this.Controls.Remove(instanceScr);
        }

        public void addCredits()
        {
            creditsScr.Location = new Point(0, 24);
            creditsScr.Dock = DockStyle.Fill;
            creditsScr.Padding = new Padding(0, 24, 0, 0);

            this.Controls.Add(creditsScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(settingsScr);
            //this.Controls.Remove(instanceScr);
        }

        public void addSettings()
        {
            settingsScr.Location = new Point(0, 24);
            settingsScr.Dock = DockStyle.Fill;
            settingsScr.Padding = new Padding(0, 24, 0, 0);

            this.Controls.Add(settingsScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(creditsScr);
            //this.Controls.Remove(instanceScr);
        }
        /*public void addInstance()
        {
            instanceScr.Location = new Point(0, 24);
            //instanceScr.Dock = DockStyle.Fill; //TODO
            instanceScr.Padding = new Padding(0, 24, 0, 0);

            this.Controls.Add(instanceScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(creditsScr);
            this.Controls.Remove(settingsScr);
        }*/

        public void loadMainWindow()
        {
            //Set the window name
            Logger.Info($"[MainWindow]", $"Codex-Ipsa Launcher has started!");
            this.Text = $"Codex-Ipsa Launcher v{Globals.verDisplay} [branch {Globals.branch}]"; //window name
            Console.Title = $"Codex-Ipsa Launcher v{Globals.verDisplay} [branch {Globals.branch}] CONSOLE";
            Logger.Info($"[MainWindow]", $"Version {Globals.verDisplay}, Branch {Globals.branch}");

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

            //Check for internet
            try
            {
                string offlineJson = Globals.client.DownloadString(Globals.offlineManifest);
                OfflineManifest test = JsonConvert.DeserializeObject<OfflineManifest>(offlineJson);
                if (test.offline)
                {
                    Logger.Error($"[MainWindow]", $"Servers are down! Reason: {test.message}");
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
                    branchIds.Add(vers.brId);
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

            //load theme
            Themes.loadTheme();

            //set theme
            menuStrip1.BackgroundImage = Themes.grass;
            this.BackgroundImage = Themes.stone;

            //Seasonal background
            //try
            //{
            //    Globals.client.DownloadFile(Globals.seasonalDirt, $"{Globals.dataPath}\\data\\seasonalDirt.png");
            //    menuStrip1.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalDirt.png");
            //}
            //catch (WebException e)
            //{
            //    if (File.Exists($"{Globals.dataPath}\\data\\seasonalDirt.png"))
            //    {
            //        File.Delete($"{Globals.dataPath}\\data\\seasonalDirt.png");
            //    }
            //}

            //try
            //{
            //    Globals.client.DownloadFile(Globals.seasonalStone, $"{Globals.dataPath}\\data\\seasonalStone.png");
            //    pnlBackground.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalStone.png");
            //    this.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalStone.png");
            //}
            //catch (WebException e)
            //{
            //    if (File.Exists($"{Globals.dataPath}\\data\\seasonalStone.png"))
            //    {
            //        File.Delete($"{Globals.dataPath}\\data\\seasonalStone.png");
            //    }
            //}

            if (SettingsScreen.isUpdating == false)
            {
                //this is done here so it initializes first
                homeScr = new HomeScreen();
                creditsScr = new CreditsScreen();
                settingsScr = new SettingsScreen();
                //instanceScr = new ProfileScreen();
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

        private void profilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //addInstance();
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

        private void importProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

    public class OfflineManifest
    {
        public bool offline { get; set; }
        public string message { get; set; }
    }
}
