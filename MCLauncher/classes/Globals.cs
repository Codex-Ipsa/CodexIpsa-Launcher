using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MCLauncher
{
    class Globals
    {
        //System
        public static WebClient client = new WebClient();
        public static bool offlineMode = false;

        //Manual
        public static string codebase = "0.3.3"; //0.3.3 //0.4.0-dev //0.3.0-prod //0.3.0-dev //0.2.1 //0.2.1-old //0.2.0 //omega13 //0.0.7-dev //mojang-data //legacyfix //legacyfix-testing
        public static string branch = "stable"; //stable //dev //experimental //omega13 //dev-instances //pallas-testing
        public static string verCurrent = "0.3.3"; //Change this on release
        public static string verDisplay = "0.3.3"; //Change this on release

        //Paths
        public static string currentPath = Directory.GetCurrentDirectory();
        public static string dataPath = Directory.GetCurrentDirectory() + "\\.codexipsa";
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //GameInfos
        public static Dictionary<string, string> running = new Dictionary<string, string>();

        //Switches
        public static bool isDebug = false;
        public static bool requireAuth = true; //Change this on release

        //Java manifests
        public static string javaManifest = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/java-manifest.json";
        public static string javaLatest = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/java-latest.json";
        public static string javaInfo = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/{{type}}/{{ver}}.json";
        public static string javaEduManifest = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/javaedu_manifest.json";

        public static string PallasManifest = $"http://codex-ipsa.dejvoss.cz/launcher/modrepo/pallas.json";
        public static string JavaInstalls = "http://codex-ipsa.dejvoss.cz/launcher/jre/manifest.json";
        public static string Modloaders = "http://codex-ipsa.dejvoss.cz/launcher/modloader/loaders-{ver}.json";
        public static string fabricReuploads = $"http://api.codex-ipsa.cz/modloader/fabric-reups.json";

        //Xbox manifests
        public static string x360Manifest = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/x360_manifest.json";
        public static string x360Url = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/x360_url.txt";
        public static string x360Base = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/x360_base.txt";
        public static string xeniaManifest = $"http://codex-ipsa.dejvoss.cz/launcher/emulator/xenia_manifest.json";

        //System
        public static string updaterUrl = $"http://codex-ipsa.dejvoss.cz/launcher/LauncherUpdater2.exe"; //LauncherUpdater.exe
        public static string updateInfo = $"http://codex-ipsa.dejvoss.cz/launcher/version/list.json";
        public static string changelogUrl = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/changelog.php";
        public static string seasonalDirt = $"http://codex-ipsa.dejvoss.cz/launcher/seasonal/dirt.png";
        public static string seasonalStone = $"http://codex-ipsa.dejvoss.cz/launcher/seasonal/stone.png";
        public static string seasonalManifest = $"http://codex-ipsa.dejvoss.cz/launcher/seasonal/index.json";
        public static string offlineManifest = $"http://codex-ipsa.dejvoss.cz/launcher/offline.json";

        public static string languageList = $"http://codex-ipsa.dejvoss.cz/launcher/language/index.json";
        public static string languageJson = $"http://codex-ipsa.dejvoss.cz/launcher/language/{{selected}}.json";
    }
}