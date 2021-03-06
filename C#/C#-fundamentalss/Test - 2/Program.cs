using System;
using System.Collections.Generic;
using System.Linq;

namespace Test___2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                if (command[0] == "swap")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    if (index1 == index2)
                    {
                        return;
                    }
                    var temp = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = temp;

                }
                else if (command[0] == "multiply")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    numbers[index1] = numbers[index1] * numbers[index2];


                }
                else if (command[0] == "decrease")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] -= 1;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
