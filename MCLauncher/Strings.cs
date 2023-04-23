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

        public static string updateAvail = "Update available";
        public static string lblUpdateAvail = "There is an update available!";
        public static string lblWhatsNew = "What's new:";
        public static string lblDoDown = "Do you wish to download it?";

        //New Profile
        public static string grbGame = "Game";
        public static string lblProfName = "Profile name";
        public static string lblGameDir = "Game directory";
        public static string lblReso = "Resolution";
        public static string lblMem = "Memory";
        public static string lblMemMax = "Max";
        public static string lblMemMin = "Min";
        public static string lblBefCmd = "Before command";
        public static string lblAftCmd = "After command";
        public static string chkProxy = "Use skin and sound proxy (<=1.5.2)";
        public static string chkUseDemo = "Launch demo (>=12w16a)";
        public static string chkOffline = "Launch in offline mode";
        public static string chkMulti = "Force multiplayer";
        public static string grbForExp = "For experts";
        public static string chkCustJava = "Custom Java";
        public static string chkCustJson = "Custom JSON";
        public static string chkClasspath = "Classpath";

        //Mods
        public static string btnMoveUp = "Move up";
        public static string btnMoveDown = "Move down";
        public static string btnRemove = "Remove";
        public static string btnForge = "Install Forge";
        public static string btnFabric = "Install Fabric";
        public static string btnMLoader = "Install ModLoader";
        public static string btnRepos = "Mod repositories";
        public static string btnAddToJar = "Add to minecraft.jar";
        public static string btnReplaceJar = "Replace minecraft.jar";
        public static string btnOpenDotMc = "Open.minecraft";
        public static string rowName = "Name";
        public static string rowType = "Type";
        public static string rowConfig = "Config";
        public static string rowReleased = "Released";

        //Mod repo
        public static string btnDownload = "Download";
        public static string lblAlwaysUpdate = "Always update";

        public static string lblNotReady = "This feature is not ready yet.";

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

                updateAvail = str.updateAvail;
                lblUpdateAvail = str.lblUpdateAvail;
                lblWhatsNew = str.lblWhatsNew;
                lblDoDown = str.lblDoDown;

                grbGame = str.grbGame;
                lblProfName = str.lblProfName;
                lblGameDir = str.lblGameDir;
                lblReso = str.lblReso;
                lblMem = str.lblMem;
                lblMemMax = str.lblMemMax;
                lblMemMin = str.lblMemMin;
                lblBefCmd = str.lblBefCmd;
                lblAftCmd = str.lblAftCmd;
                chkProxy = str.chkProxy;
                chkUseDemo = str.chkUseDemo;
                chkOffline = str.chkOffline;
                chkMulti = str.chkMulti;
                grbForExp = str.grbForExp;
                chkCustJava = str.chkCustJava;
                chkCustJson = str.chkCustJson;
                chkClasspath = str.chkClasspath;

                btnMoveUp = str.btnMoveUp;
                btnMoveDown = str.btnMoveDown;
                btnRemove = str.btnRemove;
                btnForge = str.btnForge;
                btnFabric = str.btnFabric;
                btnMLoader = str.btnMLoader;
                btnRepos = str.btnRepos;
                btnAddToJar = str.btnAddToJar;
                btnReplaceJar = str.btnReplaceJar;
                btnOpenDotMc = str.btnOpenDotMc;
                rowName = str.rowName;
                rowType = str.rowType;
                rowConfig = str.rowConfig;
                rowReleased = str.rowReleased;

                btnDownload = str.btnDownload;
                lblAlwaysUpdate = str.lblAlwaysUpdate;

                lblNotReady = str.lblNotReady;

                MainWindow.Instance.menuStrip1.Items[0].Text = cntHome;
                MainWindow.Instance.menuStrip1.Items[2].Text = cntSettings;
                MainWindow.Instance.menuStrip1.Items[3].Text = cntAbout;

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

            public string updateAvail { get; set; }
            public string lblUpdateAvail { get; set; }
            public string lblWhatsNew { get; set; }
            public string lblDoDown { get; set; }

            public string grbGame { get; set; }
            public string lblProfName { get; set; }
            public string lblGameDir { get; set; }
            public string lblReso { get; set; }
            public string lblMem { get; set; }
            public string lblMemMax { get; set; }
            public string lblMemMin { get; set; }
            public string lblBefCmd { get; set; }
            public string lblAftCmd { get; set; }
            public string chkProxy { get; set; }
            public string chkUseDemo { get; set; }
            public string chkOffline { get; set; }
            public string chkMulti { get; set; }
            public string grbForExp { get; set; }
            public string chkCustJava { get; set; }
            public string chkCustJson { get; set; }
            public string chkClasspath { get; set; }

            public string btnMoveUp { get; set; }
            public string btnMoveDown { get; set; }
            public string btnRemove { get; set; }
            public string btnForge { get; set; }
            public string btnFabric { get; set; }
            public string btnMLoader { get; set; }
            public string btnRepos { get; set; }
            public string btnAddToJar { get; set; }
            public string btnReplaceJar { get; set; }
            public string btnOpenDotMc { get; set; }
            public string rowName { get; set; }
            public string rowType { get; set; }
            public string rowConfig { get; set; }
            public string rowReleased { get; set; }

            public string btnDownload { get; set; }
            public string lblAlwaysUpdate { get; set; }

            public string lblNotReady { get; set; }
        }
    }
}
