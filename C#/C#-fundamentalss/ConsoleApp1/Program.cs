using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());

            int hours = 0;
            int allPeople = 0;

            allPeople = employee1 + employee2 + employee3;
            while (people > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }

                people -= allPeople;
                

            }
            Console.WriteLine($"Time needed: {hours}h.");
        }




    }
}
