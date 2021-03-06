using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = ArrayCreator.Create(10, "avram");
            Console.WriteLine(String.Join(", ", array));
        }
    }
}
