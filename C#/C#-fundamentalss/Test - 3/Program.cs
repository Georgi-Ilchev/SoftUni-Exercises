using System;
using System.Collections.Generic;
using System.Linq;

namespace Test___3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> goals = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> topNumbers = new List<int>();
            var large = new int[5];

            int all = 0;
            int average = 0;
            int count = 0;

            int max = 0;
            int index = 0;

            for (int i = 0; i < goals.Count; i++)
            {
                all += goals[i];
                
            }
            average = all / goals.Count;

            for (int i = 0; i < goals.Count; i++)
            {
                if (goals[i] > average)
                {
                    count++;
                    topNumbers.Add(goals[i]);
                   
                }
            }

            if (count > 0 && count < 5)
            {
                topNumbers.Reverse();
                Console.WriteLine(string.Join(" ",topNumbers));
            }
            else if (count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int j = 0; j < 5; j++)
                {
                    max = topNumbers[0];
                    index = 0;
                    for (int i = 1; i < topNumbers.Count; i++)
                    {
                        if (max < topNumbers[i])
                        {
                            max = topNumbers[i];
                            index = i;
                        }
                    }
                    large[j] = max;
                    topNumbers[index] = int.MinValue;
                    Console.Write(large[j] + " ");
                }
            }
            
            
            
            
        }
    }
}
