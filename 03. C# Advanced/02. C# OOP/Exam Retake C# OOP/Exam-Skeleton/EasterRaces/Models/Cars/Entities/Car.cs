using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => this.model;

            private set
            {
                if (value.Length < 4 ||
                    string.IsNullOrWhiteSpace(value))
                {

                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                this.model = value;

            }

        }
        public int MinHorsePower
        {
            get => this.minHorsePower;
            private set
            {
                this.minHorsePower = value;
            }

        }

        public int MaxHorsePower
        {
            get => this.maxHorsePower;
            private set
            {
                this.maxHorsePower = value;
            }

        }
        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < this.MinHorsePower || value > this.MaxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }

        }

        public double CubicCentimeters
        {
            get => this.cubicCentimeters;
            private set
            {
                this.cubicCentimeters = value;
            }
        }
        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * Convert.ToDouble(laps);
        }
    }
}
