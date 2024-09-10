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
        //Possibly rewrite all of this shit before you're going to make the MMC like selection
        public static string msPlayerName;
        public static string msPlayerUUID;
        public static string msPlayerAccessToken;
        public static string msPlayerMPPass;

        public static string modClientPath = "";
        public static string modVersion = "";
        public static string modName = "";

        public static string manifestPath = "";

        public static string runID = "";

        public static void Launch(string profileName)
        {
            modVersion = "";
            modName = "";

            Directory.CreateDirectory($"{Globals.dataPath}\\versions\\java\\");

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

            string data = File.ReadAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json");
            InstanceJson dj = JsonConvert.DeserializeObject<InstanceJson>(data);

            String version = dj.version;

            if (version.Contains("latest"))
            {
                version = HomeScreen.getLatestVersion(version);
            }

            try
            {
                Globals.client.DownloadFile(Globals.javaInfo.Replace("{type}", dj.edition).Replace("{ver}", version), $"{Globals.dataPath}\\data\\json\\{version}.json");
            }
            catch (System.Net.WebException)
            {
                Logger.Error("[JavaLauncher]", "Could not (re)download version JSON: " + Globals.javaInfo.Replace("{type}", dj.edition).Replace("{ver}", version));
                if (!File.Exists($"{Globals.dataPath}\\data\\json\\{version}.json"))
                    return;
            }

            manifestPath = $"{Globals.dataPath}\\data\\json\\{version}.json";

            /* TEMP START */



            //if (!File.Exists($"{Globals.dataPath}\\versions\\java\\{version}.jar"))
            //    Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\java\\{version}.jar");

            //Console.WriteLine("jarpath: " + ModWorker.getJarPath(profileName));
            //ModWorker.createJarPatch(profileName);

            //return; //TEMP

            /* TEMP END */

            modClientPath = ModWorker.createJarPatch(profileName);

            if (dj.useJson && !String.IsNullOrWhiteSpace(dj.jsonPath))
            {
                manifestPath = dj.jsonPath;

                if (manifestPath.Contains("http"))
                {
                    string fileName = manifestPath.Substring(manifestPath.LastIndexOf('/') + 1).Replace(".json", "");
                    Globals.client.DownloadFile(manifestPath, $"{Globals.dataPath}\\data\\json\\{fileName}.json");
                    manifestPath = $"{Globals.dataPath}\\data\\json\\{fileName}.json";
                }
            }

            string manifestJson = File.ReadAllText(manifestPath);
            VersionJson vi = JsonConvert.DeserializeObject<VersionJson>(manifestJson);


            //get ip and port for mppass (if wanted)
            String[] ipPort = null;
            if (dj.useServerIP)
            {
                ipPort = LaunchJava.splitIpPort(dj.serverIP);
            }
            else if (vi.srvJoin == true || dj.multiplayer == true)
            {
                EnterIp ei = new EnterIp();
                ei.ShowDialog();

                if (EnterIp.inputText != null && EnterIp.inputText != String.Empty)
                {
                    ipPort = LaunchJava.splitIpPort(dj.serverIP);
                }
            }

            //authenticate on game launch
            if (ipPort == null)
            {
                MSAuth.onGameStart(false, null, null);
            }
            else
            {
                MSAuth.onGameStart(true, ipPort[0], ipPort[1]);
            }

            if (dj.useAssets == true && dj.assetsPath != null)
            {
                vi.assets.url = dj.assetsPath;
                vi.assets.name = dj.assetsPath.Substring(dj.assetsPath.LastIndexOf('/') + 1).Replace(".json", "");

                if (!vi.assets.url.Contains("http"))
                {
                    vi.assets.url = "file:///" + vi.assets.url;
                }

                AssetsDownloader ad = new AssetsDownloader(vi.assets.url, vi.assets.name);
                ad.ShowDialog();
            }
            else if (vi.assets != null && !String.IsNullOrWhiteSpace(vi.assets.name))
            {
                AssetsDownloader ad = new AssetsDownloader(vi.assets.url, vi.assets.name);
                ad.ShowDialog();
            }

            //yes I know this is a shitty fix but nothing better I can do till lf releases
            if (vi.assetsVirt)
            {
                Logger.Error("[JavaLauncher]", "Copying assets... (fix for 1.6 snapshots)");

                Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\");

                foreach (string dirPath in Directory.GetDirectories($"{Globals.dataPath}\\assets\\virtual\\{vi.assets.name}\\", "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace($"{Globals.dataPath}\\assets\\virtual\\{vi.assets.name}\\", $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\"));
                }

                foreach (string newPath in Directory.GetFiles($"{Globals.dataPath}\\assets\\virtual\\{vi.assets.name}\\", "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace($"{Globals.dataPath}\\assets\\virtual\\{vi.assets.name}\\", $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\"), true);
                }

                File.Delete($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\pack.mcmeta");
                File.Delete($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\READ_ME_I_AM_VERY_IMPORTANT.txt");
                File.Delete($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\assets\\sounds.json");
            }

            string jars = "";
            if (!File.Exists($"{Globals.dataPath}\\versions\\java\\{version}.jar") && modClientPath == null)
                Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\java\\{version}.jar");

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
                        Directory.Delete($"{Globals.dataPath}\\libs\\natives-{timestamp}", true);
                    }
                }
            }
            Directory.CreateDirectory($"{Globals.dataPath}\\libs\\natives-{runID}\\");

            foreach (var lib in vi.libraries)
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

            string[] defRes = dj.resolution.Split(' ');

            if (vi.assets == null)
            {
                vi.assets = new VersionJsonAssets();
                vi.assets.name = "";
            }

            string assetsDir = "";
            if (vi.assets.name == "legacy")
                assetsDir = $"{Globals.dataPath}\\assets\\virtual\\{vi.assets.name}";
            else
                assetsDir = $"{Globals.dataPath}\\assets";

            string workDir = $"{Globals.dataPath}\\instance\\{profileName}";
            if (!string.IsNullOrWhiteSpace(dj.directory) && !string.IsNullOrEmpty(dj.directory))
                workDir = dj.directory;

            if (modVersion != "")
            {
                vi.game = modName;
                vi.version = modVersion;
            }

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
                .Replace("{version}", $"\"{vi.version}\"")
                .Replace("{libDir}", $"\"{Globals.dataPath}\\libs\"");

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
            proc.Exited += (sender, e) => HomeScreen.Instance.lblPlayedFor.Invoke(new System.Action(() => OnProcessExited(sender, e, profileName, vi.assetsVirt, proc))); //lmao this is dumb shit (but it works)
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\");
            proc.StartInfo.WorkingDirectory = $"{Globals.dataPath}\\instance\\{profileName}\\.minecraft\\";
            if (dj.useJava)
                proc.StartInfo.FileName = dj.javaPath;
            else if (vi.java <= 8)
                proc.StartInfo.FileName = Settings.sj.jre8;
            else if (vi.java <= 17)
                proc.StartInfo.FileName = Settings.sj.jre17;
            else if (vi.java <= 21)
                proc.StartInfo.FileName = Settings.sj.jre21;
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

            if (ipPort != null)
            {
                if (dj.offline)
                    msPlayerMPPass = "-";

                proc.StartInfo.Arguments += $"-Dserver=\"{ipPort[0]}\" -Dport=\"{ipPort[1]}\" -Dmppass=\"{msPlayerMPPass}\" ";
                Logger.Info("[JavaLauncher]", $"Server active!");
            }

            string classpath = vi.classpath;
            if (dj.useClass)
                classpath = dj.classpath;

            proc.StartInfo.Arguments += $"-Djava.library.path=\"{Globals.dataPath}\\libs\\natives-{runID}\" -cp {jars} {classpath} {vi.cmdAft}";

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
