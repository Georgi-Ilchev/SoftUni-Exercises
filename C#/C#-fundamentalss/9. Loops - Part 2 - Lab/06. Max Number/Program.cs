using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double maxNumber = int.MinValue;
            
            for (int i = 0; i < n; i++)
            {
                double entry = double.Parse(Console.ReadLine());
                if (entry > maxNumber )
                {
                    maxNumber = entry;
                }

            }
                    Console.WriteLine(maxNumber);
        }
    }
}
