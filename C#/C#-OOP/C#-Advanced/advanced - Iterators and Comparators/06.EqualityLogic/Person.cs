using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo( Person other)
        {
            int result = 1;

            if (other != null)
            {
                result = this.name.CompareTo(other.name);

                if (result == 0)
                {
                    result = this.age.CompareTo(other.age);

                    //if (result == 0)
                    //{
                    //    result = this.town.CompareTo(other.town);
                    //}
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Person other)
            {
                return this.name == other.name && this.age == other.age;
            }
            return false;
        }
        public override int GetHashCode()
        {
            //Person Hash = Name Hash + Age Hash
            return this.name.GetHashCode() + this.age.GetHashCode();
        }
    }
}
