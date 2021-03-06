using Microsoft.Extensions.DependencyInjection;
using SillyGame;
using SillyGame.IO;
using SillyGame.IO.Contracts;
using System;

namespace NetCoreDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IReader, ConsoleReader>()
                .AddSingleton<IWriter, WeirConsoleWriter>()
                .AddSingleton<Engine, Engine>()
                .AddSingleton<Snake, Snake>()
                .BuildServiceProvider();

            IWriter writer = serviceProvider.GetService<IWriter>();
            writer.Write("Hey");

            Engine engine = serviceProvider.GetService<Engine>();
            engine.Start();
        }
    }
}
