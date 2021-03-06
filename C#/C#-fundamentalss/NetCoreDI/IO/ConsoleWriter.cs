using SillyGame.IO.Contracts;
using System;

namespace SillyGame.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string s)
        {
            Console.WriteLine(s);
        }
    }
}
