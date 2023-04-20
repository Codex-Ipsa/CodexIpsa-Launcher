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

namespace MCLauncher
{
    internal class JavaModHelper
    {
        public static void Start(string instName, string manifestPath)
        {
            //When I wrote this, only I and my beer can knew how it worked,
            //now nobody does

            Directory.CreateDirectory($"{Globals.dataPath}\\versions\\java");
            string clientJson = File.ReadAllText(manifestPath);
            string indexPath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\mods.json";
            if (!File.Exists(indexPath))
                File.WriteAllText(indexPath, $"{{\"forge\": false, \"items\": []}}");

            Logger.Info("[JavaModHelper]", "Start for " + indexPath);

            string json = File.ReadAllText(indexPath);
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(json);

            List<string> jsonList = new List<string>();
            jsonList.Clear();

            foreach (ModJsonEntry ent in mj.items)
            {
                Logger.Info("[JavaModHelper]", $"Found mod {ent.name}, type: {ent.type}, json: {ent.json}");

                if (ent.json != "")
                {
                    jsonList.Add(ent.json);
                    Logger.Info("[JavaModHelper]", "ent.json: " + ent.json);
                }

                if(ent.type == "cusjar")
                {

                }
            }

            VersionInfo vi = new VersionInfo();
            if (jsonList.Count > 0)
            {
                Console.WriteLine($"{Globals.dataPath}\\data\\json\\{jsonList[0]}.json");
                Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", jsonList[0]), $"{Globals.dataPath}\\data\\json\\{jsonList[0]}.json");
                string newJson = File.ReadAllText($"{Globals.dataPath}\\data\\json\\{jsonList[0]}.json");

                JavaLauncher.manifestPath = $"{Globals.dataPath}\\data\\json\\{jsonList[0]}.json";
                vi = JsonConvert.DeserializeObject<VersionInfo>(newJson);
            }
            else
            {
                vi = JsonConvert.DeserializeObject<VersionInfo>(clientJson);
            }

            if (mj.items.Count() > 0)
            {
                Logger.Info("[JavaModHelper]", "count: " + mj.items.Count());

                string toHash = "";
                var md5 = MD5.Create();
                if (!File.Exists($"{Globals.dataPath}\\versions\\java\\{vi.version}.jar"))
                {
                    Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\java\\{vi.version}.jar");
                }
                var stream = File.OpenRead($"{Globals.dataPath}\\versions\\java\\{vi.version}.jar");

                var hash = md5.ComputeHash(stream);
                toHash += BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant() + ";";


                foreach (ModJsonEntry ent in mj.items)
                {
                    stream = File.OpenRead($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{ent.name}");
                    hash = md5.ComputeHash(stream);
                    toHash += BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant() + ";";
                }

                toHash += "CodexIpsa";
                Logger.Info("[JavaModHelper]", $"ToHash: {toHash}");
                string patchHash = "";


                byte[] inputBytes = Encoding.ASCII.GetBytes(toHash);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                patchHash = BitConverter.ToString(hashBytes).Replace("-", "").ToUpperInvariant();
                Logger.Info("[JavaModHelper]", $"PatchHash: {patchHash}");

                if (!File.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar"))
                {
                    if (Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\"))
                        Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\", true);

                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full");
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch");
                    ZipFile.ExtractToDirectory($"{Globals.dataPath}\\versions\\java\\{vi.version}.jar", $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\");

                    int count = 0;
                    foreach (ModJsonEntry ent in mj.items)
                    {
                        ZipFile.ExtractToDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{ent.name}", $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\{count}\\");
                        string sourcePath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\{count}\\";

                        foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(sourcePath, $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\"));
                        }

                        foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(sourcePath, $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\"), true);
                        }
                        count++;
                    }

                    Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\META-INF\\", true);
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\");
                    File.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\patch.jar");
                    ZipFile.CreateFromDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\", $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar");
                    Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\", true);
                }
                Logger.Info("[JavaModHelper]", $"Created patched jar");
                JavaLauncher.modClientPath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar";
            }
        }

        public static string LegacyUpdate(string indexPath, string json, string instName)
        {
            DirectoryInfo d = new DirectoryInfo($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\");

            string toJson = "";
            foreach (var file in d.GetFiles("*.jar"))
            {
                toJson += $"\"{file.Name}?jarmod\",";
            }
            foreach (var file in d.GetFiles("*.zip"))
            {
                toJson += $"\"{file.Name}?jarmod\",";
            }
            if (toJson.Contains(","))
                toJson = toJson.Remove(toJson.LastIndexOf(','));
            File.WriteAllText(indexPath, $"{{\"forge\":false,\"items\":[{toJson}]}}");
            json = $"{{\"forge\":false,\"items\":[{toJson}]}}";
            return json;
        }
    }
}
