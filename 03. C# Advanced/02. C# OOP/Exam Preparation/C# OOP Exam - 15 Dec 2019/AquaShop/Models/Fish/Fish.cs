using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {

        protected int size;
        private string name;
        private string species;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            //ToDO: private?
            private set
            {
                ValidateString(value, ExceptionMessages.InvalidFishName);

                this.name = value;
            }
        }

        public string Species
        {
            get => this.species;
            //ToDO: private?
            private set
            {
                ValidateString(value, ExceptionMessages.InvalidFishSpecies);

                this.species = value;
            }
        }
        //TODO: virtual?
        public abstract int Size { get; protected set; }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }

                this.price = value;
            }
        }

        public abstract void Eat();


        private static void ValidateString(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message);
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
