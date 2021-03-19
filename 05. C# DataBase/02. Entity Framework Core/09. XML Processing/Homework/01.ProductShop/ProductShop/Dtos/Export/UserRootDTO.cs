using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UserRootDTO
    {
        public UserRootDTO()
        {
            this.Users = new List<UserOutputModel>();
        }    
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<UserOutputModel> Users { get; set; }
    }
}
