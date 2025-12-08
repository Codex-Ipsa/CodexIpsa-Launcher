using System;

namespace MCLauncher.json.launcher
{
    internal class AuthJson
    {
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }
        public string Token { get; set; }
        public string uhs { get; set; }
        public double XErr { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string user_code { get; set; }
        public string device_code { get; set; }
        public string verification_uri { get; set; }

        public DisplayClaims DisplayClaims { get; set; }
    }

    internal class DisplayClaims
    {
        public XUI[] xui { get; set; }
    }

    internal class XUI
    {
        public String uhs { get; set; }
    }
}
