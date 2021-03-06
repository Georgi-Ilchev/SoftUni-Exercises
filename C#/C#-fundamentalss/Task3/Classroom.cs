using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class Classroom
    {
        private List<Student> data;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            data = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public int GetStudentsCount()
        {
            return this.Count;
        }
        public string RegisterStudent(Student student)
        {
            StringBuilder sb = new StringBuilder();
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(student);
                sb.Append($"Added student {student.FirstName} {student.LastName}");
            }
            else
            {
                sb.Append($"No seats in the classroom");
            }
            return sb.ToString().Trim();
            //StringBuilder sb = new StringBuilder();

            //if (_COUNT_OF_STUDENTS <= this.Capacity)
            //{
            //    _COUNT_OF_STUDENTS++;
            //    this.data.Add(student);
            //    sb.Append($"Added student {student.FirstName} {student.LastName}");
            //}
            //else
            //{
            //    sb.Append($"No seats in the classroom");
            //}
            //return sb.ToString().TrimEnd();
        }

        public string DismissStudent(string firstName, string lastName)
        {
            //StringBuilder sb = new StringBuilder();
            //var currentStudent = data.Find(x => (x.FirstName == firstName && x.LastName == lastName));
            //if (currentStudent != null)
            //{
            //    if (currentStudent.FirstName == firstName)
            //    {
            //        data.Remove(currentStudent);
            //        sb.Append($"Dismissed student {firstName} { lastName} ");
            //    }
            //    else
            //    {
            //        sb.Append("Student not found");
            //    }
            //}
            //else
            //{
            //    return "Student not found";
            //}



            //return sb.ToString().TrimEnd();

            StringBuilder sb = new StringBuilder();
            var currentStudent = data.Find(x => (x.FirstName == firstName && x.LastName == lastName));
            if (currentStudent == null)
            {
                sb.Append($"Student not found");
            }
            else
            {
                data.Remove(currentStudent);
                sb.Append($"Dismissed student {firstName} { lastName} ");
            }
            return sb.ToString().Trim();
        }
        public string GetSubjectInfo(string subject)
        {
            //var result = data.FindAll(x => x.Subject == subject);

            //StringBuilder sb = new StringBuilder();

            //if (result.Count == 0)
            //{
            //    //Console.WriteLine($"Subject: {subject}");
            //    //Console.WriteLine($"Students:");
            //    //foreach (var item in result)
            //    //{
            //    //    sb.AppendLine($"{item.FirstName} {item.LastName}");
            //    //}
            //    sb.Append($"No students enrolled for the subject");
            //}
            //else
            //{
            //    //sb.Append($"No students enrolled for the subject");
            //    Console.WriteLine($"Subject: {subject}");
            //    Console.WriteLine($"Students:");
            //    foreach (var item in result)
            //    {
            //        sb.AppendLine($"{item.FirstName} {item.LastName}");
            //    }
            //}

            //return sb.ToString().TrimEnd();



            var result = data.FindAll(x => x.Subject == subject);

            StringBuilder sb = new StringBuilder();

            if (result.Any())
            {
                Console.WriteLine($"Subject: {subject}");
                Console.WriteLine($"Students:");
                foreach (var item in result)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }
            }
            else
            {
                return "No students enrolled for the subject";
            }

            return sb.ToString().TrimEnd();
        }

        public Student GetStudent(string firstName, string lastName)
        {
            var result = data.FirstOrDefault(p => (p.FirstName == firstName && p.LastName == lastName));
            return result;
        }
    }
}
