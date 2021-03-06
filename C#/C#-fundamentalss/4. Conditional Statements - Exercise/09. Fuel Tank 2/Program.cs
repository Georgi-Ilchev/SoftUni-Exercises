using System;

namespace _09._Fuel_Tank_2
{
    class Program
    {
        private const double gasoline = 2.22;
        private const double diesel = 2.33;
        private const double gas = 0.93;
        private const double cardGasoline = gasoline - 0.18;
        private const double cardDiesel = diesel - 0.12;
        private const double cardGas = gas - 0.08;
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();

            double gasPrice = 0.0;
            double gasolinePrice = 0.0;
            double dieselPrice = 0.0;

            if (fuel == "Gas")
            {
                if (clubCard == "Yes")
                {
                    if (liters <20)
                    {
                        gasPrice = liters * cardGas;
                    }
                    else if (liters >=20 && liters <=25)
                    {
                        gasPrice = liters * cardGas * 0.92;
                    }
                    else if (liters >25)
                    {
                        gasPrice = liters * cardGas * 0.90;
                    }
                    Console.WriteLine($"{gasPrice:f2} lv.");
                }
                else if (clubCard == "No")
                {
                    if (liters <20)
                    {
                        gasPrice = liters * gas;
                    }
                    else if (liters >= 20 && liters <= 25)
                    {
                        gasPrice = liters * gas * 0.92;
                    }
                    else if (liters >25)
                    {
                        gasPrice = liters * gas * 0.90;
                    }
                    Console.WriteLine($"{gasPrice:f2} lv.");
                }
            }
            else if (fuel == "Gasoline")
            {
                if (clubCard == "Yes")
                {
                    if (liters <20)
                    {
                        gasolinePrice = liters * cardGasoline;
                    }
                    else if (liters >= 20 && liters <= 25)
                    {
                        gasolinePrice = liters * cardGasoline * 0.92;
                    }
                    else if (liters >25)
                    {
                        gasolinePrice = liters * cardGasoline * 0.90;
                    }
                    Console.WriteLine($"{gasolinePrice:f2} lv.");

                }
                else if (clubCard == "No")
                {
                    if (liters <20)
                    {
                        gasolinePrice = liters * gasoline;
                    }
                    else if (liters >= 20 && liters <= 25)
                    {
                        gasolinePrice = liters * gasoline * 0.92;
                    }
                    else if (liters >25)
                    {
                        gasolinePrice = liters * gasoline * 0.90;
                    }
                    Console.WriteLine($"{gasolinePrice:f2} lv.");
                }
            }
            else if (fuel == "Diesel")
            {
                if (clubCard == "Yes")
                {
                    if (liters < 20)
                    {
                        dieselPrice = liters * cardDiesel;
                    }
                    else if (liters >= 20 && liters <= 25)
                    {
                        dieselPrice = liters * cardDiesel * 0.92;
                    }
                    else if (liters > 25)
                    {
                        dieselPrice = liters * cardDiesel * 0.90;
                    }
                    Console.WriteLine($"{dieselPrice:f2} lv.");
                }
                else if (clubCard == "No")
                {
                    if (liters < 20)
                    {
                        dieselPrice = liters * diesel;
                    }
                    else if (liters >= 20 && liters <= 25)
                    {
                        dieselPrice = liters * diesel * 0.92;
                    }
                    else if (liters > 25)
                    {
                        dieselPrice = liters * diesel * 0.90;
                    }
                    Console.WriteLine($"{dieselPrice:f2} lv.");

                }
            }
        }
    }
}
