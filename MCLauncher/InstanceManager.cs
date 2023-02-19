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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MCLauncher
{
    public partial class InstanceManager : Form
    {
        public static InstanceManager This;
        public static List<string> editionNames = new List<string>() { "Java Edition", "MinecraftEdu", "Xbox 360 Edition" }; //Xbox 360 Edition, Playstation 3 Edition, MinecraftEdu
        public static List<string> editionUrls = new List<string>() { Globals.javaJson, Globals.javaeduJson, Globals.x360Json };

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
        public static string customJar;
        public static bool useCustomJar = false;

        public static bool useProxy;
        public static bool offlineMode;

        public static string tempName;
        public static int tempInt = 0;

        public static bool didClickDelete = false;
        public static string mode2;

        public InstanceManager(string instanceName, string mode)
        {
            This = this;
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //Load lang
            this.Text = Strings.titleProfileMan;
            tabControl1.TabPages[0].Text = Strings.tabEditor;
            grbInfo.Text = Strings.grbInfo;
            lblName.Text = Strings.lblName;
            label9.Text = Strings.lblDir;
            label8.Text = Strings.lblRes;
            label3.Text = Strings.lblMin;
            label5.Text = Strings.lblMax;
            label7.Text = Strings.lblRam;
            proxyCheck.Text = Strings.lblUseProxy;

            grbVersion.Text = Strings.grbVersion;
            label6.Text = Strings.lblEdition;
            label2.Text = Strings.lblVersion;

            grbExperts.Text = Strings.grbExperts;
            javaCheck.Text = Strings.lblJavaInstall;
            jvmCheck.Text = Strings.lblJvmArgs;
            jarCheck.Text = Strings.lblCustJar;
            offlineModeCheck.Text = Strings.lblOfflineLaunch;

            closeBtn.Text = Strings.btnCancel;
            btnDelete.Text = Strings.btnDeleteInst;
            opendirBtn.Text = Strings.btnOpenDir;
            saveBtn.Text = Strings.btnSaveInst;


            tempName = instanceName;
            mode2 = mode;
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
                loadDefault(instanceName, "new");
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
                customJar = "";
                useCustomJar = false;
                offlineMode = false;
                useProxy = true;
            }
            else if (mode == "new")
            {
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
                        verList.Add(vers.verName + vers.verNote);
                        typeList.Add(vers.verType);
                        urlList.Add(vers.verLink);
                    }
                }
                This.verBox.DataSource = verList;

                version = verList[0];
                type = typeList[0];
                url = urlList[0];

                directory = $"";
                This.dirBox.Text = directory;
                resolutionX = 854;
                This.resBoxHeight.Text = resolutionY.ToString();
                resolutionY = 480;
                This.resBoxWidth.Text = resolutionX.ToString();
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
                customJar = "";
                useCustomJar = false;
                This.jarCheck.Checked = false;
                offlineMode = false;
                This.offlineModeCheck.Checked = false;
                useProxy = false;
                This.proxyCheck.Checked = false;

                This.opendirBtn.Visible = false;
                This.btnDelete.Visible = false;
            }
            else if (mode == "edit")
            {
                This.editionBox.DataSource = editionNames;

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
                    if (json.Contains("customJar"))
                    {
                        customJar = vers.customJar;
                        useCustomJar = bool.Parse(vers.useCustomJar);
                    }
                    offlineMode = bool.Parse(vers.offlineMode);
                    if (json.Contains("useProxy"))
                    {
                        useProxy = bool.Parse(vers.useProxy);
                    }
                }

                This.nameBox.Enabled = false;
                This.editionBox.SelectedIndex = This.editionBox.FindStringExact(edition);

                int i = This.editionBox.FindStringExact(edition);
                using (WebClient client = new WebClient())
                {
                    string json2 = client.DownloadString(editionUrls[i]);
                    List<jsonObject> data2 = JsonConvert.DeserializeObject<List<jsonObject>>(json2);

                    foreach (var vers in data2)
                    {
                        verList.Add(vers.verName + vers.verNote);
                        ListViewItem item = new ListViewItem(new[] { vers.verName + vers.verNote, "01-01-1970", vers.verCat });
                        This.listView2.Items.Add(item);
                        
                        typeList.Add(vers.verType);
                        urlList.Add(vers.verLink);
                    }
                }
                This.listView2.Columns[0].Width = -1;
                This.listView2.Columns[1].Width = -1;
                This.listView2.Columns[2].Width = -1;

                This.verBox.DataSource = verList;
                This.verBox.SelectedIndex = This.verBox.FindStringExact(version);
                if (This.verBox.SelectedIndex == -1)
                {
                    This.verBox.SelectedIndex = This.verBox.FindString(version + " (");
                }
                This.nameBox.Text = name;
                This.dirBox.Text = directory;
                This.resBoxHeight.Text = resolutionY.ToString();
                This.resBoxWidth.Text = resolutionX.ToString();
                This.minRamBox.Value = ramMin;
                This.maxRamBox.Value = ramMax;
                This.javaCheck.Checked = useCustomJava;
                This.javaBox.Enabled = useCustomJava;
                This.javaBox.Text = customJava;
                This.jvmCheck.Checked = useJvmArgs;
                This.jvmBox.Enabled = useJvmArgs;
                This.jvmBox.Text = jvmArgs;
                This.jarCheck.Checked = useCustomJar;
                This.jarBox.Enabled = useCustomJar;
                This.jarBox.Text = customJar;
                This.offlineModeCheck.Checked = offlineMode;
                This.proxyCheck.Checked = useProxy;

                if (name == "Default")
                {
                    This.btnDelete.Visible = false;
                }
                reloadModsList();
            }
        }

        public static void setData()
        {
            varNames = new List<string>() { "name", "edition", "version", "type", "url", "directory", "resolutionX", "resolutionY", "ramMin", "ramMax", "customJava", "useCustomJava", "jvmArgs", "useJvmArgs", "customJar", "useCustomJar", "offlineMode", "useProxy" };
            varValues = new List<string>() { $"{name}", $"{edition}", $"{version}", $"{type}", $"{url}", $"{directory}", $"{resolutionX}", $"{resolutionY}", $"{ramMin}", $"{ramMax}", $"{customJava}", $"{useCustomJava}", $"{jvmArgs}", $"{useJvmArgs}", $"{customJar}", $"{useCustomJar}", $"{offlineMode}", $"{useProxy}" };
        }

        public static void saveInstance(string instanceName, string mode)
        {
            if (mode != "initial")
            {
                instanceName = instanceName.Replace("?", "_");
                instanceName = instanceName.Replace("\\", "_");
                instanceName = instanceName.Replace("/", "_");
                instanceName = instanceName.Replace(":", "_");
                instanceName = instanceName.Replace("*", "_");
                instanceName = instanceName.Replace("\"", "_");
                instanceName = instanceName.Replace("<", "_");
                instanceName = instanceName.Replace(">", "_");
                instanceName = instanceName.Replace("|", "_");

                name = instanceName;
                edition = This.editionBox.Text;
                //version = This.verBox.Text;
                if (This.verBox.Text.Contains("("))
                {
                    int index = This.verBox.Text.IndexOf(" (");
                    if (index >= 0)
                        version = This.verBox.Text.Substring(0, index);
                }
                else
                {
                    version = This.verBox.Text;
                }
                directory = This.dirBox.Text;
                resolutionX = Int32.Parse(This.resBoxWidth.Text);
                resolutionY = Int32.Parse(This.resBoxHeight.Text);
                ramMax = Int32.Parse(This.maxRamBox.Text);
                ramMin = Int32.Parse(This.minRamBox.Text);
                useCustomJava = This.javaCheck.Checked;
                customJava = This.javaBox.Text;
                useJvmArgs = This.jvmCheck.Checked;
                jvmArgs = This.jvmBox.Text;
                useCustomJar = This.jarCheck.Checked;
                customJar = This.jarBox.Text;
                offlineMode = This.offlineModeCheck.Checked;
                useProxy = This.proxyCheck.Checked;
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
                foreach (var varname in varNames)
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
            string origName = nameBox.Text;
            if(mode2 == "new" || mode2 == "initial")
            {
                if (string.IsNullOrWhiteSpace(origName) || string.IsNullOrEmpty(origName))
                {
                    origName = "New profile";
                }
                string newName = origName;
                int num = 1;

                do
                {
                    if (Globals.isDebug) { Logger.Error("[InstanceManager]", $"o: {origName}, n: {newName}, i: {num}"); }
                    if (File.Exists($"{Globals.dataPath}\\instance\\{newName}\\instance.cfg") || newName.ToLower() == "con" || newName.ToLower() == "prn" || newName.ToLower() == "nul" || newName.ToLower() == "aux" || newName.ToLower().StartsWith("lpt") || newName.ToLower().StartsWith("com"))
                    {
                        newName = $"{origName}_{num}";
                        num++;
                    }
                }
                while (File.Exists($"{Globals.dataPath}\\instance\\{newName}\\instance.cfg"));


                saveInstance(newName, "other");
                HomeScreen.reloadInstance(newName);
                HomeScreen.loadInstanceList();
                HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(newName);
                this.Close();
            }
            else if(mode2 == "edit")
            {
                saveInstance(origName, "other");
                HomeScreen.reloadInstance(origName);
                this.Close();
            }

        }

        private void editionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            edition = editionBox.Text;
            int i = editionBox.SelectedIndex;
            Logger.Info("[InstanceManager]", i.ToString() + editionUrls[i]);

            verList = new List<string>();
            typeList = new List<string>();
            urlList = new List<string>();

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(editionUrls[i]);
                List<jsonObject> data = JsonConvert.DeserializeObject<List<jsonObject>>(json);

                foreach (var vers in data)
                {
                    verList.Add(vers.verName + vers.verNote);
                    typeList.Add(vers.verType);
                    urlList.Add(vers.verLink);
                }
            }
            verBox.DataSource = verList;
            verBox.SelectedIndex = 0;

            Logger.Info("[InstanceManager]", $"Index: {i} ({verList[i]}, {typeList[i]}, {urlList[i]})");
        }

        private void verBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = verBox.SelectedIndex;
                if (verList[i].Contains("("))
                {
                    int index = verList[i].IndexOf(" (");
                    if (index >= 0)
                        version = verList[i].Substring(0, index);
                }
                else
                {
                    version = verList[i];
                }

                url = urlList[i];
                type = typeList[i];
            }
            catch (ArgumentOutOfRangeException)
            {
                Logger.Error("[InstanceManager]", "Ignore this error (*ArgumentOutOfRangeException)");
            }
        }

        private void javaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (javaCheck.Checked)
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

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void opendirBtn_Click(object sender, EventArgs e)
        {
            if (directory != String.Empty || directory != "" || directory != null)
            {
                try
                {
                    Process.Start(directory);
                }
                catch (Exception)
                {
                    Process.Start($"{Globals.dataPath}\\instance\\{name}\\");
                }
            }
            else
            {
                Process.Start($"{Globals.dataPath}\\instance\\{name}\\");
            }
        }

        private void javaBox_TextChanged(object sender, EventArgs e)
        {
            javaBox.Text = javaBox.Text.Replace('\\', '/');
        }

        private void javaBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "exe files (*.exe)|*.exe";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    javaBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void jarCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (jarCheck.Checked)
            {
                jarBox.Enabled = true;
                jarBtn.Enabled = true;
            }
            else
            {
                jarBox.Enabled = false;
                jarBtn.Enabled = false;
            }
        }

        private void jarBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "jar files (*.jar)|*.jar";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    jarBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void jarBox_TextChanged(object sender, EventArgs e)
        {
            jarBox.Text = jarBox.Text.Replace('\\', '/');
        }

        private void dirBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog openFileDialog = new FolderBrowserDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dirBox.Text = openFileDialog.SelectedPath;
                }
            }
        }

        private void dirBox_TextChanged(object sender, EventArgs e)
        {
            dirBox.Text = dirBox.Text.Replace('\\', '/');
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteWarn dw = new DeleteWarn(name);
            dw.ShowDialog();

            if (didClickDelete == true)
            {
                HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(HomeScreen.selectedInstance);
                HomeScreen.loadInstanceList();
                didClickDelete = false;
                this.Close();
            }
        }

        private void releaseBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*try
            {
                int i = listView2.Items.IndexOf(listView2.SelectedItems[0]);
                if (verList[i].Contains("("))
                {
                    int index = verList[i].IndexOf(" (");
                    if (index >= 0)
                        version = verList[i].Substring(0, index);
                }
                else
                {
                    version = verList[i];
                }

                url = urlList[i];
                type = typeList[i];
            }
            catch (ArgumentOutOfRangeException)
            {
                Logger.Error("[InstanceManager]", "Ignore this error (*ArgumentOutOfRangeException)");
            }*/
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.zip, *.jar)|*.zip;*.jar";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(openFileDialog.FileName, $"{Globals.dataPath}\\instance\\{name}\\jarmods\\{openFileDialog.SafeFileName}");
                    //todo: save to json
                    reloadModsList();
                }
            }
        }

        static void reloadModsList()
        {
            This.modView.Items.Clear();
            //TODO: make a json for mod data

            if(!File.Exists($"{Globals.dataPath}\\instance\\{name}\\jarmods\\index.cfg"))
            {
                //File.CreateText($"{Globals.dataPath}\\instance\\{name}\\jarmods\\index.cfg");
                File.WriteAllText($"{Globals.dataPath}\\instance\\{name}\\jarmods\\index.cfg", "[{\"forge\":false}]");
            }

            string filepath = $"{Globals.dataPath}\\instance\\{name}\\jarmods\\";
            DirectoryInfo d = new DirectoryInfo(filepath);

            foreach (var file in d.GetFiles("*.jar"))
            {
                Console.WriteLine(file.Name);
                This.modView.Items.Add(file.Name);
            }

            foreach (var file in d.GetFiles("*.zip"))
            {
                Console.WriteLine(file.Name);
                This.modView.Items.Add(file.Name);
            }
            This.modView.Columns[0].Width = 522;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(This.modView.SelectedItems.Count > 0)
            {
                File.Delete($"{Globals.dataPath}\\instance\\{name}\\jarmods\\{This.modView.SelectedItems[0].Text}");
                reloadModsList();
                //Console.WriteLine(This.modView.SelectedItems[0].Text);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (directory != String.Empty || directory != "" || directory != null)
            {
                try
                {
                    Process.Start(directory);
                }
                catch (Exception)
                {
                    Process.Start($"{Globals.dataPath}\\instance\\{name}\\.minecraft\\");
                }
            }
            else
            {
                Process.Start($"{Globals.dataPath}\\instance\\{name}\\.minecraft\\");
            }
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
        public string customJar { get; set; }
        public string useCustomJar { get; set; }
        public string offlineMode { get; set; }
        public string useProxy { get; set; }
    }

    public class modsObjects
    {
        public bool forge { get; set; }
    }
}
