using System;
using System.Collections.Generic;
using System.Linq;

namespace pr03___Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split().ToArray();
            string[][] matrix = new string[n][];

            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').ToArray();
                if (matrix[i].Contains("s"))
                {
                    playerRow = i;
                    playerCol = Array.IndexOf(matrix[i], "s");
                }
            }

            HashSet<Tuple<int, int>> coalLocations = new HashSet<Tuple<int, int>>();
            GetLocations(coalLocations, matrix);
            Tuple<int, int> eLocation = GetLocationOfe(matrix);

            for (int i = 0; i < commands.Length; i++)
            {
                string direction = commands[i];
                switch (direction)
                {
                    case "left":
                        if (playerCol > 0)
                        {
                            playerCol--;
                        }
                        break;
                    case "right":
                        if (playerCol + 1 < matrix[playerRow].Length)
                        {
                            playerCol++;
                        }
                        break;
                    case "up":
                        if (playerRow>0)
                        {
                            playerRow--;
                        }
                        break;
                    case "down":
                        if (playerRow+1 < matrix.Length)
                        {
                            playerRow++;
                        }
                        break;
                }

                if (eLocation.Equals(new Tuple<int, int>(playerRow, playerCol)))
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    return;
                }

                if (coalLocations.Contains(new Tuple<int, int>(playerRow, playerCol)))
                {
                    coalLocations.Remove(new Tuple<int, int>(playerRow, playerCol));
                    if (coalLocations.Count == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{coalLocations.Count} coals left. ({playerRow}, {playerCol})");
        }
        private static void FindPlayerPosition(int n, string[][] matrix, int[] playerPos)
        {
            var isFoundPos = false;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == "P")
                    {
                        playerPos[0] = row;
                        playerPos[1] = col;
                        isFoundPos = true;
                        break;
                    }
                    if (isFoundPos)
                    {
                        return;
                    }
                }
            }
        }
        private static HashSet<Tuple<int, int>> GetLocations(HashSet<Tuple<int, int>> coalLocations, string[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == "c")
                    {
                        coalLocations.Add(new Tuple<int, int>(row, col));
                    }
                }
            }

            return coalLocations;
        }
        private static Tuple<int, int> GetLocationOfe(string[][] field)
        {
            int rows = 0;
            int cols = 0;
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == "e")
                    {
                        rows = row;
                        cols = col;
                    }
                }
            }
            return new Tuple<int, int>(rows, cols);
        }

        private static void ReadMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row][col] = input[col];
                }
            }
        }
        static void PrintMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
