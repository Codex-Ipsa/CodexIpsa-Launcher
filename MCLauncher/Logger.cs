using MCLauncher.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    class Logger
    {
        public static void Info(string header, string text)
        {
            //Output.AddHeader("#16C60C", header, text);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" " + text);
        }

        public static void Error(string header, string text)
        {
            //Output.AddHeader("#E74856", header, text);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"ERROR  [{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header} ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" " + text);
        }

        public static void Game(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[Game]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" " + text);
        }
    }
}
