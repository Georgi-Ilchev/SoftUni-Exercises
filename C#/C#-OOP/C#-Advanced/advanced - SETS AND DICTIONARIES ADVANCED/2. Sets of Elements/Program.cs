using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int n = numbers[0];
            //int m = numbers[1];

            //HashSet<string> setOne = new HashSet<string>();
            //HashSet<string> setTwo = new HashSet<string>();
            //HashSet<string> identical = new HashSet<string>();

            //for (int i = 0; i < n + m; i++)
            //{
            //    string input = Console.ReadLine();

            //    if (i >= n)
            //    {
            //        setTwo.Add(input);
            //    }
            //    else
            //    {
            //        setOne.Add(input);
            //    }
            //}

            //foreach (var item in setOne)
            //{
            //    if (setTwo.Contains(item))
            //    {
            //        identical.Add(item);
            //    }
            //}

            //Console.WriteLine(string.Join(" ", identical));


            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = numbers[0];
            int m = numbers[1];

            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setOne.Add(num);
            }

            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setTwo.Add(num);
            }

            var intersection = setOne.Intersect(setTwo);

            Console.WriteLine(string.Join(" ", intersection));
        }
    }
}
