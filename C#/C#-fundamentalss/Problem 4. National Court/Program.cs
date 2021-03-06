using System;

namespace Problem_4._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            int hour = 0;
            int allPeople = 0;

            for (int i = 0; i < people; i++)
            {

                if (people <= 0)
                {
                    break;
                }
                else
                {
                    allPeople = employee1 + employee2 + employee3;
                    people -= allPeople;
                    hour++;
                }
            }
            Console.WriteLine(hour);
            
        }
    }
}
