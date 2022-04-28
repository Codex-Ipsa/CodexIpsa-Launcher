using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    public class jsonObjectMod
    {
        public string modID { get; set; }
        public string modLink { get; set; }
        public string modNote { get; set; }
        public string baseVer { get; set; }
        public string modType { get; set; }
        public string modForgeVer { get; set; }
    }

    public class RootObjectMod
    {
        public List<jsonObject> jsonObjects { get; set; }
    }
}
