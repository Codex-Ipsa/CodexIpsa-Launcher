using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    class Strings
    {
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
        public static string htmlChangelogFailed = $"Failed to load changelog";

        //CreditsScreen
        public static string lblLauncherBy = $"MineC#raft Launcher {Globals.verDisplay} by";
        public static string lblDejvossIpsa = $"DEJVOSS Productions, Codex-Ipsa";
        public static string lblCopyright = $"(c) 2022";
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


        public static void reloadLangs()
        {
            /*if(Properties.Settings.Default.prefLanguage == "cs")
            {

            }
            else
            {
                //Default to english
            }*/
        }
    }
}
