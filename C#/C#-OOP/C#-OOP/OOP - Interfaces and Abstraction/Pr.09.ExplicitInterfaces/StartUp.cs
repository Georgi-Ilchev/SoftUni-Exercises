using System;

namespace Pr._09.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] splitted = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = splitted[0];
                string country = splitted[1];
                int age = int.Parse(splitted[2]);

                IPerson person1 = new Citizen(name,country,age);
                IResident person2 = new Citizen(name,country,age);

                person1.GetName();
                person2.GetName();
                input = Console.ReadLine();
            }
        }
    }
}
