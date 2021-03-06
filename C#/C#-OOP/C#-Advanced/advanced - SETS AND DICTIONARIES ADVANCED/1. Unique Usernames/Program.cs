using System;
using System.Collections.Generic;

namespace _1._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                names.Add(input);
            }

            foreach (var item in names)
            {
                Console.WriteLine(item) ;
            }

            //Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
