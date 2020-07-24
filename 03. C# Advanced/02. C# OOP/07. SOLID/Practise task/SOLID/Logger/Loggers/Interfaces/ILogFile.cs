namespace SOLID.Loggers.Interfaces
{
    public interface ILogFile
    {
        int Size { get; }
        void Write(string message);
    }
}
