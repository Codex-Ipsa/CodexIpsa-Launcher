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
        public string instVer { get; set; }
        public string instType { get; set; }
        public string instUrl { get; set; }
        public string instResWidth { get; set; }
        public string instResHeight { get; set; }
        public string instRamMin { get; set; }
        public string instRamMax { get; set; }
        public string useCustJava { get; set; }
        public string instCustJava { get; set; }
        public string useCustJvm { get; set; }
        public string instCustJvm { get; set; }
        public string useCustMethod { get; set; }
        public string instCustMethod { get; set; }
        public string useCustJar { get; set; }
        public string instCustJar { get; set; }
        public string useOfflineMode { get; set; }


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
        public string getServer { get; set; }

        //Updates
        public string brId { get; set; }
        public string brName { get; set; }
        public string brVer { get; set; }
        public string brUrl { get; set; }

        //MSAuth
        public string refresh_token { get; set; }
        public string access_token { get; set; }
        public string Token { get; set; }
        public string uhs { get; set; }
        public string XErr { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class RootObject
    {
        public List<jsonObject> jsonObjects { get; set; }
    }
}