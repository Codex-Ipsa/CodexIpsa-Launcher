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
        public static string selectedInstance;
        public static string createName;
        public static string tempName;
        public static int instanceInt = 1;
        public static int cfgVer = 1;

        public static string cfgGameVer = "b1.7.3";
        public static string cfgTypeVer = "a106";

        public InstanceManager()
        {
            InitializeComponent();
            //Set the editions list
            List<string> editionsList = new List<string>();
            editionsList.Add("Java Edition");
            editionsList.Add("Xbox 360 Edition");
            editionsList.Add("Playstation 3 Edition");
            editionBox.DataSource = editionsList;
            editionBox.Refresh();

            //Set the versions list for java
            List<string> versionList = new List<string>();
            List<string> typeJavaList = new List<string>();
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(Globals.javaJson);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    versionList.Add(vers.verName);
                    typeJavaList.Add(vers.verType);
                }
            }
            verBox.DataSource = versionList;
            verBox.Refresh();
            cfgGameVer = verBox.Text;
            int index = verBox.FindString(cfgGameVer);
            cfgTypeVer = typeJavaList[index];
        }

        public static void createInstance()
        {
            Console.WriteLine("TEMPNAME " + tempName);

            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance");
            if (!Directory.Exists($"{Globals.currentPath}\\bin\\instance\\{tempName}"))
            {
                Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance\\{tempName}");
                Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance\\{tempName}\\game");

                using (FileStream fs = File.Create($"{Globals.currentPath}\\bin\\instance\\{tempName}\\instance.cfg"))
                {
                    byte[] config = new UTF8Encoding(true).GetBytes($"[\n{{\n\"gameVer\":\"{cfgGameVer}\"\n}},\n{{\n\"typeVer\":\"{cfgTypeVer}\"\n}}\n]");
                    fs.Write(config, 0, config.Length);
                }

                instanceInt = 1;

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
                List<string> typeJavaList = new List<string>();
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(Globals.javaJson);
                    List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                    foreach (var vers in data)
                    {
                        typeJavaList.Add(vers.verType);
                    }
                }
                int index = verBox.FindString(cfgGameVer);
                cfgTypeVer = typeJavaList[index];
                Console.WriteLine("cfgTypeVer: " + cfgTypeVer);
            }
        }
    }
}
