﻿using System;

namespace _10._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int times = 1;

            while (times<=10)
            {
                Console.WriteLine($"{number} X {times} = {number*times}");
                times++;

            }
        }
    }
}
