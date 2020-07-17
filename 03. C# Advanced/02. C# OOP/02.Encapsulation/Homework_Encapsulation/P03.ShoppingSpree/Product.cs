using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;

        }
        public string Name
        {
            get
            {
                return this.name;
            }
           private set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
                }

                this.name = value;

            }
        }
        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (!ValidateDecimal(value))
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;

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

        public override string ToString() => $"{this.Name}";
    }
}
