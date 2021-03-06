using System;
using System.Collections;
using System.Collections.Generic;

namespace _7._Hot_potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string[] children = Console.ReadLine().Split();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < children.Length; i++)
            {
                queue.Enqueue(children[i]);
            }

            while (queue.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}"); 
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
