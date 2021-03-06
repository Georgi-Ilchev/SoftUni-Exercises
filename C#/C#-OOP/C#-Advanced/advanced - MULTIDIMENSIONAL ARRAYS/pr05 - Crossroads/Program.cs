using System;
using System.Collections.Generic;
using System.Linq;

namespace pr05___Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            Queue<string> carQueue = new Queue<string>();
            int counter = 0;

            while (true)
            {
                string car = Console.ReadLine();

                int greenLigth = greenLightSeconds;
                int passSeconds = freeWindowSeconds;

                if (car == "END")
                {
                    Console.WriteLine($"Everyone is safe.{Environment.NewLine}" +
                        $"{counter} total cars passed the crossroads.");
                    return;
                }

                if (car == "green")
                {
                    while (greenLigth > 0 && carQueue.Count != 0)
                    {
                        string firstInQueue = carQueue.Dequeue();
                        greenLigth -= firstInQueue.Count();

                        if (greenLigth >= 0)
                        {
                            counter++;
                        }
                        else
                        {
                            passSeconds += greenLigth;
                            if (passSeconds < 0)
                            {
                                Console.WriteLine($"A crash happened!{Environment.NewLine}" +
                                    $"{firstInQueue} was hit at" +
                                    $" {firstInQueue[firstInQueue.Length + passSeconds]}.");
                                return;
                            }
                            counter++;
                        }
                    }
                }
                else
                {
                    carQueue.Enqueue(car);
                }
            }
        }
    }
}
