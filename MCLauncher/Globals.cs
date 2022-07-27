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
        public static string branch = "0.0.7-rewrite";
        public static string verCurrent = "0.0.7.6";
        public static string verDisplay = "0.0.7.6 (rewrite)"; //0.0.6 (Dev 7 WIP)
        public static bool offlineMode = false;

        public static string currentPath = Directory.GetCurrentDirectory();
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        //Links
        public static string xenia = $"http://codex-ipsa.dejvoss.cz/MCL-Data/emu/xenia.zip";
        public static string verCheck = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/latest.txt";
        public static string verCheckDev = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/latest-dev.txt";
        public static string javaLibs = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libs.zip";
        public static string updaterUrl = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/LauncherUpdater.exe";
        public static string updateInfo = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/version/list.json";

        public static string changelog = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/changelog.html";
        public static string defaultVer = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/java_basever.json";
        public static string javaJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/java_version.json";
        public static string javaModJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/data/java-mod.json";
        public static string x360Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/x360_version.json";
        public static string ps3Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/ps3_version.json";

        public static string libsPre16Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libraries-pre1.6.json";
        public static string libs16Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libraries-1.6.json";

        public static string jre8Link = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/jre8-latest.json";
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  