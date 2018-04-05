using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log635Lab03_Winform
{
    public enum LogType
    {
        Message,
        Warning,
        Error
    }

    public struct Log
    {
        public LogType LogType { get; set; }
        public string Text { get; set; }
    }

    public static class Logger
    {

        private static FormLogs _form;
        public static List<Log> Logs { get; } = new List<Log>();

        public static void Show()
        {
            _form = new FormLogs();
            _form.Show();
        }

        public static void LogMessage(string text)
        {
            Logs.Add(new Log {Text = text, LogType = LogType.Message});
            if (_form.IsDisposed)
            {
                _form = new FormLogs();
                _form.Show();
            }
            _form.UpdateLogs();
        }

        public static void LogWarning(string text)
        {
            Logs.Add(new Log {Text = text, LogType = LogType.Warning});
            if (_form.IsDisposed)
            {
                _form = new FormLogs();
                _form.Show();
            }
            _form.UpdateLogs();
        }

        public static void LogError(string text)
        {
            Logs.Add(new Log {Text = text, LogType = LogType.Error});
            if (_form.IsDisposed)
            {
                _form = new FormLogs();
                _form.Show();
            }
            _form.UpdateLogs();
        }

        public static void BringToFront()
        {
            _form.BringToFront();
        }
    }
}
