using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    class Logger
    {
        public static void log(ConsoleColor headerColor, ConsoleColor textColor, string header, string text)
        {
            Console.ForegroundColor = headerColor;
            Console.Write(header);
            Console.ForegroundColor = textColor;
            Console.WriteLine(" " + text);
        }

        public static void gameLog(string source, string text)
        {
            Console.WriteLine(text);
        }
    }
}
