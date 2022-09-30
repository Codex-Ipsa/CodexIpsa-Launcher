﻿using MCLauncher.controls;
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
        HomeScreen home = new HomeScreen();
        CreditsScreen creditsScr = new CreditsScreen();

        public MainWindow()
        {
            Properties.Settings.Default.Reload();
            InitializeComponent();
            addHome();
        }
        public void addHome()
        {
            home.Location = new Point(0, 24);
            home.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            this.Controls.Add(home);
            this.Controls.Remove(creditsScr);
        }

        public void addCredits()
        {
            creditsScr.Location = new Point(0, 24);
            creditsScr.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            this.Controls.Add(creditsScr);
            this.Controls.Remove(home);
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {

            //Set the window name
            Logger.logMessage($"[MainWindow]", $"MineC#raft Launcher has started!");
            this.Text = $"MineC#raft Launcher v{Globals.verDisplay} [branch {Globals.codebase}]"; //window name
            Console.Title = $"MineC#raft Launcher v{Globals.verDisplay} [branch {Globals.codebase}] CONSOLE";
            Logger.logMessage($"[MainWindow]", $"Version {Globals.verDisplay}, Branch {Globals.codebase}");

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
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void newInstBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void editInstBtn_Click(object sender, EventArgs e)
        {
            
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
            Settings stg = new Settings();
            stg.ShowDialog();
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
