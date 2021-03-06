using Pr._04.WildFarm.Foods;
using Pr._04.WildFarm.Validations;

namespace Pr._04.WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double TigerFoodPiece = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                Validator.GetValidation(this.GetType().Name, food.GetType().Name);
                base.FoodEaten = 0;
                return;
            }
            base.FoodEaten = food.Quantity;
            this.Weight += food.Quantity * TigerFoodPiece;
        }

        public override string MakeSound()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
