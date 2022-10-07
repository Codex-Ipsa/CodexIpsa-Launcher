using MCLauncher.controls;
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
        ConsoleScreen consoleScr;

        public MainWindow()
        {
            Instance = this;
            Properties.Settings.Default.Reload();
            InitializeComponent();
            loadMainWindow();

            //this is done here so it initializes first
            homeScr = new HomeScreen();
            creditsScr = new CreditsScreen();
            settingsScr = new SettingsScreen();
            instanceScr = new InstanceScreen();
            consoleScr = new ConsoleScreen();
            addHome();
        }
        public void addHome()
        {
            homeScr.Location = new Point(0, 24);
            homeScr.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            this.Controls.Add(homeScr);
            this.Controls.Remove(creditsScr);
            this.Controls.Remove(settingsScr);
            this.Controls.Remove(instanceScr);
            this.Controls.Remove(consoleScr);
        }

        public void addCredits()
        {
            creditsScr.Location = new Point(0, 24);
            creditsScr.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            this.Controls.Add(creditsScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(settingsScr);
            this.Controls.Remove(instanceScr);
            this.Controls.Remove(consoleScr);
        }

        public void addSettings()
        {
            settingsScr.Location = new Point(0, 24);
            settingsScr.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            this.Controls.Add(settingsScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(creditsScr);
            this.Controls.Remove(instanceScr);
            this.Controls.Remove(consoleScr);
        }
        public void addInstance()
        {
            instanceScr.Location = new Point(0, 24);
            instanceScr.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            this.Controls.Add(instanceScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(creditsScr);
            this.Controls.Remove(settingsScr);
            this.Controls.Remove(consoleScr);
        }
        public void addConsole()
        {
            consoleScr.Location = new Point(0, 24);
            consoleScr.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            this.Controls.Add(consoleScr);
            this.Controls.Remove(homeScr);
            this.Controls.Remove(creditsScr);
            this.Controls.Remove(settingsScr);
            this.Controls.Remove(instanceScr);
        }

        public void loadMainWindow()
        {
            //Set the window name
            Logger.logMessage($"[MainWindow]", $"MineC#raft Launcher has started!");
            this.Text = $"MineC#raft Launcher v{Globals.verDisplay} [branch {Globals.branch}]"; //window name
            Console.Title = $"MineC#raft Launcher v{Globals.verDisplay} [branch {Globals.branch}] CONSOLE";
            Logger.logMessage($"[MainWindow]", $"Version {Globals.verDisplay}, Branch {Globals.branch}");

            //Offline check
            /*try
            {
                HttpWebRequest request = WebRequest.Create("https://codex-ipsa.dejvoss.cz/") as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                Logger.logMessage($"[MainWindow]", $"Connected to internet, launcher will start in online mode");

            }
            catch (Exception ex)
            {
                Logger.logError($"[MainWindow]", $"No connection, launcher will start in offline mode");
                Globals.offlineMode = true;
            }*/

            /*if(Globals.offlineMode)
            {
                webBrowser1.Document.Write("<center><p>Unable to load changelog</p></center>");
                Logger.logError($"[MainWindow]", $"Unable to set changelog");
                webBrowser1.Refresh();
            }
            else
            {
                webBrowser1.Url = new Uri(Globals.changelog, UriKind.Absolute);
                webBrowser1.Refresh();
                Logger.logMessage($"[MainWindow]", $"Changelog loaded");
            }*/

            //Create directories
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\versions");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\assets");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\data");

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

                if (index == -1)
                {
                    Logger.logError("[MainWindow]", $"Current branch is no longer supported!");
                    Warning wrn = new Warning("Your branch is no longer supported!");
                    wrn.ShowDialog();
                }
                else
                {
                    SettingsScreen.checkForUpdates(Globals.branch);
                }

                //Seasonal background
                try
                {
                    using (WebClient cl = new WebClient())
                    {
                        cl.DownloadFile(Globals.seasonalDirt, $"{Globals.currentPath}\\.codexipsa\\data\\seasonalDirt.png");
                    }
                    menuStrip1.BackgroundImage = Image.FromFile($"{Globals.currentPath}\\.codexipsa\\data\\seasonalDirt.png");
                }
                catch(WebException e)
                {
                    if (File.Exists($"{Globals.currentPath}\\.codexipsa\\data\\seasonalDirt.png"))
                    {
                        File.Delete($"{Globals.currentPath}\\.codexipsa\\data\\seasonalDirt.png");
                    }
                }

                try
                {
                    using (WebClient cl = new WebClient())
                    {
                        cl.DownloadFile(Globals.seasonalStone, $"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png");
                    }
                    pnlBackground.BackgroundImage = Image.FromFile($"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png");
                }
                catch (WebException e)
                {
                    if (File.Exists($"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png"))
                    {
                        File.Delete($"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png");
                    }
                }


                //TODO: set selectedIndex
            }

            if (!Directory.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\Default"))
            {
                InstanceManager.mode = "initial";
                InstanceManager.tempName = "Default";
                InstanceManager.createInstance();
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

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConsole();
        }

        public static void loadLog()
        {
            Instance.addConsole();
        }
    }
}
