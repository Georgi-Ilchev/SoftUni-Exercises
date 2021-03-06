using System;

namespace _16._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            //int sum = num1 * num2 * num3;
            //if (sum==0)
            //{
            //    Console.WriteLine("zero");
            //}
            //else if (sum>0)
            //{
            //    Console.WriteLine("positive");
            //}
            //else
            //{
            //    Console.WriteLine("negative");
            //}
            Console.WriteLine(PositiveOrNegativeOrZero(num1, num2, num3));
        }
        static string PositiveOrNegativeOrZero(int num1, int num2, int num3)

        {
            string input = string.Empty;
            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                input += "zero";
            }
            else if (num1 > 0 && num2 > 0 && num3 > 0
                || (num1 < 0 && num2 < 0 && num3 > 0)
                || (num1 < 0 && num2 > 0 && num3 < 0)
                || (num1 > 0 && num2 < 0 && num3 < 0))
            {
                input += "positive";
            }
            else
            {
                input += "negative";
            }

            return input;

        }
    }
}
