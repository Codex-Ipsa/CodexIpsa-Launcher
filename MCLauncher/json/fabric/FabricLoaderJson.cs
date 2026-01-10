using System;

namespace MCLauncher.json.fabric
{
    internal class FabricLoaderJson
    {
        public FabricLoaderLoader loader { get; set; }
    }

    internal class FabricLoaderLoader
    {
        public String version { get; set; }
        public bool stable { get; set; }
    }
}
