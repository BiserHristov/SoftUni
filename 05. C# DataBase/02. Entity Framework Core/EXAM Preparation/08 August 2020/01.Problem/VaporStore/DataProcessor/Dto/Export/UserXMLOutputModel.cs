using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserXMLOutputModel
    {
        public UserXMLOutputModel()
        {
            this.Purchases = new List<PurchaseXMLOutputModel>();
        }

        [XmlAttribute("username")]
        public string UserName { get; set; }

        [XmlArray("Purchases")]
        public List<PurchaseXMLOutputModel> Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}
