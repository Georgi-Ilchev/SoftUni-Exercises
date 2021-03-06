using System;

namespace Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            double tempValueCm = 0;

            if (input == "mm")
            {
                tempValueCm = number / 10;
            }
            else if (input == "m")
            {
                tempValueCm = number * 100;
            }
            else if (input == "cm")
            {
                tempValueCm = number;
            }

            double resultValue = 0;
            if (output == "mm")
            {
                resultValue = tempValueCm * 10;
            }
            else if (output == "m")
            {
                resultValue = tempValueCm / 100;
            }
            else if (output == "cm")
            {
                resultValue = tempValueCm;
            }
            Console.WriteLine($"{resultValue:f3}");
            
            
        }
    }
}
