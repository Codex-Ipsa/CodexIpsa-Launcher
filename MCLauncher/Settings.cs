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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            numericXMS.Value = Properties.Settings.Default.ramXMS;
            numericXMX.Value = Properties.Settings.Default.ramXMX;

            if (Properties.Settings.Default.isDemo == true)
            {
                demoCheckBox.Checked = true;
            }
            else
            {
                demoCheckBox.Checked = false;
            }
        }

        private void demoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isDemo = demoCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericXMX_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ramXMX = numericXMX.Value;
            Properties.Settings.Default.Save();
        }

        private void numericXMS_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ramXMS = numericXMS.Value;
            Properties.Settings.Default.Save();
        }

        private void creditsBtn_Click(object sender, EventArgs e)
        {
            About credits = new About();
            credits.ShowDialog();
        }
    }
}
