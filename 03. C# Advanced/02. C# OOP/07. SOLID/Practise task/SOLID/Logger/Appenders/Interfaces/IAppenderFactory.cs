using SOLID.Layouts.Interfaces;

namespace SOLID.Appenders.Interfaces
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
