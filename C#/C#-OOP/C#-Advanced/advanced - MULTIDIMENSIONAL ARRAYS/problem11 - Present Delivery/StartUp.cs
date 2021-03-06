using System;
using System.Linq;
using System.Net.Security;

namespace problem11___Present_Delivery
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //int presentsCount = int.Parse(Console.ReadLine());
            //int n = int.Parse(Console.ReadLine());

            //string[,] santaTeritory = new string[n, n];
            //int santaRow = -1;
            //int santaCol = -1;

            //int niceKidsCount = 0;
            //int happyKids = 0;

            //for (int row = 0; row < n; row++)
            //{
            //    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //    for (int col = 0; col < n; col++)
            //    {
            //        santaTeritory[row, col] = input[col];
            //        if (input[col] == "S")
            //        {
            //            santaRow = row;
            //            santaCol = col;
            //        }
            //        else if (input[col] == "V")
            //        {
            //            happyKids++;
            //        }
            //    }
            //}

            //string command = Console.ReadLine();
            //while (command != "Christmas morning" || presentsCount > 0)
            //{
            //    santaTeritory[santaRow, santaCol] = "-";
            //    switch (command)
            //    {
            //        case "up":
            //            santaRow--;
            //            break;
            //        case "down":
            //            santaRow++;
            //            break;
            //        case "left":
            //            santaCol--;
            //            break;
            //        case "right":
            //            santaCol++;
            //            break;
            //    }

            //    if (santaTeritory[santaRow, santaCol] == "C")
            //    {
            //        if (presentsCount > 0)
            //        {
            //            //up
            //            //if (santaTeritory[santaRow--, santaCol] == "V" ||
            //            //    santaTeritory[santaRow--, santaCol] == "X")
            //            //{
            //            //    niceKidsCount++;
            //            //    pressentsCount--;
            //            //}
            //            if (santaTeritory[santaRow - 1, santaCol] != "-")// up
            //            {
            //                presentsCount--;
            //                santaTeritory[santaRow - 1, santaCol] = "-";
            //                if (presentsCount == 0)
            //                {
            //                    santaTeritory[santaRow, santaCol] = "S";
            //                    break;
            //                }
            //            }
            //            //down
            //            //if (santaTeritory[santaRow++, santaCol] == "V" ||
            //            //    santaTeritory[santaRow++, santaCol] == "X")
            //            //{
            //            //    niceKidsCount++;
            //            //    pressentsCount--;
            //            //}
            //            if (santaTeritory[santaRow + 1, santaCol] == "V")// down
            //            {
            //                presentsCount--;
            //                santaTeritory[santaRow + 1, santaCol] = "-";
            //                if (presentsCount == 0)
            //                {
            //                    santaTeritory[santaRow, santaCol] = "S";
            //                    break;
            //                }
            //            }
            //            //left
            //            //if (santaTeritory[santaRow, santaCol--] == "V" ||
            //            //    santaTeritory[santaRow, santaCol--] == "X")
            //            //{
            //            //    niceKidsCount++;
            //            //    pressentsCount--;
            //            //}
            //            if (santaTeritory[santaRow, santaCol - 1] != "-")// left
            //            {
            //                presentsCount--;
            //                santaTeritory[santaRow, santaCol - 1] = "-";
            //                if (presentsCount == 0)
            //                {
            //                    santaTeritory[santaRow, santaCol] = "S";
            //                    break;
            //                }
            //            }
            //            //right
            //            //if (santaTeritory[santaRow, santaCol++] == "V" ||
            //            //    santaTeritory[santaRow, santaCol++] == "X")
            //            //{
            //            //    niceKidsCount++;
            //            //    pressentsCount--;
            //            //}
            //            if (santaTeritory[santaRow, santaCol + 1] != "-")// right
            //            {
            //                presentsCount--;
            //                santaTeritory[santaRow, santaCol + 1] = "-";
            //                if (presentsCount == 0)
            //                {
            //                    santaTeritory[santaRow, santaCol] = "S";
            //                    break;
            //                }
            //            }
            //        }
            //    }

            //    if (santaTeritory[santaRow, santaCol] == "V")
            //    {
            //        niceKidsCount++;
            //        presentsCount--;
            //        if (happyKids == niceKidsCount)
            //        {
            //            santaTeritory[santaRow, santaCol] = "S";
            //            break;
            //        }
            //    }
            //    //if (santaTeritory[santaRow, santaCol] == 'X')
            //    //{
            //    //    continue;
            //    //}

            //    command = Console.ReadLine();
            //}
            //if (presentsCount == 0)
            //{
            //    Console.WriteLine($"Santa ran out of presents!");
            //}

            //int goodKidsLeft = 0;

            //foreach (var item in santaTeritory)
            //{
            //    if (item == "V")
            //    {
            //        goodKidsLeft++;
            //    }
            //}

            //PrintMatrix(santaTeritory);

            //if (goodKidsLeft == 0)
            //{
            //    Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            //}
            //else
            //{
            //    Console.WriteLine($"No presents for {goodKidsLeft} nice kid/s.");
            //}

            int presentsCount = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            int santaRow = -1;
            int santaCol = -1;

            int happyKids = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (line[j].ToString() == "S")
                    {
                        santaRow = i;
                        santaCol = j;
                    }
                    else if (line[j].ToString() == "V")
                    {
                        happyKids++;
                    }

                    matrix[i, j] = line[j];
                }
            }

            string command = "";

            while ((command = Console.ReadLine()) != "Christmas morning" && presentsCount > 0)
            {
                matrix[santaRow, santaCol] = "-";

                if (command == "up")
                {
                    santaRow--;
                }
                else if (command == "down")
                {
                    santaRow++;
                }
                else if (command == "left")
                {
                    santaCol--;
                }
                else if (command == "right")
                {
                    santaCol++;
                }

                if (CheckBounderies(matrix, santaRow, santaCol))
                {
                    Console.WriteLine("Santa ran out of presents.");
                    break;
                }

                if (matrix[santaRow, santaCol] == "-")
                {
                    matrix[santaRow, santaCol] = "S";
                }
                else if (matrix[santaRow, santaCol] == "V")
                {
                    matrix[santaRow, santaCol] = "S";
                    presentsCount--;

                    if (presentsCount == 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                }
                else if (matrix[santaRow, santaCol] == "X")
                {
                    continue;
                }
                else if (matrix[santaRow, santaCol] == "C")
                {
                    matrix[santaRow, santaCol] = "S";


                    if (matrix[santaRow, santaCol + 1] != "-")// right
                    {
                        presentsCount--;
                        matrix[santaRow, santaCol + 1] = "-";
                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                    if (matrix[santaRow, santaCol - 1] != "-")// left
                    {
                        presentsCount--;
                        matrix[santaRow, santaCol - 1] = "-";
                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                    if (matrix[santaRow - 1, santaCol] != "-")// up
                    {
                        presentsCount--;
                        matrix[santaRow - 1, santaCol] = "-";
                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                    if (matrix[santaRow + 1, santaCol] == "V")// down
                    {
                        presentsCount--;
                        matrix[santaRow + 1, santaCol] = "-";
                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                }
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

        static bool CheckBounderies(string[,] matrix, int santaRow, int santaCol)
        {
            return santaRow < 0 || santaRow >= matrix.GetLength(0) || santaCol < 0 || santaCol >= matrix.GetLength(1);
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
    }
}
