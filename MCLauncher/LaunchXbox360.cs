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
    class LaunchXbox360
    {
        public static string selectedVer = "tu0";
        public static string linkToVer = "https://vault.minerarity.org/versions/legacy/x360/TU0/49AAD81B9FCDA45E4A03D71BFCB353F8FADB236C58";

        public static void LaunchGame()
        {
            string currentPath = Directory.GetCurrentDirectory();

            //Download and extract the emulator if doesn't exist yet
            if (!File.Exists(Path.Combine(currentPath + "\\bin\\xenia\\", "xenia_canary.exe")))
            {
                DownloadProgress.url = Globals.xenia;
                DownloadProgress.savePath = $"{currentPath}\\bin\\xenia\\xenia.zip";
                DownloadProgress download = new DownloadProgress();
                download.ShowDialog();

                string zipPath = currentPath + "\\bin\\xenia\\xenia.zip";
                string extractPath = currentPath + "\\bin\\xenia\\";
                ZipFile.ExtractToDirectory(zipPath, extractPath);

                File.Delete(currentPath + "\\bin\\xenia\\xenia.zip");
            }

            //Download and apply the selected version
            if (!File.Exists(Path.Combine(currentPath + "\\bin\\versions\\x360\\", $"{selectedVer}")))
            {
                DownloadProgress.url = linkToVer;
                DownloadProgress.savePath = $"{currentPath}\\bin\\versions\\x360\\{selectedVer}";
                DownloadProgress download2 = new DownloadProgress();
                download2.ShowDialog();
            }

            //If it's a base game, launch it
            if (selectedVer == "pre-tu-0033" || selectedVer == "pre-tu-0035" || selectedVer == "pre-tu-0054"/* || selectedVer == "tu0"*/)
            {
                try
                {
                    string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string pathToVer = $"{currentPath}\\bin\\versions\\x360\\{selectedVer}";
                    string pathToCopy = $"{docsPath}\\Xenia\\content\\584111F7\\000B0000\\tu00000001_00000000";
                    File.Copy(pathToVer, pathToCopy, true);

                    System.Diagnostics.Process.Start($"{currentPath}\\bin\\xenia\\xenia_canary.exe", $"{currentPath}\\bin\\versions\\x360\\{selectedVer}");
                    VerSelect.checkTab = "x360";
                }
                catch(FileNotFoundException){}
            }
            //If it's an update, launch the base game (tu0), download if doesn't exist yet
            else
            {
                if (!File.Exists(Path.Combine(currentPath + "\\bin\\versions\\x360\\", "tu0")))
                {
                    DownloadProgress.url = "https://vault.minerarity.org/versions/legacy/x360/TU0/49AAD81B9FCDA45E4A03D71BFCB353F8FADB236C58";
                    DownloadProgress.savePath = $"{currentPath}\\bin\\versions\\x360\\tu0";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();
                }

                try
                {
                    string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string pathToVer = $"{currentPath}\\bin\\versions\\x360\\{selectedVer}";
                    string pathToCopy = $"{docsPath}\\Xenia\\content\\584111F7\\000B0000\\tu00000001_00000000";
                    File.Copy(pathToVer, pathToCopy, true);

                    System.Diagnostics.Process.Start($"{currentPath}\\bin\\xenia\\xenia_canary.exe", $"{currentPath}\\bin\\versions\\x360\\tu0");
                    Console.WriteLine("Game Launched!");
                    VerSelect.checkTab = "x360";
                }
                catch(FileNotFoundException) {}
            }
        }
    }
}
