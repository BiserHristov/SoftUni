using P07.MilitaryElite.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
