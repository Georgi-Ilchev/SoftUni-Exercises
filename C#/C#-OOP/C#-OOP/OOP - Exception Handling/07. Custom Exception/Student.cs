using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Custom_Exception
{
    public class Student : Person
    {
        public Student(string firstName, string lastName, int age, string email)
            : base(firstName, lastName, age)
        {

        }
    }
}
