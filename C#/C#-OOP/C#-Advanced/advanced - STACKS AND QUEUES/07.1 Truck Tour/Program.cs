using System;
using System.Linq;

namespace _07._1_Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStations = int.Parse(Console.ReadLine());
            long[] numDiff = new long[numStations];

            for (int i = 0; i < numStations; i++)
            {
                long[] stationData = Console.ReadLine().Split().Select(long.Parse).ToArray();
                numDiff[i] = stationData[0] - stationData[1];
            }

            int startIndex = 0;
            long sumDiff = 0;

            for (int i = 0; i < numStations; i++)
            {
                bool flag = true;
                for (int k = 0; k < numStations; k++)
                {
                    int tempIndex = (i + k) % numStations;
                    sumDiff += numDiff[tempIndex];
                    if (sumDiff < 0)
                    {
                        flag = false;
                        sumDiff = 0;
                        break;
                    }
                }

                if (flag)
                {
                    startIndex = i;
                    break;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}
