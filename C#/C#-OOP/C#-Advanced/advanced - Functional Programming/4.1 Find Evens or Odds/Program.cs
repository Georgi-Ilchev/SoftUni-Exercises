using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._1_Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = numbers[0];
            int end = numbers[1];

            string criteria = Console.ReadLine();

            Func<int, int, List<int>> generateList = (start, end) =>
              {
                  List<int> nums = new List<int>();

                  for (int i = start; i <= end; i++)
                  {
                      nums.Add(i);
                  }
                  return nums;
              };

            List<int> result = generateList(start, end);

            Func<int, bool> evenPredicate = n => n % 2 == 0;

            if (criteria == "odd")
            {
                evenPredicate = n => n % 2 != 0;
            }

            result = result.Where(evenPredicate).ToList();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
