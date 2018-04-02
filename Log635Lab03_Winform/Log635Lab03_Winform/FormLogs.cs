using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log635Lab03_Winform
{
    public partial class FormLogs : Form
    {
        private int _logIndex = 0;

        public FormLogs()
        {
            InitializeComponent();

            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
        }

        public void UpdateLogs()
        {
            for (; _logIndex < Logger.Logs.Count; _logIndex++)
            {
                Log log = Logger.Logs.ElementAt(_logIndex);
                richTextBox1.AppendText(log.Text + "\n");
                richTextBox1.SelectionStart = richTextBox1.TextLength - log.Text.Length - 1;
                richTextBox1.SelectionLength = log.Text.Length;

                switch (log.LogType)
                {
                    case LogType.Message:
                        richTextBox1.SelectionColor = Color.White;
                        break;
                    case LogType.Warning:
                        richTextBox1.SelectionColor = Color.Yellow;
                        break;
                    case LogType.Error:
                        richTextBox1.SelectionColor = Color.Red;
                        break;
                }
            }

            richTextBox1.ScrollToCaret();
        }
    }
}
