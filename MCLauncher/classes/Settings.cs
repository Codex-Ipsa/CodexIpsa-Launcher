using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;

namespace MCLauncher
{
    internal class Settings
    {
        public static SettingsJson sj = new SettingsJson();

        public static void Reload()
        {
            string json = File.ReadAllText($"{Globals.dataPath}\\config.json");
            sj = JsonConvert.DeserializeObject<SettingsJson>(json);
        }

        public static void Save()
        {
            string json = JsonConvert.SerializeObject(sj);
            File.WriteAllText($"{Globals.dataPath}\\config.json", json);
        }
    }

    public class SettingsJson
    {
        public string refreshToken { get; set; }
        public string language { get; set; }
        public string instance { get; set; }
    }
}
