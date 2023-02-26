using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace MCLauncher
{
    internal class SettingData
    {
        public static string playerRefreshToken = "";
        public static string preferredLanguage = "";

        public static void refData()
        {
            byte[] text = File.ReadAllBytes($"{Globals.dataPath}\\settings.cfg");
            string data = BitConverter.ToString(text);
            string[] vars = data.Split(';');
            int i = 0;
            foreach (string v in vars)
            {
                if (i == 0)
                    playerRefreshToken = v;
                else if(i == 1)
                    preferredLanguage = v;
            }
        }

        public static void saveData(string token, string lang)
        {
            var text = Encoding.UTF8.GetBytes($"{token};{lang};Codex-Ipsa");
            string base64 = Convert.ToBase64String(text);
            Logger.Info("[SettingData]", "Saving data..");
            File.WriteAllText($"{Globals.dataPath}\\settings.cfg", base64);
        }
    }
}
