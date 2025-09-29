using MCLauncher.forms;
using MCLauncher.json.api;
using MCLauncher.json.fabric;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using static MCLauncher.forms.ModLoaders;

namespace MCLauncher.launchers.fabric
{
    internal class FabricWorker
    {
        //check if fabric is available
        public static ModLoaders.LoaderType isAvailable(String version)
        {
            //check for reupload name first
            String fabricVersion = getFabricName(version);

            //get game manifest
            if (Globals.offlineMode)
            {
                return ModLoaders.LoaderType.None;
            }

            //fabric type
            List<FabricGameJson> fabricJson = getFabricJson($"{getMetaUrl(LoaderType.Fabric)}/versions/game");
            List<FabricGameJson> babricJson = getFabricJson($"{getMetaUrl(LoaderType.Babric)}/versions/game");
            List<FabricGameJson> legacyfabricJson = getFabricJson($"{getMetaUrl(LoaderType.LegacyFabric)}/versions/game");

            //check if version exists
            foreach (FabricGameJson ver in fabricJson)
            {
                if (ver.version == fabricVersion)
                {
                    return ModLoaders.LoaderType.Fabric;
                }
            }

            foreach (FabricGameJson ver in babricJson)
            {
                if (ver.version == fabricVersion)
                {
                    return ModLoaders.LoaderType.Babric;
                }
            }

            foreach (FabricGameJson ver in legacyfabricJson)
            {
                if (ver.version == fabricVersion)
                {
                    return ModLoaders.LoaderType.LegacyFabric;
                }
            }

            return ModLoaders.LoaderType.None;
        }

        

        private static List<FabricGameJson> getFabricJson(String url)
        {
            String manifest = Globals.client.DownloadString(url);

            return JsonConvert.DeserializeObject<List<FabricGameJson>>(manifest);
        }

        //get list of fabric loader versions for game version (version)
        public static List<String> getLoaderVersions(String version, ModLoaders.LoaderType loaderType)
        {
            //check for reupload name first
            String fabricVersion = getFabricName(version);

            //get loader manifest
            String manifest = Globals.client.DownloadString($"{getMetaUrl(loaderType)}/versions/loader/{fabricVersion}");
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
            if (Globals.offlineMode)
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
        public static String createModJson(String gameVersion, String loaderVersion, ModLoaders.LoaderType loaderType)
        {
            //check for reupload name first
            String fabricVersion = getFabricName(gameVersion);

            //get fabric ver json
            string versionInfo = Globals.client.DownloadString($"{getMetaUrl(loaderType)}/versions/loader/{fabricVersion}/{loaderVersion}/profile/json");
            FabricVersionJson fabricJson = JsonConvert.DeserializeObject<FabricVersionJson>(versionInfo);

            //get ipsa ver json
            string ipsaManifest = Globals.client.DownloadString(Globals.javaInfo.Replace("{type}", "java").Replace("{ver}", gameVersion));
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

        public static String getMetaUrl(ModLoaders.LoaderType loaderType)
        {
            if (loaderType == ModLoaders.LoaderType.Babric)
                return "https://meta.babric.glass-launcher.net/v2";
            else if (loaderType == ModLoaders.LoaderType.LegacyFabric)
                return "https://meta.legacyfabric.net/v2";
            else
                return "https://meta.fabricmc.net/v2";
        }
    }
}
