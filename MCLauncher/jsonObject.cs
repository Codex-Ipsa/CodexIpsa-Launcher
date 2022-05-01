using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher
{
    public class jsonObject
    {
        public string verName { get; set; }
        public string verLink { get; set; }
        public string verType { get; set; }
    }

    public class RootObject
    {
        public List<jsonObject> jsonObjects { get; set; }
    }
}
