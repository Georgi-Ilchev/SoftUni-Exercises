using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            SumOfProducts(product, n);
        }
        static void SumOfProducts(string type, int n)
        {
            double result = 0.0;
            switch (type)
            {
                case "coffee":
                    result = n * 1.50; break;
                case "water":
                    result = n * 1.00; break;
                case "coke":
                    result = n * 1.40; break;
                case "snacks":
                    result = n * 2.00; break;
                default: break;
            }
            Console.WriteLine($"{result:f2}");
        }

    }
}
