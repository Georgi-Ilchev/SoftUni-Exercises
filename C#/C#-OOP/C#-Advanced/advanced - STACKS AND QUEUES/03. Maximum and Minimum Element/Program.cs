using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            string command = Console.ReadLine();

            for (int i = 1; i <= n; i++)
            {

                if (command.Contains("1"))
                {
                    string[] splitted = command.Split();
                    int number = int.Parse(splitted[1]);
                    stack.Push(number);
                }
                else if (command == "2")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (command == "3")
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    //else
                    //{
                    //    continue;
                    //}
                }
                else if (command == "4")
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                    //else
                    //{
                    //    continue;
                    //}
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
