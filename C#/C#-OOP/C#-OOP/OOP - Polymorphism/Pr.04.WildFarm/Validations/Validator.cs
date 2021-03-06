using System;

namespace Pr._04.WildFarm.Validations
{
    public class Validator
    {
        public static void GetValidation(string type, string foodType)
        {
            Console.WriteLine($"{type} does not eat {foodType}!");
        }
    }
}
