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
        public static string linkToJar;
        public static bool useProxy = true;
        public static string launchCmd;

        public static void LaunchGame()
        {
            using (var client = new WebClient())
            {
                string currentPath = Directory.GetCurrentDirectory();

                //Download required libraries
                if (!File.Exists(Path.Combine(currentPath + "\\bin\\libs\\", "lwjgl.jar")))
                {
                    DownloadProgress.url = Globals.javaLibs;
                    DownloadProgress.savePath = $"{currentPath}\\bin\\libs\\libs.zip";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();

                    string zipPath = currentPath + "\\bin\\libs\\libs.zip";
                    string extractPath = currentPath + "\\bin\\libs\\";
                    ZipFile.ExtractToDirectory(zipPath, extractPath);

                    File.Delete(currentPath + "\\bin\\libs\\libs.zip");
                }

                //Download selected version
                if (!File.Exists(Path.Combine(currentPath + "\\bin\\versions\\", $"{selectedVer}.jar")))
                {
                    DownloadProgress.url = linkToJar;
                    DownloadProgress.savePath = $"{currentPath}\\bin\\versions\\{selectedVer}.jar";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();
                }

                //Apply stuff to the launch command and launch the game
                launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"bin/versions/{selectedVer}.jar;bin/libs/lwjgl.jar;bin/libs/lwjgl_util.jar\" net.minecraft.client.Minecraft {Properties.Settings.Default.playerName}";

                if (Properties.Settings.Default.isDemo == true)
                {
                    launchCmd += " --demo";
                }

                System.Diagnostics.Process.Start("java.exe", launchCmd);
                VerSelect.checkTab = "java";
            }
        }
    }
}
