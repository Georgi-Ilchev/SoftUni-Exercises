using System;
using System.Net.Mail;

namespace pr10___Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            int playerRow = -1;
            int playerCol = -1;

            int enemyRow = -1;
            int enemyCol = -1;

            for (int row = 0; row < n; row++)
            {
                string text = Console.ReadLine();
                matrix[row] = new char[text.Length];

                for (int col = 0; col < text.Length; col++)
                {
                    char c = text[col];

                    if (c == 'N')
                    {
                        enemyRow = row;
                        enemyCol = col;
                        matrix[row][col] = 'N';
                    }
                    else if (c == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row][col] = '.';
                    }
                    else
                    {
                        matrix[row][col] = c;
                    }
                }
            }

            string movement = Console.ReadLine();
            bool isAlive = true;

            for (int i = 0; i < movement.Length; i++)
            {
                char move = movement[i];

                EnemyMove(matrix);

                for (int col = 0; col < matrix[playerRow].Length; col++)
                {
                    if (matrix[playerRow][col] == 'b' && col < playerCol)
                    {
                        matrix[playerRow][playerCol] = 'X';
                        isAlive = false;
                        break;
                    }
                    else if (matrix[playerRow][col] == 'd' &&  col > playerCol)
                    {
                        matrix[playerRow][playerCol] = 'X';
                        isAlive = false;
                        break;
                    }
                }

                if (!isAlive)
                {
                    Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                    break;
                }

                switch (move)
                {
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;
                }

                if (matrix[playerRow][playerCol] != '.')
                {
                    matrix[playerRow][playerCol] = '.';
                }

                if (playerRow == enemyRow)
                {
                    matrix[enemyRow][enemyCol] = 'X';
                    matrix[playerRow][playerCol] = 'S';

                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }
            }
            PrintMatrix(matrix);
        }

        private static void EnemyMove(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b' ||
                        matrix[row][col] == 'd')
                    {
                        MoveEnemys(row, col, matrix);
                        break;
                    }
                }
            }
        }

        private static void MoveEnemys(int row, int col, char[][] matrix)
        {
            if (matrix[row][col] == 'b')
            {
                if (col + 1 >= matrix[row].Length)
                {
                    matrix[row][col] = 'd';
                }
                else
                {
                    matrix[row][col] = '.';
                    matrix[row][col + 1] = 'b';
                }
            }
            else
            {
                if (col - 1 < 0)
                {
                    matrix[row][col] = 'b';
                }
                else
                {
                    matrix[row][col] = '.';
                    matrix[row][col - 1] = 'd';
                }
            }
        }
        static void PrintMatrix(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
    }
}
