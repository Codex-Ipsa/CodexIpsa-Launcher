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
            Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", versionName), $"{Globals.dataPath}\\data\\json\\{versionName}.json");

            string manifestJson = File.ReadAllText(launchJsonPath);
            var vi = JsonConvert.DeserializeObject<VersionInfo>(manifestJson);

            MSAuth.onGameStart(false);


            if (vi.assets.url != "")
            {
                AssetIndex.Start(vi.assets.url, vi.assets.name);
            }

            string jars = "";
            if (!File.Exists($"{Globals.dataPath}\\versions\\{versionName}.jar"))
                Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\{versionName}.jar");
            jars += $"\"{Globals.dataPath}\\versions\\{versionName}.jar\";";

            if (Directory.Exists($"{Globals.dataPath}\\libs\\natives"))
                Directory.Delete($"{Globals.dataPath}\\libs\\natives", true);

            Directory.CreateDirectory($"{Globals.dataPath}\\libs\\natives\\");

            foreach (var lib in vi.libraries)
            {
                if (!File.Exists($"{Globals.dataPath}\\libs\\{lib.name}.jar"))
                {
                    Globals.client.DownloadFile(lib.url, $"{Globals.dataPath}\\libs\\{lib.name}.jar");
                }

                if (lib.extract == true)
                {
                    var archive = ZipFile.OpenRead($"{Globals.dataPath}\\libs\\{lib.name}.jar");
                    foreach (var zipArchiveEntry in archive.Entries)
                    {
                        //Console.WriteLine(zipArchiveEntry);
                        if (!zipArchiveEntry.ToString().Contains("META-INF"))
                        {
                            if (zipArchiveEntry.ToString().EndsWith("/"))
                                Directory.CreateDirectory($"{Globals.dataPath}\\libs\\natives\\{zipArchiveEntry}");
                            else
                                zipArchiveEntry.ExtractToFile($"{Globals.dataPath}\\libs\\natives\\{zipArchiveEntry}");
                        }
                    }
                }
                else
                    jars += $"\"{Globals.dataPath}\\libs\\{lib.name}.jar\";";
            }
            jars = jars.Remove(jars.LastIndexOf(';'));

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
            proc.StartInfo.FileName = "java.exe"; //java.exe
            if(vi.cmdBef != "")
                proc.StartInfo.Arguments = $"{vi.cmdBef} ";
            proc.StartInfo.Arguments += $"-Djava.library.path=\"{Globals.dataPath}\\libs\\natives\" -cp {jars} {vi.classpath} {vi.cmdAft}";

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
