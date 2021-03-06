using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            FillingUpTheMatrix(size, matrix);

            char symbol = char.Parse(Console.ReadLine());
            bool flag = false;

            flag = CheckingDidCurrentSymbolIsExisting(size, matrix, symbol, flag);

            if (!flag)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
        private static void FillingUpTheMatrix(int size, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        private static bool CheckingDidCurrentSymbolIsExisting(int size, char[,] matrix, char symbol, bool flag)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            return flag;

        }
    }
}
