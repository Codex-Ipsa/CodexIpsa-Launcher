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
            iList.Images.Add(Image.FromFile("D:\\Source Code\\MineC-raft-Launcher\\MCLauncher\\image\\icon.png"));
            iList.Images.Add(Image.FromFile("D:\\Source Code\\MineC-raft-Launcher\\MCLauncher\\image\\grass.png"));
            iList.Images.Add(Image.FromFile("D:\\Source Code\\MineC-raft-Launcher\\MCLauncher\\image\\552552.png"));
            iList.Images.Add(Image.FromFile("D:\\Source Code\\MineC-raft-Launcher\\MCLauncher\\image\\5525521.png"));
            iList.Images.Add(Image.FromFile("D:\\Source Code\\MineC-raft-Launcher\\MCLauncher\\image\\Omniarchive.png"));

            listView1.LargeImageList = iList;

            string[] dirs = Directory.GetDirectories($"{Globals.dataPath}\\instance\\", "*");

            int i = 0;
            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if (File.Exists($"{Globals.dataPath}\\instance\\{dirName}\\instance.json"))
                {
                    listView1.Items.Add(new ListViewItem { ImageIndex = i, Text = dirName });
                }

                i++;

                if (i == 5)
                    i = 0;
            }

        }
    }
}
