using MCLauncher.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace MCLauncher.forms
{
    public partial class Profile : Form
    {
        public static string profileName = "";
        public static string version = "b1.7.3";
        public static string profMode = "";

        public List<VersionManifest> vj = new List<VersionManifest>();
        public static string lastSelected;
        public static string lastDate;
        public static string lastType;
        public static Profile Instance;

        public Profile(string profile, string mode)
        {
            InitializeComponent();

            Instance = this;

            profileName = profile;
            profMode = mode;

            if (profMode == "new")
            {
                nameBox.Text = profileName;
                dirBox.Text = $"{Globals.dataPath}\\instance\\{profileName}\\";
                resXBox.Text = "854";
                resYBox.Text = "480";
                ramMaxBox.Value = 512;
                ramMinBox.Value = 512;
                classBox.Enabled = false;
                jsonBox.Enabled = false;
                jsonBtn.Enabled = false;
                javaBox.Enabled = false;
                javaBtn.Enabled = false;
            }
            else if (profMode == "def")
            {
                nameBox.Text = profileName;
                resXBox.Text = "854";
                resYBox.Text = "480";
                ramMaxBox.Value = 512;
                ramMinBox.Value = 512;
            }
            else if (profMode == "edit")
            {
                string data = Globals.client.DownloadString($"{Globals.dataPath}\\instance\\{profileName}\\instance.json");
                var dj = JsonConvert.DeserializeObject<ProfileInfo>(data);

                version = dj.version;
                nameBox.Text = profileName;
                dirBox.Text = dj.directory;
                string[] res = dj.resolution.Split(' ');
                resXBox.Text = res[0];
                resYBox.Text = res[1];
                string[] mem = dj.memory.Split(' ');
                ramMaxBox.Value = int.Parse(mem[0]);
                ramMinBox.Value = int.Parse(mem[1]);
                befBox.Text = dj.befCmd;
                aftBox.Text = dj.aftCmd;
                javaCheck.Checked = dj.useJava;
                javaBox.Text = dj.javaPath;
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
                jsonCheck.Checked = dj.useJson;
                jsonBox.Text = dj.jsonPath;
                if (jsonCheck.Checked)
                {
                    jsonBox.Enabled = true;
                    jsonBtn.Enabled = true;
                }
                else
                {
                    jsonBox.Enabled = false;
                    jsonBtn.Enabled = false;
                }
                classCheck.Checked = dj.useClass;
                if (classCheck.Checked)
                    classBox.Enabled = true;
                else
                    classBox.Enabled = false;
                classBox.Text = dj.classpath;
                demoCheck.Checked = dj.demo;
                offlineCheck.Checked = dj.offline;
                proxyCheck.Checked = dj.proxy;
                mpCheck.Checked = dj.multiplayer;
            }

            listView1.Columns.Add("Name");
            listView1.Columns.Add("Type");
            listView1.Columns.Add("Released");

            string manifest = Globals.client.DownloadString(Globals.javaManifest);
            vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);

            reloadVerBox();

            if (profMode == "def")
            {
                listView1.SelectedItems.Clear();
                lastSelected = "b1.7.3";
                saveData();
            }
            else if (profMode == "new")
            {
                var item = listView1.FindItemWithText("b1.7.3");
                listView1.Items[listView1.Items.IndexOf(item)].Selected = true;
                listView1.EnsureVisible(listView1.Items.IndexOf(item));
            }
        }

        public void reloadVerBox()
        {
            listView1.Items.Clear();

            foreach (var ver in vj)
            {
                string[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy HH:mm:ss") };

                if (checkPreClassic.Checked && row[0] == "pre-classic")
                    listView1.Items.Add(ver.id).SubItems.AddRange(row);

                if (checkClassic.Checked && row[0] == "classic")
                    listView1.Items.Add(ver.id).SubItems.AddRange(row);

                if (checkIndev.Checked && row[0] == "indev")
                    listView1.Items.Add(ver.id).SubItems.AddRange(row);

                if (checkInfdev.Checked && row[0] == "infdev")
                    listView1.Items.Add(ver.id).SubItems.AddRange(row);

                if (checkAlpha.Checked && row[0] == "alpha")
                    listView1.Items.Add(ver.id).SubItems.AddRange(row);

                if (checkBeta.Checked && row[0] == "beta")
                    listView1.Items.Add(ver.id).SubItems.AddRange(row);

                if (checkRelease.Checked && row[0] == "release")
                    listView1.Items.Add(ver.id).SubItems.AddRange(row);

                if (checkSnapshot.Checked && row[0] == "snapshot")
                    listView1.Items.Add(ver.id).SubItems.AddRange(row);

                if (checkExperimental.Checked && row[0] == "experimental")
                    listView1.Items.Add(ver.id).SubItems.AddRange(row);
            }
            listView1.Columns[0].Width = -1;
            listView1.Columns[1].Width = -1;
            listView1.Columns[2].Width = -2;

            var item = listView1.FindItemWithText(version);

            if (item != null)
            {
                listView1.Items[listView1.Items.IndexOf(item)].Selected = true;
                listView1.EnsureVisible(listView1.Items.IndexOf(item));
                saveBtn.Enabled = true;
            }
            else if (listView1.Items.Count == 0)
                saveBtn.Enabled = false;
            else
            {
                saveBtn.Enabled = true;
                listView1.Items[0].Selected = true;
            }
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void checkPreClassic_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox();
        }

        private void checkClassic_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox();
        }

        private void checkIndev_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox();
        }

        private void checkInfdev_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox();
        }

        private void checkAlpha_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox();
        }

        private void checkBeta_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox();
        }

        private void checkRelease_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox();
        }

        private void checkSnapshot_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox();
        }

        private void checkExperimental_CheckedChanged(object sender, EventArgs e)
        {
            reloadVerBox();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                lastSelected = listView1.SelectedItems[0].SubItems[0].Text;
                lastType = listView1.SelectedItems[0].SubItems[1].Text;
                lastDate = listView1.SelectedItems[0].SubItems[2].Text;
                lastDate = DateTime.ParseExact(lastDate, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-ddTHH:mm:ss+00:00");
                Console.WriteLine($"{lastSelected};{lastType};{lastDate}");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveData();
        }

        public void saveData()
        {
            if (listView1.SelectedIndices.Count == 1)
            {
                version = listView1.SelectedItems[0].SubItems[0].Text;
                string type = listView1.SelectedItems[0].SubItems[1].Text;
                string date = listView1.SelectedItems[0].SubItems[2].Text;
                Logger.Info(this.GetType().Name, $"ver {version}, type {type}, date {date}");
            }
            else
            {
                version = lastSelected;
            }

            profileName = nameBox.Text;

            string saveData = "";
            saveData += $"{{\n";
            saveData += $"  \"data\": 1,\n";
            saveData += $"  \"edition\": \"java\",\n";
            saveData += $"  \"version\": \"{version}\",\n";
            saveData += $"  \"directory\": \"{dirBox.Text}\",\n";
            saveData += $"  \"resolution\": \"{resXBox.Text} {resYBox.Text}\",\n";
            saveData += $"  \"memory\": \"{ramMaxBox.Value} {ramMinBox.Value}\",\n";
            saveData += $"  \"befCmd\": \"{befBox.Text}\",\n";
            saveData += $"  \"aftCmd\": \"{aftBox.Text}\",\n";
            saveData += $"  \"useJava\": {javaCheck.Checked.ToString().ToLower()},\n";
            saveData += $"  \"javaPath\": \"{javaBox.Text}\",\n";
            saveData += $"  \"useJson\": {jsonCheck.Checked.ToString().ToLower()},\n";
            saveData += $"  \"jsonPath\": \"{jsonBox.Text}\",\n";
            saveData += $"  \"useClass\": {classCheck.Checked.ToString().ToLower()},\n";
            saveData += $"  \"classpath\": \"{classBox.Text}\",\n";
            saveData += $"  \"demo\": {demoCheck.Checked.ToString().ToLower()},\n";
            saveData += $"  \"modded\": false,\n";
            saveData += $"  \"offline\": {offlineCheck.Checked.ToString().ToLower()},\n";
            saveData += $"  \"proxy\": {proxyCheck.Checked.ToString().ToLower()},\n";
            saveData += $"  \"multiplayer\": {mpCheck.Checked.ToString().ToLower()}\n";
            saveData += $"}}";

            if (profMode == "new")
            {
                if (Directory.Exists($"{Globals.dataPath}\\instance\\{profileName}"))
                {
                    int iter = 1;
                    do
                    {
                        if (profileName.Contains("_"))
                            profileName = profileName.Substring(0, profileName.LastIndexOf("_")) + "_" + iter;
                        else
                            profileName = profileName + "_" + iter;
                        iter++;
                    }
                    while (Directory.Exists($"{Globals.dataPath}\\instance\\{profileName}"));
                }
            }

            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{profileName}");
            File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json", saveData);

            HomeScreen.reloadInstance(profileName);
            HomeScreen.loadInstanceList();
            HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(profileName);

            this.Close();
        }

        public bool nameCheck()
        {
            return false;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            Process.Start($"{Globals.dataPath}\\instance\\{profileName}\\");
        }

        private void DirBox_TextChanged(object sender, EventArgs e)
        {
            dirBox.Text = dirBox.Text.Replace("\\", "/");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = $"{Globals.dataPath}\\instance\\{profileName}\\";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    dirBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void ramMinBox_ValueChanged(object sender, EventArgs e)
        {
            if (ramMinBox.Value > ramMaxBox.Value)
            {
                ramMaxBox.Value = ramMinBox.Value;
            }
        }

        private void ramMaxBox_ValueChanged(object sender, EventArgs e)
        {
            if (ramMaxBox.Value < ramMinBox.Value)
            {
                ramMinBox.Value = ramMaxBox.Value;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnForge_Click(object sender, EventArgs e)
        {

        }

        private void btnReplace_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnRepo_Click(object sender, EventArgs e)
        {
            ModsRepo mr = new ModsRepo();
            mr.ShowDialog();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.zip, *.jar)|*.zip;*.jar";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(openFileDialog.FileName, $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{openFileDialog.SafeFileName}");
                    addToModsList(openFileDialog.SafeFileName, "jarmod", "");
                    reloadModsList();
                }
            }
        }

        private void btnReplace_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.jar)|*.jar";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(openFileDialog.FileName, $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{openFileDialog.SafeFileName}");
                    addToModsList(openFileDialog.SafeFileName, "cusjar", "");
                    reloadModsList();
                }
            }
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                File.Delete($"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\{modView.SelectedItems[0].Text}");
                removeFromModsList(modView.SelectedItems[0].Text);
                reloadModsList();
            }
        }

        private void btnDown_Click_1(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                moveDownInModsList(modView.SelectedItems[0].Text);
                reloadModsList();
            }
        }

        private void btnUp_Click_1(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                moveUpInModsList(modView.SelectedItems[0].Text);
                reloadModsList();
            }
        }

        public static void addToModsList(string modName, string modType, string launchType)
        {
            string indexPath = $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\index.cfg";
            string json = File.ReadAllText(indexPath);
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(json);
            bool useForge = mj.forge;
            List<string> itemsList = new List<string>();
            foreach (string str in mj.items)
            {
                itemsList.Add(str);
            }
            itemsList.Add($"{modName}?{modType}?{launchType}");

            string itemsStr = "";
            foreach (string str in itemsList)
                itemsStr += $"\"{str}\",";

            if (itemsStr.Contains(","))
            {
                itemsStr = itemsStr.Remove(itemsStr.LastIndexOf(','));
            }
            string newJson = $"{{\"forge\":{mj.forge.ToString().ToLower()},\"items\":[{itemsStr}]}}";
            File.WriteAllText(indexPath, newJson);
        }

        static void moveUpInModsList(string modName)
        {
            string indexPath = $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\index.cfg";
            string json = File.ReadAllText(indexPath);
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(json);
            bool useForge = mj.forge;
            List<string> itemsList = new List<string>();
            foreach (string str in mj.items)
            {
                itemsList.Add(str);
            }

            int i = 0;
            foreach (string str2 in itemsList.ToList()) //crashes if not .ToList()
            {
                if (str2.Contains(modName) && i != 0)
                {
                    Console.WriteLine("index " + i);
                    itemsList.RemoveAt(i);
                    int i2 = i - 1;
                    Console.WriteLine("change to " + i2);
                    itemsList.Insert(i2, str2);
                    //break;
                }
                i++;
            }

            string itemsStr = "";
            foreach (string str in itemsList)
                itemsStr += $"\"{str}\",";

            if (itemsStr.Contains(","))
            {
                itemsStr = itemsStr.Remove(itemsStr.LastIndexOf(','));
            }
            string newJson = $"{{\"forge\":{mj.forge.ToString().ToLower()},\"items\":[{itemsStr}]}}";
            File.WriteAllText(indexPath, newJson);
        }

        static void moveDownInModsList(string modName)
        {
            string indexPath = $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\index.cfg";
            string json = File.ReadAllText(indexPath);
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(json);
            bool useForge = mj.forge;
            List<string> itemsList = new List<string>();
            foreach (string str in mj.items)
            {
                itemsList.Add(str);
            }

            int i = 0;
            foreach (string str2 in itemsList.ToList()) //crashes if not .ToList()
            {
                if (str2.Contains(modName) && i != itemsList.Count)
                {
                    Console.WriteLine("index " + i);
                    itemsList.RemoveAt(i);
                    int i2 = i + 1;
                    Console.WriteLine("change to " + i2);
                    itemsList.Insert(i2, str2);
                    //break;
                }
                i++;
            }

            string itemsStr = "";
            foreach (string str in itemsList)
                itemsStr += $"\"{str}\",";

            if (itemsStr.Contains(","))
            {
                itemsStr = itemsStr.Remove(itemsStr.LastIndexOf(','));
            }
            string newJson = $"{{\"forge\":{mj.forge.ToString().ToLower()},\"items\":[{itemsStr}]}}";
            File.WriteAllText(indexPath, newJson);
        }


        static void removeFromModsList(string modName)
        {
            string indexPath = $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\index.cfg";
            string json = File.ReadAllText(indexPath);
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(json);
            bool useForge = mj.forge;
            List<string> itemsList = new List<string>();
            foreach (string str in mj.items)
            {
                itemsList.Add(str);
            }

            string itemsStr = "";
            foreach (string str in itemsList)
            {
                if (!str.Contains(modName))
                {
                    itemsStr += $"\"{str}\",";
                }
            }
            if (itemsStr.Contains(","))
            {
                itemsStr = itemsStr.Remove(itemsStr.LastIndexOf(','));
            }
            string newJson = $"{{\"forge\":{mj.forge.ToString().ToLower()},\"items\":[{itemsStr}]}}";
            File.WriteAllText(indexPath, newJson);
        }

        public static void reloadModsList()
        {
            Instance.modView.Items.Clear();

            string indexPath = $"{Globals.dataPath}\\instance\\{profileName}\\jarmods\\index.cfg";
            string json = "";
            if (!File.Exists(indexPath))
            {
                string n = JavaModHelper.LegacyUpdate(indexPath, json, profileName);
            }

            json = File.ReadAllText(indexPath);
            //legacy for old launcher versions
            if (!json.Contains("\"items\":[") || json.Contains("\"items\":[{\"name\": \"aa\"}]"))
            {
                json = JavaModHelper.LegacyUpdate(indexPath, json, profileName);
            }

            ModJson mj = JsonConvert.DeserializeObject<ModJson>(json);
            bool useForge = mj.forge;
            foreach (string str in mj.items)
            {
                ListViewItem item = new ListViewItem(new[] { str.Substring(0, str.IndexOf("?")), str.Substring(str.IndexOf("?") + 1) });
                Instance.modView.Items.Add(item);
            }
            Instance.modView.Columns[0].Width = 350;
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

        private void jsonCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (jsonCheck.Checked)
            {
                jsonBox.Enabled = true;
                jsonBtn.Enabled = true;
            }
            else
            {
                jsonBox.Enabled = false;
                jsonBtn.Enabled = false;
            }
        }

        private void classCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (classCheck.Checked)
            {
                classBox.Enabled = true;
            }
            else
            {
                classBox.Enabled = false;
            }
        }
    }

    public class VersionManifest
    {
        public string id { get; set; }
        public string type { get; set; }
        public DateTime released { get; set; }
    }

    public class ProfileInfo
    {
        public int data { get; set; }
        public string edition { get; set; }
        public string version { get; set; }
        public string directory { get; set; }
        public string resolution { get; set; }
        public string memory { get; set; }
        public string befCmd { get; set; }
        public string aftCmd { get; set; }
        public bool useJava { get; set; }
        public string javaPath { get; set; }
        public bool useJson { get; set; }
        public string jsonPath { get; set; }
        public bool useClass { get; set; }
        public string classpath { get; set; }
        public bool demo { get; set; }
        public bool offline { get; set; }
        public bool proxy { get; set; }
        public bool multiplayer { get; set; }
    }
}
