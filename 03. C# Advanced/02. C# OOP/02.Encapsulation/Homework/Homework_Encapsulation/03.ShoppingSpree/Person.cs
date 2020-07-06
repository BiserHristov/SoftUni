using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (!ValidateDecimal(value))
                {
                    throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
                }

                this.money = value;
            }
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
                }
                this.name = value;
            }
        }

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();
 

        private bool ValidateString(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                return false;
            }

            return true;
        }


        private bool ValidateDecimal(decimal param)
        {
            if (param < 0)
            {
                return false;
            }

            return true;
        }
        public string BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                this.products.Add(product);
                return $"{this.Name} bought {product.Name}";

            }
            else
            {
                return $"{this.Name} can't afford {product.Name}";
            }
        }
        public override string ToString()
        {
            return $"{this.Name} - " + (this.Products.Count > 0 ? string.Join(", ", this.Products) : "Nothing bought");
        }
    }
}
