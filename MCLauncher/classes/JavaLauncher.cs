using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.classes
{
    internal class JavaLauncher
    {
        public static void Launch(string profileName, string launchJsonPath, string versionName)
        {
            Logger.Info("JavaLauncher/Launch", "");

            string manifestJson = File.ReadAllText(launchJsonPath);
            var vi = JsonConvert.DeserializeObject<VersionInfo>(manifestJson);

            string jars = "";
            if(!File.Exists($"{Globals.dataPath}\\versions\\{versionName}.jar"))
                Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\{versionName}.jar");
            jars += $"\"{Globals.dataPath}\\versions\\{versionName}.jar\";";

            foreach (var lib in vi.libraries)
            {
                string[] split = lib.name.Split(':');
                jars += $"\"{Globals.dataPath}\\libs\\{split[1]}-{split[2]}.jar\";";

                if (!File.Exists($"{Globals.dataPath}\\libs\\{split[1]}-{split[2]}.jar"))
                {
                    Globals.client.DownloadFile(lib.url, $"{Globals.dataPath}\\libs\\{split[1]}-{split[2]}.jar");

                    if (lib.extract == true)
                    {
                        ZipFile.ExtractToDirectory($"{Globals.dataPath}\\libs\\{split[1]}-{split[2]}.jar", $"{Globals.dataPath}\\libs\\natives");
                    }
                }
            }
            jars = jars.Remove(jars.LastIndexOf(';'));  
            string javaPath = "\"C:\\Program Files\\Eclipse Adoptium\\jdk-8.0.362.9-hotspot\\bin\\java.exe\""; //temp

            //Console.WriteLine($"{javaPath} -Djava.library.path=\"{Globals.dataPath}\\libs\\natives\" -cp {jars} {vi.classpath}");
            Process proc = new Process();
            proc.StartInfo.FileName = javaPath;
            proc.StartInfo.Arguments = $"-Djava.library.path=\"{Globals.dataPath}\\libs\\natives\" -cp {jars} {vi.classpath}";
            proc.Start();
        }
    }

    public class VersionInfo
    {
        public string url { get; set; }
        public int size { get; set; }
        public int java { get; set; }
        public string classpath { get; set; }
        public VersionInfoLibrary[] libraries { get; set; }
    }

    public class VersionInfoLibrary
    {
        public string name { get; set; }
        public string url { get; set; }
        public int size { get; set; }
        public bool extract { get; set; }
    }
}
