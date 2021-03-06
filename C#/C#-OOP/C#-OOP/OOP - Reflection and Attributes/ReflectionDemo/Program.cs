using System;
using System.Linq;
using System.Text;

namespace OOP___Reflection_and_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Type personType1 = typeof(Person);
            Type personType2 = typeof(string);
            Type personType3 = typeof(void);

            var propName = personType1.GetProperty("Name");
            Console.WriteLine(propName);
            Console.WriteLine($"{propName.Name} - .name");

            Console.WriteLine($"{personType2} - string");
            Console.WriteLine($"{personType3} - void");


            Console.WriteLine(new string('-', 60));
            //2
            var getType = GetType("OOP___Reflection_and_Attributes.Person");
            Console.WriteLine($"Name: {getType.Name}");
            Console.WriteLine($"Full name: {getType.FullName})");
            Console.WriteLine($"Namespace: {getType.Namespace})");
            Console.WriteLine($"Assembly.fulln: {getType.Assembly.FullName})");
            Console.WriteLine($"Basetype: {getType.BaseType}");
            Console.WriteLine($"Interfaces: {string.Join(", ", getType.GetInterfaces().ToList())}");


            static Type GetType(string name)
            {
                var type = Type.GetType(name);

                return type;
            }

            Console.WriteLine(new string('-',60));
            //3
            var type1 = typeof(Person);
            var person1 = new Person();
            person1.Age = 20;

            var result1 = type1.GetProperty("Age").GetValue(person1);
            Console.WriteLine(result1);

            //4
            Console.WriteLine(new string('-', 60));
            var type2 = typeof(Person);
            var person2 = Activator.CreateInstance(type2) as Person;
            person2.Age = 20;

            var result2 = type2.GetProperty("Age").GetValue(person2);
            Console.WriteLine(result2);

            Console.WriteLine(new string('-', 60));
            //5
            var instanceOfStringBuilder = Activator.CreateInstance(typeof(StringBuilder)) as StringBuilder;

            instanceOfStringBuilder.AppendLine("Hi");
            instanceOfStringBuilder.AppendLine("Hi2");

            Console.WriteLine(string.Join(" ", instanceOfStringBuilder.ToString()));
            Console.WriteLine(new string('-', 60));

            //6
            var person3 = Activator.CreateInstance(typeof(Person), 10) as Person;
            Console.WriteLine(person3.Age);
        }
    }
}
