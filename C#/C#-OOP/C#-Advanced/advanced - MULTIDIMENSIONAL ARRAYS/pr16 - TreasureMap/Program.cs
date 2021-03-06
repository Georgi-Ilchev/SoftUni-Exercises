using System;
using System.Text.RegularExpressions;

namespace pr16___TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(!|#)[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*(?<!\d)(?<number>\d{3})-(?<password>\d{6}|\d{4})(?!\d)[^!#]*?(?!\1)(#|!)";

            string pattern1 = @"(!|#)[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*(?<!\d)(?<number>\d{3})-(?<password>\d{6}|d{4})(?!\d)[^!#]*?(?!\1)(#|!)";
            Regex regex = new Regex(pattern);
        }
    }
}
