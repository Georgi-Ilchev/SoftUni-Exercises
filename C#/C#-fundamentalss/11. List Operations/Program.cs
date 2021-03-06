using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split();
                string operation = commands[0];

                switch (operation)
                {
                    case "Add":
                        int number = int.Parse(commands[1]);
                        list.Add(number);
                        break;
                    case "Insert":
                        int numToInsert = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);

                        if (index >=0 && index < list.Count)
                        {
                            list.Insert(index, numToInsert);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        
                        break;
                    case "Remove":
                        int indexToRemove = int.Parse(commands[1]);
                        if (indexToRemove >= 0 && indexToRemove < list.Count)
                        {
                            list.RemoveAt(indexToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        
                        break;
                    case "Shift":
                        int count = int.Parse(commands[2]);
                        if (commands[1] == "left")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int firstNum = list[0];
                                list.Add(firstNum);
                                list.RemoveAt(0);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int lastNum = list[list.Count - 1];
                                list.Insert(0, lastNum);
                                list.RemoveAt(list.Count - 1);
                            }
                        }
                        break;
                }
                                                                                                                              
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(' ', list));
        }
    }
}
