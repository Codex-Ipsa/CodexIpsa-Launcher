using MCLauncher.forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MCLauncher
{
    public partial class ModsRepo : Form
    {
        List<string> modNames = new List<string>();
        List<string> modIds = new List<string>();
        List<string> baseJars = new List<string>();
        List<string> baseUrls = new List<string>();
        List<string> baseTypes = new List<string>();
        List<string> modVers = new List<string>();
        List<string> modTypes = new List<string>();
        List<string> modUrls = new List<string>();

        string json = "";

        public ModsRepo()
        {
            InitializeComponent();

            WebClient wc = new WebClient();
            json = wc.DownloadString(Globals.CIModsJson);
            var rj = JsonConvert.DeserializeObject<List<RepoJson>>(json);
            foreach (var r in rj)
            {
                modNames.Add(r.name);
                modIds.Add(r.id);
                baseJars.Add(r.baseJar);
                baseUrls.Add(r.baseUrl);
                baseTypes.Add(r.baseType);
            }
            listBox1.DataSource = modNames;
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            modVers.Clear();
            modUrls.Clear();
            modTypes.Clear();
            var rj = JsonConvert.DeserializeObject<List<RepoJson>>(json);
            foreach (var r in rj)
            {
                //Console.WriteLine(r.name);
                if (r.name == listBox1.GetItemText(listBox1.SelectedItem))
                {
                    foreach (var i in r.items)
                    {
                        modVers.Add(i.version);
                        modUrls.Add(i.url);
                        modTypes.Add(i.type);
                        //Console.WriteLine(i.version);
                    }
                }
            }

            foreach(string s in modVers)
            {
                //Console.WriteLine("--- "+s);
            }
            listBox2.DataSource = null;
            listBox2.DataSource = modVers;
            listBox2.Refresh();
            //Console.WriteLine("GOT CALLLED YAAAY");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedItems.Count > 0)
            {
                int index = listBox1.FindString(listBox1.GetItemText(listBox1.SelectedItem));
                DownloadProgress.url = modUrls[listBox2.SelectedIndex];
                DownloadProgress.savePath = $"{Globals.dataPath}\\instance\\{Profile.profileName}\\jarmods\\{modIds[index]}-{listBox2.GetItemText(listBox2.SelectedItem)}.jar";
                DownloadProgress dp = new DownloadProgress();
                dp.ShowDialog();
                Profile.addToModsList($"{modIds[index]}-{listBox2.GetItemText(listBox2.SelectedItem)}.jar", modTypes[listBox2.SelectedIndex], baseTypes[index]);
                Profile.reloadModsList();

                //Console.WriteLine(modUrls[listBox2.SelectedIndex]);

                /*if(baseTypes[index] != Profile.type)
                {
                    Logger.Info("[ModsRepo]", $"{baseTypes[index]} != {Profile.lastType}");
                    ModWarn mw = new ModWarn();
                    mw.ShowDialog();
                    if(mw.isYes)
                    {
                        InstanceManager.This.verBox.SelectedIndex = InstanceManager.This.verBox.FindString(baseJars[index]);
                        InstanceManager.url = baseUrls[index];
                        InstanceManager.type = baseTypes[index];
                    }

                    this.Close();
                }*/
            }
        }
    }

    class RepoJson
    {
        public string name { get; set; }
        public string id { get; set; }
        public string baseJar { get; set; }
        public string baseUrl { get; set; }
        public string baseType { get; set; }
        public string baseClass { get; set; }
        public RepoInfo[] items { get; set; }
    }

    class RepoInfo
    {
        public string version { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}

