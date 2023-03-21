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
        public static string msPlayerName;
        public static string msPlayerUUID;
        public static string msPlayerAccessToken;
        public static string msPlayerMPPass;

        public static void Launch(string profileName, string launchJsonPath, string versionName)
        {
            Logger.Info("JavaLauncher/Launch", "");

            string manifestJson = File.ReadAllText(launchJsonPath);
            var vi = JsonConvert.DeserializeObject<VersionInfo>(manifestJson);

            MSAuth.onGameStart(false);

            string jars = "";
            if(!File.Exists($"{Globals.dataPath}\\versions\\{versionName}.jar"))
                Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\{versionName}.jar");
            jars += $"\"{Globals.dataPath}\\versions\\{versionName}.jar\";";

            Directory.Delete($"{Globals.dataPath}\\libs\\natives", true);

            foreach (var lib in vi.libraries)
            {
                string[] split = lib.name.Split(':');
                jars += $"\"{Globals.dataPath}\\libs\\{split[1]}-{split[2]}.jar\";";

                if (!File.Exists($"{Globals.dataPath}\\libs\\{split[1]}-{split[2]}.jar"))
                {
                    Globals.client.DownloadFile(lib.url, $"{Globals.dataPath}\\libs\\{split[1]}-{split[2]}.jar");
                }

                if (lib.extract == true)
                {
                    ZipFile.ExtractToDirectory($"{Globals.dataPath}\\libs\\{split[1]}-{split[2]}.jar", $"{Globals.dataPath}\\libs\\natives");
                }
            }
            jars = jars.Remove(jars.LastIndexOf(';'));
            string javaPath = "\"C:\\Program Files\\Eclipse Adoptium\\jdk-8.0.362.9-hotspot\\bin\\java.exe\""; //temp

            string[] defRes = vi.defRes.Split(' ');

            vi.cmdAft = vi.cmdAft.Replace("{game}", vi.game)
                .Replace("{version}", vi.version)
                .Replace("{playerName}", HomeScreen.msPlayerName)
                .Replace("{accessToken}", "")
                .Replace("{uuid}", "")
                .Replace("{width}", defRes[0]) //todo customize
                .Replace("{height}", defRes[1]) //todo customize
                .Replace("{workDir}", $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");

            Process proc = new Process();
            proc.OutputDataReceived += OnOutputDataReceived;
            proc.ErrorDataReceived += OnErrorDataReceived;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");
            proc.StartInfo.WorkingDirectory = $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\"; //todo
            proc.StartInfo.FileName = javaPath;
            proc.StartInfo.Arguments = $"{vi.cmdBef} -Djava.library.path=\"{Globals.dataPath}\\libs\\natives\" -cp {jars} {vi.classpath} {vi.cmdAft}";

            string tempAppdata = Environment.GetEnvironmentVariable("Appdata");
            Environment.SetEnvironmentVariable("Appdata", $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");
            proc.Start();
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();

            Environment.SetEnvironmentVariable("Appdata", tempAppdata);
        }

        static void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(e.Data);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Data);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    public class VersionInfo
    {
        public string game { get; set; }
        public string version { get; set; }
        public string url { get; set; }
        public int size { get; set; }
        public int java { get; set; }
        public string classpath { get; set; }
        public string cmdBef { get; set; }
        public string cmdAft { get; set; }
        public string defRes { get; set; }
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
