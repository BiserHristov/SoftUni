using System;
using System.Collections.Generic;
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
            this.Products = products;
        }
        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (!ValidateDecimal(value))
                {
                    throw new ArgumentException("Money cannot be negative");
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
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = new List<Product>();
            }

        }

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

        public override string ToString()
        {
            return $"{this.Name} - " + (this.Products.Count > 0 ? string.Join(", ", this.Products) : "Nothing bought");
        }
    }
}
