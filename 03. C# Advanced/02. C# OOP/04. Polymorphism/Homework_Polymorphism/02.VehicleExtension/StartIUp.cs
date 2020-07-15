using _02.VehicleExtension.Models;
using _02.VehicleExtension.Models.Core;
using _02.VehicleExtension.Models.Core.Contracts;
using _02.VehicleExtension.Models.IO;
using _02.VehicleExtension.Models.IO.Contracts;
using System;

namespace _02.VehicleExtension
{
    public class StartIUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IEngine engine = new Engine(reader,writer);
            engine.Run();
             
        }
    }
}
