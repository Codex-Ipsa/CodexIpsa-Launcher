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


        public static void reloadLangs(string selected, string culture)
        {
            Logger.logMessage("[Strings]", $"Setting language {selected} ({culture})");
            string url = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/language/{selected}.json";
            WebClient cl = new WebClient();
            string json = cl.DownloadString(url);
            byte[] jsonArr = Encoding.Default.GetBytes(json);
            string newJson= Encoding.UTF8.GetString(jsonArr);
            Console.WriteLine(newJson);


            List<stringJson> data = JsonConvert.DeserializeObject<List<stringJson>>(newJson);
            foreach (var str in data)
            {
                CultureInfo ci = new CultureInfo(culture);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;

                btnPlay = str.btnPlay;
                btnLogIn = str.btnLogIn;
                btnLogOut = str.btnLogOut;
                btnEditInst = str.btnEditInst;
                btnNewInst = str.btnNewInst;
                lblWelcome = str.lblWelcome;
                lblReady = str.lblReady;
                lblSelInst = str.lblSelInst;
                lblLogInWarn = str.lblLogInWarn;
            }

            HomeScreen.Instance.btnPlay.Text = btnPlay;
            HomeScreen.Instance.btnLogIn.Text = btnLogIn;
            HomeScreen.Instance.btnLogOut.Text = btnLogOut;
            HomeScreen.Instance.btnEditInst.Text = btnEditInst;
            HomeScreen.Instance.btnNewInst.Text = btnNewInst;
            HomeScreen.Instance.lblWelcome.Text = lblWelcome;
            HomeScreen.Instance.lblReady.Text = lblReady;
            HomeScreen.Instance.lblSelInst.Text = lblSelInst;
            HomeScreen.Instance.lblLogInWarn.Text = lblLogInWarn;
        }
    }

    public class stringJson
    {
        public string btnPlay { get; set; }
        public string btnLogIn { get; set; }
        public string btnLogOut { get; set; }
        public string btnEditInst { get; set; }
        public string btnNewInst { get; set; }
        public string lblWelcome { get; set; }
        public string lblReady { get; set; }
        public string lblSelInst { get; set; }
        public string lblLogInWarn { get; set; }
    }
}
