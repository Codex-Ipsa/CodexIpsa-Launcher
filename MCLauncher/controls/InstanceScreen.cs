using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            ImageList iconList = new ImageList();
            iconList.ImageSize = new Size(32, 32);

            //iconList.Images.Add(Image.FromFile(@"D:\Source Code\MineC-raft-Launcher\MCLauncher\image\icon64.png"));


            ListViewGroup group = new ListViewGroup("List item text", HorizontalAlignment.Left);
            ListViewGroup group2 = new ListViewGroup("Group test", HorizontalAlignment.Left);

            listView1.LargeImageList = iconList;
            listView1.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
            /*for(int i = 0; i <= 10; i++)
            {
                var item = new ListViewItem { Text = "Test" + i, Group = myGroup };
            }*/

            for (int i = 1; i <= 15; i++)
            {
                listView1.Items.Add(new ListViewItem("Test", 0, group));
            }

            for (int i = 1; i <= 35; i++)
            {
                listView1.Items.Add(new ListViewItem("Test", 0, group2));
            }

            listView1.Groups.Add(group);
            listView1.Groups.Add(group2);

        }
    }
}
