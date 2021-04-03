using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class PrisonerXMLOutputModel
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public List<MessageXMLOutputModel> EncryptedMessages { get; set; }
    }
}

//< Prisoner >
//    < Id > 3 </ Id >
//    < Name > Binni Cornhill </ Name >

//       < IncarcerationDate > 1967 - 04 - 29 </ IncarcerationDate >

//       < EncryptedMessages >
