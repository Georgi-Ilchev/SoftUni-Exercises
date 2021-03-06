﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));

            string act;
            while ((act = Console.ReadLine()) != "end")
            {
                if (act == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int, int> process = act switch
                    {
                        "add" => n => n + 1,
                        "multiply" => n => n * 2,
                        "subtract" => n => n - 1,
                        _ => n => n
                    };
                    numbers = numbers.Select(process).ToList();
                }
            }
        }
    }
}
