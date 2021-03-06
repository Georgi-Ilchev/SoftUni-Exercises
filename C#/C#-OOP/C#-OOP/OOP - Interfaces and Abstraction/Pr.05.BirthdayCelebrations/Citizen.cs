using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._05.BirthdayCelebrations
{
    public class Citizen : Thing, IIdable,IBirthable,INameable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public Citizen(string name, int age, string id,string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthday;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get => this.Name; set { this.Name = value; } }
        public string Birthdate { get => this.birthdate; set { this.birthdate = value; } }
    }
}
