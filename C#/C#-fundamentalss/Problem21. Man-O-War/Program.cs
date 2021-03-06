using System;
using System.Linq;

namespace Problem21._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
            int[] warShip = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
            int maximumHealth = int.Parse(Console.ReadLine());

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] command = input.Split(" ").ToArray();

                if (command[0] == "Fire")
                {
                    int index = int.Parse(command[1]);
                    int damage = int.Parse(command[2]);
                    if (index >= 0 && index < warShip.Length)
                    {
                        warShip[index] -= damage;
                        if (warShip[index]<=0)
                        {
                            Console.WriteLine($"You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (command[0] == "Defend")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    int damage = int.Parse(command[3]);

                    if (startIndex >= 0 && startIndex < pirateShip.Length)
                    {
                        if (endIndex >= 0 && endIndex < pirateShip.Length)
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShip[i] -= damage;
                                if (pirateShip[i]<=0)
                                {
                                    Console.WriteLine($"You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                    }
                }
                else if (command[0] == "Repair")
                {
                    int index = int.Parse(command[1]);
                    int health = int.Parse(command[2]);

                    if (index >= 0 && index < pirateShip.Length)
                    {
                        pirateShip[index] += health;
                        if (pirateShip[index]> maximumHealth)
                        {
                            pirateShip[index] = maximumHealth;
                        }
                        
                    }
                }
                else if (command[0] == "Status")
                {
                    int counter = 0;

                    for (int i = 0; i < pirateShip.Length; i++)
                    {
                        if (pirateShip[i] < maximumHealth*0.2)
                        {
                            counter++;
                        }
                    }
                    Console.WriteLine($"{counter} sections need repair.");
                }
            }
            int pirateShipSum = pirateShip.Sum();
            int warShipSum = warShip.Sum();

            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warShipSum}");
        }
    }
}
