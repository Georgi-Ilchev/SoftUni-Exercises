using System;
using System.Collections.Generic;
using System.Data;

namespace problem14___Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            var playerOne = new int[2];
            var playerTwo = new int[2];

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'f')
                    {
                        playerOne[0] = row;
                        playerOne[1] = col;
                    }
                    if (input[col] == 's')
                    {
                        playerTwo[0] = row;
                        playerTwo[1] = col;
                    }
                }
            }

            char symbolFirstPlayer = 'f';
            char symbolSecondPlayer = 's';
            bool isEnd = false;

            while (!isEnd)
            {
                string[] commands = Console.ReadLine().Split();
                string firstCommand = commands[0];
                string secondCommand = commands[1];

                isEnd = Move(firstCommand, playerOne, matrix, symbolFirstPlayer);
                if (isEnd)
                {
                    break;
                }
                isEnd = Move(secondCommand, playerTwo, matrix, symbolSecondPlayer);
            }

            PrintMatrix(matrix);
        }
        public static bool Move(string destination, int[] playerPosition, char[,] matrix, char symbolPlayer)
        {
            bool isEnd = false;
            ChangePositionOfPlayer(destination, playerPosition, matrix);
            if (matrix[playerPosition[0], playerPosition[1]] == '*')
            {
                matrix[playerPosition[0], playerPosition[1]] = symbolPlayer;
            }
            else
            {
                isEnd = true;
                matrix[playerPosition[0], playerPosition[1]] = 'x';
            }

            return isEnd;
        }
        private static void ChangePositionOfPlayer(string destination, int[] playerPosition, char[,] matrix)
        {
            if (destination == "up")
            {
                if (playerPosition[0] == 0)
                {
                    //row--;
                    playerPosition[0] = matrix.GetLength(0) - 1;
                }
                else
                {
                    playerPosition[0] -= 1;
                }
            }
            else if (destination == "down")
            {
                //row++;
                if (playerPosition[0] == matrix.GetLength(0) - 1)
                {
                    playerPosition[0] = 0;
                }
                else
                {
                    playerPosition[0] += 1;
                }
            }
            else if (destination == "left")
            {
                //col--;
                if (playerPosition[1] == 0)

                {
                    playerPosition[1] = matrix.GetLength(0) - 1;
                }
                else
                {
                    playerPosition[1] -= 1;
                }

            }
            else if (destination == "right")
            {
                //col++;
                if (playerPosition[1] == matrix.GetLength(0) - 1)
                {
                    playerPosition[1] = 0;
                }
                else
                {
                    playerPosition[1] += 1;
                }
            }
        }
        public static void PrintMatrix(char[,] matrix)
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
