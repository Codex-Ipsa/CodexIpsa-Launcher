using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class Profile : Form
    {
        public static string profileName = "";
        public static string version = "b1.7.3";

        public List<VersionManifest> vj = new List<VersionManifest>();
        public string lastSelected;

        public Profile(string profile)
        {
            InitializeComponent();

            profileName = profile;

            listView1.Columns.Add("Name");
            listView1.Columns.Add("Type");
            listView1.Columns.Add("Released");

            string manifest = Globals.client.DownloadString(Globals.javaManifest);
            vj = JsonConvert.DeserializeObject<List<VersionManifest>>(manifest);

            reloadVerBox();
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
                btnSave.Enabled = true;
            }
            else if(listView1.Items.Count == 0)
                btnSave.Enabled = false;
            else
            {
                btnSave.Enabled = true;
                listView1.Items[0].Selected = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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

            string saveData = "";
            saveData += $"{{\n";
            saveData += $"  \"data\": 1,\n";
            saveData += $"  \"edition\": \"java\",\n";
            saveData += $"  \"version\": \"{version}\",\n";
            saveData += $"  \"directory\": \"\",\n";
            saveData += $"  \"resolution\": \"854 480\",\n";
            saveData += $"  \"memory\": \"512 512\",\n";
            saveData += $"  \"befCmd\": \"\",\n";
            saveData += $"  \"aftCmd\": \"\",\n";
            saveData += $"  \"javaPath\": \"\",\n";
            saveData += $"  \"demo\": false,\n";
            saveData += $"  \"offline\": false,\n";
            saveData += $"  \"proxy\": false,\n";
            saveData += $"  \"multiplayer\": false\n";
            saveData += $"}}";

            File.WriteAllText($"{Globals.dataPath}\\instance\\{profileName}\\instance.json", saveData);

            HomeScreen.reloadInstance(profileName);

            this.Close();
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
            if(listView1.SelectedItems.Count > 0)
            {
                lastSelected = listView1.SelectedItems[0].SubItems[0].Text;
                Console.WriteLine(lastSelected);
            }
        }
    }

    public class VersionManifest
    {
        public string id { get; set; }
        public string type { get; set; }
        public DateTime released { get; set; }
    }
}
