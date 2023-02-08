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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" " + text);
        }

        public static void Error(string header, string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header} ERROR:");
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
