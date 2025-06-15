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
        public static string codebase = "0.3.7"; //0.3.3 //0.4.0-dev //0.3.0-prod //0.3.0-dev //0.2.1 //0.2.1-old //0.2.0 //omega13 //0.0.7-dev //mojang-data //legacyfix //legacyfix-testing
        public static string branch = "stable"; //stable //dev //experimental //omega13 //dev-instances //pallas-testing
        public static string verCurrent = "0.3.10"; //Change this on release
        public static string verDisplay = "0.3.10"; //Change this on release

        //Paths
        public static string currentPath = Directory.GetCurrentDirectory();
        public static string dataPath = Directory.GetCurrentDirectory() + "\\.codexipsa";
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //GameInfos
        public static Dictionary<string, string> running = new Dictionary<string, string>();

        //Switches
        public static bool isDebug = false;

        //Java manifests
        public static string javaManifest = $"http://files.codex-ipsa.cz/version/{codebase}/java-manifest.json";
        public static string javaManifestFile = $"{dataPath}\\versions\\java-manifest.json";
        public static string javaLatest = $"http://files.codex-ipsa.cz/version/{codebase}/java-latest.json";
        public static string javaInfo = $"http://files.codex-ipsa.cz/version/{codebase}/{{type}}/{{ver}}.json";
        public static string javaEduManifest = $"http://files.codex-ipsa.cz/version/{codebase}/javaedu-manifest.json";
        public static string javaEduManifestFile = $"{dataPath}\\versions\\javaedu-manifest.json";

        public static string PallasManifest = $"http://files.codex-ipsa.cz/modrepo/manifest.json";
        public static string JavaInstalls = "http://files.codex-ipsa.cz/jre/manifest.json";
        public static string Modloaders = "http://files.codex-ipsa.cz/modloaders/{ver}.json";
        public static string fabricReuploads = $"http://files.codex-ipsa.cz/modloaders/reuploads.json";

        //Xbox manifests
        public static string x360Manifest = $"http://files.codex-ipsa.cz/version/{codebase}/x360-manifest.json";
        public static string x360ManifestFile = $"{dataPath}\\versions\\x360-manifest.json";
        public static string x360Data = $"http://files.codex-ipsa.cz/version/{codebase}/x360-data.txt";
        public static string xeniaManifest = $"http://files.codex-ipsa.cz/xenia/manifest.json";
        public static string xeniaProfile = $"http://files.codex-ipsa.cz/xenia/xenia_profile.zip";


        //System
        public static string updaterUrl = $"http://files.codex-ipsa.cz/update/LauncherUpdater2.exe"; //LauncherUpdater.exe
        public static string updateInfo = $"http://files.codex-ipsa.cz/update/manifest.json";
        public static string changelogUrl = $"http://files.codex-ipsa.cz/version/{codebase}/changelog.php";
        public static string seasonalManifest = $"http://files.codex-ipsa.cz/seasonal/seasons.json";

        public static string offlineManifest = $"http://files.codex-ipsa.cz/offline.json";

        public static string languageList = $"http://files.codex-ipsa.cz/lang/manifest.json";
        public static string languageJson = $"http://files.codex-ipsa.cz/lang/{{selected}}.json";
    }
}