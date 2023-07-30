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
using System.Windows.Forms;

namespace MCLauncher.classes
{
    internal class JavaLauncher
    {
        public static string msPlayerName;
        public static string msPlayerUUID;
        public static string msPlayerAccessToken;
        public static string msPlayerMPPass;

        public static string modClientPath = "";
        public static string modVersion = "";

        public static string srvIP = "";
        public static string srvPort = "";

        public static string manifestPath = "";

        public static void Launch(string profileName)
        {
            string data = File.ReadAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json");
            var dj = JsonConvert.DeserializeObject<ProfileInfo>(data);

            try
            {
                Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", dj.version), $"{Globals.dataPath}\\data\\json\\{dj.version}.json");
            }
            catch (System.Net.WebException)
            {
                Logger.Error("[JavaLauncher]", "Could not (re)download version JSON.");
                if (!File.Exists($"{Globals.dataPath}\\data\\json\\{dj.version}.json"))
                    return;
            }

            manifestPath = $"{Globals.dataPath}\\data\\json\\{dj.version}.json";
            modClientPath = "";
            JavaModHelper.Start(profileName, $"{Globals.dataPath}\\data\\json\\{dj.version}.json");

            //todo move this after downloading jar
            if (!File.Exists($"{Globals.dataPath}\\data\\downloaded.json") && Profile.lastSelected != "")
            {
                string toAdd = $"[\n";
                toAdd += $"  {{\n";
                toAdd += $"    \"id\": \"{Profile.lastSelected}\",\n";
                toAdd += $"    \"alt\": \"{Profile.lastAlt}\",\n";
                toAdd += $"    \"type\": \"{Profile.lastType}\",\n";
                toAdd += $"    \"released\": \"{Profile.lastDate}\"\n";
                toAdd += $"  }}\n";
                toAdd += $"]";
                File.WriteAllText($"{Globals.dataPath}\\data\\downloaded.json", toAdd);
            }
            else if (Profile.lastSelected != "")
            {
                string toAdd = $"  {{\n";
                toAdd += $"    \"id\": \"{Profile.lastSelected}\",\n";
                toAdd += $"    \"alt\": \"{Profile.lastAlt}\",\n";
                toAdd += $"    \"type\": \"{Profile.lastType}\",\n";
                toAdd += $"    \"released\": \"{Profile.lastDate}\"\n";
                toAdd += $"  }},";
                string existing = File.ReadAllText($"{Globals.dataPath}\\data\\downloaded.json");
                if (!existing.Contains(toAdd))
                {
                    string newStr = toAdd;
                    newStr += existing.Replace("[", "").Replace("]", "");
                    File.WriteAllText($"{Globals.dataPath}\\data\\downloaded.json", $"[\n{newStr}]");
                }
            }

            if (dj.useJson && !String.IsNullOrWhiteSpace(dj.jsonPath))
                manifestPath = dj.jsonPath;

            string manifestJson = File.ReadAllText(manifestPath);
            var vi = JsonConvert.DeserializeObject<VersionInfo>(manifestJson);

            if (vi.srvJoin == true || dj.multiplayer == true)
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
                //AssetIndex.Start(vi.assets.url, vi.assets.name);
                AssetsDownloader ad = new AssetsDownloader(vi.assets.url, vi.assets.name);
                ad.ShowDialog();
            }

            string jars = "";
            if (!File.Exists($"{Globals.dataPath}\\versions\\java\\{dj.version}.jar"))
                Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\java\\{dj.version}.jar");

            Logger.Info("[Javalauncher]", $"Mod path: {modClientPath}");

            if (modClientPath != "")
                jars += $"\"{modClientPath}\";";
            else
                jars += $"\"{Globals.dataPath}\\versions\\java\\{dj.version}.jar\";";

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

            vi.cmdBef = vi.cmdBef.Replace("{assetDir}", $"\"{assetsDir}/\"").Replace("\\", "/")
                .Replace("{assetName}", $"\"{Globals.dataPath}\\assets\\indexes\\{vi.assets.name}.json\"").Replace("\\", "/")
                .Replace("{uuid}", msPlayerUUID)
                .Replace("{workDir}", $"\"{workDir}\"")
                .Replace("{game}", $"\"{vi.game}\"")
                .Replace("{version}", $"\"{vi.version}\"");

