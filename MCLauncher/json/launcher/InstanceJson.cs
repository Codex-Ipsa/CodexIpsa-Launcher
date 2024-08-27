using System;

namespace MCLauncher.json.launcher
{
    public class InstanceJson
    {
        public int data { get; set; }

        public string edition { get; set; }
        public string version { get; set; }

        public string directory { get; set; }
        public string resolution { get; set; }
        public string memory { get; set; }
        public string befCmd { get; set; }
        public string aftCmd { get; set; }

        public bool disProxy { get; set; }
        public bool demo { get; set; }
        public bool offline { get; set; }
        public bool multiplayer { get; set; }

        public bool useJava { get; set; }
        public string javaPath { get; set; }
        public bool useJson { get; set; }
        public string jsonPath { get; set; }
        public bool useClass { get; set; }
        public string classpath { get; set; }
        public bool useAssets { get; set; }
        public string assetsPath { get; set; }
        public bool useServerIP { get; set; }
        public String serverIP { get; set; }

        public bool xboxDemo { get; set; }

        public long playTime { get; set; }
    }
}
