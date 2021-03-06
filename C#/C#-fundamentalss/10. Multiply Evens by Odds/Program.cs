using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n = Math.Abs(n);
            Console.WriteLine(MultiplyEvenAndOddDigits(n));
        }
        static int MultiplyEvenAndOddDigits(int n)
        {
            return CalculateDigitsSum(n, 0) * CalculateDigitsSum(n, 1);
        }
        static int CalculateDigitsSum(int n, int isOdd)
        {
            string number = n.ToString();
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                if (currentDigit % 2 == isOdd)
                {
                    sum += currentDigit;
                }
            }
            return sum;
        }

    }
}
