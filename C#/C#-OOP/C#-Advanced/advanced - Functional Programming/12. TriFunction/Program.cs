using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int, bool> checker = (name, value) => name.ToCharArray()
              .Select(ch => (int)ch).Sum() >= value;

            Func<List<string>, int, Func<string, int, bool>, string> nameChecker =
                (names, num, checker) =>
                names.FirstOrDefault(name => checker(name, num));

            Console.WriteLine(nameChecker(names,num, checker).ToString());
        }
    }
}
