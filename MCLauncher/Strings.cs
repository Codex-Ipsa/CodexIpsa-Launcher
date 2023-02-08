using MCLauncher.controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace MCLauncher
{
    class Strings
    {
        //Main window
        public static string cntHome = "Home";
        public static string cntSettings = "Settings";
        public static string cntAbout = "About";

        //Buttons
        public static string btnCancel = "Cancel";
        public static string btnOk = "OK";
        public static string btnSaveInst = "Save profile";
        public static string btnDeleteInst = "Delete profile";
        public static string btnOpenDir = "Open directory";
        public static string btnYes = "Yes";
        public static string btnNo = "No";

        //Home screen
        public static string btnPlay = $"Play";
        public static string btnLogIn = $"Log-in";
        public static string btnLogOut = $"Log-out";
        public static string btnEditInst = $"Edit profile";
        public static string btnNewInst = $"New profile";
        public static string lblWelcome = $"Welcome,";
        public static string lblReady = $"Ready to play Minecraft";
        public static string lblSelInst = $"Select profile:";
        public static string lblLogInWarn = $"You need to log in to use the launcher!";
        public static string lblLogInWarn_Debug = $"MAKE SURE TO DISABLE THIS IN GLOBALS!!!";

        //CreditsScreen
        public static string lblLauncherBy = $"Codex-Ipsa Launcher {Globals.verDisplay} by";
        public static string lblDejvossIpsa = $"DEJVOSS Productions, Codex-Ipsa";
        public static string lblCopyright = $"(c) 2022-2023";
        public static string lblTeam = $"The team:\nDEJVOSS; programming.";
        public static string lblSpecialThanks = $"Special thanks:\nBetaCraft; proxy, inspiration.\nOmniarchive; inspiration.\nMisterSheeple; file hosting.";

        //SettingsScreen
        public static string grbLauncher = "Launcher";
        public static string grbUpdates = "Updates";
        public static string lblLang = "Language";
        public static string lblBranch = "Branch";
        public static string btnCheckUpdates = "Check for updates";

        //InstanceManager
        public static string grbInfo = "Profile info";
        public static string lblName = "Profile name:";
        public static string lblDir = "Directory (blank = default):";
        public static string lblRes = "Resolution:";
        public static string lblMin = "Min:";
        public static string lblMax = "Max:";
        public static string lblRam = "Memory:";

        public static string grbVersion = "Version selection";
        public static string lblEdition = "Edition:";
        public static string lblVersion = "Version:";

        public static string grbExperts = "For experts";
        public static string lblJavaInstall = "Java install:";
        public static string lblJvmArgs = "JVM arguments:";
        public static string lblCustJar = "Custom JAR:";
        public static string lblOfflineLaunch = "Launch in offline mode";
        public static string lblUseProxy = "Use skin and sound proxy (use up to 1.5.2)";
        public static string titleProfileMan = "Profile manager";
        public static string tabEditor = "Profile editor";

        //Login
        public static string titleLogin = "Log-in";
        public static string labelPleaseLog = "To log-in, please go to";
        public static string labelCode = "And enter the following code:";

        //Other
        public static string lblDlFiles = "Downloading files...";
        public static string lblLoading = "Loading...";
        public static string lblDlAssets = "Downloading assets...";
        public static string lblCopyUpd = "Copying update files...";
        public static string bytes = "bytes";

        public static string warning = "Warning!";
        public static string lblDel1 = "Are you sure you want to delete this profile?";
        public static string lblDel2 = "This can't be taken back!";

        public static string joinServer = "Join a server";
        public static string lblServer1 = "Please enter a server IP and port:";
        public static string lblServer2 = "(Leave blank for singleplayer)";
        public static string btnStartGame = "Start game";

        public static void reloadLangs(string selected)
        {
            Logger.Info("[Strings]", $"Setting language {selected}");
            string url = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/language/{selected}.json";
            WebClient cl = new WebClient();
            string json = cl.DownloadString(url);
            byte[] jsonArr = Encoding.Default.GetBytes(json);
            string newJson = Encoding.UTF8.GetString(jsonArr);

            List<stringJson> data = JsonConvert.DeserializeObject<List<stringJson>>(newJson);
            foreach (var str in data)
            {
                cntHome = str.cntHome;
                cntSettings = str.cntSettings;
                cntAbout = str.cntAbout;

                btnPlay = str.btnPlay;
                btnLogIn = str.btnLogIn;
                btnLogOut = str.btnLogOut;
                btnEditInst = str.btnEditInst;
                btnNewInst = str.btnNewInst;
                lblWelcome = str.lblWelcome;
                lblReady = str.lblReady;
                lblSelInst = str.lblSelInst;
                lblLogInWarn = str.lblLogInWarn;

                grbLauncher = str.grbLauncher;
                grbUpdates = str.grbUpdates;
                lblLang = str.lblLang;
                lblBranch = str.lblBranch;
                btnCheckUpdates = str.btnCheckUpdates;

                lblLauncherBy = str.lblLauncherBy.Replace("{version}", Globals.verDisplay);
                lblDejvossIpsa = str.lblDejvossIpsa;
                lblTeam = str.lblTeam;
                lblSpecialThanks = str.lblSpecialThanks;

                grbInfo = str.grbInfo;
                lblName = str.lblName;
                lblDir = str.lblDir;
                lblRes = str.lblRes;
                lblMin = str.lblMin;
                lblMax = str.lblMax;
                lblRam = str.lblRam;
                grbVersion = str.grbVersion;
                lblEdition = str.lblEdition;
                lblVersion = str.lblVersion;
                grbExperts = str.grbExperts;
                lblJavaInstall = str.lblJavaInstall;
                lblJvmArgs = str.lblJvmArgs;
                lblCustJar = str.lblCustJar;
                lblOfflineLaunch = str.lblOfflineLaunch;
                lblUseProxy = str.lblUseProxy;
                titleProfileMan = str.titleProfileMan;
                tabEditor = str.tabEditor;

                btnCancel = str.btnCancel;
                btnOk = str.btnOk;
                btnSaveInst = str.btnSaveInst;
                btnDeleteInst = str.btnDeleteInst;
                btnOpenDir = str.btnOpenDir;
                btnYes = str.btnYes;
                btnNo = str.btnNo;

                titleLogin = str.titleLogin;
                labelPleaseLog = str.labelPleaseLog;
                labelCode = str.labelCode;

                lblDlFiles = str.lblDlFiles;
                lblLoading = str.lblLoading;
                lblDlAssets = str.lblDlAssets;
                lblCopyUpd = str.lblCopyUpd;

                bytes = str.bytes;
                warning = str.warning;
                lblDel1 = str.lblDel1;
                lblDel2 = str.lblDel2;

                joinServer = str.joinServer;
                lblServer1 = str.lblServer1;
                lblServer2 = str.lblServer2;
                btnStartGame = str.btnStartGame;

                MainWindow.Instance.menuStrip1.Items[0].Text = cntHome;
                MainWindow.Instance.menuStrip1.Items[3].Text = cntSettings;
                MainWindow.Instance.menuStrip1.Items[4].Text = cntAbout;

                HomeScreen.Instance.btnPlay.Text = btnPlay;
                HomeScreen.Instance.btnLogIn.Text = btnLogIn;
                HomeScreen.Instance.btnLogOut.Text = btnLogOut;
                HomeScreen.Instance.btnEditInst.Text = btnEditInst;
                HomeScreen.Instance.btnNewInst.Text = btnNewInst;
                if (Properties.Settings.Default.msRefreshToken == String.Empty || Properties.Settings.Default.msRefreshToken == null)
                {
                    HomeScreen.Instance.lblWelcome.Text = lblWelcome + " Guest";
                    HomeScreen.Instance.lblLogInWarn.Text = lblLogInWarn;
                }
                else
                {
                    HomeScreen.Instance.lblWelcome.Text = lblWelcome + " " + HomeScreen.msPlayerName;
                    HomeScreen.Instance.lblLogInWarn.Text = "";
                }
                HomeScreen.Instance.lblReady.Text = lblReady + " " + HomeScreen.selectedVersion;
                HomeScreen.Instance.lblSelInst.Text = lblSelInst;

                SettingsScreen.InstanceSetting.grbLauncher.Text = grbLauncher;
                SettingsScreen.InstanceSetting.lblLang.Text = lblLang;
                SettingsScreen.InstanceSetting.grbUpdates.Text = grbUpdates;
                SettingsScreen.InstanceSetting.lblBranch.Text = lblBranch;
                SettingsScreen.InstanceSetting.btnCheckUpdates.Text = btnCheckUpdates;

                CreditsScreen.Instance.lblLauncherBy.Text = lblLauncherBy;
                CreditsScreen.Instance.lblDejvossIpsa.Text = lblDejvossIpsa;
                CreditsScreen.Instance.lblTeam.Text = lblTeam;
                CreditsScreen.Instance.lblCopyright.Text = lblCopyright;
                CreditsScreen.Instance.lblSpecialThanks.Text = lblSpecialThanks;
            }
        }

        public class stringJson
        {
            public string cntHome { get; set; }
            public string cntSettings { get; set; }
            public string cntAbout { get; set; }

            public string btnPlay { get; set; }
            public string btnLogIn { get; set; }
            public string btnLogOut { get; set; }
            public string btnEditInst { get; set; }
            public string btnNewInst { get; set; }
            public string lblWelcome { get; set; }
            public string lblReady { get; set; }
            public string lblSelInst { get; set; }
            public string lblLogInWarn { get; set; }

            public string grbLauncher { get; set; }
            public string grbUpdates { get; set; }
            public string lblLang { get; set; }
            public string lblBranch { get; set; }
            public string btnCheckUpdates { get; set; }

            public string lblLauncherBy { get; set; }
            public string lblDejvossIpsa { get; set; }
            public string lblTeam { get; set; }
            public string lblSpecialThanks { get; set; }

            public string grbInfo { get; set; }
            public string lblName { get; set; }
            public string lblDir { get; set; }
            public string lblRes { get; set; }
            public string lblMin { get; set; }
            public string lblMax { get; set; }
            public string lblRam { get; set; }
            public string grbVersion { get; set; }
            public string lblEdition { get; set; }
            public string lblVersion { get; set; }
            public string grbExperts { get; set; }
            public string lblJavaInstall { get; set; }
            public string lblJvmArgs { get; set; }
            public string lblCustJar { get; set; }
            public string lblOfflineLaunch { get; set; }
            public string lblUseProxy { get; set; }
            public string titleProfileMan { get; set; }
            public string tabEditor { get; set; }

            public string btnCancel { get; set; }
            public string btnOk { get; set; }
            public string btnSaveInst { get; set; }
            public string btnDeleteInst { get; set; }
            public string btnOpenDir { get; set; }
            public string btnYes { get; set; }
            public string btnNo { get; set; }

            public string titleLogin { get; set; }
            public string labelPleaseLog { get; set; }
            public string labelCode { get; set; }

            public string lblDlFiles { get; set; }
            public string lblLoading { get; set; }
            public string lblDlAssets { get; set; }
            public string lblCopyUpd { get; set; }
            public string bytes { get; set; }

            public string warning { get; set; }
            public string lblDel1 { get; set; }
            public string lblDel2 { get; set; }

            public string joinServer { get; set; }
            public string lblServer1 { get; set; }
            public string lblServer2 { get; set; }
            public string btnStartGame { get; set; }
        }
    }
}
