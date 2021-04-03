namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var depsCells = JsonConvert.DeserializeObject<IEnumerable<DepartmentCellJsonInputModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var depCell in depsCells)
            {
                if (!IsValid(depCell) ||
                    depCell.Cells.Count == 0 ||
                    !depCell.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                var department = new Department
                {
                    Name = depCell.Name,
                    Cells = depCell.Cells.Select(c => new Cell
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow
                    }).ToList()
                };

                context.Departments.Add(department);
                context.SaveChanges();
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");

            }

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var deserializedPrisoners = JsonConvert.DeserializeObject<IEnumerable<PrisonerJsonInputModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var currentPrisoner in deserializedPrisoners)
            {
                if (!IsValid(currentPrisoner) ||
                    !currentPrisoner.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = currentPrisoner.FullName,
                    Nickname = currentPrisoner.Nickname,
                    Age = currentPrisoner.Age,
                    IncarcerationDate = DateTime.ParseExact(currentPrisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = currentPrisoner.ReleaseDate == null ? null : (DateTime?)DateTime.ParseExact(currentPrisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = currentPrisoner.Bail,
                    CellId = currentPrisoner.CellId,
                    Mails = currentPrisoner.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    }).ToList()
                };

                context.Prisoners.Add(prisoner);
                context.SaveChanges();
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            return sb.ToString().Trim();

        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var desereliezedOfficers = XmlConverter.Deserializer<OfficerXMLInputModel>(xmlString, "Officers");
            var sb = new StringBuilder();

            foreach (var currentOfficer in desereliezedOfficers)
            {
                if (!IsValid(currentOfficer) ||
                    !currentOfficer.Prisoners.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;

                }



                var officer = new Officer
                {
                    FullName = currentOfficer.Name,
                    Salary = currentOfficer.Money,
                    Position = Enum.Parse<Position>(currentOfficer.Position),
                    Weapon = Enum.Parse<Weapon>(currentOfficer.Weapon),
                    DepartmentId = currentOfficer.DepartmentId,
                    OfficerPrisoners = currentOfficer.Prisoners.Select(p => new OfficerPrisoner
                    {
                        PrisonerId = p.Id
                    }).ToList()
                };

                context.Officers.Add(officer);
                context.SaveChanges();
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            return sb.ToString().Trim();

        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}