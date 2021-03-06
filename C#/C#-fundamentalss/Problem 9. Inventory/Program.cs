using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Craft!")
                {
                    break;
                }

                string[] command = input.Split(" - ");

                if (command[0] == "Collect" && !journal.Contains(command[1]))
                {
                    journal.Add(command[1]);
                }

                else if (command[0] == "Drop")
                {
                    journal.Remove(command[1]);
                }
                else if (command[0] == "Combine Items")
                {
                    string[] bothItems = command[1].Split(":");

                    if (journal.Contains(bothItems[0]))
                    {
                        int indexToInsertAt = journal.IndexOf(bothItems[0]) + 1;
                        journal.Insert(indexToInsertAt, bothItems[1]);
                    }

                }
                else if (command[0] == "Renew" && journal.Contains(command[1]))
                {
                    journal.Remove(command[1]);
                    journal.Add(command[1]);
                }
            }
            Console.WriteLine(string.Join(", ", journal));


        }
    }
}
