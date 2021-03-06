using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();

            //Func<string, int> parser = n => int.Parse(n);
            //int[] numbers = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(parser).ToArray();

            //Console.WriteLine(numbers.Length);
            //Console.WriteLine(numbers.Sum());

            int[] array = Console.ReadLine().Split(", ").Select(ParseNumber).ToArray();
            PrintResult(array, GetCount, Sum);
        }
        static void PrintResult(int[] array,
            Func<int[],int> count,
            Func<int[],int> sum)
        {
            Console.WriteLine(count(array));
            Console.WriteLine(sum(array));
        }
        static int Sum(int[] array)
        {
            return array.Sum();
        }
        static int GetCount(int[] array)
        {
            return array.Length;
        }

        static int ParseNumber(string number)
        {
            return int.Parse(number);
        }
    }
}
