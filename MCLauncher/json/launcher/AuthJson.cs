using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.json.launcher
{
    internal class AuthJson
    {
        public string refresh_token { get; set; }
        public string access_token { get; set; }
        public string Token { get; set; }
        public string uhs { get; set; }
        public string XErr { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string user_code { get; set; }
        public string device_code { get; set; }
        public string verification_uri { get; set; }
    }
}
