using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCLauncher
{
    internal class JavaModHelper
    {
        public static void Start(string instName, string clientPath)
        {
            int modNum = 0;
            List<string> modList = new List<string>();

            string filepath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\";
            DirectoryInfo d = new DirectoryInfo(filepath);

            foreach (var file in d.GetFiles("*.jar"))
            {
                Console.WriteLine(file.Name);
                modNum++;
                modList.Add(file.FullName);
            }

            foreach (var file in d.GetFiles("*.zip"))
            {
                Console.WriteLine(file.Name);
                modNum++;
                modList.Add(file.FullName);
            }

            if (modNum > 0)
            {
                Logger.Info("[ModHelper]", "Mods detected!");

                if(Directory.Exists($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\"))
                    Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\", true);

                ZipFile.ExtractToDirectory(clientPath, $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\");
                int modCount = 0;
                foreach (var mod in modList)
                {
                    ZipFile.ExtractToDirectory(mod, $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\{modCount}\\");
                    modCount++;
                }

                for(int i = 0; i < modCount; i++)
                {
                    string sourcePath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\{i}\\";

                    foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                    {
                        Directory.CreateDirectory(dirPath.Replace(sourcePath, $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\"));
                    }

                    foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                    {
                        File.Copy(newPath, newPath.Replace(sourcePath, $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\"), true);
                    }
                }

                Directory.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\META-INF\\", true);

                Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\");

                File.Delete($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\patch.jar");
                ZipFile.CreateFromDirectory($"{Globals.dataPath}\\instance\\{instName}\\jarmods\\temp\\full\\", $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\patch.jar");

                Logger.Info("[ModHelper]", "Created patched jar!");
                LaunchJava.launchClientPath = $"{Globals.dataPath}\\instance\\{instName}\\jarmods\\patch\\patch.jar";
            }
        }
    }
}
