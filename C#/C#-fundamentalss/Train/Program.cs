using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            bool isEnd = false;

            while (!isEnd)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    isEnd = true;
                    continue;
                }

                List<string> command = input.Split().ToList();

                if (command[0] == "Add")
                {
                    Add(wagons, command);
                }
                else
                {
                    Fit(wagons, command, maxCapacity);
                }
            }
            Console.WriteLine(string.Join(' ', wagons));
            
            

        }
        static void Add (List<int> wagons, List<string> command)
        {
            wagons.Add(int.Parse(command[1]));
        }
        static void Fit(List<int> wagons, List<string> command, int maxCapacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                if (maxCapacity - wagons[i] >= int.Parse(command[0]))
                {
                    wagons[i] += int.Parse(command[0]);
                    break;
                }
            }
        }
    }
}
