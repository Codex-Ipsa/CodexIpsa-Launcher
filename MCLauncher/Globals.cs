using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    class Globals
    {
        //Manual
        public static string codebase = "crystal";
        public static string branch = "crystal";
        public static string verCurrent = "0.0.7.8_03"; //Change this on release
        public static string verDisplay = "0.1.0"; //Change this on release
        public static bool offlineMode = false;

        public static string currentPath = Directory.GetCurrentDirectory();
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //Switches
        public static bool isDebug = true; //Change this on releases

        //Links
        public static string updaterUrl = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/LauncherUpdater.exe";
        public static string updateInfo = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/version/list.json";

        public static string changelog = $"http://codex-ipsa.dejvoss.cz/method-data/changelog.html";
        public static string defaultVer = $"http://codex-ipsa.dejvoss.cz/method-data/java_basever.json";
        public static string classicPJson = $"http://codex-ipsa.dejvoss.cz/method-data/ver-list/classic-plus.json";
        public static string xenia = $"removed";
        public static string javaModJson = $"removed";
        public static string x360Json = $"removed";
        public static string ps3Json = $"removed";

        public static string jre8Link = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/jre8-latest.json";
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  