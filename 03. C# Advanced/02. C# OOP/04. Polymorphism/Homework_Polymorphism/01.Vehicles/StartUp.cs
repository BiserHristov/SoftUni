using _01.Vehicles.Models;
using _01.Vehicles.Models.Core;
using _01.Vehicles.Models.Core.Contracts;
using _01.Vehicles.Models.IO;
using _01.Vehicles.Models.IO.Contracts;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();

        }
    }
}
