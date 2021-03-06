using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _5._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var demonsHealth = new SortedDictionary<string, int>();
            var demonsDamage = new SortedDictionary<string, double>();

            var pattern = @"-?\d+\.?\d*";
            Regex regex = new Regex(pattern);

            foreach (var demon in demons)
            {
                var health = demon
                    .Where(s => !char.IsDigit(s)
                    && s != '+' && s != '-' && s != '*' && s != '/' && s != '.')
                    .Sum(s => (int)s);

                demonsHealth[demon] = health;

                MatchCollection matches = regex.Matches(demon);

                double damage = 0.0;

                foreach (Match match in matches)
                {
                    string value = match.Value;
                    damage += double.Parse(value);
                }

                foreach (var symbol in demon)
                {
                    if (symbol == '*')
                    {
                        damage *= 2;
                    }
                    else if (symbol == '/')
                    {
                        damage /= 2;
                    }
                }
                demonsDamage[demon] = damage;
            }

            foreach (var demon in demonsDamage)
            {
                var demonName = demon.Key;
                var demonHealth = demonsHealth[demonName];
                var demonDamage = demon.Value;

                Console.WriteLine($"{demonName} - {demonHealth} health, {demonDamage:F2} damage");
            }
        }
    }
}
