using MCLauncher.forms;
using MCLauncher.json.api;
using MCLauncher.json.launcher;
using MCLauncher.launchers;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace MCLauncher.classes
{
    internal class JavaLauncher
    {
        //TODO
        //Possibly rewrite all of this shit
        public static string msPlayerName;
        public static string msPlayerUUID;
        public static string msPlayerAccessToken;

        public static string manifestPath = "";

        public static string runID = "";

        public static void Launch(string profileName)
        {
            //create dir
            Directory.CreateDirectory($"{Globals.dataPath}\\versions\\java\\");

            //check if profile is already running
            if (Globals.running.ContainsValue(profileName))
            {
                DialogResult result = MessageBox.Show(Strings.sj.wrnRunning.Replace("{profileName}", profileName), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            runID = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            Globals.running.Add(runID, profileName);

            //get InstanceJson
            string data = File.ReadAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json");
            InstanceJson ij = JsonConvert.DeserializeObject<InstanceJson>(data);

            //get latest versions if asked for
            String version = ij.version;
            if (version.Contains("latest"))
            {
                version = HomeScreen.getLatestVersion(version);
            }

            //get VersionJson
            if (!Globals.offlineMode)
            {
                try
                {
                    Globals.client.DownloadFile(Globals.javaInfo.Replace("{type}", ij.edition).Replace("{ver}", version), $"{Globals.dataPath}\\data\\json\\{version}.json");
                }
                catch (System.Net.WebException)
                {
                    Logger.Error("[JavaLauncher]", "Could not (re)download version JSON: " + Globals.javaInfo.Replace("{type}", ij.edition).Replace("{ver}", version));
                    if (!File.Exists($"{Globals.dataPath}\\data\\json\\{version}.json"))
                        return;
                }
            }

            manifestPath = $"{Globals.dataPath}\\data\\json\\{version}.json";

            //set manifestPath to modmanifest if mods use it
            String modManifest = ModWorker.getModManifest(profileName);
            if (modManifest != null)
                manifestPath = modManifest;

            //set manifestPath to a custom JSON if user wants it
            if (ij.useJson && !String.IsNullOrWhiteSpace(ij.jsonPath))
            {
                manifestPath = ij.jsonPath;

                if (manifestPath.Contains("http"))
                {
                    string fileName = manifestPath.Substring(manifestPath.LastIndexOf('/') + 1).Replace(".json", "");
                    Globals.client.DownloadFile(manifestPath, $"{Globals.dataPath}\\data\\json\\{fileName}.json");
                    manifestPath = $"{Globals.dataPath}\\data\\json\\{fileName}.json";
                }
            }

            //deserialize VersionJson
            Logger.Info("[JavaLauncher]", $"manifestPath: {manifestPath}");
            string manifestJson = File.ReadAllText(manifestPath);
            VersionJson vj = JsonConvert.DeserializeObject<VersionJson>(manifestJson);

            //get ip and port for mppass (if wanted)
            String[] ipPort = null;
            if (ij.useServerIP)
            {
                ipPort = LaunchJava.splitIpPort(ij.serverIP);
            }
            else if (vj.srvJoin == true || ij.multiplayer == true)
            {
                EnterIp ei = new EnterIp();
                ei.ShowDialog();

                if (EnterIp.inputText != null && EnterIp.inputText != String.Empty)
                {
                    ipPort = LaunchJava.splitIpPort(EnterIp.inputText);
                }
            }

            //download game jar
            if (!File.Exists($"{Globals.dataPath}\\versions\\java\\{version}.jar"))
                Globals.client.DownloadFile(vj.url, $"{Globals.dataPath}\\versions\\java\\{version}.jar");

            //create mod patch and info
            var modInfo = ModWorker.createJarPatch(profileName);
            String modClientPath = modInfo.Item1;
            String modName = modInfo.Item2;
            String modVersion = modInfo.Item3;

            if (!Globals.offlineMode)
            {
                if (ij.useAssets == true && ij.assetsPath != null)
                {
                    vj.assets.url = ij.assetsPath;
                    vj.assets.name = ij.assetsPath.Substring(ij.assetsPath.LastIndexOf('/') + 1).Replace(".json", "");

                    if (!vj.assets.url.Contains("http"))
                    {
                        vj.assets.url = "file:///" + vj.assets.url;
                        vj.assets.name = ij.assetsPath.Substring(ij.assetsPath.LastIndexOf('\\') + 1).Replace(".json", "");
                    }

                    AssetsDownloader ad = new AssetsDownloader(vj.assets.url, vj.assets.name);
                    ad.ShowDialog();
                }
                else if (vj.assets != null && !String.IsNullOrWhiteSpace(vj.assets.name))
                {
                    AssetsDownloader ad = new AssetsDownloader(vj.assets.url, vj.assets.name);
                    ad.ShowDialog();
                }
            }

            //yes I know this is a shitty fix but nothing better I can do till lf releases
            if (vj.assetsVirt)
            {
                Logger.Error("[JavaLauncher]", "Copying assets... (fix for 1.6 snapshots)");

                Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\");

                foreach (string dirPath in Directory.GetDirectories($"{Globals.dataPath}\\assets\\virtual\\{vj.assets.name}\\", "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace($"{Globals.dataPath}\\assets\\virtual\\{vj.assets.name}\\", $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\"));
                }

                foreach (string newPath in Directory.GetFiles($"{Globals.dataPath}\\assets\\virtual\\{vj.assets.name}\\", "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace($"{Globals.dataPath}\\assets\\virtual\\{vj.assets.name}\\", $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\"), true);
                }

                File.Delete($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\pack.mcmeta");
                File.Delete($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\READ_ME_I_AM_VERY_IMPORTANT.txt");
                File.Delete($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\sounds.json");
            }

            string jars = "";

            Logger.Info("[Javalauncher]", $"Mod path: {modClientPath}");

            if (modClientPath != null)
                jars += $"\"{modClientPath}\";";
            else
                jars += $"\"{Globals.dataPath}\\versions\\java\\{version}.jar\";";

            string[] oldNatives = Directory.GetDirectories($"{Globals.dataPath}\\libs\\", "*", SearchOption.TopDirectoryOnly);
            foreach (string oldNative in oldNatives)
            {
                string dir = oldNative.Replace($"{Globals.dataPath}\\libs\\", "");
                if (dir.StartsWith("natives") && dir.Contains("-"))
                {
                    string timestamp = dir.Substring(dir.IndexOf("-") + 1);
                    if (!Globals.running.ContainsKey(timestamp))
                    {
                        try
                        {
                            Directory.Delete($"{Globals.dataPath}\\libs\\natives-{timestamp}", true);
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            Logger.Error("[JavaLauncher]", $"Could not delete natives dir natives-{timestamp}");
                        }
                    }
                }
            }
            Directory.CreateDirectory($"{Globals.dataPath}\\libs\\natives-{runID}\\");

            foreach (var lib in vj.libraries)
            {
                if (!File.Exists($"{Globals.dataPath}\\libs\\{lib.name}.jar"))
                {
                    Globals.client.DownloadFile(lib.url, $"{Globals.dataPath}\\libs\\{lib.name}.jar");
                }
                else
                {
                    //TODO check against actual filesizes, this will do for now:tm:
                    FileInfo fi = new FileInfo($"{Globals.dataPath}\\libs\\{lib.name}.jar");
                    if (fi.Length == 0)
                    {
                        //delete and redownload
                        File.Delete($"{Globals.dataPath}\\libs\\{lib.name}.jar");
                        Globals.client.DownloadFile(lib.url, $"{Globals.dataPath}\\libs\\{lib.name}.jar");
                    }
                }

                if (lib.extract == true)
                {
                    var archive = ZipFile.OpenRead($"{Globals.dataPath}\\libs\\{lib.name}.jar");
                    foreach (var zipArchiveEntry in archive.Entries)
                    {
                        if (!zipArchiveEntry.ToString().Contains("META-INF"))
                        {
                            if (zipArchiveEntry.ToString().EndsWith("/"))
                                Directory.CreateDirectory($"{Globals.dataPath}\\libs\\natives-{runID}\\{zipArchiveEntry}");
                            else
                                zipArchiveEntry.ExtractToFile($"{Globals.dataPath}\\libs\\natives-{runID}\\{zipArchiveEntry}");
                        }
                    }
                }
                else
                    jars += $"\"{Globals.dataPath}\\libs\\{lib.name}.jar\";";
            }
            jars = jars.Remove(jars.LastIndexOf(';'));

            string[] defRes = ij.resolution.Split(' ');

            if (vj.assets == null)
            {
                vj.assets = new VersionJsonAssets();
                vj.assets.name = "";
            }

            string assetsDir = "";
            if (vj.assets.name == "legacy")
                assetsDir = $"{Globals.dataPath}\\assets\\virtual\\{vj.assets.name}";
            else
                assetsDir = $"{Globals.dataPath}\\assets";

            string workDir = $"{Globals.dataPath}\\instance\\{profileName}";
            if (!string.IsNullOrWhiteSpace(ij.directory) && !string.IsNullOrEmpty(ij.directory))
                workDir = ij.directory;

            if (modVersion != null)
            {
                vj.game = modName;
                vj.version = modVersion;
            }

            vj.cmdAft = vj.cmdAft.Replace("{game}", vj.game)
                .Replace("{version}", vj.version)
                .Replace("{playerName}", msPlayerName)
                .Replace("{accessToken}", msPlayerAccessToken)
                .Replace("{uuid}", msPlayerUUID)
                .Replace("{width}", defRes[0])
                .Replace("{height}", defRes[1])
                .Replace("{workDir}", $"\"{workDir}\"")
                .Replace("{gameDir}", $"\"{workDir}\\.minecraft\"")
                .Replace("{assetDir}", $"\"{assetsDir}\"")
                .Replace("{assetName}", $"\"{vj.assets.name}\"");

            vj.cmdBef = vj.cmdBef.Replace("{assetDir}", $"\"{assetsDir}/\"").Replace("\\", "/")
                .Replace("{assetName}", $"\"{Globals.dataPath}\\assets\\indexes\\{vj.assets.name}.json\"").Replace("\\", "/")
                .Replace("{uuid}", msPlayerUUID)
                .Replace("{workDir}", $"\"{workDir}\"")
                .Replace("{game}", $"\"{vj.game}\"")
                .Replace("{version}", $"\"{vj.version}\"")
                .Replace("{libDir}", $"\"{Globals.dataPath}\\libs\"");

            if (!Globals.offlineMode)
            {
                if (vj.supplement != null)
                {
                    foreach (var sup in vj.supplement)
                    {
                        string supPath = sup.path.Replace("{gameDir}", $"{workDir}\\.minecraft");
                        if (!File.Exists(supPath + sup.name) || sup.renew)
                        {
                            Logger.Info("[JavaLauncher]", $"Downloading supplement {sup.name}...");
                            Directory.CreateDirectory(supPath);
                            Globals.client.DownloadFile(sup.url, supPath + sup.name);
                        }

                        if (sup.extract == true)
                        {
                            ModWorker.extractZip(supPath + sup.name, supPath);
                            //ZipFile.ExtractToDirectory(supPath + sup.name, supPath);
                        }
                    }
                }
            }

            if (ij.offline)
                vj.cmdAft = vj.cmdAft.Replace(msPlayerAccessToken, "-").Replace(msPlayerUUID, "-");

            Process proc = new Process();
            proc.EnableRaisingEvents = true;
            proc.OutputDataReceived += OnOutputDataReceived;
            proc.ErrorDataReceived += OnErrorDataReceived;
            proc.Exited += (sender, e) => HomeScreen.Instance.lblPlayedFor.Invoke(new System.Action(() => OnProcessExited(sender, e, profileName, vj.assetsVirt, proc))); //lmao this is dumb shit (but it works)
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");
            proc.StartInfo.WorkingDirectory = $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\";
            if (ij.useJava)
                proc.StartInfo.FileName = ij.javaPath;
            else if (vj.java <= 8)
                proc.StartInfo.FileName = Settings.sj.jre8;
            else if (vj.java <= 17)
                proc.StartInfo.FileName = Settings.sj.jre17;
            else if (vj.java <= 21)
                proc.StartInfo.FileName = Settings.sj.jre21;
            else
                proc.StartInfo.FileName = "java.exe";

            string[] ram = ij.memory.Split(' ');

            proc.StartInfo.Arguments = $"-Xms{ram[1]}M -Xmx{ram[0]}M ";

            if (vj.cmdBef != "" && ij.disProxy == false)
                proc.StartInfo.Arguments += $"{vj.cmdBef.Replace("{gameDir}", $"{workDir}\\.minecraft").Replace("{libsDir}", $"{Globals.dataPath}\\libs")} ";
            if (ij.befCmd != "")
                proc.StartInfo.Arguments += $"{ij.befCmd} ";


            if (vj.logging != "")
            {
                Directory.CreateDirectory($"{Globals.dataPath}\\libs\\logging\\");
                string fileName = vj.logging.Substring(vj.logging.LastIndexOf('/') + 1);
                string hash = vj.logging.Substring(0, vj.logging.LastIndexOf('/') - 1);
                hash = hash.Substring(hash.LastIndexOf('/') + 1);
                if (!Globals.offlineMode)
                    Globals.client.DownloadFile(vj.logging, $"{Globals.dataPath}\\libs\\logging\\{fileName}");
                proc.StartInfo.Arguments += $"-Dlog4j.configurationFile=\"{Globals.dataPath}\\libs\\logging\\{fileName}\" ";
            }

            Logger.Info("[JavaLauncher]", $"ipPort: {ipPort}");
            if (ipPort != null)
            {
                if (!ij.offline)
                {
                    MSAuth.onServerJoin(ipPort[0], ipPort[1], msPlayerAccessToken, msPlayerUUID);
                    proc.StartInfo.Arguments += $"-Dserver=\"{ipPort[0]}\" -Dport=\"{ipPort[1]}\" -Dmppass=\"0\" ";
                    Logger.Info("[JavaLauncher]", $"Server active!");
                }
            }

            string classpath = vj.classpath;
            if (ij.useClass)
                classpath = ij.classpath;

            proc.StartInfo.Arguments += $"-Djava.library.path=\"{Globals.dataPath}\\libs\\natives-{runID}\" -cp {jars} {classpath} {vj.cmdAft}";

            if (ij.aftCmd != "")
                proc.StartInfo.Arguments += $" {ij.aftCmd}";
            if (ij.demo)
                proc.StartInfo.Arguments += " --demo";

            Logger.Info("[JavaLauncher]", $"{proc.StartInfo.FileName} {proc.StartInfo.Arguments}");

            string tempAppdata = Environment.GetEnvironmentVariable("Appdata");
            Environment.SetEnvironmentVariable("Appdata", $"{Globals.dataPath}\\instance\\{profileName}\\");

            try
            {
                Discord.ChangeMessage($"Playing {vj.game} ({vj.version})");
                proc.Start();
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                Logger.Error("[JavaLauncher]", "Could not find java!");
                Environment.SetEnvironmentVariable("Appdata", tempAppdata);

                Discord.ChangeMessage($"Idling");
                Globals.running.Remove(runID);
                return;
                //TODO = ASK TO DOWNLOAD JAVA

                /*if (!File.Exists($"{Globals.dataPath}\\data\\jre\\bin\\java.exe"))
                    DownloadJava.Start();

                proc.StartInfo.FileName = $"{Globals.dataPath}\\data\\jre\\bin\\java.exe";
                proc.StartInfo.WorkingDirectory = $"\"{workDir}\\.minecraft\"";
                Discord.ChangeMessage($"Playing {vi.game} ({vi.version})");
                proc.Start();*/
            }

            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();

            Environment.SetEnvironmentVariable("Appdata", tempAppdata);
        }

        private static void OnProcessExited(object sender, EventArgs e, string instanceName, bool shouldDelete, Process proc)
        {
            //get runtime
            TimeSpan runtime = DateTime.Now - proc.StartTime;
            long saveRuntime = (long)Math.Round(runtime.TotalMilliseconds, 0);
            Logger.Info("[JavaLauncher]", $"Total runtime for this session: {saveRuntime}");

            //change discord rpc
            Discord.ChangeMessage($"Idling");

            //remove running ID
            Globals.running.Remove(runID);

            //delete assets if wanted
            if (shouldDelete)
                if (Directory.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\.minecraft\\assets\\"))
                    Directory.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\.minecraft\\assets\\", true);

            //save the runtime
            string data = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\instance.json");
            InstanceJson ij = JsonConvert.DeserializeObject<InstanceJson>(data);
            ij.playTime = ij.playTime + (long)saveRuntime;
            String toSave = JsonConvert.SerializeObject(ij);
            File.WriteAllText($"{Globals.dataPath}\\instance\\{instanceName}\\instance.json", toSave);


            //reload played for text
            HomeScreen.Instance.loadPlayTime(instanceName, ij);
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
}
