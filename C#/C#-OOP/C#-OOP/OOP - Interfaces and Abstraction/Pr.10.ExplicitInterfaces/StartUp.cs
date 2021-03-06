using Pr._10.ExplicitInterfaces.Interfaces;
using Pr._10.ExplicitInterfaces.Models;
using System;

namespace Pr._10.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // PrintNamesAsDifferentInterfaces(); // Both variants work
            PrintNamesWithTypeCasting(); // Both variants work
        }
        private static void PrintNamesWithTypeCasting()
        {
            var name = Console.ReadLine().Split();

            while (name[0] != "End")
            {
                Citizen human = new Citizen(name[0]);
                Console.WriteLine(((IPerson)human).GetName());
                Console.WriteLine(((IResident)human).GetName());

                name = Console.ReadLine().Split();
            }
        }

        private static void PrintNamesAsDifferentInterfaces()
        {
            var name = Console.ReadLine().Split();

            while (name[0] != "End")
            {
                IPerson person = new Citizen(name[0]);
                Console.WriteLine(person.GetName());

                IResident resident = new Citizen(name[0]);
                Console.WriteLine(resident.GetName());

                name = Console.ReadLine().Split();
            }
        }
    }
}
