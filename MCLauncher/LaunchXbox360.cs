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
        public static string ver = "tu0";
        public static string url;

        public static void LaunchGame()
        {
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

            //TODO: DOWNLOAD GAME + UPDATES

            Process.Start($"{Globals.dataPath}\\emulator\\xenia\\xenia_canary.exe");
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
