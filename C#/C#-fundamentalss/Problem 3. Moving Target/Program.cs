using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isEnd = false;

            while (!isEnd)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    isEnd = true;
                    break;
                }
                List<string> command = input.Split().ToList();

                if (command[0] == "Shoot")
                {
                    int index = int.Parse(command[1]);
                    int power = int.Parse(command[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }

                }
                else if (command[0] == "Add")
                {
                    int index = int.Parse(command[1]);
                    int value = int.Parse(command[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }

                }
                else if (command[0] == "Strike")
                {
                    int index = int.Parse(command[1]);
                    int radius = int.Parse(command[2]);

                    int leftNumbers = index - radius;
                    int rightNumbers = index + radius;

                    if (leftNumbers < 0)
                    {
                        leftNumbers = 0;
                        Console.WriteLine($"Strike missed!");
                        continue;
                    }
                    if (rightNumbers > targets.Count - 1)
                    {
                        rightNumbers = targets.Count - 1;
                    }

                    targets.RemoveRange(leftNumbers, rightNumbers - leftNumbers + 1);
                    index = targets.IndexOf(index);

                }
            }
            Console.WriteLine(String.Join("|", targets));
        }
    }
}
