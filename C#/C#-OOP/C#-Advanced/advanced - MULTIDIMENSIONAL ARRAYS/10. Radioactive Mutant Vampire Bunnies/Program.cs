﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class BunniesCoordinates
    {
        public int BunnieRow { get; set; }
        public int BunnieCol { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = -1;
            int playerCol = -1;

            List<BunniesCoordinates> bunniesCoordinates = new List<BunniesCoordinates>();

            for (int row = 0; row < rows; row++)
            {
                string inputRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (inputRow[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (inputRow[col] == 'B')
                    {
                        bunniesCoordinates.Add(new BunniesCoordinates { BunnieRow = row, BunnieCol = col });
                    }
                }
            }

            char[] moves = Console.ReadLine().ToCharArray();

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'U':
                        if (playerRow - 1 < 0)
                        {
                            matrix[playerRow, playerCol] = '.';
                            bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"won: {playerRow} {playerCol}");
                            return;
                        }

                        if (matrix[playerRow - 1, playerCol] == 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow = playerRow - 1;
                            bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            return;
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow - 1, playerCol] = 'P';
                            playerRow = playerRow - 1;
                        }

                        // Растеж на зайчетата
                        bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                        break;

                    case 'D':
                        if (playerRow + 1 > matrix.GetLength(0) - 1)
                        {
                            matrix[playerRow, playerCol] = '.';
                            bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"won: {playerRow} {playerCol}");
                            return;
                        }

                        if (matrix[playerRow + 1, playerCol] == 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow = playerRow + 1;
                            bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            return;
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow + 1, playerCol] = 'P';
                            playerRow = playerRow + 1;
                        }

                        // Растеж на зайчетата
                        bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                        break;

                    case 'L':
                        if (playerCol - 1 < 0)
                        {
                            matrix[playerRow, playerCol] = '.';
                            bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"won: {playerRow} {playerCol}");
                            return;
                        }

                        if (matrix[playerRow, playerCol - 1] == 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol = playerCol - 1;
                            bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            return;
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow, playerCol - 1] = 'P';
                            playerCol = playerCol - 1;
                        }

                        // Растеж на зайчетата
                        bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                        break;

                    case 'R':
                        if (playerCol + 1 > matrix.GetLength(1) - 1)
                        {
                            matrix[playerRow, playerCol] = '.';
                            bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"won: {playerRow} {playerCol}");
                            return;
                        }

                        if (matrix[playerRow, playerCol + 1] == 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol = playerCol + 1;
                            bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            return;
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow, playerCol + 1] = 'P';
                            playerCol = playerCol + 1;
                        }

                        // Растеж на зайчетата
                        bunniesCoordinates = ExpandBunnies(rows, cols, matrix, playerRow, playerCol, bunniesCoordinates);
                        break;
                }
            }
        }

        private static void PrintMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static List<BunniesCoordinates> ExpandBunnies(int rows, int cols, char[,] matrix, int playerRow, int playerCol, List<BunniesCoordinates> bunniesCoordinates)
        {
            bool isBunnyFoundPlayer = false;

            foreach (var bunnie in bunniesCoordinates)
            {
                if (matrix[bunnie.BunnieRow, bunnie.BunnieCol] == 'B')
                {
                    if (bunnie.BunnieRow >= 1) // Горе
                    {
                        if (matrix[bunnie.BunnieRow - 1, bunnie.BunnieCol] == 'P')
                        {
                            matrix[bunnie.BunnieRow - 1, bunnie.BunnieCol] = 'B';

                            isBunnyFoundPlayer = true;
                        }
                        else
                        {
                            if (matrix[bunnie.BunnieRow - 1, bunnie.BunnieCol] == '.')
                            {
                                matrix[bunnie.BunnieRow - 1, bunnie.BunnieCol] = 'B';
                            }
                        }
                    }

                    if (bunnie.BunnieCol >= 1) // Ляво
                    {
                        if (matrix[bunnie.BunnieRow, bunnie.BunnieCol - 1] == 'P')
                        {
                            matrix[bunnie.BunnieRow, bunnie.BunnieCol - 1] = 'B';
                            isBunnyFoundPlayer = true;
                        }
                        else
                        {
                            if (matrix[bunnie.BunnieRow, bunnie.BunnieCol - 1] == '.')
                            {
                                matrix[bunnie.BunnieRow, bunnie.BunnieCol - 1] = 'B';
                            }
                        }
                    }

                    if (bunnie.BunnieCol < matrix.GetLength(1) - 1) // Дясно
                    {
                        if (matrix[bunnie.BunnieRow, bunnie.BunnieCol + 1] == 'P')
                        {
                            matrix[bunnie.BunnieRow, bunnie.BunnieCol + 1] = 'B';
                            isBunnyFoundPlayer = true;
                        }
                        else
                        {
                            if (matrix[bunnie.BunnieRow, bunnie.BunnieCol + 1] == '.')
                            {
                                matrix[bunnie.BunnieRow, bunnie.BunnieCol + 1] = 'B';
                            }
                        }
                    }

                    if (bunnie.BunnieRow < matrix.GetLength(0) - 1) // Долу
                    {
                        if (matrix[bunnie.BunnieRow + 1, bunnie.BunnieCol] == 'P')
                        {
                            matrix[bunnie.BunnieRow + 1, bunnie.BunnieCol] = 'B';
                            isBunnyFoundPlayer = true;


                            //PrintMatrix(rows, cols, matrix);
                            //Console.WriteLine($"dead: {playerRow} {playerCol}");
                            //System.Environment.Exit(1);
                        }
                        else
                        {
                            if (matrix[bunnie.BunnieRow + 1, bunnie.BunnieCol] == '.')
                            {
                                matrix[bunnie.BunnieRow + 1, bunnie.BunnieCol] = 'B';
                            }
                        }
                    }
                }
            }

            if (isBunnyFoundPlayer)
            {
                PrintMatrix(rows, cols, matrix);
                Console.WriteLine($"dead: {playerRow} {playerCol}");
                System.Environment.Exit(1);
            }

            bunniesCoordinates = new List<BunniesCoordinates>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesCoordinates.Add(new BunniesCoordinates { BunnieRow = row, BunnieCol = col });
                    }
                }
            }

            return bunniesCoordinates;
        }
    }
}
