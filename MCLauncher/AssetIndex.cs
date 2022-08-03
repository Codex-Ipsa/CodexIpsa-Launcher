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
        public static string testurl = "https://launchermeta.mojang.com/v1/packages/770572e819335b6c0a053f8378ad88eda189fc14/legacy.json";

        public static void downloadIndex()
        {
            List<string> list1 = new List<string>();
            WebClient wc = new WebClient();
            //string json = "{ProdId:\"1\",Title:\"C#\",Author:\"Jeffy\",Publisher:\"XYZ\",Category:\"Microsoft\"}";
            string json = wc.DownloadString(testurl);
            JObject obj = JsonConvert.DeserializeObject<JObject>(json);
            var properties = obj.Properties();

            string finalJson = "[\n";
            foreach (var prop in properties)
            {
                string key = prop.Name;
                object value = prop.Value;
                //Console.WriteLine("THIS IS A START+" + value.ToString());

                string assets = value.ToString();
                if (assets.Contains("icon_16x16.png"))
                {
                    JObject obj2 = JsonConvert.DeserializeObject<JObject>(assets);
                    var properties2 = obj2.Properties();
                    foreach (var prop2 in properties2)
                    {
                        string key2 = prop2.Name;
                        object value2 = prop2.Value;
                        list1.Add(value2.ToString());
                        //Console.WriteLine("THIS IS A START+" + value.ToString());

                        //Console.WriteLine(key + "=" + value);
                    }
                    foreach (var val in list1)
                    {
                        //Console.WriteLine(val + ",");
                        finalJson += val.ToString() + ",";
                    }
                    finalJson += "\n]";
                    //Console.WriteLine(finalJson);
                }
                //Console.WriteLine(key + "=" + value);
            }

            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(finalJson);

            foreach (var vers in data)
            {
                string firstTwo = vers.hash.Substring(0, 2);
                string fullHash = vers.hash;
                //Console.WriteLine("First two: " + firstTwo);
                //Console.WriteLine("Full hash: " + fullHash);

                if (!File.Exists($"{Globals.currentPath}\\assetstest\\objects\\{firstTwo}\\{fullHash}"))
                {

                    using (WebClient client = new WebClient())
                    {
                        Directory.CreateDirectory($"{Globals.currentPath}\\assetstest\\objects\\{firstTwo}");
                        client.DownloadFile($"http://resources.download.minecraft.net/{firstTwo}/{fullHash}", $"{Globals.currentPath}\\assetstest\\objects\\{firstTwo}\\{fullHash}");
                        Console.WriteLine("Downloaded: " + fullHash + "\n");
                    }
                }
                else
                {
                    //Do nothing
                    //Console.WriteLine("Already exists!\n");
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
