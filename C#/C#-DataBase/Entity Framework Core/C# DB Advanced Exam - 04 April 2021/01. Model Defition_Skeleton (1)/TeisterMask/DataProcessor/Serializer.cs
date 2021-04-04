namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var root = "Projects";

            var projects = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Count >= 1)
                .Select(p => new ProjectWithTaskXmlDto
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new TaskExportDTO
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            var result = XmlConverter.Serialize(projects, root);

            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                                .ToArray()
                                .Where(et => et.Task.OpenDate >= date)
                                .OrderByDescending(et => et.Task.DueDate)
                                .ThenBy(et => et.Task.Name)
                                .Select(et => new
                                {
                                    TaskName = et.Task.Name,
                                    OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                    DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                    LabelType = et.Task.LabelType.ToString(),
                                    ExecutionType = et.Task.ExecutionType.ToString()
                                }).ToArray()
                })
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return result;
        }
    }
}