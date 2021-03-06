using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._06.FoodShortage
{
    public class Citizen : Person, IIdable, IBirthable, INameable, IBuyer
    {
        private int age;
        private string id;
        private string birthdate;
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthday;
        }
        public int Age { get => this.age; set { this.age = value; } }
        public string Id { get => this.id; set { this.id = value; } }
        public string Birthdate { get => this.birthdate; set { this.birthdate = value; } }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
