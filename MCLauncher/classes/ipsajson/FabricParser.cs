using MCLauncher.json.api;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MCLauncher.classes.ipsajson
{
    internal class FabricParser
    {
        public static List<string> GetList()
        {
            WebClient client = new WebClient();

            string gameJson = client.DownloadString("https://meta.fabricmc.net/v2/versions/game");
            List<FabricGame> gameManifest = JsonConvert.DeserializeObject<List<FabricGame>>(gameJson);

            string loaderJson = client.DownloadString("https://meta.fabricmc.net/v2/versions/loader");
            List<FabricGame> loaderManifest = JsonConvert.DeserializeObject<List<FabricGame>>(loaderJson);

            List<string> list = new List<string>();
            foreach (FabricGame loader in loaderManifest)
            {
                list.Add(loader.version);
            }

            return list;
        }

        public static string versionJson(string gameVer, string loaderVer)
        {
            WebClient client = new WebClient();

            string reuploadsJson = client.DownloadString(Globals.reuploadsManifest);
            List<ReuploadsManifest> reuploadsManifest = JsonConvert.DeserializeObject<List<ReuploadsManifest>>(reuploadsJson);

            foreach (ReuploadsManifest reup in reuploadsManifest)
            {
                Logger.Error("[FabricParser]", $"{reup.ipsa} {gameVer}");
                if (reup.ipsa == gameVer)
                {
                    gameVer = reup.mojang;
                }
            }

            string versionInfo = client.DownloadString($"https://meta.fabricmc.net/v2/versions/loader/{gameVer}/{loaderVer}/profile/json");
            FabricManifest versionManifest = JsonConvert.DeserializeObject<FabricManifest>(versionInfo);

            foreach (ReuploadsManifest reup in reuploadsManifest)
            {
                if (reup.mojang == versionManifest.inheritsFrom)
                    versionManifest.inheritsFrom = reup.ipsa;
            }

            string ipsaJson = client.DownloadString($"http://codex-ipsa.dejvoss.cz/launcher/codebase/{Globals.codebase}/data/{versionManifest.inheritsFrom}.json");
            VersionJson ipsaManifest = JsonConvert.DeserializeObject<VersionJson>(ipsaJson);

            ipsaManifest.classpath = versionManifest.mainClass;
            ipsaManifest.game = "Fabric";
            ipsaManifest.version = $"{gameVer}-{loaderVer}";

            List<VersionJsonLibraries> list = ipsaManifest.libraries.ToList();
            foreach (FabricManifestLibrary lib in versionManifest.libraries)
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

            ipsaManifest.libraries = list.ToArray();
            string json = JsonConvert.SerializeObject(ipsaManifest);

            return json;
        }

    }

    public class FabricGame
    {
        public string version { get; set; }
        public bool stable { get; set; }
    }

    public class FabricManifest
    {
        public string id { get; set; }
        public string inheritsFrom { get; set; }
        public string releaseTime { get; set; }
        public string mainClass { get; set; }
        public FabricManifestLibrary[] libraries { get; set; }
    }
    public class FabricManifestLibrary
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class ReuploadsManifest
    {
        public string mojang { get; set; }
        public string ipsa { get; set; }
    }
}
