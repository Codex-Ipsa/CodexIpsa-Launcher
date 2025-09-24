using System;

namespace MCLauncher.json.api
{
    public class VersionJson
    {
        public String game { get; set; }
        public String version { get; set; }
        public String url { get; set; }
        public int size { get; set; }
        public int java { get; set; }
        public String cmdBef { get; set; }
        public String cmdAft { get; set; }
        public String defRes { get; set; }
        public bool srvJoin { get; set; }
        public String srvCmd { get; set; }
        public bool assetsVirt { get; set; }
        public VersionJsonAssets assets { get; set; }
        public String logging { get; set; }
        public String classpath { get; set; }
        public VersionJsonSupplement[] supplement { get; set; }
        public VersionJsonLibraries[] libraries { get; set; }
    }

    public class VersionJsonAssets
    {
        public String name { get; set; }
        public String url { get; set; }
        public int size { get; set; }
        public int fileSize { get; set; }
    }

    public class VersionJsonLibraries
    {
        public String name { get; set; }
        public String url { get; set; }
        public int size { get; set; }
        public bool extract { get; set; }
    }

    public class VersionJsonSupplement
    {
        public String url { get; set; }
        public String path { get; set; }
        public String name { get; set; }
        public bool renew { get; set; }
        public bool extract { get; set; }
    }
}
