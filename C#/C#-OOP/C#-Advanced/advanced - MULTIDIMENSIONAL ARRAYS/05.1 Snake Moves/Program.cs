using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._1_Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];

            var matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            Queue<char> snakeQueue = new Queue<char>(snake);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (snakeQueue.Any())
                        {
                            matrix[row, col] = snakeQueue.Dequeue();
                        }
                        else
                        {
                            for (int i = 0; i < snake.Length; i++)
                            {
                                snakeQueue.Enqueue(snake[i]);
                            }
                            matrix[row, col] = snakeQueue.Dequeue();
                        }
                    }
                }
                else
                {
                    for (int col2 = matrix.GetLength(1) - 1; col2 >= 0; col2--)
                    {
                        if (snakeQueue.Any())
                        {
                            matrix[row, col2] = snakeQueue.Dequeue();
                        }
                        else
                        {
                            for (int i = 0; i < snake.Length; i++)
                            {
                                snakeQueue.Enqueue(snake[i]);
                            }
                            matrix[row, col2] = snakeQueue.Dequeue();
                        }
                    }
                }

            }

            PrintMatrix(matrix);
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
    }
}
