using MCLauncher.classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MCLauncher.forms
{
    public partial class GameOutput : Form
    {
        public GameOutput(JavaLauncher launcher)
        {
            InitializeComponent();

            this.Text = $"Game output [{launcher.instanceName}]";
        }

        public void logMessage(string message)
        {
            if (message != null && message != string.Empty)
            {
                boxOutput.SelectionStart = boxOutput.TextLength;
                boxOutput.SelectionLength = 0;

                boxOutput.SelectionColor = ColorTranslator.FromHtml("#F9F1A5");

                if (MSAuth.msAccessToken != null && MSAuth.msUUID != null)
                    message = message.Replace(MSAuth.msAccessToken, "[ACCESS_TOKEN]").Replace(MSAuth.msUUID, "[UUID]");

                if (message.Contains("log4j:"))
                {
                    if (message.Contains("<log4j:Event"))
                    {
                        DateTime dt = Logger.UnixTimeStampToDateTime(Double.Parse(Logger.Splitter(message, "timestamp=\"", "\" level=")));
                        boxOutput.AppendText($"[{dt.ToString("HH:mm:ss")}] [{Logger.Splitter(message, "thread=\"", "\">")}/{Logger.Splitter(message, "level=\"", "\" thread=")}]: ");
                    }
                    else if (message.Contains("<log4j:Message"))
                    {
                        boxOutput.AppendText(Logger.Splitter(message, "<log4j:Message><![CDATA[", "]]></log4j:Message>"));
                    }
                    else if (message.Contains("</log4j:Event"))
                    {
                        boxOutput.SelectionColor = boxOutput.ForeColor;
                        boxOutput.AppendText("\n");
                    }
                }
                else
                {
                    boxOutput.AppendText($"[{DateTime.Now.ToString("HH:mm:ss")}] {message}\n");

                    boxOutput.SelectionColor = boxOutput.ForeColor;
                    boxOutput.ScrollToCaret();
                }
            }
        }

        public void logError(string message)
        {
            if (message != null && message != string.Empty)
            {
                boxOutput.SelectionStart = boxOutput.TextLength;
                boxOutput.SelectionLength = 0;

                if (MSAuth.msAccessToken != null && MSAuth.msUUID != null)
                    message = message.Replace(MSAuth.msAccessToken, "[ACCESS_TOKEN]").Replace(MSAuth.msUUID, "[UUID]");

                if (!message.StartsWith("\t"))
                    message = $"[{DateTime.Now.ToString("HH:mm:ss")}] " + message;
                else
                    message = "\t" + message;

                boxOutput.SelectionColor = ColorTranslator.FromHtml("#E74856");
                boxOutput.AppendText(message + "\n");

                boxOutput.SelectionColor = boxOutput.ForeColor;

                boxOutput.ScrollToCaret();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
