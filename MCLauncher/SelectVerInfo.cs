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
    public partial class SelectVerInfo : Form
    {
        public static string displayType;
        public static string displayName;
        public static string displayDate;
        public static string displayAuthor;
        public static string displayDescription;


        public SelectVerInfo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //richTextBox1.Text = $"{displayType}\n{displayName}\n{displayDate}\nby {displayAuthor}\n\n{displayDescription}";
            richTextBox1.Text = $"To be added.";
            richTextBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
