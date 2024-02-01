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

        public static void Discord(string header, string text)
        {
            //Output.AddHeader("#E74856", header, text);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header} ");
            Console.ForegroundColor = ConsoleColor.Gray;
            if (text != null && JavaLauncher.msPlayerAccessToken != null && JavaLauncher.msPlayerUUID != null)
                text = text.Replace(JavaLauncher.msPlayerAccessToken, "[ACCESS_TOKEN]").Replace(JavaLauncher.msPlayerUUID, "[UUID]");
            Console.WriteLine(" " + text);
        }

        public static void GameInfo(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if(text != null && JavaLauncher.msPlayerAccessToken != null && JavaLauncher.msPlayerUUID != null)
                text = text.Replace(JavaLauncher.msPlayerAccessToken, "[ACCESS_TOKEN]").Replace(JavaLauncher.msPlayerUUID, "[UUID]");

            if (text.Contains("<log4j:Event"))
            {
                DateTime dt = UnixTimeStampToDateTime(Double.Parse(Splitter(text, "timestamp=\"", "\" level=")));
                Console.Write($"[{dt.ToString("HH:mm:ss")}] [{Splitter(text, "thread=\"", "\">")}/{Splitter(text, "level=\"", "\" thread=")}]: ");
            }
            else if (text.Contains("<log4j:Message"))
            {
                Console.Write(Splitter(text, "<log4j:Message><![CDATA[", "]]></log4j:Message>"));
            }
            else if (text.Contains("</log4j:Event"))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(text);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void GameError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (text != null && JavaLauncher.msPlayerAccessToken != null && JavaLauncher.msPlayerUUID != null)
                text = text.Replace(JavaLauncher.msPlayerAccessToken, "[ACCESS_TOKEN]").Replace(JavaLauncher.msPlayerUUID, "[UUID]");
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static string Splitter(string input, string before, string after)
        {
            //return input;
            //shitty void for splitting strings
            int start = input.IndexOf(before) + before.Length;
            if(!input.Contains(after))
            {
                return input.Replace(before, "");
            }
            else
            {
                return input.Substring(start, input.IndexOf(after) - start);
            }
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
