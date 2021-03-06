using System;

namespace Problem25._Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double steps = int.Parse(Console.ReadLine());
            double length1step = double.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());


            double fifthSteps = Math.Truncate(steps / 5);
            steps = steps - fifthSteps;

            double finalDistance = (steps * length1step) + (fifthSteps * length1step * 0.7);
            distance *= 100;
            double percentage = finalDistance / distance * 100;

            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");

        }
    }
}
