using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {

        }

        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child age must be less than 15");
                }
                base.Age = value;
            }
        }


    }
}
