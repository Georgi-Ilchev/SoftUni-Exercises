using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._04.BorderControl
{
    public class Citizen : IIdable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get => this.Name; set { this.Name = value; } }

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
    }
}
