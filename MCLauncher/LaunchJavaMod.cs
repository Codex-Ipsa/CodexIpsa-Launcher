using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace MCLauncher
{
    class LaunchJavaMod
    {
        public static string selectedVer;
        public static string modType;
        public static string linkToJar;
        public static string typeVer;
        public static string linkToBase;
        public static string linkToForge;
        public static string launchCmd;

        public static void LaunchGame()
        {
            //Create directories
            Directory.CreateDirectory($"{Globals.currentPath}\\bin");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions\\mods");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\libs");

            using (var client = new WebClient())
            {
                //Apply mods
                if (!File.Exists($"{Globals.currentPath}\\bin\\versions\\mods\\{selectedVer}.jar"))
                {
                    //Just in case these exists, delete them
                    if (Directory.Exists("\\bin\\versions\\mods\\temp\\"))
                        Directory.Delete("\\bin\\versions\\mods\\temp\\", true);
                    if (Directory.Exists("\\bin\\versions\\mods\\temp\\"))
                        Directory.Delete("\\bin\\versions\\mods\\temp\\", true);
                    if (Directory.Exists("\\bin\\versions\\mods\\tempForge\\"))
                        Directory.Delete("\\bin\\versions\\mods\\tempForge\\", true);

                    //If it's not a pre-compiled jar, do all the stuff below
                    if (modType != "jar")
                    {
                        //Download mod jar
                        DownloadProgress.url = linkToJar;
                        DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\versions\\mods\\{selectedVer}.zip";
                        DownloadProgress download2 = new DownloadProgress();
                        download2.ShowDialog();

                        //Download base jar
                        DownloadProgress.url = linkToBase;
                        DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\versions\\mods\\temp.jar";
                        DownloadProgress download = new DownloadProgress();
                        download.ShowDialog();

                        //Extract base jar
                        string zipPathBase = Globals.currentPath + @"\bin\versions\mods\temp.jar";
                        string extractPathBase = Globals.currentPath + @"\bin\versions\mods\temp";
                        ZipFile.ExtractToDirectory(zipPathBase, extractPathBase);

                        //Extract mod jar/zip
                        string zipPathMod = Globals.currentPath + $@"\bin\versions\mods\{selectedVer}.zip";
                        string extractPathMod = Globals.currentPath + @"\bin\versions\mods\tempMod";
                        ZipFile.ExtractToDirectory(zipPathMod, extractPathMod);


                        //If it's a Forge mod:
                        if (modType == "forgeMod")
                        {
                            //Download forge
                            DownloadProgress.url = linkToForge;
                            DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\versions\\mods\\tempForge.zip";
                            DownloadProgress download3 = new DownloadProgress();
                            download3.ShowDialog();

                            //Extract it
                            string zipPathForge = Globals.currentPath + @"\bin\versions\mods\tempForge.zip";
                            string extractPathForge = Globals.currentPath + @"\bin\versions\mods\tempForge";
                            ZipFile.ExtractToDirectory(zipPathForge, extractPathForge);

                            //Copy Forge files to base game files
                            //Create all needed directories
                            foreach (string dirPath in Directory.GetDirectories(extractPathForge, "*", SearchOption.AllDirectories))
                            {
                                Directory.CreateDirectory(dirPath.Replace(extractPathForge, extractPathBase));
                            }
                            //Copy all the files and replace any existing files
                            foreach (string newPath in Directory.GetFiles(extractPathForge, "*.*", SearchOption.AllDirectories))
                            {
                                File.Copy(newPath, newPath.Replace(extractPathForge, extractPathBase), true);
                            }
                        }

                        //Copy mod files to base game files
                        //Create all needed directories
                        foreach (string dirPath in Directory.GetDirectories(extractPathMod, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(extractPathMod, extractPathBase));
                        }
                        //Copy all the files and replace any existing files
                        foreach (string newPath in Directory.GetFiles(extractPathMod, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(extractPathMod, extractPathBase), true);
                        }

                        //Make sure to delete META-INF!
                        if (Directory.Exists(Globals.currentPath + "\\bin\\versions\\mods\\temp\\META-INF\\"))
                        {
                            Directory.Delete(Globals.currentPath + "\\bin\\versions\\mods\\temp\\META-INF\\", true);
                        }

                        //Create a jar out of the game folder
                        ZipFile.CreateFromDirectory(extractPathBase, Globals.currentPath + $"\\bin\\versions\\mods\\{selectedVer}.jar");

                        //Cleanup
                        File.Delete($"{Globals.currentPath}\\bin\\versions\\mods\\{selectedVer}.zip");
                        File.Delete($"{Globals.currentPath}\\bin\\versions\\mods\\temp.jar");
                        Directory.Delete(Globals.currentPath + "\\bin\\versions\\mods\\tempMod\\", true);
                        Directory.Delete(Globals.currentPath + "\\bin\\versions\\mods\\temp\\", true);
                        if (modType == "forgeMod")
                            Directory.Delete($"{Globals.currentPath}\\bin\\versions\\mods\\tempForge\\", true);
                        File.Delete($"{Globals.currentPath}\\bin\\versions\\mods\\tempForge.zip");
                    }
                    //if it is a pre-compiled jar, download it
                    else
                    {
                        //Download mod jar
                        DownloadProgress.url = linkToJar;
                        DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\versions\\mods\\{selectedVer}.jar";
                        DownloadProgress download2 = new DownloadProgress();
                        download2.ShowDialog();
                    }

                }


                //Apply stuff to the launch command and launch the game
                //TODO: CHECK VERSION TYPE, LAUNCH ACCORDINGLY
                if (typeVer == "applet")
                {
                    LibsCheck.CheckPre16();
                    if (LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"bin/versions/mods/{selectedVer}.jar;bin/libs/launchwrapper-1.6.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" net.minecraft.launchwrapper.Launch {Properties.Settings.Default.playerName} test --tweakClass net.minecraft.launchwrapper.AlphaVanillaTweaker";

                        System.Diagnostics.Process.Start("java.exe", launchCmd);
                        VerSelect.checkTab = "javaMod";
                        LibsCheck.isDone = false;
                    }
                }
                else if (typeVer == "jar106")
                {
                    LibsCheck.CheckPre16();
                    if (LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"bin/versions/mods/{selectedVer}.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jinput-2.0.5.jar\" net.minecraft.client.Minecraft {Properties.Settings.Default.playerName} test";

                        System.Diagnostics.Process.Start("java.exe", launchCmd);
                        VerSelect.checkTab = "javaMod";
                        LibsCheck.isDone = false;
                    }
                }
            }
        }
    }
}
