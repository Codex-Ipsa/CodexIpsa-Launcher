using MCLauncher.classes;
using MCLauncher.forms;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;

namespace MCLauncher
{
    internal class JavaModHelper
    {
        public static string GetPath(string instName, string manifestPath)
        {
            //Manifests
            string modsJson = File.ReadAllText($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\mods.json");
            ModJson modsManifest = JsonConvert.DeserializeObject<ModJson>(modsJson);
            string clientJson = File.ReadAllText(manifestPath);
            VersionInfo clientManifest = JsonConvert.DeserializeObject<VersionInfo>(clientJson);

            //Speeds up the time
            if (modsManifest.items.Count() < 1)
            {
                return "";
            }

            //Delete these because yeah
            if(Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\"))
                Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\", true);
            if(Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2\\"))
                Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2\\", true);

            //The Loop:tm:
            string toHash = "";
            foreach (ModJsonEntry entry in modsManifest.items)
            {
                //cusjars are simple, just return the path
                if (entry.type == "cusjar")
                {
                    JavaLauncher.modName = entry.name;
                    JavaLauncher.modVersion = entry.version;
                    return $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{entry.file}"; //this is temporary, because mods for mods that are cujars won't work
                }
                //jarmods extract, then zip up and return that
                else if (entry.type == "jarmod")
                {
                    DownloadProgress.url = Globals.javaInfo.Replace("{ver}", entry.json);
                    DownloadProgress.savePath = $"{Globals.dataPath}\\data\\json\\{entry.json}.json";
                    DownloadProgress dp = new DownloadProgress();
                    dp.ShowDialog();

                    clientJson = File.ReadAllText($"{Globals.dataPath}\\data\\json\\{entry.json}.json");
                    clientManifest = JsonConvert.DeserializeObject<VersionInfo>(clientJson);
                    JavaLauncher.manifestPath = $"{Globals.dataPath}\\data\\json\\{entry.json}.json";

                    string tempDir = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp";
                    Directory.CreateDirectory(tempDir);
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2");
                    ZipFile.ExtractToDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{entry.file}", tempDir);

                    toHash += MD5File($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{entry.file}") + ";";
                }
                //for jsons just load the new json in JavaLauncher, used by modloaders
                else if (entry.type == "json")
                {
                    clientJson = File.ReadAllText($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{entry.file}");
                    clientManifest = JsonConvert.DeserializeObject<VersionInfo>(clientJson);
                    JavaLauncher.manifestPath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{entry.file}";
                }
            }

            //pack jarmods into a zip
            if(Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\"))
            {
                if(!File.Exists($"{Globals.dataPath}\\versions\\java\\{clientManifest.version}.jar"))
                {
                    DownloadProgress.url = clientManifest.url;
                    DownloadProgress.savePath = $"{Globals.dataPath}\\versions\\java\\{clientManifest.version}.jar";
                    DownloadProgress dp = new DownloadProgress();
                    dp.ShowDialog();
                }
                toHash = MD5File($"{Globals.dataPath}\\versions\\java\\{clientManifest.version}.jar") + ";" + toHash;
                toHash += "CodexIpsa";
                Logger.Info("[JavaModHelper]", $"ToHash: {toHash}");
                string patchHash = MD5String(toHash);

                if(!File.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar"))
                {
                    ZipFile.ExtractToDirectory($"{Globals.dataPath}\\versions\\java\\{clientManifest.version}.jar", $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2\\");
                    string sourcePath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp";
                    string targetPath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2";

                    foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                    {
                        Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                    }

                    foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                    {
                        File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                    }

                    Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2\\META-INF\\", true);
                    ZipFile.CreateFromDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2", $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar");
                }
                return $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar";
            }

            return "";
        }

        static string MD5File(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                }
            }
        }

        static string MD5String(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToUpperInvariant();
            }
        }

        public static string MigrateToVersion(string indexPath, string instName)
        {
            string orig = File.ReadAllText(indexPath);
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(orig);

            string created = "{\n";
            created += "  \"data\": 1,\n";
            created += "  \"items\": [\n";
            foreach (var item in mj.items)
            {
                created += $"    {{\n";
                created += $"      \"name\": \"\",\n";
                created += $"      \"version\": \"{item.version}\",\n";
                created += $"      \"file\": \"{item.name}\",\n";
                created += $"      \"type\": \"{item.type}\",\n";
                created += $"      \"json\": \"{item.json}\",\n";
                created += $"      \"update\": \"{item.update.ToString().ToLower()}\"\n";
                created += $"    }},";
            }
            created = created.TrimEnd(',');
            created += "\n  ]\n}";

            return created;
        }
    }
}
