using System;

namespace _09._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sell = double.Parse(Console.ReadLine());

            double commission = 0;
                        
            if (town != "Sofia" &&
                town != "Varna" &&
                town != "Plovdiv")
            {
                Console.WriteLine("error");
            }
            else if (sell <0)
            {
                Console.WriteLine("error");
            }

            if (town == "Sofia")
            {
                if (0 < sell && sell <= 500)
                {
                    commission = 0.05;
                }
                else if (501 <= sell && sell <= 1000)
                {
                    commission = 0.07;
                }
                else if (1000 < sell && sell <= 10000)
                {
                    commission = 0.08;
                }
                else if (sell > 10000)
                {
                    commission = 0.12;
                }

            }
            else if (town == "Varna")
            {
                if (0 < sell && sell <= 500)
                {
                    commission = 0.045;
                }
                else if (500 < sell && sell <= 1000)
                {
                    commission = 0.075;
                }
                else if (1000 < sell && sell <= 10000)
                {
                    commission = 0.10;
                }
                else if (sell > 10000)
                {
                    commission = 0.13;
                }
            }
            else if (town == "Plovdiv")
            {
                if (0 < sell && sell <= 500)
                {
                    commission = 0.055;
                }
                else if (500 < sell && sell <= 1000)
                {
                    commission = 0.08;
                }
                else if (1000 < sell && sell <= 10000)
                {
                    commission = 0.12;
                }
                else if (sell > 10000)
                {
                    commission = 0.145;
                }

            }
            if (commission > 0)
            {
                Console.WriteLine($"{sell * commission:f2}");
            }
            
        }
    }
}
