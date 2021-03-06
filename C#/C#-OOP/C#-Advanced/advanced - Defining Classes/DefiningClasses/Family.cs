using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            //int maxAge = int.MinValue;
            //Person person = null;

            //foreach (var currPerson in People)
            //{
            //    var currentAge = currPerson.Age;
            //    if (currentAge > maxAge)
            //    {
            //        maxAge = currentAge;
            //        person = currPerson;
            //    }
            //}
            //return person;

            Person oldestPerson = People.OrderByDescending(p => p.Age).First();
            return oldestPerson;
        }
        public Person[] GetPeople ()
        {
            var people = People.Where(x => x.Age > 30)
            .OrderBy(x => x.Name).ToArray();

            return people;
        }
    }
}
