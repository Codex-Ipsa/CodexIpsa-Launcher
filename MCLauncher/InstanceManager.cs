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
using Newtonsoft.Json;

namespace MCLauncher
{
    public partial class InstanceManager : Form
    {
        public static string selectedInstance = "Default";
        public static string createName;
        public static string tempName;
        public static int instanceInt = 1;
        public static int cfgVer = 1;
        public static string mode;

        public static string cfgInstName;
        public static string cfgGameVer;
        public static string cfgTypeVer;
        public static string cfgLinkVer;

        public InstanceManager()
        {
            InitializeComponent();
            //Set mode dependant stuff
            if (mode == "new")
            {
                createBtn.Visible = true;
                saveBtn.Visible = false;
            }
            else if (mode == "edit")
            {
                createBtn.Visible = false;
                saveBtn.Visible = true;
            }
            //Set the editions list
            List<string> editionsList = new List<string>();
            editionsList.Add("Java Edition");
            editionsList.Add("Xbox 360 Edition");
            //editionsList.Add("Playstation 3 Edition");
            editionBox.DataSource = editionsList;
            editionBox.Refresh();

            //Set the versions list for java
            List<string> versionList = new List<string>();
            List<string> typeJavaList = new List<string>();
            List<string> linkJavaList = new List<string>();
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.javaJson);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    versionList.Add(vers.verName);
                    typeJavaList.Add(vers.verType);
                    linkJavaList.Add(vers.verLink);
                }
            }
            verBox.DataSource = versionList;
            verBox.Refresh();

            cfgGameVer = verBox.Text;
            int index = verBox.FindString(cfgGameVer);
            cfgTypeVer = typeJavaList[index];
            cfgLinkVer = linkJavaList[index];

            nameBox.Text = cfgInstName;
        }

        public static void createInstance()
        {
            if (mode == "initial")
            {
                //Set default version
                using (var client = new WebClient())
                {
                    string json = client.DownloadString(Globals.defaultVer);
                    List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                    //Set the LaunchJava defaults
                    foreach (var vers in data)
                    {
                        cfgGameVer = vers.verName;
                        cfgLinkVer = vers.verLink;
                        cfgTypeVer = vers.verType;
                    }
                }
            }
            Console.WriteLine("TEMPNAME " + tempName);

            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance");
            if (!Directory.Exists($"{Globals.currentPath}\\bin\\instance\\{tempName}"))
            {
                Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance\\{tempName}");
                Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance\\{tempName}\\game");
                Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance\\{tempName}\\assets");

                using (FileStream fs = File.Create($"{Globals.currentPath}\\bin\\instance\\{tempName}\\instance.cfg"))
                {
                    byte[] config = new UTF8Encoding(true).GetBytes($"[\n{{\n\"gameVer\":\"{cfgGameVer}\",\n\"typeVer\":\"{cfgTypeVer}\",\n\"linkVer\":\"{cfgLinkVer}\"\n}}\n]");

                    fs.Write(config, 0, config.Length);
                }

                instanceInt = 1;
                //What the fuck is this shit
                MainWindow.reloadInstance();

                foreach (var form in Application.OpenForms.OfType<InstanceManager>().ToList())
                    form.Close();
            }
            else
            {
                tempName = createName + "_" + instanceInt.ToString();
                instanceInt++;
                createInstance();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("TEMPNAME " + tempName);
            createName = nameBox.Text;
            tempName = createName;

            if (Directory.Exists($"{Globals.currentPath}\\bin\\instance\\{tempName}"))
            {
                using (FileStream fs = File.Create($"{Globals.currentPath}\\bin\\instance\\{tempName}\\instance.cfg"))
                {
                    byte[] config = new UTF8Encoding(true).GetBytes($"[\n{{\n\"gameVer\":\"{cfgGameVer}\",\n\"typeVer\":\"{cfgTypeVer}\",\n\"linkVer\":\"{cfgLinkVer}\"\n}}\n]");

                    fs.Write(config, 0, config.Length);
                }
                MainWindow.reloadInstance();
                foreach (var form in Application.OpenForms.OfType<InstanceManager>().ToList())
                    form.Close();
            }
            else
            {
                //do nothing
                MainWindow.reloadInstance();
                foreach (var form in Application.OpenForms.OfType<InstanceManager>().ToList())
                    form.Close();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if(nameBox.Text == string.Empty)
            {
                Warning warn = new Warning("Name can't be empty!");
                warn.ShowDialog();
            }
            else
            {
                createName = nameBox.Text;
                tempName = createName;
                createInstance();
            }
        }

        private void dirCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(dirBox.Enabled == true)
            {
                dirBox.Enabled = false;
            }
            else
            {
                dirBox.Enabled = true;
            }
        }

        private void javaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (javaBox.Enabled == true)
            {
                javaBox.Enabled = false;
            }
            else
            {
                javaBox.Enabled = true;
            }
        }

        private void jvmCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (jvmBox.Enabled == true)
            {
                jvmBox.Enabled = false;
            }
            else
            {
                jvmBox.Enabled = true;
            }
        }

        private void methodCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (methodBox.Enabled == true)
            {
                methodBox.Enabled = false;
            }
            else
            {
                methodBox.Enabled = true;
            }
        }

        private void custjarCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (custjarBox.Enabled == true)
            {
                custjarBox.Enabled = false;
            }
            else
            {
                custjarBox.Enabled = true;
            }
        }

        private void resCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (resBoxX.Enabled == true)
            {
                resBoxX.Enabled = false;
                resBoxY.Enabled = false;
            }
            else
            {
                resBoxX.Enabled = true;
                resBoxY.Enabled = true;
            }
        }

        private void ramCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (maxRamBox.Enabled == true)
            {
                maxRamBox.Enabled = false;
                minRamBox.Enabled = false;
            }
            else
            {
                maxRamBox.Enabled = true;
                minRamBox.Enabled = true;
            }
        }

        private void editionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editionBox.Text == "Java Edition")
            {
                List<string> versionList = new List<string>();
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(Globals.javaJson);
                    List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                    foreach (var vers in data)
                    {
                        versionList.Add(vers.verName);
                    }
                }
                VerSelect.checkTab = "java";
                verBox.DataSource = versionList;
                verBox.Refresh();
                cfgGameVer = verBox.Text;
            }
            else if (editionBox.Text == "Xbox 360 Edition")
            {
                List<string> versionList = new List<string>();
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(Globals.x360Json);
                    List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                    foreach (var vers in data)
                    {
                        versionList.Add(vers.verName);
                    }
                }
                VerSelect.checkTab = "x360";
                verBox.DataSource = versionList;
                verBox.Refresh();
                cfgTypeVer = "x360";
            }
            else if (editionBox.Text == "Playstation 3 Edition")
            {
                List<string> versionList = new List<string>();
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(Globals.ps3Json);
                    List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                    foreach (var vers in data)
                    {
                        versionList.Add(vers.verName);
                    }
                }
                VerSelect.checkTab = "ps3";
                verBox.DataSource = versionList;
                verBox.Refresh();
                cfgTypeVer = "ps3";
            }
        }

        private void verBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cfgGameVer = verBox.Text;

            if (editionBox.Text == "Java Edition")
            {
                List<string> versionList = new List<string>();
                List<string> typeJavaList = new List<string>();
                List<string> linkJavaList = new List<string>();
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(Globals.javaJson);
                    List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                    foreach (var vers in data)
                    {
                        versionList.Add(vers.verName);
                        typeJavaList.Add(vers.verType);
                        linkJavaList.Add(vers.verLink);
                    }
                }

                cfgGameVer = verBox.Text;
                int index = verBox.FindString(cfgGameVer);
                cfgTypeVer = typeJavaList[index];
                cfgLinkVer = linkJavaList[index];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
