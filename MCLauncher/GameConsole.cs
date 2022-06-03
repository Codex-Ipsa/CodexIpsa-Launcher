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
    public partial class GameConsole : Form
    {
        public static string textStr;

        public GameConsole()
        {
            InitializeComponent();
            richTextBox1.Text = textStr;
        }
    }
}
