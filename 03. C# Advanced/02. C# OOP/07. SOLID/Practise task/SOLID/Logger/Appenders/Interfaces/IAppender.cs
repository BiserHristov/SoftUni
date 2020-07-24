using SOLID.Loggers.Enums;

namespace SOLID.Appenders.Interfaces
{
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel level, string inputMessage);
        ReportLevel ReportLevel { get; set; }
    }
}
