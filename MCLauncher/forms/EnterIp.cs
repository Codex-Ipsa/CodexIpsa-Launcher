using System;
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

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                inputText = comboBox1.Text;
                this.Close();
            }
        }
    }
}
