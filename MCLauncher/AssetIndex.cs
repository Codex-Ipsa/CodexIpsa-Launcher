using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MCLauncher
{
    public class AssetIndex
    {
        public static string testurl = "https://launchermeta.mojang.com/v1/packages/770572e819335b6c0a053f8378ad88eda189fc14/legacy.json";

        public static void downloadIndex()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(testurl);
                string json2 = $"[{json}]";

                using (var sr = new StringReader(json2))
                using (var jr = new JsonTextReader(sr))
                {
                    var serial = new JsonSerializer();
                    serial.Formatting = Formatting.Indented;
                    var obj = serial.Deserialize<assetIndexJson>(jr);

                    var reserializedJSON = JsonConvert.SerializeObject(obj, Formatting.Indented);

                    Console.WriteLine("Re-serialized JSON: ");
                    Console.WriteLine(reserializedJSON);
                }
            }
        }
    }

    class assetIndexJson
    {
        public Dictionary<string, List<assetIndexObj>> objects { get; set; }
    }

    class assetIndexObj
    {
        public string hash { get; set; }
        public int size { get; set; }
    }
}
