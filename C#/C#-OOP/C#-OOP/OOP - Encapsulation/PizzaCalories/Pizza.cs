using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly Dough dough;
        private readonly IList<Topping> toppings;

        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.PizzaInvalidName, Constants.PizzaNameMinLenght, Constants.PizzaNameMaxLenght));
                }
                this.name = value;
            }
        }
        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);

            if (this.toppings.Count > Constants.PizzaMaxToppingsCount)
            {
                throw new ArgumentException(string.Format(ErrorMessages.PizzaInvalidToppingsCount, Constants.PizzaMinToppingsCount, Constants.PizzaMaxToppingsCount));
            }
        }
        public double CalcTotalCalories()
        {
            double doughCalories = this.dough.CalcCalories();
            double toppingsCalories = this.toppings.Sum(t => t.CalcCalories());

            return doughCalories + toppingsCalories;
        }
    }
}
