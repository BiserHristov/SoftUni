using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal.Mammals.Feline
{
    public class Cat : Feline
    {
        public Cat(string name, double weight,  string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override void Feed(IFood food)
        {
            if (food.GetType().Name == "Vegetable" ||
               food.GetType().Name == "Meat")
            {
                this.Weight += food.Quantity * 0.3;

                base.Feed(food);
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
           
        }
        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }

}
