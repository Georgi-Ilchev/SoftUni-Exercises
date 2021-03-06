using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            for (int i = 0; i < arrays.Count; i++)
            {
                List<string> work = arrays[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int j = 0; j < work.Count; j++)
                {
                    Console.Write($"{work[j]} ");
                }
            }
            List<int> numbers = new List<int>();
           
        }

    }
}
