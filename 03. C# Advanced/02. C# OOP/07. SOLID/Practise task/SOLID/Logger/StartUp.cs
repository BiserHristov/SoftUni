using SOLID.Core;
using SOLID.Core.Interfaces;

namespace SOLID
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();


        }
    }
}
