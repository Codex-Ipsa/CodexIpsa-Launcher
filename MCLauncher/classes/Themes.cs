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
        public static String stonePath = "";
        public static Image stone = Image.FromFile(stonePath);
        public static String grassPath = "";
        public static Image grass = Image.FromFile(grassPath);

        public static void loadTheme()
        {
            Directory.CreateDirectory($"{Globals.dataPath}\\themes\\");

            //if seasonal theme
            if (!Settings.sj.seasonalOptout)
            {
                //Globals.client.DownloadFile("", "");
                return;
            }

            //if user theme
            if (Settings.sj.useTheme && Settings.sj.themePath != String.Empty)
            {

                return;
            }

            //if both fail, load default

            return;
        }
    }
}
