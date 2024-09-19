using System;
using CodexIpsa_Tools.modules;

namespace CodexIpsa_Tools
{
    internal class Program
    {
        public static String version = "0.1.0-wip";
        static void Main(string[] args)
        {
            Console.Title = version;
            Console.WriteLine(version);
            Console.WriteLine();
            Console.WriteLine("1) Generate VersionJsons from Mojang");
            Console.WriteLine("2) Convert MinecraftEdu builds");
            //Console.Write("> ");

            //String selection = Console.ReadLine();
            EduModule.start("1.8.9_build-3_classroom-20160404.jar", "1.8.9");

            Console.ReadLine();
        }
    }
}
