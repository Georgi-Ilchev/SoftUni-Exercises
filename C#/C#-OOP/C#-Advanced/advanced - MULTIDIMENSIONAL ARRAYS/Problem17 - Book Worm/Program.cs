using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Problem17___Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            //string word = Console.ReadLine();

            //int n = int.Parse(Console.ReadLine());
            //char[,] matrix = new char[n, n];
            //int wormRow = -1;
            //int wormCol = -1;

            //for (int row = 0; row < n; row++)
            //{
            //    string input = Console.ReadLine();
            //    for (int col = 0; col < n; col++)
            //    {
            //        matrix[row, col] = input[col];
            //        if (input[col] == 'P')
            //        {
            //            wormRow = row;
            //            wormCol = col;
            //        }
            //    }
            //}

            //string command;
            //while ((command = Console.ReadLine()) != "end")
            //{
            //    matrix[wormRow, wormCol] = '-';
            //    if (command == "left")
            //    {
            //        wormCol--;
            //        if (wormCol > n - 1 || wormCol < 0 ||
            //        wormRow > n - 1 || wormRow < 0)
            //        {
            //            word = word.Remove(word.Length - 1);
            //            wormCol++;
            //            command = Console.ReadLine();
            //            break;
            //        }
            //        wormCol++;
            //    }

            //    switch (command)
            //    {
            //        case "up":
            //            wormRow--;
            //            break;
            //        case "down":
            //            wormRow++;
            //            break;
            //        case "left":
            //            wormCol--;
            //            break;
            //        case "right":
            //            wormCol++;
            //            break;
            //    }

            //    if (wormCol > n - 1 || wormCol < 0 ||
            //        wormRow > n - 1 || wormRow < 0)
            //    {
            //        word = word.Remove(word.Length - 1);
            //        continue;
            //    }

            //    if (matrix[wormRow, wormCol] != '-')
            //    {
            //        char charToAdd = matrix[wormRow, wormCol];
            //        word = word + charToAdd;
            //    }
            //}
            //Console.WriteLine(word);
            //matrix[wormRow, wormCol] = 'P';
            //PrintMatrix(matrix);

            string initialString = Console.ReadLine();

            int n = int.Parse(Console.ReadLine());
            var field = new char[n][];
            FillTheMatrix(n, field);
            var playerPos = new int[2];
            FindPlayerPosition(n, field, playerPos);
            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                initialString = RunCmd(initialString, n, field, playerPos, cmd);
            }

            Console.WriteLine(initialString);
            field[playerPos[0]][playerPos[1]] = 'P';
            PrintMatrix(field);
        }
        static void PrintMatrix(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
            private static void FindPlayerPosition(int n, char[][] field, int[] playerPos)
            {
                var isFoundPos = false;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (field[row][col] == 'P')
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
        private static void FillTheMatrix(int n, char[][] field)
        {
            for (int row = 0; row < n; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();
            }
        }
        private static string RunCmd(string initialString, int n, char[][] field, int[] playerPos, string cmd)
        {
            bool isValid = true;
            field[playerPos[0]][playerPos[1]] = '-';
            if (cmd == "up")
            {
                isValid = ValidateNewPositionOfPlayer(playerPos, playerPos[0] - 1, playerPos[1], n);
            }
            else if (cmd == "down")
            {
                isValid = ValidateNewPositionOfPlayer(playerPos, playerPos[0] + 1, playerPos[1], n);
            }
            else if (cmd == "left")
            {
                isValid = ValidateNewPositionOfPlayer(playerPos, playerPos[0], playerPos[1] - 1, n);
            }
            else if (cmd == "right")
            {
                isValid = ValidateNewPositionOfPlayer(playerPos, playerPos[0], playerPos[1] + 1, n);
            }
            if (isValid)
            {
                if (field[playerPos[0]][playerPos[1]] != '-')
                {
                    var charToAdd = field[playerPos[0]][playerPos[1]];
                    initialString = initialString + charToAdd;
                }
            }
            else
            {
                initialString = initialString.Remove(initialString.Length - 1);
            }

            return initialString;
        }
        static bool ValidateNewPositionOfPlayer(int[] playerPos, int playerRow, int playerCol, int n)
        {
            bool isValidMovement = true;
            if (playerRow >= 0 && playerRow < n
                && playerCol >= 0 && playerCol < n)
            {
                playerPos[0] = playerRow;
                playerPos[1] = playerCol;
                return isValidMovement;
            }
            else
            {
                return false;
            }
        }
    }
}
