using System;

namespace _04._Cruise_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int playedGames = int.Parse(Console.ReadLine());


            double pointsVolleyball = 0;
            int volleyballCounter = 0;

            double pointsTennis = 0;
            int tennisCounter = 0;

            double pointsBadminton = 0;
            int badmintonCounter = 0;

            for (int i = 1; i <= playedGames; i++)
            {
                string gameName = Console.ReadLine();
                double gamePoints = int.Parse(Console.ReadLine());

                if (gameName == "volleyball")
                {
                    gamePoints *= 1.07;
                    pointsVolleyball += gamePoints;
                    volleyballCounter++;
                }
                else if (gameName == "tennis")
                {
                    gamePoints *= 1.05;
                    pointsTennis += gamePoints;
                    tennisCounter++;

                }
                else if (gameName == "badminton")
                {
                    gamePoints *= 1.02;
                    pointsBadminton += gamePoints;
                    badmintonCounter++;
                }

            }
            double volleyballAveragePoints = Math.Floor(pointsVolleyball / volleyballCounter);
            double tennisAveragePoints = Math.Floor(pointsTennis / tennisCounter);
            double badmintonAveragePoints = Math.Floor(pointsBadminton / badmintonCounter);

            double sum = Math.Floor(pointsVolleyball + pointsTennis + pointsBadminton);

            if (volleyballAveragePoints >= 75 && tennisAveragePoints >= 75 && badmintonAveragePoints >= 75)
            {
                Console.WriteLine($"Congratulations, {name}! You won the cruise games with {sum} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {name}, you lost. Your points are only {sum}.");
            }



        }
    }
}
