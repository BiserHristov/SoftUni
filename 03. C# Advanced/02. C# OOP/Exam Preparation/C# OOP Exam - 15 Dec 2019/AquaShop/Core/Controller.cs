using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            switch (aquariumType)
            {
                case nameof(FreshwaterAquarium):
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case nameof(SaltwaterAquarium):
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            switch (decorationType)
            {
                case nameof(Ornament):
                    decoration = new Ornament();
                    break;
                case nameof(Plant):
                    decoration = new Plant();
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.Models.FirstOrDefault(d => d.GetType().Name == decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var aquarium = GetAquariumByName(aquariumName);
            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }



        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {

            IFish fish = null;

            switch (fishType)
            {
                case nameof(FreshwaterFish):
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case nameof(SaltwaterFish):
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var aquarium = GetAquariumByName(aquariumName);

            string aquariumType = aquarium.GetType().Name;
            string aquariumTypeShortName = aquariumType.Substring(0, aquariumType.Length - 8);

            string fishTypeAsString = fish.GetType().Name;
            string fishTypeShortName = fishTypeAsString.Substring(0, fishTypeAsString.Length - 4);

            if (aquariumTypeShortName != fishTypeShortName)
            {
                return OutputMessages.UnsuitableWater;
            }
            else
            {
                aquarium.AddFish(fish);

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = GetAquariumByName(aquariumName);


            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = GetAquariumByName(aquariumName);

            var fishPrices = aquarium.Fish.Sum(f => f.Price);
            var decorationPrices = aquarium.Decorations.Sum(d => d.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, (fishPrices + decorationPrices).ToString());

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }

        private IAquarium GetAquariumByName(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            return aquarium;
        }
    }
}
