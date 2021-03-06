using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double longh = double.Parse(Console.ReadLine());
            double high = double.Parse(Console.ReadLine());
            double highAstronaught = double.Parse(Console.ReadLine());

            double rocket = width * longh * high;
            double rocketRoom = (highAstronaught + 0.40) * 2 * 2;

            double placeNumber = rocket / rocketRoom;

            if (placeNumber >=3 && placeNumber <=10)
            {
                Console.WriteLine($"The spacecraft holds {Math.Floor(placeNumber)} astronauts.");
            }
            else if (placeNumber <3)
            {
                Console.WriteLine($"The spacecraft is too small.");
            }
            else if (placeNumber >10)
            {
                Console.WriteLine($"The spacecraft is too big.");
            }

            
        }
    }
}
