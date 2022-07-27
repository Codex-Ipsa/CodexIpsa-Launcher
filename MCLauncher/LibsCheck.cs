using Newtonsoft.Json;
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
    public class LibsJson
    {
        public string name { get; set; }
        public string link { get; set; }
        public string extract { get; set; }
    }

    class LibsCheck
    {
        public static string type;
        public static bool isDone = false;
        public static List<string> libsList = new List<string>();

        public static void Check()
        {
            Logger.logMessage("[LibsCheck]", $"Starting LibsCheck");
            libsList.Clear();
            string url = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libraries-{type}.json";
            Logger.logMessage("[LibsCheck]", $"Type: {type}");
            Logger.logMessage("[LibsCheck]", $"Url: {url}");

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                List<LibsJson> data = JsonConvert.DeserializeObject<List<LibsJson>>(json);

                foreach (var libs in data)
                {
                    //Add names to a list for LaunchJava
                    libsList.Add(libs.name);

                    //Download required libraries
                    if (!File.Exists($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.name}"))
                    {
                        DownloadProgress.url = libs.link;
                        DownloadProgress.savePath = $"{Globals.currentPath}\\.codexipsa\\libs\\{libs.name}";
                        DownloadProgress download = new DownloadProgress();
                        download.ShowDialog();

                        if (libs.extract != "null")
                        {
                            if (Directory.Exists($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}"))
                                Directory.Delete($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}", true);
                            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}");
                            string zipPath = $"{Globals.currentPath}\\.codexipsa\\libs\\{libs.name}";
                            string extractPath = $"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}";
                            ZipFile.ExtractToDirectory(zipPath, extractPath);
                        }
                    }
                }
                Logger.logMessage("[LibsCheck]", $"Done");
                isDone = true;
            }
        }
    }
}
