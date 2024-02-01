using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.classes.jsons
{
    public class JavaManifest
    {
        public string id { get; set; }
        public string alt { get; set; }
        public string type { get; set; }
        public DateTime released { get; set; }
        public bool forge { get; set; }
        public bool fabric { get; set; }
        public string risugami { get; set; }
        public bool neoforge { get; set; }
        public bool quilt { get; set; }
    }
}
