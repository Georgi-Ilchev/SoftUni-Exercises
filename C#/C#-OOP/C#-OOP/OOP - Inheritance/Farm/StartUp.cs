using System;

namespace Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();

            Puppy gosho = new Puppy();
            gosho.Bark();
            gosho.Weep();
        }
    }
}
