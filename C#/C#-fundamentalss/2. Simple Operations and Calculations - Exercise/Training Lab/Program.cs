using System;

namespace Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());          // дължина в метри
            double h = double.Parse(Console.ReadLine());          // широчина в метри




            int workplaceW = (int)( w / 1.2);
            int workplaceH = (int)((h - 1) / 0.70); 

            int result = (workplaceW * workplaceH) - 3;

            Console.WriteLine(result);

        }
    }
}
