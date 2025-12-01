using MCLauncher.controls;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace MCLauncher
{
    class Strings
    {
        public static stringJson sj = new stringJson();

        public static void reloadLangs(string selected)
        {
            //load strings
            Logger.Info("[Strings]", $"Setting language {selected}");
            if (selected == "english")
            {
                sj = new stringJson();
            }
            else
            {
                string url = Globals.languageJson.Replace("{selected}", selected);
                WebClient cl = new WebClient();
                string json = cl.DownloadString(url);
                byte[] jsonArr = Encoding.Default.GetBytes(json);
                string newJson = Encoding.UTF8.GetString(jsonArr);

                sj = JsonConvert.DeserializeObject<stringJson>(newJson);
            }

            //set strings
            MainWindow.Instance.menuStrip1.Items[0].Text = sj.cntHome;
            MainWindow.Instance.menuStrip1.Items[1].Text = sj.cntSettings;
            MainWindow.Instance.menuStrip1.Items[2].Text = sj.cntAbout;

            HomeScreen.Instance.btnPlay.Text = sj.btnPlay;
            HomeScreen.Instance.btnLogIn.Text = sj.btnLogIn;
            HomeScreen.Instance.btnLogOut.Text = sj.btnLogOut;
            HomeScreen.Instance.btnEditInst.Text = sj.btnEditInst;
            HomeScreen.Instance.btnNewInst.Text = sj.btnNewInst;
            if (Settings.sj.refreshToken == String.Empty || Settings.sj.refreshToken == null)
            {
                HomeScreen.Instance.lblWelcome.Text = sj.lblWelcome.Replace("{playerName}", "Guest");
                HomeScreen.Instance.lblLogInWarn.Text = sj.lblLogInWarn;
            }
            else
            {
                HomeScreen.Instance.lblWelcome.Text = sj.lblWelcome.Replace("{playerName}", MSAuth.msUsername);
                HomeScreen.Instance.lblLogInWarn.Text = "";
                if (Globals.offlineMode)
                    HomeScreen.Instance.lblLogInWarn.Text = sj.lblLogInWarnOffline;
            }
            HomeScreen.Instance.lblReady.Text = sj.lblReady.Replace("{verInfo}", HomeScreen.selectedVersion);
            HomeScreen.Instance.lblSelInst.Text = sj.lblSelInst;

            SettingsScreen.InstanceSetting.grbLauncher.Text = sj.grbLauncher;
            SettingsScreen.InstanceSetting.lblLang.Text = sj.lblLang;
            SettingsScreen.InstanceSetting.lblBranch.Text = sj.lblBranch;
            SettingsScreen.InstanceSetting.btnCheckUpdates.Text = sj.btnCheckUpdates;
            SettingsScreen.InstanceSetting.chkDiscordRpc.Text = sj.chkDiscordRpc;
            SettingsScreen.InstanceSetting.chkShowLog.Text = sj.chkShowLog;
            SettingsScreen.InstanceSetting.chkShowConsole.Text = sj.chkShowConsole;

            SettingsScreen.InstanceSetting.grbJavaInstalls.Text = sj.grbJavaInstalls;
            SettingsScreen.InstanceSetting.lblJre8.Text = "Java 8";
            SettingsScreen.InstanceSetting.lblJre17.Text = "Java 17";
            SettingsScreen.InstanceSetting.lblJre21.Text = "Java 21";
            SettingsScreen.InstanceSetting.btnGetJava8.Text = sj.installJava.Replace("{ver}", "8");
            SettingsScreen.InstanceSetting.btnGetJava17.Text = sj.installJava.Replace("{ver}", "17");
            SettingsScreen.InstanceSetting.btnGetJava21.Text = sj.installJava.Replace("{ver}", "21");

            SettingsScreen.InstanceSetting.grbThemes.Text = sj.grbThemes;
            SettingsScreen.InstanceSetting.chkUseTheme.Text = sj.chkUseTheme;
            SettingsScreen.InstanceSetting.chkThemesOptout.Text = sj.chkThemesOptout;

            CreditsScreen.Instance.lblLauncherBy.Text = sj.lblLauncherBy.Replace("{version}", Globals.verDisplay);
            CreditsScreen.Instance.lblDejvossIpsa.Text = sj.lblDejvossIpsa;
            CreditsScreen.Instance.lblTeam.Text = sj.lblTeam;
            CreditsScreen.Instance.lblCopyright.Text = sj.lblCopyright;
            CreditsScreen.Instance.lblSpecialThanks.Text = sj.lblSpecialThanks;
        }

        public class stringJson
        {
            //MainWindow
            public string cntHome = "Home";
            public string cntProfiles = "Profiles";
            public string cntSettings = "Settings";
            public string cntAbout = "About";

            //HomeScreen
            public string btnPlay = "Play";
            public string btnLogIn = "Log-in";
            public string btnLogOut = "Log-out";
            public string lblSelInst = $"Select profile:";
            public string btnNewInst = "New profile";
            public string btnEditInst = "Edit profile";
            public string lblWelcome = "Welcome, {playerName}";
            public string lblReady = "Ready to play {verInfo}";
            public string lblLogInWarn = "You need to log in to use the launcher!";
            public String lblLogInWarnOffline = "Playing in offline mode, some features may not be available!";
            public string lblLogInWarn_Debug = "MAKE SURE TO DISABLE THIS IN GLOBALS!";
            public string lblPlayedFor = "Played for";
            public string lblPlayedForDay = "day";
            public string lblPlayedForDays = "days";
            public string lblPlayedForHour = "hour";
            public string lblPlayedForHours = "hours";
            public string lblPlayedForMinute = "minute";
            public string lblPlayedForMinutes = "minutes";
            public string lblPlayedForSecond = "second";
            public string lblPlayedForSeconds = "seconds";
            public string lblHaventPlayed = "Haven't played yet";

            //SettingsScreen
            public string grbLauncher = "Launcher";
            public string lblLang = "Language";
            public string chkDiscordRpc = "Discord RPC";
            public string lblBranch = "Branch";
            public string btnCheckUpdates = "Check for updates";
            public string grbDefaults = "Defaults"; //DEPRECATED
            public String grbJavaInstalls = "Java installations";
            public string installJava = "Install Java {ver} ↓";
            public String grbThemes = "Themes";
            public String chkUseTheme = "Custom theme";
            public String chkThemesOptout = "Opt-out of seasonal themes";
            public String chkShowLog = "Show game log window";
            public String chkShowConsole = "Show launcher console";

            //CreditsScreen
            public string lblLauncherBy = "Codex-Ipsa Launcher v{version} by";
            public string lblDejvossIpsa = $"DEJVOSS Productions";
            public string lblCopyright = "(c) 2022-2024";
            public string lblTeam = "The team:\nDEJVOSS; programming.";
            public string lblSpecialThanks = "Special thanks:\nBetaCraft; BCWrapper.\nOmniarchive; version files.\nMisterSheeple; file hosting.\nAnd you; for using the launcher.";

            //Generic Buttons
            public string btnCancel = "Cancel";
            public string btnOk = "OK";
            public string btnSaveInst = "Save profile";
            public string btnDeleteInst = "Delete profile";
            public string btnOpenDir = "Open directory";
            public string btnYes = "Yes";
            public string btnNo = "No";

            //Login
            public string titleLogin = "Log-in";
            public string labelPleaseLog = "To log-in, please go to";
            public string labelCode = "And enter the following code:";

            //Other
            public string lblDlFiles = "Downloading files...";
            public string lblLoading = "Loading...";
            public string lblDlAssets = "Downloading assets...";
            public string lblCopyUpd = "Copying update files...";
            public string bytes = "bytes";

            public string warning = "Warning!";
            public string lblDel1 = "Are you sure you want to delete this profile?";
            public string lblDel2 = "This can't be taken back!";

            public string joinServer = "Join a server";
            public string lblServer1 = "Please enter a server IP and port:";
            public string lblServer2 = "(Leave blank for singleplayer)";
            public string btnStartGame = "Start game";

            public string updateAvail = "Update available";
            public string lblUpdateAvail = "There is an update available!";
            public string lblWhatsNew = "What's new:";
            public string lblDoDown = "Do you wish to download it?";

            //Profile manager
            public string tabMods = "Mods";
            public string grbGame = "Game";
            public string lblProfName = "Profile name";
            public string lblGameDir = "Game directory";
            public string lblReso = "Resolution";
            public string lblMem = "Memory";
            public string lblMemMax = "Max";
            public string lblMemMin = "Min";
            public string lblBefCmd = "JVM arguments";
            public string lblAftCmd = "Game arguments";
            public string chkProxy = "Disable skin and sound fixes (<=1.5.2)";
            public string chkUseDemo = "Launch demo (>=12w16a)";
            public string chkOffline = "Launch in offline mode";
            public string chkMulti = "Force multiplayer";
            public string grbForExp = "For experts";
            public string chkCustJava = "Custom Java";
            public string chkCustJson = "Custom JSON";
            public string chkClasspath = "Classpath";
            public string chkAssetIndex = "Asset index";
            public string chkServerIP = "Server IP";
            public String createShortcut = "Create shortcut";

            //Profile manager mods
            public string btnMoveUp = "Move up";
            public string btnMoveDown = "Move down";
            public string btnRemove = "Remove";
            public string btnForge = "Install Forge";
            public string btnFabric = "Install Fabric";
            public string btnBabric = "Install Babric";
            public string btnLegacyFabric = "Install Legacy Fabric";
            public string btnMLoader = "Install ModLoader";
            public string btnRepos = "Mod repositories";
            public string btnAddToJar = "Add to minecraft.jar";
            public string btnReplaceJar = "Replace minecraft.jar";
            public string btnOpenDotMc = "Open.minecraft";
            public string rowName = "Name";
            public string rowType = "Type";
            public string rowConfig = "Config";
            public string rowReleased = "Released";
            public string rowUpdate = "Update";

            //Mod repo
            public string btnDownload = "Download";
            public string lblAlwaysUpdate = "Always update";

            public string lblNotReady = "This feature is not ready yet.";
            public string wrnRunning = "Profile [{profileName}] is already running.\nDo you wish to launch it again?\nThis may lead to unwanted behaviour!";
            public string localOrUrl = "Can be either a local path or a URL";

            public string createProfile = "Create profile";
            public string javaUpdate = "Do you wish to update your Java {vers} installation?";
            public string javaRedownload = "You already have the latest Java {ver} version installed. Do you wish to redownload?";
            public string javaSetDefault = "Do you wish to set this Java install as the default one for Java {vers.major}?";
            public string noUpdate = "No new update is available.";

            public string chooseLatestRelease = "Choose latest 'release' version";
            public string chooseLatestSnapshot = "Choose latest 'snapshot' version";

            //GameOutput
            public String btnKill = "Kill game";
            public String killInstance = "Are you sure you want to kill the game?\nThis may lead to unwanted behaviour like the game corrupting!";
        }
    }
}
