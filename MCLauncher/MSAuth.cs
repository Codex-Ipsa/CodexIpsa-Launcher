using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MCLauncher
{
    public partial class MSAuth : Form
    {
        public string browserAddress;
        public string authCode;
        public string accessToken;
        public string xblToken;
        public string userHash;
        public string XError;
        public string xstsToken;

        public MSAuth()
        {
            InitializeComponent();
            webBrowser1.Url = new Uri("https://login.live.com/oauth20_authorize.srf?client_id=2313c7c4-a66c-44c4-9683-0bde2bb69c79&response_type=code&redirect_uri=https://codex-ipsa.dejvoss.cz/auth&scope=XboxLive.signin%20offline_access");

            Console.WriteLine($"[MSAuth] Started the auth process.");
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            browserAddress = webBrowser1.Url.ToString();
            Console.WriteLine($"[MSAuth] Browser navigated to {browserAddress}");

            if (browserAddress.StartsWith("https://codex-ipsa.dejvoss.cz/auth?code="))
            {
                //Get the authcode from URL
                string temp = webBrowser1.Url.ToString();
                Console.WriteLine($"[MSAuth] Authorization Code url: {temp}");
                authCode = temp.Replace("https://codex-ipsa.dejvoss.cz/auth?code=", "");
                Authenticate();
                this.Close();
            }
        }

        public void Authenticate()
        {
            //https://login.live.com/oauth20_authorize.srf?client_id=2313c7c4-a66c-44c4-9683-0bde2bb69c79&response_type=code&redirect_uri=https://codex-ipsa.dejvoss.cz/auth&scope=XboxLive.signin offline_access
            //https://login.live.com/oauth20_authorize.srf?client_id=2313c7c4-a66c-44c4-9683-0bde2bb69c79&response_type=code&redirect_uri=https://codex-ipsa.dejvoss.cz/auth&scope=XboxLive.signin%20offline_access

            //https://codex-ipsa.dejvoss.cz/auth?code=M.R3_BL2.f93e9e01-26c2-7159-46e7-7aaa0c687132

            Console.WriteLine($"[MSAuth] AuthCode: {authCode}");

            //Get authToken using authCode
            var tokenRequest = (HttpWebRequest)WebRequest.Create("https://login.live.com/oauth20_token.srf");
            var tokenPostData = "client_id=" + Uri.EscapeDataString("2313c7c4-a66c-44c4-9683-0bde2bb69c79");
            tokenPostData += "&client_secret=" + Uri.EscapeDataString("***REMOVED***");
            tokenPostData += "&code=" + Uri.EscapeDataString($"{authCode}");
            tokenPostData += "&grant_type=" + Uri.EscapeDataString("authorization_code");
            tokenPostData += "&redirect_uri=" + Uri.EscapeDataString("https://codex-ipsa.dejvoss.cz/auth");
            var tokenData = Encoding.ASCII.GetBytes(tokenPostData);
            tokenRequest.Method = "POST";
            tokenRequest.ContentType = "application/x-www-form-urlencoded";
            tokenRequest.ContentLength = tokenData.Length;
            using (var stream = tokenRequest.GetRequestStream())
            {
                stream.Write(tokenData, 0, tokenData.Length);
            }
            var tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();
            var tokenResponseString = new StreamReader(tokenResponse.GetResponseStream()).ReadToEnd();
            Console.WriteLine($"[MSAuth] Token Response: {tokenResponseString}");

            string tokenJson = $"[{tokenResponseString}]";
            List<jsonObject> authTokenData = JsonConvert.DeserializeObject<List<jsonObject>>(tokenJson);
            foreach (var vers in authTokenData)
            {
                accessToken = vers.access_token;
                Console.WriteLine($"[MSAuth] accessToken: {accessToken}");
            }

            //Auth with XBL
            var xblRequest = (HttpWebRequest)WebRequest.Create("https://user.auth.xboxlive.com/user/authenticate");
            xblRequest.ContentType = "application/json";
            xblRequest.Accept = "application/json";
            xblRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(xblRequest.GetRequestStream()))
            {
                string json = $"{{\"Properties\": {{\"AuthMethod\": \"RPS\",\"SiteName\": \"user.auth.xboxlive.com\",\"RpsTicket\": \"d={accessToken}\"}},\"RelyingParty\": \"http://auth.xboxlive.com\",\"TokenType\": \"JWT\"}}";

                streamWriter.Write(json);
                Console.WriteLine($"[MSAuth] XBL Request: {json}");
            }

            var xblResponse = (HttpWebResponse)xblRequest.GetResponse();
            var xblResponseString = "";
            using (var streamReader = new StreamReader(xblResponse.GetResponseStream()))
            {
                xblResponseString = streamReader.ReadToEnd();
                Console.WriteLine($"[MSAuth] XBL Response: {xblResponseString}");
            }

            string xblJson = $"[{xblResponseString}]";
            List<jsonObject> xblTokenData = JsonConvert.DeserializeObject<List<jsonObject>>(xblJson);
            foreach (var vers in xblTokenData)
            {
                xblToken = vers.Token;
                Console.WriteLine($"[MSAuth] xblToken: {xblToken}");
            }

            string s = xblJson.Substring(xblJson.LastIndexOf("[{"));
            string s2 = s.Replace("}}", "");
            string s3 = s2.Replace("]]", "]");
            Console.WriteLine($"[MSAuth] Array of xui: {s3}");

            List<jsonObject> uhsTokenData = JsonConvert.DeserializeObject<List<jsonObject>>(s3);
            foreach (var vers in uhsTokenData)
            {
                userHash = vers.uhs;
                Console.WriteLine($"[MSAuth] userHash: {userHash}");
            }


            //Authenticate with XSTS
            var xstsRequest = (HttpWebRequest)WebRequest.Create("https://xsts.auth.xboxlive.com/xsts/authorize");
            xstsRequest.ContentType = "application/json";
            xstsRequest.Accept = "application/json";
            xstsRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(xstsRequest.GetRequestStream()))
            {
                string json = $"{{\"Properties\": {{\"SandboxId\": \"RETAIL\",\"UserTokens\": [\"{xblToken}\"]}},\"RelyingParty\": \"rp://api.minecraftservices.com/\",\"TokenType\": \"JWT\"}}";

                streamWriter.Write(json);
                Console.WriteLine($"[MSAuth] XSTS Request: {json}");
            }

            try
            {
                var xstsResponse = (HttpWebResponse)xstsRequest.GetResponse();
                var xstsResponseString = "";
                using (var streamReader = new StreamReader(xstsResponse.GetResponseStream()))
                {
                    xstsResponseString = streamReader.ReadToEnd();
                    Console.WriteLine($"[MSAuth] XSTS Response: {xstsResponseString}");
                }

                List<xstsObject> xstsTokenData = JsonConvert.DeserializeObject<List<xstsObject>>($"[{xstsResponseString}]");
                foreach (var vers in xstsTokenData)
                {
                    xstsToken = vers.Token;
                    Console.WriteLine($"[MSAuth] xstsToken: {xstsToken}");
                    /*XError = vers.XErr;
                    Console.WriteLine($"[MSAuth] xError: {XError}");*/
                }

                /*if (XError != String.Empty)
                {
                    Console.WriteLine($"[MSAuth] xError occured! Error code: {XError}.");
                }
                else
                {
                    Console.WriteLine($"[MSAuth] No xError found.");
                }*/
            }
            catch (WebException e)
            {
                Console.WriteLine($"[MSAuth] XSTS request returned an error: {e.Message}");
            }


            /*Console.WriteLine($"[MSAuth] Seems like there was an error in getting your Xbox account data.");
            Console.WriteLine($"[MSAuth] XError code: {XError}.");*/

        }
    }
}
