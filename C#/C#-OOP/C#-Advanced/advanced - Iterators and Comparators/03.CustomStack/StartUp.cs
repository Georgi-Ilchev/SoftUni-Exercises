using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitted = input.Split(' ', 2);
                string command = splitted[0];
                if (command == "Push")
                {
                    var elements = splitted[1].Split(", ").Select(int.Parse).ToArray();
                    myStack.Push(elements);
                }
                else if (command == "Pop")
                {
                    myStack.Pop();
                }
            }

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(string.Join(Environment.NewLine, myStack));
            }
        }
    }
}
