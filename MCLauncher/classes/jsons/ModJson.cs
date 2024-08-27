namespace MCLauncher.classes.jsons
{
    public class ModJson
    {
        public ModJsonEntry[] items { get; set; }
    }

    public class ModJsonEntry
    {
        public string name { get; set; }
        public string version { get; set; }
        public string file { get; set; }
        public string type { get; set; }
        public string json { get; set; }
        public bool disabled { get; set; }
    }
}
