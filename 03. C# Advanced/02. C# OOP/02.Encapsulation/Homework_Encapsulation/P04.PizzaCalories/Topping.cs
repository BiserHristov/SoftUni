using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.PizzaCalories
{
    public class Topping
    {
		private const int BASE_CALORIES = 2;
		private const double MIN_WEIGHT = 1;
		private const double MAX_WEIGHT = 50;
		private double weight;
		private Dictionary<string, double> validToppingType;
		private string toppingType;

		public Topping(string toppingType, double weight)
		{
			this.validToppingType = new Dictionary<string, double>();
			LoadToppingType();
			this.ToppingType = toppingType;
			this.Weight = weight;
		}
		public string ToppingType
		{
			get =>  this.toppingType; 
			set 
			{
				if (!validToppingType.ContainsKey(value.ToLower()))
				{
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");

				}
				//toLower??
				this.toppingType = value.ToLower();
			}
		}

		public double Weight
		{
			get => this.weight;
			set 
			{
				if (value<MIN_WEIGHT || value>MAX_WEIGHT)
				{
					throw new ArgumentException($"{this.ToppingType.First().ToString().ToUpper() + this.ToppingType.Substring(1)} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");

				}

				this.weight = value; 
			}
		}

		public double CalculateCalories()
		{
			return BASE_CALORIES * this.Weight * validToppingType[this.ToppingType];
		}

		private void LoadToppingType()
		{
			this.validToppingType.Add("meat", 1.2);
			this.validToppingType.Add("veggies", 0.8);
			this.validToppingType.Add("cheese", 1.1);
			this.validToppingType.Add("sauce", 0.9);

		}
	}
}
