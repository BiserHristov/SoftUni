namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.XMLHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects.ToList()
                .Where(p => p.Tasks.Count > 0)
                .Select(p => new ProjextXMLOutputModel
                {
                    ProjectName = p.Name,
                    TasksCount = p.Tasks.Count,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new TaskXMLOutputModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t=>t.Name)
                    .ToList()
                })
                .OrderByDescending(p=>p.TasksCount)
                .ThenBy(p=>p.ProjectName)
                .ToList();


            var xml = XmlConverter.Serialize(projects, "Projects");
            return xml;

        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees.ToList()
                .Where(e => e.EmployeesTasks.Count > 0)
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .OrderByDescending(et => et.Task.DueDate)
                    .ThenBy(et => et.Task.Name)
                    .Select(et => new
                    {
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        DueDate = et.Task.DueDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        LabelType = et.Task.LabelType.ToString(),
                        ExecutionType = et.Task.ExecutionType.ToString(),

                    })
                    .ToList()
                })
                .OrderByDescending(e => e.Tasks.Count)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToList();


            string result = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return result;

        }
    }
}