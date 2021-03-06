using _01._CommandPattern.Commands;
using _01._CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _01._CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND = "Command";
        public CommandInterpreter()
        {

        }
        public string Read(string args)
        {
            string[] splitted = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = splitted[0] + COMMAND;
            string[] commandArgs = splitted.Skip(1).ToArray();

            //Get assembly in order to get types
            Assembly assembly = Assembly.GetCallingAssembly();

            //Get concrete command type in order to produce instance of the concrete command
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());


            if (commandType == null)
            {
                throw new ArgumentException($"Invalid command type!");
            }

            // Without reflection
            //if (commandName == "HelloCommand")
            //{
            //    ICommand command = new HelloCommand();
            //    string result = command.Execute(commandArgs);
            //}

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);
            string result = commandInstance.Execute(commandArgs);
            //string result = commandInstance?.Execute(commandArgs);

            return result;
        }
    }
}
