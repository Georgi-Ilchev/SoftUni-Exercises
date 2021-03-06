using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            double score = 0;
            int counter = 0;

            while (true)
            {
                string name = Console.ReadLine();
                double sumOfGrades = 0;

                if (name == "Finish")
                {
                    double scoreSum = score / counter;
                    Console.WriteLine($"Student's final assessment is {scoreSum:f2}.");
                    break;
                }
                for (int i = 0; i < num; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumOfGrades += grade;
                    score += grade;
                    counter++;
                }
                double sumAfter = sumOfGrades / num;
                Console.WriteLine($"{name} - {sumAfter:f2}.");
            }
        }
    }
}
