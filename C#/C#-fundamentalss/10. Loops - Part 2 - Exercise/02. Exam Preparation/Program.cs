using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int limitGrades = int.Parse(Console.ReadLine());

            int gradeSum = 0;
            int gradeCount = 0;
            int badGrade = 0;
            string problemName = Console.ReadLine();
            string lastProblemName = "";

            while (problemName != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                gradeSum += grade;
                gradeCount++;

                if (grade <= 4)
                {
                    badGrade++;
                }

                if (badGrade == limitGrades)
                {
                    break;
                }

                lastProblemName = problemName;
                problemName = Console.ReadLine();
            }
            if (badGrade == limitGrades)
            {
                Console.WriteLine($"You need a break, {badGrade} poor grades.");
            }
            else
            {
                double averageGrade = gradeSum * 1.0 / gradeCount;
                Console.WriteLine($"Average score: {averageGrade:f2}");
                Console.WriteLine($"Number of problems: {gradeCount}");
                Console.WriteLine($"Last problem: {lastProblemName}");

            }

        }
    }
}
