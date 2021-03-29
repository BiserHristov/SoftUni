namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using SoftJail.XMLHelper;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po => new
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = decimal.Parse(p.PrisonerOfficers
                                        .Sum(po => po.Officer.Salary)
                                        .ToString("F2"))
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            string result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return result;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            var prisoners = context.Prisoners
                .Where(p => names.Contains(p.FullName))
                .Select(x => new PrisonerXMLOutputModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = x.Mails.Select(m => new MessageXMLOutputModel
                    {
                        Description = ReverseMe(m.Description)
                    }).ToArray()

                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            var xml = XmlConverter.Serialize(prisoners, "Prisoners");

            return xml;
        }


        private static string ReverseMe(string input)
        {
            // string result = string.Empty;
            //var stringAsCharArray = input.ToCharArray();
            string result = new string(input.ToCharArray().Reverse().ToArray());

            return result;
        }
    }
}

//Export the prisoners: for each prisoner, export its id, name, incarcerationDate in the format “yyyy - MM - dd” and their encrypted mails.The encrypted algorithm you have to use is just to take each prisoner mail description and reverse it.Sort the prisoners by their name(ascending), then by their id(ascending).





//{
//    "Id": 3,
//    "Name": "Binni Cornhill",
//    "CellNumber": 503,
//    "Officers": [
//      {
//        "OfficerName": "Hailee Kennon",
//        "Department": "ArtificialIntelligence"
//      },
//      {
//        "OfficerName": "Theo Carde",
//        "Department": "Blockchain"
//      }
//    ],
//    "TotalOfficerSalary": 7127.93
//  },
