using _01._CommandPattern.Core;
using _01._CommandPattern.Core.Contracts;

namespace _01._CommandPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
