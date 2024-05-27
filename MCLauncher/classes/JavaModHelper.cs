using MCLauncher.classes;
using MCLauncher.classes.jsons;
using MCLauncher.forms;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
            if (Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\"))
                Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\", true);
            if (Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2\\"))
                Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2\\", true);

            //The Loop:tm:
            string toHash = "";
            foreach (ModJsonEntry entry in modsManifest.items)
            {
                if (entry.disabled)
                    continue;

                //check for updates
                string[] skip = PallasRepo.checkForUpdate(instName, entry.name, entry.version);
                if (skip != null)
                {
                    Logger.Info("[JavaModHelper/Test1]", $"0   {entry.version}, {entry.json}, {entry.file}, {entry.type}");
                    entry.version = skip[0];
                    entry.json = skip[1];
                    entry.file = skip[2];
                    entry.type = skip[3];
                    Logger.Info("[JavaModHelper/Test1]", $"1   {entry.version}, {entry.json}, {entry.file}, {entry.type}");
                }

                if (!string.IsNullOrWhiteSpace(entry.name))
                {
                    JavaLauncher.modName = entry.name;
                }
                if (!string.IsNullOrWhiteSpace(entry.version))
                {
                    JavaLauncher.modVersion = entry.version;
                }



                //cusjars are simple, just return the path
                if (entry.type == "cusjar")
                {
                    DownloadProgress.url = Globals.javaInfo.Replace("{ver}", entry.json).Replace("{type}", "java");
                    DownloadProgress.savePath = $"{Globals.dataPath}\\data\\json\\{entry.json}.json";
                    DownloadProgress dp = new DownloadProgress();
                    dp.ShowDialog();

                    if (!string.IsNullOrEmpty(entry.json))
                        JavaLauncher.manifestPath = $"{Globals.dataPath}\\data\\json\\{entry.json}.json";

                    return $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{entry.file}"; //this is temporary, because mods for mods that are cujars won't work
                }
                //jarmods extract, then zip up and return that
                else if (entry.type == "jarmod")
                {
                    DownloadProgress.url = Globals.javaInfo.Replace("{ver}", entry.json).Replace("{type}", "java");
                    DownloadProgress.savePath = $"{Globals.dataPath}\\data\\json\\{entry.json}.json";
                    DownloadProgress dp = new DownloadProgress();
                    dp.ShowDialog();

                    if (!string.IsNullOrEmpty(entry.json))
                    {
                        clientJson = File.ReadAllText($"{Globals.dataPath}\\data\\json\\{entry.json}.json");
                        clientManifest = JsonConvert.DeserializeObject<VersionInfo>(clientJson);
                        JavaLauncher.manifestPath = $"{Globals.dataPath}\\data\\json\\{entry.json}.json";
                    }

                    string tempDir = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp";
                    Directory.CreateDirectory(tempDir);
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2");

                    //extract jarmods AND overwrite file if exists
                    ZipArchive archive = ZipFile.Open($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{entry.file}", ZipArchiveMode.Read);
                    foreach (ZipArchiveEntry file in archive.Entries)
                    {
                        string completeFileName = Path.GetFullPath(Path.Combine(tempDir, file.FullName));
                        Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                        if (file.Name == "")
                        {
                            continue;
                        }
                        file.ExtractToFile(completeFileName, true);
                    }
                    archive.Dispose();


                    //ZipFile.ExtractToDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\{entry.file}", tempDir);

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
            if (Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\"))
            {
                if (!File.Exists($"{Globals.dataPath}\\versions\\java\\{clientManifest.version}.jar"))
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

                if (!File.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\{patchHash}.jar"))
                {
                    ZipArchive archive = ZipFile.Open($"{Globals.dataPath}\\versions\\java\\{clientManifest.version}.jar", ZipArchiveMode.Read);
                    foreach (ZipArchiveEntry file in archive.Entries)
                    {
                        string completeFileName = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2\\{file.FullName}";
                        Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                        if (file.Name == "")
                            continue;

                        try
                        {
                            file.ExtractToFile(completeFileName, true);
                        }
                        catch (System.NotSupportedException e)
                        {
                            Logger.Error("[JavaModHelper]", $"Couldn't extract {file.Name}");
                        }
                    }
                    archive.Dispose();

                    //ZipFile.ExtractToDirectory($"{Globals.dataPath}\\versions\\java\\{clientManifest.version}.jar", $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2");
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

                    if(Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2\\META-INF\\"))
                        Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp2\\META-INF\\", true);
                    
                    Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\");
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
    }
}
