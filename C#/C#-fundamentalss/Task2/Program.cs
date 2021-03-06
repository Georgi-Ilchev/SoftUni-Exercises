using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];
            int[,] matrix = new int[n, m];
            FillTheMatrix(n, matrix);

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                var flowers = command.Split().Select(int.Parse).ToArray();
                int flowerRow = flowers[0];
                int flowerCol = flowers[1];

                if (flowerCol > n - 1 || flowerCol < 0 ||
                    flowerRow > n - 1 || flowerRow < 0)
                {
                    Console.WriteLine($"Invalid coordinates");
                    continue;
                }
                else
                {
                    PlaceFlowerPosition(m, n, matrix, flowerRow, flowerCol);
                }

                command = Console.ReadLine();
            }


            PrintMatrix(matrix);
        }

        private static void PlaceFlowerPosition(int m, int n, int[,] field, int flowerRow, int flowerCol)
        {
            var isFoundPos = false;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    field[flowerRow, flowerCol] = -1;
                    GetWholeRow(flowerCol, n, field);
                    GetWholeCol(m, n, field, flowerRow);
                    isFoundPos = true;

                    if (isFoundPos)
                    {
                        return;
                    }
                }
            }
        }

        private static void GetWholeCol(int m, int n, int[,] field, int flowerCol)
        {
            for (int i = 0; i < m; i++)
            {
                field[i, flowerCol]++;
            }
        }

        private static void GetWholeRow( int flowerRow, int n, int[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[flowerRow, i] += 1;
            }
        }

        private static void FillTheMatrix(int n, int[,] field)
        {
            for (int row = 0; row < n; row++)
            {
                string input = "0";
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = int.Parse(input);
                }
            }
        }
        static void PrintMatrix(int[,] field)
        {

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
