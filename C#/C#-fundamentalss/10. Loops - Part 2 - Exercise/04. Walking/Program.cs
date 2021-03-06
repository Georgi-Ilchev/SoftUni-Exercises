using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSteps = int.Parse(Console.ReadLine());
            int goalSteps = 10000;

            string input = Console.ReadLine();
            while (input != "Going home")
            {
                int steps = int.Parse(input);
                totalSteps += steps;
                if (totalSteps >= goalSteps)
                {
                    break;
                }
                
                input = Console.ReadLine();
            }
            if (totalSteps >= goalSteps)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{goalSteps - totalSteps} more steps to reach goal.");
            }


        }
    }
}
