using P07.MilitaryElite.Core;
using P07.MilitaryElite.Core.Contracts;
using P07.MilitaryElite.IO;
using P07.MilitaryElite.IO.Contracts;
using System;

namespace P07.MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
