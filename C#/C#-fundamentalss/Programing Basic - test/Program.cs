using System;

namespace Programing_Basic___test
{
    class Program
    {
        static void Main(string[] args)
        {
            double averageSpeed = double.Parse(Console.ReadLine());
            double litres = double.Parse(Console.ReadLine());

            double moon = 384400;

            double goAndBack = (moon * 2) / averageSpeed;
            double allTime = (goAndBack) + 3;
            double neededGasoline = (litres * (moon * 2)) / 100;

            Console.WriteLine(Math.Ceiling(allTime));
            Console.WriteLine(neededGasoline);
        }
    }
}
