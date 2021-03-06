using System;

namespace _05._Darts_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingPoints = int.Parse(Console.ReadLine());
            int moves = 0;
            int sectorPoints = startingPoints;

            while (sectorPoints > 0)
            {
                moves++;
                string sector = Console.ReadLine();

                if (sector == "bullseye")
                {
                    Console.WriteLine($"Congratulations! You won the game with a bullseye in {moves} moves!");
                    return;
                }

                int points = int.Parse(Console.ReadLine());

                if (sector == "number section")
                {
                    sectorPoints -= points;
                }
                else if (sector == "double ring")
                {
                    sectorPoints = sectorPoints - (points * 2);
                }
                else if (sector == "triple ring")
                {
                    sectorPoints = sectorPoints - (points * 3);
                }
                

            }
            
            if (sectorPoints == 0)
            {
                Console.WriteLine($"Congratulations! You won the game in {moves} moves!");
            }
            else if (sectorPoints<0)
            {
                Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs(sectorPoints)}.");
            }
            

        }
    }
}
