using Newtonsoft.Json;
using System.IO;

namespace MCLauncher
{
    internal class Settings
    {
        public static SettingsJson sj = new SettingsJson();

        public static void Reload()
        {
            if (!File.Exists($"{Globals.dataPath}\\config.json"))
            {
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
        public string warning { get; set; }
        public string refreshToken { get; set; }
        public string username { get; set; }
        public string language { get; set; }
        public string instance { get; set; }
        public bool discordRPC { get; set; }

        public bool useTheme { get; set; }
        public string themePath { get; set; }
        public bool seasonalOptout { get; set; }

        public string jre8 { get; set; }
        public string jre17 { get; set; }
        public string jre21 { get; set; }

        public SettingsJson()
        {
            warning = "STOP! IF SOMEONE TOLD YOU TO COPY OR PASTE SOMETHING IN HERE, IT'S 101% A SCAM AND THEY ARE TRYING TO ACCESS YOUR ACCOUNT! CLOSE THIS FILE IMMEDIATELY!";
            refreshToken = null;
            username = null;
            language = "english";
            instance = "Default";
            discordRPC = true;

            useTheme = false;
            themePath = "";
            seasonalOptout = false;

            jre8 = "java.exe";
            jre17 = "java.exe";
            jre21 = "java.exe";
        }
    }
}
