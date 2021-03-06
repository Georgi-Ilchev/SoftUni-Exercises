using System;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "BILLGATES";
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var currChar = input[i];
                sum += (int)currChar;
            }
            Console.WriteLine(sum);
        }
    }
}
