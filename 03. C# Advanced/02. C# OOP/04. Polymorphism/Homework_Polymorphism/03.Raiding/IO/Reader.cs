using Raiding.IO.Interfaces;
using System;

namespace Raiding.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
