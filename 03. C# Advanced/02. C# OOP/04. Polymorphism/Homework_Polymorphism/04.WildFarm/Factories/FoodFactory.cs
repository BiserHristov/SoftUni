using _04.WildFarm.Interfaces;
using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    public class FoodFactory
    {
        public IFood ProduceFood(string[] foodArgs)
        {
            IFood food = null;
            string type = foodArgs[0];
            int qty = int.Parse(foodArgs[1]);

            if (type == "Vegetable")
            {
                food = new Vegetable(qty);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(qty);
            }
            else if (type == "Meat")
            {
                food = new Meat(qty);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(qty);
            }

            if (food!=null)
            {
                return food;
            }
            else
            {
                throw new ArgumentException("Invalid food type");
            }
        }
    }
}
