using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Pr._05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> entrees = new List<IBirthable>();
            string[] input = Console.ReadLine().Split();

            while (!input.Contains("End"))
            {
                if (input[0] == "Robot")
                {
                    string model = input[1];
                    string id = input[2];

                    Thing robot = new Robot(model, id);
                }
                else if (input[0] == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthDate = input[4];

                    IBirthable citizen = new Citizen(name, age, id,birthDate);
                    entrees.Add(citizen);
                }
                else
                {
                    string name = input[1];
                    string birtDate = input[2];
                    IBirthable pet = new Pet(name, birtDate);
                    entrees.Add(pet);
                }

                input = Console.ReadLine().Split();
            }

            string year = Console.ReadLine();

            foreach (var id in entrees)
            {
                var lastDigits = id.Birthdate.TakeLast(4).ToList();

                if (string.Join("", lastDigits) == year)
                {
                    Console.WriteLine(id.Birthdate);
                }
            }
        }
    }
}
