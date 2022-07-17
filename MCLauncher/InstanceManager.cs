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



        public static string instCustDirectory = "";
        public static bool useCustDirectory = false;

        public static string instCustResWidth = "";
        public static string instCustResHeight = "";
        public static bool useCustResolution = false;

        public static string instCustRamMin = "1024";
        public static string instCustRamMax = "1024";
        public static bool useCustRam = false;

        public static string instCustJava = "";
        public static bool useCustJava = false;

        public static string instCustJvm = "";
        public static bool useCustJvm = false;

        public static string instCustMethod = "";
        public static bool useCustMethod = false;

        public static string instCustJar = "";
        public static bool useCustJar = false;

        public static bool useOfflineMode = false;

        public InstanceManager()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

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

            //Set mode dependant stuff
            if (mode == "new")
            {
                createBtn.Visible = true;
                saveBtn.Visible = false;
                instmodBtn.Visible = false;
                opendirBtn.Visible = false;

            }
            else if (mode == "edit")
            {
                createBtn.Visible = false;
                saveBtn.Visible = true;
                instmodBtn.Visible = true;
                opendirBtn.Visible = true;
                nameBox.Enabled = false;
            }

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

                    foreach (var vers in data)
                    {
                        cfgGameVer = vers.verName;
                        cfgLinkVer = vers.verLink;
                        cfgTypeVer = vers.verType;
                    }
                }
            }

            Console.WriteLine("TEMPNAME " + tempName);

            Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance");
            if (!Directory.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}"))
            {
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}");
                //Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}\\game");
                //Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}\\assets");
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}\\jarmods");

                using (FileStream fs = File.Create($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}\\instance.cfg"))
                {
                    byte[] config = new UTF8Encoding(true).GetBytes($"[\n{{\n" +
                        $"\"gameVer\":\"{cfgGameVer}\"," +
                        $"\n\"typeVer\":\"{cfgTypeVer}\"," +
                        $"\n\"linkVer\":\"{cfgLinkVer}\"," +
                        $"\n\"useCustDir\":\"{useCustDirectory}\"," +
                        $"\n\"custDir\":\"{instCustDirectory}\"," +
                        $"\n\"useCustRes\":\"{useCustResolution}\"," +
                        $"\n\"custResWidth\":\"{instCustResWidth}\"," +
                        $"\n\"custResHeight\":\"{instCustResHeight}\"," +
                        $"\n\"useCustRam\":\"{useCustRam}\"," +
                        $"\n\"custRamMin\":\"{instCustRamMin}\"," +
                        $"\n\"custRamMax\":\"{instCustRamMax}\"," +
                        $"\n\"useCustJava\":\"{useCustJava}\"," +
                        $"\n\"custJava\":\"{instCustJava}\"," +
                        $"\n\"useCustJvm\":\"{useCustJvm}\"," +
                        $"\n\"custJvm\":\"{instCustJvm}\"," +
                        $"\n\"useCustMethod\":\"{useCustMethod}\"," +
                        $"\n\"custMethod\":\"{instCustMethod}\"," +
                        $"\n\"useCustJar\":\"{useCustJar}\"," +
                        $"\n\"custJar\":\"{instCustJar}\"," +
                        $"\n\"useOfflineMode\":\"{useOfflineMode}\"" +
                        $"\n}}\n]");

                    fs.Write(config, 0, config.Length);
                }

                instanceInt = 1;

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

            if (Directory.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}"))
            {
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}");
                //Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}\\game");
                //Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}\\assets");
                Directory.CreateDirectory($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}\\jarmods");

                using (FileStream fs = File.Create($"{Globals.currentPath}\\.codexipsa\\instance\\{tempName}\\instance.cfg"))
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
                JavaCheck warn = new JavaCheck("Name can't be empty!");
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
                useCustDirectory = false;
                dirBox.Enabled = false;
                dirBtn.Enabled = false;
            }
            else
            {
                useCustDirectory = true;
                dirBox.Enabled = true;
                dirBtn.Enabled = true;
            }
        }

        private void javaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (javaBox.Enabled == true)
            {
                useCustJava = false;
                javaBox.Enabled = false;
                javaBtn.Enabled = false;
            }
            else
            {
                useCustJava = true;
                javaBox.Enabled = true;
                javaBtn.Enabled = true;
            }
        }

        private void jvmCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (jvmBox.Enabled == true)
            {
                useCustJvm = false;
                jvmBox.Enabled = false;
            }
            else
            {
                useCustJvm = true;
                jvmBox.Enabled = true;
            }
        }

        private void methodCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (methodBox.Enabled == true)
            {
                useCustMethod = false;
                methodBox.Enabled = false;
            }
            else
            {
                useCustMethod = true;
                methodBox.Enabled = true;
            }
        }

        private void custjarCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (custjarBox.Enabled == true)
            {
                useCustJar = false;
                custjarBox.Enabled = false;
                custjarBtn.Enabled = false;
            }
            else
            {
                useCustJar = true;
                custjarBox.Enabled = true;
                custjarBtn.Enabled = true;
            }
        }

        private void resCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (resBoxWidth.Enabled == true)
            {
                useCustResolution = false;
                resBoxWidth.Enabled = false;
                resBoxHeight.Enabled = false;
            }
            else
            {
                useCustResolution = true;
                resBoxWidth.Enabled = true;
                resBoxHeight.Enabled = true;
            }
        }

        private void ramCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (maxRamBox.Enabled == true)
            {
                useCustRam = false;
                maxRamBox.Enabled = false;
                minRamBox.Enabled = false;
            }
            else
            {
                useCustRam = true;
                maxRamBox.Enabled = true;
                minRamBox.Enabled = true;
            }
        }

        private void custjarBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open a game file";
            ofd.Filter = "JAR File (*.jar*) | *.jar*";
            DialogResult dr = ofd.ShowDialog();
            /*if (dr == DialogResult.OK)
            {
                verPath = ofd.FileName;
            }
            pathLabel.Text = verPath;*/
        }

        private void offlineModeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!offlineModeCheck.Checked)
            {
                useOfflineMode = false;
                Console.WriteLine("It is now unchecked.");
            }
            else
            {
                useOfflineMode = true;
                Console.WriteLine("It is now checked.");
            }
        }

        private void dirBox_TextChanged(object sender, EventArgs e)
        {
            instCustDirectory = dirBox.Text;
        }

        private void resBoxWidth_TextChanged(object sender, EventArgs e)
        {
            instCustResWidth = resBoxWidth.Text;
        }

        private void resBoxHeight_TextChanged(object sender, EventArgs e)
        {
            instCustResHeight = resBoxHeight.Text;
        }

        private void javaBox_TextChanged(object sender, EventArgs e)
        {
            instCustJava = javaBox.Text;
        }

        private void jvmBox_TextChanged(object sender, EventArgs e)
        {
            instCustJvm = jvmBox.Text;
        }

        private void methodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            instCustMethod = methodBox.Text;
        }

        private void custjarBox_TextChanged(object sender, EventArgs e)
        {
            instCustJar = custjarBox.Text;
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

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
