using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static string ver;
        public static string url;
        public static string type;

        public static void LaunchGame()
        {
            //TODO: ATTEMPT FIXING BLACK SCREEN BY COPYING BASE GAME INTO XENIA?

            //Create required dirs
            Directory.CreateDirectory($"{Globals.dataPath}");
            Directory.CreateDirectory($"{Globals.dataPath}\\versions");
            Directory.CreateDirectory($"{Globals.dataPath}\\versions\\x360");
            Directory.CreateDirectory($"{Globals.dataPath}\\emulator\\xenia");
            Directory.CreateDirectory($"{Globals.docsPath}\\Xenia\\content\\584111F7\\000B0000");
            Logger.logMessage("[LaunchX360]", $"Directories created");

            //Get latest xenia version
            WebClient wc = new WebClient();
            string xeniaJson = wc.DownloadString(Globals.xeniaInfo);
            Logger.logError("[LaunchX360]" , xeniaJson);

            List<xeniaObject> data = JsonConvert.DeserializeObject<List<xeniaObject>>(xeniaJson);
            foreach (var vers in data)
            {
                Console.WriteLine(vers.id);
                Console.WriteLine(vers.ver);
                Console.WriteLine(vers.url);

                if (!File.Exists($"{Globals.dataPath}\\emulator\\xenia\\version.cfg"))
                {
                    updateXenia(vers.url, vers.ver);
                }
                else
                {
                    string text = File.ReadAllText($"{Globals.dataPath}\\emulator\\xenia\\version.cfg");
                    if(!text.Contains(vers.ver))
                    {
                        updateXenia(vers.url, vers.ver);
                    }
                }
            }

            //download game and updates
            if (!Directory.Exists($"{Globals.dataPath}\\versions\\x360\\{ver}"))
            {
                DownloadProgress.url = url;
                DownloadProgress.savePath = $"{Globals.dataPath}\\versions\\x360\\{ver}.zip";
                DownloadProgress dp = new DownloadProgress();
                dp.ShowDialog();

                if(File.Exists($"{Globals.dataPath}\\versions\\x360\\{ver}.zip"))
                {
                    Directory.CreateDirectory($"{Globals.dataPath}\\versions\\x360\\{ver}");
                    ZipFile.ExtractToDirectory($"{Globals.dataPath}\\versions\\x360\\{ver}.zip", $"{Globals.dataPath}\\versions\\x360\\{ver}");
                    File.Delete($"{Globals.dataPath}\\versions\\x360\\{ver}.zip");
                }
            }
            Logger.logMessage("[LaunchXbox360]", $"Ver: {ver}, Url: {url}, Type: {type}");
            
            if(type  == "base")
            {
                if(Directory.Exists($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000"))
                    Directory.Delete($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000", true);

                Process.Start($"{Globals.dataPath}\\emulator\\xenia\\xenia_canary.exe", $"\"{Globals.dataPath}\\versions\\x360\\{ver}\\default.xex\"");
            }
            else if(type == "update")
            {
                //get base
                if(!Directory.Exists($"{Globals.dataPath}\\versions\\x360\\tu0"))
                {
                    WebClient cl = new WebClient();
                    string urlForBase = cl.DownloadString(Globals.x360Base);

                    DownloadProgress.url = urlForBase;
                    DownloadProgress.savePath = $"{Globals.dataPath}\\versions\\x360\\tu0.zip";
                    DownloadProgress dp = new DownloadProgress();
                    dp.ShowDialog();

                    if (File.Exists($"{Globals.dataPath}\\versions\\x360\\tu0.zip"))
                    {
                        Directory.CreateDirectory($"{Globals.dataPath}\\versions\\x360\\tu0");
                        ZipFile.ExtractToDirectory($"{Globals.dataPath}\\versions\\x360\\tu0.zip", $"{Globals.dataPath}\\versions\\x360\\tu0");
                        File.Delete($"{Globals.dataPath}\\versions\\x360\\tu0.zip");
                    }
                }

                //get update
                if (!Directory.Exists($"{Globals.dataPath}\\versions\\x360\\{ver}"))
                {
                    DownloadProgress.url = url;
                    DownloadProgress.savePath = $"{Globals.dataPath}\\versions\\x360\\{ver}.zip";
                    DownloadProgress dp = new DownloadProgress();
                    dp.ShowDialog();

                    if (File.Exists($"{Globals.dataPath}\\versions\\x360\\{ver}.zip"))
                    {
                        Directory.CreateDirectory($"{Globals.dataPath}\\versions\\x360\\{ver}");
                        ZipFile.ExtractToDirectory($"{Globals.dataPath}\\versions\\x360\\{ver}.zip", $"{Globals.dataPath}\\versions\\x360\\{ver}");
                        File.Delete($"{Globals.dataPath}\\versions\\x360\\{ver}.zip");
                    }
                }

                //move base to xenia dir
                if(!Directory.Exists($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\{ver}"))
                {
                    Directory.CreateDirectory($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000");

                    DirectoryInfo di = new DirectoryInfo($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000");
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    Directory.CreateDirectory($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\{ver}");

                    foreach (string dirPath in Directory.GetDirectories($"{Globals.dataPath}\\versions\\x360\\{ver}", "*", SearchOption.AllDirectories))
                    {
                        Directory.CreateDirectory(dirPath.Replace($"{Globals.dataPath}\\versions\\x360\\{ver}", $"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\{ver}"));
                    }

                    //Copy all the files & Replaces any files with the same name
                    foreach (string newPath in Directory.GetFiles($"{Globals.dataPath}\\versions\\x360\\{ver}", "*.*", SearchOption.AllDirectories))
                    {
                        File.Copy(newPath, newPath.Replace($"{Globals.dataPath}\\versions\\x360\\{ver}", $"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\{ver}"), true);
                    }
                }

                Process.Start($"{Globals.dataPath}\\emulator\\xenia\\xenia_canary.exe", $"\"{Globals.dataPath}\\versions\\x360\\tu0\\default.xex\"");
            }
        }

        public static void updateXenia(string url, string ver)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo($"{Globals.dataPath}\\emulator\\xenia");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            using (StreamWriter sw = File.CreateText($"{Globals.dataPath}\\emulator\\xenia\\version.cfg"))
            {
                sw.WriteLine(ver);
            }
            using (var client = new WebClient())
            {
                client.DownloadFile(url, $"{Globals.dataPath}\\emulator\\xenia\\temp.zip");
            }
            ZipFile.ExtractToDirectory($"{Globals.dataPath}\\emulator\\xenia\\temp.zip", $"{Globals.dataPath}\\emulator\\xenia\\");
            File.Delete($"{Globals.dataPath}\\emulator\\xenia\\temp.zip");
        }
    }

    public class xeniaObject
    {
        public string id { get; set; }
        public string ver { get; set; }
        public string url { get; set; }
    }
}
