using SillyGame.IO.Contracts;
using System;

namespace SillyGame.IO
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
