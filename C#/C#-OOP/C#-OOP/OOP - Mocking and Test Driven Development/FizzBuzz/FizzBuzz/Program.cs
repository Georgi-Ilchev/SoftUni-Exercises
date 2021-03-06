using FizzBuzz.Contracts;
using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 50;

            //Writer writer = new Writer();
            FizzBuzz fizzBuzz = new FizzBuzz();

            fizzBuzz.PrintNumbers(start, end);
            //Console.WriteLine(writer.Result);
        }
    }
}
