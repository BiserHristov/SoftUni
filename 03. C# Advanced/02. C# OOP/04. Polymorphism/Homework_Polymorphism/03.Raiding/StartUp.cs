using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;
using System;

namespace Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IEngine engine = new Engine(reader, writer);

            engine.Run();

        }
    }
}
