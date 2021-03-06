using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace preparetion
{
    class Program
    {
        public class Position
        {
            public Position(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }
            public int Row { get; set; }
            public int Col { get; set; }
            public bool IsSafe(int rowCount, int colCount)
            {
                if (Row < 0 || Col < 0)
                {
                    return false;
                }
                if (Row >= rowCount || Col >= colCount)
                {
                    return false;
                }
                return true;
            }
            public static Position GetDirection(string command)
            {
                int row = 0;
                int col = 0;
                if (command == "left")
                {
                    col = -1;
                }
                if (command == "right")
                {
                    col = 1;
                }
                if (command == "up")
                {
                    row = -1;
                }
                if (command == "down")
                {
                    row = 1;
                }
                return new Position(row, col);
            }
            public void CheckOtherSideMovement(int rowCount, int colCount)
            {
                if (Row < 0)
                {
                    Row = rowCount - 1;
                }
                if (Col < 0)
                {
                    Col = colCount - 1;
                }
                if (Row >= rowCount)
                {
                    Row = 0;
                }
                if (Col >= colCount)
                {
                    Col = 0;
                }
            }
        }
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];
            ReadMatrix(matrix);

            var player = GetPlayerPostion(matrix);
            var happyKids = GetKidsCount(matrix);

            string input;
            while ((input = Console.ReadLine()) != "Christmas morning" && presentsCount > 0)
            {
                matrix[player.Row, player.Col] = "-";
                MovePlayer(player, input, size);

                if (CheckBounderies(matrix, player.Row, player.Col))
                {
                    Console.WriteLine("Santa ran out of presents.");
                    break;
                }

                if (matrix[player.Row, player.Col] == "-")
                {
                    matrix[player.Row, player.Col] = "S";
                }
                else if (matrix[player.Row, player.Col] == "C")
                {
                    matrix[player.Row, player.Col] = "S";
                    //right
                    if (matrix[player.Row, player.Col + 1] != "-")
                    {
                        presentsCount--;
                        matrix[player.Row, player.Col + 1] = "-";
                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                    //left 
                    if (matrix[player.Row, player.Col - 1] != "-")
                    {
                        presentsCount--;
                        matrix[player.Row, player.Col - 1] = "-";
                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                    //up
                    if (matrix[player.Row - 1, player.Col] != "-")
                    {
                        presentsCount--;
                        matrix[player.Row - 1, player.Col] = "-";
                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                    //down
                    if (matrix[player.Row + 1, player.Col] != "-")
                    {
                        presentsCount--;
                        matrix[player.Row + 1, player.Col] = "-";
                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                }
                else if (matrix[player.Row, player.Col] == "V")
                {
                    matrix[player.Row, player.Col] = "S";
                    presentsCount--;
                    if (presentsCount == 0)
                    {
                        break;
                    }
                }
                else if (matrix[player.Row, player.Col] == "X")
                {
                    continue;
                }
            }
            if (presentsCount == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            int goodKidsLeft = 0;

            foreach (var item in matrix)
            {
                if (item == "V")
                {
                    goodKidsLeft++;
                }
            }
            PrintMatrix(matrix);

            if (goodKidsLeft == 0)
            {
                Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {goodKidsLeft} nice kid/s.");
            }

        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool CheckBounderies(string[,] matrix, int playerRow, int playerCol)
        {
            return playerRow < 0 || playerRow >= matrix.GetLength(0) || playerCol < 0 || playerCol >= matrix.GetLength(1);
        }
        private static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        public static int GetKidsCount(string[,] matrix)
        {
            var result = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "V")
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        static Position GetPlayerPostion(string[,] matrix) //int happyKids)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "S")
                    {
                        position = new Position(row, col);
                    }
                }
            }
            return position;
        }
        static Position MovePlayer(Position player, string command, int size)
        {
            Position movement = Position.GetDirection(command);
            player.Row += movement.Row;
            player.Col += movement.Col;
            player.CheckOtherSideMovement(size, size);
            return player;
        }
    }
}
