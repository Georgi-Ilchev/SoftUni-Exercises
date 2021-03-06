using System;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double wight = double.Parse(Console.ReadLine());

            double area = tables * (lenght + 2 * 0.30) * (wight + 2 * 0.30);
            double coach = tables * (lenght / 2) * (lenght / 2);
            double USD = area * 7 + coach * 9;
            double BGN = USD * 1.85;

            Console.WriteLine($"{USD:f2} USD");
            Console.WriteLine($"{BGN:f2} BGN");


            

        }
    }
}
