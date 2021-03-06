using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordTime = double.Parse(Console.ReadLine());
            double distanceInMeteres = double.Parse(Console.ReadLine());
            double timeInSeconds = double.Parse(Console.ReadLine());

            double totalSeconds = distanceInMeteres * timeInSeconds;
            double delaySeconds = Math.Floor (distanceInMeteres / 15) * 12.5;

            double totalSecondsTime = totalSeconds + delaySeconds;

            if (totalSecondsTime < recordTime )
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {totalSecondsTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {totalSecondsTime - recordTime:f2} seconds slower.");
            }
        }
    }
}
