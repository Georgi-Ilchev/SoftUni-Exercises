using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Swap_Method_String
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> values = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string currentValue = Console.ReadLine();
                values.Add(currentValue);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Box<string> box = new Box<string>(values);

            box.Swap(firstIndex, secondIndex);
            Console.WriteLine(box);
        }
    }
}
