using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string[] names = Console.ReadLine().Split();
            Action<string> printNames = (x) => Console.WriteLine(x);
            names.ToList();

            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }


            //2
            List<string> namess = Console.ReadLine().Split().ToList();
            //namess = namess.Select(n => $"Sir {n}").ToList();
            namess = MySelect(namess, n => $"Sir {n}");

            Action<string[]> printNamess = a => Console.WriteLine(string.Join(Environment.NewLine, a));


            printNamess(namess.ToArray());
        }

        static List<string> MySelect(List<string>items, Func<string,string>func)
        {
            List<string> newList = new List<string>();

            foreach (var item in items)
            {
                string newItem = func(item);
                newList.Add(newItem);
            }
            return newList;
        }
    }
}
