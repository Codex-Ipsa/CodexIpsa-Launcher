using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MCLauncher
{
    public class AssetIndex
    {
        public static void Start(string indexUrl, string indexName)
        {
            Directory.CreateDirectory($"{Globals.dataPath}\\assets\\indexes\\");

            if (!File.Exists($"{Globals.dataPath}\\assets\\indexes\\{indexName}.json"))
            {
                Globals.client.DownloadFile(indexUrl, $"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");
            }
            else
            {
                FileInfo fi = new FileInfo($"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(indexUrl);
                req.Method = "HEAD";
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); //fix rate limit
                long urlSize = resp.ContentLength;

                if (urlSize != fi.Length)
                {
                    Logger.Info("AssetIndex", "Index has changed! Redownloading json.");
                    File.Delete($"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");
                    Globals.client.DownloadFile(indexUrl, $"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");
                }
            }

            string manifest = File.ReadAllText($"{Globals.dataPath}\\assets\\indexes\\{indexName}.json");

            var data = (JObject)JsonConvert.DeserializeObject(manifest);
            Dictionary<string, AssetIndexObject> dict = JsonConvert.DeserializeObject<Dictionary<string, AssetIndexObject>>(data["objects"].ToString());

            bool isVirt = false;
            if (data["virtual"] != null)
                isVirt = true;

            foreach (KeyValuePair<string, AssetIndexObject> entry in dict)
            {
                string filePath = "";
                string firstTwo = entry.Value.hash.Substring(0, 2);
                if (isVirt)
                {
                    filePath = $"{Globals.dataPath}/assets/virtual/{indexName}/{entry.Key}";
                }
                else
                {
                    filePath = $"{Globals.dataPath}/assets/objects/{firstTwo}/{entry.Value.hash}";
                }

                Logger.Info("AssetIndex", $"Downloading assets... This may take a while...");
                if (!File.Exists(filePath))
                {
                    string path = filePath.Substring(0, filePath.LastIndexOf("/"));
                    Directory.CreateDirectory(path);
                    Globals.client.DownloadFile($"https://resources.download.minecraft.net/{firstTwo}/{entry.Value.hash}", filePath);
                }
                else
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Length != entry.Value.size)
                    {
                        Logger.Error("AssetIndex", $"Bad item: {entry.Key} {fi.Length}::{entry.Value.size}");
                        File.Delete(filePath);
                        Globals.client.DownloadFile($"https://resources.download.minecraft.net/{firstTwo}/{entry.Value.hash}", filePath);
                        Logger.Info("AssetIndex", $"Redownloaded {entry.Key}");
                    }
                }
            }
        }
    }

    public class AssetIndexManifest
    {
        public AssetIndexObject objects { get; set; }
        public bool isVirtual { get; set; }
    }

    public class AssetIndexObject
    {
        public int size { get; set; }
        public string hash { get; set; }
        public string custom_url { get; set; }
    }
}
