using System;

namespace Simple_Operations_and_Calculations___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double bgn = usd * 1.79549;

            Console.WriteLine("hi");
            Console.WriteLine($"{bgn:F2}");
        }
    }
}
