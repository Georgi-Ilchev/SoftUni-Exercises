using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20._Take___Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> message = Console.ReadLine().Split().ToList();
            List<string> nonNumberList = new List<string>();

            StringBuilder result = new StringBuilder();

            string input = message[0].ToString();

            SplitInput(nonNumberList, input);

            List<char> numberList = new List<char>();
            for (int i = 0; i < nonNumberList.Count; i++)
            {

                char isDigit = char.Parse(nonNumberList[i]);

                if (Char.IsDigit(isDigit))
                {
                    numberList.Add(isDigit);
                    nonNumberList.Remove(isDigit.ToString());
                    i--;
                }

            }

            Console.WriteLine(string.Join("", nonNumberList));
            Console.WriteLine(string.Join("", numberList));
            //List<string> collections = DigitEvenOrOdd(numberList);

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(int.Parse(numberList[i].);
                }
                else
                {
                    skipList.Add(numberList[i].ToString());
                }
            }
            Console.WriteLine(string.Join("",takeList));
            Console.WriteLine(string.Join("", skipList));

            string indexForSkip = string.Empty;

            for (int i = 0; i < takeList.Count; i++)
            {
                for (int j = 0; j < takeList[i]; j++)
                {
                    if (nonNumberList.Count == 0)
                    {
                        break;
                    }
                    result.Append(nonNumberList[0]);
                    nonNumberList.Remove(nonNumberList[0]);


                }
                if (nonNumberList.Count == 0)
                {
                    break;
                }
                for (int k = 0; k < skipList[i]; k++)
                {
                    if (nonNumberList.Count == 0)
                    {
                        break;
                    }
                    nonNumberList.Remove(nonNumberList[0]);
                }

            }


        }

        private static void SplitInput(List<string> c, string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                c.Add(input[i].ToString());
            }
        }
        //private static List<string> DigitEvenOrOdd(List<char> numberList)
        //{
        //    List<string> takeList = new List<string>();
        //    List<string> skipList = new List<string>();

        //    for (int i = 0; i < numberList.Count; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            takeList.Add(numberList[i].ToString());
        //        }
        //        else
        //        {
        //            skipList.Add(numberList[i].ToString());
        //        }
        //    }

        //    List<string> appendCollection = AppendCollectionsInOne(takeList, skipList);

        //    return appendCollection;
        //}
        private static List<string> AppendCollectionsInOne(List<string> takeList, List<string> skipList)
        {
            List<string> ls = new List<string>();

            string takeListToString = string.Empty;
            for (int i = 0; i < takeList.Count; i++)
            {
                takeListToString += takeList[i] + ",";
            }

            string skipListToString = string.Empty;
            for (int i = 0; i < skipList.Count; i++)
            {
                skipListToString += skipList[i] + ",";
            }

            ls.Add(takeListToString);
            ls.Add(skipListToString);

            return ls;
        }
    }
}
