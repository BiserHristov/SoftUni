using SOLID.Appenders.Interfaces;
using SOLID.Loggers.Enums;
using SOLID.Loggers.Interfaces;

namespace SOLID.Loggers
{
    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;
        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }


        public void Info(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.INFO, message);

        }

        public void Warning(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.WARNING, message);

        }
        public void Error(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.ERROR, message);

        }
        public void Critical(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.CRITICAL, message);

        }
        public void Fatal(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.FATAL, message);
        }



        private void Append(string date, ReportLevel level, string message)
        {
            if (level>=consoleAppender.ReportLevel)
            {
                consoleAppender.Append(date, level, message);
            }

            if (this.fileAppender != null &&
                level>=fileAppender.ReportLevel)
            {
                this.fileAppender.Append(date, level, message);
            }

        }
    }
}
