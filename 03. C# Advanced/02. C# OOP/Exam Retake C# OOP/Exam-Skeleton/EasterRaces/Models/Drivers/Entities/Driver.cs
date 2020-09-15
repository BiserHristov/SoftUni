using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private bool canParticipate;
        public Driver(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 5 ||
                    string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }

        }
        public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get => this.Car != null;
            private set
            {
                this.canParticipate = value;
            }

        }
        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {

                throw new ArgumentNullException($"Car cannot be null.");
            }

            this.Car = car;
            this.CanParticipate = true;
        }
    }
}
