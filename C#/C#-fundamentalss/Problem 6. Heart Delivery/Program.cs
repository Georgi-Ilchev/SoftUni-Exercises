using System;
using System.Linq;

namespace Problem_6._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split('@').Select(int.Parse).ToArray();

            int totalLength = 0;
            int counter = 0;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] command = input.Split();

                int length = int.Parse(command[1]);
                totalLength += length;

                if (totalLength > neighborhood.Length - 1)
                {
                    totalLength = 0;
                }
                if (neighborhood[totalLength] == 0)
                {
                    Console.WriteLine($"Place {totalLength} already had Valentine's day.");
                    continue;

                }
                neighborhood[totalLength] -= 2;
                if (neighborhood[totalLength] == 0)
                {
                    counter++;
                    Console.WriteLine($"Place {totalLength} has Valentine's day.");
                }
            }


            Console.WriteLine($"Cupid's last position was {totalLength}.");


            if (counter == neighborhood.Length)
            {
                Console.WriteLine($"Mission was successful.");
            }
            if (counter != neighborhood.Length)
            {
                Console.WriteLine($"Cupid has failed {neighborhood.Length - counter} places.");
            }

        }
    }
}
