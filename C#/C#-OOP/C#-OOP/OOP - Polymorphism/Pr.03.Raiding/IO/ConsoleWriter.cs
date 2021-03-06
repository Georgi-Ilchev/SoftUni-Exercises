using Pr._03.Raiding.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._03.Raiding.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text) => Console.WriteLine(text);
    }
}
