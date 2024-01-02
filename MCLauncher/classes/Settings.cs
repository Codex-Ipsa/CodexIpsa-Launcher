using System.IO;
using Newtonsoft.Json;

namespace MCLauncher
{
    internal class Settings
    {
        public static SettingsJson sj = new SettingsJson();

        public static void Reload()
        {
            if(!File.Exists($"{Globals.dataPath}\\config.json"))
            {
                sj.refreshToken = Properties.Settings.Default.msRefreshToken;
                sj.language = Properties.Settings.Default.prefLanguage;
                sj.instance = Properties.Settings.Default.lastInstance;
                sj.discordRPC = Properties.Settings.Default.discordRpc;
                sj.jre8 = Properties.Settings.Default.jre8;
                sj.jre17 = Properties.Settings.Default.jre17;

                string toSave = JsonConvert.SerializeObject(sj);
                File.WriteAllText($"{Globals.dataPath}\\config.json", toSave);
            }

            string toLoad = File.ReadAllText($"{Globals.dataPath}\\config.json");
            sj = JsonConvert.DeserializeObject<SettingsJson>(toLoad);
        }

        public static void Save()
        {
            string toSave = JsonConvert.SerializeObject(sj);
            File.WriteAllText($"{Globals.dataPath}\\config.json", toSave);
        }
    }

    public class SettingsJson
    {
        public string refreshToken { get; set; }
        public string language { get; set; }
        public string instance { get; set; }
        public bool discordRPC { get; set; }
        public string jre8 { get; set; }
        public string jre17 { get; set; }
    }
}
