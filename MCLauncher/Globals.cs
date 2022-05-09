﻿using System;
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
<<<<<<< Updated upstream
        public static string verCurrent = "demo1rc";
        public static string verDisplay = "0.0.6-rc (Xbox 360 Demo)";
        public static bool isDev = false;
=======
        public static string codebase = "demo1";
        public static string verCurrent = "demo1";
        public static string verDisplay = "0.0.6 (Demo)";
        public static bool isDev = false; //MAKE SURE IT'S FALSE ON RELEASE
>>>>>>> Stashed changes
        public static bool offlineMode = false;

        public static string currentPath = Directory.GetCurrentDirectory();
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //Links

        public static string xenia = $"http://codex-ipsa.dejvoss.cz/MCL-Data/emu/xenia.zip";
        public static string verCheck = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/latest.txt";
        public static string verCheckDev = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/latest-dev.txt";
        public static string javaLibs = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libs.zip";
        public static string updaterRel = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/MCLauncherUpdater.exe";
        public static string updaterDev = $"https://dejvoss.cz/launcher-data/MCLauncherDevUpdater.exe"; //TODO

        public static string changelog = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{verCurrent}/changelog/";
        public static string javaJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{verCurrent}/data/java.json";
        public static string javaModJson = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{verCurrent}/data/java-mod.json";
        public static string x360Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{verCurrent}/data/x360.json";
        public static string ps3Json = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{verCurrent}/data/ps3-blus.json";
    }
}
