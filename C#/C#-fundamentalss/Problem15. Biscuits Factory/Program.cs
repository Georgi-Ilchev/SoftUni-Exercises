using System;

namespace Problem15._Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsForDay = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int anotherFactBiscuits = int.Parse(Console.ReadLine());

            double biscuits = 0.0;
            double temp = biscuitsForDay;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    temp = biscuitsForDay * 0.75;
                    biscuits += Math.Floor(workers * temp);
                }
                else
                {
                    biscuits += workers * biscuitsForDay;
                }
            }

            Console.WriteLine($"You have produced {biscuits} biscuits for the past month.");

            double difference = 0.0;
            double percentage = 0.0;

            if (biscuits > anotherFactBiscuits)
            {
                difference = biscuits - anotherFactBiscuits;
                percentage = (difference / anotherFactBiscuits) * 100;
                Console.WriteLine($"You produce { percentage:f2} percent more biscuits.");
            }
            else if (biscuits < anotherFactBiscuits)
            {
                difference = anotherFactBiscuits - biscuits;
                percentage = (difference / anotherFactBiscuits) * 100;
                Console.WriteLine($"You produce { percentage:f2} percent less biscuits.");
            }
        }
    }
}
