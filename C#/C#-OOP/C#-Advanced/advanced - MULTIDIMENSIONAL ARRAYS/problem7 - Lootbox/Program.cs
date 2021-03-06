using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace problem7___Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondBox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstBoxQueue = new Queue<int>(firstBox);
            Stack<int> secondBoxStack = new Stack<int>(secondBox);

            int operations = Math.Min(firstBoxQueue.Count(), secondBoxStack.Count());
            int sum = 0;

            for (int i = 0; i < operations; i++)
            {
                int currentFirst = firstBoxQueue.Peek();
                int currentSecond = secondBoxStack.Peek();

                int currentSum = currentFirst + currentSecond;
                if (currentSum % 2 == 0)
                {
                    sum += currentFirst + currentSecond;
                    firstBoxQueue.Dequeue();
                    secondBoxStack.Pop();
                }
                else
                {
                    firstBoxQueue.Enqueue(currentSecond);
                    secondBoxStack.Pop();
                }
            }

            if (firstBoxQueue.Count == 0)
            {
                Console.WriteLine($"First lootbox is empty");
            }
            else
            {
                Console.WriteLine($"Second lootbox is empty");
            }

            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
