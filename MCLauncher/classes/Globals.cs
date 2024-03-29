using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;
using MCLauncher.classes;

namespace MCLauncher
{
    class Globals
    {
        //System
        public static WebClient client = new WebClient();
        public static bool offlineMode = false;

        //Manual
        public static string codebase = "0.3.2"; //0.4.0-dev //0.3.0-prod //0.3.0-dev //0.2.1 //0.2.1-old //0.2.0 //omega13 //0.0.7-dev //mojang-data //legacyfix //legacyfix-testing
        public static string branch = "stable"; //dev //omega13 //stable //dev-instances //experimental //pallas-testing
        public static string verCurrent = "0.3.2"; //Change this on release
        public static string verDisplay = "0.3.2"; //Change this on release

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
        public static string javaManifest = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/java_manifest.json";
        public static string javaInfo = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/data/{{ver}}.json";
        public static string javaEduManifest = $"http://codex-ipsa.dejvoss.cz/launcher/codebase/{codebase}/javaedu_manifest.json";

        public static string PallasManifest = $"http://codex-ipsa.dejvoss.cz/launcher/modrepo/pallas.json";
        public static string JavaInstalls = "http://codex-ipsa.dejvoss.cz/launcher/jre/manifest.json";
        public static string Modloaders = "http://codex-ipsa.dejvoss.cz/launcher/modloader/loaders-{ver}.json";
        public static string reuploadsManifest = $"http://codex-ipsa.dejvoss.cz/launcher/modloader/reuploads.json";

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
        public static string seasonalManfest = $"http://codex-ipsa.dejvoss.cz/launcher/seasonal/index.json";
        public static string offlineManfest = $"http://codex-ipsa.dejvoss.cz/launcher/offline.json";
        public static string languageManfest = $"http://codex-ipsa.dejvoss.cz/launcher/lang/index.json";
    }
}