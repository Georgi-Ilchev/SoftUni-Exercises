using System;

namespace Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string architectName = Console.ReadLine();
            int project = int.Parse(Console.ReadLine());
            int projectHours = project * 3;
            Console.WriteLine($"The architect {architectName} will need {projectHours} hours to complete {project} project/s.");
        }
    }
}
