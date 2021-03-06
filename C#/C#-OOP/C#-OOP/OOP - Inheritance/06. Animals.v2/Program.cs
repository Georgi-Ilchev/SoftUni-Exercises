using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Animals.v2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animals> animals = new List<Animals>();

            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string type = input;
                string[] splitted = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Animals animal;
                try
                {
                    animal = GetAnimal(type, splitted);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                animals.Add(animal);
            }

            foreach (Animals currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal);
            }
        }

        private static Animals GetAnimal(string type, string[] splitted)
        {
            string name = splitted[0];
            int age = int.Parse(splitted[1]);
            string gender = null;
            gender = GetGender(splitted, gender);

            Animals animal;
            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }
            return animal;
        }

        private static string GetGender(string[] splitted, string gender)
        {
            if (splitted.Length >= 3)
            {
                gender = splitted[2];
            }
            return gender;
        }
    }
}
