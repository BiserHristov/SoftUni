using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace P04.PizzaCalories
{
    public class Dough
    {
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 200;
        private const double DEFAULT_CALORIES = 2;
        private string flourType;
        private string bakingTechnique;
        private int weight;
        private Dictionary<string, double> validFlourType;
        private Dictionary<string, double> validBakingTechnique;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.validBakingTechnique = new Dictionary<string, double>();
            this.validFlourType = new Dictionary<string, double>();
            this.LoadBakingtechnique();
            this.LoadFlourType();
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;


        }
        public int Weight
        {
            get => this.weight;
            set
            {
                if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
                }

                this.weight = value;
            }
        }
        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!validFlourType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");

                }

                this.flourType = value.ToLower();

            }

        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!validBakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");

                }
                this.bakingTechnique = value.ToLower();
            }


        }

        private void LoadFlourType()
        {
            this.validFlourType.Add("white", 1.5);
            this.validFlourType.Add("wholegrain", 1.0);

        }

        private void LoadBakingtechnique()
        {
            this.validBakingTechnique.Add("crispy", 0.9);
            this.validBakingTechnique.Add("chewy", 1.1);
            this.validBakingTechnique.Add("homemade", 1.0);

        }

        public double CalculateCalories()
        {
            return DEFAULT_CALORIES * this.weight * validFlourType[this.FlourType] * validBakingTechnique[this.bakingTechnique];
        }

    }
}