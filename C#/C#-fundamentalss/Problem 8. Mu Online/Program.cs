using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Mu_Online
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            int health = 100;
            int bitcoins = 0;

            int currentHealth = 0;
            int tempHealth = 0;
            bool isAlive = true;

            for (int i = 0; i < rooms.Length; i++)
            {
                int currentBitcoins = 0;
                string command = rooms[i];
                string[] splitted = command.Split();

                if (splitted[0] == "potion")
                {
                    currentHealth = health;
                    tempHealth = health;
                    currentHealth += int.Parse(splitted[1]);

                    if (currentHealth<=100)
                    {
                        health += int.Parse(splitted[1]);
                        Console.WriteLine($"You healed for {splitted[1]} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if( currentHealth>100)
                    {
                        int diff = 100 - tempHealth;
                        health = 100;
                        Console.WriteLine($"You healed for {diff} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    
                }
                else if (splitted[0] == "chest")
                {
                    bitcoins += int.Parse(splitted[1]);
                    currentBitcoins += int.Parse(splitted[1]);
                    Console.WriteLine($"You found {currentBitcoins} bitcoins.");
                }
                else
                {
                    int attack = int.Parse(splitted[1]);
                    health -= attack;

                    if (health<=0)
                    {
                        Console.WriteLine($"You died! Killed by {splitted[0]}.");
                        Console.WriteLine($"Best room: {i+1}");
                        isAlive = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {splitted[0]}.");
                    }
                        
                }
            }
            if (isAlive)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
            
        }
    }
}
