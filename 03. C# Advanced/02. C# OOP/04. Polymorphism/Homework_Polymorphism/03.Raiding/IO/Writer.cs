using Raiding.IO.Interfaces;
using System;

namespace Raiding.IO
{
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
