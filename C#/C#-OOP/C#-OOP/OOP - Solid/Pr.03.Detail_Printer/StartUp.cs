using System;
using System.Collections.Generic;

namespace Pr._03.Detail_Printer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Employee firstEmployee = new Employee("Kircho");
            Employee secondEmployee = new Employee("Stoyan");

            Manager manager = new Manager("baiGosho", new List<string>() { "data.txt", "preview.pptx", "salaries.xsl" });
            IList<Employee> employees = new List<Employee>() { firstEmployee, secondEmployee, manager };
            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}
