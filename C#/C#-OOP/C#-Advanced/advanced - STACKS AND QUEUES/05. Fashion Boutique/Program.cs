using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(numbers);

            int counter = 0;
            int sum = 0;

            while (stack.Count > 0)
            {
                var current = stack.Peek();

                if (sum + current > capacity)
                {
                    counter++;
                    sum = 0;
                }
                else if (sum + current == capacity)
                {
                    counter++;
                    sum = 0;
                    stack.Pop();
                }
                else
                {
                    sum += stack.Pop();
                }
            }

            if (sum > 0)
            {
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
