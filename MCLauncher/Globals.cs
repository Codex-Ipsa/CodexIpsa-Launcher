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
        public static string codebase = "0.0.7-dev";
        public static string branch = "dev";
        public static string verCurrent = "0.0.7.14"; //Change this on release
        public static string verDisplay = "0.0.7.14"; //Change this on release
        public static bool offlineMode = false;

        public static string currentPath = Directory.GetCurrentDirectory();
        public static string dataPath = Directory.GetCurrentDirectory() + "\\.codexipsa";
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //Switches
        public static bool isDebug = true; //Change this on releases

        //Links
        public static string xenia = $"http://codex-ipsa.dejvoss.cz/MCL-Data/emu/xenia.zip";
        public static string updaterUrl = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/LauncherUpdater.exe";
        public static string updateInfo = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/version/list.json";

        public static string changelog = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/changelog.html";
        public static string defaultVer = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/java_basever.json";
        public static string javaJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/java_version.json";
        public static string javaModJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/data/java-mod.json";
        public static string x360Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/x360_version.json";
        public static string ps3Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/ps3_version.json";

        public static string jre8Link = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/jre8-latest.json";
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  