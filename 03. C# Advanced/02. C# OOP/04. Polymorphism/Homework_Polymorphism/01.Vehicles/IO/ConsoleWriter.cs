using _01.Vehicles.Models.IO.Contracts;
using System;

namespace _01.Vehicles.Models
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
