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

namespace MCLauncher.controls
{
    public partial class InstanceScreen : UserControl
    {
        public InstanceScreen()
        {
            InitializeComponent();

            listView1.Columns[0].Width = 150;
            listView1.Columns[1].Width = -1;
            listView1.Columns[2].Width = -1;

            string[] dirs = Directory.GetDirectories($"{Globals.currentPath}\\.codexipsa\\instance\\", "*");

            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if (File.Exists($"{Globals.currentPath}\\.codexipsa\\instance\\{dirName}\\instance.cfg"))
                {
                    string json = File.ReadAllText($"{Globals.currentPath}\\.codexipsa\\instance\\{dirName}\\instance.cfg");
                    List<instanceObjects> data = JsonConvert.DeserializeObject<List<instanceObjects>>(json);
                    ListViewItem item = new ListViewItem(dirName);
                    foreach (var thing in data)
                    {
                        item.SubItems.Add(thing.version);
                        item.SubItems.Add(thing.edition);
                    }

                    listView1.Items.Add(item);
                }
            }


            //ListViewGroup group = new ListViewGroup("List item text", HorizontalAlignment.Left);
            //ListViewGroup group2 = new ListViewGroup("Group test", HorizontalAlignment.Left);

            /*for(int i = 0; i <= 10; i++)
            {
                var item = new ListViewItem { Text = "Test" + i, Group = myGroup };
            }*/

            /*for (int i = 1; i <= 15; i++)
            {
                listView1.Items.Add(new ListViewItem("Test", 0/*, group));
            }

            for (int i = 1; i <= 35; i++)
            {
                listView1.Items.Add(new ListViewItem("Test", 0/*, group2));
            }*/

            /*listView1.Groups.Add(group);
            listView1.Groups.Add(group2);*/

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string selectedName = "";
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                selectedName = listView1.Items[intselectedindex].Text;

            }

            InstanceManager man = new InstanceManager(selectedName, "edit");
            man.ShowDialog();
        }
    }
}
