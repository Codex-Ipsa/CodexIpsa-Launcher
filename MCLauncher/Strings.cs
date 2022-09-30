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
        public static string lblWelcome = $"Welcome, {{playerName}}";
        public static string lblReady = $"Ready to play Minecraft {{gameVer}}";
        public static string lblSelInst = $"Select profile:";
        public static string lblLogInWarn = $"";
        public static string lblLogInWarn_Debug = $"";

        //CreditsScreen
        public static string lblLauncherBy = $"MineC#raft Launcher {Globals.verDisplay} by";
        public static string lblDejvossIpsa = $"DEJVOSS Productions, Codex-Ipsa";
        public static string lblCopyright = $"(c) 2022";
        public static string lblTeam = $"The team:\nDEJVOSS; programming.";
        public static string lblSpecialThanks = $"Special thanks:\nBetaCraft; proxy, inspiration.\nOmniarchive; inspiration.\nMisterSheeple; file hosting.";
    
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
