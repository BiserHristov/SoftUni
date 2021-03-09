using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new SoftUniContext();

            string result = string.Empty;

            //Task 3
            // result = GetEmployeesFullInformation(db);

            //Task 4
            // result = GetEmployeesWithSalaryOver50000(db);

            //Task 5
            // result = GetEmployeesFromResearchAndDevelopment(db);

            //Task 6
            //result = AddNewAddressToEmployee(db);

            //Task 7
            //result = GetEmployeesInPeriod(db);


            //Task 8
            //result = GetAddressesByTown(db);

            //Task 9
            //result = GetEmployee147(db);

            //Task 10
            //result = GetDepartmentsWithMoreThan5Employees(db);


            //Task 11
            //result = GetLatestProjects(db);


            //Task 12
            //result = IncreaseSalaries(db);

            //Task 13
            //result = GetEmployeesByFirstNameStartingWithSa(db);

            //Task 14
            //result = DeleteProjectById(db);

            //Task 15
            result = RemoveTown(db);



            Console.WriteLine(result);


        }

        //Task 15
        public static string RemoveTown(SoftUniContext context)
        {
            var seattleTown = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle");


            var addressIds = seattleTown.Addresses.Select(x => x.AddressId).ToList();

            var addressesInSeattle = context.Addresses
                .Where(a => a.TownId == seattleTown.TownId)
                .ToList();

          
            var employyeesWithAddressInSeattle = context.Employees
                .Where(e => e.AddressId.HasValue && addressIds.Contains(e.AddressId.Value))
                .ToList();

            foreach (var emp in employyeesWithAddressInSeattle)
            {
                emp.AddressId = null;
            }
        

            foreach (var ais in addressesInSeattle)
            {
                context.Addresses.Remove(ais);
            }
        

            context.Towns.Remove(seattleTown);
            context.SaveChanges();

            return $"{addressesInSeattle.Count} addresses in Seattle were deleted";

      

        }


        //Task 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeesProjects = context.EmployeesProjects
                .Where(p => p.ProjectId == 2)
                .ToList();

            foreach (var emPr in employeesProjects)
            {
                context.EmployeesProjects.Remove(emPr);
            }


            var project = context.Projects
                .Where(p => p.ProjectId == 2)
                .FirstOrDefault();
            context.Projects.Remove(project);
            context.SaveChanges();

            var tenProjects = context.Projects
                .Take(10)
                .Select(p => new
                {
                    p.Name
                })
                .ToList();



            var sb = new StringBuilder();


            foreach (var pr in tenProjects)
            {
                sb.AppendLine(pr.Name);

            }
            return sb.ToString().Trim();
        }



        //Task 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();


            var sb = new StringBuilder();


            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");

            }
            return sb.ToString().Trim();

        }

        //Task 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            List<string> departments = new List<string> { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(e => departments.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();


            var sb = new StringBuilder();


            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary *= 1.12M:F2})");

            }
            context.SaveChanges();
            return sb.ToString().Trim();
        }



        //Task 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    ProjectStartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                });

            var sb = new StringBuilder();


            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.ProjectStartDate);

            }

            return sb.ToString().Trim();
        }

        //Task 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    AllEmployees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                })

                .ToList();


            var sb = new StringBuilder();


            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.Name} - {dep.ManagerFirstName} {dep.ManagerLastName}");

                foreach (var emp in dep.AllEmployees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }

            }

            return sb.ToString().Trim();
        }


        //Task 9
        public static string GetEmployee147(SoftUniContext context)
        {


            var emp = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name
                    })
                })
                .FirstOrDefault();

            var sb = new StringBuilder();

            sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");

            foreach (var project in emp.Projects.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{project.Name}");

            }

            return sb.ToString().Trim();
        }

        //Task 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var empAddress = context.Addresses
                .OrderByDescending(x => x.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(x => new
                {
                    Address = x.AddressText,
                    TownName = x.Town.Name,
                    EmpCpount = x.Employees.Count()
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var ea in empAddress)
            {
                sb.AppendLine($"{ea.Address}, {ea.TownName} - {ea.EmpCpount} employees");
            }

            return sb.ToString().Trim();
        }



        //Task 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                //.Include(x => x.EmployeesProjects)
                //.ThenInclude(x => x.Project)
                .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
                                                       p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFirstName = x.FirstName,
                    EmployeeLastName = x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var project in emp.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {  (project.EndDate == null ? "not finished" : project.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");


                }
            }

            return sb.ToString().Trim();



            //ANOTHER SOLUTION
            //var employeesManagers = context.EmployeesProjects
            //    .Where(e => e.Project.StartDate.Year >= 2001 && e.Project.StartDate.Year <= 2003)
            //    .Select(e => new
            //    {
            //        EmpId = e.EmployeeId,
            //        EmployeeFirstName = e.Employee.FirstName,
            //        EmployeeLastName = e.Employee.LastName,
            //        ManagerFirstName = e.Employee.Manager.FirstName,
            //        ManagerLastName = e.Employee.Manager.LastName


            //    })
            //    .Distinct()
            //    .Take(10)
            //    .ToList();


            //var sb = new StringBuilder();

            //foreach (var emp in employeesManagers)
            //{
            //    sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

            //    var allProjects = context.EmployeesProjects
            //         .Where(ep => ep.EmployeeId == emp.EmpId)
            //         .ToList();

            //    foreach (var item in allProjects)
            //    {
            //        var project = context.Projects.FirstOrDefault(p => p.ProjectId == item.ProjectId);
            //        sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {  (project.EndDate == null ? "not finished" : project.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");


            //    }
            //}

            //return sb.ToString().Trim();
        }


        //Task 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var employee = context.Employees
                            .Where(e => e.LastName == "Nakov")
                            .FirstOrDefault();
            employee.AddressId = address.AddressId;
            context.SaveChanges();


            var allEmp = context.Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Select(x => new
                {
                    x.Address.AddressText
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in allEmp)
            {
                sb.AppendLine(e.AddressText);
            }

            return sb.ToString().Trim();

        }

        //Task 3:Employees Full Information
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
                       x.Salary
                   })
                   .OrderBy(x => x.EmployeeId)
                   .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {(emp.MiddleName == null ? "" : emp.MiddleName + " ")}{emp.JobTitle} {emp.Salary:F2}");
            }

            return sb.ToString().Trim();

        }


        //Task 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }


            return sb.ToString().Trim();

        }

        //Task 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.DepartmentName} - ${emp.Salary:F2}");
            }
            return sb.ToString().Trim();
        }
    }
}
