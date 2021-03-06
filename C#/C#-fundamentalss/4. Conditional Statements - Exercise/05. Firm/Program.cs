using System;

namespace _05._Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoursNeeded = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double dayTraining = 0.0;
            double workHours = 0.0;
            double overtime = 0.0;
            double all = 0.0;
            double sumLeft = 0.0;

            dayTraining  = days * 0.9;
            workHours = dayTraining * 8;
            overtime = workers * (2 * days);
            all = workHours + overtime;
            sumLeft = Math.Abs(hoursNeeded - all);

            if (all >= hoursNeeded)
            {
                Console.WriteLine($"Yes!{Math.Round(sumLeft)} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Ceiling(sumLeft)} hours needed.");
            }
            


            
        }
    }
}
