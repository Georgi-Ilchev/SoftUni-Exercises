using System;
using System.Linq;

namespace Threeuples
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{firstData[0]} {firstData[1]}";
            string addres = firstData[2];
            string town = string.Join(" ", firstData.Skip(3));

            Tuple<string, string, string> firstTuple = new Tuple<string, string, string>(fullName, addres, town);


            string[] secondData = Console.ReadLine().Split();
            string name = secondData[0];
            int littersBeer = int.Parse(secondData[1]);
            bool isDrunkOrNot = false;
            //bool isDrunkOrNot = secondData[2] == "drunk" ? true : false;
            if (secondData[2] == "drunk")
            {
                isDrunkOrNot = true;
            }
            else if (secondData[2] == "not")
            {
                isDrunkOrNot = false;
            }

            Tuple<string, int, bool> secondTuple = new Tuple<string, int, bool>(name, littersBeer, isDrunkOrNot);


            string[] thirdData = Console.ReadLine().Split();
            string namePerson = thirdData[0];
            double bankBalance = double.Parse(thirdData[1]);
            string bankName = thirdData[2];

            Tuple<string, double, string> thirdTuple = new Tuple<string, double, string>(namePerson, bankBalance, bankName);

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2} -> {firstTuple.Item3}");
            Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2} -> {secondTuple.Item3}");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2} -> {thirdTuple.Item3}");

           //Console.WriteLine(firstTuple);
           //Console.WriteLine(secondTuple);
           //Console.WriteLine(thirdTuple);
        }
    }
}
