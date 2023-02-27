using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            listView1.Groups.Add(new ListViewGroup("ModName"));
        }
    }
}

