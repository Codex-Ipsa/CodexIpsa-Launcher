using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class HomeScreen : UserControl
    {
        public static HomeScreen Instance;
        public static string selectedEdition = "java"; //TODO: LOAD THIS FROM INSTANCE
        public static string msPlayerName;

        public HomeScreen()
        {
            Instance = this;
            InitializeComponent();

            //Load lang
            btnPlay.Text = Strings.btnPlay;
            btnLogIn.Text = Strings.btnLogIn;
            btnLogOut.Text = Strings.btnLogOut;
            btnNewInst.Text = Strings.btnNewInst;
            btnEditInst.Text = Strings.btnEditInst;
            lblSelInst.Text = Strings.lblSelInst;
            lblWelcome.Text = Strings.lblWelcome;
            lblReady.Text = Strings.lblReady;

            //Load browser URL
            if(Globals.offlineMode == false)
            {
                webBrowser.Url = new Uri(Globals.changelog, UriKind.Absolute);
                webBrowser.Refresh();
                Logger.logMessage($"[HomeScreen]", $"Changelog loaded");
            }
            else
            {
                webBrowser.DocumentText = $"<center><p>{Strings.htmlChangelogFailed}</p></center>";
                webBrowser.Refresh();
                Logger.logError($"[HomeScreen]", $"Failed to load changelog");
            }

            //Check if user is logged in
            checkAuth();

            //Load instance list
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
            Instance.lblReady.Text = $"{Strings.lblReady} {LaunchJava.launchVerName}";

        }

        public static void checkAuth()
        {
            if (Properties.Settings.Default.msRefreshToken == String.Empty || Properties.Settings.Default.msRefreshToken == null)
            {
                Logger.logError($"[HomeScreen]", "User is not logged in");
                Instance.btnLogOut.Visible = false;
                Instance.btnLogIn.Visible = true;
                Instance.lblWelcome.Text = $"{Strings.lblWelcome} Guest";
                LaunchJava.launchPlayerName = "Guest";
                LaunchJava.launchPlayerUUID = "null";
                LaunchJava.launchPlayerAccessToken = "null";
                LaunchJava.launchMpPass = "null";
                if (Globals.requireAuth == true)
                {
                    Instance.btnPlay.Enabled = false;
                    Instance.cmbInstaces.Enabled = false;
                    Instance.btnEditInst.Enabled = false;
                    Instance.btnNewInst.Enabled = false;
                    Instance.lblLogInWarn.Text = Strings.lblLogInWarn;
                }
                else
                {
                    Instance.btnPlay.Enabled = true;
                    Instance.cmbInstaces.Enabled = true;
                    Instance.btnEditInst.Enabled = true;
                    Instance.btnNewInst.Enabled = true;
                    Instance.lblLogInWarn.Text = Strings.lblLogInWarn_Debug;
                }
            }
            else
            {
                Logger.logMessage($"[HomeScreen]", "User is logged in, re-checking everything");
                MSAuth.usernameFromRefreshToken();
                if (MSAuth.hasErrored == true)
                {
                    Logger.logMessage($"[HomeScreen]", $"MSAuth returned hasErrored. Please re-log in.");
                    MSAuth.hasErrored = false;
                    Properties.Settings.Default.msRefreshToken = String.Empty;
                    Properties.Settings.Default.Save();
                    checkAuth();
                }
                else
                {
                    Instance.btnLogOut.Visible = true;
                    Instance.btnLogIn.Visible = false;
                    Instance.lblWelcome.Text = $"{Strings.lblWelcome} {msPlayerName}";
                    Instance.btnPlay.Enabled = true;
                    Instance.lblLogInWarn.Text = "";
                }
            }
        }

        public void loadInstanceList()
        {
            List<string> instanceList = new List<string>();
            string[] dirs = Directory.GetDirectories($"{Globals.currentPath}\\.codexipsa\\instance\\", "*");

            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if (File.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\{dirName}\\instance.cfg"))
                {
                    instanceList.Add(dirName);
                }
                else
                {
                    //do nothing
                }

                //Console.WriteLine(dir);
            }
            cmbInstaces.DataSource = instanceList;
            cmbInstaces.Refresh();
            LaunchJava.instanceName = cmbInstaces.Text;
        }

        public static void reloadInstance()
        {
            if (InstanceManager.mode != "initial")
            {
                InstanceManager.selectedInstance = Instance.cmbInstaces.Text;
            }

            Logger.logMessage("[HomeScreen]", $"Selected instance: {InstanceManager.selectedInstance}");

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
            LaunchJava.currentInstance = Instance.cmbInstaces.Text;
            Instance.lblReady.Text = "Ready to play Minecraft " + LaunchJava.launchVerName;
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

        private void btnNewInst_Click(object sender, EventArgs e)
        {
            //TODO: switch to a tab instead
            InstanceManager.cfgInstName = "New profile";
            InstanceManager.mode = "new";
            InstanceManager instMan = new InstanceManager();
            instMan.ShowDialog();
        }

        private void btnEditInst_Click(object sender, EventArgs e)
        {
            //TODO: switch to a tab instead
            string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{InstanceManager.selectedInstance}\\instance.cfg");
            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

            //TODO: Set the data
            /*foreach (var vers in data)
            {
                InstanceManager.cfgGameVer = vers.gameVer;
                InstanceManager.cfgTypeVer = vers.typeVer;
            }*/

            InstanceManager.cfgInstName = cmbInstaces.Text;
            InstanceManager.mode = "edit";
            InstanceManager instMan = new InstanceManager();
            instMan.ShowDialog();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //Calling MSAuth
            Logger.logMessage($"[HomeScreen]", "Calling MSAuth");
            MSAuth auth = new MSAuth();
            auth.ShowDialog();

            if (MSAuth.hasErrored == true)
            {
                Logger.logMessage($"[HomeScreen]", $"MSAuth returned hasErrored. Please try again.");
                MSAuth.hasErrored = false;
            }
            else
            {
                Instance.btnLogOut.Visible = true;
                Instance.btnLogIn.Visible = false;
                Instance.lblWelcome.Text = $"Welcome, {msPlayerName}";
                this.Refresh();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Logger.logMessage($"[HomeScreen]", "Logging out");
            LaunchJava.launchPlayerName = "Guest";
            LaunchJava.launchPlayerUUID = "null";
            LaunchJava.launchPlayerAccessToken = "null";
            LaunchJava.launchMpPass = "null";
            Properties.Settings.Default.msRefreshToken = String.Empty;
            Properties.Settings.Default.Save();
            checkAuth();
        }

        private void cmbInstaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadInstance();
        }

        private void cmbInstaces_Click(object sender, EventArgs e)
        {
            loadInstanceList();
        }
    }
}
