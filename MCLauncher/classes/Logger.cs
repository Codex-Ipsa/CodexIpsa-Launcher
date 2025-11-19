using MCLauncher.classes;
using System;
using System.Globalization;
using System.IO;

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
            if (text != null && MSAuth.msAccessToken != null && MSAuth.msUUID != null)
                text = text.Replace(MSAuth.msAccessToken, "[ACCESS_TOKEN]").Replace(MSAuth.msUUID, "[UUID]");
            Console.WriteLine(" " + text);

            File.AppendAllText($"{Globals.dataPath}\\launcher.log", $"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header} {text}\n");
        }

        public static void Error(string header, string text)
        {
            //Output.AddHeader("#E74856", header, text);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"ERROR  [{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header} ");
            Console.ForegroundColor = ConsoleColor.Gray;
            if (text != null && MSAuth.msAccessToken != null && MSAuth.msUUID != null)
                text = text.Replace(MSAuth.msAccessToken, "[ACCESS_TOKEN]").Replace(MSAuth.msUUID, "[UUID]");
            Console.WriteLine(" " + text);

            File.AppendAllText($"{Globals.dataPath}\\launcher.log", $"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header} {text}\n");
        }

        public static void Discord(string header, string text)
        {
            //Output.AddHeader("#E74856", header, text);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header}");
            Console.ForegroundColor = ConsoleColor.Gray;
            if (text != null && MSAuth.msAccessToken != null && MSAuth.msUUID != null)
                text = text.Replace(MSAuth.msAccessToken, "[ACCESS_TOKEN]").Replace(MSAuth.msUUID, "[UUID]");
            Console.WriteLine(" " + text);

            File.AppendAllText($"{Globals.dataPath}\\launcher.log", $"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {header} {text}\n");
        }

        public static void GameInfo(string text, String instName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (text != null && MSAuth.msAccessToken != null && MSAuth.msUUID != null)
                text = text.Replace(MSAuth.msAccessToken, "[ACCESS_TOKEN]").Replace(MSAuth.msUUID, "[UUID]");

            if (text.Contains("<log4j:Event"))
            {
                DateTime dt = UnixTimeStampToDateTime(Double.Parse(Splitter(text, "timestamp=\"", "\" level=")));
                String msg = $"[{dt.ToString("HH:mm:ss")}] [{Splitter(text, "thread=\"", "\">")}/{Splitter(text, "level=\"", "\" thread=")}]: ";
                Console.Write(msg);
                File.AppendAllText($"{Globals.dataPath}\\instance\\{instName}\\instance.log", msg + "\n");
            }
            else if (text.Contains("<log4j:Message"))
            {
                String msg = Splitter(text, "<log4j:Message><![CDATA[", "]]></log4j:Message>");
                Console.Write(msg);
                File.AppendAllText($"{Globals.dataPath}\\instance\\{instName}\\instance.log", msg + "\n");
            }
            else if (text.Contains("</log4j:Event"))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                File.AppendAllText($"{Globals.dataPath}\\instance\\{instName}\\instance.log", "\n");
            }
            else
            {
                Console.WriteLine(text);
                File.AppendAllText($"{Globals.dataPath}\\instance\\{instName}\\instance.log", text + "\n");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void GameError(string text, String instName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (text != null && MSAuth.msAccessToken != null && MSAuth.msUUID != null)
                text = text.Replace(MSAuth.msAccessToken, "[ACCESS_TOKEN]").Replace(MSAuth.msUUID, "[UUID]");
            Console.WriteLine(text);
            File.AppendAllText($"{Globals.dataPath}\\instance\\{instName}\\instance.log", text + "\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static string Splitter(string input, string before, string after)
        {
            //return input;
            //shitty void for splitting strings
            int start = input.IndexOf(before) + before.Length;
            if (!input.Contains(after))
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
