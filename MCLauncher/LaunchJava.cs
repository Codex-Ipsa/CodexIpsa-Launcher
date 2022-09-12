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
        public static string launchProxy;
        //public static string launchProxyOld;
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
        public static string assetIndexDir;

        public static string loggingXml;
        public static string javaagentJar;

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
                    launchProxy = vers.proxy;
                    Logger.logMessage("[LaunchJava]", $"Proxy: {launchProxy}");
                    launchCmdAddon = vers.addCmd;
                    Logger.logMessage("[LaunchJava]", $"Addon: {launchCmdAddon}");
                    assetIndexUrl = vers.assetIndex;
                    Logger.logMessage("[LaunchJava]", $"Asset index: {assetIndexUrl}");
                    assetIndexDir = vers.assetDir;
                    Logger.logMessage("[LaunchJava]", $"Asset dir: {assetIndexDir}");
                    loggingXml = vers.logging;
                    Logger.logMessage("[LaunchJava]", $"Logging url: {loggingXml}");
                    javaagentJar = vers.javaagent;
                    Logger.logMessage("[LaunchJava]", $"Javaagent url: {javaagentJar}");
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
                    Logger.logMessage("[AssetIndex/LaunchJava]", $"indexType: {assetIndexType}");
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
                launchClientPath = $"{Globals.currentPath}/.codexipsa/versions/java/{launchVerName}.jar";
                Logger.logMessage("[LaunchJava]", $"Client path: {launchClientPath}");
                //launchProxyOld = $"-DproxySet=true -Dhttp.proxyHost=betacraft.uk -Dhttp.proxyPort={launchProxy} -Djava.util.Arrays.useLegacyMergeSort=true -Dstand-alone=true"; //TO DISABLE 1.6 has been release flag use -Dhttp.nonProxyHosts=assets.minecraft.net
                //Logger.logMessage("[LaunchJava]", $"Proxy: {launchProxyOld}");
                launchNativePath = $"\"{Globals.currentPath}/.codexipsa/libs/natives/\"";
                Logger.logMessage("[LaunchJava]", $"Native path: {launchNativePath}");
                workDir = $"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}"; //TODO, customise
                Logger.logMessage("[LaunchJava]", $"WorkDir: {workDir}");
                gameDir = $"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}\\.minecraft"; //TODO, customise
                Logger.logMessage("[LaunchJava]", $"GameDir: {gameDir}");
                assetDir = $"{Globals.currentPath}\\.codexipsa\\assets\\{assetIndexType}"; //TODO, customise
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
                    launchLibsPath += $"{Globals.currentPath}\\.codexipsa\\libs\\{lib};";
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
                if(javaagentJar != "false")
                {
                    Logger.logMessage("[LaunchJava]", "Javaagent active!");
                    string fileName = javaagentJar;
                    int index2 = fileName.IndexOf("/");
                    if (index2 >= 0)
                        fileName = fileName.Substring(fileName.LastIndexOf("/"));

                    if(!File.Exists($"{workDir}\\.minecraft\\{fileName}"))
                    {
                        DownloadProgress.url = javaagentJar;
                        DownloadProgress.savePath = $"{workDir}\\.minecraft\\{fileName}";
                        DownloadProgress dp4j = new DownloadProgress();
                        dp4j.ShowDialog();
                    }
                    launchCommand += $"-javaagent:\"{workDir}\\.minecraft\\{fileName}\" ";
                }
                if (launchProxy != "null")
                {
                    launchCommand += $"{launchProxy} ";
                }
                if (loggingXml != "false")
                {
                    Logger.logMessage("[LaunchJava]", "Log4j active!");
                    string fileName = loggingXml;
                    int index2 = fileName.IndexOf("/");
                    if (index2 >= 0)
                        fileName = fileName.Substring(fileName.LastIndexOf("/"));

                    if (!File.Exists($"{Globals.currentPath}\\.codexipsa\\libs\\log4j\\{fileName}"))
                    {
                        Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs\\log4j");
                        DownloadProgress.url = loggingXml;
                        DownloadProgress.savePath = $"{Globals.currentPath}\\.codexipsa\\libs\\log4j\\{fileName}";
                        DownloadProgress dp4j = new DownloadProgress();
                        dp4j.ShowDialog();
                    }
                    launchCommand += $"-Dlog4j.configurationFile=\"{Globals.currentPath}\\.codexipsa\\libs\\log4j\\{fileName}\" ";
                }
                if (launchJoinMP == true)
                {
                    launchCommand += $"-Dserver={launchServerIP} -Dport={launchServerPort} -Dmppass={launchMpPass} ";
                }

                launchCommand += $"-Djava.library.path={launchNativePath} -cp \"{launchClientPath};{launchLibsPath}\" {launchClasspath} ";
                if (launchCmdAddon != string.Empty)
                {
                    //This needs a better system
                    launchCmdAddon = launchCmdAddon.Replace("{gameDir}", $"\"{gameDir}\"");
                    launchCmdAddon = launchCmdAddon.Replace("{assetDir}", $"\"{assetDir}\"");
                    launchCmdAddon = launchCmdAddon.Replace("{playerName}", $"{launchPlayerName}");
                    //launchCmdAddon = launchCmdAddon.Replace("{session}", $"token:{launchPlayerAccessToken}:{launchPlayerUUID}"); //LEGACY, DO NOT USE
                    launchCmdAddon = launchCmdAddon.Replace("{version}", $"{launchVerName}");
                    launchCmdAddon = launchCmdAddon.Replace("{workDir}", $"\"{workDir}\"");
                    launchCmdAddon = launchCmdAddon.Replace("{uuid}", $"{launchPlayerUUID}");
                    launchCmdAddon = launchCmdAddon.Replace("{accessToken}", $"{launchPlayerAccessToken}");
                    launchCmdAddon = launchCmdAddon.Replace("{assetName}", $"\"{assetIndexType}\"");
                    launchCmdAddon = launchCmdAddon.Replace("{userType}", $"msa");

                    launchCommand += $"{launchCmdAddon}";
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
                    process.StartInfo.WorkingDirectory = $"{gameDir}";
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
