using Pr._04.WildFarm.Foods;
using Pr._04.WildFarm.Validations;

namespace Pr._04.WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double CatFoodPiece = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
            {
                Validator.GetValidation(this.GetType().Name, food.GetType().Name);
                base.FoodEaten = 0;
                return;
            }
            base.FoodEaten = food.Quantity;
            this.Weight += food.Quantity * CatFoodPiece;
        }

        public override string MakeSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            //•	Felines – "{AnimalType} [{AnimalName}, {Breed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
