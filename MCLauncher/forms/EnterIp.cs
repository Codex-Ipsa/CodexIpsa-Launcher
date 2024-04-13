using MCLauncher.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class EnterIp : Form
    {
        public static string inputedText;
        /*public static string serverIP;
        public static string serverPort;*/
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
            inputedText = comboBox1.Text;
            if(inputedText == String.Empty || inputedText == null)
            {
                this.Close();
            }
            else
            {
                bool b = inputedText.Contains(":");
                string ValidIpAddressRegex = "^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
                string ValidHostnameRegex = "^(([a-zA-Z]|[a-zA-Z][a-zA-Z0-9\\-]*[a-zA-Z0-9])\\.)*([A-Za-z]|[A-Za-z][A-Za-z0-9\\-]*[A-Za-z0-9])$";

                if (b == true)
                {
                    var split = inputedText.Split(':');

                    if (Regex.IsMatch(split[0], ValidIpAddressRegex))
                    {
                        JavaLauncher.srvIP = split[0];
                    }
                    else if (Regex.IsMatch(split[0], ValidHostnameRegex))
                    {
                        IPAddress[] arr = Dns.GetHostAddresses(split[0]);
                        foreach(IPAddress ip in arr)
                            JavaLauncher.srvIP = ip.ToString();
                    }
                    JavaLauncher.srvPort = split[1];
                    this.Close();
                }
                else
                {
                    if (Regex.IsMatch(inputedText, ValidIpAddressRegex))
                    {
                        JavaLauncher.srvIP = inputedText;
                    }
                    else if (Regex.IsMatch(inputedText, ValidHostnameRegex))
                    {
                        IPAddress[] arr = Dns.GetHostAddresses(inputedText);
                        foreach (IPAddress ip in arr)
                            JavaLauncher.srvIP = ip.ToString();
                    }
                    JavaLauncher.srvPort = "25565";
                    this.Close();
                }
            }
        }
    }
}
