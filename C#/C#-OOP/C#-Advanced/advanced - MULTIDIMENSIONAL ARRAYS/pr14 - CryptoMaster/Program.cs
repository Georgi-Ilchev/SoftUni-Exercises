using System;
using System.Collections.Generic;
using System.Linq;

namespace pr14___CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            long seqLength = numbers.Count;
            long maxLength = 0;

            for (int step = 1; step < seqLength; step++)
            {
                for (int i = 0; i < seqLength; i++)
                {
                    int localMax = 1;
                    int currentElement = i;
                    int nextElement = (currentElement + step) % numbers.Count;

                    while (numbers[nextElement] > numbers[currentElement])
                    {
                        localMax++;

                        currentElement = nextElement;
                        nextElement = (currentElement + step) % numbers.Count;
                    }

                    if (maxLength < localMax)
                    {
                        maxLength = localMax;
                    }
                }
            }

            Console.WriteLine(maxLength);
        }
    }
}
