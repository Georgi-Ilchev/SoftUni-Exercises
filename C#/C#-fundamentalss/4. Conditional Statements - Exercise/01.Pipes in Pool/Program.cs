using System;

namespace Pipes_In_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine()); // обем на басейна в литри
            int R1 = int.Parse(Console.ReadLine()); // дебит на първа тръба 
            int R2 = int.Parse(Console.ReadLine()); // дебит на втора тръба 
            double hours = double.Parse(Console.ReadLine()); // часове, които работникът отсъства

            double R1flow = R1 * hours;
            double R2flow = R2 * hours;
            double water = R1flow + R2flow;
            double percentR1 = Math.Abs(R1flow / water * 100);
            double percentR2 = Math.Abs(R2flow / water * 100);
            double percentWater = Math.Abs(water / v * 100);


            if (water <= v)
            {

                Console.WriteLine($"The pool is {percentWater:f2}% full. Pipe 1: {percentR1:f2}%. Pipe 2: {percentR2:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {(R1flow + R2flow) - v:f2} liters.");
            }
        }
    }
}
