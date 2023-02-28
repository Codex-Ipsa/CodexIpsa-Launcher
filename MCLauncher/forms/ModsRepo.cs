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

namespace MCLauncher
{
    public partial class ModsRepo : Form
    {

        public ModsRepo()
        {
            InitializeComponent();
            listView1.Columns[0].Width = 150;

            WebClient wc = new WebClient();
            string json = wc.DownloadString(Globals.CIModsJson);
            var rj = JsonConvert.DeserializeObject<List<RepoJson>>(json);
            foreach (var r in rj)
            {
                ListViewGroup group = new ListViewGroup($"{r.name} (for {r.baseJar})", HorizontalAlignment.Left);
                Logger.Info("[ModsRepo]", $"{r.name}, {r.id}");

                foreach (var i in r.items)
                {
                    listView1.Items.Add(new ListViewItem(i.version, 0, group));
                    listView1.Groups.Add(group);
                    Logger.Info("[ModsRepo]", $"{i.version}, {i.url}");
                }
            }


            /*for (int i = 0; i <= 10; i++)
            {
                var item = new ListViewItem { Text = "Test" + i, Group = group };
            }*/

            /*for (int i = 1; i <= 15; i++)
            {
                listView1.Items.Add(new ListViewItem("Test", 0, group));
            }
            for (int i = 1; i <= 35; i++)
            {
                listView1.Items.Add(new ListViewItem("Test", 0, group2));
            }*/

            /*listView1.Groups.Add(group);
            listView1.Groups.Add(group2);*/
            listView1.Columns[0].Width = -1;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;

            string name = listView1.SelectedItems[0].Text.ToString();
            string group = listView1.SelectedItems[0].Group.ToString();
            Logger.Info("[ModsRepo]", $"aa: {name}, {group.Substring(0, group.IndexOf(" ("))}");
        }
    }

    class RepoJson
    {
        public string name { get; set; }
        public string id { get; set; }
        public string baseJar { get; set; }
        public string baseUrl { get; set; }
        public RepoInfo[] items { get; set; }
    }

    class RepoInfo
    {
        public string version { get; set; }
        public string url { get; set; }
    }
}

