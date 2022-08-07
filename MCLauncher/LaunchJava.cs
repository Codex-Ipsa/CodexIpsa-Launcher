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

        public static string launchCommand;
        public static string launchJavaReq;

        public static string launchXmx = "1024"; //TODO, custom vars
        public static string launchXms = "1024"; //TODO, custom vars
        public static string launchProxyPort;
        public static string launchProxy;
        public static string launchNativePath;
        public static string launchClientPath;
        public static string launchLibsPath;
        public static string launchPlayerName;
        public static string launchPlayerUUID;
        public static string launchMpPass;
        public static string launchPlayerAccessToken;
        public static string launchCmdAddon;
        public static bool launchJoinMP = false;
        public static string launchServerIP;
        public static string launchServerPort;
        public static string launchWidth = "854";
        public static string launchHeight = "480";
        public static string launchJavaLocation = "java.exe";
        public static bool useCustJava;

        public static bool useCustJvm;
        public static string launchClasspath;
        public static bool useCustMethod;

        public static bool useCustJar;

        public static bool useOfflineMode;

        public static string gameDir;
        public static string assetDir;
        public static string workDir;

        public static string assetIndexType;
        public static string assetIndexUrl;

        public static void LaunchGame()
        {
            //Deserialize the versiontype json
            launchJsonUrl = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{Globals.codebase}/ver-launch/{launchVerType}.json";
            Logger.logMessage("[LaunchJava]", $"Loading version data from {launchJsonUrl}");
            
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(launchJsonUrl);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    launchJavaReq = vers.minJava;
                    Logger.logMessage("[LaunchJava]", $"Minimum java: {launchJavaReq}");
                    launchClasspath = vers.launchMethod;
                    Logger.logMessage("[LaunchJava]", $"Main class: {launchClasspath}");
                    launchLibsType = vers.libsType;
                    Logger.logMessage("[LaunchJava]", $"Libs type: {launchLibsType}");
                    launchProxyPort = vers.proxy;
                    Logger.logMessage("[LaunchJava]", $"Proxy port: {launchProxyPort}");
                    launchCmdAddon = vers.addCmd;
                    Logger.logMessage("[LaunchJava]", $"Addon: {launchCmdAddon}");
                    if (vers.getServer == "true")
                    {
                        Logger.logMessage("[LaunchJava]", $"getServer returned true");
                        EnterIp ei = new EnterIp();
                        ei.ShowDialog();

                        if (EnterIp.inputedText == String.Empty || EnterIp.inputedText == null)
                        {
                            launchJoinMP = false;
                            Logger.logMessage("[LaunchJava]", $"serverIP returned empty");
                        }
                        else
                        {
                            launchServerIP = EnterIp.serverIP;
                            launchServerPort = EnterIp.serverPort;
                            launchJoinMP = true;
                            Logger.logMessage("[LaunchJava]", $"Server IP: {launchServerIP}");
                            Logger.logMessage("[LaunchJava]", $"Server port: {launchServerPort}");
                        }
                    }
                    else
                    {
                        Logger.logMessage("[LaunchJava]", $"getServer returned false");
                    }
                }
            }
            Logger.logMessage("[LaunchJava]", $"Version data succesfully loaded");            

            if(launchJoinMP == true)
            {
                MSAuth.onGameStart(true);
            }
            else
            {
                MSAuth.onGameStart(false);
            }

            if (MSAuth.hasErrored == true)
            {
                Logger.logError("[MSAuth/LaunchJava]", $"Could not authenticate you!");
                MSAuth.hasErrored = false;
            }
            else
            {

                //Check for assets + get type from json name
                if (assetIndexUrl != String.Empty)
                {
                    string input1 = assetIndexUrl;
                    input1 = input1.Substring(input1.LastIndexOf("/"));
                    input1 = input1.Replace(".json", "");
                    input1 = input1.Replace("/", "");
                    assetIndexType = input1;
                    Logger.logError("[AssetIndex/LaunchJava]", $"indexType: {assetIndexType}");
                    AssetIndex.start(assetIndexUrl, assetIndexType);
                }

                Logger.logMessage("[LaunchJava]", $"Mppass: {launchMpPass}");
                //Create required dirs
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa");
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\versions");
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\versions\\java");
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs");
                Logger.logMessage("[LaunchJava]", $"Directories created");

                Logger.logMessage("[LaunchJava]", $"Version name: {launchVerName}");
                Logger.logMessage("[LaunchJava]", $"Version type: {launchVerType}");
                Logger.logMessage("[LaunchJava]", $"Version URL: {launchVerUrl}");
                Logger.logMessage("[LaunchJava]", $"Version AssetIndex: {assetIndexUrl}");

                //Set required stuff
                launchClientPath = $".codexipsa/versions/java/{launchVerName}.jar";
                Logger.logMessage("[LaunchJava]", $"Client path: {launchClientPath}");
                launchProxy = $"-DproxySet=true -Dhttp.proxyHost=betacraft.uk -Dhttp.proxyPort={launchProxyPort} -Djava.util.Arrays.useLegacyMergeSort=true -Dstand-alone=true"; //TO DISABLE 1.6 has been release flag use -Dhttp.nonProxyHosts=assets.minecraft.net
                Logger.logMessage("[LaunchJava]", $"Proxy: {launchProxy}");
                launchNativePath = $".codexipsa/libs/natives/";
                Logger.logMessage("[LaunchJava]", $"Native path: {launchNativePath}");
                workDir = $"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}"; //TODO, customise
                Logger.logMessage("[LaunchJava]", $"WorkDir: {workDir}");
                gameDir = $"\"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}\\.minecraft\""; //TODO, customise
                Logger.logMessage("[LaunchJava]", $"GameDir: {gameDir}");
                assetDir = $"\"{Globals.currentPath}\\.codexipsa\\assets\\{assetIndexType}\""; //TODO, customise
                Logger.logMessage("[LaunchJava]", $"AssetDir: {assetDir}");
                Logger.logMessage("[LaunchJava]", $"Player name: {launchPlayerName}");

                //Download client
                var dlClient = new WebClient();
                if (!File.Exists($"{Globals.currentPath}\\.codexipsa\\versions\\java\\{launchVerName}.jar"))
                {
                    DownloadProgress.url = launchVerUrl;
                    DownloadProgress.savePath = $"{Globals.currentPath}\\.codexipsa\\versions\\java\\{launchVerName}.jar";
                    DownloadProgress dl = new DownloadProgress();
                    dl.ShowDialog();
                }
                Logger.logMessage("[LaunchJava]", $"Downloaded client.jar");

                LibsCheck.type = launchLibsType;
                LibsCheck.Check();

                foreach (var lib in LibsCheck.libsList)
                {
                    Logger.logMessage("[LibsCheck/LaunchJava]", $"Loaded a lib from list: {lib}");
                    launchLibsPath += $".codexipsa\\libs\\{lib};";
                }

                //TODO: CHECK IF AUTHENTICATED
                if (launchPlayerAccessToken == String.Empty || launchPlayerAccessToken == null)
                {
                    Logger.logError("[LaunchJava]", $"Failed to authenticate");
                    Logger.logError("[LaunchJava]", $"The game will start in offline mode");
                    launchPlayerAccessToken = "null";
                    launchPlayerUUID = "null";
                    launchMpPass = "null";
                    launchPlayerName = "Guest";
                }


                //Build the launchcmd
                launchCommand = $"-Xmx{launchXmx}m -Xms{launchXms}m ";
                if (launchProxyPort != "null")
                {
                    launchCommand += $"{launchProxy} ";
                }
                if (launchJoinMP == true)
                {
                    launchCommand += $"-Dserver={launchServerIP} -Dport={launchServerPort} -Dmppass={launchMpPass} ";
                }

                launchCommand += $"-Djava.library.path={launchNativePath} -cp \"{launchClientPath};{launchLibsPath}\" {launchClasspath}";
                if (launchCmdAddon != string.Empty)
                {
                    //This needs a better system
                    var launchCmdAddon1 = launchCmdAddon.Replace("{gameDir}", $"{gameDir}");
                    var launchCmdAddon2 = launchCmdAddon1.Replace("{assetDir}", $"{assetDir}");
                    var launchCmdAddon3 = launchCmdAddon2.Replace("{playerName}", $"{launchPlayerName}");
                    var launchCmdAddon4 = launchCmdAddon3.Replace("{session}", $"token:{launchPlayerAccessToken}:{launchPlayerUUID}");
                    var launchCmdAddon5 = launchCmdAddon4.Replace("{version}", $"{launchVerName}");
                    var launchCmdAddon6 = launchCmdAddon5.Replace("{workDir}", $"{workDir}");

                    launchCommand += $" {launchCmdAddon6}";
                }
                if(Globals.isDebug)
                {
                    Logger.logMessage("[LaunchJava]", $"Launch cmd done: {launchCommand}");
                }
                Logger.logMessage("[LaunchJava]", $"Java location: {launchJavaLocation}");

                //Check if Java exists
                try
                {
                    Logger.logMessage("[LaunchJava]", $"Launching the game");

                    //Get current appdata for later
                    var tempAppdata = Environment.GetEnvironmentVariable("Appdata");
                    Logger.logMessage("[LaunchJava]", $"Current Appdata is {Environment.GetEnvironmentVariable("Appdata")}");

                    //Set appdata to instance dir
                    Environment.SetEnvironmentVariable("Appdata", workDir);
                    Logger.logMessage("[LaunchJava]", $"Changed Appdata to {Environment.GetEnvironmentVariable("Appdata")}");
                    Logger.logMessage("[LaunchJava]", $"Game output:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //Start the game
                    Process process = new Process();
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.OutputDataReceived += OnOutputDataReceived;
                    process.ErrorDataReceived += OnErrorDataReceived;


                    process.StartInfo.FileName = launchJavaLocation;
                    process.StartInfo.Arguments = launchCommand;
                    process.StartInfo.WorkingDirectory = $"{Globals.currentPath}";
                    process.Start();

                    process.BeginErrorReadLine();
                    process.BeginOutputReadLine();

                    VerSelect.checkTab = "java";
                    LibsCheck.isDone = false;
                    launchLibsPath = string.Empty;
                    process.WaitForExit();

                    //Reset appdata back to original
                    Environment.SetEnvironmentVariable("Appdata", tempAppdata);
                    Logger.logMessage("[LaunchJava]", $"Changed Appdata back to {Environment.GetEnvironmentVariable("Appdata")}");
                    Logger.logMessage("[LaunchJava]", $"Game closed");
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    //TODO: start some java install wizard thing LMFAO
                    Logger.logError("[LaunchJava]", $"Could not find Java: {ex.Message}");
                }
            }
        }

        static void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(e.Data);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Data);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
