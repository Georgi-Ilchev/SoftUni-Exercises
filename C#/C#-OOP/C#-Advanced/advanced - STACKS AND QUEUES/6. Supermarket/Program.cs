using System;
using System.Collections;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int count = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else if (input == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine,queue));
                    queue.Clear();
                    count = 0;
                }
                else
                {
                    queue.Enqueue(input);
                    count++;
                }
            }
            Console.WriteLine($"{count} people remaining.");
        }
    }
}
