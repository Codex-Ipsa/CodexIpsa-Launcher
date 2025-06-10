using MCLauncher.forms;
using MCLauncher.json.api;
using MCLauncher.json.launcher;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace MCLauncher.launchers
{
    internal class ModWorker
    {
        //this compiles mods and returns the path of the patched jar (or custom jar)
        //returns null if no mods used, launcher should just use default jar path
        public static (String, String, String) createJarPatch(String instanceName)
        {
            //cleanup
            if (Directory.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\"))
                Directory.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\", true);

            //get instance manifest
            String instanceManifest = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\instance.json");
            InstanceJson ij = JsonConvert.DeserializeObject<InstanceJson>(instanceManifest);

            //get mod manifest
            String modManifest = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\mods.json");
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(modManifest);

            //return if no mods
            if (mj.items.Length == 0)
            {
                Logger.Info("[ModWorker/createJarPatch]", $"No mods found!");
                return (null, null, null);
            }

            //variables
            bool hasJarMods = false;
            String clientPath = $"{Globals.dataPath}\\versions\\java\\{ij.version}.jar"; //TODO IF BASEGAME IS REPLACED WITH A CUSJAR

            //gets client path
            for (int i = 0; i < mj.items.Length; i++)
            {
                ModJsonEntry entry = mj.items[i];

                if (entry.disabled)
                    continue;

                //check for mod updates
                string[] skip = PallasRepo.checkForUpdate(instanceName, entry.name, entry.version);
                if (skip != null)
                {
                    Logger.Info("[JavaModHelper/Test1]", $"0   {entry.version}, {entry.json}, {entry.file}, {entry.type}");
                    entry.version = skip[0];
                    entry.json = skip[1];
                    entry.file = skip[2];
                    entry.type = skip[3];
                    Logger.Info("[JavaModHelper/Test1]", $"1   {entry.version}, {entry.json}, {entry.file}, {entry.type}");
                }

                if (entry.type == "cusjar")
                {
                    clientPath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{entry.file}";
                    break;
                }
                else
                {
                    String modFile = getModManifest(instanceName);
                    if (modFile == null)
                        break;

                    String modVerManifest = File.ReadAllText(modFile);
                    VersionJson vj = JsonConvert.DeserializeObject<VersionJson>(modVerManifest);

                    if (!File.Exists($"{Globals.dataPath}\\versions\\java\\{vj.version}.jar"))
                        Globals.client.DownloadFile(vj.url, $"{Globals.dataPath}\\versions\\java\\{vj.version}.jar");

                    clientPath = $"{Globals.dataPath}\\versions\\java\\{vj.version}.jar";
                    break;
                }
            }

            //get patch MD5
            String md5Patch = getPatchMD5(instanceName);
            var gameInfo = getPatchName(mj);


            //loop through all mods and extract
            for (int i = 0; i < mj.items.Length; i++)
            {
                ModJsonEntry entry = mj.items[i];

                //skip disabled entries
                if (entry.disabled)
                    continue;

                //work only with jarmods
                if (entry.type == "jarmod")
                {
                    //if patch doesn't exist
                    if (!File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\patch\\minecraft-{md5Patch}.jar"))
                    {
                        Logger.Info("[ModWorker/createJarPatch]", $"Jarmod: {entry.file} {entry.type}");

                        if (!hasJarMods)
                        {
                            //ONLY extract the base game when jarmods exist
                            extractZip(clientPath, $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\");
                            Logger.Info("[ModWorker/createJarPatch]", $"Base game jar: {ij.version}.jar");

                            hasJarMods = true;
                        }

                        //extract jar to temp dir
                        ZipArchive archive = ZipFile.Open($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{entry.file}", ZipArchiveMode.Read);
                        foreach (ZipArchiveEntry file in archive.Entries)
                        {
                            string completeFileName = Path.GetFullPath($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\{file.FullName}");
                            Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                            if (file.Name == "")
                            {
                                continue;
                            }
                            file.ExtractToFile(completeFileName, true);
                        }
                        archive.Dispose();
                    }
                    hasJarMods = true;
                }
            }

            if (hasJarMods) //jarmods
            {
                //delete META-INF
                if (Directory.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\META-INF\\"))
                    Directory.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\META-INF\\", true);

                //zip up the patch dir
                if (!File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\patch\\minecraft-{md5Patch}.jar"))
                {
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\patch\\");
                    ZipFile.CreateFromDirectory($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\", $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\patch\\minecraft-{md5Patch}.jar");
                }

                //cleanup
                if (Directory.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\"))
                    Directory.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\", true);

                return ($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\patch\\minecraft-{md5Patch}.jar", gameInfo.Item1, gameInfo.Item2);
            }
            else //should ALWAYS be custom JAR only
            {
                return (clientPath, gameInfo.Item1, gameInfo.Item2);
            }
        }

        //gets MD5 of the game patch
        public static String getPatchMD5(String instanceName)
        {
            //get mod manifest
            String modManifest = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\mods.json");
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(modManifest);

            String toMD5 = "";

            //loop through items
            for (int i = 0; i < mj.items.Length; i++)
            {
                ModJsonEntry entry = mj.items[i];

                //skip disabled entries
                if (entry.disabled)
                    continue;

                //if cusjar = set path
                if (entry.type == "jarmod")
                {
                    long length = new FileInfo($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{entry.file}").Length;
                    toMD5 += $"{entry.file}:{length};";
                }

                Console.WriteLine($"({entry.type}) {entry.file}: {entry.json}");
            }

            return MD5String(toMD5);
        }

        //gets game and version variables of patch
        public static (String, String) getPatchName(ModJson mj)
        {
            String game = null;
            String version = null;

            //loop through items
            for (int i = 0; i < mj.items.Length; i++)
            {
                ModJsonEntry entry = mj.items[i];

                //skip disabled entries
                if (entry.disabled)
                    continue;

                //set game name
                if ((game == null && entry.name != "") && (version == null && entry.version != ""))
                {
                    game = entry.name;
                    version = entry.version;
                    break;
                }
            }

            Logger.Info("[ModWorker/getPatchName]", $"{game}, {version}");
            return (game, version);
        }

        //TODO get and download the mod manifest
        public static String getModManifest(String instanceName)
        {
            //get mod manifest
            String modManifest = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\mods.json");
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(modManifest);

            String manifestPath = null;

            //loop through items
            for (int i = 0; i < mj.items.Length; i++)
            {
                ModJsonEntry entry = mj.items[i];

                if (entry.disabled)
                    continue;

                if (manifestPath == null)
                {
                    if (entry.type == "json")
                    {
                        manifestPath = $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{entry.file}";
                        break;
                    }
                    else if (entry.json != null && entry.json != String.Empty)
                    {
                        if (!File.Exists($"{Globals.dataPath}\\data\\json\\{entry.json}.json"))
                            Globals.client.DownloadFile(Globals.javaInfo.Replace("{type}", "java").Replace("{ver}", entry.json), $"{Globals.dataPath}\\data\\json\\{entry.json}.json");

                        manifestPath = $"{Globals.dataPath}\\data\\json\\{entry.json}.json";
                        break;
                    }
                }
            }

            Logger.Info("[ModWorker/getModManifest]", $"{manifestPath}");
            return manifestPath;
        }

        //String to MD5
        public static String MD5String(String input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToUpperInvariant();
            }
        }

        //extracts zip with catching errors
        public static void extractZip(String zipPath, String destination)
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    try
                    {
                        String path = Path.Combine(destination, entry.FullName);
                        String dir = Path.GetDirectoryName(path);

                        Directory.CreateDirectory(dir);
                        if(File.Exists(path))
                            File.Delete(path);

                        entry.ExtractToFile(path);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("[ModWorker/extractZip]", $"Failed to extract {entry.FullName} ({ex.Message})");
                    }
                }
            }
        }
    }
}
