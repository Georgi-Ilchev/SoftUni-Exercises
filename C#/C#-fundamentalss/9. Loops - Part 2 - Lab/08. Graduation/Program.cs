using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int level = 1;
            double grade = double.Parse(Console.ReadLine());
            double sumOfgrades = 0;

            while (grade <= 12)
            {
                if (grade >= 4.00)
                {
                    sumOfgrades += grade;
                    level++;
                    if (level == 13)
                    {
                        break;
                    }
                    grade = double.Parse(Console.ReadLine());

                }
                else
                {
                    grade = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine($"{name} graduated. Average grade: {sumOfgrades / 12:f2}");

        }
    }
}
