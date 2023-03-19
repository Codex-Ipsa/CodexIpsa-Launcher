using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MCLauncher
{
    class Globals
    {
        //System
        public static WebClient client = new WebClient();

        //Manual
        public static string codebase = "omega13"; //0.2.0 //omega13 //0.0.7-dev //mojang-data
        public static string branch = "omega13"; //dev //omega13 //stable //dev-instances
        public static string verCurrent = "0.2.0-dev6"; //Change this on release
        public static string verDisplay = "0.2.0-dev6"; //Change this on release
        public static bool offlineMode = false;

        public static string currentPath = Directory.GetCurrentDirectory();
        public static string dataPath = Directory.GetCurrentDirectory() + "\\.codexipsa";
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //Switches
        public static bool isDebug = false;
        public static bool requireAuth = false; //Change this on release to true

        //Links
        public static string javaManifest = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/java_manifest.json";
        public static string javaInfo = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/data/{{ver}}.json";



        public static string updaterUrl = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/LauncherUpdater2.exe"; //LauncherUpdater.exe
        public static string updateInfo = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/version/list.json";
        public static string xeniaInfo = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/emulator/xenia.json";
        public static string changelog = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/changelog.html";
        public static string changelogJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/changelog.json";
        public static string defaultVer = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/java_basever.json";
        public static string javaeduJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/javaedu_version.json";
        public static string x360Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/x360_version.json";
        public static string x360Base = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/x360_base.txt";
        public static string ps3Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/ps3_version.json";

        public static string CIModsJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/modrepo/ipsa_mods.json";

        public static string jre8Link = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/jre8-latest.json";
        public static string seasonalDirt = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/seasonal/dirt.png";
        public static string seasonalStone = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/seasonal/stone.png";

        public static string languageIndex = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/language/index.json";
    }
}