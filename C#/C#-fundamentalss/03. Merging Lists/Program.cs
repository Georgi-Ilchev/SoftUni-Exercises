using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static List<int> ReadIntListSingleLine()
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            return list;
        }
        static void Main(string[] args)
        {
            var firstList = ReadIntListSingleLine();
            var secondList = ReadIntListSingleLine();
            Console.WriteLine(String.Join(" ", MergeList(firstList, secondList)));
        }
        static List<int> MergeList(List<int> first, List<int> second)
        {
            int count = Math.Max(first.Count, second.Count);
            List<int> merged = new List<int>();
            for (int i = 0; i < count; i++)
            {
                if (first.Count > i)
                {
                    merged.Add(first[i]);
                }
                if (second.Count > i)
                {
                    merged.Add(second[i]);
                }
            }
            return merged;
        }
    }
}
