using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    class Logger
    {
        public static void logMessage(string header, string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(header);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" " + text);
        }

        public static void logError(string header, string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(header);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" " + text);
        }

        public static void logGame(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[Game]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" " + text);
        }
    }
}
