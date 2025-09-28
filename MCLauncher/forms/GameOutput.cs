using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MCLauncher.forms
{
    public partial class GameOutput : Form
    {
        public GameOutput()
        {
            InitializeComponent();
        }

        public void logMessage(string message)
        {
            if (message != null)
            {
                boxOutput.SelectionStart = boxOutput.TextLength;
                boxOutput.SelectionLength = 0;

                if (MSAuth.msAccessToken != null && MSAuth.msUUID != null)
                    message = message.Replace(MSAuth.msAccessToken, "[ACCESS_TOKEN]").Replace(MSAuth.msUUID, "[UUID]");

                if (!message.StartsWith("\t"))
                    message = $"[{DateTime.Now.ToString("HH:mm:ss")}] " + message;


                boxOutput.SelectionColor = ColorTranslator.FromHtml("#F9F1A5");
                boxOutput.AppendText(message + "\n");

                boxOutput.SelectionColor = boxOutput.ForeColor;

                boxOutput.ScrollToCaret();
            }
        }

        public void logError(string message)
        {
            if (message != null)
            {
                boxOutput.SelectionStart = boxOutput.TextLength;
                boxOutput.SelectionLength = 0;

                if (MSAuth.msAccessToken != null && MSAuth.msUUID != null)
                    message = message.Replace(MSAuth.msAccessToken, "[ACCESS_TOKEN]").Replace(MSAuth.msUUID, "[UUID]");

                if (!message.StartsWith("\t"))
                    message = $"[{DateTime.Now.ToString("HH:mm:ss")}] " + message;

                boxOutput.SelectionColor = ColorTranslator.FromHtml("#E74856");
                boxOutput.AppendText(message + "\n");

                boxOutput.SelectionColor = boxOutput.ForeColor;

                boxOutput.ScrollToCaret();
            }
        }
    }
}
