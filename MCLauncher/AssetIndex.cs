using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
                //Logger.log(ConsoleColor.Green, ConsoleColor.Gray, "[AssetIndex]", $"Donloaded index content: {json}");
               // Logger.log(ConsoleColor.Green, ConsoleColor.Gray, "[AssetIndex]", $"End of index content");
                
                string s = json.Replace("{\"objects\": ", "\"objects\": ");
                string s2 = s.Replace("}, \"virtual\": true}", "}, \"virtual\": true");

                Logger.logMessage("[AssetIndex]", $"Fixed index content: [{s2}]");

                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>($"[{s2}]");



                foreach (var vers in data)
                {
                    
                    Logger.logMessage("[AssetIndex]", $"Ver: {vers.objects}");
                }
            }
        }
    }
}
