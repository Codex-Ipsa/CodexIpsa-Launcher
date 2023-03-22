using MCLauncher.progressbars;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace MCLauncher
{
    public class AssetIndex
    {
        public static bool isLegacy;

        public static List<string> nameList = new List<string>();
        public static List<string> hashList = new List<string>();
        public static List<int> sizeList = new List<int>();

        public static void start(string indexUrl, string indexName)
        {
            if (indexName.Contains("legacy"))
            {
                isLegacy = true;
                Logger.Info("[AssetIndex]", "isLegacy returned true!");
            }
            else
            {
                isLegacy = false;
            }

            WebClient client = new WebClient();
            Directory.CreateDirectory($"{Globals.dataPath}\\assets\\indexes\\");

            if (!File.Exists($"{Globals.dataPath}\\assets\\indexes\\{indexName}.json"))
            {
                client.DownloadFile(indexUrl, $"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");
            }
            else
            {
                FileInfo fi = new FileInfo($"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(indexUrl);
                req.Method = "HEAD";
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); //fix rate limit
                long urlSize = resp.ContentLength;

                if(urlSize != fi.Length)
                {
                    Logger.Info("[AssetIndex]", "Index has changed! Redownloading json.");
                    File.Delete($"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");
                    client.DownloadFile(indexUrl, $"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");
                }
            }
            string origJson = File.ReadAllText($"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");

            JObject origObj = JsonConvert.DeserializeObject<JObject>(origJson);
            var origProps = origObj.Properties();

            foreach (var oProp in origProps)
            {
                string oKey = oProp.Name;
                string oVal = oProp.Value.ToString();

                if (oKey == "objects")
                {
                    string indexJson = oVal;
                    JObject assetObj = JsonConvert.DeserializeObject<JObject>(indexJson);
                    var assetProps = assetObj.Properties();
                    foreach (var aProp in assetProps)
                    {
                        string aKey = aProp.Name;
                        object aVal = aProp.Value;
                        JObject itemObj = JsonConvert.DeserializeObject<JObject>(aVal.ToString());
                        var itemProps = itemObj.Properties();
                        foreach (var iProp in itemProps)
                        {
                            if (iProp.Name == "hash")
                            {
                                object iVal = iProp.Value;
                                //Logger.logMessage("[AssetIndex]", $"Name: {aKey}; hash: {iVal}");
                                nameList.Add(aKey);
                                hashList.Add(iVal.ToString());
                            }
                            else if (iProp.Name == "size")
                            {
                                object iVal = iProp.Value;
                                sizeList.Add(int.Parse(iVal.ToString()));
                                //Logger.logMessage("[AssetIndex]", $"Current size: {iVal}");
                            }
                        }
                    }
                }
                else
                {
                    Logger.Error("[AssetIndex]", $"Unknown key: {oKey}, with value: {oVal}");
                }

                Logger.Error("[AssetIndex]", $"isLegacy: {isLegacy}");
                if (isLegacy == true)
                {
                    Directory.CreateDirectory($"{Globals.dataPath}\\assets\\virtual\\{indexName}\\");
                    int indexInt = 0;
                    WebClient wc = new WebClient();
                    
                    List<string> urls = new List<string>();
                    List<string> paths = new List<string>();

                    int totalSize = 0;
                    foreach (var name in nameList)
                    {
                        string fullHash = hashList[indexInt];
                        string firstTwo = fullHash.Substring(0, 2);

                        string fileDirectory = "/" + name;
                        int index = fileDirectory.LastIndexOf("/");
                        if (index >= 0)
                            fileDirectory = fileDirectory.Substring(0, index);

                        string fileName = name;
                        int index2 = fileName.IndexOf("/");
                        if (index2 >= 0)
                            fileName = fileName.Substring(fileName.LastIndexOf("/"));

                        if (!File.Exists($"{Globals.dataPath}\\assets\\virtual\\{indexName}\\{fileDirectory}\\{fileName}"))
                        {
                            totalSize += sizeList[indexInt];
                            Directory.CreateDirectory($"{Globals.dataPath}\\assets\\virtual\\{indexName}\\{fileDirectory}");
                            urls.Add($"https://resources.download.minecraft.net/{firstTwo}/{fullHash}");
                            paths.Add($"{Globals.dataPath}\\assets\\virtual\\{indexName}\\{fileDirectory}\\{fileName}");
                        }
                        else
                        {
                            //Logger.logError("[AssetIndex]", "aa " + $"{Globals.dataPath}\\assets\\virtual\\{indexName}\\{fileDirectory}\\{fileName}");
                            FileInfo fi = new FileInfo($"{Globals.dataPath}\\assets\\virtual\\{indexName}\\{fileDirectory}\\{fileName}");
                            if (fi.Length != sizeList[indexInt])
                            {
                                Logger.Error("[AssetIndex]", $"Bad item! {indexName}/{fileDirectory}/{fileName} {fi.Length}::{sizeList[indexInt]}");
                                File.Delete($"{Globals.dataPath}\\assets\\virtual\\{indexName}\\{fileDirectory}\\{fileName}");
                                totalSize += sizeList[indexInt];
                                Directory.CreateDirectory($"{Globals.dataPath}\\assets\\virtual\\{indexName}\\{fileDirectory}");
                                urls.Add($"https://resources.download.minecraft.net/{firstTwo}/{fullHash}");
                                paths.Add($"{Globals.dataPath}\\assets\\virtual\\{indexName}\\{fileDirectory}\\{fileName}");
                            }
                        }

                        indexInt++;
                    }
                    if(urls.Count != 0)
                    {
                        DownloadProgressMulti dpm = new DownloadProgressMulti(urls, paths, totalSize, Strings.lblDlAssets);
                        dpm.ShowDialog();
                    }

                    isLegacy = false;
                    indexInt = 0;
                    hashList.Clear();
                    nameList.Clear();
                    totalSize = 0;
                }
                else if (isLegacy == false)
                {
                    Directory.CreateDirectory($"{Globals.dataPath}\\assets\\objects\\");

                    int indexInt = 0;
                    WebClient wc = new WebClient();
                    
                    List<string> urls = new List<string>();
                    List<string> paths = new List<string>();
                    int totalSize = 0;
                    foreach (var name in nameList)
                    {
                        string fullHash = hashList[indexInt];
                        string firstTwo = fullHash.Substring(0, 2);

                        if (!File.Exists($"{Globals.dataPath}\\assets\\objects\\{firstTwo}\\{fullHash}"))
                        {
                            totalSize += sizeList[indexInt];
                            urls.Add($"https://resources.download.minecraft.net/{firstTwo}/{fullHash}");
                            paths.Add($"{Globals.dataPath}\\assets\\objects\\{firstTwo}\\{fullHash}");
                            Directory.CreateDirectory($"{Globals.dataPath}\\assets\\objects\\{firstTwo}");
                        }
                        else
                        {
                            FileInfo fi = new FileInfo($"{Globals.dataPath}\\assets\\objects\\{firstTwo}\\{fullHash}");
                            if (fi.Length != sizeList[indexInt])
                            {
                                Logger.Error("[AssetIndex]", $"Bad item! {firstTwo}/{fullHash} {fi.Length}::{sizeList[indexInt]}");
                                File.Delete($"{Globals.dataPath}\\assets\\objects\\{firstTwo}\\{fullHash}");
                                totalSize += sizeList[indexInt];
                                urls.Add($"https://resources.download.minecraft.net/{firstTwo}/{fullHash}");
                                paths.Add($"{Globals.dataPath}\\assets\\objects\\{firstTwo}\\{fullHash}");
                                Directory.CreateDirectory($"{Globals.dataPath}\\assets\\objects\\{firstTwo}");
                            }
                        }

                        indexInt++;
                    }
                    if(urls.Count != 0)
                    {
                        DownloadProgressMulti dpm = new DownloadProgressMulti(urls, paths, totalSize, Strings.lblDlAssets);
                        dpm.ShowDialog();
                    }

                    isLegacy = false;
                    indexInt = 0;
                    hashList.Clear();
                    nameList.Clear();
                    totalSize = 0;
                }
            }
        }
    }
}
