using MCLauncher.classes;
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
            if (text != null && JavaLauncher.msPlayerAccessToken != null && JavaLauncher.msPlayerUUID != null)
                text = text.Replace(JavaLauncher.msPlayerAccessToken, "[ACCESS_TOKEN]").Replace(JavaLauncher.msPlayerUUID, "[UUID]");
            Console.WriteLine(" " + text);
        }

        public static void Error(string header, string text)
        {
            //Output.AddHeader("#E74856", header, text);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"ERROR  [{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header} ");
            Console.ForegroundColor = ConsoleColor.Gray;
            if (text != null && JavaLauncher.msPlayerAccessToken != null && JavaLauncher.msPlayerUUID != null)
                text = text.Replace(JavaLauncher.msPlayerAccessToken, "[ACCESS_TOKEN]").Replace(JavaLauncher.msPlayerUUID, "[UUID]");
            Console.WriteLine(" " + text);
        }

        public static void GameInfo(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            text = text.Replace(JavaLauncher.msPlayerAccessToken, "[ACCESS_TOKEN]").Replace(JavaLauncher.msPlayerUUID, "[UUID]");
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void GameError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            text = text.Replace(JavaLauncher.msPlayerAccessToken, "[ACCESS_TOKEN]").Replace(JavaLauncher.msPlayerUUID, "[UUID]");
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
