using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();
            bool isGoShhopping = false;

            while (!isGoShhopping)
            {
                string input = Console.ReadLine();
                if (input == "Go Shopping!")
                {
                    isGoShhopping = true;
                    break;
                }
                List<string> command = input.Split().ToList();

                if (command[0] == "Urgent")
                {
                    string item = command[1];
                    if (products.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        products.Insert(0, item);
                    }
                    

                }
                else if (command[0] == "Unnecessary")
                {
                    string item = command[1];
                    if (products.Contains(item))
                    {
                        products.Remove(item);
                    }
                    else
                    {
                        continue;
                    }
                    
                }
                else if (command[0] == "Correct")
                {
                    string oldItem = command[1];
                    string newItem = command[2];
                    if (products.Contains(oldItem))
                    {
                        products[products.FindIndex(x => x.Equals(command[1]))] = command[2];

                    }
                    else
                    {
                        continue;
                    }
                    
                }
                else if (command[0] == "Rearrange")
                {
                    string item = command[1];
                    if (products.Contains(item))
                    {
                        products.Remove(item);
                        products.Add(item);
                    }
                    
                }
            }
            Console.WriteLine(String.Join(", ", products));
        }
    }
}
