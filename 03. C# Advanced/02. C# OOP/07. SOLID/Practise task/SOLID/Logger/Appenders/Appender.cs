using SOLID.Appenders.Interfaces;
using SOLID.Layouts.Interfaces;
using SOLID.Loggers.Enums;

namespace SOLID.Appenders
{
    public abstract class Appender : IAppender
    {

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        protected ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel level, string inputMessage);


    }
}
