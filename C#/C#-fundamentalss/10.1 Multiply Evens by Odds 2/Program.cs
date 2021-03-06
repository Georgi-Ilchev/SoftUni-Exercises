using System;

namespace _10._1_Multiply_Evens_by_Odds_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n = Math.Abs(n);
            Console.WriteLine(GetMultipleOfEvenAndOdds(n));
        }
        static int GetMultipleOfEvenAndOdds(int n)
        {
            return GetSumOfEvenDigits(n) * GetSumOfOddDigits(n);
        }

        static int GetSumOfEvenDigits(int n)
        {
            string number = n.ToString();
            int isEven = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                if (currentDigit % 2 == 0)
                {
                    isEven  += currentDigit;
                }
            }
            return isEven;
        }
        static int GetSumOfOddDigits(int n)
        {
            string number = n.ToString();
            int isOdd = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                if (currentDigit % 2 == 1)
                {
                    isOdd += currentDigit;
                }
            }
            return isOdd;
        }
    }
}
