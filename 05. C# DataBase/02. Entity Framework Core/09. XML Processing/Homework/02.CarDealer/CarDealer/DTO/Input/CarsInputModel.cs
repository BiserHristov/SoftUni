using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("Car")]
    public class CarsInputModel
    {

        public CarsInputModel()
        {
            this.PartCars = new List<PartCarInputModel>();
        }

        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public List<PartCarInputModel> PartCars { get; set; }

    }
}

//< Car >
//   < make > Opel </ make >
//   < model > Omega </ model >
//   < TraveledDistance > 176664996 </ TraveledDistance >
//   < parts >
//     < partId id = "38" />
//      < partId id = "102" />


// </ parts >

// </ Car >