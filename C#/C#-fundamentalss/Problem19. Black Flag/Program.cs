using System;

namespace Problem19._Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double dailyPlunder = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double allPlunder = 0.0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0)
                {
                    allPlunder += dailyPlunder * 1.5;
                }
                else
                {
                    allPlunder += dailyPlunder;
                }

                if (i % 5 == 0)
                {
                    
                    allPlunder *= 0.7;
                }
                
            }

            double percentage = 0.0;

            if (allPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {allPlunder:f2} plunder gained.");
            }
            else
            {
                percentage = (allPlunder / expectedPlunder) * 100.00;
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}
