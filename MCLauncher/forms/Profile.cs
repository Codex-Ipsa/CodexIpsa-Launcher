using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class Profile : Form
    {
        public static string version = "";

        public Profile(string mode)
        {
            InitializeComponent();

            listView1.Columns.Add("Name");
            listView1.Columns.Add("Type");
            listView1.Columns.Add("Released");

            string manifest = Globals.client.DownloadString(Globals.javaManifest);
            var vj = JsonConvert.DeserializeObject < List<VersionManifest>> (manifest);

            foreach(var ver in vj)
            {
                string[] row = { ver.type, ver.released.ToString() };
                listView1.Items.Add(ver.id).SubItems.AddRange(row);
            }
            listView1.Columns[0].Width = -1;
            listView1.Columns[1].Width = -1;
            listView1.Columns[2].Width = -2;

            listView1.Items[0].Selected = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 1)
            {
                version = listView1.SelectedItems[0].SubItems[0].Text;
                string type = listView1.SelectedItems[0].SubItems[1].Text;
                string date = listView1.SelectedItems[0].SubItems[2].Text;
                Logger.Info(this.GetType().Name, $"ver {version}, type {type}, date {date}");

                Globals.client.DownloadFile(Globals.javaInfo.Replace("{ver}", version), $"{Globals.dataPath}\\data\\json\\{version}.json");
            }

            this.Close();
        }
    }

    public class VersionManifest
    {
        public string id { get; set; }
        public string type { get; set; }
        public DateTime released { get; set; }
    }
}
