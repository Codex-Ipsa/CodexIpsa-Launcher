using MCLauncher.classes;
using MCLauncher.json.fabric;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MCLauncher.launchers.fabric
{
    internal class FabricWorker
    {
        //check if fabric is available
        public static bool isAvailable(String version)
        {
            //check for reupload name first
            String fabricVersion = getFabricName(version);

            //get game manifest
            String manifest = Globals.client.DownloadString("https://meta.fabricmc.net/v2/versions/game");
            List<FabricGameJson> gj = JsonConvert.DeserializeObject<List<FabricGameJson>>(manifest);

            //check if version exists
            foreach (FabricGameJson ver in gj)
            {
                if (ver.version == fabricVersion)
                {
                    return true;
                }
            }

            return false;
        }

        //get list of fabric loader versions for game version (version)
        public static List<String> getLoaderVersions(String version)
        {
            //check for reupload name first
            String fabricVersion = getFabricName(version);

            //get loader manifest
            String manifest = Globals.client.DownloadString($"https://meta.fabricmc.net/v2/versions/loader/{fabricVersion}");
            List<FabricLoaderJson> lj = JsonConvert.DeserializeObject<List<FabricLoaderJson>>(manifest);

            //add loader vers to list
            List<String> lst = new List<String>();
            foreach (FabricLoaderJson ver in lj)
            {
                lst.Add(ver.loader.version);
            }

            return lst;
        }

        //gets fabric name of version (reuploads handling)
        public static String getFabricName(String version)
        {
            //get fabric reuploads manifest
            String manifest = Globals.client.DownloadString(Globals.fabricReuploads);
            List<FabricReuploadsJson> frj = JsonConvert.DeserializeObject<List<FabricReuploadsJson>>(manifest);

            //check for names
            foreach (FabricReuploadsJson f in frj)
            {
                if (version == f.ipsa)
                {
                    return f.fabric;
                }
            }

            return version;

        }
    }
}
