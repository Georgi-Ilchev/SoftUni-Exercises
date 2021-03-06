using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[] input = Console.ReadLine().ToCharArray();

            //Stack<char> stack = new Stack<char>();
            //Queue<char> queue = new Queue<char>();

            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (i < input.Length / 2)
            //    {
            //        stack.Push(input[i]);
            //    }
            //    else
            //    {
            //        queue.Enqueue(input[i]);
            //    }
            //}

            //bool isBalanced = true;

            //while (stack.Count > 0)
            //{
            //    char first = stack.Pop();
            //    char second = queue.Dequeue();

            //    if (!((first == '[' && second == ']')
            //        || (first == '(' && second == ')')
            //        || (first == '{' && second == '}')))
            //    {
            //        isBalanced = false;
            //        break;
            //    }
            //}

            //if (isBalanced && queue.Count == 0)
            //{
            //    Console.WriteLine("YES");
            //}
            //else
            //{
            //    Console.WriteLine("NO");
            //}



            var parantheses = Console.ReadLine();
            var stack = new Stack<char>();

            for (int i = 0; i < parantheses.Length; i++)
            {
                var expectedParantheses = '(';
                var isBalanced = false;

                if (parantheses[i] == ')')
                {
                    isBalanced = true;
                }
                else if (parantheses[i] == ']')
                {
                    expectedParantheses = '[';
                    isBalanced = true;
                }
                else if (parantheses[i] == '}')
                {
                    expectedParantheses = '{';
                    isBalanced = true;
                }
                else
                {
                    stack.Push(parantheses[i]);
                }

                if (isBalanced)
                {
                    if (stack.Count == 0 || stack.Pop() != expectedParantheses)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
