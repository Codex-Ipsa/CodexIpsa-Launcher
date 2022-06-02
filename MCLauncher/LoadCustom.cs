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
    public partial class LoadCustom : Form
    {
        string result;
        string verType;

        public LoadCustom()
        {
            InitializeComponent();
            methodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open a game file";
            ofd.Filter = "JAR File (*.jar*) | *.jar*";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                result = ofd.FileName;
                StreamReader sr = new StreamReader(ofd.FileName);
                sr.Close();
            }
            pathLabel.Text = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(verType == "java-applet")
            {
                LaunchJava.isCustom = true;
                LaunchJava.selectedVer = "custom";
                LaunchJava.typeVer = "applet";
                LaunchJava.clientPath = result;
                this.Close();
            }
            else if (verType == "java-a106")
            {
                LaunchJava.isCustom = true;
                LaunchJava.selectedVer = "custom";
                LaunchJava.typeVer = "jar106";
                LaunchJava.clientPath = result;
                this.Close();
            }
            else
            {
                //do nothing
            }
        }

        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            verType = this.methodComboBox.GetItemText(this.methodComboBox.SelectedItem);
            Console.WriteLine(verType);
        }
    }
}
