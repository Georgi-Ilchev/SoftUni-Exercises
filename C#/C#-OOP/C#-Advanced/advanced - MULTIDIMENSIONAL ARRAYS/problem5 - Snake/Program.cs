using System;

namespace problem5___Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] snakeTeritory = new char[n, n];
            int snakeRow = -1;
            int snakeCol = -1;

            //2
            int firstBurrowRow = -1;
            int firstBurrowCol = -1;

            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    snakeTeritory[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    if (input[col] == 'B')
                    {
                        if (firstBurrowRow == -1)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }
                }
            }

            int foods = 0;
            string command = Console.ReadLine();
            while (true)
            {
                snakeTeritory[snakeRow, snakeCol] = '.';
                switch (command)
                {
                    case "up":
                        snakeRow--;
                        break;
                    case "down":
                        snakeRow++;
                        break;
                    case "left":
                        snakeCol--;
                        break;
                    case "right":
                        snakeCol++;
                        break;
                }
                //1
                //if (snakeCol > n - 1 || snakeCol < 0 ||
                //    snakeRow > n - 1 || snakeRow < 0)
                //{
                //    Console.WriteLine($"Game over!");
                //    break;
                //}

                //1 - with method
                if (!IsSafe(snakeTeritory, snakeRow, snakeCol))
                {
                    Console.WriteLine($"Game over!");
                    break;
                }

                if (snakeTeritory[snakeRow, snakeCol] == '*')
                {
                    foods++;
                    if (foods >= 10)
                    {
                        Console.WriteLine($"You won! You fed the snake.");
                        snakeTeritory[snakeRow, snakeCol] = 'S';
                        break;
                    }
                }
                else if (snakeTeritory[snakeRow, snakeCol] == 'B')
                {
                    //2
                    //snakeTeritory[snakeRow, snakeCol] = '.';
                    //bool isFound = false;
                    //for (int row = 0; row < n; row++)
                    //{
                    //    for (int col = 0; col < n; col++)
                    //    {
                    //        if (snakeTeritory[row, col] == 'B')
                    //        {
                    //            snakeRow = row;
                    //            snakeCol = col;
                    //            isFound = true;
                    //            break;
                    //        }
                    //    }
                    //    if (isFound)
                    //    {
                    //        break;
                    //    }
                    //}

                    //2
                    snakeTeritory[snakeRow, snakeCol] = '.';
                    if (firstBurrowRow == snakeRow && firstBurrowCol == snakeCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"Food eaten: {foods}");

            PrintMatrix(snakeTeritory);
        }
        static void PrintMatrix(char[,] matrix)
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
        static bool IsSafe(char[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
