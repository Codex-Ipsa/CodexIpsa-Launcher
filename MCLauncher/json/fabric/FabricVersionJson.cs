using MCLauncher.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.json.fabric
{
    public class FabricVersionJson
    {
        public string id { get; set; }
        public string inheritsFrom { get; set; }
        public string releaseTime { get; set; }
        public string mainClass { get; set; }
        public FabricLibsJson[] libraries { get; set; }

    }
    public class FabricLibsJson
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
