using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.controls
{
    public partial class ConsoleScreen : UserControl
    {
        public static ConsoleScreen Instance;

        public ConsoleScreen()
        {
            Instance = this;
            InitializeComponent();
        }

        public static void writeMessage(string message)
        {
            if(message != null)
            {
                Instance.richTextBox2.Invoke((Action)delegate
                {
                    Instance.richTextBox2.AppendText(message + "\n");
                    Instance.richTextBox2.Find(message);
                    Instance.richTextBox2.SelectionColor = Color.Yellow;
                    Instance.richTextBox2.ScrollToCaret();
                });
            }
        }
        public static void writeError(string message)
        {
            if(message != null)
            {
                Instance.richTextBox2.Invoke((Action)delegate
                {
                    Instance.richTextBox2.AppendText(message + "\n");
                    Instance.richTextBox2.Find(message);
                    Instance.richTextBox2.SelectionColor = Color.Red;
                    Instance.richTextBox2.ScrollToCaret();
                });
            }
        }
    }
}
