using System;

namespace Examples2
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            var volume = length * width * height / 1000; 

            var loses = percentage * volume / 100;

            var liters = volume - loses;


            Console.WriteLine($"{liters:f3}");
        
        }
    }
}
