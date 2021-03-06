using System;
using System.Linq;
using System.Resources;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];
            FillingUpTheMatrix(matrix, rows);

            for (int i = 0; i < rows - 1; i++)
            {
                if (matrix[i].Count() == matrix[i + 1].Count())
                {
                    matrix[i] = matrix[i].Select(x => x * 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }

            while (true)
            {
                string[] splitted = Console.ReadLine().Split();
                string command = splitted[0];

                if (command == "End")
                {
                    break;
                }

                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                double value = double.Parse(splitted[3]);

                if (!IsCoordinatesValid(matrix,row,col))
                {
                    continue;
                }

                if (command == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    matrix[row][col] -= value;
                }
            }
            PrintMatrix(matrix, rows);
        }
        private static bool IsCoordinatesValid(double[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length)
            {
                if (col >= 0 && col < matrix[row].Length)
                {
                    return true;
                }
            }

            return false;
        }
        private static void FillingUpTheMatrix(double[][] matrix, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

                matrix[row] = input;
            }
        }
        static void PrintMatrix(double[][] matrix, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.Write(string.Join(" ",matrix[row]));
                Console.WriteLine();
            }
        }
    }
}
