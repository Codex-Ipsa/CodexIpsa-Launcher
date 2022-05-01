using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    class LaunchJava
    {
        public static string selectedVer = "b1.7.3";
        public static string linkToJar = "https://launcher.mojang.com/v1/objects/43db9b498cb67058d2e12d394e6507722e71bb45/client.jar";
        public static string typeVer = "jar106";
        public static bool useProxy = true;
        public static string launchCmd;

        public static void LaunchGame()
        {
            //Create directories
            Directory.CreateDirectory($"{Globals.currentPath}\\bin");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\versions\\java");
            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\libs");

            using (var client = new WebClient())
            {
                //Download version
                if (!File.Exists($"{Globals.currentPath}\\bin\\versions\\java\\{selectedVer}.jar"))
                {
                    DownloadProgress.url = linkToJar;
                    DownloadProgress.savePath = $"{Globals.currentPath}\\bin\\versions\\java\\{selectedVer}.jar";
                    DownloadProgress download = new DownloadProgress();
                    download.ShowDialog();
                }

                //If it's an applet, check for libs, download them, and launch the game
                if (typeVer == "applet")
                {
                    LibsCheck.CheckPre16();

                    if (LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"bin/versions/java/{selectedVer}.jar;bin/libs/launchwrapper-1.6.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar;bin/libs/jutils-1.0.0.jar;bin/libs/jopt-simple-4.5.jar;bin/libs/jinput-2.0.5.jar;bin/libs/asm-all-4.1.jar\" net.minecraft.launchwrapper.Launch {Properties.Settings.Default.playerName} test --tweakClass net.minecraft.launchwrapper.AlphaVanillaTweaker";

                        System.Diagnostics.Process.Start("java.exe", launchCmd);
                        VerSelect.checkTab = "java";
                        LibsCheck.isDone = false;
                    }
                }
                //If it's a1.0.6 to 1.5, check for libs, download them, and launch the game.
                else if (typeVer == "jar106")
                {
                    LibsCheck.CheckPre16();

                    if(LibsCheck.isDone == true)
                    {
                        launchCmd = $" -Xms{Properties.Settings.Default.ramXMS}m -Xmx{Properties.Settings.Default.ramXMS}m -DproxySet=true -Dhttp.proxyHost=betacraft.uk -Djava.util.Arrays.useLegacyMergeSort=true -Djava.library.path=bin/libs/natives/ -cp \"bin/versions/java/{selectedVer}.jar;bin/libs/lwjgl-2.9.0.jar;bin/libs/lwjgl_util-2.9.0.jar\" net.minecraft.client.Minecraft {Properties.Settings.Default.playerName} test";

                        System.Diagnostics.Process.Start("java.exe", launchCmd);
                        VerSelect.checkTab = "java";
                        LibsCheck.isDone = false;
                    }
                }
                //If it's post1.6, check for libs, download them, and launch the game.
                else if (typeVer == "jar16")
                {

                }
            }
        }
    }
}
