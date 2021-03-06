using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double minNumber = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                double entry = double.Parse(Console.ReadLine());
                if (entry < minNumber)
                {
                    minNumber = entry;
                }

            }
            Console.WriteLine(minNumber);
        }
    }
}
