using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCLauncher
{
    class LaunchJava
    {
        /// <summary>
        /// Old stuff
        /// </summary>
        //Main
        public static string selectedVer;
        public static string linkToJar;
        public static string typeVer;

        //Launch
        public static string instanceName;
        public static string javaLocation = "java.exe";
        public static string proxyPort;
        public static string launchCmd;
        public static string clientPath;
        public static string launchMethod;

        //Debug
        public static bool isCustom = false;
        public static bool useProxy = true;
        public static string consoleOutput;
        /// <summary>
        /// Old stuff ends
        /// </summary>


        public static string launchVerName;
        public static string launchVerType;
        public static string launchVerUrl;
        public static string launchJsonUrl;
        public static string launchLibsType;

        public static string currentInstance;

        public static string launchJavaLocation = "java.exe"; //TODO, custom Java
        public static string launchCommand;
        public static string launchJavaReq;

        public static string launchXmx = "1024"; //TODO, custom vars
        public static string launchXms = "1024"; //TODO, custom vars
        public static string launchProxyPort;
        public static string launchProxy;
        public static string launchNativePath;
        public static string launchClientPath;
        public static string launchLibsPath;
        public static string launchClasspath;
        public static string launchPlayerName;
        public static string launchCmdAddon;

        public static string gameDir;
        public static string assetDir;
        public static string workDir;

        public static void LaunchGame()
        {
            //Create directories
            /*Directory.CreateDirectory($"{Globals.currentPath}\\bin");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions\\java");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\libs");
            gameDir = $"\"{Globals.currentPath}\\bin\\instance\\{instanceName}\\game\"";
            assetDir = $"\"{Globals.currentPath}\\bin\\instance\\{instanceName}\\assets\"";
            if (isCustom == false)
            {
                clientPath = "bin/versions/java/" + selectedVer + ".jar";
            }*/

            //Create required dirs
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\versions");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\versions\\java");
            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs");

            //Deserialize the versiontype json
            launchJsonUrl = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{Globals.codebase}/ver-launch/{launchVerType}.json";
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(launchJsonUrl);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    launchJavaReq = vers.minJava;
                    launchClasspath = vers.launchMethod;
                    launchLibsType = vers.libsType;
                    launchLibsPath = vers.libs;
                    launchProxyPort = vers.proxy;
                    launchCmdAddon = vers.addCmd;
                }
            }
            
            //Set required stuff
            launchClientPath = $".codexipsa/versions/java/{launchVerName}.jar";
            launchProxy = $"-DproxySet=true -Dhttp.proxyHost=betacraft.uk -Dhttp.proxyPort={launchProxyPort} -Djava.util.Arrays.useLegacyMergeSort=true -Dstand-alone=true";
            launchNativePath = $".codexipsa/libs/natives/";
            workDir = $"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}"; //TODO, customise
            gameDir = $"\"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}\\.minecraft\""; //TODO, customise
            assetDir = $"\"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}\\assets\""; //TODO, customise
            launchPlayerName = Properties.Settings.Default.playerName;

            //Download client
            var dlClient = new WebClient();
            if (!File.Exists($"{Globals.currentPath}\\.codexipsa\\versions\\java\\{launchVerName}.jar"))
            {
                DownloadProgress.url = launchVerUrl;
                DownloadProgress.savePath = $"{Globals.currentPath}\\.codexipsa\\versions\\java\\{launchVerName}.jar";
                DownloadProgress dl = new DownloadProgress();
                dl.ShowDialog();
            }

            //Check for libs - TODO
            Console.WriteLine("lib type " + launchLibsType);
            LibsCheck.type = launchLibsType;
            LibsCheck.Check();

            //Build the launchcmd
            launchCommand = $"-Xmx{launchXmx}m -Xms{launchXms}m ";
            if(launchProxyPort != "null")
            {
                launchCommand += $"{launchProxy} ";
            }
            launchCommand += $"-Djava.library.path={launchNativePath} -cp \"{launchClientPath};{launchLibsPath}\" {launchClasspath}";
            if (launchCmdAddon != string.Empty)
            {
                //This needs a better system
                var launchCmdAddon1 = launchCmdAddon.Replace("{gameDir}", $"{gameDir}");
                var launchCmdAddon2 = launchCmdAddon1.Replace("{assetDir}", $"{assetDir}");
                var launchCmdAddon3 = launchCmdAddon2.Replace("{playerName}", $"{launchPlayerName}");
                var launchCmdAddon4 = launchCmdAddon3.Replace("{session}", $"test");
                var launchCmdAddon5 = launchCmdAddon4.Replace("{version}", $"{launchVerName}");
                var launchCmdAddon6 = launchCmdAddon5.Replace("{workDir}", $"{workDir}");

                launchCommand += $" {launchCmdAddon6}";
            }

            Console.WriteLine($"LaunchCommand done: {launchCommand}");
            Console.WriteLine($"More debug shit:\nname: {launchVerName}\ntype: {launchVerType}\nurl: {launchVerUrl}\ninstance: {currentInstance}\ngameDir: {gameDir}\nassetDir: {assetDir}");
            Console.WriteLine($"VerData url: http://codex-ipsa.dejvoss.cz/MCL-Data/{Globals.codebase}/ver-launch/{launchVerType}.json");

            //Check if Java exists
            try
            {
                //get current appdata for later
                var tempAppdata = Environment.GetEnvironmentVariable("Appdata");
                Console.WriteLine($"TempAppdata: {Environment.GetEnvironmentVariable("Appdata")}");
                
                //Set appdata to instance dir
                Environment.SetEnvironmentVariable("Appdata", workDir);
                Console.WriteLine($"InstAppdata: {Environment.GetEnvironmentVariable("Appdata")}");

                //Start the game
                Process process = new Process();
                process.StartInfo.FileName = launchJavaLocation;
                process.StartInfo.Arguments = launchCommand;
                process.StartInfo.WorkingDirectory = $"{Globals.currentPath}";
                process.Start();


                VerSelect.checkTab = "java";
                LibsCheck.isDone = false;
                process.WaitForExit();

                //Reset appdata back to original
                Environment.SetEnvironmentVariable("Appdata", tempAppdata);
                Console.WriteLine($"OldAppdata: {Environment.GetEnvironmentVariable("Appdata")}");

                //Process.Start("java.exe");
                //Console.WriteLine("Just pretend the game started");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                //TODO: start some java install wizard thing LMFAO
                Console.WriteLine("Could not find Java!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
