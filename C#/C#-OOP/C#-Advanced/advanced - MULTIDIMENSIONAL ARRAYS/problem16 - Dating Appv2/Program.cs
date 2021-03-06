using System;
using System.Collections.Generic;
using System.Linq;

namespace custom
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currMale = males.Peek();
                int currFemale = females.Peek();

                if (currMale <= 0)
                {
                    males.Pop();
                    continue;
                }
                else if (currMale % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }
                if (currFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                else if (currFemale % 25 == 0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    continue;
                }

                if (currMale == currFemale)
                {
                    matches++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    males.Push(males.Pop() - 2);
                    //currMale -= 2;
                    females.Dequeue();
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if (!males.Any())
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: " + string.Join(", ", males));
            }

            if (!females.Any())
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: " + string.Join(", ", females));
            }
        }
    }
}
