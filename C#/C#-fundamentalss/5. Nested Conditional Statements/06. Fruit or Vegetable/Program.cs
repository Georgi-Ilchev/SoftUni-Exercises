using System;

namespace _06._Fruit_or_Vegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name = Console.ReadLine();

            //switch (name)
            {
                //case "banana": Console.WriteLine("fruit");break;
                //case "apple": Console.WriteLine("fruit");break;
                //case "kiwi": Console.WriteLine("fruit");break;
                //case "cherry": Console.WriteLine("fruit");break;
                //case "lemon": Console.WriteLine("fruit");break;
                //case "grapes": Console.WriteLine("fruit");break;
                //case "tomato": Console.WriteLine("vegetable");break;
                //case "cucumber": Console.WriteLine("vegetable");break;
                //case "pepper": Console.WriteLine("vegetable");break;
                //case "carrot": Console.WriteLine("vegetable");break;
                //default:
                //Console.WriteLine("unknown"); break; 

            }
            string name = Console.ReadLine();

            if (name == "banana" ||
                name == "apple" ||
                name == "kiwi" ||
                name == "cherry" ||
                name == "lemon" ||
                name == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (name == "tomato" ||
                name == "cucumber" ||
                name == "pepper" ||
                name == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }


    }
}
