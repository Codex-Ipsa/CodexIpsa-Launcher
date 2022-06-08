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
        public static string codebase = "0.0.6-dev";
        public static string verCurrent = "0.0.6-dev_b7b";
        public static string verDisplay = "0.0.6 (Dev 7b)"; //0.0.6 (Dev 7 WIP)
        public static bool isDev = true; //MAKE SURE IT'S FALSE ON RELEASE
        public static bool offlineMode = false;

        public static string currentPath = Directory.GetCurrentDirectory();
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        //Links
        public static string xenia = $"http://codex-ipsa.dejvoss.cz/MCL-Data/emu/xenia.zip";
        public static string verCheck = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/latest.txt";
        public static string verCheckDev = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/latest-dev.txt";
        public static string javaLibs = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libs.zip";
        public static string updaterRel = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/MCLauncherUpdater.exe";
        public static string updaterDev = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/MCLauncherUpdaterDev.exe";

        public static string changelog = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/changelog/";
        public static string defaultVer = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/data/base-ver.json";
        public static string javaJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/data/java.json";
        public static string javaModJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/data/java-mod.json";
        public static string x360Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/data/x360.json";
        public static string ps3Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/data/ps3-blus.json";

        public static string libsPre16Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libraries-pre1.6.json";
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  