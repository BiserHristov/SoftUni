using SOLID.Core.Interfaces;
using System;

namespace SOLID.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;
       
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
           
        }
        public void Run()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] appenderArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                this.commandInterpreter.AddAppender(appenderArgs);
            }
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] reportArgs = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                this.commandInterpreter.AddReport(reportArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
