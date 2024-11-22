using MCLauncher.classes;
using System;
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

            Logger.Info($"[Startup]", $"Codex-Ipsa Launcher has started!");
            Logger.Info($"[Startup]", $"Version {Globals.verDisplay}, Branch {Globals.branch}");
            Console.Title = $"Codex-Ipsa Launcher v{Globals.verDisplay} [branch {Globals.branch}] CONSOLE";

            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (arg == "-debug")
                    {
                        Globals.isDebug = true;
                        Logger.Info("[Startup]", $"Starting in debug mode...");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n __    __   ____  ____   ____   ____  ____    ____ \n|  |__|  | /    ||    \\ |    \\ |    ||    \\  /    |\n|  |  |  ||  o  ||  D  )|  _  | |  | |  _  ||   __|\n|  |  |  ||     ||    / |  |  | |  | |  |  ||  |  |\n|  `  '  ||  _  ||    \\ |  |  | |  | |  |  ||  |_ |\n \\      / |  |  ||  .  \\|  |  | |  | |  |  ||     |\n  \\_/\\_/  |__|__||__|\\_||__|__||____||__|__||___,_|\nWARNING: USING DEBUG MODE CAN REVEAL VARIOUS INFORMATION SUCH AS YOUR LOGIN DETAILS!\nDO NOT COPY ANYTHING FROM HERE!\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (arg.StartsWith("-instance="))
                    {
                        String instanceName = arg.Substring(arg.IndexOf('=') + 1);
                        Logger.Info("[Startup]", $"Starting nogui mode with instance {instanceName}");

                        //Application.Run(new MainWindow());
                        //HomeScreen.Instance.Hide();

                        //TODO auth fails
                        //TODO count and add playtime 
                        //TODO discord RPC

                        JavaLauncher.Launch(instanceName);
                        Console.ReadLine(); //TEMP
                        return;
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
