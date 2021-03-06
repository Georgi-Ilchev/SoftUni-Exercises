using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> goals = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = string.Empty;
            int counter = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                int index = int.Parse(command);
                if (index < goals.Count)
                {
                    if (goals[index] != -1)
                    {
                        int temp = goals[index];
                        goals[index] = -1;
                        counter++;

                        for (int i = 0; i < goals.Count; i++)
                        {
                            if (goals[i] >temp)
                            {
                                if (goals[i] != -1)
                                {
                                    goals[i] -= temp;
                                }
                            }
                            else
                            {
                                if (goals[i] != -1)
                                {
                                    goals[i] += temp;
                                }
                            }
                        }
                        
                    }
                    else
                    {

                    }
                }
                else
                {

                }

            }
            Console.WriteLine($"Shot targets: {counter} -> {string.Join(" ", goals)}");
        }
    }
}
