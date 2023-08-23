using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class Output : Form
    {
        public static RichTextBox rtb;
        public Output()
        {
            InitializeComponent();

            rtb = richTextBox1;

            //AddHeader("#16C60C", "Codex-Ipsa Launcher has started!");

            //demo
            /*rtb.Select(rtb.TextLength, 0);
            rtb.SelectionColor = System.Drawing.Color.Red;
            rtb.AppendText("[23.04.2023 14:08:02] [MainWindow] Codex-Ipsa Launcher has started!" + Environment.NewLine);
            rtb.Select(rtb.TextLength, 0);
            rtb.SelectionColor = System.Drawing.Color.Green;
            rtb.AppendText("sfa" + Environment.NewLine);
            rtb.Select(rtb.TextLength, 0);
            rtb.SelectionColor = System.Drawing.Color.Yellow;
            rtb.AppendText("hgfoikyuh" + Environment.NewLine);*/
        }

        public static void AddHeader(string colorHex, string header, string message)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(colorHex);

            rtb.Select(rtb.TextLength, 0);
            rtb.SelectionColor = color;
            rtb.AppendText($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] [{header}] ");

            rtb.Select(rtb.TextLength, 0);
            rtb.SelectionColor = Color.LightGray;
            rtb.AppendText(message + Environment.NewLine);
        }
    }
}
