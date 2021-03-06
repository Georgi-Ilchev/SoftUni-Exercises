using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _06._Animals
{
    public class Engine
    {
        private const string END_OF_INPUT_COMMAND = "Beast!";
        private readonly List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != END_OF_INPUT_COMMAND)
            {
                string type = input;
                string[] splitted = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Animal animal;

                try
                {
                    animal = GetAnimal(type, splitted);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                this.animals.Add(animal);
            }

            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Animal GetAnimal(string type, string[] splitted)
        {
            string name = splitted[0];
            int age = int.Parse(splitted[1]);
            string gender = null;
            gender = GetGender(splitted, gender);

            Animal animal;
            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
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
