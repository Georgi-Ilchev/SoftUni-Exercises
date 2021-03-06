using OOP___Workshop.Modules;
using SillyGame.IO;
using SillyGame.IO.Contracts;
using System;

namespace SillyGame.DI
{
    public class ConfigureDI : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
            CreateMapping<IWriter, WeirConsoleWriter>();
            //CreateMapping<IWriter, WeirConsoleWriter>();
            //CreateMapping<Int32, Int32>();
        }
    }
}
