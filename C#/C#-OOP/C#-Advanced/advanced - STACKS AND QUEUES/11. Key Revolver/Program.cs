using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            List<int> bullets = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> locks = Console.ReadLine().Split().Select(int.Parse).ToList();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);

            int shootedBulletsCount = 0;
            int totalShootedBulletsCount = 0;

            while (true)
            {
                int currentBullet = bulletsStack.Peek();
                int currentLock = locksQueue.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                shootedBulletsCount++;
                totalShootedBulletsCount++;
                bulletsStack.Pop();

                if (shootedBulletsCount == gunBarrelSize && bulletsStack.Any())
                {
                    Console.WriteLine("Reloading!");
                    shootedBulletsCount = 0;
                }

                if (!bulletsStack.Any() && locksQueue.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count()}");
                    break;
                }

                if (!locksQueue.Any())
                {
                    int moneyEarned = intelligenceValue - (totalShootedBulletsCount * bulletPrice);
                    Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
                    break;
                }
            }
        }
    }
}
