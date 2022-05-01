using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class VerSelect : Form
    {
        public static string checkTab = "java";
        List<string> linksJavaList = new List<string>();
        List<string> typeJavaList = new List<string>();

        List<string> linksJavaModsList = new List<string>();
        List<string> linksBaseJavaModsList = new List<string>();
        List<string> linksJavaForgeList = new List<string>();
        List<string> typeJavaModsList = new List<string>();

        List<string> linksX360List = new List<string>();
        
        List<string> linksPS3List = new List<string>();

        public VerSelect()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            if(!Globals.offlineMode)
            {
                LoadJavaList();
            }
            else
            {
                //TODO: get the already downloaded versions and display them
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Globals.offlineMode)
            {
                if (checkTab == "java")
                {
                    LaunchJava.selectedVer = listBox1.Items[listBox1.SelectedIndex].ToString();
                    int index = listBox1.FindString(LaunchJava.selectedVer);
                    LaunchJava.linkToJar = linksJavaList[index];
                    LaunchJava.typeVer = typeJavaList[index];
                    label1.Text = "Selected: Java " + LaunchJava.selectedVer;
                    //infoBox.Text = $"Java Edition\nVersionGoesHere\nReleaseDate\nSimpleInfoGoesHere";
                }
                else if (checkTab == "javaMod")
                {
                    LaunchJavaMod.selectedVer = listBox1.Items[listBox1.SelectedIndex].ToString();
                    int index = listBox1.FindString(LaunchJavaMod.selectedVer);
                    label1.Text = "Selected: Mod " + LaunchJavaMod.selectedVer;
                    LaunchJavaMod.linkToJar = linksJavaModsList[index];
                    LaunchJavaMod.linkToBase = linksBaseJavaModsList[index];
                    LaunchJavaMod.linkToForge = linksJavaForgeList[index];
                    LaunchJavaMod.modType = typeJavaModsList[index];
                    //infoBox.Text = $"{LaunchMod.selectedVer}\nVersionGoesHere\nReleaseDate\nSimpleInfoGoesHere";
                }
                else if (checkTab == "x360")
                {
                    LaunchXbox360.selectedVer = listBox1.Items[listBox1.SelectedIndex].ToString();
                    int index = listBox1.FindString(LaunchXbox360.selectedVer);
                    label1.Text = "Selected: Xbox 360 " + LaunchXbox360.selectedVer;
                    LaunchXbox360.linkToVer = linksX360List[index];
                    //infoBox.Text = $"Xbox 360 Edition\nVersionGoesHere\nReleaseDate\nSimpleInfoGoesHere";
                }
                else if (checkTab == "ps3")
                {
                    LaunchPS3.selectedVer = listBox1.Items[listBox1.SelectedIndex].ToString();
                    int index = listBox1.FindString(LaunchPS3.selectedVer);
                    label1.Text = "Selected: PS3 " + LaunchPS3.selectedVer;
                    LaunchPS3.linkToVer = linksPS3List[index];
                    //infoBox.Text = $"Xbox 360 Edition\nVersionGoesHere\nReleaseDate\nSimpleInfoGoesHere";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void javaEdBtn_Click(object sender, EventArgs e)
        {
            if (!Globals.offlineMode)
            {
                LoadJavaList();
            }
        }

        private void javaModBtn_Click(object sender, EventArgs e)
        {
            if (!Globals.offlineMode)
            {
                LoadJavaModList();
            }
        }

        private void x360EdBtn_Click(object sender, EventArgs e)
        {
            if (!Globals.offlineMode)
            {
                LoadXbox360List();
            }
        }

        private void ps3EdBtn_Click(object sender, EventArgs e)
        {
            if (!Globals.offlineMode)
            {
                LoadPS3List();
            }
        }

        public void LoadJavaList()
        {
            List<string> versionListJava = new List<string>();
            checkTab = "java";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.javaJson);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    versionListJava.Add(vers.verName);
                    linksJavaList.Add(vers.verLink);
                    typeJavaList.Add(vers.verType);
                }
            }
            listBox1.DataSource = versionListJava;

            listBox1.Refresh();
        }

        public void LoadJavaModList()
        {
            List<string> versionJavaModList = new List<string>();
            checkTab = "javaMod";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.javaModJson);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    versionJavaModList.Add(vers.modID);
                    linksJavaModsList.Add(vers.modLink);
                    linksBaseJavaModsList.Add(vers.baseVer);
                    linksJavaForgeList.Add(vers.modForgeVer);
                    typeJavaModsList.Add(vers.modType);
                }
            }
            listBox1.DataSource = versionJavaModList;

            listBox1.Refresh();
        }

        public void LoadXbox360List()
        {
            List<string> versionListX360 = new List<string>();
            checkTab = "x360";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.x360Json);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    versionListX360.Add(vers.verName);
                    linksX360List.Add(vers.verLink);
                }
            }
            listBox1.DataSource = versionListX360;

            listBox1.Refresh();
        }

        public void LoadPS3List()
        {
            List<string> versionListPS3 = new List<string>();
            checkTab = "ps3";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.ps3Json);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    versionListPS3.Add(vers.verName);
                    linksPS3List.Add(vers.verLink);
                }
            }
            listBox1.DataSource = versionListPS3;

            listBox1.Refresh();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCustom loadCustom = new LoadCustom();
            loadCustom.ShowDialog();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            SelectVerInfo verInfo = new SelectVerInfo();
            verInfo.ShowDialog();
        }
    }
}
