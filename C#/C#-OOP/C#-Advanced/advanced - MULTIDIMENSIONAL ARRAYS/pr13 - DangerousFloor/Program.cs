using System;
using System.Linq;

namespace pr13___DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 8;
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                //K33 - 44
                //K11 - 02
                //P44 - 34
                //P65 - 55
                //P55 - 65

                char pieceType = input[0];
                int currentRow = input[1] - '0';
                int currentCol = input[2] - '0';
                int nextRow = input[4] - '0';
                int nextCol = input[5] - '0';

                if (matrix[currentRow, currentCol] != pieceType)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (CheckIsMoveValid(matrix, new int[] { currentRow, currentCol }, new int[] { nextRow, nextCol }) == false)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (nextRow >= matrix.GetLength(0) || nextRow < 0 ||
                    nextCol >= matrix.GetLength(1) || nextCol < 0)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                MovePiece(matrix, new int[] { currentRow, currentCol }, new int[] { nextRow, nextCol });
            }
        }
        static void MovePiece(char[,] matrix, int[] currentPosition, int[] nextPosition)
        {
            char piece = matrix[currentPosition[0], currentPosition[1]];
            matrix[currentPosition[0], currentPosition[1]] = 'x';
            matrix[nextPosition[0], nextPosition[1]] = piece;
        }
        static bool CheckIsMoveValid(char[,] matrix, int[] currentPosition, int[] nextPosition)
        {
            bool isValid = false;
            char piece = matrix[currentPosition[0], currentPosition[1]];

            if (piece == 'K')
            {
                if (new int[] { currentPosition[0], currentPosition[1] + 1 }.SequenceEqual(nextPosition) ||
                    new int[] { currentPosition[0] + 1, currentPosition[1] + 1 }.SequenceEqual(nextPosition) ||
                    new int[] { currentPosition[0] + 1, currentPosition[1] }.SequenceEqual(nextPosition) ||
                    new int[] { currentPosition[0], currentPosition[1] - 1 }.SequenceEqual(nextPosition) ||
                    new int[] { currentPosition[0] - 1, currentPosition[1] - 1 }.SequenceEqual(nextPosition) ||
                    new int[] { currentPosition[0] - 1, currentPosition[1] }.SequenceEqual(nextPosition) ||
                    new int[] { currentPosition[0] - 1, currentPosition[1] + 1 }.SequenceEqual(nextPosition) ||
                    new int[] { currentPosition[0] + 1, currentPosition[1] - 1 }.SequenceEqual(nextPosition))
                {
                    isValid = true;
                }
            }
            else if (piece == 'R')
            {
                if (currentPosition[0] == nextPosition[0] || currentPosition[1] == nextPosition[1])
                {
                    isValid = true;
                }
            }
            else if (piece == 'B')
            {
                int rowsDiference = Math.Abs(currentPosition[0] - nextPosition[0]);
                int colsDiference = Math.Abs(currentPosition[1] - nextPosition[1]);

                if (rowsDiference == colsDiference)
                {
                    isValid = true;
                }
            }
            else if (piece == 'P')
            {
                if (nextPosition[0] - currentPosition[0] == -1 && currentPosition[1] == nextPosition[1])
                {
                    isValid = true;
                }
            }
            else if (piece == 'Q')
            {
                if (currentPosition[0] == nextPosition[0] || currentPosition[1] == nextPosition[1])
                {
                    isValid = true;
                }
                else
                {
                    int rowsDiference = Math.Abs(currentPosition[0] - nextPosition[0]);
                    int colsDiference = Math.Abs(currentPosition[1] - nextPosition[1]);

                    if (rowsDiference == colsDiference)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}
