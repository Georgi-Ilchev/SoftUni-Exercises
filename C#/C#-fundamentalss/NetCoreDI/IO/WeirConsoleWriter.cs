using SillyGame.IO.Contracts;
using System;

namespace SillyGame.IO
{
    public class WeirConsoleWriter : IWriter
    {
        public void Write(string s)
        {
            Console.WriteLine("Weird");
            Console.WriteLine(s);
        }
    }
}
