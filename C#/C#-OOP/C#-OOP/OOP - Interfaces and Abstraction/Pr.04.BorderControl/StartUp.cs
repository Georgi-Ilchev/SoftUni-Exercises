using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr._04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdable> entrees = new List<IIdable>();
            string[] input = Console.ReadLine().Split();

            while (!input.Contains("End"))
            {
                if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];

                    IIdable robot = new Robot(model, id);
                    entrees.Add(robot);
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];

                    IIdable citizen = new Citizen(name, age, id);
                    entrees.Add(citizen);
                }

                input = Console.ReadLine().Split();
            }
            
            string detainingId = Console.ReadLine();

            foreach (var id in entrees)
            {
                var lastDigits = id.Id.TakeLast(detainingId.Length).ToList();

                if (string.Join("", lastDigits) == detainingId)
                {
                    Console.WriteLine(id.Id);
                }
            }
        }
    }
}
