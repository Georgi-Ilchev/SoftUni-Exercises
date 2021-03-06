using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var listAttackedPlanets = new List<string>();
            var listDestroyedPlanets = new List<string>();

            int counterA = 0;
            int counterD = 0;

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"[sStTaArR]";
                var matches = Regex.Matches(input, pattern);
                int count = int.Parse(matches.Count.ToString());
                string decryptedMessage = string.Empty;

                foreach (var character in input)
                {
                    decryptedMessage += (char)(character - count);
                }
                //string pattern1 = @"^[^@\-!:>]*@(?<planetName>[a-zA-Z]+)[^@\-!:>]*:[^@\-!:>]*?(?<populationCount>\d+)[^@\-!:>]*![^@\-!:>]*(?<attackType>[AD])![^@\-!:>]*->(?<soldierCount>\d+)[^@\-!:>]*$";
                string pattern1 = @"@(?<Planet>[A-za-z]+)\d*[^@\-!:>]*:(?<Population>\d+)[^@\-!:>]*!(?<Action>[AD])![^@\-!:>]*->(?<Soldier>\d+)";
                var matchMessage = Regex.Match(decryptedMessage, pattern1);

                if (matchMessage.Success)
                {
                    if (matchMessage.Groups["Action"].Value == "A")
                    {
                        counterA++;
                        string attackedPlanets = $"-> {matchMessage.Groups["Planet"].Value}";
                        listAttackedPlanets.Add(attackedPlanets);
                    }
                    else
                    {
                        counterD++;
                        string destroyedPlanets = $"-> {matchMessage.Groups["Planet"].Value}";
                        listDestroyedPlanets.Add(destroyedPlanets);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {counterA}");

            if (counterA != 0)
            {
                Console.WriteLine(string.Join("\n", listAttackedPlanets.OrderBy(x => x)));
            }
            Console.WriteLine($"Destroyed planets: {counterD}");
            Console.WriteLine(string.Join("\n", listDestroyedPlanets.OrderBy(x => x)));

        }
    }
}
