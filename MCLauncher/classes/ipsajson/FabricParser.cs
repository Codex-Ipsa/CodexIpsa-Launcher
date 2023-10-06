using MCLauncher.forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            foreach(FabricGame loader in loaderManifest)
            {
                list.Add(loader.version);
            }

            return list;
        }

    }

    public class FabricGame
    {
        public string version { get; set; }
        public bool stable { get; set; }
    }
}
