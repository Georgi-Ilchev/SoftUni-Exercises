using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem26._Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split();

                if (command[0] == "Switch")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < numbers.Length)
                    {
                        numbers[index] = numbers[index] * -1;
                    }
                }
                else if (command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    int value = int.Parse(command[2]);
                    if (index >= 0 && index < numbers.Length)
                    {
                        numbers[index] = value;
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (command[1] == "Negative")
                {
                    int sumNegative = 0;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] < 0)
                        {
                            sumNegative += numbers[i];
                        }

                    }
                    Console.WriteLine(sumNegative);

                }
                else if (command[1] == "Positive")
                {
                    int sumPositive = 0;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] > 0)
                        {
                            sumPositive += numbers[i];
                        }
                    }
                    Console.WriteLine(sumPositive);
                }
                else if (command[1] == "All")
                {
                    int sumAll = 0;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        sumAll += numbers[i];
                    }
                    Console.WriteLine(sumAll);
                }
            }

            foreach (var item in numbers)
            {
                if (item >= 0)
                {
                    Console.Write(string.Join(" ", item + " "));
                }
            }

            
        }
    }
}
