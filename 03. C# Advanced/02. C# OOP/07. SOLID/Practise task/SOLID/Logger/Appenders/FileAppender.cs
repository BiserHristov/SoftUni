using SOLID.Layouts.Interfaces;
using SOLID.Loggers;
using SOLID.Loggers.Enums;
using System;
using System.IO;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        private const string path = @"..\..\..\log.txt";
        private LogFile logFile;
        public FileAppender(ILayout layout, LogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }


        public override void Append(string dateTime, ReportLevel level, string inputMessage)
        {
            File.AppendAllText(path, string.Format(this.Layout.FormattedMessage() + Environment.NewLine, dateTime, level, inputMessage));
        }
    }
}
