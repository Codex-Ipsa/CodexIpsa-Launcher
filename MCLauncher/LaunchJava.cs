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
        public static string launchJavaLocation;
        public static bool useCustJava;

        public static bool useCustJvm;
        public static string launchClasspath;
        public static bool useCustMethod;

        public static bool useCustJar;

        public static bool useOfflineMode;

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

            //Deserialize the versiontype json
            launchJsonUrl = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{Globals.codebase}/ver-launch/{launchVerType}.json";
            Console.WriteLine($"[LaunchJava] Loading version data from {launchJsonUrl}...");
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(launchJsonUrl);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    launchJavaReq = vers.minJava;
                    Console.WriteLine($"[LaunchJava] Minimum Java: {launchJavaReq}");
                    launchClasspath = vers.launchMethod;
                    Console.WriteLine($"[LaunchJava] Classpath: {launchClasspath}");
                    launchLibsType = vers.libsType;
                    Console.WriteLine($"[LaunchJava] Libs type: {launchLibsType}");
                    launchLibsPath = vers.libs;
                    Console.WriteLine($"[LaunchJava] Libs path: {launchLibsPath}");
                    launchProxyPort = vers.proxy;
                    Console.WriteLine($"[LaunchJava] Proxy port: {launchProxyPort}");
                    launchCmdAddon = vers.addCmd;
                    Console.WriteLine($"[LaunchJava] Addon: {launchCmdAddon}");
                    if (vers.getServer == "true")
                    {
                        Console.WriteLine($"[LaunchJava] GetServer is true");
                        EnterIp ei = new EnterIp();
                        ei.ShowDialog();

                        if (EnterIp.inputedText == String.Empty || EnterIp.inputedText == null)
                        {
                            launchJoinMP = false;
                            Console.WriteLine($"[LaunchJava] Server IP returned empty.");
                        }
                        else
                        {
                            launchServerIP = EnterIp.serverIP;
                            launchServerPort = EnterIp.serverPort;
                            launchJoinMP = true;
                            Console.WriteLine($"[LaunchJava] Server IP: {launchServerIP}");
                            Console.WriteLine($"[LaunchJava] Server port: {launchServerPort}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"[LaunchJava] GetServer is false");
                    }
                }
            }
            Console.WriteLine($"[LaunchJava] Loaded version data!");

            MSAuth.onGameStart();
            if (MSAuth.hasErrored == true)
            {
                Logger.log(ConsoleColor.Red, ConsoleColor.Gray, $"[MSAuth]", $"Could not authenticate you.");
                MSAuth.hasErrored = false;
            }
            else
            {
                Console.WriteLine($"[LaunchJava] MP pass: {launchMpPass}");
                //Create required dirs
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa");
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\versions");
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\versions\\java");
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs");
                Console.WriteLine($"[LaunchJava] Directories created!");

                Console.WriteLine($"[LaunchJava] Version: {launchVerName}");
                Console.WriteLine($"[LaunchJava] Type: {launchVerType}");
                Console.WriteLine($"[LaunchJava] Url: {launchVerUrl}");

                //Set required stuff
                launchClientPath = $".codexipsa/versions/java/{launchVerName}.jar";
                Console.WriteLine($"[LaunchJava] Client path: {launchClientPath}");
                launchProxy = $"-DproxySet=true -Dhttp.proxyHost=betacraft.uk -Dhttp.proxyPort={launchProxyPort} -Djava.util.Arrays.useLegacyMergeSort=true -Dstand-alone=true";
                Console.WriteLine($"[LaunchJava] Proxy: {launchProxy}");
                launchNativePath = $".codexipsa/libs/natives/";
                Console.WriteLine($"[LaunchJava] Natives path:{launchNativePath}");
                workDir = $"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}"; //TODO, customise
                Console.WriteLine($"[LaunchJava] WorkDir: {workDir}");
                gameDir = $"\"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}\\.minecraft\""; //TODO, customise
                Console.WriteLine($"[LaunchJava] GameDir: {gameDir}");
                assetDir = $"\"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}\\assets\""; //TODO, customise
                Console.WriteLine($"[LaunchJava] AssetsDir: {assetDir}");
                /*launchPlayerName = Properties.Settings.Default.playerName;*/
                Console.WriteLine($"[LaunchJava] Player name: {launchPlayerName}");

                //Download client
                Console.WriteLine($"[LaunchJava] Donloading client...");
                var dlClient = new WebClient();
                if (!File.Exists($"{Globals.currentPath}\\.codexipsa\\versions\\java\\{launchVerName}.jar"))
                {
                    DownloadProgress.url = launchVerUrl;
                    DownloadProgress.savePath = $"{Globals.currentPath}\\.codexipsa\\versions\\java\\{launchVerName}.jar";
                    DownloadProgress dl = new DownloadProgress();
                    dl.ShowDialog();
                }
                Console.WriteLine($"[LaunchJava] Done!");

                //Check for libs - TODO
                Console.WriteLine($"[LaunchJava] Starting libs check...");
                LibsCheck.type = launchLibsType;
                LibsCheck.Check();
                Console.WriteLine($"[LaunchJava] Done!");

                //TODO: CHECK IF AUTHENTICATED
                if (launchPlayerAccessToken == String.Empty || launchPlayerAccessToken == null)
                {
                    Logger.log(ConsoleColor.Red, ConsoleColor.Gray, "[LaunchJava]", "Failed to authenticate!");
                    Logger.log(ConsoleColor.Red, ConsoleColor.Gray, "[LaunchJava]", "The game will start in offline mode.");
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
                    launchCommand += $"-Dserver={launchServerIP} -Dport={launchServerPort} -Dmppass={launchMpPass}";
                }

                launchCommand += $" -Djava.library.path={launchNativePath} -cp \"{launchClientPath};{launchLibsPath}\" {launchClasspath}";
                if (launchCmdAddon != string.Empty)
                {
                    //This needs a better system
                    var launchCmdAddon1 = launchCmdAddon.Replace("{gameDir}", $"{gameDir}");
                    var launchCmdAddon2 = launchCmdAddon1.Replace("{assetDir}", $"{assetDir}");
                    var launchCmdAddon3 = launchCmdAddon2.Replace("{playerName}", $"{launchPlayerName}");
                    var launchCmdAddon4 = launchCmdAddon3.Replace("{session}", $"token:{launchPlayerAccessToken}:{launchPlayerUUID}");
                    var launchCmdAddon5 = launchCmdAddon4.Replace("{version}", $"{launchVerName}");
                    var launchCmdAddon6 = launchCmdAddon5.Replace("{workDir}", $"{workDir}");

                    launchCommand += $" {launchCmdAddon6} with={launchWidth} height={launchHeight}";
                }
                //Console.WriteLine($"[LaunchJava] Launch command done: **{launchCommand}**");
                Console.WriteLine($"[LaunchJava] Java location: {launchJavaLocation}");

                //Check if Java exists
                try
                {
                    Console.WriteLine($"[LaunchJava] Launching the game...");
                    //get current appdata for later
                    var tempAppdata = Environment.GetEnvironmentVariable("Appdata");
                    Console.WriteLine($"[LaunchJava] TempAppdata: {Environment.GetEnvironmentVariable("Appdata")}");

                    //Set appdata to instance dir
                    Environment.SetEnvironmentVariable("Appdata", workDir);
                    Console.WriteLine($"[LaunchJava] InstAppdata: {Environment.GetEnvironmentVariable("Appdata")}");

                    Console.WriteLine($"[LaunchJava] Game output:");
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
                    process.WaitForExit();

                    //Reset appdata back to original
                    Environment.SetEnvironmentVariable("Appdata", tempAppdata);
                    Console.WriteLine($"[LaunchJava] OldAppdata: {Environment.GetEnvironmentVariable("Appdata")}");

                    Console.WriteLine($"[LaunchJava] Closing the game...");
                    //Process.Start("java.exe");
                    //Console.WriteLine("Just pretend the game started");
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    //TODO: start some java install wizard thing LMFAO
                    Console.WriteLine("[LaunchJava] Could not find Java!");
                    Console.WriteLine(ex.Message);
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
