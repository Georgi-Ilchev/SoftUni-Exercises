using System;
using System.Collections.Generic;
using System.Linq;

namespace testing
{
    class Program
    {
        class Solution
        {

            // Complete the compareTriplets function below.
            static int[] compareTriplets(List<int> a, List<int> b)
            {
                int[] list = new int[2];
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i] > b[i])
                    {
                        list[0] += 1;
                    }
                    else if (a[i] < b[i])
                    {
                        list[1] += 1;
                    }
                }
                return list;
            }

            static void Main(string[] args)
            {
                //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

                List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

                List<int> b = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bTemp => Convert.ToInt32(bTemp)).ToList();

                int[] result = compareTriplets(a, b);

                Console.WriteLine(String.Join(" ", result));

                //textWriter.Flush();
                //textWriter.Close();
            }
        }
    }
}
