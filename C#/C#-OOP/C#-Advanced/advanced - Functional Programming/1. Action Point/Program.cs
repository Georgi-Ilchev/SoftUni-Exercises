using System;
using System.Linq;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string[] names = Console.ReadLine().Split();
            Action<string> printNames = (x) => Console.WriteLine(x);
            names.ToList().ForEach(x => printNames(x));

            //2
            string[] namess = Console.ReadLine().Split();
            Action<string[]> printNamess = a => Console.WriteLine(string.Join(Environment.NewLine, a));
            printNamess(namess);
        }
    }
}
