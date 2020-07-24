using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Food
{
    public abstract class Food : IFood
    {
        public Food(double quantity)
        {
            this.Quantity = quantity;
        }
        public double Quantity { get;  set; }
    }
}
