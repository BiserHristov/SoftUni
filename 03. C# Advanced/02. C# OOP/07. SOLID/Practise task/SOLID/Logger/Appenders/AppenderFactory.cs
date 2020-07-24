using SOLID.Appenders.Interfaces;
using SOLID.Layouts.Interfaces;
using SOLID.Loggers;
using System;

namespace SOLID.Appenders
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            type = type.ToLower();
            IAppender appender = null;

            if (type == "consoleappender")
            {
                appender = new ConsoleAppender(layout);
            }
            else if (type == "fileappender")
            {
                appender = new FileAppender(layout, new LogFile());
            }

            if (appender!=null)
            {
                return appender;
            }
            else
            {
                throw new InvalidOperationException("Invalid appender type!");
            }
        }

       

    }
}
