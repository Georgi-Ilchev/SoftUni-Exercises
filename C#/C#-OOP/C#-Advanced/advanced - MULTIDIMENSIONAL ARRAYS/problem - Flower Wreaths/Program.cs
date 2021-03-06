using System;
using System.Collections.Generic;
using System.Linq;

namespace problem1___Flower_Wreaths
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
            int leftWreaths = 0;
            int operation = Math.Min(queueRoses.Count(), stackLilies.Count());

            for (int i = 0; i < operation; i++)
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
                            leftWreaths += currentLilie + currentRose;
                            stackLilies.Pop();
                            queueRoses.Dequeue();
                            break;
                        }
                    }
                }
                else
                {
                    leftWreaths += currentLilie + currentRose;
                    stackLilies.Pop();
                    queueRoses.Dequeue();
                }
            }

            if (leftWreaths >= 15)
            {
                var left = leftWreaths / 15;
                wreaths += left;
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths } wreaths more!");
            }
        }
    }
}
