using MCLauncher.classes;
using MCLauncher.json.api;
using MCLauncher.json.fabric;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if(Globals.offlineMode)
            {
                return false;
            }
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
            if(Globals.offlineMode)
            {
                return "null";
            }
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

        //creates the mod json to use
        public static String createModJson(String gameVersion, String loaderVersion)
        {
            //check for reupload name first
            String fabricVersion = getFabricName(gameVersion);

            //get fabric ver json
            string versionInfo = Globals.client.DownloadString($"https://meta.fabricmc.net/v2/versions/loader/{fabricVersion}/{loaderVersion}/profile/json");
            FabricVersionJson fabricJson = JsonConvert.DeserializeObject<FabricVersionJson>(versionInfo);

            //get ipsa ver json
            string ipsaManifest = Globals.client.DownloadString($"http://codex-ipsa.dejvoss.cz/launcher/codebase/{Globals.codebase}/java/{gameVersion}.json");
            VersionJson ipsaJson = JsonConvert.DeserializeObject<VersionJson>(ipsaManifest);

            //replace ipsa info with fabric stuff
            ipsaJson.classpath = fabricJson.mainClass;

            List<VersionJsonLibraries> list = ipsaJson.libraries.ToList();
            foreach (FabricLibsJson lib in fabricJson.libraries)
            {
                string[] names = lib.name.Split(':');
                string[] paths = names[0].Split('.');

                string fullUrl = lib.url;
                foreach (string path in paths)
                {
                    fullUrl += path + "/";
                }

                fullUrl += $"{names[1]}/{names[2]}/{names[1]}-{names[2]}.jar";

                string libname = $"{names[1]}-{names[2]}";

                //Console.WriteLine(fullUrl);

                VersionJsonLibraries newOne = new VersionJsonLibraries();
                newOne.name = libname;
                newOne.url = fullUrl;
                newOne.size = 0;
                newOne.extract = false;

                list.Add(newOne);
            }

            ipsaJson.libraries = list.ToArray();
            string json = JsonConvert.SerializeObject(ipsaJson);

            return json;
        }
    }
}
