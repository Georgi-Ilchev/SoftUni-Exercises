using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var allStepsForTheDay = 10000;
            var totalSteps = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Going home")
                {
                    int backSteps = int.Parse(Console.ReadLine());
                    totalSteps += backSteps;
                    break;
                }

                totalSteps += int.Parse(input);

                if (totalSteps >= allStepsForTheDay)
                {
                    break;
                }
            }




            if (totalSteps >= allStepsForTheDay)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                var diffSteps = allStepsForTheDay - totalSteps;
                Console.WriteLine($"{diffSteps} more steps to reach goal.");
            }
        }
    }
}
