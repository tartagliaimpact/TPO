using System;
using System.IO;
namespace lab1112
{
    public class Logger
    {
        private string filePath;

        public Logger(string path)
        {
            filePath = path;
        }

        public void Log(string message)
        {
            string logEntry = $"{DateTime.Now}: {message}";
            File.AppendAllText(filePath, logEntry + Environment.NewLine);
        }


    }
}
