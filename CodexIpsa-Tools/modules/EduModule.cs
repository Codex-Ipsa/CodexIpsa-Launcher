using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodexIpsa_Tools.modules
{
    internal class EduModule
    {
        public static void start(String jarPath, String baseVersion)
        {
            ZipFile.ExtractToDirectory(jarPath, "temp");

            //GET install_res\launcher.zip\minecraft\libraries\minecraftedu\mceduforge\0\mceduforge-0.jar

            //GET install_res\launcher.zip\minecraft\versions\mceduforge\mceduforge.json
            //PARSE ^

            //TODO merge loaded mojang json for edu version with a downloaded IpsaJson for the version
        }
    }
}
