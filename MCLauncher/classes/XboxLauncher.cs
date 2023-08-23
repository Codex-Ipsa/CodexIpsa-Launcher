using MCLauncher.forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.classes
{
    internal class XboxLauncher
    {
        public static void Launch(string profileName)
        {
            //download/update xenia
            Directory.CreateDirectory($"{Globals.dataPath}\\emulator\\xenia\\");
            var xm = JsonConvert.DeserializeObject<XeniaManifest>(Globals.client.DownloadString(Globals.xeniaManifest));
            if (File.Exists($"{Globals.dataPath}\\emulator\\xenia\\version.cfg"))
            {
                File.Move($"{Globals.dataPath}\\emulator\\xenia\\version.cfg", $"{Globals.dataPath}\\emulator\\xenia\\version");
            }

            if (!File.Exists($"{Globals.dataPath}\\emulator\\xenia\\version") || !File.ReadAllText($"{Globals.dataPath}\\emulator\\xenia\\version").Contains(xm.ver))
            {
                File.Delete($"{Globals.dataPath}\\emulator\\xenia\\xenia_canary.exe");
                File.Delete($"{Globals.dataPath}\\emulator\\xenia\\LICENSE");

                DownloadProgress.url = xm.url;
                DownloadProgress.savePath = $"{Globals.dataPath}\\emulator\\xenia\\xenia.zip";
                DownloadProgress download = new DownloadProgress();
                download.ShowDialog();

                ZipFile.ExtractToDirectory($"{Globals.dataPath}\\emulator\\xenia\\xenia.zip", $"{Globals.dataPath}\\emulator\\xenia\\");
                File.WriteAllText($"{Globals.dataPath}\\emulator\\xenia\\version", xm.ver);
                File.Delete($"{Globals.dataPath}\\emulator\\xenia\\xenia.zip");

                Logger.Info("[XboxLauncher]", "Updated Xenia");
            }

            //downloading game
            string data = File.ReadAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json");
            var dj = JsonConvert.DeserializeObject<ProfileInfo>(data);

            string url = Globals.client.DownloadString(Globals.x360Url) + dj.version + ".zip";

            Directory.CreateDirectory($"{Globals.dataPath}\\versions\\x360\\");
            if (!Directory.Exists($"{Globals.dataPath}\\versions\\x360\\{dj.version}"))
            {
                DownloadProgress.url = url;
                DownloadProgress.savePath = $"{Globals.dataPath}\\versions\\x360\\{dj.version}.zip";
                DownloadProgress download = new DownloadProgress();
                download.ShowDialog();

                ZipFile.ExtractToDirectory($"{Globals.dataPath}\\versions\\x360\\{dj.version}.zip", $"{Globals.dataPath}\\versions\\x360\\{dj.version}");
                File.Delete($"{Globals.dataPath}\\versions\\x360\\{dj.version}.zip");
            }

            //loading settings
            if(!File.Exists($"{Globals.dataPath}\\emulator\\xenia\\xenia-canary.config.toml"))
            {
                Logger.Error("[XboxLauncher]", "Xenia config not found! Make sure to relaunch the game at least once for settings to take place!");
            }
            else
            {
                string config = File.ReadAllText($"{Globals.dataPath}\\emulator\\xenia\\xenia-canary.config.toml");
                config = config.Replace("discord = true", "discord = false");
                if (!dj.xboxDemo)
                {
                    config = config.Replace("license_mask = 0", "license_mask = 1").Replace("license_mask = -1", "license_mask = 1");
                }
                else
                {
                    config = config.Replace("license_mask = 1", "license_mask = 0").Replace("license_mask = -1", "license_mask = 0");
                }
                File.WriteAllText($"{Globals.dataPath}\\emulator\\xenia\\xenia-canary.config.toml", config);
            }

            //launching bases
            if (dj.version.Contains("pre") || dj.version == "tu0")
            {
                if(Directory.Exists($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\"))
                    Directory.Delete($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\", true);

                Process proc = new Process();
                proc.EnableRaisingEvents = true;
                proc.StartInfo.FileName = $"\"{Globals.dataPath}\\emulator\\xenia\\xenia_canary.exe\"";
                proc.StartInfo.Arguments = $"\"{Globals.dataPath}\\versions\\x360\\{dj.version}\\default.xex\"";
                proc.Exited += OnProcessExited;
                proc.Start();
                Logger.Info("[XboxLauncher]", "Launched xenia @ base");
                Discord.ChangeMessage($"Playing Xbox 360 Edition ({dj.version})");
            }
            //launching updates
            else
            {
                //download base
                if (!Directory.Exists($"{Globals.dataPath}\\versions\\x360\\tu0"))
                {
                    DownloadProgress.url = Globals.client.DownloadString(Globals.x360Base);
                    DownloadProgress.savePath = $"{Globals.dataPath}\\versions\\x360\\tu0.zip";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();

                    ZipFile.ExtractToDirectory($"{Globals.dataPath}\\versions\\x360\\tu0.zip", $"{Globals.dataPath}\\versions\\x360\\tu0");
                    File.Delete($"{Globals.dataPath}\\versions\\x360\\tu0.zip");
                }

                if (!Directory.Exists($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\{dj.version}"))
                {
                    Logger.Info("[XboxLauncher]", "Copying update files...");
                    Directory.CreateDirectory($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000");
                    DirectoryInfo di = new DirectoryInfo($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000");
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    Directory.CreateDirectory($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\{dj.version}");

                    DirectoryInfo itunes = new DirectoryInfo($"{Globals.dataPath}\\versions\\x360\\{dj.version}");
                    FileInfo[] itunesFiles = itunes.GetFiles("*.*", SearchOption.AllDirectories);
                    foreach(FileInfo file in itunesFiles)
                    {
                        string fileName = file.FullName.Replace($"{Globals.dataPath}\\versions\\x360\\{dj.version}", "");
                        string path = fileName.Substring(0, fileName.LastIndexOf("\\") + 1);
                        //Console.WriteLine(file.FullName);
                        //Console.WriteLine(path + fileName);
                        //Console.WriteLine("-----------");
                        Directory.CreateDirectory($"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\{dj.version}\\{path}");
                        File.Copy($"{file.FullName}", $"{Globals.dataPath}\\emulator\\xenia\\content\\584111F7\\000B0000\\{dj.version}\\{fileName}");
                    }
                }

                Process proc = new Process();
                proc.EnableRaisingEvents = true;
                proc.StartInfo.FileName = $"\"{Globals.dataPath}\\emulator\\xenia\\xenia_canary.exe\"";
                proc.StartInfo.Arguments = $"\"{Globals.dataPath}\\versions\\x360\\tu0\\default.xex\"";
                proc.Exited += OnProcessExited;
                proc.Start();
                Logger.Info("[XboxLauncher]", "Launched xenia @ update");
                Discord.ChangeMessage($"Playing Xbox 360 Edition ({dj.version})");
            }
        }

        private static void OnProcessExited(object sender, EventArgs e)
        {
            Discord.ChangeMessage($"Idling");
        }
    }

    public class XeniaManifest
    {
        public string ver { get; set; }
        public string url { get; set; }
    }
}
