using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Student
    {
        public Student(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        //"Student: First Name = {firstName}, Last Name = {lastName}, Subject = {subject}"
        public override string ToString()
        {
            return $"Student: First Name = {this.FirstName}, Last Name = {this.LastName}, Subject = {this.Subject}";
        }
    }
}
