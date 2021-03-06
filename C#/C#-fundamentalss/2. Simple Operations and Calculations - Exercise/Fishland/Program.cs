using System;

namespace Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double skumriyaPrice = double.Parse(Console.ReadLine());
            double tsatsaPrice = double.Parse(Console.ReadLine());
            double palamudPrice = double.Parse(Console.ReadLine());
            double safridPrice = double.Parse(Console.ReadLine());
            int midiPrice = int.Parse(Console.ReadLine());

            double palamudPrice1 = skumriyaPrice + (0.60 * skumriyaPrice);
            double palamudSum = palamudPrice * palamudPrice1;
            double safridPrice1 = tsatsaPrice + (0.80 * tsatsaPrice);
            double safridSum = safridPrice * safridPrice1;
            double midiPricekg = midiPrice * 7.50;

            
            
            
            double all = palamudSum + safridSum + midiPricekg;

            Console.WriteLine($"{Math.Abs(all):f2}");

        }
    }
}
