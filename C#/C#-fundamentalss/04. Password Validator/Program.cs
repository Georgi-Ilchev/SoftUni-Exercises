using System;
using System.Linq;
namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            PasswordValidator(password);
        }
        static void PasswordValidator(string password)
        {
            if (password.Count(Char.IsDigit) >= 2 
                && password.Length >= 6 
                && password.Length <=10 
                && password.All(Char.IsLetterOrDigit))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!(password.Length >= 6 && password.Length <= 10))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!(password.All(Char.IsLetterOrDigit)))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!(password.Count(Char.IsDigit) >= 2))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }
    }
}
