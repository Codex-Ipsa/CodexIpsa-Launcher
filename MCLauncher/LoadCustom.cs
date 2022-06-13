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
        string verPath = string.Empty;
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
                verPath = ofd.FileName;
            }
            pathLabel.Text = verPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(verPath == string.Empty)
            {
                JavaCheck warn = new JavaCheck("Please choose a valid path.");
                warn.ShowDialog();
            }
            else
            {
                if (verType == "java-applet")
                {
                    LaunchJava.isCustom = true;
                    LaunchJava.selectedVer = "custom";
                    LaunchJava.typeVer = "applet";
                    LaunchJava.clientPath = verPath;
                    this.Close();
                }
                else if (verType == "java-a106")
                {
                    LaunchJava.isCustom = true;
                    LaunchJava.selectedVer = "custom";
                    LaunchJava.typeVer = "jar106";
                    LaunchJava.clientPath = verPath;
                    this.Close();
                }
                else if (verType == "rubydung")
                {
                    LaunchJava.isCustom = true;
                    LaunchJava.selectedVer = "custom";
                    LaunchJava.typeVer = "rubydung";
                    LaunchJava.clientPath = verPath;
                    this.Close();
                }
                else if (verType == "rubydung2")
                {
                    LaunchJava.isCustom = true;
                    LaunchJava.selectedVer = "custom";
                    LaunchJava.typeVer = "rubydung2";
                    LaunchJava.clientPath = verPath;
                    this.Close();
                }
                else
                {
                    JavaCheck warn = new JavaCheck("Please select a launch type.");
                    warn.ShowDialog();
                }
            }
        }

        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            verType = this.methodComboBox.GetItemText(this.methodComboBox.SelectedItem);
            Console.WriteLine(verType);
        }
    }
}
