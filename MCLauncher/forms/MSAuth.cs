using MCLauncher.classes;
using MCLauncher.json.launcher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class MSAuth : Form
    {
        //auth info
        public static String deviceCode;

        //user info
        public static String msAccessToken;
        public static String msRefreshToken;

        //error to display
        public static String errorMsg = "An error happened during the login process!\nCheck the console for further information and try again.";

        //for checking initial time to wait for auth
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

            deviceCurrent = 0;

            String url = "https://login.microsoftonline.com/consumers/oauth2/v2.0/devicecode?client_id=bee0ffd1-4143-41ef-bdf6-fe15d5549c09&scope=XboxLive.signin+offline_access"; //this needs to have offline access at the end
            String response = Http.getUrl(url);
            if (Globals.isDebug)
                Logger.Info("[MSAuth]", $"deviceflow response: {response}");

            AuthJson json = JsonConvert.DeserializeObject<AuthJson>(response);
            deviceCode = json.device_code;
            deviceLimit = json.expires_in;

            textBox1.Text = json.user_code;
            textBox1.ReadOnly = true;

            Logger.Info("[MSAuth]", $"To sign in, use a web browser to open the page {json.verification_uri} and enter the code {json.user_code} to authenticate.");
            Logger.Info("[MSAuth]", $"Device code: {deviceCode}");
            this.Refresh();
            backgroundWorker1.RunWorkerAsync();
            //this.Close();
        }

        public static void deviceFlowPing(object source, ElapsedEventArgs e)
        {
            if (Globals.isDebug)
                Logger.Info("[MSAuth/deviceFlowPing]", $"called! {deviceCurrent}");

            String url = "https://login.microsoftonline.com/consumers/oauth2/v2.0/token";
            String data = "grant_type=urn:ietf:params:oauth:grant-type:device_code";
            data += "&client_id=bee0ffd1-4143-41ef-bdf6-fe15d5549c09";
            data += $"&device_code={deviceCode}";

            //This has to be done because of MS's shitty service - thanks!
            try
            {
                String response = Http.postUrl(url, data);

                deviceCurrent = deviceLimit + 1;
                if (Globals.isDebug)
                    Logger.Info("[MSAuth/deviceFlowPing]", $"Response string: {response}");
                else
                    Logger.Info("[MSAuth/deviceFlowPing]", "Got Token response!");

                AuthJson json = JsonConvert.DeserializeObject<AuthJson>(response);
                msAccessToken = json.access_token;
                msRefreshToken = json.refresh_token;
            }
            catch (WebException)
            {
                deviceCurrent++;
            }
        }

        //authenticate with xbox live
        public static String[] xblAuth(String msAccess)
        {
            try
            {
                String url = "https://user.auth.xboxlive.com/user/authenticate";
                String data = $"{{\"Properties\": {{\"AuthMethod\": \"RPS\",\"SiteName\": \"user.auth.xboxlive.com\",\"RpsTicket\": \"d={msAccess}\"}},\"RelyingParty\": \"http://auth.xboxlive.com\",\"TokenType\": \"JWT\"}}";
                String response = Http.postJson(url, data);

                if (Globals.isDebug)
                    Logger.Info($"[MSAuth/xblAuth]", $"response: {response}");

                AuthJson json = JsonConvert.DeserializeObject<AuthJson>(response);
                return new string[] { json.Token, json.DisplayClaims.xui[0].uhs };
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth/xblAuth]", $"returned an error: {e.Message}");
                return null;
            }
        }

        //get xsts token
        public static String getXstsToken(String xblToken)
        {
            try
            {
                String url = "https://xsts.auth.xboxlive.com/xsts/authorize";
                String data = $"{{\"Properties\": {{\"SandboxId\": \"RETAIL\",\"UserTokens\": [\"{xblToken}\"]}},\"RelyingParty\": \"rp://api.minecraftservices.com/\",\"TokenType\": \"JWT\"}}";
                String response = Http.postJson(url, data);

                if (Globals.isDebug)
                    Logger.Info($"[MSAuth/xstsAuth]", $"response: {response}");

                AuthJson json = JsonConvert.DeserializeObject<AuthJson>(response);
                Logger.Info($"[MSAuth/xstsAuth]", $"xError: {json.XErr}");

                return json.Token;
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth/xstsAuth]", $"returned an error: {e.Message}");
                return null;
            }
        }

        //authenticate with minecraft
        public static String getMinecraftToken(String userHash, String xstsToken)
        {
            try
            {
                String url = "https://api.minecraftservices.com/authentication/login_with_xbox";
                String data = $"{{\"identityToken\": \"XBL3.0 x={userHash};{xstsToken}\"}}";
                String response = Http.postJson(url, data);

                if (Globals.isDebug)
                    Logger.Info($"[MSAuth/minecraftAuth]", $"response: {response}");

                AuthJson json = JsonConvert.DeserializeObject<AuthJson>(response);
                return json.access_token;
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth/minecraftAuth]", $"returned an error: {e.Message}");
                return null;
            }
        }

        //check game ownership
        public static void verifyOwnership(String accessToken)
        {
            try
            {
                String url = "https://api.minecraftservices.com/entitlements/mcstore";
                Dictionary<String, String> headers = new Dictionary<String, String>();
                headers.Add("Authorization", $"Bearer {accessToken}");

                String response = Http.getJson(url, headers);

                if (Globals.isDebug)
                    Logger.Info($"[MSAuth/verifyOwnership]", $"response: {response}");
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth/verifyOwnership]", $"returned an error: {e.Message}");
            }
            //TODO: VERIFY THE USER ACTALLY OWNS THE GAME, ALONG OTHER GAMES LIKE BEDROCK AND DUNGEONS [maybe it works without it?]
        }

        //get profile info
        public static String[] getProfileInfo(String accessToken)
        {
            try
            {
                String url = "https://api.minecraftservices.com/minecraft/profile";
                Dictionary<String, String> headers = new Dictionary<String, String>();
                headers.Add("Authorization", $"Bearer {accessToken}");

                String response = Http.getJson(url, headers);

                if (Globals.isDebug)
                    Logger.Info($"[MSAuth/getProfileInfo]", $"response: {response}");

                AuthJson json = JsonConvert.DeserializeObject<AuthJson>(response);
                return new String[] { json.name, json.id };
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth/getProfileInfo]", $"returned an error: {e.Message}");
                errorMsg = "Seems like you don't own Minecraft on this account.\nTry another or buy the game at minecraft.net!";
                return null;
            }
        }

        //gets access token from refresh token
        public static String fromRefreshToken(String refreshToken)
        {
            try
            {
                String url = "https://login.live.com/oauth20_token.srf";
                String data = "client_id=" + Uri.EscapeDataString("bee0ffd1-4143-41ef-bdf6-fe15d5549c09");
                data += "&refresh_token=" + Uri.EscapeDataString($"{refreshToken}");
                data += "&grant_type=" + Uri.EscapeDataString("refresh_token");
                data += "&redirect_uri=" + Uri.EscapeDataString("https://codex-ipsa.cz/auth");
                String response = Http.postUrl(url, data);

                if (Globals.isDebug)
                    Logger.Info($"[MSAuth/fromRefreshToken]", $"response: {response}");

                AuthJson json = JsonConvert.DeserializeObject<AuthJson>(response);
                return json.access_token;
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth/fromRefreshToken]", $"returned an error: {e.Message}");
                return null;
            }
        }

        //notify session servers on joining a server
        public static void onServerJoin(String ip, String port, String accessToken, String playerUUID)
        {
            Logger.Info("[MSAuth/onServerJoin]", $"ip: {ip}, port: {port}");

            try
            {
                String myIP = Globals.client.DownloadString("http://checkip.amazonaws.com/");
                myIP = myIP.Replace("\n", String.Empty);

                var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(myIP));
                string sha1 = string.Concat(hash.Select(b => b.ToString("x2")));
                if (Globals.isDebug)
                    Logger.Info("[MSAuth]", $"sha1 serverId: {sha1}");

                String url = "https://sessionserver.mojang.com/session/minecraft/join";
                String data = $"{{\"serverId\": \"{sha1}\",\"accessToken\": \"{accessToken}\",\"selectedProfile\": \"{playerUUID}\"}}";
                HttpStatusCode status = Http.postJsonStatus(url, data);

                if (status == HttpStatusCode.NoContent)
                    Logger.Info($"[MSAuth/onServerJoin]", "Success!");
                else
                    Logger.Error("[MSAuth/onServerJoin]", $"got a wrong statusCode: {status}");
            }
            catch (WebException e)
            {
                Logger.Error("[MSAuth/onServerJoin]", $"returned an error: {e.Message}");
            }
        }

        //login for the first time
        public static void deviceFlow()
        {
            String[] xblInfo = xblAuth(msAccessToken);
            if (xblInfo != null)
            {
                String xblToken = xblInfo[0];
                String xblUser = xblInfo[1];

                String xstsToken = getXstsToken(xblToken);
                if (xblToken != null)
                {
                    String accessToken = getMinecraftToken(xblUser, xstsToken);
                    if (accessToken != null)
                    {
                        verifyOwnership(accessToken);

                        //todo: only do if player owns the game
                        String[] profileInfo = getProfileInfo(accessToken); //name, id
                        if (profileInfo != null)
                        {
                            String playerName = profileInfo[0];
                            String playerUUID = profileInfo[1];

                            Settings.sj.refreshToken = msRefreshToken;
                            Settings.Save();

                            HomeScreen.msPlayerName = playerName;
                            JavaLauncher.msPlayerName = playerName;
                            JavaLauncher.msPlayerUUID = playerUUID;
                            JavaLauncher.msPlayerAccessToken = accessToken;
                            Settings.sj.username = playerName;
                            Settings.Save();

                            Logger.Info($"[MSAuth]", $"Logged in successfully!");
                            HomeScreen.loadUserInfo(playerName, "");
                            HomeScreen.enableButtons(true);
                            return;
                        }
                    }
                }
            }

            Logger.Error($"[MSAuth]", $"Could not authenticate you.");
            if (errorMsg != null)
                MessageBox.Show(errorMsg, "Authentication error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Settings.sj.refreshToken = null;
            Settings.Save();

            HomeScreen.loadUserInfo("Guest", Strings.sj.lblLogInWarn);
            HomeScreen.enableButtons(false);
        }

        //logs in the user on the start of launcher if already logged in before
        public static void refreshAuth()
        {
            String msAccess = fromRefreshToken(Settings.sj.refreshToken);
            if (msAccess != null)
            {
                String[] xblInfo = xblAuth(msAccess);
                if (xblInfo != null)
                {
                    String xblToken = xblInfo[0];
                    String xblUser = xblInfo[1];

                    String xstsToken = getXstsToken(xblToken);
                    if (xblToken != null)
                    {
                        String accessToken = getMinecraftToken(xblUser, xstsToken);
                        if (accessToken != null)
                        {
                            verifyOwnership(accessToken);

                            //todo: only do if player owns the game
                            String[] profileInfo = getProfileInfo(accessToken); //name, id
                            if (profileInfo != null)
                            {
                                String playerName = profileInfo[0];
                                String playerUUID = profileInfo[1];

                                HomeScreen.msPlayerName = playerName;
                                JavaLauncher.msPlayerName = playerName;
                                JavaLauncher.msPlayerUUID = playerUUID;
                                JavaLauncher.msPlayerAccessToken = accessToken;

                                Settings.sj.username = playerName;
                                Settings.Save();

                                Logger.Info($"[MSAuth]", $"Logged in successfully!");
                                HomeScreen.loadUserInfo(playerName, "");
                                HomeScreen.enableButtons(true);
                                return;
                            }
                        }
                    }
                }
            }

            Logger.Error($"[MSAuth]", $"Could not authenticate you.");
            if (errorMsg != null)
                MessageBox.Show(errorMsg, "Authentication error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Settings.sj.refreshToken = null;
            Settings.Save();

            HomeScreen.loadUserInfo("Guest", Strings.sj.lblLogInWarn);
            HomeScreen.enableButtons(false);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://microsoft.com/link");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            Logger.Info("[MSAuth]", $"Waiting for user to log in...");
            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(deviceFlowPing);
            myTimer.Interval = 5000; // 1000 ms is one second
            myTimer.Start();
            while (deviceCurrent <= deviceLimit / 5)
            {

            }
            myTimer.Stop();
            myTimer.Dispose();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Logger.Error("[MSAuth]", "User cancelled the operation!");
            errorMsg = null;
            this.Close();
        }

        private void MSAuth_FormClosing(object sender, FormClosingEventArgs e)
        {
            deviceCurrent = deviceLimit + 1;
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
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(textBox1, "Click to copy to clipboard");
        }
    }
}
