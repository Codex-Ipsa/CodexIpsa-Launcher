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

        public static void start(string indexUrl, string indexName)
        {
            isLegacy = false;
            WebClient client = new WebClient();
            string origJson = client.DownloadString(indexUrl);
            Logger.logMessage("[AssetIndex]", origJson);

            JObject origObj = JsonConvert.DeserializeObject<JObject>(origJson);
            var origProps = origObj.Properties();

            foreach (var oProp in origProps)
            {
                string oKey = oProp.Name;
                string oVal = oProp.Value.ToString();

                if (oKey == "virtual" && oVal == "True")
                {
                    isLegacy = true;
                    Logger.logMessage("[AssetIndex]", "isLegacy returned true!");
                }
                else if (oKey == "objects")
                {
                    string indexJson = oVal;

                    JObject assetObj = JsonConvert.DeserializeObject<JObject>(indexJson);
                    var assetProps = assetObj.Properties();
                    foreach (var aProp in assetProps)
                    {
                        string aKey = aProp.Name;
                        object aVal = aProp.Value;

                        //Logger.logError("[AssetIndex]", $"Loaded asset object: {aKey}; {aVal}");

                        JObject itemObj = JsonConvert.DeserializeObject<JObject>(aVal.ToString());
                        var itemProps = itemObj.Properties();
                        foreach (var iProp in itemProps)
                        {
                            if(iProp.Name == "hash")
                            {
                                //string iKey = iProp.Name;
                                object iVal = iProp.Value;

                                //Logger.logError("[AssetIndex]", $"Loaded key object: {iKey}; {iVal}");

                                Logger.logMessage("[AssetIndex]", $"Name: {aKey}; hash: {iVal}");
                                nameList.Add(aKey);
                                hashList.Add(iVal.ToString());
                            }
                        }
                    }
                }
                else
                {
                    Logger.logError("[AssetIndex]", $"Unknown key: {oKey}, with value: {oVal}");
                }


                if (isLegacy == true)
                {
                    int indexInt = 0;
                    WebClient wc = new WebClient();
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

                        //Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\assets\\{indexName}");

                        if (!File.Exists($"{Globals.currentPath}\\.codexipsa\\assets\\{indexName}\\{fileDirectory}\\{fileName}"))
                        {
                            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\assets\\{indexName}\\{fileDirectory}");
                            wc.DownloadFile($"http://resources.download.minecraft.net/{firstTwo}/{fullHash}", $"{Globals.currentPath}\\.codexipsa\\assets\\{indexName}\\{fileDirectory}\\{fileName}");
                            Logger.logMessage("[AssetIndex]", $"Downloaded {fileName} to {fileDirectory}");
                        }
                        isLegacy = false;

                        //isLegacy = false;
                        //Logger.logError("[AssetIndex]", $"Name: {name}; hash: {fullHash}");
                        indexInt++;
                    }
                    indexInt = 0;
                    hashList.Clear();
                    nameList.Clear();
                    //TODO: copy to .minecraft/assets for versions that don't support --assetsDir
                }
                else
                {
                    //TODO: for versions past 1.7 (?) do the new system
                }
            }
        }
    }
}
