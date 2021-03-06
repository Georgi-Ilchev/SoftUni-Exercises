using FizzBuzz.Contracts;
using System;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        //private IWriter writer;
        public FizzBuzz()//IWriter writer)
        {
            //this.writer = writer;
        }
        public void PrintNumbers(int start, int end)
        {
            if (start < 0)
            {
                start = 1;
            }
            for (int i = start; i <= end; i++)
            {
                if (i % 5 == 0 && i % 3 == 0)
                {
                    //writer.WirteLine("FizzBuzz");
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    //writer.WirteLine("Fizz");
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    //writer.WirteLine("Buzz");
                    Console.WriteLine("Buzz");
                }
                else
                {
                    //writer.WirteLine(i.ToString());
                    Console.WriteLine(i.ToString());
                }
            }
        }
    }
}
