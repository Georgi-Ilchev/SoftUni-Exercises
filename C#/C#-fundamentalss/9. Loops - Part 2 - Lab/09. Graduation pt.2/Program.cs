using System;

namespace _09._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int level = 0;
            int badGrad = 0;
            double allGrades = 0.0;
            int countGrades = 0;

            while (true)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4.00)
                {
                    badGrad++;
                }
                                                                
                if (badGrad == 2)
                {
                    break;
                }

                level++;
                allGrades += grade;
                countGrades++;

                if (level == 12)
                {
                    break;
                }



            }

            var averageGrad = allGrades / countGrades;
            if (level == 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrad:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {level} grade");
            }
        }
    }
}
