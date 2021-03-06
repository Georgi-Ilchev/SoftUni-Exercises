using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Func<int[], int> minFunc = x =>
            {
                int minValue = int.MaxValue;
                foreach (var item in x)
                {
                    if (item < minValue)
                    {
                        minValue = item;
                    }
                }
                return minValue;
            };

            int[] numbers = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();

            Console.WriteLine(minFunc(numbers));


            //2
            Func<string, int> myIntParse = s => int.Parse(s);

            int[] numberss = Console.ReadLine()
                .Split()
                .Select(myIntParse)
                .ToArray();

            Func<int[], int> minFuncs = nums =>
            {
                int minNum = int.MaxValue;

                foreach (var num in nums)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };
            Console.WriteLine(minFuncs(numberss));
        }
    }
}
