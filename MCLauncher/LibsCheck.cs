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
            Logger.Info("[LibsCheck]", $"Starting LibsCheck");
            libsList.Clear();
            //string url = $"http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libraries-{type}.json";
            string url = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{Globals.codebase}/ver-libs/{type}.json"; //THIS IS FOR THE MAJOR LIBRARIES + VER JSON MERGE
            Logger.Info("[LibsCheck]", $"Type: {type}");
            Logger.Info("[LibsCheck]", $"Url: {url}");

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                List<LibsJson> data = JsonConvert.DeserializeObject<List<LibsJson>>(json);

                //delete natives
                DirectoryInfo di = new DirectoryInfo($"{Globals.currentPath}\\.codexipsa\\libs\\natives\\");
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
                    string savePath;

                    if(libs.extract == "null" && !libs.name.Contains("{gameDir}"))
                    {
                        //Add names to a list for LaunchJava - this is here so natives don't get added to the list
                        libsList.Add(libs.name);
                    }

                    //Download required libraries
                    if(libs.name.StartsWith("{gameDir}"))
                    {
                        Directory.CreateDirectory($"{LaunchJava.gameDir}\\lib");
                        savePath = libs.name.Replace("{gameDir}", LaunchJava.gameDir);
                    }
                    else
                    {
                        savePath = $"{Globals.currentPath}\\.codexipsa\\libs\\{libs.name}";
                    }
                    Console.WriteLine(savePath);
                    if (!File.Exists(savePath))
                    {
                        if (Globals.isDebug)
                        {
                            Logger.Info("[LibsCheck]", $"Downloading {libs.link} {savePath}");
                        }
                        DownloadProgress.url = libs.link;
                        DownloadProgress.savePath = savePath;
                        DownloadProgress download = new DownloadProgress();
                        download.ShowDialog();
                    }

                    if (libs.extract != "null")
                    {
                        //TODO: get rid of this
                        Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}");
                        using (ZipArchive archive = ZipFile.OpenRead(savePath))
                        {
                            //TODO: if they don't exist, extract/replace them
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                string dir = "/" + entry.ToString();
                                int index = dir.LastIndexOf("/");
                                if (index >= 0)
                                    dir = dir.Substring(0, index); // or index + 1 to keep slash


                                string file = "/" + entry.FullName;
                                if(Globals.isDebug)
                                {
                                    Logger.Info("[LibsCheck]", $"Exctract part: {entry.FullName}");
                                    Logger.Info("[LibsCheck]", $"Exctract dir: {dir}");

                                }
                                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\libs\\{libs.extract}\\META-INF\\");

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
                    }
                }
                Logger.Info("[LibsCheck]", $"Done");
                isDone = true;
            }
        }
    }
}
