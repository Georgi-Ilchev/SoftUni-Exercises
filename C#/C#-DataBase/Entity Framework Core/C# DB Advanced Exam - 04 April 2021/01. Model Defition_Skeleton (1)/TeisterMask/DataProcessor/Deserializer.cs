namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var root = "Projects";
            var sb = new StringBuilder();

            var validProjects = new List<Project>();

            var projects = XmlConverter.Deserializer<ProjectXmlDTO>(xmlString, root);

            foreach (var xmlProject in projects)
            {
                if (!IsValid(xmlProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isOpenDateValid = DateTime.TryParseExact(xmlProject.OpenDate, "dd/MM/yyyy",
                                      CultureInfo.InvariantCulture, DateTimeStyles.None, out var openDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (!string.IsNullOrEmpty(xmlProject.DueDate))
                {
                    var isDueDateValid = DateTime.TryParseExact(xmlProject.DueDate, "dd/MM/yyyy",
                                         CultureInfo.InvariantCulture, DateTimeStyles.None, out var dueDateValue);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateValue;
                }

                var project = new Project
                {
                    Name = xmlProject.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                foreach (var xmlTask in xmlProject.Tasks)
                {
                    if (!IsValid(xmlTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isTaskOpenDateValid = DateTime.TryParseExact(xmlTask.OpenDate, "dd/MM/yyyy",
                                     CultureInfo.InvariantCulture, DateTimeStyles.None, out var taskOpenDate);

                    if (!isTaskOpenDateValid || taskOpenDate < project.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    var isTaskDueDateValid = DateTime.TryParseExact(xmlTask.DueDate, "dd/MM/yyyy",
                                     CultureInfo.InvariantCulture, DateTimeStyles.None, out var taskDueDate);

                    if (!isTaskDueDateValid || taskDueDate > project.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    var task = new Task
                    {
                        Name = xmlTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)xmlTask.ExecutionType,
                        LabelType = (LabelType)xmlTask.LabelType
                    };

                    project.Tasks.Add(task);
                }

                validProjects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var validEmployees = new List<Employee>();

            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeJsonDTO>>(jsonString);

            foreach (var jsonEmployee in employees)
            {
                if (!IsValid(jsonEmployee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (jsonEmployee.Username.Any(x => !char.IsLetterOrDigit(x)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = jsonEmployee.Username,
                    Email = jsonEmployee.Email,
                    Phone = jsonEmployee.Phone,
                };

                //unique tasks
                foreach (var jsonTask in jsonEmployee.Tasks.Distinct())
                {
                    //if task does not exist in the database
                    if (context.Tasks.All(t => t.Id != jsonTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = context.Tasks.FirstOrDefault(t => t.Id == jsonTask);

                    var employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        Task = task
                    };

                    employee.EmployeesTasks.Add(employeeTask);
                }

                validEmployees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}