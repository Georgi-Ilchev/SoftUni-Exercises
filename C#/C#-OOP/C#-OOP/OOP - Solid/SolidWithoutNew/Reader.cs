using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Solid
{
    public class Reader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
