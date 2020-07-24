using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }
        public override void Feed(IFood food)
        {
            if (food.GetType().Name == "Meat")
            {

                this.Weight += food.Quantity * 0.25;
                base.Feed(food);
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
