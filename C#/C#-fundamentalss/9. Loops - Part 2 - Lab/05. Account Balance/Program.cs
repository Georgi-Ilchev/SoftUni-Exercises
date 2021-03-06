using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            double bill = 0.0;

            for (int i = 0; i < n; i++)
            {
                double money = double.Parse(Console.ReadLine());
                if (money > 0)
                {
                    bill += money;
                    Console.WriteLine($"Increase: {money:f2}");
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
            }

            Console.WriteLine($"Total: {bill:f2}");



















            //while (counter <= n)
            //{
            //    double money = double.Parse(Console.ReadLine());
            //    ++counter;
            //    if (money<0)
            //    {
            //        Console.WriteLine("Invalid operation!");
            //        break;
            //    }
            //    else if (money>=0)
            //    {
            //        Console.WriteLine($"Increase: {money}");
            //        bill += money;
            //    }
            //}
            //Console.WriteLine($"Total: {bill:f2}");
        }
    }
}
