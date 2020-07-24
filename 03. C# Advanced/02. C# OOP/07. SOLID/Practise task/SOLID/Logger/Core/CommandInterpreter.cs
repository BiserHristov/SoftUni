using SOLID.Appenders;
using SOLID.Appenders.Interfaces;
using SOLID.Core.Interfaces;
using SOLID.Layouts;
using SOLID.Layouts.Interfaces;
using SOLID.Loggers.Enums;
using System;
using System.Collections.Generic;

namespace SOLID.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }
        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;

            appenders.Add(appender);
        }

        public void AddReport(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0]);
            string dateTime = args[1];
            string message = args[2];

            foreach (var appender in appenders)
            {
                if (reportLevel >= appender.ReportLevel)
                {
                    appender.Append(dateTime, reportLevel, message);

                }

            }
        }


        //ToDo: Implenet it!
        public void PrintInfo()
        {
            throw new NotImplementedException();
        }
    }
}
