using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UserSoldProductsOutputModel
    {
        public UserSoldProductsOutputModel()
        {
            this.ProductsSold = new List<SoldProductOutputModel>();
        }

        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public List<SoldProductOutputModel> ProductsSold { get; set; }

    }
}

//< User >
//  < firstName > Almire </ firstName >
//  < lastName > Ainslee </ lastName >
//  < soldProducts >
//    < Product >
//      < name > olio activ mouthwash</name>
//      <price>206.06</price>
//    </Product>

