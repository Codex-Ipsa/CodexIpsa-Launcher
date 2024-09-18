using System;

namespace MCLauncher.json.api
{
    public class ModloadersJson
    {
        public Risugami[] risugami { get; set; }
        public Forge[] forge { get; set; }
        public Neoforge[] neoforge { get; set; }
        public Quilt[] quilt { get; set; }
        public Liteloader[] liteloader { get; set; }
    }

    public class Risugami
    {
        public String id { get; set; }
        public String url { get; set; }
        public String urlmp { get; set; }
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
        public Forge[] supplement { get; set; }
    }

    public class Neoforge
    {
        //TODO
    }

    public class Quilt
    {
        //TODO
    }

    public class Liteloader
    {
        //TODO
    }
}
