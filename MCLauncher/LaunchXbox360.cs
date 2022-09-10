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
        public static string linkToVer;

        public static void LaunchGame()
        {
            //Create required dirs
            Directory.CreateDirectory($"{Globals.dataPath}");
            Directory.CreateDirectory($"{Globals.dataPath}\\versions");
            Directory.CreateDirectory($"{Globals.dataPath}\\versions\\x360");
            Directory.CreateDirectory($"{Globals.dataPath}\\emulator\\xenia");
            Logger.logMessage("[LaunchX360]", $"Directories created");

            /*Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions\\x360");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\xenia");
            Directory.CreateDirectory($"{Globals.docsPath}\\Xenia\\content\\584111F7\\000B0000");

            //Download and extract the emulator if doesn't exist yet
            if (!File.Exists($"{Globals.currentPath}\\bin\\xenia\\xenia_canary.exe"))
            {
                DownloadProgress.url = Globals.xenia;
                DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\xenia\\xenia.zip";
                DownloadProgress download = new DownloadProgress();
                download.ShowDialog();

                try
                {
                    string zipPath = $"{Globals.currentPath}\\bin\\xenia\\xenia.zip";
                    string extractPath = $"{Globals.currentPath}\\bin\\xenia\\";
                    ZipFile.ExtractToDirectory(zipPath, extractPath);

                    File.Delete($"{Globals.currentPath}\\bin\\xenia\\xenia.zip");
                }
                catch (FileNotFoundException) { }

            }

            //Download and apply the selected version
            if (!File.Exists($"{Globals.currentPath}\\bin\\versions\\x360\\{selectedVer}"))
            {
                DownloadProgress.url = linkToVer;
                DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\versions\\x360\\{selectedVer}";
                DownloadProgress download2 = new DownloadProgress();
                download2.ShowDialog();
            }

            //If it's a base game, launch it
            if (selectedVer == "pre-tu-0033" || selectedVer == "pre-tu-0035" || selectedVer == "pre-tu-0054" || selectedVer == "tu0")
            {
                try
                {
                    string pathToVer = $"{Globals.currentPath}\\bin\\versions\\x360\\{selectedVer}";
                    string pathToCopy = $"{Globals.docsPath}\\Xenia\\content\\584111F7\\000B0000\\tu00000001_00000000";
                    File.Copy(pathToVer, pathToCopy, true);

                    System.Diagnostics.Process.Start($"{Globals.currentPath}\\bin\\xenia\\xenia_canary.exe", $"{Globals.currentPath}\\bin\\versions\\x360\\{selectedVer}");
                    VerSelect.checkTab = "x360";
                }
                catch(FileNotFoundException){}
                catch(System.ComponentModel.Win32Exception) { }
            }
            //If it's an update, launch the base game (tu0), download if doesn't exist yet
            else
            {
                if (!File.Exists($"{Globals.currentPath}\\bin\\versions\\x360\\tu0"))
                {
                    //TODO: GET THIS FROM A JSON
                    DownloadProgress.url = "https://vault.minerarity.org/versions/legacy/x360/TU0/49AAD81B9FCDA45E4A03D71BFCB353F8FADB236C58";
                    DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\versions\\x360\\tu0";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();
                }

                try
                {
                    string pathToVer = $"{Globals.currentPath}\\bin\\versions\\x360\\{selectedVer}";
                    string pathToCopy = $"{Globals.docsPath}\\Xenia\\content\\584111F7\\000B0000\\tu00000001_00000000";
                    File.Copy(pathToVer, pathToCopy, true);

                    System.Diagnostics.Process.Start($"{Globals.currentPath}\\bin\\xenia\\xenia_canary.exe", $"{Globals.currentPath}\\bin\\versions\\x360\\tu0");
                    Console.WriteLine("Game Launched!");
                    VerSelect.checkTab = "x360";
                }
                catch(FileNotFoundException) {}
                catch (System.ComponentModel.Win32Exception) { }
            }*/
        }
    }
}
