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
    public partial class ModWarn : Form
    {
        public bool isYes = false;
        public ModWarn()
        {
            InitializeComponent();
            button1.Text = Strings.btnNo;
            button2.Text = Strings.btnYes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isYes = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isYes = false;
            this.Close();
        }
    }
}
