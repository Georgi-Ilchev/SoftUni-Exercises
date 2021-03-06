using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isChanged = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        isChanged = true;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        numbers.RemoveAt(indexToRemove);
                        isChanged = true;
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        isChanged = true;
                        break;
                    case "Contains":
                        int containNumber = int.Parse(tokens[1]);
                        if (numbers.Contains(containNumber))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        List<int> printEven = numbers.Where(x => x % 2 == 0).ToList();
                        Console.WriteLine(string.Join(" ", printEven));
                        break;
                    case "PrintOdd":
                        List<int> printOdd = numbers.Where(x => x % 2 != 0).ToList();
                        Console.WriteLine(string.Join(" ", printOdd));
                        break;
                    case "GetSum":
                        string sum = tokens[0];
                        int totalSum = numbers.Sum();
                        Console.WriteLine(totalSum);
                        break;
                    case "Filter":
                        string symbol = tokens[1];
                        int filter = int.Parse(tokens[2]);

                        if (symbol == "<")
                        {
                            Console.WriteLine(string.Join(" ", numbers.FindAll(x => x < filter)));
                        }
                        else if (symbol ==">")
                        {
                            Console.WriteLine(string.Join(" ", numbers.FindAll(x => x > filter)));
                        }
                        else if (symbol == "<=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.FindAll(x => x <= filter)));
                        }
                        else if (symbol == ">=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.FindAll(x => x >= filter)));
                        }
                        break;
                }
            }
            if (isChanged == true)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            
        }
    }
}
