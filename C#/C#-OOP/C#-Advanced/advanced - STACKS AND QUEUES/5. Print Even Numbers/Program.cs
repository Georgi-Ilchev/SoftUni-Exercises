using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                var str = queue.Peek().ToString();
                if (int.Parse(str) % 2 == 0)
                {
                    if (i < numbers.Length - 2)
                    {
                        Console.Write(str + ", ");
                    }
                    else
                    {
                        Console.Write(str);
                    }
                }
                queue.Dequeue();
            }

            Console.WriteLine(string.Join(", ", queue));




            //int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //Queue<int> queue = new Queue<int>(numbers);
            //Queue<int> queue1 = new Queue<int>();

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (numbers[i] % 2 == 0)
            //    {

            //        queue1.Enqueue(numbers[i]);
            //    }
            //}

            //Console.WriteLine(string.Join(", ", queue1));
        }
    }
}
