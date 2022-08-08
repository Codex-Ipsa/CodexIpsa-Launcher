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
    public partial class EnterIp : Form
    {
        public static string inputedText;
        public static string serverIP;
        public static string serverPort;
        public EnterIp()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputedText = comboBox1.Text;
            if(inputedText == String.Empty || inputedText == null)
            {
                this.Close();
            }
            else
            {
                bool b = inputedText.Contains(":");

                if(b == true)
                {
                    var splitted = inputedText.Split(':');
                    serverIP = splitted[0];
                    serverPort = splitted[1];
                    this.Close();
                }
                else
                {
                    serverIP = inputedText;
                    serverPort = "25565";
                    this.Close();
                }
            }
        }
    }
}
