using System;

namespace _05._ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number!");
            string input = Console.ReadLine();

            try
            {
                double result = Convert.ToDouble(input);
                Console.WriteLine(result);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }
}
