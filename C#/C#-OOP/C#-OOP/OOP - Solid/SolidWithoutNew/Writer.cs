using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Solid
{
    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
