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


        //JRE downloads
        public string jreLink { get; set; }
        public string jreVer { get; set; }

        //VersionType Json
        public string note { get; set; }
        public string minJava { get; set; }
        public string launchMethod { get; set; }
        public string libsType { get; set; }
        public string libs { get; set; }
        public string proxy { get; set; }
        public string addCmd { get; set; }

        //Updates
        public string brId { get; set; }
        public string brName { get; set; }
        public string brVer { get; set; }
        public string brUrl { get; set; }

        //MSAuth
        public string access_token { get; set; }
        public string Token { get; set; }
        public string uhs { get; set; }
    }

    public class xstsObject
    {
        public string Token { get; set; }
        public string XErr { get; set; }
    }

    public class RootObject
    {
        public List<jsonObject> jsonObjects { get; set; }
        public List<xstsObject> xstsObjects { get; set; }
    }
}