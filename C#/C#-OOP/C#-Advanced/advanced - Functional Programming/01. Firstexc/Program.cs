using System;
using System.Linq;

namespace advanced___Functional_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(n=> (int.Parse)(n))
                .Where(x => x % 2 == 0)
                .OrderBy(x=>x)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
