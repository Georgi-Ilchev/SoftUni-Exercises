namespace Pr._04.Recharge
{
    using System;

    public class Employee : Worker
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            // sleep...
            Console.WriteLine($"Employee is sleeping!");
        }
    }
}
