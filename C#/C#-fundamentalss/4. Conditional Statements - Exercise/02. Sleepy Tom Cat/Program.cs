using System;

namespace _02._Sleepy_Tom_Cat
{
    class Program
    {
        private const int oneyearDays = 365;
        private const int gameMinutes = 30000;
        private const int minutesWorkday = 63;
        private const int minutesOffday = 127;

        static void Main(string[] args)
        {
            int offDays = int.Parse(Console.ReadLine());
            int workDays = oneyearDays - offDays;
            int playTime = workDays * minutesWorkday + offDays * minutesOffday;

            if (playTime >= gameMinutes)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{(playTime - gameMinutes) / 60} hours and {(playTime - gameMinutes) % 60} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{(gameMinutes - playTime)/60} hours and {(gameMinutes - playTime) % 60} minutes less for play");
            }
        }
    }
}
