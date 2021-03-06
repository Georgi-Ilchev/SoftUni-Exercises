using System;

namespace Weather_Forecast___Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            if (input >= 26.00 && input <= 35.00)
            {
                Console.WriteLine("Hot");
            }
            else if (input >= 20.1 && input <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (input >= 15.00 && input <= 20.00)
            {
                Console.WriteLine("Mild");
            }
            else if (input >= 12.00 && input <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (input >=5.00 && input <=11.9)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");   
            }
        }
    }
}
