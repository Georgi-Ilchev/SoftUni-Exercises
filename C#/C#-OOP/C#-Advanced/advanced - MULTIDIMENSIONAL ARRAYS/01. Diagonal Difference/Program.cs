using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int rows = matrixSize;
            int cols = matrixSize;

            var matrix = new int[rows, cols];

            FillingUpTheMatrix(rows, cols, matrix);
            //FindingFirstDiagonal(cols, matrix);
            //FindingSecondDiagonal(cols, matrix);


            // col = n - 1 - row
            int sumD1 = 0;
            int sumD2 = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    int number = matrix[row, col];

                    if (row == col)
                    {
                        sumD1 += number;
                    }
                    if (col == matrixSize - 1 - row)
                    {
                        sumD2 += number;
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumD1 - sumD2));
        }

        private static void FillingUpTheMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
