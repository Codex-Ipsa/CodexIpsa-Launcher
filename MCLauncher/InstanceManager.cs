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

namespace MCLauncher
{
    public partial class InstanceManager : Form
    {
        public static string selectedInstance;
        public static string createName;
        public static string tempName;
        public static int instanceInt = 1;
        public static int cfgVer = 1;

        public static string cfgGameVer = "a1.1.1";
        public static string cfgTypeVer = "java-applet";

        public InstanceManager()
        {
            InitializeComponent();
        }

        public static void createInstance()
        {
            Console.WriteLine("TEMPNAME " + tempName);

            Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance");
            if (!Directory.Exists($"{Globals.currentPath}\\bin\\instance\\{tempName}"))
            {
                Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance\\{tempName}");
                Directory.CreateDirectory($"{Globals.currentPath}\\bin\\instance\\{tempName}\\game");

                using (FileStream fs = File.Create($"{Globals.currentPath}\\bin\\instance\\{tempName}\\instance.cfg"))
                {
                    byte[] config = new UTF8Encoding(true).GetBytes($"[\n{{\n\"gameVer\":\"{cfgGameVer}\"\n}},\n{{\n\"typeVer\":\"{cfgTypeVer}\"\n}}\n]");
                    fs.Write(config, 0, config.Length);
                }

                instanceInt = 1;
            }
            else
            {
                tempName = createName + "_" + instanceInt.ToString();
                instanceInt++;
                createInstance();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if(nameBox.Text == string.Empty)
            {
                Warning warn = new Warning("Name can't be empty!");
                warn.ShowDialog();
            }
            else
            {
                createName = nameBox.Text;
                tempName = createName;
                createInstance();
            }
        }
    }
}
