using Pr._04.WildFarm.Foods;

namespace Pr._04.WildFarm.Animals
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public double Weight
        {
            get => this.weight;
            set => this.weight = value;
        }
        public int FoodEaten
        {
            get => this.foodEaten;
            set => this.foodEaten = value;
        }

        public abstract string MakeSound();
        public abstract void Eat(Food food);
    }
}
