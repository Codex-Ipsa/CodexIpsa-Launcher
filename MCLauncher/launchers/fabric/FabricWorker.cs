using MCLauncher.classes;
using MCLauncher.json.fabric;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MCLauncher.launchers.fabric
{
    internal class FabricWorker
    {
        public static bool isAvailable(String version)
        {
            String manifest = Globals.client.DownloadString("https://meta.fabricmc.net/v2/versions/game");
            List<FabricGameJson> gj = JsonConvert.DeserializeObject<List<FabricGameJson>>(manifest);

            foreach (FabricGameJson ver in gj)
            {
                if (ver.version == version)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<String> loaderVersions(String version)
        {
            //check for reupload name first
            String ipsaVersion = getFabricName(version);

            //get loader manifest
            //String manifest = Globals.client.DownloadString($"https://meta.fabricmc.net/v2/versions/loader/{version}");
            //List<FabricGameJson> gj = JsonConvert.DeserializeObject<List<FabricGameJson>>(manifest);

            //foreach (FabricGameJson ver in gj)
            //{
            //    if (ver.version == version)
            //    {
            //        return true;
            //    }
            //}

            return new List<string> { "" };
        }

        public static String getFabricName(String version)
        {
            String manifest = Globals.client.DownloadString(Globals.fabricReuploads);
            List<FabricReuploadsJson> frj = JsonConvert.DeserializeObject<List<FabricReuploadsJson>>(manifest);

            foreach (FabricReuploadsJson f in frj)
            {
                //Console.WriteLine("1!");
                if (version == f.ipsa)
                {
                    Console.WriteLine("aaah!");
                    return f.fabric;
                }
            }

            return version;

        }
    }
}
