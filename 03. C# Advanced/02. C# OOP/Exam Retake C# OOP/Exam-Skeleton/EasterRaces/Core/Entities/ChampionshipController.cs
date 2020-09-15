using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();

        }
        public string CreateDriver(string driverName)
        {
            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            var driver = new Driver(driverName);
            this.drivers.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar searchedCar = cars.GetAll()
                .FirstOrDefault(c => c.Model == model && c.HorsePower == horsePower);

            if (searchedCar != null)// &&
                                    //searchedCar.GetType().Name.Substring(0, searchedCar.GetType().Name.Length-3) == type &&
                                    // searchedCar.HorsePower == horsePower)
            {
                throw new ArgumentException($"Car {model} is already create.");
            }

            ICar car = null;
            string message = string.Empty;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
                message = $"MuscleCar {car.Model} is created.";
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
                message = $"SportsCar {car.Model} is created.";

            }

            cars.Add(car);
            return message;
        }

        public string CreateRace(string name, int laps)
        {
            var searchedRace = races.GetByName(name);

            if (searchedRace != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            var race = new Race(name, laps);
            races.Add(race);

            return $"Race {race.Name} is created.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var driver = drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driver.Name} added in {race.Name} race.";

        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            var car = this.cars.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException($"Car  {carModel} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driver.Name} received car {car.Model}.";
        }

        public string StartRace(string raceName)
        {
            var race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }

            //var list = drivers.GetAll().OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();
            List<IDriver> currenList = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {currenList[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {currenList[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {currenList[2].Name} is third in {race.Name} race.");

            races.Remove(race);
            currenList[0].WinRace();

            return sb.ToString().Trim();

        }
    }
}
