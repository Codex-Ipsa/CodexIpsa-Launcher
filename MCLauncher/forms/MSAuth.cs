using MCLauncher.classes;
using MCLauncher.json.launcher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Security.Cryptography;
using System.Text;
using System.Timers;
using System.Windows.Forms;

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

        public static string userCode;
        public static string deviceCode;
        public static string deviceUrl;

        public static bool hasErrored = false;
        public static String errorMsg = "An error happened during the login process!\nCheck the console for further information and try again.";

        public static int deviceLimit = 900;
        public static int deviceCurrent = 0;

        public MSAuth()
        {
            this.ControlBox = false;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //Load lang
            this.Text = Strings.sj.titleLogin;
            label2.Text = Strings.sj.labelPleaseLog;
            label1.Text = Strings.sj.labelCode;
            cancelBtn.Text = Strings.sj.btnCancel;

            //This NO LONGER uses the test azure app, DONT change that!!!
            deviceCurrent = 0;
            var deviceRequest = (HttpWebRequest)WebRequest.Create($"https://login.microsoftonline.com/consumers/oauth2/v2.0/devicecode?client_id=bee0ffd1-4143-41ef-bdf6-fe15d5549c09&scope=XboxLive.signin+offline_access"); //THIS NEEDS TO HAVE OFFLINE ACCESS TO RETURN REFRESH CODE!!!!!
            deviceRequest.Method = "GET";
            deviceRequest.ContentType = "application/x-www-form-urlencoded";
            var deviceResponse = (HttpWebResponse)deviceRequest.GetResponse();
            var deviceResponseString = new StreamReader(deviceResponse.GetResponseStream()).ReadToEnd();
            if (Globals.isDebug)
                Logger.Info("[MSAuth]", $"Deviceflow response: {deviceResponseString}");

            string deviceJson = $"[{deviceResponseString}]";

            List<AuthJson> deviceData = JsonConvert.DeserializeObject<List<AuthJson>>(deviceJson);
            foreach (var vers in deviceData)
            {
                userCode = vers.user_code;
                deviceCode = vers.device_code;
                deviceUrl = vers.verification_uri;
                if (Globals.isDebug)
                {
                    Logger.Info("[MSAuth]", $"To sign in, use a web browser to open the page {deviceUrl} and enter the code {userCode} to authenticate.");
                    Logger.Info("[MSAuth]", $"Device code: {deviceCode}");
                }
                textBox1.Text = $"{userCode}";
                textBox1.ReadOnly = true;
            }
            this.Refresh();
            backgroundWorker1.RunWorkerAsync();
            //this.Close();
        }

        public static void deviceFlowPing(object source, ElapsedEventArgs e)
        {
            if (Globals.isDebug)
                Logger.Info("[MSAuth]", $"Test! 1s! {deviceCurrent}");
            var tokenRequest = (HttpWebRequest)WebRequest.Create("https://login.microsoftonline.com/consumers/oauth2/v2.0/token");
            var tokenPostData = "grant_type=urn:ietf:params:oauth:grant-type:device_code";
            tokenPostData += "&client_id=bee0ffd1-4143-41ef-bdf6-fe15d5549c09";
            tokenPostData += $"&device_code={deviceCode}";
            var tokenData = Encoding.ASCII.GetBytes(tokenPostData);
            tokenRequest.Method = "POST";
            tokenRequest.ContentType = "application/x-www-form-urlencoded";
            tokenRequest.ContentLength = tokenData.Length;
            tokenRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            if (Globals.isDebug)
                Logger.Info("[MSAuth]", $"Post data: {tokenPostData}");

            //This has to be done because of MS's shitty service - thanks!
            try
            {
                using (var stream = tokenRequest.GetRequestStream())
                {
                    stream.Write(tokenData, 0, tokenData.Length);
                }
                var tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();
                var tokenResponseString = new StreamReader(tokenResponse.GetResponseStream()).ReadToEnd();
                deviceCurrent = 181;
                if (Globals.isDebug)
                    Logger.Info("[MSAuth]", $"Response string: {tokenResponseString}");
                else
                    Logger.Info("[MSAuth]", "Got Token response!");
                string tokenJson = $"[{tokenResponseString}]";
                List<AuthJson> authTokenData = JsonConvert.DeserializeObject<List<AuthJson>>(tokenJson);
                foreach (var vers in authTokenData)
                {
                    accessToken = vers.access_token;
                    refreshToken = vers.refresh_token;
                    if (Globals.isDebug)
                    {
                        Logger.Info("[MSAuth]", $"AccessToken: {accessToken}");
                        Logger.Info("[MSAuth]", $"RefreshToken: {refreshToken}");
                    }
                }
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    Logger.Info("[MSAuth]", $"Waiting for user to log in...");
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();

                        if (Globals.isDebug)
                            Logger.Info("[MSAuth]", $"Response: \n{text}");
                    }
                }
                deviceCurrent++;
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
                    if (Globals.isDebug)
                        Logger.Info("[MSAuth]", $"XBL Request: {json}");
                }

                var xblResponse = (HttpWebResponse)xblRequest.GetResponse();
                var xblResponseString = "";
                using (var streamReader = new StreamReader(xblResponse.GetResponseStream()))
                {
                    xblResponseString = streamReader.ReadToEnd();
                    if (Globals.isDebug)
                        Logger.Info("[MSAuth]", $"XBL Response: {xblResponseString}");
                    else
                        Logger.Info("[MSAuth]", $"Got XBL response");
                }

                string xblJson = $"[{xblResponseString}]";
                List<AuthJson> xblTokenData = JsonConvert.DeserializeObject<List<AuthJson>>(xblJson);
                foreach (var vers in xblTokenData)
                {
                    xblToken = vers.Token;
                    if (Globals.isDebug)
                        Logger.Info("[MSAuth]", $"xblToken: {xblToken}");
                }

                string s = xblJson.Substring(xblJson.LastIndexOf("[{"));
                string s2 = s.Replace("}}", "");
                string s3 = s2.Replace("]]", "]");
                if (Globals.isDebug)
                    Logger.Info("[MSAuth]", $"Array of xui: {s3}");

                List<AuthJson> uhsTokenData = JsonConvert.DeserializeObject<List<AuthJson>>(s3);
                foreach (var vers in uhsTokenData)
                {
                    userHash = vers.uhs;
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"userHash: {userHash}");
                    else
                        Logger.Info($"[MSAuth]", $"Got userHash!");
                }
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth]", $"XBL request returned an error: {e.Message}");
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
                if (Globals.isDebug)
                    Logger.Info("[MSAuth]", $"XSTS Request: {json}");
            }

            try
            {
                var xstsResponse = (HttpWebResponse)xstsRequest.GetResponse();
                var xstsResponseString = "";
                using (var streamReader = new StreamReader(xstsResponse.GetResponseStream()))
                {
                    xstsResponseString = streamReader.ReadToEnd();
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"XSTS Response: {xstsResponseString}");
                    else
                        Logger.Info($"[MSAuth]", $"Got XSTS response");
                }

                List<AuthJson> xstsTokenData = JsonConvert.DeserializeObject<List<AuthJson>>($"[{xstsResponseString}]");
                foreach (var vers in xstsTokenData)
                {
                    xstsToken = vers.Token;
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"xstsToken: {xstsToken}");
                    XError = vers.XErr;
                    Logger.Info($"[MSAuth]", $"xError: {XError}");
                }

            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth]", $"XSTS request returned an error: {e.Message}");
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
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"MC Request: {json}");
                }
                var mcResponse = (HttpWebResponse)mcRequest.GetResponse();
                var mcResponseString = "";
                using (var streamReader = new StreamReader(mcResponse.GetResponseStream()))
                {
                    mcResponseString = streamReader.ReadToEnd();
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"MC Response: {mcResponseString}");
                    else
                        Logger.Info($"[MSAuth]", $"Got MC response");
                }

                List<AuthJson> mcTokenData = JsonConvert.DeserializeObject<List<AuthJson>>($"[{mcResponseString}]");
                foreach (var vers in mcTokenData)
                {
                    mcAccessToken = vers.access_token;
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"mcAccessToken: {mcAccessToken}");
                }
            }
            catch (WebException e)
            {
                hasErrored = true;
                Logger.Error("[MSAuth]", $"MinecraftAuth returned a webException: {e.Message}");
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
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"Own Response: {ownResponseString}");
                }
            }
            catch (WebException e)
            {
                hasErrored = true;
                Logger.Error("[MSAuth]", $"VerifyOwnership returned a webException: {e.Message}");
            }
            //TODO: VERIFY THE USER ACTALLY OWNS THE GAME, ALONG OTHER GAMES LIKE BEDROCK AND DUNGEONS [maybe it works without it?]
        }

        public static void voidRefreshToken(string mcRefreshToken)
        {
            try
            {
                //THIS USES THE TEST APP, CHANGE!!!
                var tokenRequest = (HttpWebRequest)WebRequest.Create("https://login.live.com/oauth20_token.srf");
                var tokenPostData = "client_id=" + Uri.EscapeDataString("bee0ffd1-4143-41ef-bdf6-fe15d5549c09");
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
                if (Globals.isDebug)
                    Logger.Info($"[MSAuth]", $"RefreshToken Response: {tokenResponseString}");
                else
                    Logger.Info($"[MSAuth]", $"Got RefreshToken response");

                string tokenJson = $"[{tokenResponseString}]";
                List<AuthJson> authTokenData = JsonConvert.DeserializeObject<List<AuthJson>>(tokenJson);
                foreach (var vers in authTokenData)
                {
                    accessToken = vers.access_token;
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"accessToken: {accessToken}");
                }
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth]", $"RefreshToken request returned an error: {e.Message}");
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
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"Profile Response: {profileResponseString}");
                    else
                        Logger.Info("[MSAuth]", "Got profile response");
                }

                List<AuthJson> mcProfileData = JsonConvert.DeserializeObject<List<AuthJson>>($"[{profileResponseString}]");
                foreach (var vers in mcProfileData)
                {
                    playerName = vers.name;
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"Player name: {playerName}");
                    playerUUID = vers.id;
                    if (Globals.isDebug)
                        Logger.Info($"[MSAuth]", $"Player UUID: {playerUUID}");
                }
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth]", $"ProfileInfo request returned an error: {e.Message}");
                errorMsg = "Seems like you don't own Minecraft on this account.\nTry another or buy the game at minecraft.net!";
                hasErrored = true;
            }
        }

        public static void getMpPass(String ip, String port)
        {
            try
            {
                //Notify the mojang session servers
                var mojpassRequest = (HttpWebRequest)WebRequest.Create("https://sessionserver.mojang.com/session/minecraft/join");
                mojpassRequest.ContentType = "application/json";
                mojpassRequest.Accept = "application/json";
                mojpassRequest.Method = "POST";

                String myIP = Globals.client.DownloadString("http://checkip.amazonaws.com/");
                myIP = myIP.Replace("\n", String.Empty);

                var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(myIP));
                string sha1 = string.Concat(hash.Select(b => b.ToString("x2")));
                if (Globals.isDebug)
                    Logger.Info("[MSAuth]", $"sha1 (serverId): {sha1}");

                using (var streamWriter = new StreamWriter(mojpassRequest.GetRequestStream()))
                {
                    string json = $"{{\"serverId\": \"{sha1}\",\"accessToken\": \"{mcAccessToken}\",\"selectedProfile\": \"{playerUUID}\"}}";

                    streamWriter.Write(json);
                    if (Globals.isDebug)
                        Logger.Info("[MSAuth]", $"Mojpass Request: {json}");
                }
                var mojpassResponse = (HttpWebResponse)mojpassRequest.GetResponse();
                var mojpassResponseString = "";
                using (var streamReader = new StreamReader(mojpassResponse.GetResponseStream()))
                {
                    mojpassResponseString = streamReader.ReadToEnd();
                    if (Globals.isDebug)
                        Logger.Info("[MSAuth]", $"Mojpass Response: {mojpassResponseString}");
                    else
                        Logger.Info("[MSAuth]", "Got Mojpass response");
                }
                if (Globals.isDebug)
                    Logger.Info("[MSAuth]", $"Mojpass code: {mojpassResponse.StatusCode}");

                if (mojpassResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine($"[MSAuth] Success! Getting Mppass..");

                    //Get the actual Mppass
                    var mppassRequest = (HttpWebRequest)WebRequest.Create($"http://api.betacraft.uk/getmppass.jsp?user={playerName}&server={ip}:{port}");

                    mppassRequest.Method = "POST";
                    mppassRequest.ContentType = "application/x-www-form-urlencoded";

                    var mppassResponse = (HttpWebResponse)mppassRequest.GetResponse();
                    var mppassResponseString = new StreamReader(mppassResponse.GetResponseStream()).ReadToEnd();
                    if (Globals.isDebug)
                        Logger.Info("[MSAuth]", $"MPpass Response: {mppassResponseString}");
                    else
                        Logger.Info("[MSAuth]", "Got Mppass response");
                    mpPass = mppassResponseString;
                }
                else
                {
                    Logger.Error("[MSAuth]", $"Mojpass request returned an error: {mojpassResponse.StatusCode}");
                    mpPass = "-";
                }
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth]", $"GetMpPass request returned an error: {e.Message}");
                hasErrored = true;
            }
        }

        public static void deviceFlow()
        {
            Logger.Info($"[MSAuth]", $"deviceFlow was called!");
            xblAuth();
            xstsAuth();
            minecraftAuth();
            verifyOwnership();
            //todo: only do if player owns the game
            getProfileInfo();

            if (hasErrored == true)
            {
                Logger.Error($"[MSAuth]", $"Could not authenticate you.");
                MessageBox.Show(errorMsg, "MS auth error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Globals.isDebug)
                    Logger.Info("[MSAuth]", $"Refresh token to save: {refreshToken}");
                Settings.sj.refreshToken = refreshToken;
                Settings.Save();
                if (Globals.isDebug)
                    Logger.Info("[MSAuth]", $"Saved refresh token: {Settings.sj.refreshToken}");
                HomeScreen.msPlayerName = playerName;
                Settings.sj.username = playerName;
                Settings.Save();
                HomeScreen.checkAuth();
            }
        }

        public static void usernameFromRefreshToken()
        {
            voidRefreshToken(Settings.sj.refreshToken);
            xblAuth();
            xstsAuth();
            minecraftAuth();
            verifyOwnership();
            //todo: only do if player owns the game
            getProfileInfo();

            if (hasErrored == true)
            {
                Logger.Error($"[MSAuth]", $"Could not authenticate you.");
                hasErrored = false;
            }
            else
            {
                //Logger.log(ConsoleColor.Blue, ConsoleColor.Gray, $"[MSAuth]", $"Got username: {playerName}");
                HomeScreen.msPlayerName = playerName;
                Settings.sj.username = playerName;
                Settings.Save();
            }
        }

        public static void onGameStart(bool getMppass, String ip, String port)
        {
            voidRefreshToken(Settings.sj.refreshToken);
            xblAuth();
            xstsAuth();
            minecraftAuth();
            verifyOwnership();
            if (getMppass == true)
            {
                getMpPass(ip, port);
            }
            //todo: only do if player owns the game
            getProfileInfo();

            if (hasErrored == true)
            {
                Logger.Error($"[MSAuth]", $"Could not authenticate you.");
                hasErrored = false;
            }
            else
            {
                JavaLauncher.msPlayerName = playerName;
                JavaLauncher.msPlayerUUID = playerUUID;
                JavaLauncher.msPlayerAccessToken = mcAccessToken;
                JavaLauncher.msPlayerMPPass = mpPass;

                Settings.sj.username = playerName;
                Settings.Save();

                /*LaunchJava.launchPlayerName = playerName;
                LaunchJava.launchPlayerUUID = playerUUID;
                LaunchJava.launchPlayerAccessToken = mcAccessToken;
                LaunchJava.launchMpPass = mpPass;*/
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://microsoft.com/link");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(deviceFlowPing);
            myTimer.Interval = 5000; // 1000 ms is one second
            myTimer.Start();
            while (deviceCurrent <= 180)
            {

            }
            myTimer.Stop();
            myTimer.Dispose();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Logger.Error("[MSAuth]", "User cancelled the operation!");
            hasErrored = true;
            this.Close();
        }

        private void MSAuth_FormClosing(object sender, FormClosingEventArgs e)
        {
            deviceCurrent = 181;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Logger.Info("[MSAuth]", "Worker completed!");
            deviceFlow();
            this.Close();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(textBox1, "Click to copy to clipboard");
        }
    }
}