            if (vi.supplement != null)
            {
                foreach (var sup in vi.supplement)
                {
                    string supPath = sup.path.Replace("{gameDir}", $"{workDir}\\.minecraft");
                    if (!File.Exists(supPath + sup.name) || sup.renew)
                    {
                        Logger.Info("[JavaLauncher]", $"Downloading supplement {sup.name}...");
                        Directory.CreateDirectory(supPath);
                        Globals.client.DownloadFile(sup.url, supPath + sup.name);
                    }
                }
            }

            if (dj.offline)
                vi.cmdAft = vi.cmdAft.Replace(msPlayerAccessToken, "-").Replace(msPlayerUUID, "-");

            Process proc = new Process();
            proc.EnableRaisingEvents = true;
            proc.OutputDataReceived += OnOutputDataReceived;
            proc.ErrorDataReceived += OnErrorDataReceived;
            proc.Exited += OnProcessExited;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");
            proc.StartInfo.WorkingDirectory = $"{Globals.dataPath}\\instance\\{profileName}\\";
            if (dj.useJava)
                proc.StartInfo.FileName = dj.javaPath;
            else
                proc.StartInfo.FileName = "java.exe";

            string[] ram = dj.memory.Split(' ');

            proc.StartInfo.Arguments = $"-Xmx{ram[0]}M -Xms{ram[1]}M ";

            if (vi.cmdBef != "" && dj.disProxy == false)
                proc.StartInfo.Arguments += $"{vi.cmdBef.Replace("{gameDir}", $"{workDir}\\.minecraft").Replace("{libsDir}", $"{Globals.dataPath}\\libs")} ";
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

            if (srvIP != "")
            {
                if (dj.offline)
                    msPlayerMPPass = "-";
                proc.StartInfo.Arguments += $"-Dserver=\"{srvIP}\" -Dport=\"{srvPort}\" -Dmppass=\"{msPlayerMPPass}\" ";
                Logger.Info("[JavaLauncher]", $"Server active!");
            }

            string classpath = vi.classpath;
            if (dj.useClass)
                classpath = dj.classpath;

            proc.StartInfo.Arguments += $"-Djava.library.path=\"{Globals.dataPath}\\libs\\natives\" -cp {jars} {classpath} {vi.cmdAft}";

            if (dj.aftCmd != "")
                proc.StartInfo.Arguments += $" {dj.aftCmd}";
            if (dj.demo)
                proc.StartInfo.Arguments += " --demo";

            Logger.Info("[JavaLauncher]", $"{proc.StartInfo.FileName} {proc.StartInfo.Arguments}");

            string tempAppdata = Environment.GetEnvironmentVariable("Appdata");
            Environment.SetEnvironmentVariable("Appdata", $"{Globals.dataPath}\\instance\\{profileName}\\");
            try
            {
                Discord.ChangeMessage($"Playing {vi.game} ({vi.version})");
                proc.Start();
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                Logger.Error("[JavaLauncher]", "Could not find java!");
                if (!File.Exists($"{Globals.dataPath}\\data\\jre\\bin\\java.exe"))
                    DownloadJava.Start();

                proc.StartInfo.FileName = $"{Globals.dataPath}\\data\\jre\\bin\\java.exe";
                proc.StartInfo.WorkingDirectory = $"\"{workDir}\\.minecraft\"";
                Discord.ChangeMessage($"Playing {vi.game} ({vi.version})");
                proc.Start();
            }

            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();

            Environment.SetEnvironmentVariable("Appdata", tempAppdata);
        }

        private static void OnProcessExited(object sender, EventArgs e)
        {
            Discord.ChangeMessage($"Idling");
        }

        static void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                Logger.GameInfo(e.Data);
            }
        }

        static void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                Logger.GameError(e.Data);
            }
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
        public VersionInfoSupplement[] supplement { get; set; }
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

    public class VersionInfoSupplement
    {
        public string url { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public bool renew { get; set; }
    }
}
