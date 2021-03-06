using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Valid_Person
{
    public class Person
    {
        private const int minAge = 0;
        private const int maxAge = 120;

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The first name cannot be null or empty");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The last name cannot be null or empty");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < minAge || value > maxAge)
                {
                    throw new ArgumentOutOfRangeException($"The age shoud be in range {minAge} - {maxAge}!");
                }
                this.age = value;
            }
        }
    }
}
