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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MCLauncher
{
    public partial class MSAuth : Form
    {
        public static string browserAddress;
        public static string authCode;
        public static string accessToken;
        public static string xblToken;
        public static string userHash;
        public static string XError;
        public static string xstsToken;
        public static string mcAccessToken;
        public static string playerUUID;
        public static string playerName;
        public static string refreshToken;
        public static string mpPass;

        public static bool hasErrored = false;


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
                LogIn();
                this.Close();
            }
        }

        public static void getToken()
        {
            //Get authToken using authCode
            var tokenRequest = (HttpWebRequest)WebRequest.Create("https://login.live.com/oauth20_token.srf");
            var tokenPostData = "client_id=" + Uri.EscapeDataString("2313c7c4-a66c-44c4-9683-0bde2bb69c79");
            tokenPostData += "&client_secret=" + Uri.EscapeDataString("***REMOVED***"); //HIDE THIS
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
                refreshToken = vers.refresh_token;
                Console.WriteLine($"[MSAuth] refreshToken: {refreshToken}");
            }
        }

        public static void xblAuth()
        {
            //Auth with XBL
            try
            {
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
            }
            catch (WebException e)
            {
                Console.WriteLine($"[MSAuth] XBL request returned an error: {e.Message}");
                hasErrored = true;
            }
        }

        public static void xstsAuth()
        {
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

                List<jsonObject> xstsTokenData = JsonConvert.DeserializeObject<List<jsonObject>>($"[{xstsResponseString}]");
                foreach (var vers in xstsTokenData)
                {
                    xstsToken = vers.Token;
                    Console.WriteLine($"[MSAuth] xstsToken: {xstsToken}");
                    XError = vers.XErr;
                    Console.WriteLine($"[MSAuth] xError: {XError}");
                }

            }
            catch (WebException e)
            {
                Console.WriteLine($"[MSAuth] XSTS request returned an error: {e.Message}");
                hasErrored = true;
            }
        }

        public static void minecraftAuth()
        {
            //Minecraft authentication
            try
            {
                var mcRequest = (HttpWebRequest)WebRequest.Create("https://api.minecraftservices.com/authentication/login_with_xbox");
                mcRequest.ContentType = "application/json";
                mcRequest.Accept = "application/json";
                mcRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(mcRequest.GetRequestStream()))
                {
                    string json = $"{{\"identityToken\": \"XBL3.0 x={userHash};{xstsToken}\"}}";

                    streamWriter.Write(json);
                    Console.WriteLine($"[MSAuth] MC Request: {json}");
                }
                var mcResponse = (HttpWebResponse)mcRequest.GetResponse();
                var mcResponseString = "";
                using (var streamReader = new StreamReader(mcResponse.GetResponseStream()))
                {
                    mcResponseString = streamReader.ReadToEnd();
                    Console.WriteLine($"[MSAuth] MC Response: {mcResponseString}");
                }

                List<jsonObject> mcTokenData = JsonConvert.DeserializeObject<List<jsonObject>>($"[{mcResponseString}]");
                foreach (var vers in mcTokenData)
                {
                    mcAccessToken = vers.access_token;
                    Console.WriteLine($"[MSAuth] mcAccessToken: {mcAccessToken}");
                }
            }
            catch(WebException e)
            {
                hasErrored = true;
                Logger.log(ConsoleColor.Red, ConsoleColor.Gray, "[MSAuth]", $"MinecraftAuth returned a webException: {e.Message}");
            }

        }

        public static void verifyOwnership()
        {
            //Verify game ownership
            try
            {
                var ownRequest = (HttpWebRequest)WebRequest.Create("https://api.minecraftservices.com/entitlements/mcstore");
                ownRequest.ContentType = "application/json";
                ownRequest.Accept = "application/json";
                ownRequest.Method = "GET";
                ownRequest.PreAuthenticate = true;
                ownRequest.Headers.Add("Authorization", $"Bearer {mcAccessToken}");

                var ownResponse = (HttpWebResponse)ownRequest.GetResponse();
                var ownResponseString = "";
                using (var streamReader = new StreamReader(ownResponse.GetResponseStream()))
                {
                    ownResponseString = streamReader.ReadToEnd();
                    Console.WriteLine($"[MSAuth] Own Response: {ownResponseString}");
                }
            }
            catch(WebException e)
            {
                hasErrored = true;
                Logger.log(ConsoleColor.Red, ConsoleColor.Gray, "[MSAuth]", $"VerifyOwnership returned a webException: {e.Message}");
            }
            //TODO: VERIFY THE USER ACTALLY OWNS THE GAME (lol)
        }

        public static void voidRefreshToken(string mcRefreshToken)
        {
            try
            {
                var tokenRequest = (HttpWebRequest)WebRequest.Create("https://login.live.com/oauth20_token.srf");
                var tokenPostData = "client_id=" + Uri.EscapeDataString("2313c7c4-a66c-44c4-9683-0bde2bb69c79");
                tokenPostData += "&client_secret=" + Uri.EscapeDataString("***REMOVED***"); //HIDE THIS
                tokenPostData += "&refresh_token=" + Uri.EscapeDataString($"{mcRefreshToken}");
                tokenPostData += "&grant_type=" + Uri.EscapeDataString("refresh_token");
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
                Console.WriteLine($"[MSAuth] RefreshToken Response: {tokenResponseString}");

                string tokenJson = $"[{tokenResponseString}]";
                List<jsonObject> authTokenData = JsonConvert.DeserializeObject<List<jsonObject>>(tokenJson);
                foreach (var vers in authTokenData)
                {
                    accessToken = vers.access_token;
                    Console.WriteLine($"[MSAuth] accessToken: {accessToken}");
                }
            }
            catch(WebException e)
            {
                Console.WriteLine($"[MSAuth] RefreshToken request returned an error: {e.Message}");
                hasErrored = true;
            }
        }

        public static void getProfileInfo()
        {
            //Get profile info
            try
            {
                var profileRequest = (HttpWebRequest)WebRequest.Create("https://api.minecraftservices.com/minecraft/profile");
                profileRequest.ContentType = "application/json";
                profileRequest.Accept = "application/json";
                profileRequest.Method = "GET";
                profileRequest.PreAuthenticate = true;
                profileRequest.Headers.Add("Authorization", $"Bearer {mcAccessToken}");

                var profileResponse = (HttpWebResponse)profileRequest.GetResponse();
                var profileResponseString = "";
                using (var streamReader = new StreamReader(profileResponse.GetResponseStream()))
                {
                    profileResponseString = streamReader.ReadToEnd();
                    Console.WriteLine($"[MSAuth] Profile Response: {profileResponseString}");
                }

                List<jsonObject> mcProfileData = JsonConvert.DeserializeObject<List<jsonObject>>($"[{profileResponseString}]");
                foreach (var vers in mcProfileData)
                {
                    playerName = vers.name;
                    Console.WriteLine($"[MSAuth] Player name: {playerName}");
                    playerUUID = vers.id;
                    Console.WriteLine($"[MSAuth] Player UUID: {playerUUID}");
                }
            }
            catch(WebException e)
            {
                Console.WriteLine($"[MSAuth] ProfileInfo request returned an error: {e.Message}");
                hasErrored = true;
            }
        }

        public static void getMpPass()
        {
            try
            {
                //Notify the mojang session servers
                var mojpassRequest = (HttpWebRequest)WebRequest.Create("https://sessionserver.mojang.com/session/minecraft/join");
                mojpassRequest.ContentType = "application/json";
                mojpassRequest.Accept = "application/json";
                mojpassRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(mojpassRequest.GetRequestStream()))
                {
                    //TODO: GENERATE SERVERID IP:PORT > SHA1
                    var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes("142.44.247.4:25565"));
                    string sha1 = string.Concat(hash.Select(b => b.ToString("x2")));

                    Console.WriteLine($"[MSAuth] sha1 (serverId): {sha1}");

                    string json = $"{{\"serverId\": \"e4ac4d84356dc6617c55f4b5d1d7ba5fba2d4f88\",\"accessToken\": \"{mcAccessToken}\",\"selectedProfile\": \"{playerUUID}\"}}";

                    streamWriter.Write(json);
                    Console.WriteLine($"[MSAuth] Mojpass Request: {json}");
                }
                var mojpassResponse = (HttpWebResponse)mojpassRequest.GetResponse();
                var mojpassResponseString = "";
                using (var streamReader = new StreamReader(mojpassResponse.GetResponseStream()))
                {
                    mojpassResponseString = streamReader.ReadToEnd();
                    Console.WriteLine($"[MSAuth] Mojpass Response: {mojpassResponseString}");
                }
                Console.WriteLine($"[MSAuth] Mojpass code: {mojpassResponse.StatusCode}");

                if (mojpassResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine($"[MSAuth] Success! Getting Mppass..");

                    //Get the actual Mppass
                    var mppassRequest = (HttpWebRequest)WebRequest.Create($"http://api.betacraft.uk/getmppass.jsp?user={playerName}&server=142.44.247.4:25565");

                    mppassRequest.Method = "POST";
                    mppassRequest.ContentType = "application/x-www-form-urlencoded";

                    Console.WriteLine($"[MSAuth] mppassData: {mppassRequest}");
                    var mppassResponse = (HttpWebResponse)mppassRequest.GetResponse();
                    var mppassResponseString = new StreamReader(mppassResponse.GetResponseStream()).ReadToEnd();
                    Console.WriteLine($"[MSAuth] MPpass Response: {mppassResponseString}");
                    mpPass = mppassResponseString;

                }
                else
                {
                    Console.WriteLine($"[MSAuth] Auth failed! Mojpass status: {mojpassResponse.StatusCode}");
                    mpPass = "-";
                }
            }
            catch(WebException e)
            {
                Console.WriteLine($"[MSAuth] getMpPass request returned an error: {e.Message}");
                hasErrored = true;
            }
        }

        public void LogIn()
        {
            Console.WriteLine($"[MSAuth] AuthCode: {authCode}");
            getToken();
            xblAuth();
            xstsAuth();
            minecraftAuth();
            verifyOwnership();
            //todo: only do if player owns the game
            getProfileInfo();
            //todo: move to javalaunch?
            //getMpPass();

            if (hasErrored == true)
            {
                Logger.log(ConsoleColor.Red, ConsoleColor.Gray, $"[MSAuth]", $"Could not authenticate you.");
            }
            else
            {
                Properties.Settings.Default.msRefreshToken = refreshToken;
                Properties.Settings.Default.Save();
                MainWindow.msPlayerName = playerName;
            }


            /*Console.WriteLine($"[MSAuth] Seems like there was an error in getting your Xbox account data.");
            Console.WriteLine($"[MSAuth] XError code: {XError}.");*/

        }

        public static void usernameFromRefreshToken()
        {
            voidRefreshToken(Properties.Settings.Default.msRefreshToken);
            xblAuth();
            xstsAuth();
            minecraftAuth();
            verifyOwnership();
            //todo: only do if player owns the game
            getProfileInfo();

            if (hasErrored == true)
            {
                Logger.log(ConsoleColor.Red, ConsoleColor.Gray, $"[MSAuth]", $"Could not authenticate you.");
                hasErrored = false;
            }
            else
            {
                Logger.log(ConsoleColor.Blue, ConsoleColor.Gray, $"[MSAuth]", $"Got username: {playerName}");
                MainWindow.msPlayerName = playerName;
            }
        }

        public static void onGameStart()
        {
            voidRefreshToken(Properties.Settings.Default.msRefreshToken);
            xblAuth();
            xstsAuth();
            minecraftAuth();
            verifyOwnership();
            getMpPass();
            //todo: only do if player owns the game
            getProfileInfo();

            if (hasErrored == true)
            {
                Logger.log(ConsoleColor.Red, ConsoleColor.Gray, $"[MSAuth]", $"Could not authenticate you.");
                hasErrored = false;
            }
            else
            {
                LaunchJava.launchPlayerName = playerName;
                LaunchJava.launchPlayerUUID = playerUUID;
                LaunchJava.launchPlayerAccessToken = mcAccessToken;
                LaunchJava.launchMpPass = mpPass;
            }
        }

    }
}
