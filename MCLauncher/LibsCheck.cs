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
        public static List<string> nativesList = new List<string>(); //TODO

        public static void Check()
        {
            Logger.logMessage("[LibsCheck]", $"Starting LibsCheck");
            libsList.Clear();
            //string url = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libraries-{type}.json";
            string url = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{Globals.codebase}/ver-libs/{type}.json"; //THIS IS FOR THE MAJOR LIBRARIES + VER JSON MERGE
            Logger.logMessage("[LibsCheck]", $"Type: {type}");
            Logger.logMessage("[LibsCheck]", $"Url: {url}");

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                List<LibsJson> data = JsonConvert.DeserializeObject<List<LibsJson>>(json);

                //delete natives
                System.IO.DirectoryInfo di = new DirectoryInfo($"{Globals.currentPath}\\.codexipsa\\libs\\natives\\");
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs\\natives\\");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                foreach (var libs in data)
                {
                    if(libs.extract == "null")
                    {
                        //Add names to a list for LaunchJava - this is here so natives don't get added to the list
                        libsList.Add(libs.name);
                    }

                    //Download required libraries
                    if (!File.Exists($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.name}"))
                    {
                        DownloadProgress.url = libs.link;
                        DownloadProgress.savePath = $"{Globals.currentPath}\\.codexipsa\\libs\\{libs.name}";
                        DownloadProgress download = new DownloadProgress();
                        download.ShowDialog();
                    }

                    if (libs.extract != "null")
                    {
                        //TODO: get rid of this
                        Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}");
                        using (ZipArchive archive = ZipFile.OpenRead($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.name}"))
                        {
                            //TODO: if they don't exist, extract/replace them
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                string dir = "/" + entry.ToString();
                                int index = dir.LastIndexOf("/");
                                if (index >= 0)
                                    dir = dir.Substring(0, index); // or index + 1 to keep slash


                                string file = "/" + entry.FullName;
                                Logger.logError("[LibsCheck]", $"Exctract part: {entry.FullName}");
                                Logger.logError("[LibsCheck]", $"Exctract dir: {dir}");

                                if (File.Exists($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}\\{entry.FullName}"))
                                {
                                    File.Delete($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}\\{entry.FullName}");
                                }
                                if (entry.FullName.EndsWith("/"))
                                {
                                    Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}\\{entry.FullName}");
                                }
                                else
                                {
                                    entry.ExtractToFile($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}\\{entry.FullName}");
                                }
                            }
                        }
                        /*string zipPath = $"{Globals.currentPath}\\.codexipsa\\libs\\{libs.name}";
                        string extractPath = $"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}";
                        ZipFile.ExtractToDirectory(zipPath, extractPath);*/
                    }
                }
                Logger.logMessage("[LibsCheck]", $"Done");
                isDone = true;
            }
        }
    }
}
