using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.classes
{
    class DownloadJava
    {
        public static void Start()
        {
            string manifest = Globals.client.DownloadString("https://launchermeta.mojang.com/v1/packages/ddc568a50326d2cf85765abb61e752aab191c366/manifest.json");

            JObject origObj = JsonConvert.DeserializeObject<JObject>(manifest);
            var origProps = origObj.Properties();

            Directory.CreateDirectory($"{Globals.dataPath}\\data\\jre\\");

            foreach (var oProp in origProps)
            {
                string oKey = oProp.Name;
                string oVal = oProp.Value.ToString();

                if (oKey == "files")
                {
                    string indexJson = oVal;
                    JObject assetObj = JsonConvert.DeserializeObject<JObject>(indexJson);
                    var assetProps = assetObj.Properties();
                    foreach (var aProp in assetProps)
                    {
                        string aKey = aProp.Name;
                        object aVal = aProp.Value;
                        var j = JsonConvert.DeserializeObject<ManifestJson>(aVal.ToString());
                        if (j.type == "file")
                        {
                            Console.WriteLine(j.downloads.raw.url);
                            Globals.client.DownloadFile(j.downloads.raw.url, $"{Globals.dataPath}\\data\\jre\\{aKey.ToString()}");
                        }
                        else if (j.type == "directory")
                        {
                            Directory.CreateDirectory($"{Globals.dataPath}\\data\\jre\\{aKey.ToString()}");
                        }
                    }
                }
            }
        }
    }

    public class ManifestJson
    {
        public ManifestJsonFile downloads { get; set; }
        public string type { get; set; }
    }

    public class ManifestJsonFile
    {
        public ManifestJsonRaw raw { get; set; }
    }

    public class ManifestJsonRaw
    {
        public string url { get; set; }
    }
}
