using MCLauncher.forms;
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

        public static string srvIP = "";
        public static string srvPort = "";

        public static void Launch(string profileName)
        {
            string data = Globals.client.DownloadString($"{Globals.dataPath}\\instance\\{profileName}\\instance.json");
            var dj = JsonConvert.DeserializeObject<ProfileInfo>(data);

            Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", dj.version), $"{Globals.dataPath}\\data\\json\\{dj.version}.json");

            string manifestJson = File.ReadAllText($"{Globals.dataPath}\\data\\json\\{dj.version}.json"); //todo: custom launch json
            var vi = JsonConvert.DeserializeObject<VersionInfo>(manifestJson);

            if (vi.srvJoin == true)
            {
                EnterIp ei = new EnterIp();
                ei.ShowDialog();

                if (EnterIp.inputedText != String.Empty || EnterIp.inputedText != null)
                {
                    MSAuth.onGameStart(true);
                }
            }
            else
                MSAuth.onGameStart(false);

            if (vi.assets.url != "")
            {
                AssetIndex.Start(vi.assets.url, vi.assets.name);
            }

            string jars = "";
            if (!File.Exists($"{Globals.dataPath}\\versions\\{dj.version}.jar"))
                Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\{dj.version}.jar");
            jars += $"\"{Globals.dataPath}\\versions\\{dj.version}.jar\";";

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

            string[] defRes = dj.resolution.Split(' ');

            string assetsDir = "";
            if (vi.assets.name == "legacy")
                assetsDir = $"{Globals.dataPath}\\assets\\virtual\\{vi.assets.name}";
            else
                assetsDir = $"{Globals.dataPath}\\assets";

            string workDir = $"{Globals.dataPath}\\instance\\{profileName}";
            if (!string.IsNullOrWhiteSpace(dj.directory) && !string.IsNullOrEmpty(dj.directory))
                workDir = dj.directory;

            vi.cmdAft = vi.cmdAft.Replace("{game}", vi.game)
                .Replace("{version}", vi.version)
                .Replace("{playerName}", msPlayerName)
                .Replace("{accessToken}", msPlayerAccessToken)
                .Replace("{uuid}", msPlayerUUID)
                .Replace("{width}", defRes[0])
                .Replace("{height}", defRes[1])
                .Replace("{workDir}", $"\"{workDir}\"")
                .Replace("{gameDir}", $"\"{workDir}\\.minecraft\"")
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
            proc.StartInfo.WorkingDirectory = $"{Globals.dataPath}\\instance\\{profileName}\\";
            proc.StartInfo.FileName = "java.exe"; //java.exe

            string[] ram = dj.memory.Split(' ');

            proc.StartInfo.Arguments = $"-Xmx{ram[0]}M -Xms{ram[1]}M ";

            if (vi.cmdBef != "" && dj.proxy == true)
                proc.StartInfo.Arguments += $"{vi.cmdBef} ";
            if (dj.befCmd != "")
                proc.StartInfo.Arguments += $"{dj.befCmd} ";


            if (vi.logging != "")
            {
                Directory.CreateDirectory($"{Globals.dataPath}\\libs\\logging\\");
                string fileName = vi.logging.Substring(vi.logging.LastIndexOf('/') + 1);
                string hash = vi.logging.Substring(0, vi.logging.LastIndexOf('/') - 1);
                hash = hash.Substring(hash.LastIndexOf('/') + 1);
                Globals.client.DownloadFile(vi.logging, $"{Globals.dataPath}\\libs\\logging\\{fileName}");
                proc.StartInfo.Arguments += $"-Dlog4j.configurationFile=\"{Globals.dataPath}\\libs\\logging\\{fileName}\" ";
            }

            if(srvIP != "")
            {
                proc.StartInfo.Arguments += $"-Dserver=\"{srvIP}\" -Dport=\"{srvPort}\" -Dmppass=\"{msPlayerMPPass}\" ";
                Logger.Info("JavaLauncher", $"Server active!");
            }

            proc.StartInfo.Arguments += $"-Djava.library.path=\"{Globals.dataPath}\\libs\\natives\" -cp {jars} {vi.classpath} {vi.cmdAft}";

            if(dj.aftCmd != "")
                proc.StartInfo.Arguments += $" {dj.aftCmd}";
            if (dj.demo)
                proc.StartInfo.Arguments += " --demo";

            Logger.Info("JavaLauncher", $"{proc.StartInfo.FileName} {proc.StartInfo.Arguments}");

            string tempAppdata = Environment.GetEnvironmentVariable("Appdata");
            Environment.SetEnvironmentVariable("Appdata", $"{Globals.dataPath}\\instance\\{profileName}\\");
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
        public string logging { get; set; }
        public bool srvJoin { get; set; }
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
