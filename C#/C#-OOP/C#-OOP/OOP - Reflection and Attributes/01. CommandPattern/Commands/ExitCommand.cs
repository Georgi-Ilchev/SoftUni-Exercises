using _01._CommandPattern.Core.Contracts;
using System;

namespace _01._CommandPattern.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);

            return null;
        }
    }
}
