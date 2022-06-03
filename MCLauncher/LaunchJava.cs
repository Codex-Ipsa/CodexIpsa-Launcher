using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    class LaunchJava
    {
        public static string selectedVer;
        public static string linkToJar;
        public static string typeVer;
        public static bool useProxy = true;
        public static string launchCmd;
        public static string consoleOutput;

        public static string clientPath;
        public static bool isCustom = false;

        public static void LaunchGame()
        {
            //Create directories
            Directory.CreateDirectory($"{Globals.currentPath}\\bin");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions\\java");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\libs");
            if(isCustom == false)
            {
                clientPath = "bin/versions/java/" + selectedVer + ".jar";
            }

            using (var client = new WebClient())
            {
                //Download version
                if (!File.Exists($"{Globals.currentPath}\\bin\\versions\\java\\{selectedVer}.jar"))
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
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"{clientPath};bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jinput-2.0.5.jar\" com.mojang.rubydung.RubyDung {Properties.Settings.Default.playerName} test";

                        System.Diagnostics.Process.Start("java.exe", launchCmd);
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
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"{clientPath};bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jinput-2.0.5.jar\" com.mojang.minecraft.RubyDung {Properties.Settings.Default.playerName} test";

                        System.Diagnostics.Process.Start("java.exe", launchCmd);
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
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"{clientPath};bin/libs/launchwrapper-1.6.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" net.minecraft.launchwrapper.Launch {Properties.Settings.Default.playerName} test --tweakClass net.minecraft.launchwrapper.AlphaVanillaTweaker";

                        System.Diagnostics.Process.Start("java.exe", launchCmd);
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
                        string gamedir = $"\"{Globals.currentPath}\\bin\\instance\\game\"";
                        //string gamedir = $"{Globals.currentPath}\\bin\\instance";
                        string assetdir = $"\"{Globals.currentPath}\\bin\\instance\\assets\"";
                        //Console.WriteLine(gamedir);
                        Console.WriteLine(clientPath);
                        //launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"bin/versions/java/{selectedVer}.jar;bin/libs/launchwrapper-1.6.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" net.minecraft.launchwrapper.Launch {Properties.Settings.Default.playerName} test --gameDir {gamedir} --assetDir {assetdir} --tweakClass net.minecraft.launchwrapper.VanillaTweaker";
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"{clientPath};bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jinput-2.0.5.jar\" net.minecraft.client.Minecraft {Properties.Settings.Default.playerName} test";

                        System.Diagnostics.Process.Start("java.exe", launchCmd);

                        /*Process process = new Process();
                        process.StartInfo.FileName = "java.exe";
                        process.StartInfo.Arguments = launchCmd;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;

                        process.ErrorDataReceived += new DataReceivedEventHandler(ErrorOutputHandler);

                        process.Start();

                        process.BeginErrorReadLine();

                        string output = process.StandardOutput.ReadToEnd();
                        GameConsole.textStr += output;
                        GameConsole con = new GameConsole();
                        con.ShowDialog();
                        process.WaitForExit();*/
                        /*proc.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                        proc.ErrorDataReceived += new DataReceivedEventHandler(OutputHandlerErr);
                        GameConsole con = new GameConsole();
                        con.ShowDialog();

                        while (!proc.StandardOutput.EndOfStream)
                        {
                            consoleOutput = proc.StandardOutput.ReadLine();
                            GameConsole.textStr += consoleOutput;
                        }*/

                        VerSelect.checkTab = "java";
                        LibsCheck.isDone = false;
                    }
                }
                //If it's post1.6, check for libs, download them, and launch the game.
                else if (typeVer == "jar16")
                {

                }
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
