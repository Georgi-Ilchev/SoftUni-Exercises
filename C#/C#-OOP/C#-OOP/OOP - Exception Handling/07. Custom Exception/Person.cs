using _07._Custom_Exception.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Custom_Exception
{
    public class Person
    {
        private const string INVALID_NAME_MSG = "The {0} name should contains only letters!";
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

                if (!value.All(c => char.IsLetter(c)))
                {
                    throw new InvalidPersonNameException(string.Format(INVALID_NAME_MSG, "first"));
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

                if (!value.All(c => char.IsLetter(c)))
                {
                    throw new InvalidPersonNameException(string.Format(INVALID_NAME_MSG, "last"));
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
