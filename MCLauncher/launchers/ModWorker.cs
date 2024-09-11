using MCLauncher.json.launcher;
using Newtonsoft.Json;
using System;
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

        //TODO MAKE THIS RETURN GAME AND VERSION IF SET

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

            //extract base game
            //TODO IF BASEGAME IS REPLACED WITH A CUSJAR
            ZipFile.ExtractToDirectory($"{Globals.dataPath}\\versions\\java\\{ij.version}.jar", $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\");
            Logger.Info("[ModWorker/createJarPatch]", $"Base game jar: {ij.version}.jar");

            //get patch MD5
            String md5Patch = getPatchMD5(instanceName);
            var gameInfo = getPatchName(mj);

            //if patch already exists
            if (!File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\patch\\minecraft-{md5Patch}.jar"))
            {
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
                        Logger.Info("[ModWorker/createJarPatch]", $"Jarmod: {entry.file} {entry.type}");

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
                }

                //delete META-INF
                Directory.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\META-INF\\", true);

                //zip up the patch dir
                Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\patch\\");
                ZipFile.CreateFromDirectory($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\", $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\patch\\minecraft-{md5Patch}.jar");

                //cleanup
                if (Directory.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\"))
                    Directory.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\temp\\", true);
            }

            return ($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\patch\\minecraft-{md5Patch}.jar", gameInfo.Item1, gameInfo.Item2);
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

                //if cusjar = set path
                if (game == null && version == null)
                {
                    game = entry.name;
                    version = entry.version;
                    break;
                }
            }

            Logger.Info("[ModWorker/getPatchName]", $"{game}, {version}");
            return (game, version);
        }

        //String to MD5
        public static String MD5String(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToUpperInvariant();
            }
        }
    }
}
