namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var depsCells = JsonConvert.DeserializeObject<IEnumerable<DepartmentCellInputModel>>(jsonString);

            var sb = new StringBuilder();
            var departmentsDTO = new List<DepartmentCellInputModel>();

            foreach (var dc in depsCells)
            {
                if (!IsValid(dc) ||
                    dc.Cells.Count == 0 ||
                    !dc.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var currentDepartment = new DepartmentCellInputModel
                {
                    Name = dc.Name,
                    Cells = dc.Cells.Select(c => new CellInputModel
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow
                    }).ToList()
                };

                departmentsDTO.Add(currentDepartment);

                sb.AppendLine($"Imported {currentDepartment.Name} with {currentDepartment.Cells.Count} cells");
            }

            var departments = Mapper.Map<IEnumerable<Department>>(departmentsDTO);

            context.Departments.AddRange(departments);
            context.SaveChanges();
            //var users = mapper.Map<IEnumerable<User>>(usersDto);

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prosonersConverted = JsonConvert.DeserializeObject<IEnumerable<PrisonerInputModel>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            var sb = new StringBuilder();
            var prisonersDTO = new List<PrisonerInputModel>();

            foreach (var currentPrisoner in prosonersConverted)
            {
                if (!IsValid(currentPrisoner) ||
                    !currentPrisoner.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var prisoner = new PrisonerInputModel
                {
                    FullName = currentPrisoner.FullName,
                    Nickname = currentPrisoner.Nickname,
                    Age = currentPrisoner.Age,
                    IncarcerationDate = currentPrisoner.IncarcerationDate,
                    ReleaseDate = currentPrisoner.ReleaseDate,
                    Bail = currentPrisoner.Bail,
                    CellId = currentPrisoner.CellId,
                    Mails = currentPrisoner.Mails.Select(m => new MailInputModel
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    }).ToList()
                };

                prisonersDTO.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            var prisoners = Mapper.Map<IEnumerable<Prisoner>>(prisonersDTO);

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().Trim();

        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {

            const string root = "Officers";
            var serializer = new XmlSerializer(typeof(List<OfficersInputModel>), new XmlRootAttribute(root));
            var deserializedOfficers = (List<OfficersInputModel>)serializer.Deserialize(new StringReader(xmlString));

            var officersDTO = new List<OfficersInputModel>();
            var sb = new StringBuilder();

            foreach (var officer in deserializedOfficers)
            {
                bool positionIsParsed = Enum.TryParse<Position>(officer.Position, false, out Position position);

                bool weaponIsParsed = Enum.TryParse<Weapon>(officer.Weapon, false, out Weapon weapon);

                if (!IsValid(officer) ||
                    !positionIsParsed ||
                    !weaponIsParsed)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                officersDTO.Add(officer);

                sb.AppendLine($"Imported {officer.Name} ({officer.Prisoners.Count()} prisoners)");
            }


           var officers = Mapper.Map<List<Officer>>(officersDTO);

            context.Officers.AddRange(officers);
            context.SaveChanges();

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