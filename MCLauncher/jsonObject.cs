using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    public class jsonObject
    {
        //Universal
        public string verName { get; set; }
        public string verLink { get; set; }
        public string verType { get; set; }
        public string proxyPort { get; set; }

        //Mods
        public string modID { get; set; }
        public string modLink { get; set; }
        public string modNote { get; set; }
        public string baseVer { get; set; }
        public string modType { get; set; }
        public string modForgeVer { get; set; }

        //Instance config
        public string gameVer { get; set; }
        public string typeVer { get; set; }
        public string linkVer { get; set; }
        public string proxyVer { get; set; }
    }

    public class RootObject
    {
        public List<jsonObject> jsonObjects { get; set; }
    }
}
