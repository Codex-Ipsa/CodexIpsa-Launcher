using System;

namespace MCLauncher.json.api
{
    internal class UpdateJson
    {
        public String id { get; set; }
        public String name { get; set; }
        public String version { get; set; }
        public String url { get; set; }
        public String info { get; set; }
        public bool available { get; set; }
    }
}
