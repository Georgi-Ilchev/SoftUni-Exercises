using System;


namespace Problem_1._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int counter = 0;

            while ((command = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(command);
                if (distance <= energy)
                {
                    energy -= distance;
                    counter++;
                    if (counter % 3 == 0)
                    {
                        energy += counter;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {counter} won battles and {energy} energy");
                    break;
                }

            }


            if (command == "End of battle")
            {
                Console.WriteLine($"Won battles: {counter}. Energy left: {energy}");
            }
            
        }



    }
}
