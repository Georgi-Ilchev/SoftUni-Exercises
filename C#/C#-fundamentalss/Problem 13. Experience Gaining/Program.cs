using System;

namespace Problem_13._Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battles = int.Parse(Console.ReadLine());
            int currentBattles = 0;

            double currentExp = 0.0;

            for (int i = 1; i <= battles; i++)
            {
                currentBattles++;
                double earnExp = double.Parse(Console.ReadLine());

                if (currentBattles % 3 == 0)
                {
                    earnExp += earnExp * 0.15;
                    currentExp += earnExp;
                }
                else if (currentBattles % 5 == 0)
                {
                    earnExp -= earnExp * 0.1;
                    currentExp += earnExp;
                }
                else
                {
                    currentExp += earnExp;
                }

                if (currentExp >= neededExperience)
                {
                    break;
                }

            }
            if (currentExp >= neededExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {currentBattles} battles.");
            }
            else
            {
                double sum = neededExperience - currentExp;
                Console.WriteLine($"Player was not able to collect the needed experience, {sum:f2} more needed.");
            }
        }
    }
}
