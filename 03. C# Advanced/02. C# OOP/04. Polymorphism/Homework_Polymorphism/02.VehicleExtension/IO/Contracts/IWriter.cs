namespace _02.VehicleExtension.Models.IO.Contracts
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
