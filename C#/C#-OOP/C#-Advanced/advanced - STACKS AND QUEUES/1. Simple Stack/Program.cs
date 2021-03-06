using System;
using System.Collections;
using System.Collections.Generic;

namespace advanced___STACKS_AND_QUEUES
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
