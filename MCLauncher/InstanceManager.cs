using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public static InstanceManager This;
        public static List<string> editionNames = new List<string>() { "Java Edition", "MinecraftEdu" }; //Xbox 360 Edition, Playstation 3 Edition, MinecraftEdu
        public static List<string> editionUrls = new List<string>() { Globals.javaJson, Globals.javaeduJson };

        public static List<string> varNames;
        public static List<string> varValues;

        public static List<string> verList = new List<string>();
        public static List<string> typeList = new List<string>();
        public static List<string> urlList = new List<string>();

        public static string name;
        public static string edition;
        public static string version;
        public static string type;
        public static string url;

        public static string directory;
        public static int resolutionX;
        public static int resolutionY;
        public static int ramMin;
        public static int ramMax;

        public static string customJava;
        public static bool useCustomJava = false;
        public static string jvmArgs;
        public static bool useJvmArgs = false;
        public static string launchMethod;
        public static bool useLaunchMethod = false;
        public static bool offlineMode;

        public static string tempName;
        public static int tempInt = 0;

        public InstanceManager(string instanceName, string mode)
        {
            This = this;
            InitializeComponent();

            tempName = instanceName;
            Start(instanceName, mode);
        }

        public static void Start(string instanceName, string mode)
        {
            verList.Clear();
            typeList.Clear();
            urlList.Clear();
            if (mode == "initial")
            {
                loadDefault(instanceName, "initial");
                saveInstance("Default", "initial");
            }
            else if (mode == "new")
            {
                Logger.logError("[InstanceManager]", $"{tempName}_{tempInt}");
                //TODO this throws a stackoverflow for some reason
                if (File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\instance.cfg"))
                {
                    tempInt++;
                    Start($"{tempName}_{tempInt}", "new");
                }
                else
                {
                    loadDefault(instanceName, "new");
                    tempInt = 0;
                    tempName = "";
                }
            }
            else if (mode == "edit")
            {
                loadDefault(instanceName, "edit");
            }
        }



        public static void loadDefault(string instanceName, string mode)
        {
            //this sets default stuff

            if (mode == "initial")
            {
                name = instanceName;
                edition = editionNames[0];
                using (var client = new WebClient())
                {
                    string json = client.DownloadString(Globals.defaultVer);
                    List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                    foreach (var vers in data)
                    {
                        version = vers.verName;
                        type = vers.verType;
                        url = vers.verLink;
                    }
                }
                directory = $"";
                resolutionX = 854;
                resolutionY = 480;
                ramMin = 512;
                ramMax = 512;
                customJava = "";
                useCustomJava = false;
                jvmArgs = "";
                useJvmArgs = false;
                launchMethod = "";
                useLaunchMethod = false;
                offlineMode = false;
            }
            else if (mode == "new")
            {
                //TODO
                name = instanceName;
                This.nameBox.Text = instanceName;
                This.editionBox.DataSource = editionNames;
                edition = editionNames[0];
                int i = This.editionBox.FindStringExact(edition);
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(editionUrls[i]);
                    List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                    foreach (var vers in data)
                    {
                        verList.Add(vers.verName);
                        typeList.Add(vers.verType);
                        urlList.Add(vers.verLink);
                    }
                }
                This.verBox.DataSource = verList;

                using (WebClient client = new WebClient())
                {
                    string json2 = client.DownloadString(Globals.defaultVer);
                    List<jsonObject> data2 = JsonConvert.DeserializeObject<List<jsonObject>>(json2);

                    foreach (var vers in data2)
                    {
                        version = vers.verName;
                        type = vers.verType;
                        url = vers.verLink;
                    }
                }

                directory = "";
                resolutionX = 854;
                This.resBoxHeight.Text = resolutionX.ToString();
                resolutionY = 480;
                This.resBoxWidth.Text = resolutionY.ToString();
                ramMin = 512;
                This.minRamBox.Value = ramMin;
                ramMax = 512;
                This.maxRamBox.Value = ramMax;
                customJava = "";
                useCustomJava = false;
                This.javaCheck.Checked = false;
                jvmArgs = "";
                useJvmArgs = false;
                This.jvmCheck.Checked = false;
                launchMethod = "";
                useLaunchMethod = false;
                This.methodCheck.Checked = false;
                offlineMode = false;
                This.offlineModeCheck.Checked = false;
            }
            else if(mode == "edit")
            {
                This.nameBox.Enabled = false;
                This.editionBox.DataSource = editionNames;
                This.editionBox.SelectedIndex = This.editionBox.FindStringExact(edition);

                int i = This.editionBox.FindStringExact(edition);
                using (WebClient client = new WebClient())
                {
                    string json2 = client.DownloadString(editionUrls[i]);
                    List<jsonObject> data2 = JsonConvert.DeserializeObject<List<jsonObject>>(json2);

                    foreach (var vers in data2)
                    {
                        verList.Add(vers.verName);
                        typeList.Add(vers.verType);
                        urlList.Add(vers.verLink);
                    }
                }


                string json = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\instance.cfg");
                List<instanceObjects> data = JsonConvert.DeserializeObject<List<instanceObjects>>(json);
                foreach (var vers in data)
                {
                    name = vers.name;
                    edition = vers.edition;
                    version = vers.version;
                    type = vers.type;
                    url = vers.url;
                    directory = vers.directory;
                    resolutionX = Int32.Parse(vers.resolutionX);
                    resolutionY = Int32.Parse(vers.resolutionY);
                    ramMin = Int32.Parse(vers.ramMin);
                    ramMax = Int32.Parse(vers.ramMax);
                    customJava = vers.customJava;
                    useCustomJava = bool.Parse(vers.useCustomJava);
                    jvmArgs = vers.jvmArgs;
                    useJvmArgs = bool.Parse(vers.useJvmArgs);
                    launchMethod = vers.launchMethod;
                    useLaunchMethod = bool.Parse(vers.useLaunchMethod);
                    offlineMode = bool.Parse(vers.offlineMode);
                }
                This.verBox.DataSource = verList;
                This.verBox.SelectedIndex = This.verBox.FindStringExact(version);
                This.nameBox.Text = name;
                This.dirBox.Text = directory;
                This.resBoxHeight.Text = resolutionX.ToString();
                This.resBoxWidth.Text = resolutionY.ToString();
                This.minRamBox.Value = ramMin;
                This.maxRamBox.Value = ramMax;
                This.javaCheck.Checked = useCustomJava;
                This.javaBox.Enabled = useCustomJava;
                This.javaBox.Text = customJava;
                This.jvmCheck.Checked = useJvmArgs;
                This.jvmBox.Enabled = useJvmArgs;
                This.jvmBox.Text = jvmArgs;
                This.methodCheck.Checked = useLaunchMethod;
                This.methodBox.Enabled = useLaunchMethod;
                This.methodBox.Text = launchMethod;
                This.offlineModeCheck.Checked = offlineMode;
            }
        }

        public static void setData()
        {
            varNames = new List<string>() { "name", "edition", "version", "type", "url", "directory", "resolutionX", "resolutionY", "ramMin", "ramMax", "customJava", "useCustomJava", "jvmArgs", "useJvmArgs", "launchMethod", "useLaunchMethod", "offlineMode" };
            varValues = new List<string>() { $"{name}", $"{edition}", $"{version}", $"{type}", $"{url}", $"{directory}", $"{resolutionX}", $"{resolutionY}", $"{ramMin}", $"{ramMax}", $"{customJava}", $"{useCustomJava}", $"{jvmArgs}", $"{useJvmArgs}", $"{launchMethod}", $"{useLaunchMethod}", $"{offlineMode}" };
        }

        public static void saveInstance(string instanceName, string mode)
        {
            if(mode != "initial")
            {
                name = instanceName;
                edition = This.editionBox.Text;
                version = This.verBox.Text;
                directory = This.dirBox.Text;
                resolutionX = Int32.Parse(This.resBoxWidth.Text);
                resolutionY = Int32.Parse(This.resBoxHeight.Text);
                ramMax = Int32.Parse(This.maxRamBox.Text);
                ramMin = Int32.Parse(This.minRamBox.Text);
                useCustomJava = This.javaCheck.Checked;
                customJava = This.javaBox.Text;
                useJvmArgs = This.jvmCheck.Checked;
                jvmArgs = This.jvmBox.Text;
                useLaunchMethod = This.methodCheck.Checked;
                launchMethod = This.methodBox.Text;
                offlineMode = This.offlineModeCheck.Checked;
            }



            setData();

            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instanceName}");
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods");
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instanceName}\\.minecraft");

            if (File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\instance.cfg"))
                File.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\instance.cfg");
            
            using (FileStream fs = File.Create($"{Globals.dataPath}\\instance\\{instanceName}\\instance.cfg"))
            {
                string final = $"[\n  {{\n";
                int i = 0;
                foreach(var varname in varNames)
                {
                    final += $"    \"{varname}\":\"{varValues[i]}\",\n";
                    i++;
                }
                i = 0;
                final += $"  }}\n]";
                byte[] config = new UTF8Encoding(true).GetBytes(final);
                fs.Write(config, 0, config.Length);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveInstance(nameBox.Text, "other");
            HomeScreen.reloadInstance(name);
            this.Close();
        }

        private void editionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            edition = editionBox.Text;
            int i = editionBox.SelectedIndex;
            Logger.logMessage("[InstanceManager]", i.ToString() + editionUrls[i]);

            verList = new List<string>();
            typeList = new List<string>();
            urlList = new List<string>();

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(editionUrls[i]);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    verList.Add(vers.verName);
                    typeList.Add(vers.verType);
                    urlList.Add(vers.verLink);
                }
            }
            verBox.DataSource = verList;
            /*verBox.SelectedIndex = verBox.FindStringExact(version);
            Logger.logMessage("[InstanceManager]", "Sample test " + verBox.FindStringExact(version));*/

            Logger.logError("[InstanceManager]", $"Index: {i} ({verList[i]}, {typeList[i]}, {urlList[i]})");
        }

        private void verBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = verBox.SelectedIndex;
                version = verList[i];
                url = urlList[i];
                type = typeList[i];
            }
            catch(ArgumentOutOfRangeException aore)
            {
                Logger.logError("[InstanceManager]", "Ignore this error");
            }
        }

        private void javaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(javaCheck.Checked)
            {
                javaBox.Enabled = true;
                javaBtn.Enabled = true;
            }
            else
            {
                javaBox.Enabled = false;
                javaBtn.Enabled = false;
            }
        }

        private void jvmCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (jvmCheck.Checked)
            {
                jvmBox.Enabled = true;
            }
            else
            {
                jvmBox.Enabled = false;
            }
        }

        private void methodCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (methodCheck.Checked)
            {
                methodBox.Enabled = true;
            }
            else
            {
                methodBox.Enabled = false;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void opendirBtn_Click(object sender, EventArgs e)
        {
            Process.Start($"{Globals.dataPath}\\instance\\{name}\\");
        }

        private void javaBox_TextChanged(object sender, EventArgs e)
        {
            javaBox.Text = javaBox.Text.Replace('\\', '/');
        }
    }

    public class instanceObjects
    {
        public string name { get; set; }
        public string edition { get; set; }
        public string version { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string directory { get; set; }
        public string resolutionX { get; set; }
        public string resolutionY { get; set; }
        public string ramMin { get; set; }
        public string ramMax { get; set; }
        public string customJava { get; set; }
        public string useCustomJava { get; set; }
        public string jvmArgs { get; set; }
        public string useJvmArgs { get; set; }
        public string launchMethod { get; set; }
        public string useLaunchMethod { get; set; }
        public string offlineMode { get; set; }
    }
}
