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

            Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", versionName), $"{Globals.dataPath}\\data\\json\\{versionName}.json");

            string manifestJson = File.ReadAllText(launchJsonPath);
            var vi = JsonConvert.DeserializeObject<VersionInfo>(manifestJson);

            MSAuth.onGameStart(false);


            if (vi.assets.url != "")
            {
                AssetIndex.start(vi.assets.url, vi.assets.name);
            }

            string jars = "";
            if (!File.Exists($"{Globals.dataPath}\\versions\\{versionName}.jar"))
                Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\{versionName}.jar");
            jars += $"\"{Globals.dataPath}\\versions\\{versionName}.jar\";";

            if (Directory.Exists($"{Globals.dataPath}\\libs\\natives"))
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

            string javaPath = "***REMOVED***"; //temp

            string[] defRes = vi.defRes.Split(' ');

            string assetsDir = "";
            if (vi.assets.name == "legacy")
                assetsDir = $"{Globals.dataPath}\\assets\\virtual\\{vi.assets.name}";
            else
                assetsDir = $"{Globals.dataPath}\\assets";

            vi.cmdAft = vi.cmdAft.Replace("{game}", vi.game)
                .Replace("{version}", vi.version)
                .Replace("{playerName}", msPlayerName)
                .Replace("{accessToken}", msPlayerAccessToken)
                .Replace("{uuid}", msPlayerUUID)
                .Replace("{width}", defRes[0]) //todo customize
                .Replace("{height}", defRes[1]) //todo customize
                .Replace("{workDir}", $"\"{Globals.dataPath}\\instance\\{profileName}\"")
                .Replace("{gameDir}", $"\"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\"")
                .Replace("{assetDir}", $"\"{assetsDir}\"")
                .Replace("{assetName}", $"\"{vi.assets.name}\"");

            Process proc = new Process();
            proc.OutputDataReceived += OnOutputDataReceived;
            proc.ErrorDataReceived += OnErrorDataReceived;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");
            proc.StartInfo.WorkingDirectory = $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\"; 
            proc.StartInfo.FileName = "\"C:\\Program Files\\Eclipse Adoptium\\jdk-8.0.362.9-hotspot\\bin\\java.exe\""; //java.exe
            proc.StartInfo.Arguments = $"-Djava.library.path=\"{Globals.dataPath}\\libs\\natives\" -cp {jars} {vi.classpath} {vi.cmdAft}";

            Logger.Info("JavaLauncher", $"{proc.StartInfo.FileName} {proc.StartInfo.Arguments}");

            string tempAppdata = Environment.GetEnvironmentVariable("Appdata");
            Environment.SetEnvironmentVariable("Appdata", $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");
            try
            {
                proc.Start();
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                Logger.Error("JavaLauncher", "Could not find java!");
                if (!File.Exists($"{Globals.dataPath}\\data\\jre\\bin\\java.exe"))
                    DownloadJava.Start();

                proc.StartInfo.FileName = $"{Globals.dataPath}\\data\\jre\\bin\\java.exe";
                proc.Start();
            }

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
        public VersionInfoAssets assets { get; set; }
        public VersionInfoLibrary[] libraries { get; set; }
    }

    public class VersionInfoLibrary
    {
        public string name { get; set; }
        public string url { get; set; }
        public int size { get; set; }
        public bool extract { get; set; }
    }

    public class VersionInfoAssets
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
