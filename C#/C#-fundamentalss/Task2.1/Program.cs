using System;

namespace Task2._1
{
    class Program
    {
        public class Postiton
        {
            public Postiton(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }
            public int Row { get; set; }
            public int Col { get; set; }

            public bool IsSafe(int rowCount, int colCount)
            {
                if (this.Row < 0 || this.Col < 0)
                {
                    return false;
                }
                if (this.Row >= rowCount || this.Col >= colCount)
                {
                    return false;
                }
                return true;
            }

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            FillTheMatrix(matrix);
            Postiton position = GetPosition(matrix);

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "up")
                {
                    position.Row--;
                }
                else if (command == "down")
                {
                    position.Row++;
                }
                else if (command == "left")
                {
                    position.Col--;
                }
                else if (command == "right")
                {
                    position.Col++;
                }

                if (matrix[position.Row, position.Col] == 'E')
                {
                    break;
                }
            }

        }

        static void FillTheMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                //var line = Console.ReadLine().Split(", ").Select(char.Parse).ToArray();
                var line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        static Postiton GetPosition(char[,] matrix)
        {
            Postiton position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        position = new Postiton(row, col);

                    }
                }
            }
            return position;
        }

        private static void Print(char[,] matrix)
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
    }
}
