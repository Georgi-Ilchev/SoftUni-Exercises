using System;
using System.Linq;

namespace _8._1_Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(numbers, (x, y) =>
            {
                int sorter = 0;
                if (x % 2 == 0 && y % 2 != 0)
                {
                    sorter = -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    sorter = 1;
                }
                else
                {
                    //sorter = x - y;
                    sorter = x.CompareTo(y);
                }
                return sorter;
            });
            //Array.Sort(numbers, (x, y) =>
            //x % 2 == 0 && y % 2 != 0 ? -1 :
            //x % 2 != 0 && y % 2 == 0 ? 1 :
            //x.CompareTo(y));
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
