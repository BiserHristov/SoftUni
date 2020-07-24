using SOLID.Layouts.Interfaces;
using SOLID.Loggers.Enums;
using System;

namespace SOLID.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
                    : base(layout)
        {
        }


        public override void Append(string dateTime, ReportLevel level, string inputMessage)
        {
            Console.WriteLine(string.Format(this.Layout.FormattedMessage(), dateTime, level.ToString(), inputMessage));
        }


    }
}
