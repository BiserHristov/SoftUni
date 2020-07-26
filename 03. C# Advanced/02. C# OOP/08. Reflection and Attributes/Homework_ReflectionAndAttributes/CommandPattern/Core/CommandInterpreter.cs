using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string NAME_POSTFIX = "Command";
        public string Read(string args)
        {
            string[] input = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = input[0] + NAME_POSTFIX;
         
            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t=>t.GetInterfaces().Any(i=>i.Name==nameof(ICommand)))
                .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            ICommand instance = Activator.CreateInstance(commandType) as ICommand;
            input = input.Skip(1).ToArray();
            return instance.Execute(input);
        }
    }
}
