using _01.Vehicles.Models.IO.Contracts;
using System;

namespace  _01.Vehicles.Models.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
