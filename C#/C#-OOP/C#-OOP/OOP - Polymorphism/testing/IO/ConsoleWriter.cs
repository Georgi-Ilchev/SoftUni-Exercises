using System;
using System.Collections.Generic;
using System.Text;
using testing.IO.Contracts;

namespace testing.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
