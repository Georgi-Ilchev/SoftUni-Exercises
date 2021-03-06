using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace advanced___Algorithms_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = Sum(array, 0);
            Console.WriteLine(sum);
        }
        private static int Sum (int[] array, int n)
        {
            if (n == array.Length -1)
            {
                return array[n];
            }
            else
            {
                return array[n] + Sum(array, n + 1);
            }
        }
    }
}
