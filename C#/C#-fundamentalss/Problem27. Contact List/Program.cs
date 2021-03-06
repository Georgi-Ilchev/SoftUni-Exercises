using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem27._Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = string.Empty;

            var print = new List<string>();

            while (!(input = Console.ReadLine()).Contains("Print"))
            {
                string[] command = input.Split();

                if (command[0] == "Add")
                {
                    string contact = command[1];
                    int index = int.Parse(command[2]);
                    if (!contacts.Contains(contact))
                    {
                        contacts.Add(contact);
                    }
                    else if(index >= 0 && index < contacts.Count)
                    {
                        contacts.Insert(index, contact);
                    }

                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < contacts.Count)
                    {
                        contacts.RemoveAt(index);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command[0] =="Export")
                {
                    int startIndex = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    if (startIndex >= 0 && startIndex < contacts.Count() && index > 0)
                    {
                        if (index >= contacts.Count || index <= 0)
                        {
                            index = contacts.Count;
                        }
                        print = contacts.Skip(startIndex).Take(index).Select(x => x).ToList();
                        
                        Console.WriteLine(string.Join(" ", print));
                        print.Clear();
                    }
                }
                
            }

            if (input.Split(" ")[1] == "Reversed")
            {
                contacts.Reverse();
            }
            Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
        }
    }
}
