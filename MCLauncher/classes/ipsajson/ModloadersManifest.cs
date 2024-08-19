using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.classes.ipsajson
{
    public class ModloadersManifest
    {
        public Risugami[] risugami { get; set; }
        public Forge[] forge { get; set; }
        public Fabric[] fabric { get; set; }
        public Neoforge[] neoforge { get; set; }
        public Quilt[] quilt { get; set; }
        public Liteloader[] liteloader { get; set; }
    }

    public class Risugami
    {

    }

    public class Forge
    {
        public String id { get; set; }
        public String type { get; set; }
        public String json { get; set; }
        public String url { get; set; }
        public double size { get; set; }
        public String released { get; set; }
        public bool recommended { get; set; }
        public ForgeSupplement supplement { get; set; }
    }
    public class ForgeSupplement
    {

    }

    public class Fabric
    {

    }

    public class Neoforge
    {

    }

    public class Quilt
    {

    }

    public class Liteloader
    {

    }
}
