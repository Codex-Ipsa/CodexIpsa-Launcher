using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class ImportProfile : Form
    {
        public string theZip = "";
        public ImportProfile(string zipPath)
        {
            InitializeComponent();
            textBox1.Text = " ";
            textBox1.Text = string.Empty; //so it forces TextChanged lmao

            theZip = zipPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.Info("[ImportProfile]", $"Importing {textBox1.Text}, this may take a while...");
            ZipFile.ExtractToDirectory(theZip, $"{Globals.dataPath}\\instance\\{textBox1.Text}");

            HomeScreen.loadInstanceList();
            HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(textBox1.Text);
            HomeScreen.reloadInstance(textBox1.Text);
            Logger.Info("[ImportProfile]", "Done!");
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace("\\", "")
                .Replace("/", "")
                .Replace(":", "")
                .Replace("*", "")
                .Replace("?", "")
                .Replace("\"", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label2.Visible = true;
                label2.Text = "Can't be empty.";
                button1.Enabled = false;
            }
            else if (Directory.Exists($"{Globals.dataPath}\\instance\\{textBox1.Text}"))
            {
                label2.Visible = true;
                label2.Text = "A profile with this name already exists.";
                button1.Enabled = false;
            }
            else
            {
                label2.Visible = false;
                button1.Enabled = true;
            }
        }
    }
}
