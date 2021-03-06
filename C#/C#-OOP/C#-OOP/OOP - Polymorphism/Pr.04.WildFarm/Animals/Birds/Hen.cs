using Pr._04.WildFarm.Foods;

namespace Pr._04.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double HenFoodPiece = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            base.FoodEaten = food.Quantity;
            this.Weight += food.Quantity * HenFoodPiece;
        }

        public override string MakeSound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            //•	Birds – "{AnimalType} [{AnimalName}, {WingSize}, {AnimalWeight}, {FoodEaten}]"
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {base.FoodEaten}]";
        }
    }
}
