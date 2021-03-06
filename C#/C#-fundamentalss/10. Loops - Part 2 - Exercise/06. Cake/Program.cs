using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int totalPieces = width * height;
            string input = Console.ReadLine();

            while (input != "STOP")
            {
                int pieces = int.Parse(input);
                totalPieces -= pieces;

                if (totalPieces < 0)
                {
                    break;
                }

                input = Console.ReadLine();
            }
            if (totalPieces < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs (totalPieces)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs (totalPieces)} pieces are left.");
            }
        }
    }
}
