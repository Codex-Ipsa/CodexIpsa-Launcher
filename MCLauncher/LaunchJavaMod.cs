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
        public static string selectedVer = "ap-0.0.9a";
        public static string modType;
        public static string linkToJar;
        public static string linkToBase;
        public static string linkToForge;
        public static string launchCmd;

        public static void LaunchGame()
        {
            Directory.CreateDirectory(Globals.currentPath + "\\bin");
            Directory.CreateDirectory(Globals.currentPath + "\\bin\\versions");
            Directory.CreateDirectory(Globals.currentPath + "\\bin\\libs");
            Directory.CreateDirectory(Globals.currentPath + "\\bin\\mods");

            using (var client = new WebClient())
            {
                string currentPath = Directory.GetCurrentDirectory();

                //Download required libraries
                /*if (!File.Exists(Path.Combine(currentPath + "\\bin\\libs\\", "lwjgl.jar")))
                {
                    DownloadProgress.url = Globals.javaLibs;
                    DownloadProgress.savePath = $"{currentPath}\\bin\\libs\\libs.zip";
                    DownloadProgress download1 = new DownloadProgress();
                    download1.ShowDialog();

                    string zipPath = currentPath + "\\bin\\libs\\libs.zip";
                    string extractPath = currentPath + "\\bin\\libs\\";
                    ZipFile.ExtractToDirectory(zipPath, extractPath);

                    File.Delete(currentPath + "\\bin\\libs\\libs.zip");
                }*/
                //LibsCheck.Check();

                //Apply mods
                if (!File.Exists(Path.Combine(currentPath + "\\bin\\mods\\", $"{selectedVer}.jar")))
                {
                    if (modType == "jarMod")
                    {
                        //Download base jar
                        DownloadProgress.url = linkToBase;
                        DownloadProgress.savePath = $"{currentPath}\\bin\\mods\\temp.jar";
                        DownloadProgress download = new DownloadProgress();
                        download.ShowDialog();

                        //Download mod jar
                        DownloadProgress.url = linkToJar;
                        DownloadProgress.savePath = $"{currentPath}\\bin\\mods\\{selectedVer}.zip";
                        DownloadProgress download2 = new DownloadProgress();
                        download2.ShowDialog();

                        if (Directory.Exists("\\bin\\mods\\temp\\"))
                        {
                            Directory.Delete("\\bin\\mods\\temp\\");
                        }

                        string zipPathBase = currentPath + @"\bin\mods\temp.jar";
                        string extractPathBase = currentPath + @"\bin\mods\temp";
                        ZipFile.ExtractToDirectory(zipPathBase, extractPathBase);

                        string zipPathMod = currentPath + $@"\bin\mods\{selectedVer}.zip";
                        string extractPathMod = currentPath + @"\bin\mods\tempMod";
                        ZipFile.ExtractToDirectory(zipPathMod, extractPathMod);

                        //Create all of the directories
                        foreach (string dirPath in Directory.GetDirectories(extractPathMod, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(extractPathMod, extractPathBase));
                        }

                        //Copy all the files & Replaces any files with the same name
                        foreach (string newPath in Directory.GetFiles(extractPathMod, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(extractPathMod, extractPathBase), true);
                        }

                        if (Directory.Exists(currentPath + "\\bin\\mods\\temp\\META-INF\\"))
                        {
                            Directory.Delete(currentPath + "\\bin\\mods\\temp\\META-INF\\", true);
                        }

                        ZipFile.CreateFromDirectory(extractPathBase, currentPath + $"\\bin\\mods\\{selectedVer}.jar");
                        Directory.Delete(currentPath + "\\bin\\mods\\tempMod\\", true);
                        Directory.Delete(currentPath + "\\bin\\mods\\temp\\", true);

                        File.Delete(currentPath + $"\\bin\\mods\\{selectedVer}.zip");
                        File.Delete(currentPath + $"\\bin\\mods\\temp.jar");
                    }

                    if (modType == "forgeMod")
                    {
                        //Download base jar
                        DownloadProgress.url = linkToBase;
                        DownloadProgress.savePath = $"{currentPath}\\bin\\mods\\temp.jar";
                        DownloadProgress download = new DownloadProgress();
                        download.ShowDialog();

                        //Download mod jar
                        DownloadProgress.url = linkToJar;
                        DownloadProgress.savePath = $"{currentPath}\\bin\\mods\\{selectedVer}.zip";
                        DownloadProgress download2 = new DownloadProgress();
                        download2.ShowDialog();

                        //Download forge
                        DownloadProgress.url = linkToForge;
                        DownloadProgress.savePath = $"{currentPath}\\bin\\mods\\tempForge.zip";
                        DownloadProgress download3 = new DownloadProgress();
                        download3.ShowDialog();

                        if (Directory.Exists("\\bin\\mods\\temp\\"))
                        {
                            Directory.Delete("\\bin\\mods\\temp\\");
                        }

                        string zipPathBase = currentPath + @"\bin\mods\temp.jar";
                        string extractPathBase = currentPath + @"\bin\mods\temp";
                        ZipFile.ExtractToDirectory(zipPathBase, extractPathBase);

                        string zipPathMod = currentPath + $@"\bin\mods\{selectedVer}.zip";
                        string extractPathMod = currentPath + @"\bin\mods\tempMod";
                        ZipFile.ExtractToDirectory(zipPathMod, extractPathMod);

                        string zipPathForge = currentPath + @"\bin\mods\tempForge.zip";
                        string extractPathForge = currentPath + @"\bin\mods\tempForge";
                        ZipFile.ExtractToDirectory(zipPathForge, extractPathForge);

                        //Create all of the directories
                        foreach (string dirPath in Directory.GetDirectories(extractPathForge, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(extractPathForge, extractPathBase));
                        }

                        //Copy all the files & Replaces any files with the same name
                        foreach (string newPath in Directory.GetFiles(extractPathForge, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(extractPathForge, extractPathBase), true);
                        }


                        //Create all of the directories
                        foreach (string dirPath in Directory.GetDirectories(extractPathMod, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(extractPathMod, extractPathBase));
                        }

                        //Copy all the files & Replaces any files with the same name
                        foreach (string newPath in Directory.GetFiles(extractPathMod, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(extractPathMod, extractPathBase), true);
                        }

                        if (Directory.Exists(currentPath + "\\bin\\mods\\temp\\META-INF\\"))
                        {
                            Directory.Delete(currentPath + "\\bin\\mods\\temp\\META-INF\\", true);
                        }

                        ZipFile.CreateFromDirectory(extractPathBase, currentPath + $"\\bin\\mods\\{selectedVer}.jar");
                        Directory.Delete(currentPath + "\\bin\\mods\\tempMod\\", true);
                        Directory.Delete(currentPath + "\\bin\\mods\\tempForge\\", true);
                        Directory.Delete(currentPath + "\\bin\\mods\\temp\\", true);

                        File.Delete(currentPath + $"\\bin\\mods\\{selectedVer}.zip");
                        File.Delete(currentPath + $"\\bin\\mods\\temp.jar");
                        File.Delete(currentPath + $"\\bin\\mods\\tempForge.zip");
                    }
                }


                //Apply stuff to the launch command and launch the game
                launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMX}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"bin/mods/{selectedVer}.jar;bin/libs/lwjgl.jar;bin/libs/lwjgl_util.jar\" net.minecraft.client.Minecraft {Properties.Settings.Default.playerName} test";

                System.Diagnostics.Process.Start("java.exe", launchCmd);
                VerSelect.checkTab = "javaMod";
            }
        }
    }
}
