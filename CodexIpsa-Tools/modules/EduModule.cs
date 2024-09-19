using MCLauncher;
using MCLauncher.json.api;
using MCLauncher.json.fabric;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodexIpsa_Tools.modules
{
    internal class EduModule
    {
        public static void start(String jarPath, String baseVersion, String eduVersion)
        {
            //create needed dirs
            Directory.CreateDirectory($"files.codex-ipsa.cz\\edu\\{eduVersion}\\");

            //extract installerr
            //ZipFile.ExtractToDirectory(jarPath, "temp");
            //ZipFile.ExtractToDirectory("temp\\install_res\\launcher.zip", "temp_launcher");

            //GET \install_res\launcher.zip\minecraft\libraries\minecraftedu\mceduforge\0\mceduforge-0.jar

            //GET \install_res\launcher.zip\launcher_res\settings\options_orig.txt (?)

            //GET \install_res\launcher.zip\lib\* (LIBRARIES)

            //GET \install_res\launcher.zip\minecraft\mods\1.8.9\ (COMPUTER CRAFT, POSSIBLY OTHER STUFF)
            //GET \install_res\launcher.zip\minecraft\resourcepacks\mcedu_resourcepack.zip (RESOURCE PACK)

            //GET \install_res\launcher.zip\minecraft\versions\mceduforge\mceduforge.json
            
            //parse edu manifest
            String eduManifest = File.ReadAllText("temp_launcher\\minecraft\\versions\\mceduforge\\mceduforge.json");
            FabricVersionJson fvj = JsonConvert.DeserializeObject<FabricVersionJson>(eduManifest);

            //parse ipsa manifest
            WebClient wc = new WebClient();
            String ipsaManifest = wc.DownloadString($"http://codex-ipsa.dejvoss.cz/launcher/codebase/{Globals.codebase}/java/{baseVersion}.json");
            VersionJson vj = JsonConvert.DeserializeObject<VersionJson>(ipsaManifest);

            //TODO merge loaded mojang json for edu version with a downloaded IpsaJson for the version

            //add edu libraries
            foreach(FabricLibsJson lib in fvj.libraries)
            {
                String[] split = lib.name.Split(':');
                String libName = split[split.Length - 2] + "-" + split[split.Length - 1];

                int pos = -1;
                for(int i = 0; i < vj.libraries.Length; i++)
                {
                    if(libName == vj.libraries[i].name)
                    {
                        pos = i;
                    }
                }

                if(pos < 0)
                {
                    Console.WriteLine(libName);
                }
            }

            String serialized = JsonConvert.SerializeObject(vj);
            Console.WriteLine(serialized);
            Console.ReadLine();
        }
    }
}
