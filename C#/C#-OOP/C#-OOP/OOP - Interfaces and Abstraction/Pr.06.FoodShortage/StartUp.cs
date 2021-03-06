using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Pr._06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();
            List<IBuyer> foods = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    Rebel rebel = new Rebel(name, age, group);
                    persons.Add(rebel);
                }
                else if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    persons.Add(citizen);
                }
            }

            string personBuyingFood = Console.ReadLine();
            while (personBuyingFood != "End")
            {
                Person currentPerson = persons.Find(x => x.Name == personBuyingFood);
                if (currentPerson != null)
                {
                    currentPerson.BuyFood();
                }
                personBuyingFood = Console.ReadLine();
            }

            int totalFood = persons.Sum(f => f.Food);
            Console.WriteLine(totalFood);
        }
    }
}
