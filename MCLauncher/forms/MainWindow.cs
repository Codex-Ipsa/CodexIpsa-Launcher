using MCLauncher.classes;
using MCLauncher.controls;
using MCLauncher.forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class MainWindow : Form
    {
        public static MainWindow Instance;
        HomeScreen homeScr;
        CreditsScreen creditsScr;
        SettingsScreen settingsScr;
        InstanceScreen instanceScr;

        public MainWindow()
        {
            Instance = this;
            Properties.Settings.Default.Reload();
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
            this.Controls.Remove(instanceScr);
        }

        public void addCredits()
        {
            creditsScr.Location = new Point(0, 24);
            creditsScr.Dock = DockStyle.Fill;
            creditsScr.Padding = new Padding(0, 24, 0, 0);

            this.Controls.Add(creditsScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(settingsScr);
            this.Controls.Remove(instanceScr);
        }

        public void addSettings()
        {
            settingsScr.Location = new Point(0, 24);
            settingsScr.Dock = DockStyle.Fill;
            settingsScr.Padding = new Padding(0, 24, 0, 0);

            this.Controls.Add(settingsScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(creditsScr);
            this.Controls.Remove(instanceScr);
        }
        public void addInstance()
        {
            instanceScr.Location = new Point(0, 24);
            instanceScr.Dock = DockStyle.Fill;
            instanceScr.Padding = new Padding(0, 24, 0, 0);

            this.Controls.Add(instanceScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(creditsScr);
            this.Controls.Remove(settingsScr);
        }

        public void loadMainWindow()
        {
            /*Output ou = new Output();
            ou.Show();*/

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

            //Delete updater if it exists
            if (File.Exists($"{Globals.currentPath}\\LauncherUpdater.exe"))
                File.Delete($"{Globals.currentPath}\\LauncherUpdater.exe");

            //Check for internet
            try
            {
                string tets = Globals.client.DownloadString("codex-ipsa.dejvoss.cz");
            }
            catch
            {
                Globals.offlineMode = true;
            }

            //Check for updates
            Logger.Info($"[MainWindow]", "Checking for updates..");
            List<string> branchIds = new List<string>();

            if(!Globals.offlineMode)
            {
                string jsonUpd = Globals.client.DownloadString(Globals.updateInfo);
                List<jsonObject> dataUpd = JsonConvert.DeserializeObject<List<jsonObject>>(jsonUpd);

                foreach (var vers in dataUpd)
                {
                    branchIds.Add(vers.brId);
                }

                int index = branchIds.FindIndex(x => x.StartsWith(Globals.branch));
                Logger.Info($"[MainWindow]", $"Branch {Globals.branch} is on {index}");

                if (index == -1)
                {
                    Logger.Error("[MainWindow]", $"Current branch is no longer supported!");
                    Warning wrn = new Warning("Your branch is no longer supported!");
                    wrn.ShowDialog();
                }
                else
                {
                    SettingsScreen.checkForUpdates(Globals.branch);
                }
            }

            //Seasonal background
            try
            {
                Globals.client.DownloadFile(Globals.seasonalDirt, $"{Globals.dataPath}\\data\\seasonalDirt.png");
                menuStrip1.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalDirt.png");
            }
            catch (WebException e)
            {
                if (File.Exists($"{Globals.dataPath}\\data\\seasonalDirt.png"))
                {
                    File.Delete($"{Globals.dataPath}\\data\\seasonalDirt.png");
                }
            }

            try
            {
                Globals.client.DownloadFile(Globals.seasonalStone, $"{Globals.dataPath}\\data\\seasonalStone.png");
                pnlBackground.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalStone.png");
                this.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalStone.png");
            }
            catch (WebException e)
            {
                if (File.Exists($"{Globals.dataPath}\\data\\seasonalStone.png"))
                {
                    File.Delete($"{Globals.dataPath}\\data\\seasonalStone.png");
                }
            }


            if (SettingsScreen.isUpdating == false)
            {
                //this is done here so it initializes first
                homeScr = new HomeScreen();
                creditsScr = new CreditsScreen();
                settingsScr = new SettingsScreen();
                instanceScr = new InstanceScreen();
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

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugTools dt = new DebugTools();
            dt.ShowDialog();
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

        private void instanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addInstance();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Discord.client.Dispose();
        }
    }
}
