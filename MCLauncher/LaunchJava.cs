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
        public static string gameDir;
        public static string assetDir;

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

        public static string launchJavaLocation = "java.exe"; //TODO
        public static string launchCommand;
        public static string launchJavaReq;

        public static string launchXmx = "1024"; //TODO
        public static string launchXms = "1024"; //TODO
        public static string launchProxyPort;
        public static string launchProxy;
        public static string launchNativePath;
        public static string launchClientPath;
        public static string launchLibsPath;
        public static string launchClasspath;
        public static string launchPlayerName = "DEJVOSS"; //TODO
        public static string launchCmdAddon;

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
            launchProxy = $"-DproxySet=true -Dhttp.proxyHost=betacraft.uk -Dhttp.proxyPort={launchProxyPort} -Djava.util.Arrays.useLegacyMergeSort=true";
            launchNativePath = $".codexipsa/libs/natives/";
            gameDir = $"\"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}\\game\""; //TODO
            assetDir = $"\"{Globals.currentPath}\\.codexipsa\\instance\\{currentInstance}\\assets\""; //TODO

            //Download client
            var dlClient = new WebClient();
            if (!File.Exists($"{Globals.currentPath}\\.codexipsa\\versions\\java\\{launchVerName}.jar"))
            {
                DownloadProgress.url = launchVerUrl;
                DownloadProgress.savePath = $"{Globals.currentPath}\\.codexipsa\\versions\\java\\{launchVerName}.jar";
                DownloadProgress dl = new DownloadProgress();
                dl.ShowDialog();
            }

            //Check for libs
            LibsCheck.CheckPre16();

            //Build the launchcmd
            launchCommand = $"-Xmx{launchXmx}m -Xms{launchXms}m ";
            if(launchProxyPort != "null")
            {
                launchCommand += $"{launchProxy} ";
            }
            launchCommand += $"-Djava.library.path={launchNativePath} -cp \"{launchClientPath};{launchLibsPath}\" {launchClasspath} {launchPlayerName} test";
            if (launchCmdAddon != string.Empty)
            {
                //This needs a better system
                var launchCmdAddon1 = launchCmdAddon.Replace("{gameDir}", $"{gameDir}");
                var launchCmdAddon2 = launchCmdAddon1.Replace("{assetDir}", $"{assetDir}");
                launchCommand += $" {launchCmdAddon2}";
            }

            Console.WriteLine($"LaunchCommand done: {launchCommand}");
            Console.WriteLine($"More debug shit:\nname: {launchVerName}\ntype: {launchVerType}\nurl: {launchVerUrl}\ninstance: {currentInstance}\ngameDir: {gameDir}\nassetDir: {assetDir}");
            Console.WriteLine($"VerData url: http://codex-ipsa.dejvoss.cz/MCL-Data/{Globals.codebase}/ver-launch/{launchVerType}.json");

            //Check if Java exists
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = launchJavaLocation;
                process.StartInfo.Arguments = launchCommand;
                process.StartInfo.WorkingDirectory = $"{Globals.currentPath}";
                process.Start();

                VerSelect.checkTab = "java";
                LibsCheck.isDone = false;
                //Process.Start("java.exe");
                //Console.WriteLine("Just pretend the game started");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                //TODO: start some java install wizard thing LMFAO
                Console.WriteLine("Could not find Java!");
                Console.WriteLine(ex.Message);
            }

            using (var download = new WebClient())
            {
                //Download version
                /*if (!File.Exists($"{Globals.currentPath}\\bin\\versions\\java\\{selectedVer}.jar"))
                {
                    DownloadProgress.url = linkToJar;
                    DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\versions\\java\\{selectedVer}.jar";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();
                }

                //If it's a pre-classic, check for libs, download them, and launch the game
                if (typeVer == "rubydung")
                {
                    LibsCheck.CheckPre16();

                    if (LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -Djava.library.path=bin/libs/natives/ -cp \"{clientPath};bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" com.mojang.rubydung.RubyDung {Properties.Settings.Default.playerName} test"; //gameDir {gameDir} --assetDir {assetDir} --tweakClass net.minecraft.launchwrapper.VanillaTweaker

                        //Process.Start("java.exe", launchCmd);
                        Process process = new Process();
                        process.StartInfo.FileName = javaLocation;
                        process.StartInfo.Arguments = launchCmd;
                        process.StartInfo.WorkingDirectory = $"{Globals.currentPath}";
                        process.Start();
                        
                        VerSelect.checkTab = "java";
                        LibsCheck.isDone = false;
                    }
                }
                //If it's rd-161348, check for libs, download them, and launch the game
                else if (typeVer == "rubydung2")
                {
                    LibsCheck.CheckPre16();

                    if (LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -Djava.library.path=bin/libs/natives/ -cp \"{clientPath};bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" com.mojang.minecraft.RubyDung {Properties.Settings.Default.playerName} test"; //gameDir {gameDir} --assetDir {assetDir} --tweakClass net.minecraft.launchwrapper.VanillaTweaker

                        Process process = new Process();
                        process.StartInfo.FileName = javaLocation;
                        process.StartInfo.Arguments = launchCmd;
                        process.StartInfo.WorkingDirectory = $"{Globals.currentPath}";
                        process.Start();

                        VerSelect.checkTab = "java";
                        LibsCheck.isDone = false;
                    }
                }

                //If it's an applet, check for libs, download them, and launch the game
                else if (typeVer == "applet")
                {
                    LibsCheck.CheckPre16();

                    if (LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Dhttp.proxyPort={proxyPort} -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"{clientPath};bin/libs/launchwrapper-1.6.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" net.minecraft.launchwrapper.Launch {Properties.Settings.Default.playerName} test --gameDir {gameDir} --assetDir {assetDir} --tweakClass net.minecraft.launchwrapper.AlphaVanillaTweaker";

                        Process process = new Process();
                        process.StartInfo.FileName = javaLocation;
                        process.StartInfo.Arguments = launchCmd;
                        process.StartInfo.WorkingDirectory = $"{Globals.currentPath}";
                        process.Start();

                        VerSelect.checkTab = "java";
                        LibsCheck.isDone = false;
                    }
                }
                //If it's a1.0.6 to 1.5, check for libs, download them, and launch the game.
                else if (typeVer == "jar106")
                {
                    LibsCheck.CheckPre16();

                    if(LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Dhttp.proxyPort={proxyPort} -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"{clientPath};bin/libs/launchwrapper-1.6.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" net.minecraft.launchwrapper.Launch {Properties.Settings.Default.playerName} test --gameDir {gameDir} --assetDir {assetDir} --tweakClass net.minecraft.launchwrapper.AlphaVanillaTweaker";
                        //launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Dhttp.proxyPort={proxyPort} -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"{clientPath};bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" net.minecraft.client.Minecraft {Properties.Settings.Default.playerName} test --gameDir {gameDir} --assetDir {assetDir}";

                        //edutest
                        //launchCmd = "java.exe -Xms1024m -Xmx1024m -Djava.library.path=minecraft/bin/natives/ -cp \"minecraft/bin/minecraft.jar;minecraft/bin/lwjgl.jar;minecraft/bin/lwjgl_util.jar;minecraft/bin/argo-small-3.2.jar;minecraft/bin/bcprov-jdk15on-148.jar;minecraft/bin/worldedit-5.5.6.jar;minecraft/bin/scala-library.jar;minecraft/bin/guava-14.0-rc3.jar;minecraft/bin/commons-io-2.2.jar;minecraft/bin/jinput.jar;bin/libs/asm-all-4.1.jar\" net.minecraft.client.Minecraft Player test";

                        Process process = new Process();
                        process.StartInfo.FileName = javaLocation;
                        process.StartInfo.Arguments = launchCmd;
                        process.StartInfo.WorkingDirectory = $"{Globals.currentPath}";
                        process.Start();

                        VerSelect.checkTab = "java";
                        LibsCheck.isDone = false;
                    }
                }
                //If it's post1.6, check for libs, download them, and launch the game.
                else if (typeVer == "jar1.6")
                {
                    //java.exe -Xms1024m -Xmx1024m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp "bin/versions/java/1.6.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar;bin/libs/codecjorbis-20101023.jar;bin/libs/codecwav-20101023.jar;bin/libs/libraryjavasound-20101123.jar;bin/libs/librarylwjglopenal-20100824.jar;bin/libs/soundsystem-20120107.jar;bin/libs/argo-2.25_fixed.jar;bin/libs/bcprov-jdk15on-1.47.jar;bin/libs/guava-14.0.jar;bin/libs/commons-lang3-3.1.jar;bin/libs/commons-io-2.4.jar;bin/libs/gson-2.2.2.jar" net.minecraft.client.main.Main PlayerName test --username DEJVOSS --version 1.6 --gameDir bin/instance/Default/game --assetsDir bin/instance/Default/assets
                }*/
            }
        }

        /*private static void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            GameConsole.textStr += e.Data;
            //Console.WriteLine(e.Data);
        }
        private static void ErrorOutputHandler(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
            //Console.WriteLine(e.Data);
        }*/
    }
}
