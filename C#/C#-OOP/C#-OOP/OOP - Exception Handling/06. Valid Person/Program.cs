using System;

namespace _06._Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Person first = new Person("Pesho", "Peshev", 24);
                Person second = new Person("", "Goshev", 31);
                //Person third = new Person("Ivan", null, 63);
                //Person fourth = new Person("Stoyan", "Kolev", -1);
                //Person fifth = new Person("Iskren", "EIskren", 121);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine($"Exception thrown: {aor.Message}");
            }
        }
    }
}
