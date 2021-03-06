using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            int nameL = int.Parse(Console.ReadLine());

            Func<string, bool> filter = n => n.Length <= nameL;
            Console.ReadLine()
                .Split()
                .Where(filter)
                .ToList()
                .ForEach(Console.WriteLine);

            //2
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            names = names.Where(n => n.Length <= length).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
