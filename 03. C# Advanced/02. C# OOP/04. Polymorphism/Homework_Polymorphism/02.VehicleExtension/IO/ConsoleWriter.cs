using _02.VehicleExtension.Models.IO.Contracts;
using System;

namespace _02.VehicleExtension.Models
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
             Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
