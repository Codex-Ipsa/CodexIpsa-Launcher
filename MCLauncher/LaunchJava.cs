using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static string selectedVer = "b1.7.3";
        public static string linkToJar = "https://launcher.mojang.com/v1/objects/43db9b498cb67058d2e12d394e6507722e71bb45/client.jar";
        public static string typeVer = "jar106";
        public static bool useProxy = true;
        public static string launchCmd;

        public static void LaunchGame()
        {
            Directory.CreateDirectory(Globals.currentPath + "\\bin");
            Directory.CreateDirectory(Globals.currentPath + "\\bin\\versions");
            Directory.CreateDirectory(Globals.currentPath + "\\bin\\libs");
            Directory.CreateDirectory(Globals.currentPath + "\\bin\\versions\\java");

            using (var client = new WebClient())
            {
                string currentPath = Directory.GetCurrentDirectory();

                //Download required libraries
                /*if (!File.Exists(Path.Combine(currentPath + "\\bin\\libs\\", "lwjgl.jar")))
                {
                    DownloadProgress.url = Globals.javaLibs;
                    DownloadProgress.savePath = $"{currentPath}\\bin\\libs\\libs.zip";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();

                    string zipPath = currentPath + "\\bin\\libs\\libs.zip";
                    string extractPath = currentPath + "\\bin\\libs\\";
                    ZipFile.ExtractToDirectory(zipPath, extractPath);

                    File.Delete(currentPath + "\\bin\\libs\\libs.zip");
                }*/

                //Download version and libraries
                if (!File.Exists(Path.Combine(currentPath + "\\bin\\versions\\java\\", $"{selectedVer}.jar")))
                {
                    DownloadProgress.url = linkToJar;
                    DownloadProgress.savePath = $"{currentPath}\\bin\\versions\\java\\{selectedVer}.jar";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();
                }
                if (typeVer == "applet")
                {
                    LibsCheck.CheckPre17();

                    if (LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"bin/versions/java/{selectedVer}.jar;bin/libs/launchwrapper-1.6.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" net.minecraft.launchwrapper.Launch {Properties.Settings.Default.playerName} test --tweakClass net.minecraft.launchwrapper.AlphaVanillaTweaker";

                        System.Diagnostics.Process.Start("java.exe", launchCmd);
                        VerSelect.checkTab = "java";
                        LibsCheck.isDone = false;
                    }
                }                
                else if (typeVer == "jar106")
                {
                    LibsCheck.CheckPre17();

                    if(LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"bin/versions/java/{selectedVer}.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar\" net.minecraft.client.Minecraft {Properties.Settings.Default.playerName} test";


                        System.Diagnostics.Process.Start("java.exe", launchCmd);
                        VerSelect.checkTab = "java";
                        LibsCheck.isDone = false;
                    }
                }
                else if (typeVer == "jar16")
                {

                }
            }
        }
    }
}
