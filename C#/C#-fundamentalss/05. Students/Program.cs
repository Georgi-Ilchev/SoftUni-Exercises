using System;
using System.Collections.Generic;

namespace _05._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split();
                string firstName = command[0];
                string lastName = command[1];
                int age = int.Parse(command[2]);
                string city = command[3];

                Student student = new Student();
                
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.City = city;

                students.Add(student);
                input = Console.ReadLine();
            }
            string filter = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.City == filter)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
