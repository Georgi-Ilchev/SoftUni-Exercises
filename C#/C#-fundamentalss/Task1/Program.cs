using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int value = int.Parse(Console.ReadLine());

            bool isDead = false;
            while (!isDead)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentTask == value)
                {
                    isDead = true;
                    break;
                }

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (currentThread < currentTask)
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {value}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
