using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class UserAndProductsSoldProductsOutputModel
    {
        public UserAndProductsSoldProductsOutputModel()
        {
            this.Products = new List<ProductsOutputModel>();
        }
        [XmlElement("count")]
        public int Count { get; set; }  /*=> this.Products.Count;*/

        [XmlArray("products")]
        public List<ProductsOutputModel> Products { get; set; }


    }
}
