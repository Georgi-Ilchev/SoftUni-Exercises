using System;

namespace Problem_7._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            double students = double.Parse(Console.ReadLine());
            double lecturesCount = double.Parse(Console.ReadLine());
            double courseBonus = double.Parse(Console.ReadLine());

            double studentWithMaxBonus = 0;
            double maxAtt = 0;

            if (students == 0 || lecturesCount ==0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }
            for (int i = 0; i < students; i++)
            {
                int attendance = int.Parse(Console.ReadLine());
                double temp = Math.Ceiling(attendance / lecturesCount * (5 + courseBonus));

                if (temp > studentWithMaxBonus)
                {
                    studentWithMaxBonus = (int)temp;
                    maxAtt = attendance;
                }
            }
            Console.WriteLine($"Max Bonus: {studentWithMaxBonus}.");
            Console.WriteLine($"The student has attended {maxAtt} lectures.");

        }
    }
}
