using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using Color = System.Drawing.Color;

namespace MCLauncher
{
    public partial class HomeScreen : UserControl
    {
        public static HomeScreen Instance;
        public static string selectedEdition = "java"; //TODO: LOAD THIS FROM INSTANCE
        public static string msPlayerName;
        public static string selectedInstance = "Default"; //TODO: SAVE LAST OPENED INSTANCE AND LOAD It here

        public HomeScreen()
        {
            Instance = this;
            InitializeComponent();

            //Load lang
            btnPlay.Text = Strings.btnPlay;
            btnLogIn.Text = Strings.btnLogIn;
            btnLogOut.Text = Strings.btnLogOut;
            btnNewInst.Text = Strings.btnNewInst;
            btnEditInst.Text = Strings.btnEditInst;
            lblSelInst.Text = Strings.lblSelInst;
            lblWelcome.Text = Strings.lblWelcome;
            lblReady.Text = Strings.lblReady;

            pnlChangelog.AutoScroll = true;

            if (File.Exists($"{Globals.currentPath}\\.codexipsa\\data\\seasonalDirt.png"))
            {
                panel1.BackgroundImage = Image.FromFile($"{Globals.currentPath}\\.codexipsa\\data\\seasonalDirt.png");
            }
            if (File.Exists($"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png"))
            {
                this.BackgroundImage = Image.FromFile($"{Globals.currentPath}\\.codexipsa\\data\\seasonalStone.png");
            }

            //Load browser URL
            /*if(Globals.offlineMode == false)
            {
                webBrowser.Url = new Uri(Globals.changelog, UriKind.Absolute);
                webBrowser.Refresh();
                Logger.logMessage($"[HomeScreen]", $"Changelog loaded");


            }
            else
            {
                webBrowser.DocumentText = $"<center><p>{Strings.htmlChangelogFailed}</p></center>";
                webBrowser.Refresh();
                Logger.logError($"[HomeScreen]", $"Failed to load changelog");
            }*/
            //JSON changelog system
            loadChangelog();

            //Check if user is logged in
            checkAuth();

            if (!Directory.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\Default"))
            {
                InstanceManager man = new InstanceManager("Default", "initial");
                man.ShowDialog();
            }       

            //Load instance list
            loadInstanceList();
            string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{selectedInstance}\\instance.cfg");
            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

            //Set the LaunchJava stuff
            foreach (var vers in data)
            {
                LaunchJava.launchVerName = vers.instVer;
                LaunchJava.launchVerUrl = vers.instUrl;
                LaunchJava.launchVerType = vers.instType;
            }
            Instance.lblReady.Text = $"{Strings.lblReady} {LaunchJava.launchVerName}";

        }

        public static void checkAuth()
        {
            if (Properties.Settings.Default.msRefreshToken == String.Empty || Properties.Settings.Default.msRefreshToken == null)
            {
                Logger.logError($"[HomeScreen]", "User is not logged in");
                Instance.btnLogOut.Visible = false;
                Instance.btnLogIn.Visible = true;
                Instance.lblWelcome.Text = $"{Strings.lblWelcome} Guest";
                LaunchJava.launchPlayerName = "Guest";
                LaunchJava.launchPlayerUUID = "null";
                LaunchJava.launchPlayerAccessToken = "null";
                LaunchJava.launchMpPass = "null";
                if (Globals.requireAuth == true)
                {
                    Instance.btnPlay.Enabled = false;
                    Instance.cmbInstaces.Enabled = false;
                    Instance.btnEditInst.Enabled = false;
                    Instance.btnNewInst.Enabled = false;
                    Instance.lblLogInWarn.Text = Strings.lblLogInWarn;
                }
                else
                {
                    Instance.btnPlay.Enabled = true;
                    Instance.cmbInstaces.Enabled = true;
                    Instance.btnEditInst.Enabled = true;
                    Instance.btnNewInst.Enabled = true;
                    Instance.lblLogInWarn.Text = Strings.lblLogInWarn_Debug;
                }
            }
            else
            {
                Logger.logMessage($"[HomeScreen]", "User is logged in, re-checking everything");
                MSAuth.usernameFromRefreshToken();
                if (MSAuth.hasErrored == true)
                {
                    Logger.logMessage($"[HomeScreen]", $"MSAuth returned hasErrored. Please re-log in.");
                    MSAuth.hasErrored = false;
                    Properties.Settings.Default.msRefreshToken = String.Empty;
                    Properties.Settings.Default.Save();
                    checkAuth();
                }
                else
                {
                    Instance.btnLogOut.Visible = true;
                    Instance.btnLogIn.Visible = false;
                    Instance.lblWelcome.Text = $"{Strings.lblWelcome} {msPlayerName}";
                    Instance.btnPlay.Enabled = true;
                    Instance.lblLogInWarn.Text = "";
                }
            }
        }

        public void loadInstanceList()
        {
            List<string> instanceList = new List<string>();
            string[] dirs = Directory.GetDirectories($"{Globals.currentPath}\\.codexipsa\\instance\\", "*");

            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if (File.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\{dirName}\\instance.cfg"))
                {
                    instanceList.Add(dirName);
                }
                else
                {
                    //do nothing
                }

                //Console.WriteLine(dir);
            }
            cmbInstaces.DataSource = instanceList;
            cmbInstaces.Refresh();
            LaunchJava.instanceName = cmbInstaces.Text;
        }

        public static void reloadInstance()
        {
            /*if (InstanceManager.mode != "initial")
            {
                InstanceManager.selectedInstance = Instance.cmbInstaces.Text;
            }

            Logger.logMessage("[HomeScreen]", $"Selected instance: {InstanceManager.selectedInstance}");

            string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{InstanceManager.selectedInstance}\\instance.cfg");
            List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

            //Set the LaunchJava stuff
            foreach (var vers in data)
            {
                LaunchJava.launchVerName = vers.instVer;
                LaunchJava.launchVerUrl = vers.instUrl;
                LaunchJava.launchVerType = vers.instType;
                LaunchJava.launchWidth = vers.instResWidth;
                LaunchJava.launchHeight = vers.instResHeight;
                LaunchJava.launchXms = vers.instRamMin;
                LaunchJava.launchXmx = vers.instRamMax;
                //LaunchJava.javaLocation = vers.instCustJava;
                //LaunchJava.use //TODO!!!
            }
            LaunchJava.currentInstance = Instance.cmbInstaces.Text;
            Instance.lblReady.Text = "Ready to play Minecraft " + LaunchJava.launchVerName;*/
        }

        public static void loadChangelog()
        {
            using (WebClient client = new WebClient())
            {
                int y = 5;
                int x = 2;
                string json = client.DownloadString(Globals.changelogJson);
                List<changelogJson> data = JsonConvert.DeserializeObject<List<changelogJson>>(json);

                foreach (var vers in data)
                {
                    if (vers.type == "header")
                    {
                        Label labelHead = new Label();
                        labelHead.Text = $"{vers.title}";
                        labelHead.Location = new Point(x, y);
                        labelHead.Font = new Font("Arial", 16, FontStyle.Regular);
                        labelHead.AutoSize = true;
                        labelHead.ForeColor = Color.White;
                        Instance.pnlChangelog.Controls.Add(labelHead);
                        y += 14 * 3;
                    }
                    else if (vers.type == "post")
                    {
                        Label labelHead = new Label();
                        labelHead.Text = $"{vers.title}";
                        labelHead.Location = new Point(x, y);
                        labelHead.Font = new Font("Arial", 14, FontStyle.Regular);
                        labelHead.AutoSize = true;
                        labelHead.ForeColor = Color.White;
                        Instance.pnlChangelog.Controls.Add(labelHead);
                        y += 13 * 2;

                        Label labelDate = new Label();
                        labelDate.Text = $"{vers.date}";
                        labelDate.Location = new Point(x, y);
                        labelDate.Font = new Font("Arial", 12, FontStyle.Italic);
                        labelDate.AutoSize = true;
                        labelDate.ForeColor = Color.White;
                        Instance.pnlChangelog.Controls.Add(labelDate);
                        y += 12 * 2;

                        int strLog = 1;
                        string[] result = vers.content.Split(new[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
                        foreach(string s in result)
                        {
                            Label labelText = new Label();
                            labelText.Text = $"{s}";
                            labelText.Location = new Point(x, y);
                            labelText.Font = new Font("Arial", 12, FontStyle.Regular);
                            labelText.AutoSize = true;
                            labelText.ForeColor = Color.White;
                            Instance.pnlChangelog.Controls.Add(labelText);
                            if(strLog < result.Length)
                            {
                                y += 12 * 2;
                            }
                            else if(strLog >= result.Length)
                            {
                                y += 12 * 3;
                            }
                            strLog++;
                        }
                        strLog = 1;
                    }
                    else if (vers.type == "announcement")
                    {
                        Label labelHead = new Label();
                        labelHead.Text = $"{vers.title}";
                        labelHead.Location = new Point(x, y);
                        labelHead.Font = new Font("Arial", 16, FontStyle.Regular);
                        labelHead.AutoSize = true;
                        labelHead.ForeColor = Color.Red;
                        Instance.pnlChangelog.Controls.Add(labelHead);
                        y += 12 * 3;

                        /*if(vers.date != String.Empty)
                        {
                            Label labelDate = new Label();
                            labelDate.Text = $"{vers.date}";
                            labelDate.Location = new Point(x, y);
                            labelDate.Font = new Font("Arial", 12, FontStyle.Italic);
                            labelDate.AutoSize = true;
                            labelDate.ForeColor = Color.Red;
                            Instance.pnlChangelog.Controls.Add(labelDate);
                            y += 12 * 2;
                        }

                        if(vers.content !=  String.Empty)
                        {
                            Label labelText = new Label();
                            labelText.Text = $"{vers.content}";
                            labelText.Location = new Point(x, y);
                            labelText.Font = new Font("Arial", 12, FontStyle.Regular);
                            labelText.AutoSize = true;
                            labelText.ForeColor = Color.Red;
                            Instance.pnlChangelog.Controls.Add(labelText);
                            y += 12 * 3;
                        }*/
                    }
                }

                y = y -= 12 * 2;
                Label labelEmpty = new Label();
                labelEmpty.Text = $"";
                labelEmpty.Location = new Point(x, y);
                labelEmpty.Font = new Font("Arial", 12, FontStyle.Regular);
                labelEmpty.AutoSize = true;
                labelEmpty.ForeColor = Color.Red;
                Instance.pnlChangelog.Controls.Add(labelEmpty);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (selectedEdition == "java")
                LaunchJava.LaunchGame();

            else if (selectedEdition == "x360")
                LaunchXbox360.LaunchGame();

            else if (selectedEdition == "ps3")
                LaunchPS3.LaunchGame();

            else if (selectedEdition == "edu")
                LaunchJava.LaunchGame();
        }

        private void btnNewInst_Click(object sender, EventArgs e)
        {
            InstanceManager man = new InstanceManager("New profile", "new");
            man.ShowDialog();
        }

        private void btnEditInst_Click(object sender, EventArgs e)
        {
            InstanceManager man = new InstanceManager(cmbInstaces.Text, "edit");
            man.ShowDialog();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //Calling MSAuth
            Logger.logMessage($"[HomeScreen]", "Calling MSAuth");
            MSAuth auth = new MSAuth();
            auth.ShowDialog();

            if (MSAuth.hasErrored == true)
            {
                Logger.logMessage($"[HomeScreen]", $"MSAuth returned hasErrored. Please try again.");
                MSAuth.hasErrored = false;
            }
            else
            {
                Instance.btnLogOut.Visible = true;
                Instance.btnLogIn.Visible = false;
                Instance.lblWelcome.Text = $"{Strings.lblWelcome} {msPlayerName}";
                this.Refresh();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Logger.logMessage($"[HomeScreen]", "Logging out");
            LaunchJava.launchPlayerName = "Guest";
            LaunchJava.launchPlayerUUID = "null";
            LaunchJava.launchPlayerAccessToken = "null";
            LaunchJava.launchMpPass = "null";
            Properties.Settings.Default.msRefreshToken = String.Empty;
            Properties.Settings.Default.Save();
            checkAuth();
        }

        private void cmbInstaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadInstance();
        }

        private void cmbInstaces_Click(object sender, EventArgs e)
        {
            loadInstanceList();
        }

        private void pnlChangelog_Scroll(object sender, ScrollEventArgs e)
        {
            pnlChangelog.Invalidate();
        }
    }

    public class changelogJson
    {
        public string type { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string content { get; set; }
        public string brNote { get; set; }
    }
}
