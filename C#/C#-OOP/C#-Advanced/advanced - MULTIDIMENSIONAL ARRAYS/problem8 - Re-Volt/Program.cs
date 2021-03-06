using System;

namespace problem8___Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCmd = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            CreateTheMatrix(size, matrix);

            int[] playerPos = FindPlayerPosition(size, matrix);

            bool isWin = false;



            for (int i = 0; i < countOfCmd; i++)
            {
                string command = Console.ReadLine();
                matrix[playerPos[0]][playerPos[1]] = '-';
                isWin = MovePlayer(matrix, size, command, playerPos, isWin);

                if (isWin)
                {
                    Console.WriteLine("Player won!");
                    break;
                }
            }
            matrix[playerPos[0]][playerPos[1]] = 'f';

            if (!isWin)
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < size; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
        private static bool CheckIsNextPosInMatrix(int size, int x, int y)
        {
            if (x >= 0 && x < size && y >= 0 && y < size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool MovePlayer(char[][] matrix, int size, string command, int[] playerPos, bool isWin)
        {
            int playerRow = playerPos[0];
            int playerCol = playerPos[1];

            if (command == "left")
            {
                bool check = CheckIsNextPosInMatrix(size, playerRow, playerCol - 1);
                playerCol = check == true ? playerCol - 1 : size - 1;
                playerPos[1] = playerCol;

                if (matrix[playerRow][playerCol] == 'F')
                {
                    isWin = true;

                }
                else if (matrix[playerRow][playerCol] == 'B')
                {
                    isWin = MovePlayer(matrix, size, "left", playerPos, isWin);

                }
                else if (matrix[playerRow][playerCol] == 'T')
                {
                    isWin = MovePlayer(matrix, size, "right", playerPos, isWin);
                }
            }
            else if (command == "right")
            {
                bool check = CheckIsNextPosInMatrix(size, playerRow, playerCol + 1);
                playerCol = check == true ? playerCol + 1 : 0;
                playerPos[1] = playerCol;

                if (matrix[playerRow][playerCol] == 'F')
                {
                    isWin = true;
                }
                else if (matrix[playerRow][playerCol] == 'B')
                {
                    isWin = MovePlayer(matrix, size, "right", playerPos, isWin);

                }
                else if (matrix[playerRow][playerCol] == 'T')
                {
                    isWin = MovePlayer(matrix, size, "left", playerPos, isWin);
                }
            }
            else if (command == "up")
            {
                bool check = CheckIsNextPosInMatrix(size, playerRow - 1, playerCol);
                playerRow = check == true ? playerRow - 1 : size - 1;
                playerPos[0] = playerRow;

                if (matrix[playerRow][playerCol] == 'F')
                {
                    isWin = true;

                }
                else if (matrix[playerRow][playerCol] == 'B')
                {
                    isWin = MovePlayer(matrix, size, "up", playerPos, isWin);

                }
                else if (matrix[playerRow][playerCol] == 'T')
                {
                    isWin = MovePlayer(matrix, size, "down", playerPos, isWin);
                }
            }
            else if (command == "down")
            {
                bool check = CheckIsNextPosInMatrix(size, playerRow + 1, playerCol);
                playerRow = check == true ? playerRow + 1 : 0;
                playerPos[0] = playerRow;

                if (matrix[playerRow][playerCol] == 'F')
                {
                    isWin = true;

                }
                else if (matrix[playerRow][playerCol] == 'B')
                {
                    isWin = MovePlayer(matrix, size, "down", playerPos, isWin);

                }
                else if (matrix[playerRow][playerCol] == 'T')
                {
                    isWin = MovePlayer(matrix, size, "up", playerPos, isWin);
                }
            }
            return isWin;
        }
        private static void CreateTheMatrix(int size, char[][] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[row] = input;
            }
        }

        private static int[] FindPlayerPosition(int size, char[][] matrix)
        {
            int[] playerPos = new int[2];
            bool isFound = false;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row][col] == 'f')
                    {
                        isFound = true;
                        playerPos[0] = row;
                        playerPos[1] = col;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            return playerPos;
        }
    }
}
