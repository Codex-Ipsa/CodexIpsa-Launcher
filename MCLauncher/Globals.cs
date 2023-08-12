using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;

namespace MCLauncher
{
    class Globals
    {
        //System
        public static WebClient client = new WebClient();

        //Manual
        public static string codebase = "omega13"; //0.2.0 //omega13 //0.0.7-dev //mojang-data //legacyfix
        public static string branch = "dev"; //dev //omega13 //stable //dev-instances //experimental
        public static string discordClient = ""; //this is not here on purpose (note to self: MAKE SURE NOT TO SHIP IT IN GIT ELSE YOU'LL HAVE TO REVERT AGAIN!!!!)
        public static string verCurrent = "0.2.0-pre8"; //Change this on release
        public static string verDisplay = "0.2.0-pre8"; //Change this on release

        //Paths
        public static string currentPath = Directory.GetCurrentDirectory();
        public static string dataPath = Directory.GetCurrentDirectory() + "\\.codexipsa";
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //GameInfos
        public static Dictionary<string, string> running = new Dictionary<string, string>();

        //Switches
        public static bool isDebug = false;
        public static bool requireAuth = true; //Change this on release

        //Links
        public static string javaManifest = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/java_manifest.json";
        public static string javaInfo = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/data/{{ver}}.json";
        public static string javaEduManifest = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/javaedu_manifest.json";

        public static string x360Manifest = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/x360_manifest.json";
        public static string x360Url = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/x360_url.txt";
        public static string x360Base = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/x360_base.txt";
        public static string xeniaManifest = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/emulator/xenia_manifest.json";

        public static string CIModsJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/modrepo/manifest.json";

        public static string updaterUrl = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/LauncherUpdater2.exe"; //LauncherUpdater.exe
        public static string updateInfo = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/version/list.json";
        public static string xeniaInfo = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/emulator/xenia.json";
        public static string changelog = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/changelog.html";
        public static string changelogJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/changelog.json";
        //public static string defaultVer = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/java_basever.json";
        public static string javaeduJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/javaedu_version.json";
        public static string x360Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/x360_version.json";
        public static string ps3Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{codebase}/ver-list/ps3_version.json";

        public static string jre8Link = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/jre8-latest.json";
        public static string seasonalDirt = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/seasonal/dirt.png";
        public static string seasonalStone = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/seasonal/stone.png";

        public static string languageIndex = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/language/index.json";
    }
}