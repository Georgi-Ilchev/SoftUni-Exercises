using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            var result = RemoveTown(db);

            Console.WriteLine(result);
        }

        //03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary,
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        //04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Salary > 50_000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            var result = sb.ToString();

            return result.ToString().TrimEnd();
        }

        //05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department.Name,
                    x.Salary,
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
            }

            var result = sb.ToString();

            return result.ToString().TrimEnd();
        }

        //06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var nakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            nakov.AddressId = address.AddressId;
            context.SaveChanges();


            var addresses = context.Employees
                .Select(x => new
                {
                    x.Address.AddressText,
                    x.Address.AddressId,
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var currentAddres in addresses)
            {
                sb.AppendLine($"{currentAddres.AddressText}");
            }

            var result = sb.ToString();

            return result.ToString().TrimEnd();

            //-------------------2-------------

            //var nakov2 = context.Employees
            //    .FirstOrDefault(x => x.LastName == "Nakov");

            //nakov2.Address = new Address
            //{
            //    AddressText = "Vitoshka 15",
            //    TownId = 4,
            //};

            //context.SaveChanges();


            //var addresses2 = context.Employees
            //    .Select(x => new
            //    {
            //        x.Address.AddressText,
            //        x.Address.AddressId,
            //    })
            //    .OrderByDescending(x => x.AddressId)
            //    .Take(10)
            //    .ToList();

            //var sb2 = new StringBuilder();

            //foreach (var currentAddres in addresses2)
            //{
            //    sb2.AppendLine($"{currentAddres.AddressText}");
            //}

            //var result2 = sb2.ToString();

            //return result2.ToString().TrimEnd();
        }

        //07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
                                                         p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFirstName = x.FirstName,
                    EmployeeLastName = x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Project = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate,
                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var eProject in emp.Project)
                {
                    var endDate = eProject.EndDate.HasValue ? eProject.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";
                    sb.AppendLine($"--{eProject.ProjectName} - {eProject.StartDate} - {endDate}");
                }
            }

            var result = sb.ToString();

            return result.ToString().TrimEnd();
        }

        //08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(x => new
                {
                    x.AddressText,
                    x.Town.Name,
                    x.Employees.Count,
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }

            var result = sb.ToString();

            return result.ToString().TrimEnd();
        }

        //09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            //--------------------------1---------------------------
            var employee147 = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects.OrderBy(x => x.Project.Name)
                        .Select(p => new
                        {
                            p.Project.Name
                        })

                })
                .FirstOrDefault(x => x.EmployeeId == 147);

            var sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.Projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            var result = sb.ToString().TrimEnd();

            return result;

            //-------------------------2-----------------------------

            //var employee147 = context.Employees
            //    .Include(x=>x.EmployeesProjects)
            //    .ThenInclude(x=>x.Project)
            //    .ToList()
            //    .Select(x => new
            //    {
            //        x.EmployeeId,
            //        x.FirstName,
            //        x.LastName,
            //        x.JobTitle,
            //        Projects = x.EmployeesProjects
            //            .Select(p => new
            //            {
            //                p.Project.Name
            //            })
            //            .OrderBy(x => x.Name)
            //    })
            //    .FirstOrDefault(x => x.EmployeeId == 147);

            //var sb = new StringBuilder();

            //sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            //foreach (var project in employee147.Projects)
            //{
            //    sb.AppendLine($"{project.Name}");
            //}

            //var result = sb.ToString().TrimEnd();

            //return result;

            //---------------------------3----------------------------

            //var employee147 = context.Employees
            //    .Select(x => new Employee
            //    {
            //        EmployeeId = x.EmployeeId,
            //        FirstName = x.FirstName,
            //        LastName = x.LastName,
            //        JobTitle = x.JobTitle,
            //        EmployeesProjects = x.EmployeesProjects
            //            .Select(p => new EmployeeProject
            //            {
            //                Project = p.Project
            //            })
            //            .OrderBy(x => x.Project.Name)
            //            .ToList()
            //    })
            //    .FirstOrDefault(x => x.EmployeeId == 147);

            //var sb = new StringBuilder();

            //sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            //foreach (var project in employee147.EmployeesProjects)
            //{
            //    sb.AppendLine($"{project.Project.Name}");
            //}

            //var result = sb.ToString().TrimEnd();

            //return result;
        }

        //10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var deparment in departments)
            {
                sb.AppendLine($"{deparment.Name} - {deparment.ManagerFirstName} {deparment.ManagerLastName}");

                foreach (var emp in deparment.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        //11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate,
                })
                .OrderBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var proj in projects)
            {
                var startDate = proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                sb.AppendLine($"{proj.Name}");
                sb.AppendLine($"{proj.Description}");
                sb.AppendLine($"{startDate}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        //12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(x => departments.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var emp in employees)
            {
                emp.Salary *= 1.12m;
            }
            context.SaveChanges();

            var sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }

        //13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                //.Where(x => x.FirstName.StartsWith("Sa"))
                .Where(x => EF.Functions.Like(x.FirstName, "sa%"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //14.	Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();

            var project = context.Projects
                .Where(x => x.ProjectId == 2)
                .Single();

            foreach (var proj in projectToDelete)
            {
                context.EmployeesProjects.Remove(proj);
            }

            context.Projects.Remove(project);
            context.SaveChanges();

            var sb = new StringBuilder();

            //1
            //var projects = context.Projects
            //    .Select(x => x.Name)
            //    .Take(10)
            //    .ToList();

            //foreach (var proj in projects)
            //{
            //    sb.AppendLine($"{proj}");
            //}

            //return sb.ToString().TrimEnd();

            //2
            context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList()
                .ForEach(p => sb.AppendLine(p));

            return sb.ToString().TrimEnd();
        }

        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var seattle = context.Towns
                .Include(x=>x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");

            var addresses = seattle.Addresses
                .Select(x => x.AddressId).ToList();

            var employees = context.Employees
                .Where(x => x.AddressId.HasValue && addresses.Contains(x.AddressId.Value))
                .ToList();

            foreach (var emp in employees)
            {
                emp.AddressId = null;
            }
            context.SaveChanges();

            foreach (var addressId in addresses)
            {
                var address = context.Addresses.FirstOrDefault(x => x.AddressId == addressId);

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(seattle);
            context.SaveChanges();

            var result = $"{addresses.Count} addresses in Seattle were deleted";

            return result.ToString();

            //---------------2---------------------
            //var town = context.Towns
            //    .First(t => t.Name == "Seattle");

            //var addressesToDel = context
            //    .Addresses
            //    .Where(s => s.TownId == town.TownId);
            //int addressesCount = addressesToDel.Count();

            //var employees = context.Employees
            //    .Where(e => addressesToDel.Any(a => a.AddressId == e.AddressId));

            //foreach (var e in employees)
            //{
            //    e.AddressId = null;
            //}

            //foreach (var a in addressesToDel)
            //{
            //    context.Addresses.Remove(a);
            //}

            //context.Towns.Remove(town);

            //context.SaveChanges();

            //return $"{addressesCount} addresses in {town.Name} were deleted";
        }
    }
}
