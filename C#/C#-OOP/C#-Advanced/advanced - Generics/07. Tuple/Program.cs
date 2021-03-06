using System;
using System.Linq;

namespace _07._Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstTokens = Console.ReadLine().Split();
            string personName = $"{firstTokens[0]} {firstTokens[1]}";
            string personAdress = firstTokens[2];

            Tuple<string, string> personInfo = new Tuple<string, string>(personName, personAdress);


            string[] secondTokens = Console.ReadLine().Split();
            string personFullName = secondTokens[0];
            int beerLiters = int.Parse(secondTokens[1]);

            Tuple<string, int> personBeerInfo = new Tuple<string, int>(personFullName, beerLiters);


            string[] thirdTokes = Console.ReadLine().Split();
            int intValue = int.Parse(thirdTokes[0]);
            double doubleValue = double.Parse(thirdTokes[1]);

           Tuple<int, double> numbersInfo = new Tuple<int, double>(intValue, doubleValue);


            Console.WriteLine(personInfo.ToString());
            Console.WriteLine(personBeerInfo.ToString());
            Console.WriteLine(numbersInfo.ToString());
        }

    }
}
