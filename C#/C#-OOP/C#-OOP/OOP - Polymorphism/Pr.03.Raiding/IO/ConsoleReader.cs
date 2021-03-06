using Pr._03.Raiding.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._03.Raiding.IO
{
    public class ConsoleReader : IReader
    {
        public string Read() => Console.ReadLine();
    }
}
