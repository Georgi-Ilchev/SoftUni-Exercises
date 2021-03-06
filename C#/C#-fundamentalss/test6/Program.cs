using System;

namespace test6
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int firstNum = 0;
            int secondNum = 0;
            int thirdNum = 0;
            for (int i = 0; i < 3; i++)
            {
                if (i==0)
                {
                    firstNum = number %10;
                    number /= 10;
                }
                else if (i==1)
                {
                    secondNum = number % 10;
                    number /= 10;
                }
                else if (i==2)
                {
                    thirdNum = number;
                }
            }

            for (int first = 1; first <= firstNum; first++)
            {
                for (int second = 1; second <= secondNum; second++)
                {
                    for (int third = 1; third <= thirdNum; third++)
                    {
                        int sum = first * second * third;
                        Console.WriteLine($"{first} * {second} * {third} = {sum};");
                    }
                }
            }
        }
    }
}
