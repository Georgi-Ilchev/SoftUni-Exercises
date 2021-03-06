using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < number; i++)
            {
                leftSum += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < number; i++)
            {
                rightSum += int.Parse(Console.ReadLine());
            }
            
            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = "+Math.Abs(rightSum - leftSum));
            }
        }
    }
}
