using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem23._Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> hours = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string input = string.Empty;
            List<int> incomplete = new List<int>();

            int countCompleted = 0;
            int countIncomplete = 0;
            int countDropped = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split();
                if (command[0] == "Complete")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < hours.Count)
                    {
                        hours[index] = 0;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    int time = int.Parse(command[2]);
                    if (index >= 0 && index < hours.Count)
                    {
                        hours[index] = time;
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (command[0] == "Drop")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < hours.Count)
                    {
                        hours[index] = -1;
                    }
                    else
                    {
                        continue;
                    }
                }

                else if (command[0] == "Count")
                {
                    foreach (var item in hours)
                    {
                        if (item < 0)
                        {
                            countDropped++;
                        }
                        else if (item == 0)
                        {
                            countCompleted++;
                        }
                        else if (item > 0)
                        {
                            countIncomplete++;
                        }
                    }

                    if (command[1] == "Completed")
                    {
                        Console.WriteLine(countCompleted);
                    }
                    else if (command[1] == "Incomplete")
                    {
                        Console.WriteLine(countIncomplete);
                    }
                    else if (command[1] == "Dropped")
                    {
                        Console.WriteLine(countDropped);
                    }
                }
            }
            PrintOutPut(hours);
        }
        private static void PrintOutPut(List<int> hoursByTask)
        {
            foreach (var item in hoursByTask)
            {
                if (item > 0)
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
    




}


