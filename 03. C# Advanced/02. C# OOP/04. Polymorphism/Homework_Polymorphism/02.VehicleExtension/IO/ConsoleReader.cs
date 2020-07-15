using _02.VehicleExtension.Models.IO.Contracts;
using System;

namespace  _02.VehicleExtension.Models.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
