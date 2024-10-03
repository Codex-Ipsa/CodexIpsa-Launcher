using MCLauncher.json.launcher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.classes
{
    internal class Themes
    {
        public static String stonePath = null;
        public static Image stone;
        public static String dirtPath = null;
        public static Image dirt;

        public static void loadTheme()
        {
            Logger.Info("[Theme]", "Loading a theme...");
            Directory.CreateDirectory($"{Globals.dataPath}\\themes\\");

            //if seasonal theme
            if (!Settings.sj.seasonalOptout)
            {
                String seasonalManifest = Globals.client.DownloadString(Globals.seasonalManifest);
                List<ThemesJson> tjl = JsonConvert.DeserializeObject<List<ThemesJson>>(seasonalManifest);

                DateTime dt = DateTime.Now;

                foreach (ThemesJson tj in tjl)
                {
                    foreach (String date in tj.dates)
                    {
                        if (dt.ToString("dd-MM-yyyy").StartsWith(date))
                        {
                            Console.WriteLine("GOT DATE! WOOO! DO FUNNY STUFF HERE!");
                            break;
                        }
                    }
                }

                //Globals.client.DownloadFile("", "");
                Logger.Info("[Theme]", "Seasonal theme loaded!");
            }
            //if user theme
            else if (Settings.sj.useTheme && Settings.sj.themePath != String.Empty)
            {

                Logger.Info("[Theme]", "Custom theme loaded!");
            }

            //if both fail, load default
            if (stonePath == null || dirtPath == null)
            {
                dirtPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"../../res/dirt.png");
                stonePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"../../res/stone.png");
                Logger.Info("[Theme]", "Default theme loaded!");
            }

            //finally load textures to Image()
            stone = Image.FromFile(stonePath);
            dirt = Image.FromFile(dirtPath);
        }
    }
}
