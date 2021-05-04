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
    using TeisterMask.XMLHelper;
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
            var desereliezedProjects = XmlConverter.Deserializer<ProjectXMLInputModel>(xmlString, "Projects");
            var sb = new StringBuilder();

            foreach (var currentProject in desereliezedProjects)
            {
                if (!IsValid(currentProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projectDueDate = currentProject.DueDate == null || currentProject.DueDate == "" ?
                    null :
                    (DateTime?)DateTime.ParseExact(currentProject.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var projectOpenDate = DateTime.ParseExact(currentProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var project = new Project
                {
                    Name = currentProject.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                foreach (var currentTask in currentProject.Tasks)
                {
                    if (!IsValid(currentTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    var taskOpenDate = DateTime.ParseExact(currentTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var taskDueDate = DateTime.ParseExact(currentTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (taskOpenDate < projectOpenDate ||
                        taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(new Task
                    {
                        Name = currentTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(currentTask.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(currentTask.LabelType)

                    });


                }

                context.Projects.Add(project);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedProject.ToString(), project.Name, project.Tasks.Count));
            }

            return sb.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var deserializedEmployees = JsonConvert.DeserializeObject<IEnumerable<EmployeeJsonInputModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var currentEmployee in deserializedEmployees)
            {
                if (!IsValid(currentEmployee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var employee = new Employee
                {
                    Username = currentEmployee.Username,
                    Email = currentEmployee.Email,
                    Phone = currentEmployee.Phone,
                };

                var uniqueTaskIds = currentEmployee.Tasks.Distinct().ToList();
                var dbTasksId = context.Tasks.Select(x => x.Id).ToList();

                foreach (var taskId in uniqueTaskIds)
                {
                    if (!dbTasksId.Contains(taskId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        TaskId = taskId
                    });
                }

                context.Employees.Add(employee);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee.ToString(), employee.Username, employee.EmployeesTasks.Count));


            }



            return sb.ToString().Trim();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}