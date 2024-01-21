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

            ImageList iList = new ImageList();
            iList.ImageSize = new Size(32, 32);
            iList.ColorDepth = ColorDepth.Depth32Bit;
            iList.Images.Add(Image.FromFile("D:\\Source Code\\MineC-raft-Launcher\\MCLauncher\\image\\icon.png"));

            listView1.LargeImageList = iList;

            string[] dirs = Directory.GetDirectories($"{Globals.dataPath}\\instance\\", "*");

            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if (File.Exists($"{Globals.dataPath}\\instance\\{dirName}\\instance.json"))
                {
                    listView1.Items.Add(new ListViewItem { ImageIndex = 0, Text = dirName });
                }
            }
        }
    }
}
