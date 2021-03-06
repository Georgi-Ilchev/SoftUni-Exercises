using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Bee
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
            int size = int.Parse(Console.ReadLine());
            int countOfCmd = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            Read(matrix);
            var player = GetPlayerPostion(matrix);

            if (countOfCmd > 0)
            {
                matrix[player.Row, player.Col] = '-';
            }

            for (int i = 0; i < countOfCmd; i++)
            {
                string command = Console.ReadLine();
                MovePlayer(player, command, size);

                while (matrix[player.Row, player.Col] == 'B')
                {
                    MovePlayer(player, command, size);
                }

                while (matrix[player.Row, player.Col] == 'T')
                {
                    Position direction = Position.GetDirection(command);
                    player.Row += direction.Row * -1;
                    player.Col += direction.Col * -1;
                }

                if (matrix[player.Row, player.Col] == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[player.Row, player.Col] = 'f';
                    PrintMatrix(matrix);
                    return;
                }
            }

            Console.WriteLine("Player lost!");
            matrix[player.Row, player.Col] = 'f';
            PrintMatrix(matrix);
        }

            static Position GetPlayerPostion(char[,] matrix)
            {
                Position position = null;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'f')
                        {
                            position = new Position(row, col);
                        }
                    }
                }
                return position;
            }

        private static void PrintMatrix(char[,] matrix)
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

        private static void Read(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static Position MovePlayer(Position player, string command, int size)
        {
            Position movement = Position.GetDirection(command);
            player.Row += movement.Row;
            player.Col += movement.Col;
            player.CheckOtherSideMovement(size, size);
            return player;
            //if (command == "left")
            //{
            //    player.Col--;
            //    if (!player.IsSafe(size, size))
            //    {
            //        player.Col = size - 1;
            //    }
            //}
            //if (command == "right")
            //{
            //    player.Col++;
            //    if (!player.IsSafe(size, size))
            //    {
            //        player.Col = 0;
            //    }
            //}
            //if (command == "up")
            //{
            //    player.Row--;
            //    if (!player.IsSafe(size, size))
            //    {
            //        player.Row = size - 1;
            //    }
            //}
            //if (command == "down")
            //{
            //    player.Row++;
            //    if (!player.IsSafe(size, size))
            //    {
            //        player.Row = 0;
            //    }
            //}
        }
    }
}
