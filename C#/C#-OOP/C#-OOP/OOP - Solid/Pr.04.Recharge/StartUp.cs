using System;

namespace Pr._04.Recharge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Gecata Toshkov");
            Robot robot = new Robot("Robosx240", 100);

            RechargeStation rechargeStation = new RechargeStation();

            rechargeStation.Recharge(robot);

            employee.Work(12);
            employee.Work(12);
            employee.Work(12);
            employee.Sleep();
            Console.WriteLine(robot.CurrentPower);
            robot.Work(24);
            robot.Recharge();
            robot.Work(98);
            Console.WriteLine(robot.CurrentPower);
            Console.WriteLine(employee.WorkingHours);
        }
    }
}
