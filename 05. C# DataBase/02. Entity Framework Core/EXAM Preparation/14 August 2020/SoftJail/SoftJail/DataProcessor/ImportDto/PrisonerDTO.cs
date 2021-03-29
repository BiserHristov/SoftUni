using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class PrisonerDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
//< Prisoner id = "15" />