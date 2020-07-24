using SOLID.Loggers.Interfaces;
using System.Linq;
using System.Text;

namespace SOLID.Loggers
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb;
        public int Size { get; private set; }
        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(x => x);

        }

     
    }
}
