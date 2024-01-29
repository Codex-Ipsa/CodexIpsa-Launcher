using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MCLauncher.forms
{
    public partial class NewInstance : Form
    {
        public NewInstance()
        {
            InitializeComponent();

            //TODO load lang

            //fill in stuff
            populateLists();
        }

        private void populateLists()
        {
            if (tabControl1.SelectedTab.Text == "Vanilla")
            {
                vanillaList.Columns.Add(Strings.rowName);
                vanillaList.Columns.Add(Strings.rowType);
                vanillaList.Columns.Add(Strings.rowReleased);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO (hell)
            if(tabControl1.SelectedTab.Text == "Vanilla")
            {

            }
        }
    }
}
