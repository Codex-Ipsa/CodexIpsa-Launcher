using MCLauncher.classes;
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
    public partial class ProfileScreen : UserControl
    {
        public ProfileScreen()
        {
            InitializeComponent();

            reloadProfileList();
        }

        public void reloadProfileList()
        {
            ImageList iList = new ImageList();
            iList.ImageSize = new Size(32, 32);
            iList.ColorDepth = ColorDepth.Depth32Bit;
            listView1.LargeImageList = iList;

            iList.Images.Add(Image.FromFile("D:\\Source Code\\MineC-raft-Launcher\\MCLauncher\\image\\icon.png"));

            string[] dirs = Directory.GetDirectories($"{Globals.dataPath}\\instance\\", "*");

            int i = 0;
            int images = 1;
            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if (File.Exists($"{Globals.dataPath}\\instance\\{dirName}\\instance.json"))
                {
                    int img = 0;
                    if (File.Exists($"{Globals.dataPath}\\instance\\{dirName}\\icon.png"))
                    {
                        iList.Images.Add(Image.FromFile($"{Globals.dataPath}\\instance\\{dirName}\\icon.png"));
                        img = images;
                        images++;
                    }
                    listView1.Items.Add(new ListViewItem { ImageIndex = img, Text = dirName });
                }

                i++;

                if (i == 5)
                    i = 0;
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                JavaLauncher jl = new JavaLauncher();
                jl.Launch(listView1.SelectedItems[0].Text);

            }
        }
    }
}
