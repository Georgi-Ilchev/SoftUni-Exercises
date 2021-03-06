using Pr._04.WildFarm.Animals;
using Pr._04.WildFarm.Animals.Birds;
using Pr._04.WildFarm.Animals.Mammals;
using Pr._04.WildFarm.Animals.Mammals.Felines;
using Pr._04.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace Pr._04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] animalParts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal = GetAnimal(animalParts);
                Food food = GetFood(foodParts);

                animals.Add(animal);
                foods.Add(food);

                input = Console.ReadLine();
            }

            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i].MakeSound());
                animals[i].Eat(foods[i]);
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public static Food GetFood(string[] foodParts)
        {
            string foodType = foodParts[0];
            switch (foodType)
            {
                case "Fruit":
                    return new Fruit(int.Parse(foodParts[1]));
                case "Meat":
                    return new Meat(int.Parse(foodParts[1]));
                case "Seeds":
                    return new Seeds(int.Parse(foodParts[1]));
                case "Vegetable":
                    return new Vegetable(int.Parse(foodParts[1]));
                default:
                    return null;
            }
        }

        public static Animal GetAnimal(string[] animalParts)
        {
            string animalType = animalParts[0];
            switch (animalType)
            {
                case "Hen":
                    return new Hen(animalParts[1], double.Parse(animalParts[2]), double.Parse(animalParts[3]));
                case "Owl":
                    return new Owl(animalParts[1], double.Parse(animalParts[2]), double.Parse(animalParts[3]));
                case "Mouse":
                    return new Mouse(animalParts[1], double.Parse(animalParts[2]), animalParts[3]);
                case "Dog":
                    return new Dog(animalParts[1], double.Parse(animalParts[2]), animalParts[3]);
                case "Cat":
                    return new Cat(animalParts[1], double.Parse(animalParts[2]), animalParts[3], animalParts[4]);
                case "Tiger":
                    return new Tiger(animalParts[1], double.Parse(animalParts[2]), animalParts[3], animalParts[4]);
                default:
                    return null;
            }
            //•	Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";  - Cat && Tiger
            //•	Birds - "{Type} {Name} {Weight} {WingSize}";                - Hen && Owl
            //•	Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}";    - Mouse && Dog

        }
    }
}
