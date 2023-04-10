using MCLauncher.classes;
using MCLauncher.forms;
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
        public static void Start(string instName, string clientPath)
        {
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
            }

            if (mj.items.Count() > 0)
            {
                Logger.Info("[JavaModHelper]", "count: " + mj.items.Count());

                string toHash = "";
                var md5 = MD5.Create();
                var stream = File.OpenRead(clientPath);

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

                if(!File.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar"))
                {
                    if (Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\"))
                        Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\", true);

                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full");
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch");
                    ZipFile.ExtractToDirectory(clientPath, $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\");

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












            /*
            Logger.Error("JavaModHelper", $"Client path; {JavaLauncher.modClientPath}");
            /*if (typeList.Count > 0) //Will it crash?
            {
                JavaLauncher.launchVerType = typeList[0];
                JavaLauncher.launchJsonUrl = $"http://codex-ipsa.dejvoss.cz/MCL-Data/{Globals.codebase}/ver-launch/{typeList[0]}.json";
            }*/

            /*string index = File.ReadAllText($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\index.cfg");
            if (index.Contains("\"forge\":true"))
            {
                LaunchJava.launchProxy += "-Dhttp.nonProxyHosts=codex-ipsa.dejvoss.cz -Dminecraft.applet.TargetDirectory={gameDir} -Dfml.core.libraries.mirror=http://codex-ipsa.dejvoss.cz/MCL-Data/launcher/forgelib/%s ";
                Logger.Info("[ModHelper]", "Forge tweaks on!");
            }
        }*/
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
