using System;

namespace _10._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int apartmentVolume = w * l * h;
            int volume = 0;

            while (command != "Done")
            {
                int commandAsNumber = int.Parse(command);
                volume += commandAsNumber;
                command = Console.ReadLine();
                if (volume >= apartmentVolume)
                {
                    Console.WriteLine($"No more free space! You need {volume - apartmentVolume} Cubic meters more.");
                    return;
                }

            }
            Console.WriteLine($"{apartmentVolume - volume} Cubic meters left.");



        }
    }
}
