using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int num = int.Parse(Console.ReadLine());

            Func<int, bool> predicate = n => n % num != 0;
            Action<List<int>> print = n => Console.WriteLine(String.Join(" ", n));

            numbers = numbers.Where(predicate).ToList();
            print(numbers);
        }
    }
}
