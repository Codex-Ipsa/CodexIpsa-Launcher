using MCLauncher.json.launcher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;

namespace MCLauncher.classes
{
    internal class Themes
    {
        public static String stonePath = null;
        public static Image stone;
        public static String dirtPath = null;
        public static Image dirt;

        //TODO: HOT RELOAD THEMES WHEN USER DOES STUFF WITH CHECKBOX ETC

        public static void loadTheme()
        {
            Logger.Info("[Theme]", "Loading a theme...");
            Directory.CreateDirectory($"{Globals.dataPath}\\themes\\");

            //if seasonal theme
            if (!Settings.sj.seasonalOptout && !Globals.noInternet)
            {
                String seasonalManifest = Globals.client.DownloadString(Globals.seasonalManifest);
                List<ThemesJson> tjl = JsonConvert.DeserializeObject<List<ThemesJson>>(seasonalManifest);

                DateTime dt = DateTime.UtcNow;

                foreach (ThemesJson tj in tjl)
                {
                    foreach (String date in tj.dates)
                    {
                        if (dt.ToString("dd-MM-yyyy").StartsWith(date))
                        {
                            if (Directory.Exists($"{Globals.dataPath}\\themes\\{tj.id}\\"))
                                Directory.Delete($"{Globals.dataPath}\\themes\\{tj.id}\\", true);

                            Globals.client.DownloadFile(tj.url, $"{Globals.dataPath}\\themes\\{tj.id}.zip");
                            ZipFile.ExtractToDirectory($"{Globals.dataPath}\\themes\\{tj.id}.zip", $"{Globals.dataPath}\\themes\\{tj.id}\\");
                            File.Delete($"{Globals.dataPath}\\themes\\{tj.id}.zip");

                            dirtPath = $"{Globals.dataPath}\\themes\\{tj.id}\\dirt.png";
                            stonePath = $"{Globals.dataPath}\\themes\\{tj.id}\\stone.png";

                            Logger.Info("[Theme]", "Seasonal theme loaded!");
                            break;
                        }
                    }
                }
            }

            //if user theme
            if (Settings.sj.useTheme && Settings.sj.themePath != String.Empty)
            {
                if (dirtPath != null || stonePath != null)
                {
                    goto final;
                }

                if (Directory.Exists($"{Globals.dataPath}\\themes\\custom\\"))
                    Directory.Delete($"{Globals.dataPath}\\themes\\custom\\", true);

                Directory.CreateDirectory($"{Globals.dataPath}\\themes\\custom\\");
                ZipFile.ExtractToDirectory(Settings.sj.themePath, $"{Globals.dataPath}\\themes\\custom\\");

                dirtPath = $"{Globals.dataPath}\\themes\\custom\\dirt.png";
                stonePath = $"{Globals.dataPath}\\themes\\custom\\stone.png";

                Logger.Info("[Theme]", "Custom theme loaded!");
            }

        final:

            //if both fail, load default
            if (stonePath == null || dirtPath == null)
            {
                stone = Properties.Resources.stone;
                dirt = Properties.Resources.dirt;

                stonePath = "http://files.codex-ipsa.cz/seasonal/defaultStone.png";
                Logger.Info("[Theme]", "Default theme loaded!");
            }
            //and if everything goes well, load theme textures to Image()
            else
            {
                stone = Image.FromFile(stonePath);
                dirt = Image.FromFile(dirtPath);
            }
        }
    }
}
