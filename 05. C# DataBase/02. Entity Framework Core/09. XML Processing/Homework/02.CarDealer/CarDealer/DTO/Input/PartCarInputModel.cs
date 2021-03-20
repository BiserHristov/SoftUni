using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("partId")]
    public class PartCarInputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

//   < parts >
//     < partId id = "38" />
//      < partId id = "102" />
