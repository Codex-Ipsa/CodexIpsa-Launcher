using System;
using System.Collections.Generic;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Logger.logMessage("[Startup]", "Launch args: " + args.Length);
            if(args.Length > 0)
            {
                foreach(string arg in args)
                {
                    if(arg == "-debug")
                    {
                        Globals.isDebug = true;
                        Logger.logMessage("[Startup]", $"Starting in debug mode...");
                    }
                    else
                    {
                        Logger.logError("[Startup]", $"Unknown argument: {arg}");
                    }
                }
            }
            Application.Run(new MainWindow());
            //Application.Run(new NewUI());
        }
    }
}
