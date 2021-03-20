using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("Sale")]
    public class SaleInputModel
    {
        [XmlElement("carId")]
        public int carId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }
    }
}
//< Sales >
//    < Sale >
//        < carId > 105 </ carId >
//        < customerId > 30 </ customerId >
//        < discount > 30 </ discount >
//    </ Sale >