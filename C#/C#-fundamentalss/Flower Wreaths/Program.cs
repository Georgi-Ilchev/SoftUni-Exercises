using System;
using System.Collections.Generic;
using System.Linq;

namespace Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] roses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Stack<int> stackLilies = new Stack<int>(lilies);
            Queue<int> queueRoses = new Queue<int>(roses);

            int wreaths = 0;
            int leftFlowers = 0;
            int opeartions = Math.Min(queueRoses.Count(), stackLilies.Count());
            for (int i = 0; i < opeartions; i++)
            {
                int currentLilie = stackLilies.Peek();
                int currentRose = queueRoses.Peek();

                if (currentLilie + currentRose == 15)
                {
                    wreaths++;
                    stackLilies.Pop();
                    queueRoses.Dequeue();
                }
                else if (currentLilie + currentRose > 15)
                {
                    while (true)
                    {
                        currentLilie -= 2;
                        if (currentLilie + currentRose == 15)
                        {
                            wreaths++;
                            stackLilies.Pop();
                            queueRoses.Dequeue();
                            break;
                        }
                        else if (currentLilie + currentRose < 15)
                        {
                            leftFlowers += currentLilie + currentRose;
                            stackLilies.Pop();
                            queueRoses.Dequeue();
                            break;
                        }
                    }
                }
                else
                {
                    leftFlowers += currentLilie + currentRose;
                    stackLilies.Pop();
                    queueRoses.Dequeue();
                }
            }

            if (leftFlowers >= 15)
            {
                var leftOver = leftFlowers / 15;
                wreaths += leftOver;
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
