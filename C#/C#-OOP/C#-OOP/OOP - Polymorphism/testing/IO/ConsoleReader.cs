using System;
using System.Collections.Generic;
using System.Text;
using testing.IO.Contracts;

namespace testing.IO
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
