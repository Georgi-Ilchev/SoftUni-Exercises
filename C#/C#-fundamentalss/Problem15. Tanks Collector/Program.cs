using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem15._Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tank = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                string input = Console.ReadLine();
                List<string> command = input.Split(", ").ToList();

                if (command[0] == "Add")
                {
                    string tankName = command[1];
                    if (tank.Contains(tankName))
                    {
                        Console.WriteLine($"Tank is already bought");
                    }
                    else
                    {
                        tank.Add(tankName);
                        Console.WriteLine($"Tank successfully bought");
                    }
                    
                }
                else if (command[0] == "Remove")
                {
                    string tankName = command[1];
                    if (tank.Contains(tankName))
                    {
                        tank.Remove(tankName);
                        Console.WriteLine($"Tank successfully sold");
                    }
                    else
                    {
                        Console.WriteLine($"Tank not found");
                    }
                }
                else if (command[0] == "Remove At")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < tank.Count)
                    {
                        tank.RemoveAt(index);
                        Console.WriteLine($"Tank successfully sold");
                    }
                    else
                    {
                        Console.WriteLine($"Index out of range");
                        continue;
                    }
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string tankName = command[2];

                    if (index >= 0 && index < tank.Count)
                    {
                        if (!tank.Contains(tankName))
                        {
                            tank.Insert(index, tankName);
                            Console.WriteLine($"Tank successfully bought");
                        }
                        else
                        {
                            Console.WriteLine($"Tank is already bought");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
            }
            Console.WriteLine(string.Join(", ", tank));
            
        }
    }
}
