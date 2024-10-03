using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.classes
{
    internal class Themes
    {
        public static String stonePath = "D:\\dejvoss.cz\\subdom\\codex-ipsa\\launcher\\seasonal\\stone2.png";
        public static Image stone = Image.FromFile(stonePath);
        public static String dirtPath = "D:\\dejvoss.cz\\subdom\\codex-ipsa\\launcher\\seasonal\\dirt7.png";
        public static Image dirt = Image.FromFile(dirtPath);

        public static void loadTheme()
        {
            Logger.Info("[Theme]", "Loading a theme...");
            Directory.CreateDirectory($"{Globals.dataPath}\\themes\\");

            //if seasonal theme
            if (!Settings.sj.seasonalOptout)
            {
                //Globals.client.DownloadFile("", "");
                Logger.Info("[Theme]", "Seasonal theme loaded!");
                return;
            }

            //if user theme
            if (Settings.sj.useTheme && Settings.sj.themePath != String.Empty)
            {

                Logger.Info("[Theme]", "Custom theme loaded!");
                return;
            }

            //if both fail, load default

            Logger.Info("[Theme]", "Default theme loaded!");
            return;
        }
    }
}
