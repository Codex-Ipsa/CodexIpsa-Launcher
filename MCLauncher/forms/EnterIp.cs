using MCLauncher.classes;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class EnterIp : Form
    {
        public static string inputText = null;

        public EnterIp()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //Lang
            this.Text = Strings.sj.joinServer;
            label1.Text = Strings.sj.lblServer1;
            label2.Text = Strings.sj.lblServer2;
            button1.Text = Strings.sj.btnStartGame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputText = comboBox1.Text;
            this.Close();
        }
    }
}
