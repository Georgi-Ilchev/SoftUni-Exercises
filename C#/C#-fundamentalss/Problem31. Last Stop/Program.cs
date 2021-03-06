using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem31._Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] currentCommand = command.Split().ToArray();
                string nameOfCommand = currentCommand[0];

                if (nameOfCommand == "Insert")
                {
                    if (int.Parse(currentCommand[1]) > -1 && int.Parse(currentCommand[1]) < numbers.Count)
                    {
                        numbers.Insert(int.Parse(currentCommand[1]) + 1, int.Parse(currentCommand[2]));
                    }
                }
                else if (nameOfCommand == "Hide")
                {
                    if (numbers.Contains(int.Parse(currentCommand[1])))
                    {
                        numbers.Remove(int.Parse(currentCommand[1]));
                    }
                }
                else if (nameOfCommand == "Switch")
                {
                    if (numbers.Contains(int.Parse(currentCommand[1])))
                    {
                        int switch1 = int.Parse(currentCommand[1]);
                        int switch2 = int.Parse(currentCommand[2]);

                        if (numbers.Contains(switch1) && numbers.Contains(switch2))
                        {
                            SwitchPaintings(numbers, switch1, switch2);
                        }
                    }
                }
                else if (nameOfCommand == "Change")
                {
                    int oldName = int.Parse(currentCommand[1]);
                    int newName = int.Parse(currentCommand[2]);
                    if (numbers.Contains(oldName))
                    {
                        Change(numbers, oldName, newName);
                    }
                }
                else if (nameOfCommand == "Reverse")
                {
                    numbers.Reverse();
                }
                //Console.WriteLine(string.Join(" ", numbers));
            }
            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }
        }

        private static void Change(List<int> numbers, int oldName, int newName)
        {
            int index = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == oldName)
                {
                    index = i;
                }
            }
            numbers.Insert(index, newName);
            numbers.Remove(oldName);

        }

        private static void SwitchPaintings(List<int> numbers, int switch1, int switch2)
        {
            int switch1Index = 0;
            int switch2Index = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == switch1)
                {
                    switch1Index = i;
                }
                if (numbers[i] == switch2)
                {
                    switch2Index = i;
                }

            }
            numbers.Insert(switch2Index + 1, switch1);
            numbers.RemoveAt(switch2Index);
            numbers.Insert(switch1Index + 1, switch2);
            numbers.RemoveAt(switch1Index);
        }
    }
}
