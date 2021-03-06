using _07._Custom_Exception.Exceptions;
using System;

namespace _07._Custom_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Gin4o", "Petrov", 21, "gim40@abv.bg");
            }
            catch(ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine($"Exception thrown: {aor.Message}");
            }
            catch(InvalidPersonNameException ipn)
            {
                Console.WriteLine(ipn.Message);
            }
        }
    }
}
