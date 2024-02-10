using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetDefaultFont(new Font(new FontFamily("Microsoft Sans Serif"), 8f));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Logger.logMessage("[Startup]", "Launch args: " + args.Length);
            if (args.Length > 0)
            {
                foreach(string arg in args)
                {
                    if(arg == "-debug")
                    {
                        Globals.isDebug = true;
                        Logger.Info("[Startup]", $"Starting in debug mode...");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n __    __   ____  ____   ____   ____  ____    ____ \n|  |__|  | /    ||    \\ |    \\ |    ||    \\  /    |\n|  |  |  ||  o  ||  D  )|  _  | |  | |  _  ||   __|\n|  |  |  ||     ||    / |  |  | |  | |  |  ||  |  |\n|  `  '  ||  _  ||    \\ |  |  | |  | |  |  ||  |_ |\n \\      / |  |  ||  .  \\|  |  | |  | |  |  ||     |\n  \\_/\\_/  |__|__||__|\\_||__|__||____||__|__||___,_|\nWARNING: USING DEBUG MODE CAN REVEAL VARIOUS INFORMATION SUCH AS YOUR LOGIN DETAILS!\nDO NOT COPY ANYTHING FROM HERE!\n");
                        Console.ForegroundColor= ConsoleColor.Gray;
                    }
                    else
                    {
                        Logger.Error("[Startup]", $"Unknown argument: {arg}");
                    }
                }
            }
            Application.Run(new MainWindow());
            //Application.Run(new NewUI());
        }
    }
}
