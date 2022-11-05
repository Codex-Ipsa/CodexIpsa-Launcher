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
    class LaunchPS3
    {
        public static string selectedVer = "1.00";
        public static string linkToVer;

        public static void LaunchGame()
        {
            Directory.CreateDirectory(Globals.currentPath + "\\bin");
            Directory.CreateDirectory(Globals.currentPath + "\\bin\\versions");
            Directory.CreateDirectory(Globals.currentPath + "\\bin\\versions\\ps3");
            Directory.CreateDirectory(Globals.currentPath + "\\bin\\rpcs3");

            using (var client = new WebClient())
            {
                string currentPath = Directory.GetCurrentDirectory();

                //Download and extract the emulator if doesn't exist yet
                if (!File.Exists(Path.Combine(currentPath + "\\bin\\rpcs3\\", "rpcs3.exe")))
                {
                    DownloadProgress.url = "https://s3.us-east-1.wasabisys.com/vault.minerarity.org/versions/legacy/ps3/rpcs3.zip";
                    DownloadProgress.savePath = $"{currentPath}\\bin\\rpcs3\\rpcs3.zip";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();

                    string zipPath = currentPath + "\\bin\\rpcs3\\rpcs3.zip";
                    string extractPath = currentPath + "\\bin\\rpcs3\\";
                    ZipFile.ExtractToDirectory(zipPath, extractPath);

                    File.Delete(currentPath + "\\bin\\rpcs3\\rpcs3.zip");
                }

                //Download the selected version
                if (!Directory.Exists(Path.Combine(currentPath + "\\bin\\versions\\", $"{selectedVer}")))
                {
                    DownloadProgress.url = linkToVer;
                    DownloadProgress.savePath = $"{currentPath}\\bin\\versions\\{selectedVer}";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();

                    string zipPath = currentPath + $"\\bin\\versions\\1.00_blus";
                    string extractPath = currentPath + $"\\bin\\versions\\1.00_blus\\";
                    ZipFile.ExtractToDirectory(zipPath, extractPath);

                    File.Delete(currentPath + $"\\bin\\versions\\1.00_blus");

                    //client.DownloadFile(linkToVer, currentPath + $"\\bin\\versions\\{selectedVer}");
                }

                //If it's the base game, launch it
                if (selectedVer == "1.00_blus"/*|| selectedVer == "pre-tu-0035" || selectedVer == "pre-tu-0054"*/)
                {
                    System.Diagnostics.Process.Start($"{currentPath}\\bin\\rpcs3\\rpcs3.exe", $"{currentPath}\\bin\\versions\\{selectedVer}");
                    //VerSelect.checkTab = "ps3";
                }
            }
        }
    }
}
