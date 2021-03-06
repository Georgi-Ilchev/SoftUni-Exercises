using System;
using System.Collections.Generic;
using System.Linq;

namespace problem13___Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split().ToArray();

            Stack<string> inputArg = new Stack<string>(input);
            Queue<string> halls = new Queue<string>();
            List<int> guests = new List<int>();

            int currentCapacity = 0;

            //inputArg > 0
            while (inputArg.Any())
            {
                string currentElement = inputArg.Pop();
                bool isDigit = int.TryParse(currentElement, out int countOfGuests);

                if (!isDigit)
                {
                    halls.Enqueue(currentElement);
                }
                else
                {
                    if (currentCapacity + countOfGuests > capacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", guests)}");
                        currentCapacity = 0;
                        guests.Clear();
                    }

                    if (halls.Any())
                    {
                        guests.Add(countOfGuests);
                        currentCapacity += countOfGuests;
                    }
                }
            }
        }
    }
}
