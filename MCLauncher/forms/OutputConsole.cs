using System;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class OutputConsole : Form
    {
        public OutputConsole()
        {
            InitializeComponent();
        }

        public void addText(String text)
        {
            richTextBox1.Text += text;
        }
    }
}
