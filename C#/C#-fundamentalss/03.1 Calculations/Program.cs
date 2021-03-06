using System;

namespace _03._1_Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine(Sum(input, num1, num2));
        }
        static int Sum(string input, int num1, int num2)
        {
            int result = 0;
            if (input == "add")
            {
                result = num1 + num2;
            }
            else if (input == "subtract")
            {
                result = num1 - num2;
            }
            else if (input == "multiply")
            {
                result = num1 * num2;
            }
            else if (input == "divide")
            {
                result = num1 / num2;
            }
            return result;
        }
    }
}
