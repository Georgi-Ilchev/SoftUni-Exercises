using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _15._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            if (number <= 0)
            {
                Console.WriteLine(0);
            }
            else if (number == 1)
            {
                Console.WriteLine(1);
            }
            else if (number == 2)
            {
                Console.WriteLine("1 1");
            }
            else if (number == 3)
            {
                Console.WriteLine("1 1 2");
            }
            else if (true)
            {
                Console.Write("1 1 2 ");
                
                GetTribonacci(number);
            }
        }
        private static void GetTribonacci(BigInteger number)
        {
            BigInteger minus3 = 1;
            BigInteger minus2 = 1;
            BigInteger minus1 = 2;
            BigInteger max = number;
            for (int i = 0; i < max - 3; i++)
            {
                number = minus3 + minus2 + minus1;
                minus3 = minus2;
                minus2 = minus1;
                minus1 = number;
                Console.Write($"{number} ");
            }
        }
    }
}
