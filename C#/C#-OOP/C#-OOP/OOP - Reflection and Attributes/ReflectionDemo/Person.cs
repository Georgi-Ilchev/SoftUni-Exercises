using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Reflection_and_Attributes
{
    public class Person : IPerson
    {
        public Person()
        {

        }
        public Person(int age)
        {
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Work { get; set; }
    }
}
