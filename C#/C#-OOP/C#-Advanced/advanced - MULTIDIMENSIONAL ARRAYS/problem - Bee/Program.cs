using System;
using System.Security.Authentication.ExtendedProtection;

namespace problem2___Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] beeTeritory = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    beeTeritory[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int pollinatedFlowers = 0;

            string command = Console.ReadLine();
            while (command != "End")
            {
                beeTeritory[beeRow, beeCol] = '.';
                switch (command)
                {
                    case "up":
                        beeRow--;
                        break;
                    case "down":
                        beeRow++;
                        break;
                    case "left":
                        beeCol--;
                        break;
                    case "right":
                        beeCol++;
                        break;
                }

                if (beeCol > n - 1 || beeCol < 0 ||
                    beeRow > n - 1 || beeRow < 0)
                {
                    Console.WriteLine($"The bee got lost!");
                    break;
                }

                if (beeTeritory[beeRow, beeCol] == 'f')
                {
                    pollinatedFlowers++;
                }
                else if (beeTeritory[beeRow, beeCol] == 'O')
                {
                    continue;
                }
                command = Console.ReadLine();
            }

            if (command == "End")
            {
                beeTeritory[beeRow, beeCol] = 'B';
            }

            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate { pollinatedFlowers} flowers!");
            }

            PrintMatrix(beeTeritory);
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
