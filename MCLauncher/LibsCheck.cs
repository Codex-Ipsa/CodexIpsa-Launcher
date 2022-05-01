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
        
        //For versions before release 1.6
        public static void CheckPre16()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.libsPre16Json);
                List<LibsJson> data = JsonConvert.DeserializeObject<List<LibsJson>>(json);

                foreach (var libs in data)
                {
                    //Download required libraries
                    if (!File.Exists($"{Globals.currentPath}\\bin\\libs\\{libs.name}"))
                    {
                        DownloadProgress.url = libs.link;
                        DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\libs\\{libs.name}";
                        DownloadProgress download = new DownloadProgress();
                        download.ShowDialog();

                        if(libs.extract != "null")
                        {
                            if(Directory.Exists($"{Globals.currentPath}\\bin\\libs\\{libs.extract}"))
                                Directory.Delete($"{Globals.currentPath}\\bin\\libs\\{libs.extract}", true);
                            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\libs\\{libs.extract}");
                            string zipPath = $"{Globals.currentPath}\\bin\\libs\\{libs.name}";
                            string extractPath = $"{Globals.currentPath}\\bin\\libs\\{libs.extract}";
                            ZipFile.ExtractToDirectory(zipPath, extractPath);
                        }
                    }
                }
                isDone = true;
            }
        }
    }
}
