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
        public static bool isDone = false;
        public static void CheckPre17()
        {
            var libsLink = "http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/libraries-pre1.6.json";

            using (WebClient client = new WebClient())
            {
                string currentPath = Directory.GetCurrentDirectory();

                string json = client.DownloadString(libsLink);
                List<LibsJson> data = JsonConvert.DeserializeObject<List<LibsJson>>(json);

                foreach (var libs in data)
                {
                    //Download required libraries
                    if (!File.Exists($"{currentPath}\\bin\\libs\\{libs.name}"))
                    {
                        DownloadProgress.url = libs.link;
                        DownloadProgress.savePath = $"{currentPath}\\bin\\libs\\{libs.name}";
                        DownloadProgress download = new DownloadProgress();
                        download.ShowDialog();

                        if(libs.extract != "null")
                        {
                            Directory.CreateDirectory($"{currentPath}\\bin\\libs\\{libs.extract}");
                            string zipPath = $"{currentPath}\\bin\\libs\\{libs.name}";
                            string extractPath = $"{currentPath}\\bin\\libs\\{libs.extract}";
                            ZipFile.ExtractToDirectory(zipPath, extractPath);
                        }
                    }
                }
                isDone = true;
            }
        }
    }
}
