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
    public partial class NewInstance : Form
    {
        public NewInstance()
        {
            InitializeComponent();
            ImageList imglList = new ImageList();
            imglList.Images.Add("vanilla", Image.FromFile("C:\\Users\\David\\Downloads\\grass.png"));
            imglList.Images.Add("ipsa", Image.FromFile("C:\\Users\\David\\Downloads\\ipsa.png"));
            imglList.Images.Add("forge", Image.FromFile("C:\\Users\\David\\Downloads\\forge.png"));
            imglList.Images.Add("fabric", Image.FromFile("C:\\Users\\David\\Downloads\\fabric.png"));


            tabControl1.ImageList = imglList;

            tabControl1.TabPages[0].ImageKey = "vanilla";
            tabControl1.TabPages[1].ImageKey = "ipsa";
            tabControl1.TabPages[2].ImageKey = "forge";
            tabControl1.TabPages[3].ImageKey = "fabric";

            textBox1.Text = "New instance";
        }
    }
}
