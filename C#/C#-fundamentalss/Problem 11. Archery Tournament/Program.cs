using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int points = 0;
            bool gameOver = false;

            while (!gameOver)
            {
                
                List<string> command = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).ToList();

                if (command[0] == "Game over")
                {
                    Console.WriteLine(string.Join(" - ", targets));
                    Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
                    gameOver = true;
                    continue; 
                }

                else if (command[0] == "Shoot Left")
                {
                    points = ShootLeft(targets, command, points);
                }
                else if (command[0] == "Shoot Right")
                {
                    points = ShootRight(targets, command, points);
                }
                else if (command[0] == "Reverse")
                {
                    targets.Reverse();
                }

            }
        }
        static int ShootLeft(List<int> targets, List<string> command, int points)
        {
            int startIndex = int.Parse(command[1]);
            int length = int.Parse(command[2]);
            int shootPosition = startIndex - length;

            if (startIndex >= 0 && startIndex <= targets.Count - 1)
            {
                if (shootPosition < 0)
                {
                    while (shootPosition < 0 || shootPosition > targets.Count - 1)
                    {
                        shootPosition = targets.Count - Math.Abs(shootPosition);
                    }
                    shootPosition = Math.Abs(shootPosition);
                    points += 5;
                    targets[shootPosition] -= 5;

                    if (targets[shootPosition] < 5)
                    {
                        points += targets[shootPosition];
                        targets[shootPosition] = 0;
                    }

                }
                else
                {
                    points += 5;
                    targets[shootPosition] -= 5;

                    if (targets[shootPosition] < 5)
                    {
                        points += targets[shootPosition];
                        targets[shootPosition] = 0;
                    }
                }
            }
            return points;
        }
        static int ShootRight(List<int> targets, List<string> command, int points)
        {
            int startIndex = int.Parse(command[1]);
            int length = int.Parse(command[2]);
            int shootPosition = startIndex + length;

            if (startIndex >= 0 && startIndex <= targets.Count - 1)
            {
                if (shootPosition > targets.Count - 1)
                {
                    while (shootPosition > targets.Count - 1)
                    {
                        shootPosition = shootPosition - targets.Count;
                    }

                    points += 5;
                    targets[shootPosition] -= 5;

                    if (targets[shootPosition] < 5)
                    {
                        points += targets[shootPosition];
                        targets[shootPosition] = 0;
                    }

                }
                else
                {
                    points += 5;
                    targets[shootPosition] -= 5;

                    if (targets[shootPosition] < 5)
                    {
                        points += targets[shootPosition];
                        targets[shootPosition] = 0;
                    }
                }
            }
            return points;
        }


    }
}
