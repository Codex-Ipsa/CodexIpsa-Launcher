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
            //When I wrote this, only I and my beer bottle knew how it worked,
            //now nobody does

            //Note 29.7.2023 - this needs to be rewritten lmao

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
            List<string> cusJarList = new List<string>();
            cusJarList.Clear();

            foreach (ModJsonEntry ent in mj.items)
            {
                Logger.Info("[JavaModHelper]", $"Found mod {ent.name}, type: {ent.type}, json: {ent.json}, update: {ent.update}");

                if(ent.update == true)
                {
                    string modManifest = Globals.client.DownloadString(Globals.CIModsJson);
                    List<RepoJson> repoJsons = JsonConvert.DeserializeObject<List<RepoJson>>(modManifest);
                    foreach(var entry in repoJsons)
                    {
                        if (ent.name.Contains(entry.id))
                        {
                            if (ent.name.EndsWith(entry.items[0].version + ".zip"))
                            {
                                Logger.Error("[JavaModHelper]", "MOD IS UP TO DATE");
                            }
                            else
                            {
                                if(!File.Exists($"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{entry.id}-{entry.items[0].version}.zip"))
                                {
                                    DownloadProgress.url = entry.items[0].url;
                                    DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{entry.id}-{entry.items[0].version}.zip";
                                    DownloadProgress dp = new DownloadProgress();
                                    dp.ShowDialog();
                                }

                                Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", entry.items[0].json), $"{Globals.dataPath}\\data\\json\\{entry.items[0].json}.json");
                                Profile.modListWorker("add", $"{entry.id}-{entry.items[0].version}.zip", entry.items[0].type, entry.items[0].json, true);
                                Profile.modListWorker("remove", ent.name, "", "", false);
                                File.Delete($"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{ent.name}");
                                //Profile.reloadModsList();

                                json = File.ReadAllText(indexPath);
                                mj = JsonConvert.DeserializeObject<ModJson>(json);

                                Logger.Error("[JavaModHelper]", "MOD UPDATE AVAILABLE");
                            }
                        }
                    }
                }

                if (ent.json != "")
                {
                    jsonList.Add(ent.json);
                    Logger.Info("[JavaModHelper]", "ent.json: " + ent.json);
                }
                if(ent.type == "cusjar")
                {
                    cusJarList.Add($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{ent.name}");
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
                string clientPath = $"{Globals.dataPath}\\versions\\java\\{vi.version}.jar";
                if (cusJarList.Count() > 0)
                {
                    clientPath = cusJarList[0];
                }
                Logger.Info("[JavaModHelper]", "clientPath: " + clientPath);
                Logger.Info("[JavaModHelper]", "count: " + mj.items.Count());

                string toHash = "";
                var md5 = MD5.Create();
                if (!File.Exists($"{Globals.dataPath}\\versions\\java\\{vi.version}.jar") && clientPath == $"{Globals.dataPath}\\versions\\java\\{vi.version}.jar")
                {
                    Globals.client.DownloadFile(vi.url, $"{Globals.dataPath}\\versions\\java\\{vi.version}.jar");
                }
                var stream = File.OpenRead(clientPath);

                var hash = md5.ComputeHash(stream);
                toHash += BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant() + ";";


                foreach (ModJsonEntry ent in mj.items)
                {
                    if(ent.type != "cusjar")
                    {
                        stream = File.OpenRead($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{ent.name}");
                        hash = md5.ComputeHash(stream);
                        toHash += BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant() + ";";
                    }
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
                    ZipFile.ExtractToDirectory(clientPath, $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\");

                    int count = 0;
                    foreach (ModJsonEntry ent in mj.items)
                    {
                        if (ent.type != "cusjar")
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
                    }

                    if(cusJarList.Count() <= 0)
                    {
                        Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\META-INF\\", true);
                    }
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\");
                    File.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\patch.jar");
                    ZipFile.CreateFromDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\", $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar");
                    Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\", true);
                }
                Logger.Info("[JavaModHelper]", $"Created patched jar");

                //this is a shitty fix
                if(cusJarList.Count == 1 && mj.items.Length == 1)
                {
                    JavaLauncher.modClientPath = cusJarList[0];
                }
                else
                {
                    JavaLauncher.modClientPath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar";
                }
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
